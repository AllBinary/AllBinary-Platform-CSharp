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
        long maxUtilizedMemoryAvailable = Runtime.getRuntime().maxMemory();
        long memoryUsed = Runtime.getRuntime().totalMemory();
        stringBuffer.append("APK Memory: Available: ");
        stringBuffer.appendlong(maxUtilizedMemoryAvailable);
        stringBuffer.append("/");
        stringBuffer.appendlong(((long) Runtime.getRuntime().maxMemory()));
        stringBuffer.append(" Used: ");
        stringBuffer.appendlong(memoryUsed);
        stringBuffer.append(" Free: ");
        stringBuffer.appendlong(maxUtilizedMemoryAvailable - memoryUsed);
        stringBuffer.append("/");
        stringBuffer.appendlong(((long) (Runtime.getRuntime().maxMemory() - memoryUsed)));
        return stringBuffer.ToString();
    }

}

