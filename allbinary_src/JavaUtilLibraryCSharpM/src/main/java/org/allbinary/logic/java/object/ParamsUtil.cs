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

namespace org.allbinary.logic.java.anyType;

public class ParamsUtil
{
    private ParamsUtil()
    {
    }

    public static string viewParams(Type[] @params)
    {
        if (@params != null) {
            StringMaker stringBuffer = new StringMaker();
            for (int index = 0; index < @params.Length; index++) {
                stringBuffer.append(" ");
                stringBuffer.append(@params[index].getName());
            }
            return stringBuffer.ToString();
        } else {
            return "Params Null";
        }
    }

}

