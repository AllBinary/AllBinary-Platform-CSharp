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

namespace org.allbinary;

//TempBase
public class TsUtil
{
    private static readonly TsUtil instance = new TsUtil();
    public static TsUtil getInstance()
    {
        return TsUtil.instance;
    }

    public virtual double longBitsToDouble(long bits)
    {
        return BitConverter.Int64BitsToDouble(bits);
    }

    public virtual float intBitsToFloat(int bits)
    {
        return BitConverter.Int32BitsToSingle(bits);
    }

    public virtual int hashCode(object anyType)
    {
        return anyType.GetHashCode();
    }

    // throws InterruptedException
    public virtual void waitFor(object any, long timeoutMillis)
    {
        object anyType = ((object) any);
        System.Threading.Monitor.Wait(anyType, (int) (timeoutMillis));
    }

    public virtual int compareTo(string a, string b)
    {
        return string.CompareOrdinal(a, b);
    }

}

