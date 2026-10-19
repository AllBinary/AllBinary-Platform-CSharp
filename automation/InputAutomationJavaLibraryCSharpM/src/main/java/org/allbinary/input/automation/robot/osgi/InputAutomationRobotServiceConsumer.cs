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
using InputAutomationRobotServiceInterface = bundle.input.automation.robot.InputAutomationRobotServiceInterface;
using InputAutomationServiceConsumer = org.allbinary.osgi.service.InputAutomationServiceConsumer;

namespace org.allbinary.input.automation.robot.osgi;

public class InputAutomationRobotServiceConsumer : InputAutomationServiceConsumer
{
    public InputAutomationRobotServiceConsumer(BundleContext bundleContext) : base(typeof(InputAutomationRobotServiceInterface).getName(), bundleContext, new InputAutomationRobotOSGIServiceVisitor())
    {
        // base(typeof(InputAutomationRobotServiceInterface).getName(), bundleContext, new InputAutomationRobotOSGIServiceVisitor()) is called from the constructor declaration
    }

}

