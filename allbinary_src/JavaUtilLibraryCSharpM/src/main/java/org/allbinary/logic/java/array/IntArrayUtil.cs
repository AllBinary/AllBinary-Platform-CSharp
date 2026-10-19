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

namespace org.allbinary.logic.java.array;

public class IntArrayUtil
{
    private IntArrayUtil()
    {
    }

    public static string toString(int[] array)
    {
        StringMaker stringBuffer = new StringMaker();
        for (int index = 0; index < array.Length; index++) {
            stringBuffer.appendint(array[index]);
            if (index < array.Length) {
                stringBuffer.append(", ");
            }
        }
        return stringBuffer.ToString();
    }

    public static string toString(int[][] array)
    {
        StringMaker stringBuffer = new StringMaker();
        for (int index = 0; index < array.Length; index++) {
            stringBuffer.append("{");
            for (int index2 = 0; index2 < array[index].Length; index2++) {
                stringBuffer.appendint(((int) array[index][index2]));
                if (index2 < array[index].Length - 1) {
                    stringBuffer.append(", ");
                }
            }
            stringBuffer.append("}");
            if (index < array.Length - 1) {
                stringBuffer.append(", \n");
            }
        }
        return stringBuffer.ToString();
    }

    public static string toString(int[][][] array)
    {
        StringMaker stringBuffer = new StringMaker();
        for (int index = 0; index < array.Length; index++) {
            stringBuffer.append("{");
            for (int index2 = 0; index2 < array[index].Length; index2++) {
                stringBuffer.append("{");
                for (int index3 = 0; index3 < array[index][index2].Length; index3++) {
                    stringBuffer.appendint(((int) array[index][index2][index3]));
                    if (index3 < array[index][index2].Length - 1) {
                        stringBuffer.append(", ");
                    }
                }
                stringBuffer.append("}");
                if (index2 < array[index].Length - 1) {
                    stringBuffer.append(", ");
                }
            }
            stringBuffer.append("}");
            if (index < array.Length - 1) {
                stringBuffer.append(", \n");
            }
        }
        return stringBuffer.ToString();
    }

}

