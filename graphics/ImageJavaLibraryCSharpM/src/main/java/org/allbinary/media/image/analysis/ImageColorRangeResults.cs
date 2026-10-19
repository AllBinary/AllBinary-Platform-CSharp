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

public class ImageColorRangeResults
{
    private ColorRangeInterface colorRangeInterface = null;
    private long matchingPixelsChecked = 0L;
    private long totalPixelsChecked = 0L;
    public ImageColorRangeResults()
    {
        this.setColorRangeInterface(((ColorRangeInterface) new ColorRange()));
    }

    public virtual ColorRangeInterface getColorRangeInterface()
    {
        return this.colorRangeInterface;
    }

    public virtual void setColorRangeInterface(ColorRangeInterface colorRangeInterface)
    {
        this.colorRangeInterface = colorRangeInterface;
    }

    public virtual long getMatchingPixelsChecked()
    {
        return this.matchingPixelsChecked;
    }

    public virtual void setMatchingPixelsChecked(long matchingPixelsChecked)
    {
        this.matchingPixelsChecked = matchingPixelsChecked;
    }

    public virtual void addMatchingPixelsChecked()
    {
        this.matchingPixelsChecked++;
    }

    public virtual long getTotalPixelsChecked()
    {
        return this.totalPixelsChecked;
    }

    public virtual void addTotalPixelsChecked()
    {
        this.totalPixelsChecked++;
    }

    public virtual void setTotalPixelsChecked(long totalPixelsChecked)
    {
        this.totalPixelsChecked = totalPixelsChecked;
    }

    public virtual float getPercent()
    {
        return (((float) this.getMatchingPixelsChecked()) / ((float) this.getTotalPixelsChecked()));
    }

}

