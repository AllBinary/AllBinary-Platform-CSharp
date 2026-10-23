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
//using Image = javax.microedition.lcdui.Image;
//using NullImage = javax.microedition.lcdui.NullImage;
using Animation = org.allbinary.animation.Animation;
using AnimationBehaviorFactory = org.allbinary.animation.AnimationBehaviorFactory;
using GameConfigurationCentral = org.allbinary.game.configuration.GameConfigurationCentral;
using PrimitiveIntUtil = org.allbinary.logic.math.PrimitiveIntUtil;
using AngleFactory = org.allbinary.math.AngleFactory;
using AngleInfo = org.allbinary.math.AngleInfo;
using ImageToRotationImageArrayUtil = org.allbinary.media.image.ImageToRotationImageArrayUtil;

namespace org.allbinary.animation.image;

public class AllBinaryArrayImageRotationAnimationFactory : BaseImageAnimationFactory
{
    private Image[] imageArray = NullImage.NULL_IMAGE_ARRAY;
    private int angleIncrement;
    // throws Exception
    public static AllBinaryArrayImageRotationAnimationFactory createFactory(Image image, int dx, int dy)
    {
        AllBinaryArrayImageRotationAnimationFactory arrayImageRotationAnimationFactory = new AllBinaryArrayImageRotationAnimationFactory(image, image.getWidth(), image.getHeight(), AngleFactory.getInstance().TOTAL_ANGLE / GameConfigurationCentral.getInstance().getGameControlFidelity(), AnimationBehaviorFactory.getInstance());
        arrayImageRotationAnimationFactory.initDXY(dx, dy);
        return arrayImageRotationAnimationFactory;
    }

    // throws Exception
    public static AllBinaryArrayImageRotationAnimationFactory createFactoryA(Image image, int dx, int dy, int angleIncrement)
    {
        AllBinaryArrayImageRotationAnimationFactory arrayImageRotationAnimationFactory = new AllBinaryArrayImageRotationAnimationFactory(image, image.getWidth(), image.getHeight(), angleIncrement, AnimationBehaviorFactory.getInstance());
        arrayImageRotationAnimationFactory.initDXY(dx, dy);
        return arrayImageRotationAnimationFactory;
    }

    public AllBinaryArrayImageRotationAnimationFactory(Image image, int width, int height, int angleIncrement, AnimationBehaviorFactory animationBehaviorFactory) : base(image, PrimitiveIntUtil.getArrayInstance(), width, height, 0, 0, animationBehaviorFactory)
    {
        // base(image, PrimitiveIntUtil.getArrayInstance(), width, height, 0, 0, animationBehaviorFactory) is called from the constructor declaration
        this.angleIncrement = angleIncrement;
        this.init();
    }

    // throws Exception
    private void init()
    {
        this.setImageArray(ImageToRotationImageArrayUtil.getInstance().generate(this.getImage(), this.getAngleIncrement(), ((int) AngleFactory.getInstance().TOTAL_ANGLE)));
    }

    private void initDXY(int dx, int dy)
    {
        this.animationFactoryInitializationVisitor.dx = dx;
        this.animationFactoryInitializationVisitor.dy = dy;
        this.animationFactoryInitializationVisitor.originalDx = dx;
        this.animationFactoryInitializationVisitor.originalDy = dy;
    }

    // throws Exception
    public override Animation getInstance(int instanceId)
    {
        Image[] scaledImageArray = new Image[this.imageArray.Length];
        int size = scaledImageArray.Length;
        Image image = this.getImage();
        for (int index = 0; index < size; index++) {
            scaledImageArray[index] = this.animationFactoryImageScaleUtil.createImage(image, image.getWidth(), image.getHeight(), this.scaleProperties.scaleWidth, this.scaleProperties.scaleHeight);
        }
        if (this.animationFactoryInitializationVisitor.dx != 0 || this.animationFactoryInitializationVisitor.dy != 0) {
            this.animationFactoryImageScaleUtil.processAdjust(this);
            return new AdjustedImageArrayRotationAnimation(scaledImageArray, AngleInfo.getInstance(((short) this.getAngleIncrement())), ((int) AngleFactory.getInstance().TOTAL_ANGLE), this.animationFactoryInitializationVisitor.dx, this.animationFactoryInitializationVisitor.dy, this.animationBehaviorFactory.getOrCreateInstance());
        } else {
            return new ImageArrayRotationAnimation(scaledImageArray, AngleInfo.getInstance(((short) this.getAngleIncrement())), ((int) AngleFactory.getInstance().TOTAL_ANGLE), this.animationBehaviorFactory.getOrCreateInstance());
        }
    }

    public virtual void setImageArray(Image[] imageArray)
    {
        this.imageArray = imageArray;
    }

    public virtual int getAngleIncrement()
    {
        return this.angleIncrement;
    }

}

