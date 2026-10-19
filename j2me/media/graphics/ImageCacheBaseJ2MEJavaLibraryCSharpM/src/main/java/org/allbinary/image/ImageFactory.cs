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
//using InputStream = java.io.InputStream;
//using Image = javax.microedition.lcdui.Image;

namespace org.allbinary.image;

//ImageCacheBaseJavaLibrary - J2ME
public class ImageFactory
{
    private static readonly ImageFactory instance = new ImageFactory();
    public static ImageFactory getInstance()
    {
        return ImageFactory.instance;
    }

    // throws Exception
    public virtual Image createImageUrl(string url)
    {
        return Image.createImage(url);
    }

    // throws Exception
    public virtual Image createImage(string caller, int width, int height)
    {
        return Image.createImage(width, height);
    }

    // throws Exception
    public virtual Image createImageFromInputStream(object key, InputStream inputStream)
    {
        Image image = Image.createImage(inputStream);
        return image;
    }

    // throws Exception
    public virtual Image createImageFromInputStream(InputStream inputStream)
    {
        return Image.createImage(inputStream);
    }

}

