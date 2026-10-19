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
//using MIDlet = javax.microedition.midlet.MIDlet;
using AppletUtil = org.allbinary.AppletUtil;
using J2MEUtil = org.allbinary.J2MEUtil;
using Processor = org.allbinary.canvas.Processor;

namespace org.allbinary.midlet;

public class MidletExitProcessorFactory
{
    private static readonly MidletExitProcessorFactory instance = new MidletExitProcessorFactory();
    public static MidletExitProcessorFactory getInstance()
    {
        return MidletExitProcessorFactory.instance;
    }

    public virtual Processor getExitInstance(MIDlet midlet)
    {
        if (AppletUtil.isAppletLoader(midlet) || J2MEUtil.isJ2ME()) {
            return Processor.getInstance();
        } else {
            return new MidletExitProcessor(midlet);
        }
    }

}

