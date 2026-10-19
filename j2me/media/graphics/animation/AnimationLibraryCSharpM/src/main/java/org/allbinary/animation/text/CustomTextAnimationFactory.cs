/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2022 AllBinary 
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
//using Font = javax.microedition.lcdui.Font;
using Animation = org.allbinary.animation.Animation;
using AnimationBehaviorFactory = org.allbinary.animation.AnimationBehaviorFactory;
using AnimationInterfaceFactoryInterface = org.allbinary.animation.AnimationInterfaceFactoryInterface;
using BasicColor = org.allbinary.graphics.color.BasicColor;
using BasicColorFactory = org.allbinary.graphics.color.BasicColorFactory;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using ScaleProperties = org.allbinary.media.ScaleProperties;

namespace org.allbinary.animation.text;

public class CustomTextAnimationFactory : AnimationInterfaceFactoryInterface
{
    public static CustomTextAnimationFactory createDXY(string text, int fontSize, int dx, int dy, AnimationBehaviorFactory animationBehaviorFactory)
    {
        CustomTextAnimationFactory customTextAnimationFactory = new CustomTextAnimationFactory(text, fontSize, animationBehaviorFactory);
        customTextAnimationFactory.dx = dx;
        customTextAnimationFactory.dy = dy;
        return customTextAnimationFactory;
    }

    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly AnimationBehaviorFactory animationBehaviorFactory;
    public BasicColor basicColor = BasicColorFactory.getInstance().BLACK;
    private string text;
    private int initScaleHeight;
    public int dx = 0;
    public int dy = 0;
    public Font font;
    public ScaleProperties scaleProperties;
    public CustomTextAnimationFactory(string text, int fontSize, AnimationBehaviorFactory animationBehaviorFactory)
    {
        this.scaleProperties = new ScaleProperties();
        this.text = text;
        this.scaleProperties.scaleHeight = fontSize - (fontSize / 4);
        this.initScaleHeight = this.scaleProperties.scaleHeight;
        this.animationBehaviorFactory = animationBehaviorFactory;
        this.font = Font.getFont(Font.FACE_SYSTEM, Font.STYLE_PLAIN, this.initScaleHeight);
    }

    // throws Exception
    public virtual Animation getInstance(int instanceId)
    {
        CustomTextAnimation customTextAnimation = null;
        if (this.dx != 0 || this.dy != 0) {
            customTextAnimation = new AdjustCustomTextAnimation(this.text, this.scaleProperties.scaleHeight, this.dx, this.dy, this.animationBehaviorFactory.getOrCreateInstance());
        } else {
            customTextAnimation = new CustomTextAnimation(this.text, this.scaleProperties.scaleHeight, this.animationBehaviorFactory.getOrCreateInstance());
        }
        customTextAnimation.setBasicColorP(this.basicColor);
        return customTextAnimation;
    }

    public virtual void setInitialScale(ScaleProperties scaleProperties)
    {
    }

    public virtual int getWidth()
    {
        return this.font.stringWidth(this.text);
    }

    public virtual int getHeight()
    {
        return this.font.getHeight();
    }

}

