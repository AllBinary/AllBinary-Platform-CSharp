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
using NullUtil = org.allbinary.logic.NullUtil;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using CommonSeps = org.allbinary.@string.CommonSeps;

namespace org.allbinary.graphics.opengles.shader;

public class CompositeShaderUpdater : ShaderUpdater
{
    public readonly CommonSeps commonSeps = CommonSeps.getInstance();
    private static readonly CompositeShaderUpdater instanceC = new CompositeShaderUpdater(StringUtil.getInstance().getArrayInstance(), StringUtil.getInstance().getArrayInstance(), StringUtil.getInstance().getArrayInstance(), NullUtil.getInstance().NULL_INT_ARRAY);
    public static CompositeShaderUpdater getInstance()
    {
        return CompositeShaderUpdater.instanceC;
    }

    public CompositeShaderUpdater(string[] uniformBlockArray, string[] uniformArray, string[] attributeArray, int[] attributeHandleArray)
    {
    }

    public virtual void onSurfaceCreated(GL10 gl, EGLConfig eglConfig, int programHandle)
    {
    }

    public virtual void onSurfaceDestroyed(GL10 gl)
    {
    }

}

