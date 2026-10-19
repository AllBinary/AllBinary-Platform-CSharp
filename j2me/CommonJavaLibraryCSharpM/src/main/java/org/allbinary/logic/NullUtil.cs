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
//using JsType = jsinterop.annotations.JsType;

namespace org.allbinary.logic;

//ActualPlatform
public class NullUtil
{
    private static readonly NullUtil instance = new NullUtil();
    public static NullUtil getInstance()
    {
        return NullUtil.instance;
    }

    public readonly object NULL_OBJECT = new object();
    public readonly Type NULL_CLASS;
    public readonly object[] NULL_OBJECT_ARRAY = new object[0];
    public readonly char[] NULL_CHAR_ARRAY = new char[0];
    public readonly sbyte[] NULL_BYTE_ARRAY = new sbyte[0];
    public readonly short[][] NULL_SHORT_ARRAY_ARRAY = System.Linq.Enumerable.Range(0, 0).Select(_ => new short[0]).ToArray();
    public readonly int[] NULL_INT_ARRAY = new int[0];
    public readonly int[][] NULL_INT_ARRAY_ARRAY = System.Linq.Enumerable.Range(0, 0).Select(_ => new int[0]).ToArray();
    public readonly int[][][] NULL_INT_ARRAY_ARRAY_ARRAY = System.Linq.Enumerable.Range(0, 0).Select(_ => System.Linq.Enumerable.Range(0, 0).Select(_ => new int[0]).ToArray()).ToArray();
    public readonly float[] NULL_FLOAT_ARRAY = new float[0];
    public NullUtil()
    {
        this.NULL_CLASS = this.NULL_OBJECT.GetType();
    }

}

