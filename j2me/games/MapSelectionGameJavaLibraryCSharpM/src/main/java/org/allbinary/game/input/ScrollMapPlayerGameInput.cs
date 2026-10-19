/*
 *
 * AllBinary Open License Version 1
 * Copyright (c) 2011 AllBinary
 * 
 * By agreeing to this license you and any business entity you represent are
 * legally bound to the AllBinary Open License Version 1 legal agreement.
 * 
 * You may obtain the AllBinary Open License Version 1 legal agreement from
 * AllBinary or the root directory of AllBinary's AllBinary Platform repository.
 * 
 * Created By: Travis Berthelot
 *  
 */
// Generated Code Do Not Modify

using System;
using System.Linq;
//using Canvas = javax.microedition.lcdui.Canvas;
//using Graphics = javax.microedition.lcdui.Graphics;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using Features = org.allbinary.game.configuration.feature.Features;
using InputFeatureFactory = org.allbinary.game.configuration.feature.InputFeatureFactory;
using GameKeyEvent = org.allbinary.game.input.@event.GameKeyEvent;
using AllBinaryGameLayerManager = org.allbinary.game.layer.AllBinaryGameLayerManager;
using AllBinaryTiledLayer = org.allbinary.game.layer.AllBinaryTiledLayer;
using DisplayInfoSingleton = org.allbinary.graphics.displayable.DisplayInfoSingleton;
using AllBinaryLayerManager = org.allbinary.layer.AllBinaryLayerManager;
using ScrollMapEvent = org.allbinary.layer.@event.ScrollMapEvent;
using ScrollMapEventHandler = org.allbinary.layer.@event.ScrollMapEventHandler;
using BasicGeographicMap = org.allbinary.media.graphics.geography.map.BasicGeographicMap;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.game.input;

public class ScrollMapPlayerGameInput : PlayerGameInput
{
    public readonly GameInputProcessor[] inputProcessorArray = new GameInputProcessor[InputFactory.getInstance().MAX];
    private readonly int border = 150;
    private readonly BasicArrayList inputList;
    public readonly bool isSingleKeyProcessing = Features.getInstance().isFeature(InputFeatureFactory.getInstance().SINGLE_KEY_REPEAT_PRESS) || Features.getInstance().isFeature(InputFeatureFactory.getInstance().SINGLE_KEY_PRESS);
    private readonly BasicGeographicMap geographicMapInterface;
    private int maxBottom = 0;
    private int maxRight = 0;
    public ScrollMapPlayerGameInput(BasicGeographicMap geographicMapInterface, BasicArrayList list, int playerInputId) : base(list, new BasicArrayListD(), playerInputId)
    {
        this.scrollMapEvent = new ScrollMapEvent(this);
        // base(list, new BasicArrayListD(), playerInputId) is called from the constructor declaration
        this.initInputProcessors();
        this.geographicMapInterface = geographicMapInterface;
        this.inputList = list;
        this.init();
    }

    private readonly ScrollMapEvent scrollMapEvent;
    // throws Exception
    private void move(int dx, int dy)
    {
        AllBinaryTiledLayer terrainTiledLayer = this.geographicMapInterface.getAllBinaryTiledLayer();
        terrainTiledLayer.moveDXY(-dx, -dy);
        this.scrollMapEvent.setDxDy(-dx, -dy);
        ScrollMapEventHandler.getInstance().fireEvent(this.scrollMapEvent);
    }

    public virtual void init()
    {
        this.maxBottom = this.getSpecialHeight();
        this.maxRight = this.getSpecialWidth();
    }

    // throws Exception
    public virtual void scrollMiddleX()
    {
        AllBinaryTiledLayer terrainTiledLayer = this.geographicMapInterface.getAllBinaryTiledLayer();
        DisplayInfoSingleton displayInfo = DisplayInfoSingleton.getInstance();
        this.move(-terrainTiledLayer.getXP(), 0);
        if (terrainTiledLayer.getWidth() < displayInfo.getLastWidth()) {
            int diffX = ((displayInfo.getLastWidth() - terrainTiledLayer.getWidth()) >> 1);
            this.move(-diffX, 0);
        } else {
            int diffX = ((terrainTiledLayer.getWidth() - displayInfo.getLastWidth()) >> 1);
            this.move(diffX, 0);
        }
    }

    // throws Exception
    public virtual void scrollY(int anchor)
    {
        AllBinaryTiledLayer terrainTiledLayer = this.geographicMapInterface.getAllBinaryTiledLayer();
        DisplayInfoSingleton displayInfo = DisplayInfoSingleton.getInstance();
        if (anchor == Graphics.TOP) {
            this.logUtil.putF("Top", this, "scrollY");
        } else if (anchor == Graphics.BOTTOM) {
            this.logUtil.putF("Bottom", this, "scrollY");
            int diffY = (terrainTiledLayer.getHeight() - displayInfo.getLastHeight());
            this.move(0, diffY);
        } else if (anchor == Graphics.VCENTER) {
            this.logUtil.putF("Center", this, "scrollY");
            int diffY = (terrainTiledLayer.getHeight() - displayInfo.getLastHeight()) / 2;
            this.move(0, diffY);
        } else {
            throw new Exception("No Such Anchor Supported");
        }
    }

