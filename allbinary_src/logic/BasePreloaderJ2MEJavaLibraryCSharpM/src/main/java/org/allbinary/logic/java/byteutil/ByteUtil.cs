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

namespace org.allbinary.logic.java.byteutil;

public class ByteUtil
{
    private static readonly ByteUtil instance = new ByteUtil();
    public static ByteUtil getInstance()
    {
        return ByteUtil.instance;
    }

    private ByteUtil()
    {
    }

    public virtual sbyte[] xor(sbyte[] array, sbyte mask)
    {
        sbyte[] bytes = new sbyte[array.Length];
        int size = array.Length;
        int index = 0;
        sbyte currentByte = 0;
        while (index < size) {
            currentByte = array[index];
            bytes[index] = ((sbyte) (currentByte ^ mask));
            index++;
        }
        return bytes;
    }

    public virtual sbyte[] not(sbyte[] array)
    {
        sbyte[] bytes = new sbyte[array.Length];
        int size = array.Length;
        int index = 0;
        while (index < size) {
            bytes[index] = ((sbyte) (~array[index]));
            index++;
        }
        return bytes;
    }

    public virtual sbyte[] xorByte(sbyte[] array, int index)
    {
        sbyte mask = 0;
        if (index == 0) {
            mask = 1;
        }
        if (index == 1) {
            mask = 2;
        }
        if (index == 2) {
            mask = 4;
        }
        if (index == 3) {
            mask = 8;
        }
        if (index == 4) {
            mask = 16;
        }
        if (index == 5) {
            mask = 32;
        }
        if (index == 6) {
            mask = 64;
        }
        if (index == 7) {
            mask = ((sbyte) (-127));
        }
        return this.xor(array, mask);
    }

    public virtual bool compare(sbyte[] newByteArray, sbyte[] oldByteArray)
    {
        if (newByteArray.Length != oldByteArray.Length) {
            return false;
        } else {
        }
        int size = newByteArray.Length;
        for (int index = 0; index < size; index++) {
            if (newByteArray[index] != oldByteArray[index]) {
                return false;
            }
        }
        return true;
    }

    public virtual bool compareWithStats(sbyte[] newByteArray, int newSize, sbyte[] oldByteArray, int[] stats)
    {
        if (newSize != oldByteArray.Length) {
            stats[0] = -1;
            stats[2] = newSize;
            stats[3] = oldByteArray.Length;
            return false;
        } else {
            stats[0] = newSize;
        }
        stats[1] = 0;
        int size = newSize;
        for (int index = 0; index < size; index++) {
            if (newByteArray[index] != oldByteArray[index]) {
                return false;
            }
            stats[1]++;
        }
        return true;
    }

}

