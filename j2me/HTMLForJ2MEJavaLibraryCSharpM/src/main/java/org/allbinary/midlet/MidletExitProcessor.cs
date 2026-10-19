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
using Processor = org.allbinary.canvas.Processor;

namespace org.allbinary.midlet;

public class MidletExitProcessor : Processor
{
    private readonly MIDlet midlet;
    public MidletExitProcessor(MIDlet midlet)
    {
        this.midlet = midlet;
    }

    // throws Exception
    public virtual void process()
    {
    }

}

