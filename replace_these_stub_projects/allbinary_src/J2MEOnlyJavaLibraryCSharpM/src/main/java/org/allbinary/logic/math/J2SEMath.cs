/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2025 AllBinary 
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

namespace org.allbinary.logic.math;

public class J2SEMath
{
    private static readonly J2SEMath instance = new J2SEMath();
    public static J2SEMath getInstance()
    {
        return J2SEMath.instance;
    }

    public virtual int round(float value)
    {
        return ((int) value);
    }

    public virtual float abs(float value)
    {
        return ((value < 0f) ? -value : value);
    }

    public virtual double absdouble(double value)
    {
        return ((value < 0.0) ? -value : value);
    }

}

