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
//using Sprite = javax.microedition.lcdui.game.Sprite;
//using Player = javax.microedition.media.Player;
using Animation = org.allbinary.animation.Animation;
using AnimationBehaviorFactory = org.allbinary.animation.AnimationBehaviorFactory;
using AnimationInterfaceFactoryInterface = org.allbinary.animation.AnimationInterfaceFactoryInterface;
using IndexedAnimation = org.allbinary.animation.IndexedAnimation;
using CaptionIndexedAnimation = org.allbinary.animation.caption.CaptionIndexedAnimation;
using ImageAnimation = org.allbinary.animation.image.ImageAnimation;
using BasicColorUtil = org.allbinary.graphics.color.BasicColorUtil;
using AnimationFactoryImageScaleUtil = org.allbinary.image.AnimationFactoryImageScaleUtil;
using AnimationFactorySpriteScaleUtil = org.allbinary.image.sprite.AnimationFactorySpriteScaleUtil;
using ForcedLogUtil = org.allbinary.logic.communication.log.ForcedLogUtil;
using ScaleProperties = org.allbinary.media.ScaleProperties;
using Sound = org.allbinary.media.audio.Sound;

namespace org.allbinary.animation.image.sprite;

public class ImageCaptionIndexedAnimationFactory : AnimationInterfaceFactoryInterface
{
    public readonly AnimationFactoryImageScaleUtil animationFactoryImageScaleUtil = AnimationFactoryImageScaleUtil.getInstance();
    private readonly AnimationFactorySpriteScaleUtil animationFactorySpriteScaleUtil = AnimationFactorySpriteScaleUtil.getInstance();
    private Image captionImage;
    private Image spriteMovieImage;
    private int frameWidth;
    private int frameHeight;
    private int captionDx;
    private int captionDy;
    private int dx;
    private int dy;
    private int time;
    private Sound soundInterface;
    public ScaleProperties scaleProperties = ScaleProperties.instance;
    private readonly AnimationBehaviorFactory animationBehaviorFactory;
    public ImageCaptionIndexedAnimationFactory(Image captionImage, Image spriteMovieImage, Sound soundInterface, int frameWidth, int frameHeight, int captionDx, int captionDy, int dx, int dy, int time, AnimationBehaviorFactory animationBehaviorFactory)
    {
        if (animationBehaviorFactory == AnimationBehaviorFactory.getInstance()) {
            ForcedLogUtil.log("Using default AnimationBehaviorFactory with IndexedAnimationFactory", this);
        }
        this.captionImage = captionImage;
        this.spriteMovieImage = spriteMovieImage;
        this.frameWidth = frameWidth;
        this.frameHeight = frameHeight;
        this.captionDx = captionDx;
        this.captionDy = captionDy;
        this.dx = dx;
        this.dy = dy;
        this.time = time;
        this.soundInterface = soundInterface;
        this.animationBehaviorFactory = animationBehaviorFactory;
    }

    // throws Exception
    public virtual Animation getInstance(int instanceId)
    {
        Image scaledImage = this.animationFactoryImageScaleUtil.createImage(this.captionImage, this.captionImage.getWidth(), this.captionImage.getHeight(), this.scaleProperties.scaleWidth, this.scaleProperties.scaleHeight);
        Animation animationInterface = new ImageAnimation(scaledImage, this.animationBehaviorFactory.getOrCreateInstance());
        Sprite sprite = this.animationFactorySpriteScaleUtil.createImage(this.spriteMovieImage, this.frameWidth, this.frameHeight, this.scaleProperties.scaleWidth, this.scaleProperties.scaleHeight);
        IndexedAnimation movieIndexedAnimationInterface = new SpriteIndexedAnimation(sprite, this.spriteMovieImage, BasicColorUtil.getInstance().ZERO_ARRAY, this.animationBehaviorFactory.getOrCreateInstance());
        Player player = this.soundInterface.getPlayerP();
        if (player == null) {
            throw new Exception("Sound Was not Initialized");
        }
        return new CaptionIndexedAnimation(animationInterface, movieIndexedAnimationInterface, player, this.captionDx, this.captionDy, this.dx, this.dy, this.time, this.animationBehaviorFactory.getOrCreateInstance());
    }

    public virtual void setInitialScale(ScaleProperties scaleProperties)
    {
        this.scaleProperties = scaleProperties;
    }

}

