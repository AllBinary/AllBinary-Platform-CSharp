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
//using Graphics = javax.microedition.lcdui.Graphics;
using BasicGroupFactory = org.allbinary.game.identification.BasicGroupFactory;
using Group = org.allbinary.game.identification.Group;
using GPoint = org.allbinary.graphics.GPoint;
using Rectangle = org.allbinary.graphics.Rectangle;
using RectangleFactory = org.allbinary.graphics.RectangleFactory;
using OpenGLFeatureUtil = org.allbinary.graphics.opengles.OpenGLFeatureUtil;
using TsUtil = org.allbinary.TsUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using PositionStrings = org.allbinary.math.PositionStrings;
using CommonLabels = org.allbinary.@string.CommonLabels;
using CommonSeps = org.allbinary.@string.CommonSeps;
using ViewPositionBase = org.allbinary.view.ViewPositionBase;
using ViewPositionEvent = org.allbinary.view.@event.ViewPositionEvent;

namespace org.allbinary.layer;

public class AllBinaryLayer : Layer, LayerInterface
{
    public static readonly AllBinaryLayer NULL_ALLBINARY_LAYER = new AllBinaryLayer(StringUtil.getInstance().EMPTY_STRING, RectangleFactory.SINGLETON, ViewPositionBase.NULL_VIEW_POSITION);
    public readonly ViewPositionEvent viewPositionEvent;
    private int halfWidth = 0;
    private int halfHeight = 0;
    private readonly string name;
    private ViewPositionBase viewPosition = ViewPositionBase.NULL_VIEW_POSITION;
    public AllBinaryLayer(string name, Rectangle rectangle, ViewPositionBase viewPosition) : base(rectangle.getWidth(), rectangle.getHeight())
    {
        this.viewPositionEvent = new ViewPositionEvent(this);
        // base(rectangle.getWidth(), rectangle.getHeight()) is called from the constructor declaration
        string localName = null;
        if (name == null) {
            localName = this.GetType().FullName;
        } else {
            localName = new StringMaker().append(name).append(CommonSeps.getInstance().COLON).append(Convert.ToString(TsUtil.getInstance().hashCode(this), 16)).ToString();
        }
        this.name = localName;
        GPoint point = rectangle.getPoint();
        this.setPosition(point.getX(), point.getY(), point.getZ());
        this.setHalfWidth((this.getWidth() >> 1));
        this.setHalfHeight((this.getHeight() >> 1));
        this.viewPosition = viewPosition;
        this.viewPosition.setAllbinaryLayer(this);
    }

    // throws Exception
    public virtual void onChangeEvent(ViewPositionEvent layerManagerEvent)
    {
    }

    public override void paintThreed(Graphics graphics)
    {
    }

    public override int getX2()
    {
        return this.getXP() + this.getWidth();
    }

    public override int getY2()
    {
        return this.getYP() + this.getHeight();
    }

    public override int getZ2()
    {
        return ((int) (this.getZP() + this.getDepth()));
    }

    public override string getName()
    {
        return this.name;
    }

    protected virtual void setHalfWidth(int halfWidth)
    {
        this.halfWidth = halfWidth;
    }

    public override int getHalfWidth()
    {
        return this.halfWidth;
    }

    protected virtual void setHalfHeight(int halfHeight)
    {
        this.halfHeight = halfHeight;
    }

    public override int getHalfHeight()
    {
        return this.halfHeight;
    }

    public virtual int getHalfDepth()
    {
        return ((int) this.getDepth()) / 2;
    }

    public virtual ViewPositionBase getViewPosition()
    {
        return this.viewPosition;
    }

    public virtual void setViewPosition(ViewPositionBase viewPosition)
    {
        this.viewPosition = viewPosition;
    }

    public override Group[] getGroupInterface()
    {
        return BasicGroupFactory.getInstance().NONE_ARRAY;
    }

    public override bool implmentsTickableInterface()
    {
        return false;
    }

    public override bool implmentsGameInputInterface()
    {
        return false;
    }

    public override bool implmentsArtificialIntelligenceCompositeInterface()
    {
        return false;
    }

    public override bool implmentsCollidableInterface()
    {
        return false;
    }

    public virtual bool implementsThreedInterface()
    {
        return OpenGLFeatureUtil.getInstance().isAnyThreed();
    }

    public override int getType()
    {
        return -1;
    }

    public virtual int getMultiPlayerType()
    {
        return -1;
    }

    private static readonly string TYPE = "Type: ";
    public override void toStringAppend(StringMaker stringBuffer)
    {
        CommonSeps commonSeps = CommonSeps.getInstance();
        PositionStrings positionStrings = PositionStrings.getInstance();
        CommonLabels commonLabels = CommonLabels.getInstance();
        stringBuffer.append(this.getName());
        stringBuffer.append(commonSeps.COLON);
        stringBuffer.append(AllBinaryLayer.TYPE);
        stringBuffer.appendint(this.getType());
        stringBuffer.append(commonSeps.SPACE);
        stringBuffer.append(positionStrings.X_LABEL);
        stringBuffer.appendint(((int) this.getXP()));
        stringBuffer.append(commonSeps.SPACE);
        stringBuffer.append(positionStrings.Y_LABEL);
        stringBuffer.appendint(((int) this.getYP()));
        stringBuffer.append(commonSeps.SPACE);
        stringBuffer.append(positionStrings.Z_LABEL);
        stringBuffer.appendint(((int) this.getZP()));
        stringBuffer.append(commonSeps.SPACE);
        stringBuffer.append(commonLabels.WIDTH_LABEL);
        stringBuffer.appendint(((int) this.getWidth()));
        stringBuffer.append(commonSeps.SPACE);
        stringBuffer.append(commonLabels.HEIGHT_LABEL);
        stringBuffer.appendint(((int) this.getHeight()));
    }

    public override string ToString()
    {
        StringMaker stringBuffer = new StringMaker();
        this.toStringAppend(stringBuffer);
        return stringBuffer.ToString();
    }

}

