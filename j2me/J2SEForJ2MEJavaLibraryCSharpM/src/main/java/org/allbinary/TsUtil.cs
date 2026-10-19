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
//using Displayable = javax.microedition.lcdui.Displayable;
//using Form = javax.microedition.lcdui.Form;
//using InvalidRecordIDException = javax.microedition.rms.InvalidRecordIDException;
//using RecordStore = javax.microedition.rms.RecordStore;
//using RecordStoreException = javax.microedition.rms.RecordStoreException;
//using RecordStoreNotOpenException = javax.microedition.rms.RecordStoreNotOpenException;
using NullUtil = org.allbinary.logic.NullUtil;

namespace org.allbinary;

//J2SE
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

    // throws RecordStoreNotOpenException, InvalidRecordIDException, RecordStoreException
    public virtual sbyte[] getRecord(object anyType, int recordId)
    {
        RecordStore recordStore = ((RecordStore) anyType);
        sbyte[] data = null;
        lock (this) {
            data = new sbyte[recordStore.getRecordSize(recordId)];
            recordStore.getRecord(recordId, data, 0);
        }
        return (data.Length < 1 ? NullUtil.getInstance().NULL_BYTE_ARRAY : data);
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

    public virtual ClassLoader getClassClassLoader(object anyType)
    {
        return anyType.GetType().getClassLoader();
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
        return System.Text.Encoding.UTF8.GetBytes(@string);
    }

    public virtual bool isItemListener(Displayable owner)
    {
        if (owner is Form) {
            return true;
        } else {
            return false;
        }
    }

    public virtual void gc()
    {
        GC.Collect();
    }

}

