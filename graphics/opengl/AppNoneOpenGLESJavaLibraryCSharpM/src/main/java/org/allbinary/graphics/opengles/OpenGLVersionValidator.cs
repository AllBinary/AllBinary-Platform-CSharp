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
using ShaderComposite = org.allbinary.graphics.opengles.shader.ShaderComposite;

namespace org.allbinary.graphics.opengles;

public class OpenGLVersionValidator
{
    private static readonly OpenGLVersionValidator instance = new OpenGLVersionValidator();
    public static OpenGLVersionValidator getInstance()
    {
        return OpenGLVersionValidator.instance;
    }

    public virtual bool isGL31OrHigher()
    {
        return false;
    }

    public virtual bool isAvailable(string glVersionRequired)
    {
        return false;
    }

    public virtual void setShaderComposite(ShaderComposite shaderComposite, object anyType)
    {
    }

    public int EGL_CONTEXT_CLIENT_VERSION_VALUE = -1;
}

