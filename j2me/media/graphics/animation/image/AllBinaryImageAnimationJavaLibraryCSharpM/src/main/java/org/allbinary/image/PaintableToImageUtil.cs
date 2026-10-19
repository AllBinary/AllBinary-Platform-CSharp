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
//using Graphics = javax.microedition.lcdui.Graphics;
//using Image = javax.microedition.lcdui.Image;
using PaintableInterface = org.allbinary.graphics.paint.PaintableInterface;

namespace org.allbinary.image;

public class PaintableToImageUtil
{
    private static readonly PaintableToImageUtil instance = new PaintableToImageUtil();
    // throws Exception
    public static Image getImage(PaintableInterface paintableInterface, int width, int height)
    {
        Image image = GameFeatureImageCacheFactory.getInstance().get(PaintableToImageUtil.instance.GetType().FullName, width, height);
        Graphics graphics = image.getGraphics();
        paintableInterface.paint(graphics);
        return image;
    }

}

