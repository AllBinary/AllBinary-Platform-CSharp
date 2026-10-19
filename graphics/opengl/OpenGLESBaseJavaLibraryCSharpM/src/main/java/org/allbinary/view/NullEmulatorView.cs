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
//using Displayable = javax.microedition.lcdui.Displayable;
//using MIDlet = javax.microedition.midlet.MIDlet;

namespace org.allbinary.view;

public class NullEmulatorView : EmulatorViewInterface
{
    public static readonly NullEmulatorView NULL_EMULATOR_VIEW = new NullEmulatorView();
    public virtual void setMidlet(MIDlet midlet)
    {
    }

    public virtual void onEmulatorInitComplete(object midletActivity)
    {
    }

    public virtual void onSetDisplayable(Displayable displayable)
    {
    }

}

