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
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using ImageComparisonResult = org.allbinary.media.image.comparison.ImageComparisonResult;

namespace org.allbinary.media.image.comparison.motion;

public class MotionRectangles
{
    private readonly string name;
    private BasicArrayList rectangleVector = null;
    private ImageComparisonResult imageComparisonResult = null;
    public readonly int MAX_PIXEL_DISTANCE_THRESHOLD = 2;
    public MotionRectangles(string name, ImageComparisonResult imageComparisonResult)
    {
        this.name = name;
        this.setImageComparisonResult(imageComparisonResult);
        this.setVector(new BasicArrayListD());
    }

    public virtual BasicArrayList getVector()
    {
        return this.rectangleVector;
    }

    public virtual void setVector(BasicArrayList rectangleVector)
    {
        this.rectangleVector = rectangleVector;
    }

    public virtual string getName()
    {
        return this.name;
    }

    public virtual ImageComparisonResult getImageComparisonResult()
    {
        return this.imageComparisonResult;
    }

    public virtual void setImageComparisonResult(ImageComparisonResult imageComparisonResult)
    {
        this.imageComparisonResult = imageComparisonResult;
    }

}

