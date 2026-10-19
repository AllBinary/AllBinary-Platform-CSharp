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
using AllBinaryEventObject = org.allbinary.logic.util.@event.AllBinaryEventObject;

namespace org.allbinary.media.image.comparison;

public class ImageComparisonResultsEvent : AllBinaryEventObject
{
    private ImageComparisonResult imageComparisonResult = null;
    public ImageComparisonResultsEvent(object anyType, ImageComparisonResult imageComparisonInfo) : base(anyType)
    {
        // base(anyType) is called from the constructor declaration
        this.setImageComparisonResult(imageComparisonInfo);
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

