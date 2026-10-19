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
using Animation = org.allbinary.animation.Animation;

namespace org.allbinary.image;

public class AnimationFrameToImageUtil
{
    private static readonly AnimationFrameToImageUtil instance = new AnimationFrameToImageUtil();
    public static AnimationFrameToImageUtil getInstance()
    {
        return AnimationFrameToImageUtil.instance;
    }

    // throws Exception
    public virtual Image getInstanceTranslate(int width, int height, Animation animationInterface)
    {
        Image image = GameFeatureImageCacheFactory.getInstance().get(AnimationFrameToImageUtil.instance.GetType().FullName, ((width * 3) >> 1), ((height * 3) >> 1));
        Graphics graphics = image.getGraphics();
        int tranlateX = (width >> 2);
        int tranlateY = (height >> 2);
        graphics.translate(tranlateX, tranlateY);
        animationInterface.paintXY(graphics, 0, 0);
        graphics.translate(-tranlateX, -tranlateY);
        return image;
    }

    // throws Exception
    public virtual Image getInstanceWH(int width, int height, Animation animationInterface)
    {
        Image image = GameFeatureImageCacheFactory.getInstance().get(AnimationFrameToImageUtil.instance.GetType().FullName, width, height);
        Graphics graphics = image.getGraphics();
        animationInterface.paintXY(graphics, 0, 0);
        return image;
    }

}

