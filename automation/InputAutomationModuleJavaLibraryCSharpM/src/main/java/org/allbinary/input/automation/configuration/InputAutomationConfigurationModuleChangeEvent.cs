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
using InputAutomationModuleConfiguration = org.allbinary.input.automation.module.configuration.InputAutomationModuleConfiguration;

namespace org.allbinary.input.automation.configuration;

public class InputAutomationConfigurationModuleChangeEvent
{
    private InputAutomationModuleConfiguration inputAutomationModuleConfiguration = null;
    public InputAutomationConfigurationModuleChangeEvent(InputAutomationModuleConfiguration inputAutomationModuleConfiguration)
    {
        this.setInputAutomationModuleConfiguration(inputAutomationModuleConfiguration);
    }

    public virtual InputAutomationModuleConfiguration getInputAutomationModuleConfiguration()
    {
        return this.inputAutomationModuleConfiguration;
    }

    private void setInputAutomationModuleConfiguration(InputAutomationModuleConfiguration inputAutomationModuleConfiguration)
    {
        this.inputAutomationModuleConfiguration = inputAutomationModuleConfiguration;
    }

}

