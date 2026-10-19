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
using NoDecimalTrigTable = org.allbinary.math.NoDecimalTrigTable;

namespace org.allbinary.logic.math.vector;

public class AxisMathVectorUtil
{
    private static readonly AxisMathVectorUtil instance = new AxisMathVectorUtil();
    public static AxisMathVectorUtil getInstance()
    {
        return AxisMathVectorUtil.instance;
    }

    private readonly NoDecimalTrigTable noDecimalTrigTable = NoDecimalTrigTable.getInstance();
    public virtual long calculateX(long magnitude, int angle)
    {
        return magnitude * this.noDecimalTrigTable.cos(angle) / 10;
    }

    public virtual long calculateY(long magnitude, int angle)
    {
        return magnitude * this.noDecimalTrigTable.sin(angle) / 10;
    }

    public virtual long calculateZ(long magnitude, int otherAngle)
    {
        return magnitude * this.noDecimalTrigTable.sin(otherAngle) / 10;
    }

}

