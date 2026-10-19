/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2025 AllBinary 
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
//using EGLConfig = javax.microedition.khronos.egl.EGLConfig;
//using GL10 = javax.microedition.khronos.opengles.GL10;
using RendererStrings = org.allbinary.graphics.opengles.renderer.RendererStrings;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.graphics.opengles.shader;

public class ShaderUpdater
{
    private static readonly ShaderUpdater instance = new ShaderUpdater();
    public static ShaderUpdater getInstance()
    {
        return ShaderUpdater.instance;
    }

    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    public readonly RendererStrings rendererStrings = RendererStrings.getInstance();
    public virtual void onSurfaceCreated(GL10 gl, EGLConfig eglConfig)
    {
    }

}

