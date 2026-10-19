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

namespace org.allbinary.graphics.opengles;

public class WithNormalAttributePointerOpenGLProcessor : ObjectThreedOpenGLProcessor
{
    private static readonly WithNormalAttributePointerOpenGLProcessor instance = new WithNormalAttributePointerOpenGLProcessor();
    public static WithNormalAttributePointerOpenGLProcessor getInstance()
    {
        return WithNormalAttributePointerOpenGLProcessor.instance;
    }

    public WithNormalAttributePointerOpenGLProcessor()
    {
    }

    public override void process(GL10 gl, object aObject3d)
    {
        throw new SystemException();
    }

}

