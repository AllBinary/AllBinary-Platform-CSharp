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
using System.Runtime.CompilerServices;
//using Graphics = javax.microedition.lcdui.Graphics;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using ForcedLogUtil = org.allbinary.logic.communication.log.ForcedLogUtil;
using CircleFilledAnimation = org.allbinary.animation.vector.CircleFilledAnimation;
using AllBinaryTiledLayer = org.allbinary.game.layer.AllBinaryTiledLayer;
using GPoint = org.allbinary.graphics.GPoint;
using PointFactory = org.allbinary.graphics.PointFactory;
using Rectangle = org.allbinary.graphics.Rectangle;
using BasicColor = org.allbinary.graphics.color.BasicColor;
using BasicColorFactory = org.allbinary.graphics.color.BasicColorFactory;
using ColorCompositeInterface = org.allbinary.graphics.color.ColorCompositeInterface;
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;
using AllBinaryEventObject = org.allbinary.logic.util.@event.AllBinaryEventObject;
using EventStrings = org.allbinary.logic.util.@event.EventStrings;
using BasicGeographicMap = org.allbinary.media.graphics.geography.map.BasicGeographicMap;
using BasicGeographicMapCellPositionFactory = org.allbinary.media.graphics.geography.map.BasicGeographicMapCellPositionFactory;
using GeographicMapCellPosition = org.allbinary.media.graphics.geography.map.GeographicMapCellPosition;
using GeographicMapCellPositionEvent = org.allbinary.media.graphics.geography.map.@event.GeographicMapCellPositionEvent;
using GeographicMapCellPositionEventHandler = org.allbinary.media.graphics.geography.map.@event.GeographicMapCellPositionEventHandler;
using GeographicMapCellPositionEventListenerInterface = org.allbinary.media.graphics.geography.map.@event.GeographicMapCellPositionEventListenerInterface;
using ViewPositionBase = org.allbinary.view.ViewPositionBase;

namespace org.allbinary.game.layer.geographic.map;

public class MiniMapLayer : AllBinaryLayer, GeographicMapCellPositionEventListenerInterface
{
    public readonly AllBinaryTiledLayer allBinaryTiledLayer;
    private readonly BasicGeographicMapCellPositionFactory geographicMapCellPositionFactory;
    private readonly BasicArrayList list;
    private readonly BasicArrayList basicColorList;
    private readonly BasicArrayList positionList;
    private CircleFilledAnimation animationInterface;
    public MiniMapLayer(BasicGeographicMap geographicMapInterface, ViewPositionBase viewPosition) : base(StringUtil.getInstance().EMPTY_STRING, new Rectangle(PointFactory.getInstance().createXY(0, viewPosition.getY()), geographicMapInterface.getAllBinaryTiledLayer().getWidth(), geographicMapInterface.getAllBinaryTiledLayer().getHeight()), viewPosition)
    {
        // base(StringUtil.getInstance().EMPTY_STRING, new Rectangle(PointFactory.getInstance().createXY(0, viewPosition.getY()), geographicMapInterface.getAllBinaryTiledLayer().getWidth(), geographicMapInterface.getAllBinaryTiledLayer().getHeight()), viewPosition) is called from the constructor declaration
        this.allBinaryTiledLayer = geographicMapInterface.getAllBinaryTiledLayer();
        this.geographicMapCellPositionFactory = geographicMapInterface.getGeographicMapCellPositionFactory();
        this.animationInterface = new CircleFilledAnimation(this.allBinaryTiledLayer.getCellWidth(), this.allBinaryTiledLayer.getCellHeight(), BasicColorFactory.getInstance().WHITE);
        this.list = new BasicArrayListD();
        this.basicColorList = new BasicArrayListD();
        this.positionList = new BasicArrayListD();
        GeographicMapCellPositionEventHandler.getInstance().addListener(this);
        this.init();
    }

    // throws Exception
    protected virtual void init()
    {
        this.allBinaryTiledLayer.setPosition(this.x, this.y, this.z);
    }

    public override void onEvent(AllBinaryEventObject eventObject)
    {
        ForcedLogUtil.log(EventStrings.getInstance().PERFORMANCE_MESSAGE, this);
    }

    // throws Exception
    [MethodImpl(MethodImplOptions.Synchronized)]
    public override void onRemoveGeographicMapCellPositionEvent(GeographicMapCellPositionEvent geographicMapCellPositionEvent)
    {
        ColorCompositeInterface colorCompositeInterface = ((ColorCompositeInterface) geographicMapCellPositionEvent.getSource());
        int index = this.list.indexOf(colorCompositeInterface);
        if (index >= 0) {
            this.list.removeAt(index);
            this.basicColorList.removeAt(index);
            this.positionList.removeAt(index);
        }
    }

    // throws Exception
    [MethodImpl(MethodImplOptions.Synchronized)]
    public override void onGeographicMapCellPositionEvent(GeographicMapCellPositionEvent geographicMapCellPositionEvent)
    {
        ColorCompositeInterface colorCompositeInterface = ((ColorCompositeInterface) geographicMapCellPositionEvent.getSource());
        int layerIndex = -1;
        int size = this.list.size();
        ColorCompositeInterface nextColorCompositeInterface = null;
        for (int index = 0; index < size; index++) {
            nextColorCompositeInterface = ((ColorCompositeInterface) this.list.get(index));
            if (nextColorCompositeInterface == colorCompositeInterface) {
                layerIndex = index;
                break;
            }
        }
        GeographicMapCellPosition geographicMapCellPosition = this.geographicMapCellPositionFactory.getInstance(geographicMapCellPositionEvent.getGeographicMapCellPosition());
        GPoint point = geographicMapCellPosition.getPoint();
        if (layerIndex == -1) {
            this.list.add(colorCompositeInterface);
            BasicColor basicColor = colorCompositeInterface.getBasicColorP();
            this.basicColorList.add(basicColor);
            this.positionList.add(point);
            layerIndex = this.basicColorList.size() - 1;
        } else {
            this.positionList.set(layerIndex, point);
        }
    }

    public virtual void paintDots(Graphics graphics)
    {
        BasicArrayList localPositionList = this.positionList;
        BasicArrayList localBasicColorList = this.basicColorList;
        int length = localPositionList.size();
        GPoint point = null;
        BasicColor basicColor = null;
        for (int index = length; --index >= 0; ) {
            point = ((GPoint) localPositionList.get(index));
            basicColor = ((BasicColor) localBasicColorList.get(index));
            graphics.setColor(((int) basicColor));
            this.animationInterface.setBasicColorP(basicColor);
            this.animationInterface.paintXY(graphics, point.getX() + this.x, point.getY() + this.y);
        }
    }

    public override void paint(Graphics graphics)
    {
        this.allBinaryTiledLayer.paint(graphics);
        this.paintDots(graphics);
    }

}

