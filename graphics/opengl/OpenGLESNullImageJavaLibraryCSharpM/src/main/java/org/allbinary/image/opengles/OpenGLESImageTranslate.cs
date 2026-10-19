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

namespace org.allbinary.image.opengles;

public class OpenGLESImageTranslate
{
    private static readonly OpenGLESImageTranslate instance = new OpenGLESImageTranslate();
    public static OpenGLESImageTranslate getInstance()
    {
        return OpenGLESImageTranslate.instance;
    }

    public virtual void translate(GL10 gl, OpenGLESImage openGLESImage, float x, float y)
    {
        openGLESImage.imageProcessor.translate(gl, x, y);
    }

    public virtual void translate2(GL10 gl, OpenGLESImage openGLESImage)
    {
    }

}

