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

public class ImageColorResults
{
    private ColorRange colorRange = null;
    private ColorAverage colorAverage = null;
    public ImageColorResults()
    {
        this.setColorRange(new ColorRange());
        this.getColorRange().setMaxRed(-1);
        this.getColorRange().setMaxGreen(-1);
        this.getColorRange().setMaxBlue(-1);
        this.getColorRange().setMinRed(256);
        this.getColorRange().setMinGreen(256);
        this.getColorRange().setMinBlue(256);
        this.setColorAverage(new ColorAverage());
    }

    public virtual ColorRange getColorRange()
    {
        return this.colorRange;
    }

    public virtual void setColorRange(ColorRange colorRange)
    {
        this.colorRange = colorRange;
    }

    public virtual ColorAverage getColorAverage()
    {
        return this.colorAverage;
    }

    public virtual void setColorAverage(ColorAverage colorAverage)
    {
        this.colorAverage = colorAverage;
    }

}

