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
using BaseResourceAnimationInterfaceFactoryInterfaceFactory = org.allbinary.animation.resource.BaseResourceAnimationInterfaceFactoryInterfaceFactory;
using Features = org.allbinary.game.configuration.feature.Features;
using ResourceLoadingLevelFactory = org.allbinary.game.resource.ResourceLoadingLevelFactory;
using OpenGLFeatureFactory = org.allbinary.graphics.opengles.OpenGLFeatureFactory;
using ImageCache = org.allbinary.image.ImageCache;
using ImageCacheFactory = org.allbinary.image.ImageCacheFactory;
using StdUtil = org.allbinary.logic.StdUtil;

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

