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
//using Graphics = javax.microedition.lcdui.Graphics;

namespace org.allbinary.game.input;

public class TestInputExample : TestInputInterface
{
    private int testValue = 0;
    public virtual void up()
    {
    }

    public virtual void down()
    {
    }

    public virtual void left()
    {
        this.testValue++;
    }

    public virtual void right()
    {
        this.testValue--;
    }

    public virtual void strafeLeft()
    {
    }

    public virtual void strafeRight()
    {
    }

    public virtual void paint(Graphics graphics)
    {
    }

    public virtual void paintThreed(Graphics graphics)
    {
    }

}

