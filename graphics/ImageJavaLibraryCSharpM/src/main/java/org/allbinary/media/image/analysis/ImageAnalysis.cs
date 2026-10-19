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
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonLabels = org.allbinary.@string.CommonLabels;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.media.image.analysis;

public class ImageAnalysis
{
    private static readonly ImageAnalysis instance = new ImageAnalysis();
    public static ImageAnalysis getInstance()
    {
        return ImageAnalysis.instance;
    }

    public readonly LogUtil logUtil = LogUtil.getInstance();
    private ImageAnalysis()
    {
    }

    // throws Exception
    public virtual ImageAnalysisResults[] process(BufferedImage[] bufferedImageArray, ColorRangeInterface colorRangeInterface)
    {
        CommonStrings commonStrings = CommonStrings.getInstance();
        this.logUtil.putF(CommonLabels.getInstance().START + colorRangeInterface.ToString(), this, commonStrings.PROCESS);
        ImageAnalysisResults[] imageAnalysisResultsArray = new ImageAnalysisResults[bufferedImageArray.Length];
        for (int index = 0; index < bufferedImageArray.Length; index++) {
            imageAnalysisResultsArray[index] = ImageAnalysis.process(bufferedImageArray[index], colorRangeInterface);
        }
        return imageAnalysisResultsArray;
    }

    // throws Exception
    public static ImageAnalysisResults process(BufferedImage bufferedImage, ColorRangeInterface colorRangeInterface)
    {
        ImageAnalysisResults imageAnalysisResults = new ImageAnalysisResults();
        long redTotal = 0L;
        long greenTotal = 0L;
        long blueTotal = 0L;
        for (int indexY = 0; indexY < bufferedImage.getHeight(); indexY++) {
            for (int indexX = 0; indexX < bufferedImage.getWidth(); indexX++) {
                int? keyInteger = (bufferedImage.getRGB(indexX, indexY)).ToString();
                ColorCacheable colorCacheable = ((ColorCacheable) ColorCacheFactory.getInstance().get(keyInteger));
                Color color = colorCacheable.getColor();
                ImageAnalysis.processColorRangeResults(imageAnalysisResults, colorRangeInterface, color);
                ImageAnalysis.processImageColorResults(imageAnalysisResults.getImageColorResults(), colorRangeInterface, color);
                redTotal += color.getRed();
                greenTotal += color.getGreen();
                blueTotal += color.getBlue();
            }
        }
        long totalPixels = imageAnalysisResults.getImageColorRangeResults().getTotalPixelsChecked();
        ColorAverage colorAverage = imageAnalysisResults.getImageColorResults().getColorAverage();
        colorAverage.setAvgRed(((float) redTotal) / ((float) totalPixels));
        colorAverage.setAvgGreen(((float) greenTotal) / ((float) totalPixels));
        colorAverage.setAvgBlue(((float) blueTotal) / ((float) totalPixels));
        return imageAnalysisResults;
    }

    private static void processColorRangeResults(ImageAnalysisResults imageAnalysisResults, ColorRangeInterface colorRangeInterface, Color color)
    {
        if (colorRangeInterface.isInRange(color)) {
            imageAnalysisResults.getImageColorRangeResults().addMatchingPixelsChecked();
        } else {
        }
        imageAnalysisResults.getImageColorRangeResults().addTotalPixelsChecked();
    }

    private static void processImageColorResults(ImageColorResults imageColorResults, ColorRangeInterface colorRangeInterface, Color color)
    {
        if (color.getRed() < imageColorResults.getColorRange().getMinRed()) {
            imageColorResults.getColorRange().setMinRed(color.getRed());
        }
        if (color.getGreen() < imageColorResults.getColorRange().getMinGreen()) {
            imageColorResults.getColorRange().setMinGreen(color.getGreen());
        }
        if (color.getBlue() < imageColorResults.getColorRange().getMinBlue()) {
            imageColorResults.getColorRange().setMinBlue(color.getBlue());
        }
        if (color.getRed() > imageColorResults.getColorRange().getMaxRed()) {
            imageColorResults.getColorRange().setMaxRed(color.getRed());
        }
        if (color.getGreen() > imageColorResults.getColorRange().getMaxGreen()) {
            imageColorResults.getColorRange().setMaxGreen(color.getGreen());
        }
        if (color.getBlue() > imageColorResults.getColorRange().getMaxBlue()) {
            imageColorResults.getColorRange().setMaxBlue(color.getBlue());
        }
    }

}

