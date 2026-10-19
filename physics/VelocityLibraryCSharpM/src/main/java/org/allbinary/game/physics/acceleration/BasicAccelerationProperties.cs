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

namespace org.allbinary.game.physics.acceleration;

public class BasicAccelerationProperties
{
    private int forward = 0;
    private int reverse = 0;
    public BasicAccelerationProperties(int forward, int reverse)
    {
        this.setForward(forward);
        this.setReverse(reverse);
    }

    public virtual void setReverse(int reverse)
    {
        this.reverse = reverse;
    }

    public virtual int getReverse()
    {
        return this.reverse;
    }

    public virtual void setForward(int forward)
    {
        this.forward = forward;
    }

    public virtual int getForward()
    {
        return this.forward;
    }

}

