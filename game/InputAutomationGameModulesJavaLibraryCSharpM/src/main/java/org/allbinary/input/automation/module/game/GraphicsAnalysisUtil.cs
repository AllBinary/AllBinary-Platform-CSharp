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
//using java.awt;
//using BufferedImage = java.awt.image.BufferedImage;
using ColorCacheFactory = org.allbinary.graphics.color.ColorCacheFactory;
using ColorCacheable = org.allbinary.graphics.color.ColorCacheable;
using AutomaticCacheInterface = org.allbinary.logic.util.cache.AutomaticCacheInterface;

namespace org.allbinary.input.automation.module.game;

public class GraphicsAnalysisUtil
{
    private static readonly int MAX = 122;
    private GraphicsAnalysisUtil()
    {
    }

    // throws Exception
    public static double getNominator(BufferedImage bufferedImage, int? min_x, int? max_x, int? y)
    {
        for (int index = ((int) max_x); index > ((int) min_x); index -= 1) {
            int? colorInteger = (bufferedImage.getRGB(index, ((int) y))).ToString();
            AutomaticCacheInterface automaticCacheInterface = ColorCacheFactory.getInstance();
            ColorCacheable colorCacheable = ((ColorCacheable) automaticCacheInterface.get(colorInteger));
            Color color = colorCacheable.getColor();
            if (color.getRed() < GraphicsAnalysisUtil.MAX && color.getGreen() < GraphicsAnalysisUtil.MAX && color.getBlue() < GraphicsAnalysisUtil.MAX) {
            } else {
                return index - ((int) min_x);
            }
        }
        return 0.0;
    }

}

