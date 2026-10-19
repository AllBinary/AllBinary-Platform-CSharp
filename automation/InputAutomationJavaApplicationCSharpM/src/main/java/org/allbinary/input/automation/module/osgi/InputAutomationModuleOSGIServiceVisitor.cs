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
using InputAutomationModuleService = bundle.input.automation.module.InputAutomationModuleService;
using InputAutomationJFrame = org.allbinary.input.automation.InputAutomationJFrame;
using InputAutomationConfigurationUtil = org.allbinary.input.automation.configuration.InputAutomationConfigurationUtil;
using InputAutomationModuleFactoryInterface = org.allbinary.input.automation.module.InputAutomationModuleFactoryInterface;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using OSGIServiceInterface = org.allbinary.osgi.OSGIServiceInterface;
using OSGIServiceVisitorInterface = org.allbinary.osgi.OSGIServiceVisitorInterface;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.input.automation.module.osgi;

public class InputAutomationModuleOSGIServiceVisitor : OSGIServiceVisitorInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    public InputAutomationModuleOSGIServiceVisitor()
    {
    }

    public virtual object visit(object anyType)
    {
        return this.visit(((OSGIServiceInterface) anyType));
    }

    public virtual bool? visit(OSGIServiceInterface osgiServiceInterface)
    {
        try {
            InputAutomationModuleService inputAutomationModuleService = ((InputAutomationModuleService) osgiServiceInterface);
            InputAutomationModuleFactoryInterface[] inputAutomationModuleInterfaceArray = inputAutomationModuleService.getInputAutomationModuleInterfaceArray();
            for (int index = 0; index < inputAutomationModuleInterfaceArray.Length; index++) {
                InputAutomationJFrame.getInstance().onAdd(InputAutomationConfigurationUtil.getChangeEvent(inputAutomationModuleInterfaceArray[index]));
            }
            return true;
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "visit", e);
            return false;
        }
    }

}

