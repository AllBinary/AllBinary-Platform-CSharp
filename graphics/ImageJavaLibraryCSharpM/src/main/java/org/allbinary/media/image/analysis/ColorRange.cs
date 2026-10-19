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
using StringMaker = org.allbinary.logic.@string.StringMaker;
using CommonSeps = org.allbinary.@string.CommonSeps;

namespace org.allbinary.media.image.analysis;

public class ColorRange : ColorRangeInterface
{
    private int minRed;
    private int maxRed;
    private int minGreen;
    private int maxGreen;
    private int minBlue;
    private int maxBlue;
    public ColorRange()
    {
        this.minRed = 0;
        this.maxRed = 0;
        this.minGreen = 0;
        this.maxGreen = 0;
        this.minBlue = 0;
        this.maxBlue = 0;
    }

    public virtual int getMinRed()
    {
        return this.minRed;
    }

    public virtual void setMinRed(int minRed)
    {
        this.minRed = minRed;
    }

    public virtual int getMaxRed()
    {
        return this.maxRed;
    }

    public virtual void setMaxRed(int maxRed)
    {
        this.maxRed = maxRed;
    }

    public virtual int getMinGreen()
    {
        return this.minGreen;
    }

    public virtual void setMinGreen(int minGreen)
    {
        this.minGreen = minGreen;
    }

    public virtual int getMaxGreen()
    {
        return this.maxGreen;
    }

    public virtual void setMaxGreen(int maxGreen)
    {
        this.maxGreen = maxGreen;
    }

    public virtual int getMinBlue()
    {
        return this.minBlue;
    }

    public virtual void setMinBlue(int minBlue)
    {
        this.minBlue = minBlue;
    }

    public virtual int getMaxBlue()
    {
        return this.maxBlue;
    }

    public virtual void setMaxBlue(int maxBlue)
    {
        this.maxBlue = maxBlue;
    }

    public virtual bool isInRange(Color color)
    {
        if (color.getRed() >= this.getMinRed() && color.getRed() <= this.getMaxRed() && color.getGreen() >= this.getMinGreen() && color.getGreen() <= this.getMaxGreen() && color.getBlue() >= this.getMinBlue() && color.getBlue() <= this.getMaxBlue()) {
            return true;
        } else {
            return false;
        }
    }

    public override string ToString()
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append("getMinRed(): ");
        stringBuffer.appendint(this.getMinRed());
        stringBuffer.append(CommonSeps.getInstance().NEW_LINE);
        stringBuffer.append("getMaxRed(): ");
        stringBuffer.appendint(this.getMaxRed());
        stringBuffer.append(CommonSeps.getInstance().NEW_LINE);
        stringBuffer.append("getMinGreen(): ");
        stringBuffer.appendint(this.getMinGreen());
        stringBuffer.append(CommonSeps.getInstance().NEW_LINE);
        stringBuffer.append("getMaxGreen(): ");
        stringBuffer.appendint(this.getMaxGreen());
        stringBuffer.append(CommonSeps.getInstance().NEW_LINE);
        stringBuffer.append("getMinBlue(): ");
        stringBuffer.appendint(this.getMinGreen());
        stringBuffer.append(CommonSeps.getInstance().NEW_LINE);
        stringBuffer.append("getMaxBlue(): ");
        stringBuffer.appendint(this.getMaxBlue());
        return stringBuffer.ToString();
    }

}

