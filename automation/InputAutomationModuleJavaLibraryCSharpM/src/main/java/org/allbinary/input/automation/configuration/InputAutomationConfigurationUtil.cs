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
using InputAutomationModuleFactoryInterface = org.allbinary.input.automation.module.InputAutomationModuleFactoryInterface;
using InputAutomationModuleConfiguration = org.allbinary.input.automation.module.configuration.InputAutomationModuleConfiguration;

namespace org.allbinary.input.automation.configuration;

public class InputAutomationConfigurationUtil
{
    private InputAutomationConfigurationUtil()
    {
    }

    // throws Exception
    public static InputAutomationConfigurationModuleChangeEvent getChangeEvent(InputAutomationModuleFactoryInterface inputAutomationModuleInterface)
    {
        InputAutomationModuleConfiguration inputAutomationModuleConfiguration = new InputAutomationModuleConfiguration(inputAutomationModuleInterface);
        InputAutomationConfigurationModuleChangeEvent inputAutomationConfigurationModuleChangeEvent = new InputAutomationConfigurationModuleChangeEvent(inputAutomationModuleConfiguration);
        return inputAutomationConfigurationModuleChangeEvent;
    }

}

