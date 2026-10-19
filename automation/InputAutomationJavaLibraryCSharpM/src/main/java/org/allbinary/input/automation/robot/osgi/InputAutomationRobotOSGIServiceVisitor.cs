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
using InputAutomationRobotServiceInterface = bundle.input.automation.robot.InputAutomationRobotServiceInterface;
using InputRobotFactory = org.allbinary.input.automation.robot.InputRobotFactory;
using InputRobotInterface = org.allbinary.input.automation.robot.InputRobotInterface;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using OSGIServiceInterface = org.allbinary.osgi.OSGIServiceInterface;
using OSGIServiceVisitorInterface = org.allbinary.osgi.OSGIServiceVisitorInterface;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.input.automation.robot.osgi;

public class InputAutomationRobotOSGIServiceVisitor : OSGIServiceVisitorInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    public InputAutomationRobotOSGIServiceVisitor()
    {
    }

    public virtual object visit(object anyType)
    {
        return this.visit(((OSGIServiceInterface) anyType));
    }

    public virtual bool? visit(OSGIServiceInterface osgiServiceInterface)
    {
        try {
            this.logUtil.putF(this.commonStrings.START, this, "visit");
            InputAutomationRobotServiceInterface inputAutomationRobotServiceInterface = ((InputAutomationRobotServiceInterface) osgiServiceInterface);
            InputRobotInterface[] inputRobotInterfaceArray = inputAutomationRobotServiceInterface.getInputRobotInterfaceArray();
            for (int index = 0; index < inputRobotInterfaceArray.Length; index++) {
                this.logUtil.putF("Adding: " + inputRobotInterfaceArray[index].getName(), this, "visit");
                InputRobotFactory.getInstance().add(inputRobotInterfaceArray[index]);
            }
            return true;
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "visit", e);
            return false;
        }
    }

}

