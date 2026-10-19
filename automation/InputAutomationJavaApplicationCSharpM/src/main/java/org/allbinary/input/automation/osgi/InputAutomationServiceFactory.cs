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
using InputAutomationJFrame = org.allbinary.input.automation.InputAutomationJFrame;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.input.automation.osgi;

public class InputAutomationServiceFactory : ServiceFactory
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private static readonly InputAutomationServiceFactory inputAutomationServiceFactory = new InputAutomationServiceFactory();
    private InputAutomationServiceFactory()
    {
    }

    public static InputAutomationServiceFactory getInstance()
    {
        return InputAutomationServiceFactory.inputAutomationServiceFactory;
    }

    public virtual object getService(Bundle bundle, ServiceRegistration registration)
    {
        this.logUtil.putF(this.commonStrings.START, this, "getService");
        return InputAutomationJFrame.getInstance();
    }

    public virtual void ungetService(Bundle bundle, ServiceRegistration registration, object service)
    {
    }

}

