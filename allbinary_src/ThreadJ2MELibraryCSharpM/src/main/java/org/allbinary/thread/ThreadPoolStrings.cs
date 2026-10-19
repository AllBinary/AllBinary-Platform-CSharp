/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2022 AllBinary 
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

namespace org.allbinary.thread;

public class ThreadPoolStrings
{
    private static readonly ThreadPoolStrings instance = new ThreadPoolStrings();
    public static ThreadPoolStrings getInstance()
    {
        return ThreadPoolStrings.instance;
    }

    public readonly string ADD_TASK = "addTask";
    public readonly string START_TASK = "Started Task: ";
    public readonly string COMPLETE_TASK = "Completed Task: ";
}

