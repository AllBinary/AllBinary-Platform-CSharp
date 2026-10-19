/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2022 AllBinary 
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

namespace org.allbinary.image.opengles;

public class ModifierOpenGLESImageProcessor : OpenGLESImageProcessor
{
    private static readonly ModifierOpenGLESImageProcessor instanceC = new ModifierOpenGLESImageProcessor();
    public static ModifierOpenGLESImageProcessor getInstance()
    {
        return ModifierOpenGLESImageProcessor.instanceC;
    }

    public override void colorMask(GL10 gl, float red, float green, float blue, float alpha)
    {
        gl.glColor4f(red, green, blue, alpha);
    }

}

