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
//using GL = javax.microedition.khronos.opengles.GL;
//using Graphics = javax.microedition.lcdui.Graphics;
using Rectangle = org.allbinary.graphics.Rectangle;
using BasicColor = org.allbinary.graphics.color.BasicColor;
using BasicColorFactory = org.allbinary.graphics.color.BasicColorFactory;
using BasicColorSetUtil = org.allbinary.graphics.color.BasicColorSetUtil;
using NullPaintable = org.allbinary.graphics.paint.NullPaintable;
using Paintable = org.allbinary.graphics.paint.Paintable;
using OpenGLSurfaceChangedInterface = org.allbinary.image.opengles.OpenGLSurfaceChangedInterface;
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;
using AllBinaryLayerManager = org.allbinary.layer.AllBinaryLayerManager;
using ForcedLogUtil = org.allbinary.logic.communication.log.ForcedLogUtil;
using AllBinaryEventObject = org.allbinary.logic.util.@event.AllBinaryEventObject;
using EventStrings = org.allbinary.logic.util.@event.EventStrings;
using CommonStrings = org.allbinary.@string.CommonStrings;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using ViewPositionBase = org.allbinary.view.ViewPositionBase;
using ViewPositionEvent = org.allbinary.view.@event.ViewPositionEvent;
using ViewPositionEventListenerInterface = org.allbinary.view.@event.ViewPositionEventListenerInterface;

namespace org.allbinary.game.layer;

public class AllBinaryGameLayer : AllBinaryLayer, ViewPositionEventListenerInterface, OpenGLSurfaceChangedInterface
{
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    public readonly BasicColorSetUtil basicSetColorUtil = BasicColorSetUtil.getInstance();
    public readonly BasicColor RED = BasicColorFactory.getInstance().RED;
    private readonly Paintable paintable = (SWTUtil.isSWT ? new Paintable()
#if JAVA_ANONYMOUS_CLASS_BODY
        private readonly BasicColorSetUtil basicSetColorUtil = BasicColorSetUtil.getInstance();
        private readonly BasicColor BLACK = BasicColorFactory.getInstance().BLACK;
        public virtual void paint(Graphics graphics)
        {
            this.basicSetColorUtil.setBasicColorP(graphics, this.BLACK);
        }

#endif
 : NullPaintable.getInstance());
    private readonly BasicArrayList gameKeyEventList = new BasicArrayListD();
    public AllBinaryGameLayer(string name, Rectangle layerInfo, ViewPositionBase viewPosition) : base(name, layerInfo, viewPosition)
    {
        // base(name, layerInfo, viewPosition) is called from the constructor declaration
    }

    // throws Exception
    public override void set(GL gl)
    {
        throw new Exception(this.commonStrings.NOT_IMPLEMENTED);
    }

    public virtual void move()
    {
    }

    public virtual BasicArrayList getGameKeyEventList()
    {
        return this.gameKeyEventList;
    }

    // throws Exception
    public virtual void processInput(AllBinaryLayerManager allBinaryLayerManager)
    {
        throw new Exception(this.commonStrings.NOT_IMPLEMENTED);
    }

    // throws Exception
    public virtual void processTick(AllBinaryLayerManager allBinaryLayerManager)
    {
        throw new Exception(this.commonStrings.NOT_IMPLEMENTED);
    }

    public override void onEvent(AllBinaryEventObject eventObject)
    {
        ForcedLogUtil.log(EventStrings.getInstance().PERFORMANCE_MESSAGE, this);
    }

    // throws Exception
    public virtual void onViewPositionChangeEvent()
    {
        this.onChangeEvent(this.viewPositionEvent);
    }

    // throws Exception
    public override void onChangeEvent(ViewPositionEvent layerManagerEvent)
    {
        if (GameLayerUtil.isOnScreen(this)) {
            this.setVisible(true);
        } else {
            this.setVisible(false);
        }
    }

    public virtual void paintFirst(Graphics graphics)
    {
        this.paintable.paint(graphics);
    }

    public virtual void paintDebug(Graphics graphics)
    {
        ViewPositionBase viewPosition = this.getViewPosition();
        int viewX = viewPosition.getX();
        int viewY = viewPosition.getY();
        this.basicSetColorUtil.setBasicColorP(graphics, this.RED);
        graphics.drawRect(viewX, viewY, this.getWidth(), this.getHeight());
    }

    public virtual void setWidth(int width)
    {
        base.setLayerWidth(width);
        this.setHalfWidth(width >> 1);
    }

    public virtual void setHeight(int height)
    {
        base.setLayerHeight(height);
        this.setHalfHeight(height >> 1);
    }

}

