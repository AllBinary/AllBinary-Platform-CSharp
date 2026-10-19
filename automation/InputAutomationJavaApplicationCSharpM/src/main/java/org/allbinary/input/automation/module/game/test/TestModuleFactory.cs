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
using System.Runtime.CompilerServices;
//using javax.swing;
using AbstractInputAutomationFactory = org.allbinary.input.automation.module.AbstractInputAutomationFactory;
using InputAutomationModuleData = org.allbinary.input.automation.module.InputAutomationModuleData;
using BlankModuleConfigurationJPanel = org.allbinary.input.automation.module.configuration.BlankModuleConfigurationJPanel;
using RunnableInterface = org.allbinary.thread.RunnableInterface;

namespace org.allbinary.input.automation.module.game.test;

public class TestModuleFactory : AbstractInputAutomationFactory
{
    private static string NAME = "Test New Game" + InputAutomationModuleData.MODULE_NAME_END;
    private BlankModuleConfigurationJPanel blankModuleConfigurationJPanel = null;
    public TestModuleFactory() : base(NAME, new BlankModuleConfigurationJPanel())
    {
        // base(NAME, new BlankModuleConfigurationJPanel()) is called from the constructor declaration
    }

    public virtual string getName()
    {
        return TestModuleFactory.NAME;
    }

    public virtual JPanel getConfigurationJPanel()
    {
        return this.blankModuleConfigurationJPanel;
    }

    // throws Exception
    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual RunnableInterface getInstance()
    {
        return null;
    }

}

