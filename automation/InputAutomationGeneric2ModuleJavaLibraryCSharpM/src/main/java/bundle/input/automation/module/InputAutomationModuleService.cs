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

namespace bundle.input.automation.module;

public class InputAutomationModuleService : InputAutomationModuleServiceInterface
{
    private InputAutomationModuleFactoryInterface[] inputAutomationModuleInterfaceArray = null;
    public InputAutomationModuleService(InputAutomationModuleFactoryInterface[] inputAutomationModuleInterfaceArray)
    {
        this.setInputAutomationModuleInterfaceArray(inputAutomationModuleInterfaceArray);
    }

    public virtual InputAutomationModuleFactoryInterface[] getInputAutomationModuleInterfaceArray()
    {
        return this.inputAutomationModuleInterfaceArray;
    }

    public virtual void setInputAutomationModuleInterfaceArray(InputAutomationModuleFactoryInterface[] inputAutomationModuleInterfaceArray)
    {
        this.inputAutomationModuleInterfaceArray = inputAutomationModuleInterfaceArray;
    }

}

