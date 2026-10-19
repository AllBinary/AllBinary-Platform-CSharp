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
//using Displayable = javax.microedition.lcdui.Displayable;
using Processor = org.allbinary.canvas.Processor;

namespace org.allbinary.graphics.displayable.screen;

public class ScreenRepaintProcessor : Processor
{
    private readonly Displayable displayable;
    public ScreenRepaintProcessor(Displayable displayable)
    {
        this.displayable = displayable;
    }

    // throws Exception
    public override void process()
    {
        ScreenRepaintUtil.repaint(this.displayable);
    }

}

