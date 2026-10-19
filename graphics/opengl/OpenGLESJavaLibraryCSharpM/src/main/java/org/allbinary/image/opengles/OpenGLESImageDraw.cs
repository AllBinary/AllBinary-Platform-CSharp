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

public class OpenGLESImageDraw
{
    private static readonly OpenGLESImageDraw instance = new OpenGLESImageDraw();
    public static OpenGLESImageDraw getInstance()
    {
        return OpenGLESImageDraw.instance;
    }

    public virtual void drawRegion(GL10 gl, int viewHeight, float x_src, float y_src, float width, float height, int x, int y, int z)
    {
    }

    public virtual void draw(GL10 gl, int x, int y, int z)
    {
    }

}

