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
//using Image = javax.microedition.lcdui.Image;
using ImageModifierUtil = org.allbinary.media.image.ImageModifierUtil;

namespace org.allbinary.animation.image;

public class AlphaProcessor : AlphaBaseProcessor
{
    private static readonly AlphaProcessor instanceC = new AlphaProcessor();
    public static AlphaProcessor getInstance()
    {
        return AlphaProcessor.instanceC;
    }

    public override void setAlpha(ImageModifierUtil imageModifierUtil, Image originalImage, Image imageToShow, int alpha)
    {
        imageModifierUtil.setAlpha3(imageToShow, alpha);
    }

}

