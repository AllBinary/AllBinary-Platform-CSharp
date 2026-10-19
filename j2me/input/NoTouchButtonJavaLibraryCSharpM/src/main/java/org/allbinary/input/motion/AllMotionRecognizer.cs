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

namespace org.allbinary.input.motion;

public class AllMotionRecognizer
{
    private readonly int id;
    private static int index = 0;
    public AllMotionRecognizer()
    {
        this.id = AllMotionRecognizer.index++;
    }

    // throws Exception
    public virtual void processStartMotionEvent(int x, int y, int deviceId, int modifiers)
    {
    }

    // throws Exception
    public virtual void processEndMotionEvent(int x, int y, int deviceId, int modifiers)
    {
    }

    // throws Exception
    public virtual void processDraggedMotionEvent(int x, int y, int deviceId, int modifiers)
    {
    }

    // throws Exception
    public virtual void processMovedMotionEvent(int x, int y, int deviceId, int modifiers)
    {
    }

    // throws Exception
    public virtual void processScrolledMotionEvent(int x, int y, int deviceId, int modifiers)
    {
    }

    public virtual int getId()
    {
        return this.id;
    }

}

