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
using Animation = org.allbinary.animation.Animation;
using AnimationBehaviorFactory = org.allbinary.animation.AnimationBehaviorFactory;
using AnimationInterfaceFactoryInterface = org.allbinary.animation.AnimationInterfaceFactoryInterface;
using NullAnimationFactory = org.allbinary.animation.NullAnimationFactory;
using AnimationFactoryImageScaleUtil = org.allbinary.image.AnimationFactoryImageScaleUtil;
using ForcedLogUtil = org.allbinary.logic.communication.log.ForcedLogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using ScaleProperties = org.allbinary.media.ScaleProperties;
using CommonLabels = org.allbinary.@string.CommonLabels;
using CommonSeps = org.allbinary.@string.CommonSeps;

namespace org.allbinary.animation.image;

public class BaseImageAnimationFactory : AnimationInterfaceFactoryInterface
{
    // throws Exception
    public static BaseImageAnimationFactory createFactoryBase(Image image, int[] sequenceArray, int width, int height, AnimationBehaviorFactory animationBehaviorFactory)
    {
        return new BaseImageAnimationFactory(image, sequenceArray, width, height, 0, 0, animationBehaviorFactory);
    }

    public readonly AnimationFactoryImageScaleUtil animationFactoryImageScaleUtil = AnimationFactoryImageScaleUtil.getInstance();
    private readonly Image image;
    public readonly AnimationBehaviorFactory animationBehaviorFactory;
    private readonly int[] sequenceArray;
    public readonly AnimationFactoryInitializationVisitor animationFactoryInitializationVisitor;
    public ScaleProperties scaleProperties = ScaleProperties.instance;
    public BaseImageAnimationFactory(Image image, int[] sequenceArray, int width, int height, int dx, int dy, AnimationBehaviorFactory animationBehaviorFactory)
    {
        this.animationFactoryInitializationVisitor = new AnimationFactoryInitializationVisitor();
        this.image = image;
        this.animationFactoryInitializationVisitor.width = width;
        this.animationFactoryInitializationVisitor.height = height;
        this.animationBehaviorFactory = animationBehaviorFactory;
        this.sequenceArray = sequenceArray;
        this.animationFactoryInitializationVisitor.dx = dx;
        this.animationFactoryInitializationVisitor.dy = dy;
    }

    // throws Exception
    public virtual Animation getInstance(int instanceId)
    {
        return NullAnimationFactory.getFactoryInstance().getInstance(instanceId);
    }

    public virtual Image getImage()
    {
        return this.image;
    }

    public virtual int[] getSequenceArray()
    {
        return this.sequenceArray;
    }

    public virtual void setInitialScale(ScaleProperties scaleProperties)
    {
        this.scaleProperties = scaleProperties;
        if (this.scaleProperties.shouldScale) {
            this.scaleProperties.scaleWidth = ((int) (this.animationFactoryInitializationVisitor.width * this.scaleProperties.scaleX));
            this.scaleProperties.scaleHeight = ((int) (this.animationFactoryInitializationVisitor.height * this.scaleProperties.scaleY));
        } else {
        }
    }

    public virtual AnimationFactoryInitializationVisitor getAnimationFactoryInitializationVisitorP()
    {
        return this.animationFactoryInitializationVisitor;
    }

    public virtual ScaleProperties getScalePropertiesP()
    {
        return this.scaleProperties;
    }

    public override string ToString()
    {
        CommonSeps commonSeps = CommonSeps.getInstance();
        CommonLabels commonLabels = CommonLabels.getInstance();
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(base.ToString());
        stringBuffer.append(commonLabels.HEIGHT_LABEL);
        stringBuffer.appendint(((int) this.image.getHeight()));
        stringBuffer.append(commonSeps.SPACE);
        stringBuffer.append(this.animationFactoryInitializationVisitor.ToString());
        return stringBuffer.ToString();
    }

}

