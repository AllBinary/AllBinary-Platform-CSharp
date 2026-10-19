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

namespace org.allbinary.media.image.search;

public class ImageComparisonSearchResultsEvent : AllBinaryEventObject
{
    private ImageComparisonSearch imageComparisonSearch = null;
    public ImageComparisonSearchResultsEvent(object anyType, ImageComparisonSearch imageComparisonSearch) : base(anyType)
    {
        // base(anyType) is called from the constructor declaration
        this.setImageComparisonSearch(imageComparisonSearch);
    }

    public virtual ImageComparisonSearch getImageComparisonSearch()
    {
        return this.imageComparisonSearch;
    }

    private void setImageComparisonSearch(ImageComparisonSearch imageComparisonSearch)
    {
        this.imageComparisonSearch = imageComparisonSearch;
    }

}

