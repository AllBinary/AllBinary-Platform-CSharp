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
using System.Runtime.CompilerServices;

namespace org.allbinary.thread;

public class NullABRunnable : ABRunnable
{
    private static readonly NullABRunnable instance = new NullABRunnable();
    public static NullABRunnable getInstance()
    {
        return NullABRunnable.instance;
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public override bool isRunning()
    {
        return false;
    }

}