    // throws Exception
    protected virtual void up()
    {
        int y = this.geographicMapInterface.getAllBinaryTiledLayer().getYP() - 10;
        if (this.keepOnMapMinY(y)) {
            this.move(0, -10);
        }
    }

    // throws Exception
    protected virtual void down()
    {
        int y = -this.geographicMapInterface.getAllBinaryTiledLayer().getYP() + 10;
        if (this.keepOnMapMaxY(y)) {
            this.move(0, 10);
        }
    }

    // throws Exception
    protected virtual void right()
    {
        int x = this.geographicMapInterface.getAllBinaryTiledLayer().getYP() + 10;
        if (this.keepOnMapMinX(x)) {
            this.move(10, 0);
        }
    }

    // throws Exception
    protected virtual void left()
    {
        int x = -this.geographicMapInterface.getAllBinaryTiledLayer().getYP() - 10;
        if (this.keepOnMapMaxX(x)) {
            this.move(-10, 0);
        }
    }

    public virtual void initInputProcessors()
    {
        this.inputProcessorArray[Canvas.UP] = new ScrollMapUpGameInputProcessor(this);
        this.inputProcessorArray[Canvas.DOWN] = new ScrollMapDownGameInputProcessor(this);
        this.inputProcessorArray[Canvas.KEY_NUM9] = new ScrollMapRightGameInputProcessor(this);
        this.inputProcessorArray[Canvas.KEY_NUM7] = new ScrollMapLeftGameInputProcessor(this);
        GameInputProcessorUtil.init(this.inputProcessorArray);
    }

    // throws Exception
    public virtual void processInputKey(int key)
    {
        this.inputProcessorArray[key].processEvent(AllBinaryGameLayerManager.getNullInstance(), GameKeyEvent.NONE);
    }

    // throws Exception
    public virtual void processInput(AllBinaryLayerManager layerManager)
    {
        try {
            int size = this.inputList.size();
            int key = 0;
            for (int index = 0; index < size; index++) {
                GameKeyEvent gameKeyEvent = ((GameKeyEvent) this.inputList.get(index));
                key = gameKeyEvent.getKey();
                this.processInputKey(key);
            }
            if (this.isSingleKeyProcessing) {
                this.clear();
            } else {
                this.update();
            }
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, this.gameInputStrings.PROCESS_INPUT, e);
        }
    }

    private int getSpecialHeight()
    {
        AllBinaryTiledLayer terrainTiledLayer = this.geographicMapInterface.getAllBinaryTiledLayer();
        DisplayInfoSingleton displayInfo = DisplayInfoSingleton.getInstance();
        if (terrainTiledLayer.getHeight() > displayInfo.getLastHeight()) {
            return terrainTiledLayer.getHeight() - displayInfo.getLastHeight();
        } else {
            return displayInfo.getLastHeight() - terrainTiledLayer.getHeight() + terrainTiledLayer.getCellHeight();
        }
    }

    private int getSpecialWidth()
    {
        AllBinaryTiledLayer terrainTiledLayer = this.geographicMapInterface.getAllBinaryTiledLayer();
        DisplayInfoSingleton displayInfo = DisplayInfoSingleton.getInstance();
        if (terrainTiledLayer.getWidth() > displayInfo.getLastWidth()) {
            return terrainTiledLayer.getWidth() - displayInfo.getLastWidth();
        } else {
            return displayInfo.getLastWidth() - terrainTiledLayer.getWidth() + terrainTiledLayer.getCellWidth();
        }
    }

    public virtual bool keepOnMapMaxY(int newY)
    {
        int y = this.geographicMapInterface.getAllBinaryTiledLayer().getYP();
        if (y > this.maxBottom + this.border) {
            return false;
        } else {
            return true;
        }
    }

    public virtual bool keepOnMapMinY(int newY)
    {
        int y = this.geographicMapInterface.getAllBinaryTiledLayer().getYP();
        if (y < -this.border) {
            return false;
        } else {
            return true;
        }
    }

    public virtual bool keepOnMapMaxX(int newX)
    {
        int x = this.geographicMapInterface.getAllBinaryTiledLayer().getXP();
        if (x < -this.maxRight - this.border) {
            return false;
        } else {
            return true;
        }
    }

    public virtual bool keepOnMapMinX(int newX)
    {
        int x = this.geographicMapInterface.getAllBinaryTiledLayer().getXP();
        if (x > this.border) {
            return false;
        } else {
            return true;
        }
    }

}

