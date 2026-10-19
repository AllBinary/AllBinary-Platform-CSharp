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
//using GL10 = javax.microedition.khronos.opengles.GL10;
using ObjectThreedOpenGLProcessor = org.allbinary.graphics.threed.min3d.renderer.processor.ObjectThreedOpenGLProcessor;

namespace org.allbinary.graphics.opengles.vbo;

public class ColorAttributePointerVBOOpenGLProcessor : ObjectThreedOpenGLProcessor
{
    private static readonly ColorAttributePointerVBOOpenGLProcessor instance = new ColorAttributePointerVBOOpenGLProcessor();
    public static ColorAttributePointerVBOOpenGLProcessor getInstance()
    {
        return ColorAttributePointerVBOOpenGLProcessor.instance;
    }

    public ColorAttributePointerVBOOpenGLProcessor()
    {
    }

    public override void process(GL10 gl, object anyType)
    {
        throw new SystemException();
    }

}

