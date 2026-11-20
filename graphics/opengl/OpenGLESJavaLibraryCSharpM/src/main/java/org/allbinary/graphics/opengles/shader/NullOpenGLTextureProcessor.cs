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

namespace org.allbinary.graphics.opengles.shader;

public class NullOpenGLTextureProcessor
{
    private static readonly OpenGLObject3dProcessor instance = new OpenGLObject3dProcessor();
    public static OpenGLObject3dProcessor getInstance()
    {
        return NullOpenGLTextureProcessor.instance;
    }

}

