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
using BasicColor = org.allbinary.graphics.color.BasicColor;
using ImageModifierUtil = org.allbinary.media.image.ImageModifierUtil;

namespace org.allbinary.animation.image;

public class ModifierBaseProcessor
{
    private static readonly ModifierBaseProcessor instance = new ModifierBaseProcessor();
    public static ModifierBaseProcessor getInstance()
    {
        return ModifierBaseProcessor.instance;
    }

    public virtual void updateColor(ImageModifierUtil imageModifierUtil, Image originalImage, Image imageToShow, int index, BasicColor basicColor)
    {
    }

    public virtual void updateAlpha(ImageModifierUtil imageModifierUtil, Image originalImage, Image imageToShow, int index, int alpha)
    {
    }

}

