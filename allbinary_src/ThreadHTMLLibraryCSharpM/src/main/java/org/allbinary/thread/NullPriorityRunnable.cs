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

namespace org.allbinary.thread;

public class NullPriorityRunnable : PriorityRunnable
{
    public virtual int getPriority()
    {
        return 0;
    }

    public virtual bool isDone()
    {
        return true;
    }

    public virtual void reset()
    {
    }

    public virtual void run()
    {
    }

}

