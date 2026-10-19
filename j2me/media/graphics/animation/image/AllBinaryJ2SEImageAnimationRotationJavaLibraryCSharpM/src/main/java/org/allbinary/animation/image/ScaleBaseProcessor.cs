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

namespace org.allbinary.animation.image;

public class ScaleBaseProcessor
{
    private static readonly ScaleBaseProcessor instance = new ScaleBaseProcessor();
    public static ScaleBaseProcessor getInstance()
    {
        return ScaleBaseProcessor.instance;
    }

    public virtual void update(Image originalImage, Image[] originalImageArray, Image[] imageToShowArray, int index, float scaleX, float scaleY, float maxScaleX, float maxScaleY)
    {
    }

}

