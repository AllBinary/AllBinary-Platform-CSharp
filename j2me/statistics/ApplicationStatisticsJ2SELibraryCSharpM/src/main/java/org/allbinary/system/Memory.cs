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

namespace org.allbinary.system;

//ActualPlatform
public class Memory
{
    public static string getInfo()
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append("Memory: Free: ");
        stringBuffer.appendlong(((long) Runtime.getRuntime().freeMemory()));
        stringBuffer.append(" Max: ");
        stringBuffer.appendlong(((long) Runtime.getRuntime().maxMemory()));
        stringBuffer.append(" Total: ");
        stringBuffer.appendlong(((long) Runtime.getRuntime().totalMemory()));
        return stringBuffer.ToString();
    }

}

