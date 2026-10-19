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
//using HelpSet = javax.help.HelpSet;
//using javax.swing;
using RunnableInterface = org.allbinary.thread.RunnableInterface;

namespace org.allbinary.input.automation.module;

public class InputAutomationModuleFactoryInterface
{
    public virtual string getName()
    {
        return null;
    }

    public virtual JPanel getConfigurationJPanel()
    {
        return null;
    }

    public virtual HelpSet getHelpSet()
    {
        return null;
    }

    // throws Exception
    public virtual RunnableInterface getInstance()
    {
        return null;
    }

}

