/*
 *
 * AllBinary Open License Version 1
 * Copyright (c) 2011 AllBinary
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
//using GL = javax.microedition.khronos.opengles.GL;
//using Graphics = javax.microedition.lcdui.Graphics;
//using Image = javax.microedition.lcdui.Image;

namespace org.allbinary.image;

public class PreResourceImageUtil
{
    private static readonly PreResourceImageUtil instance = new PreResourceImageUtil();
    public static PreResourceImageUtil getInstance()
    {
        return PreResourceImageUtil.instance;
    }

    public virtual Image encapsulate(Image image)
    {
        return image;
    }

    public virtual void updateGL(GL gl, Image image)
    {
    }

    public virtual void update(Graphics graphics, Image image)
    {
    }

}

