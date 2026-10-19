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

public class OpenGLESDeviceImageTranslate : OpenGLESImageTranslate
{
    public float translateX = 0f;
    public float translateY = 0f;
    public float translateX2 = 0f;
    public float translateY2 = 0f;
    public override void translate(GL10 gl, OpenGLESImage openGLESImage, float x, float y)
    {
        openGLESImage.imageProcessor.translate(gl, this.translateX + (openGLESImage.openGLESImageProperties.scaleX * x), this.translateY + (openGLESImage.openGLESImageProperties.scaleY * y));
    }

    public override void translate2(GL10 gl, OpenGLESImage openGLESImage)
    {
        openGLESImage.imageProcessor.translate(gl, this.translateX2, this.translateY2);
    }

}

