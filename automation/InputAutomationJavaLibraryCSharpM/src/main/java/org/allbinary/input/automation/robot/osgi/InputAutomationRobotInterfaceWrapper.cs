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
using InputRobotInterface = org.allbinary.input.automation.robot.InputRobotInterface;

namespace org.allbinary.input.automation.robot.osgi;

public class InputAutomationRobotInterfaceWrapper
{
    private InputRobotInterface inputRobotInterface = null;
    public InputAutomationRobotInterfaceWrapper(InputRobotInterface inputRobotInterface)
    {
        this.setInputRobotInterface(inputRobotInterface);
    }

    public virtual InputRobotInterface getInputRobotInterface()
    {
        return this.inputRobotInterface;
    }

    public virtual void setInputRobotInterface(InputRobotInterface inputRobotInterface)
    {
        this.inputRobotInterface = inputRobotInterface;
    }

}

