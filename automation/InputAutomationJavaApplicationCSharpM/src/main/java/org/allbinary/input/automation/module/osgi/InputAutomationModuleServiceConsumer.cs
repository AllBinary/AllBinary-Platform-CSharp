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
using BundleContext = org.osgi.framework.BundleContext;
using InputAutomationModuleServiceInterface = bundle.input.automation.module.InputAutomationModuleServiceInterface;
using InputAutomationServiceConsumer = org.allbinary.osgi.service.InputAutomationServiceConsumer;

namespace org.allbinary.input.automation.module.osgi;

public class InputAutomationModuleServiceConsumer : InputAutomationServiceConsumer
{
    public InputAutomationModuleServiceConsumer(BundleContext bundleContext) : base(typeof(InputAutomationModuleServiceInterface).getName(), bundleContext, new InputAutomationModuleOSGIServiceVisitor())
    {
        // base(typeof(InputAutomationModuleServiceInterface).getName(), bundleContext, new InputAutomationModuleOSGIServiceVisitor()) is called from the constructor declaration
    }

}

