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

public class OpenGLESImageProcessor
{
    private static readonly OpenGLESImageProcessor instance = new OpenGLESImageProcessor();
    public static OpenGLESImageProcessor getInstance()
    {
        return OpenGLESImageProcessor.instance;
    }

    public virtual void translate(GL10 gl, float translateX, float translateY)
    {
    }

    public virtual void rotate(GL10 gl, float angle)
    {
    }

    public virtual void scale(GL10 gl, float scaleX, float scaleY)
    {
    }

    public virtual void colorMask(GL10 gl, float red, float green, float blue, float alpha)
    {
    }

}

