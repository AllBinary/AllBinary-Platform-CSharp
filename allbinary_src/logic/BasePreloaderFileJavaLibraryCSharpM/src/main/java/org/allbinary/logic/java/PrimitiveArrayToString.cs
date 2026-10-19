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

namespace org.allbinary.logic.java;

public class PrimitiveArrayToString
{
    public static string toString(float[] floats)
    {
        StringMaker stringBuffer = new StringMaker();
        for (int index = 0; index < floats.Length; index++) {
            stringBuffer.appendfloat(floats[index]);
        }
        return stringBuffer.ToString();
    }

}

