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
using AnimationBehaviorFactory = org.allbinary.animation.AnimationBehaviorFactory;
using NullAnimationFactory = org.allbinary.animation.NullAnimationFactory;
using OneRowSpriteIndexedAnimationFactory = org.allbinary.animation.image.sprite.OneRowSpriteIndexedAnimationFactory;
using BaseResourceAnimationInterfaceFactoryInterfaceFactory = org.allbinary.animation.resource.BaseResourceAnimationInterfaceFactoryInterfaceFactory;
using Features = org.allbinary.game.configuration.feature.Features;
using ResourceLoadingLevelFactory = org.allbinary.game.resource.ResourceLoadingLevelFactory;
using ProgressCanvas = org.allbinary.graphics.canvas.transition.progress.ProgressCanvas;
using ProgressCanvasFactory = org.allbinary.graphics.canvas.transition.progress.ProgressCanvasFactory;
using OpenGLFeatureFactory = org.allbinary.graphics.opengles.OpenGLFeatureFactory;
using ImageCache = org.allbinary.image.ImageCache;
using ImageCacheFactory = org.allbinary.image.ImageCacheFactory;
using StdUtil = org.allbinary.logic.StdUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using OperatingSystemFactory = org.allbinary.logic.system.os.OperatingSystemFactory;
using ImageCompleteUtil = org.allbinary.media.image.ImageCompleteUtil;

namespace org.allbinary.input.motion.button;

public class TouchButtonResourceAnimationInterfaceFactoryInterfaceFactory : BaseResourceAnimationInterfaceFactoryInterfaceFactory
{
    public static TouchButtonResourceAnimationInterfaceFactoryInterfaceFactory createFactory()
    {
        return new TouchButtonResourceAnimationInterfaceFactoryInterfaceFactory("TouchButton Animations");
    }

    public TouchButtonResourceAnimationInterfaceFactoryInterfaceFactory(string name) : base(name, StdUtil.getInstance().createHashtable(), StdUtil.getInstance().createHashtable(), StdUtil.getInstance().createHashtable())
    {
        // base(name, StdUtil.getInstance().createHashtable(), StdUtil.getInstance().createHashtable(), StdUtil.getInstance().createHashtable()) is called from the constructor declaration
    }

    // throws Exception
    public override void init(int level)
    {
        this.initImageCache(ImageCacheFactory.getInstance(), level);
    }

