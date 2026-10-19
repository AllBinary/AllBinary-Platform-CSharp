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

namespace org.allbinary.media.image.analysis;

public class ImageAnalysisResults
{
    private ImageColorRangeResults imageColorRangeResults;
    private ImageColorResults imageColorResults;
    private float averageAmbientLevel = 0f;
    public ImageAnalysisResults()
    {
        this.imageColorRangeResults = new ImageColorRangeResults();
        this.imageColorResults = new ImageColorResults();
    }

    public virtual ImageColorRangeResults getImageColorRangeResults()
    {
        return this.imageColorRangeResults;
    }

    public virtual void setImageColorRangeResults(ImageColorRangeResults imageColorRangeResults)
    {
        this.imageColorRangeResults = imageColorRangeResults;
    }

    public virtual float getAverageAmbientLevel()
    {
        return this.averageAmbientLevel;
    }

    public virtual void setAverageAmbientLevel(float averageAmbientLevel)
    {
        this.averageAmbientLevel = averageAmbientLevel;
    }

    public virtual ImageColorResults getImageColorResults()
    {
        return this.imageColorResults;
    }

    public virtual void setImageColorResults(ImageColorResults imageColorResults)
    {
        this.imageColorResults = imageColorResults;
    }

}

