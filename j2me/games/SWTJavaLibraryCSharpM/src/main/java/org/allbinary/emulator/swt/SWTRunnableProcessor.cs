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

namespace org.allbinary.emulator.swt;

public class SWTRunnableProcessor : SWTProcessor
{
    private static readonly SWTRunnableProcessor instanceR = new SWTRunnableProcessor();
    public static SWTRunnableProcessor getInstance()
    {
        return SWTRunnableProcessor.instanceR;
    }

    private SWTRunnableProcessor()
    {
    }

    public virtual void process(Display display)
    {
        this.runnable.run();
    }

}

