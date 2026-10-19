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
using Features = org.allbinary.game.configuration.feature.Features;
using OpenGLFeatureFactory = org.allbinary.graphics.opengles.OpenGLFeatureFactory;
using OpenGLImageCacheFactory = org.allbinary.image.opengles.OpenGLImageCacheFactory;

namespace org.allbinary.input.motion.button;

public class TouchButtonResourceOpenGLESAnimationInterfaceFactoryInterfaceFactory : TouchButtonResourceAnimationInterfaceFactoryInterfaceFactory
{
    public TouchButtonResourceOpenGLESAnimationInterfaceFactoryInterfaceFactory() : base("OpenGL TouchButton Animations")
    {
        // base("OpenGL TouchButton Animations") is called from the constructor declaration
    }

    // throws Exception
    public override void init(int level)
    {
        base.initImageCache(OpenGLImageCacheFactory.getInstance(), level);
    }

    public override bool isFeature()
    {
        if (Features.getInstance().isDefault(OpenGLFeatureFactory.getInstance().OPENGL)) {
            return true;
        } else {
            return false;
        }
    }

}

