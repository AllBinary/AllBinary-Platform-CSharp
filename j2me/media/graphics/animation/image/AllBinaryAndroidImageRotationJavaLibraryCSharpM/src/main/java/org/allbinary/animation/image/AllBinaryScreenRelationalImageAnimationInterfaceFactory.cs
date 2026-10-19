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
using GameFeatureImageCacheFactory = org.allbinary.image.GameFeatureImageCacheFactory;
using Animation = org.allbinary.animation.Animation;
using AnimationBehaviorFactory = org.allbinary.animation.AnimationBehaviorFactory;
using ScreenRelationalUtil = org.allbinary.graphics.displayable.ScreenRelationalUtil;
using PrimitiveIntUtil = org.allbinary.logic.math.PrimitiveIntUtil;
using ImageScaleUtil = org.allbinary.media.image.ImageScaleUtil;
using AndroidImageInterface = org.microemu.android.device.AndroidImageInterface;

namespace org.allbinary.animation.image;

public class AllBinaryScreenRelationalImageAnimationInterfaceFactory : BaseImageAnimationFactory
{
    private Image lastImage = NullImage.NULL_IMAGE;
    public AllBinaryScreenRelationalImageAnimationInterfaceFactory(Image image, AnimationBehaviorFactory animationBehaviorFactory) : base(image, PrimitiveIntUtil.getArrayInstance(), 0, 0, 0, 0, animationBehaviorFactory)
    {
        // base(image, PrimitiveIntUtil.getArrayInstance(), 0, 0, 0, 0, animationBehaviorFactory) is called from the constructor declaration
        if (this.lastImage != NullImage.NULL_IMAGE) {
            AndroidImageInterface androidImageInterface = ((AndroidImageInterface) this.lastImage);
            androidImageInterface.getBitmap().recycle();
        }
        float scale = ScreenRelationalUtil.getInstance().getScaleImage(image);
        this.lastImage = ImageScaleUtil.getInstance().createImage(GameFeatureImageCacheFactory.getInstance(), this.getImage(), scale, scale, false);
    }

    // throws Exception
    public override Animation getInstance(int instanceId)
    {
        return new ImageAnimation(this.lastImage, this.animationBehaviorFactory.getOrCreateInstance());
    }

}

