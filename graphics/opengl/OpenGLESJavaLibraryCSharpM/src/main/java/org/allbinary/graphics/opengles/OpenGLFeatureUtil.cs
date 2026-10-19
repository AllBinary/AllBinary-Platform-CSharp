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

namespace org.allbinary.graphics.opengles;

public class OpenGLFeatureUtil
{
    private static readonly OpenGLFeatureUtil instance = new OpenGLFeatureUtil();
    public static OpenGLFeatureUtil getInstance()
    {
        return OpenGLFeatureUtil.instance;
    }

    private readonly bool anyThreed;
    public OpenGLFeatureUtil()
    {
        OpenGLConfiguration openGLConfiguration = OpenGLConfiguration.getInstance();
        Features features = Features.getInstance();
        OpenGLFeatureFactory openGLFeatureFactory = OpenGLFeatureFactory.getInstance();
        this.anyThreed = openGLConfiguration.isOpenGL() && (features.isFeature(openGLFeatureFactory.OPENGL_2D_AND_3D) || features.isFeature(openGLFeatureFactory.OPENGL_3D));
    }

    public virtual bool isAnyThreed()
    {
        return this.anyThreed;
    }

}

