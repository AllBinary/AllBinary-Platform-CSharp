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
        stringBuffer.appendlong(((long) Math.Max(0L, GC.GetGCMemoryInfo().HeapSizeBytes - GC.GetTotalMemory(false))));
        stringBuffer.append(" Total: ");
        stringBuffer.appendlong(((long) GC.GetGCMemoryInfo().HeapSizeBytes));
        return stringBuffer.ToString();
    }

}

