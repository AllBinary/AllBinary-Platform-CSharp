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
using Bundle = org.osgi.framework.Bundle;
using ServiceFactory = org.osgi.framework.ServiceFactory;
using ServiceRegistration = org.osgi.framework.ServiceRegistration;
using InputAutomationModuleService = bundle.input.automation.module.InputAutomationModuleService;
using InputAutomationModuleFactoryInterface = org.allbinary.input.automation.module.InputAutomationModuleFactoryInterface;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.input.automation.module.osgi;

public class InputAutomationModuleServiceFactory : ServiceFactory
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private InputAutomationModuleFactoryInterface[] inputAutomationModuleInterfaceArray = null;
    public InputAutomationModuleServiceFactory()
    {
    }

    public virtual object getService(Bundle bundle, ServiceRegistration registration)
    {
        this.logUtil.putF(this.commonStrings.START, this, "getService");
        return new InputAutomationModuleService(this.getInputAutomationModuleInterfaceArray());
    }

    public virtual void ungetService(Bundle bundle, ServiceRegistration registration, object service)
    {
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

