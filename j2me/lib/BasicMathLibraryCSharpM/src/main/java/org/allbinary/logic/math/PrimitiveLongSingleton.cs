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

namespace org.allbinary.logic.math;

public class PrimitiveLongSingleton
{
    private static readonly PrimitiveLongSingleton instance = new PrimitiveLongSingleton();
    public static PrimitiveLongSingleton getInstance()
    {
        return PrimitiveLongSingleton.instance;
    }

    public readonly char[] UNK = new char[] { 'U', 'n', 'k' };
    public readonly sbyte[] NUMBER_ARRAY = new sbyte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    public readonly char[] NUMBER_CHAR_ARRAY = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
    public readonly char[][] NUMBER_CHAR_ARRAYS = new char[][] { new char[] { '0' }, new char[] { '1' }, new char[] { '2' }, new char[] { '3' }, new char[] { '4' }, new char[] { '5' }, new char[] { '6' }, new char[] { '7' }, new char[] { '8' }, new char[] { '9' } };
    public readonly char[] ZERO;
    // throws Exception
    public virtual sbyte getNumberFromChar(char numberAsChar)
    {
        int size = this.NUMBER_CHAR_ARRAY.Length;
        for (int index = 0; index < size; index++) {
            if (this.NUMBER_CHAR_ARRAY[index] == numberAsChar) {
                return this.NUMBER_ARRAY[index];
            }
        }
        throw new Exception(new StringMaker().append("numberAsChar was not in array: ").appendchar(numberAsChar).ToString());
    }

    public PrimitiveLongSingleton()
    {
        this.ZERO = new char[] { this.NUMBER_CHAR_ARRAY[0] };
    }

}

