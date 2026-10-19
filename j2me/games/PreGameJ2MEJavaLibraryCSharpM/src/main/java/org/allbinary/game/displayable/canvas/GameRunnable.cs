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
using DisplayInfoSingleton = org.allbinary.graphics.displayable.DisplayInfoSingleton;

namespace org.allbinary.game.displayable.canvas;

public class GameRunnable : Runnable
{
    public readonly int WAIT = 240;
    public readonly int FAST = 60;
    public long waitInMillis;
    public GameRunnable()
    {
        this.waitInMillis = ((long) this.WAIT);
    }

    public virtual void run()
    {
        DisplayInfoSingleton.getInstance().process();
    }

    // throws Exception
    public virtual void processLoopSleep()
    {
        System.Threading.Thread.Sleep((int) (this.waitInMillis));
    }

}