    // throws Exception
    public override void initImageCache(ImageCache imageCache, int level)
    {
        if (this.isInitialized()) {
            return;
        }
        int portion = 140;
        string loadingString = new StringMaker().append(this.ToString()).append(" Loading: ").ToString();
        int index = 0;
        ProgressCanvas progressCanvas = ProgressCanvasFactory.getInstance();
        progressCanvas.addPortion(portion, loadingString, index++);
        TouchButtonResource touchButtonBlankResource = TouchButtonBlankResource.getInstance();
        TouchButtonResource touchButtonGenericActionResource = TouchButtonGenericActionResource.getInstance();
        TouchButtonResource touchButtonStartResource = TouchButtonStartResource.getInstance();
        TouchButtonResource touchButtonUpResource = TouchButtonUpResource.getInstance();
        TouchButtonResource touchButtonDownResource = TouchButtonDownResource.getInstance();
        TouchButtonResource touchButtonTurnLeftResource = TouchButtonTurnLeftResource.getInstance();
        TouchButtonResource touchButtonTurnRightResource = TouchButtonTurnRightResource.getInstance();
        TouchButtonResource touchButtonStrafeLeftResource = TouchButtonStrafeLeftResource.getInstance();
        TouchButtonResource touchButtonStrafeRightResource = TouchButtonStrafeRightResource.getInstance();
        Image touchButtonBlankResourceImage = imageCache.getWithKey(touchButtonBlankResource.RESOURCE);
        Image touchButtonGenericActionResourceImage = imageCache.getWithKey(touchButtonGenericActionResource.RESOURCE);
        Image touchButtonStartResourceImage = imageCache.getWithKey(touchButtonStartResource.RESOURCE);
        Image touchButtonUpResourceImage = imageCache.getWithKey(touchButtonUpResource.RESOURCE);
        Image touchButtonDownResourceImage = imageCache.getWithKey(touchButtonDownResource.RESOURCE);
        Image touchButtonTurnLeftResourceImage = imageCache.getWithKey(touchButtonTurnLeftResource.RESOURCE);
        Image touchButtonTurnRightResourceImage = imageCache.getWithKey(touchButtonTurnRightResource.RESOURCE);
        Image touchButtonStrafeLeftResourceImage = imageCache.getWithKey(touchButtonStrafeLeftResource.RESOURCE);
        Image touchButtonStrafeRightResourceImage = imageCache.getWithKey(touchButtonStrafeRightResource.RESOURCE);
        NullAnimationFactory nullAnimationFactory = NullAnimationFactory.getFactoryInstance();
        if (OperatingSystemFactory.getInstance().getOperatingSystemInstance().isOverScan()) {
            imageCache.getWithKey(TouchButtonStartResource.getInstance().HINT);
        }
        progressCanvas.addPortion(portion, loadingString, index++);
        ImageCompleteUtil imageCompleteUtil = ImageCompleteUtil.getInstance();
        progressCanvas.addPortion(portion, loadingString, index++);
        imageCompleteUtil.waitForImage(touchButtonBlankResourceImage, touchButtonBlankResource.RESOURCE);
        this.add(touchButtonBlankResource.RESOURCE, OneRowSpriteIndexedAnimationFactory.createFactory(touchButtonBlankResourceImage, AnimationBehaviorFactory.getInstance()));
        this.add(touchButtonBlankResource.HINT, nullAnimationFactory);
        progressCanvas.addPortion(portion, loadingString, index++);
        imageCompleteUtil.waitForImage(touchButtonGenericActionResourceImage, touchButtonGenericActionResource.RESOURCE);
        this.add(touchButtonGenericActionResource.RESOURCE, OneRowSpriteIndexedAnimationFactory.createFactory(touchButtonGenericActionResourceImage, AnimationBehaviorFactory.getInstance()));
        this.add(touchButtonGenericActionResource.HINT, nullAnimationFactory);
        progressCanvas.addPortion(portion, loadingString, index++);
        imageCompleteUtil.waitForImage(touchButtonStartResourceImage, touchButtonStartResource.RESOURCE);
        this.add(touchButtonStartResource.RESOURCE, OneRowSpriteIndexedAnimationFactory.createFactory(touchButtonStartResourceImage, AnimationBehaviorFactory.getInstance()));
        progressCanvas.addPortion(portion, loadingString, index++);
        imageCompleteUtil.waitForImage(touchButtonUpResourceImage, touchButtonUpResource.RESOURCE);
        this.add(touchButtonUpResource.RESOURCE, OneRowSpriteIndexedAnimationFactory.createFactory(touchButtonUpResourceImage, AnimationBehaviorFactory.getInstance()));
        this.add(touchButtonUpResource.HINT, nullAnimationFactory);
        progressCanvas.addPortion(portion, loadingString, index++);
        imageCompleteUtil.waitForImage(touchButtonDownResourceImage, touchButtonDownResource.RESOURCE);
        this.add(touchButtonDownResource.RESOURCE, OneRowSpriteIndexedAnimationFactory.createFactory(touchButtonDownResourceImage, AnimationBehaviorFactory.getInstance()));
        this.add(touchButtonDownResource.HINT, nullAnimationFactory);
        progressCanvas.addPortion(portion, loadingString, index++);
        imageCompleteUtil.waitForImage(touchButtonTurnLeftResourceImage, touchButtonTurnLeftResource.RESOURCE);
        this.add(touchButtonTurnLeftResource.RESOURCE, OneRowSpriteIndexedAnimationFactory.createFactory(touchButtonTurnLeftResourceImage, AnimationBehaviorFactory.getInstance()));
        this.add(touchButtonTurnLeftResource.HINT, nullAnimationFactory);
        progressCanvas.addPortion(portion, loadingString, index++);
        imageCompleteUtil.waitForImage(touchButtonTurnRightResourceImage, touchButtonTurnRightResource.RESOURCE);
        this.add(touchButtonTurnRightResource.RESOURCE, OneRowSpriteIndexedAnimationFactory.createFactory(touchButtonTurnRightResourceImage, AnimationBehaviorFactory.getInstance()));
        this.add(touchButtonTurnRightResource.HINT, nullAnimationFactory);
        progressCanvas.addPortion(portion, loadingString, index++);
        imageCompleteUtil.waitForImage(touchButtonStrafeLeftResourceImage, touchButtonStrafeLeftResource.RESOURCE);
        this.add(touchButtonStrafeLeftResource.RESOURCE, OneRowSpriteIndexedAnimationFactory.createFactory(touchButtonStrafeLeftResourceImage, AnimationBehaviorFactory.getInstance()));
        this.add(touchButtonStrafeLeftResource.HINT, nullAnimationFactory);
        progressCanvas.addPortion(portion, loadingString, index++);
        imageCompleteUtil.waitForImage(touchButtonStrafeRightResourceImage, touchButtonStrafeRightResource.RESOURCE);
        this.add(touchButtonStrafeRightResource.RESOURCE, OneRowSpriteIndexedAnimationFactory.createFactory(touchButtonStrafeRightResourceImage, AnimationBehaviorFactory.getInstance()));
        this.add(touchButtonStrafeRightResource.HINT, nullAnimationFactory);
        if (OperatingSystemFactory.getInstance().getOperatingSystemInstance().isOverScan()) {
            Image touchButtonStartHintResource = imageCache.getWithKey(TouchButtonStartResource.getInstance().HINT);
            this.add(touchButtonStartResource.HINT, OneRowSpriteIndexedAnimationFactory.createFactory(touchButtonStartHintResource, AnimationBehaviorFactory.getInstance()));
        } else {
            this.add(touchButtonStartResource.HINT, nullAnimationFactory);
        }
        base.init(level);
    }

    public override bool isLoadingLevel(int level)
    {
        ResourceLoadingLevelFactory resourceLoadingLevelFactory = ResourceLoadingLevelFactory.getInstance();
        if (level == resourceLoadingLevelFactory.LOAD_TOUCH.getLevel()) {
            return true;
        } else {
            return base.isLoadingLevel(level);
        }
    }

    public override bool isFeature()
    {
        if (!Features.getInstance().isDefault(OpenGLFeatureFactory.getInstance().OPENGL)) {
            return true;
        } else {
            return false;
        }
    }

}

