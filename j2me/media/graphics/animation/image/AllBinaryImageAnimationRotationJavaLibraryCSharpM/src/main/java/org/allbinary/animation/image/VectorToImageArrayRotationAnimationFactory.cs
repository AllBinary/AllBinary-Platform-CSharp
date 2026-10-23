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
using VectorAnimation = org.allbinary.animation.VectorAnimation;
using GameConfigurationCentral = org.allbinary.game.configuration.GameConfigurationCentral;
using BasicColor = org.allbinary.graphics.color.BasicColor;
using AnimationFrameToImageUtil = org.allbinary.image.AnimationFrameToImageUtil;
using PrimitiveIntUtil = org.allbinary.logic.math.PrimitiveIntUtil;
using AngleFactory = org.allbinary.math.AngleFactory;
using AngleInfo = org.allbinary.math.AngleInfo;
using ScaleProperties = org.allbinary.media.ScaleProperties;
using ImageToRotationImageArrayUtil = org.allbinary.media.image.ImageToRotationImageArrayUtil;
using VectorInfo = org.allbinary.vector.VectorInfo;

namespace org.allbinary.animation.image;

public class VectorToImageArrayRotationAnimationFactory : BaseImageAnimationFactory
{
    private Image[] imageArray = NullImage.NULL_IMAGE_ARRAY;
    private int angleIncrement = 0;
    public VectorToImageArrayRotationAnimationFactory(VectorInfo vectorInfo, BasicColor basicColor, AnimationBehaviorFactory animationBehaviorFactory) : base(AnimationFrameToImageUtil.getInstance().getInstanceTranslate(vectorInfo.getWidth(), vectorInfo.getHeight(), VectorAnimation.createVectorAnimation(vectorInfo.getPoints(), basicColor, animationBehaviorFactory.getOrCreateInstance())), PrimitiveIntUtil.getArrayInstance(), 0, 0, 0, 0, animationBehaviorFactory)
    {
        // base(AnimationFrameToImageUtil.getInstance().getInstanceTranslate(vectorInfo.getWidth(), vectorInfo.getHeight(), VectorAnimation.createVectorAnimation(vectorInfo.getPoints(), basicColor, animationBehaviorFactory.getOrCreateInstance())), PrimitiveIntUtil.getArrayInstance(), 0, 0, 0, 0, animationBehaviorFactory) is called from the constructor declaration
        this.init();
    }

    // throws Exception
    public virtual void init()
    {
        AngleFactory angleFactory = AngleFactory.getInstance();
        this.angleIncrement = angleFactory.TOTAL_ANGLE / GameConfigurationCentral.getInstance().getGameControlFidelity();
        this.imageArray = ImageToRotationImageArrayUtil.getInstance().generate(this.getImage(), this.getAngleIncrement(), ((int) angleFactory.TOTAL_ANGLE));
    }

    // throws Exception
    public override Animation getInstance(int instanceId)
    {
        if (this.animationFactoryInitializationVisitor.dx != 0 || this.animationFactoryInitializationVisitor.dy != 0) {
            return new AdjustedImageArrayRotationAnimation(this.imageArray, AngleInfo.getInstance(((short) this.getAngleIncrement())), ((int) AngleFactory.getInstance().TOTAL_ANGLE), this.animationFactoryInitializationVisitor.dx, this.animationFactoryInitializationVisitor.dy, this.animationBehaviorFactory.getOrCreateInstance());
        } else {
            return AdjustedImageArrayRotationAnimation.createAnimation(this.imageArray, AngleInfo.getInstance(((short) this.angleIncrement)), ((int) AngleFactory.getInstance().TOTAL_ANGLE), this.animationBehaviorFactory.getOrCreateInstance());
        }
    }

    public virtual int getAngleIncrement()
    {
        return this.angleIncrement;
    }

    public override void setInitialScale(ScaleProperties scaleProperties)
    {
    }

}

