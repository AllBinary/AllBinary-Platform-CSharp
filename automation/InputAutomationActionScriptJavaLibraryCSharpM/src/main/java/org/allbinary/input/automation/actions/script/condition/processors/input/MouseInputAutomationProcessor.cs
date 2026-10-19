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
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.input.automation.actions.script.condition.processors.input;

public class MouseInputAutomationProcessor
{
    private MouseInputAutomationProcessor()
    {
    }

    // throws Exception
    public static void process(MouseActionScriptInputInterface mouseActionScriptInputInterface)
    {
        LogUtil logUtil = LogUtil.getInstance();
        CommonStrings commonStrings = CommonStrings.getInstance();
        logUtil.putF(new StringMaker().append("Start - Processing Mouse Input at: ").append(mouseActionScriptInputInterface.getPoint().ToString()).append(" clicks: ").appendint(((int) mouseActionScriptInputInterface.getButtonClicks())).ToString(), "MouseInputAutomationProcessor", commonStrings.PROCESS);
        InputRobotInterface inputRobotInterface = mouseActionScriptInputInterface.getInputRobotInterface();
        if (mouseActionScriptInputInterface.getPoint().x != -1 && mouseActionScriptInputInterface.getPoint().y != -1) {
            inputRobotInterface.mouseMove(mouseActionScriptInputInterface.getPoint());
        }
        System.Threading.Thread.Sleep((int) (mouseActionScriptInputInterface.getTime()));
        if (mouseActionScriptInputInterface.getButtonClicks() != 0) {
            inputRobotInterface.mousePress(mouseActionScriptInputInterface.getButtonClicks());
            System.Threading.Thread.Sleep((int) (mouseActionScriptInputInterface.getTime()));
            inputRobotInterface.mouseRelease(mouseActionScriptInputInterface.getButtonClicks());
        }
        System.Threading.Thread.Sleep((int) (mouseActionScriptInputInterface.getTime()));
    }

}

