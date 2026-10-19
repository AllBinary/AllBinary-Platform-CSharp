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
using InputAutomationModuleServiceFactory = org.allbinary.input.automation.module.osgi.InputAutomationModuleServiceFactory;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;

namespace org.allbinary.input.automation.module.generic;

public class InputAutomationGenericModuleServiceFactory : InputAutomationModuleServiceFactory
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static InputAutomationGenericModuleServiceFactory inputAutomationGenericModuleServiceFactory = new InputAutomationGenericModuleServiceFactory();
    public InputAutomationGenericModuleServiceFactory()
    {
        try {
            InputAutomationModuleFactoryInterface[] inputAutomationModuleInterfaceArray = new InputAutomationModuleFactoryInterface[1];
            inputAutomationModuleInterfaceArray[0] = new GenericModuleFactory();
            this.setInputAutomationModuleInterfaceArray(inputAutomationModuleInterfaceArray);
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.CONSTRUCTOR, e);
        }
    }

    public static InputAutomationGenericModuleServiceFactory getInstance()
    {
        return InputAutomationGenericModuleServiceFactory.inputAutomationGenericModuleServiceFactory;
    }

}

