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
//using Image = javax.microedition.lcdui.Image;
using OpenGLESImage = org.allbinary.image.opengles.OpenGLESImage;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.graphics.opengles.renderer;

public class AllBinaryRendererBase3
{
    public readonly BasicArrayList list = new BasicArrayListD();
    // throws Exception
    protected virtual void update(GL10 gl)
    {
        while (this.list.size() > 0) {
            OpenGLESImage openGLESImage = ((OpenGLESImage) this.list.removeAt(0));
            if (openGLESImage != null) {
                openGLESImage.set(gl);
            }
        }
    }

    public virtual void add(Image image)
    {
        this.list.add(image);
    }

}

