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
using Display = org.eclipse.swt.widgets.Display;
using NullRunnable = org.allbinary.thread.NullRunnable;

namespace org.allbinary.emulator.swt;

public class SWTProcessor
{
    private static readonly SWTProcessor instance = new SWTProcessor();
    public static SWTProcessor getInstance()
    {
        return SWTProcessor.instance;
    }

    public Runnable runnable = NullRunnable.getInstance();
    public virtual void process(Display display)
    {
        display.sleep();
    }

}

