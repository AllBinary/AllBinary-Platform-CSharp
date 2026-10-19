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
using StringMaker = org.allbinary.logic.@string.StringMaker;
using CommonSeps = org.allbinary.@string.CommonSeps;

namespace org.allbinary.media.image.analysis;

public class ColorAverage
{
    private float avgRed = 0f;
    private float avgGreen = 0f;
    private float avgBlue = 0f;
    public ColorAverage()
    {
        this.setAvgRed(0);
        this.setAvgGreen(0);
        this.setAvgBlue(0);
    }

    public override string ToString()
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append("getAvgRed(): ");
        stringBuffer.appendfloat(this.getAvgRed());
        stringBuffer.append(CommonSeps.getInstance().NEW_LINE);
        stringBuffer.append("getAvgRed(): ");
        stringBuffer.appendfloat(this.getAvgRed());
        stringBuffer.append(CommonSeps.getInstance().NEW_LINE);
        stringBuffer.append("getAvgGreen(): ");
        stringBuffer.appendfloat(this.getAvgGreen());
        stringBuffer.append(CommonSeps.getInstance().NEW_LINE);
        return stringBuffer.ToString();
    }

    public virtual float getAvgRed()
    {
        return this.avgRed;
    }

    public virtual void setAvgRed(float avgRed)
    {
        this.avgRed = avgRed;
    }

    public virtual float getAvgGreen()
    {
        return this.avgGreen;
    }

    public virtual void setAvgGreen(float avgGreen)
    {
        this.avgGreen = avgGreen;
    }

    public virtual float getAvgBlue()
    {
        return this.avgBlue;
    }

    public virtual void setAvgBlue(float avgBlue)
    {
        this.avgBlue = avgBlue;
    }

}

