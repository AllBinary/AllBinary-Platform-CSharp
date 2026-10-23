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

//None - Do not use
public class TsUtil
{
    private static readonly TsUtil instance = new TsUtil();
    public static TsUtil getInstance()
    {
        return TsUtil.instance;
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

    public virtual sbyte[] getRecord(object anyType, int recordId)
    {
        return new sbyte[0];
    }

    public virtual int compareTo(string a, string b)
    {
        return string.CompareOrdinal(a, b);
    }

    public virtual bool equalIgnoreCase(string a, string b)
    {
        return string.Equals(a, b, StringComparison.OrdinalIgnoreCase);
    }

    public virtual bool equalsNotstring(object anyType, object object2)
    {
        return anyType.Equals(object2);
    }

    public virtual int toNumberFromChar(char value)
    {
        return ((int) value);
    }

    public virtual int toNumber(int value)
    {
        return value;
    }

    public virtual sbyte[] getByteArray(string @string)
    {
        return System.Array.ConvertAll(System.Text.Encoding.UTF8.GetBytes(@string), value => unchecked((sbyte) value));
    }

    public virtual bool isItemListener(object owner)
    {
        return false;
    }

    public virtual void printAvailableMethods(object anyType)
    {
    }

    public virtual void gc()
    {
        GC.Collect();
    }

}

