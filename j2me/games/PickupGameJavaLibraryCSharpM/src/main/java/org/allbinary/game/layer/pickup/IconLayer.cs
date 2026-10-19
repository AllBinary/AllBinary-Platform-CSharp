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
using Animation = org.allbinary.animation.Animation;
using NullAnimationFactory = org.allbinary.animation.NullAnimationFactory;
using PointFactory = org.allbinary.graphics.PointFactory;
using Rectangle = org.allbinary.graphics.Rectangle;
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using ViewPosition = org.allbinary.view.ViewPosition;

namespace org.allbinary.game.layer.pickup;

public class IconLayer : AllBinaryLayer
{
    public static readonly IconLayer NULL_ICON_LAYER = new IconLayer(NullAnimationFactory.getFactoryInstance().getInstance(0), 0, 0);
    private Animation animationInterface;
    public IconLayer(Animation animationInterface, int width, int height) : base(StringUtil.getInstance().EMPTY_STRING, new Rectangle(PointFactory.getInstance().ZERO_ZERO, width, height), ViewPosition.getInstanceD())
    {
        // base(StringUtil.getInstance().EMPTY_STRING, new Rectangle(PointFactory.getInstance().ZERO_ZERO, width, height), ViewPosition.getInstanceD()) is called from the constructor declaration
        this.animationInterface = animationInterface;
    }

    public override void paint(Graphics graphics)
    {
        this.animationInterface.paintXY(graphics, this.x, this.y);
    }

    public override void paintThreed(Graphics graphics)
    {
        this.animationInterface.paintThreedXYZ(graphics, this.x, this.y, this.z);
    }

    public virtual Animation getAnimationInterface()
    {
        return this.animationInterface;
    }

}

