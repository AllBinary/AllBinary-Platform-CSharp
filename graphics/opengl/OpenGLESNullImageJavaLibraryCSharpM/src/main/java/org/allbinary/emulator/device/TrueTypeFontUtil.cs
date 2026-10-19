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
//using GL10 = javax.microedition.khronos.opengles.GL10;
//using Image = javax.microedition.lcdui.Image;
using BasicColor = org.allbinary.graphics.color.BasicColor;
using OpenGLESImage = org.allbinary.image.opengles.OpenGLESImage;

namespace org.allbinary.emulator.device;

public class TrueTypeFontUtil : TrueTypeFontUtilBase
{
    private static readonly TrueTypeFontUtil instance = new TrueTypeFontUtil();
    public static TrueTypeFontUtil getInstance()
    {
        return TrueTypeFontUtil.instance;
    }

    public OpenGLESImage fontImage = OpenGLESImage.NULL_OPENGL_IMAGE;
    private TrueTypeFontUtil() : base(1)
    {
        // base(1) is called from the constructor declaration
    }

    public override int getAsTextureSize(int textureSize)
    {
        throw new SystemException();
    }

    public override int getCellSize(int cellSize)
    {
        throw new SystemException();
    }

    public virtual Image getFontBitmap(string filename, int fontSize, int cellSize, BasicColor basicColor)
    {
        throw new SystemException();
    }

    public virtual void saveFontAtlasAsFile()
    {
    }

    public virtual Image getFontBitmapGL(GL10 gl, string filename, int cellSize, BasicColor basicColor)
    {
        throw new SystemException();
    }

    public virtual int[] getFontWidths(string filename, int fontSize)
    {
        throw new SystemException();
    }

}

