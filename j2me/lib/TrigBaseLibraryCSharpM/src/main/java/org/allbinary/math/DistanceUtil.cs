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
using MathUtil = org.allbinary.logic.math.MathUtil;

namespace org.allbinary.math;

public class DistanceUtil
{
    private static readonly DistanceUtil instance = new DistanceUtil();
    public static DistanceUtil getInstance()
    {
        return DistanceUtil.instance;
    }

    private readonly MathUtil mathUtil = MathUtil.getInstance();
    public virtual int getDistance(int x1, int y1, int x2, int y2)
    {
        int dx = x1 - x2;
        int dy = y1 - y2;
        return ((int) this.mathUtil.sqrt((dx * dx) + (dy * dy)));
    }

}

