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
using J2MEUtil = org.allbinary.J2MEUtil;
using Processor = org.allbinary.canvas.Processor;

namespace org.allbinary.graphics.displayable.screen;

public class ScreenRepaintProcessorFactory
{
    private static readonly ScreenRepaintProcessorFactory instance = new ScreenRepaintProcessorFactory();
    public static ScreenRepaintProcessorFactory getInstance()
    {
        return ScreenRepaintProcessorFactory.instance;
    }

    private ScreenRepaintProcessorFactory()
    {
    }

    public virtual Processor create(Displayable displayable)
    {
        if (!J2MEUtil.isJ2ME()) {
            return new ScreenRepaintProcessor(displayable);
        } else {
            return Processor.getInstance();
        }
    }

}

