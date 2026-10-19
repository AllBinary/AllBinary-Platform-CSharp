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
using AbstractInputAutomationFactory = org.allbinary.input.automation.module.AbstractInputAutomationFactory;
using InputAutomationActionInterface = org.allbinary.input.automation.module.InputAutomationActionInterface;
using InputAutomationModuleData = org.allbinary.input.automation.module.InputAutomationModuleData;
using GenericModuleConfigurationJPanel = org.allbinary.input.automation.module.generic.configuration.GenericModuleConfigurationJPanel;
using GenericProfile = org.allbinary.input.automation.module.generic.configuration.profile.GenericProfile;
using NoImageComparatorConstraints = org.allbinary.input.automation.module.generic.constraints.NoImageComparatorConstraints;
using NoMotionRectangleConstraints = org.allbinary.input.automation.module.generic.constraints.NoMotionRectangleConstraints;
using RunnableInterface = org.allbinary.thread.RunnableInterface;

namespace org.allbinary.input.automation.module.generic;

public class GenericModuleFactory : AbstractInputAutomationFactory
{
    private static string NAME = "Generic" + InputAutomationModuleData.MODULE_NAME_END;
    public GenericModuleFactory() : base(NAME, new GenericModuleConfigurationJPanel())
    {
        // base(NAME, new GenericModuleConfigurationJPanel()) is called from the constructor declaration
    }

    // throws Exception
    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual RunnableInterface getInstance()
    {
        GenericProfile genericProfile = (((GenericModuleConfigurationJPanel) this.getConfigurationJPanel())).getSelectedGenericProfile();
        InputAutomationActionInterface inputAutomationActionInterface = ((InputAutomationActionInterface) new GenericInputAutomationAction());
        return ((RunnableInterface) new GenericInputAutomationWorker(inputAutomationActionInterface, genericProfile, new NoMotionRectangleConstraints(), new NoImageComparatorConstraints()));
    }

}

