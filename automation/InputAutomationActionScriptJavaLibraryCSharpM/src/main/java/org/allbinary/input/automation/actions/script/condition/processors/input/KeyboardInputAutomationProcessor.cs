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
using CommonLabels = org.allbinary.@string.CommonLabels;
using CommonStrings = org.allbinary.@string.CommonStrings;
using TimeDelayHelper = org.allbinary.time.TimeDelayHelper;

namespace org.allbinary.input.automation.actions.script.condition.processors.input;

public class KeyboardInputAutomationProcessor
{
    private KeyboardInputAutomationProcessor()
    {
    }

    // throws Exception
    public static void process(KeyboardActionScriptInputInterface keyActionScriptInputInterface)
    {
        LogUtil logUtil = LogUtil.getInstance();
        CommonStrings commonStrings = CommonStrings.getInstance();
        logUtil.putF(CommonLabels.getInstance().START + keyActionScriptInputInterface.ToString(), "KeyInputAutomationProcessor", commonStrings.PROCESS);
        InputRobotInterface inputRobotInterface = keyActionScriptInputInterface.getInputRobotInterface();
        int?[] integer = keyActionScriptInputInterface.getKeyArray();
        if (keyActionScriptInputInterface.getDelayBetweenKeys() == 0) {
            for (int index = 0; index < keyActionScriptInputInterface.getKeyArray().Length; index++) {
                if (keyActionScriptInputInterface.isPress()) {
                    inputRobotInterface.keyPress(integer[index]);
                }
            }
            System.Threading.Thread.Sleep((int) (keyActionScriptInputInterface.getTime()));
            for (int index = keyActionScriptInputInterface.getKeyArray().Length - 1; index >= 0; index--) {
                if (keyActionScriptInputInterface.isRelease()) {
                    inputRobotInterface.keyRelease(integer[index]);
                }
            }
        } else {
            for (int index = 0; index < keyActionScriptInputInterface.getKeyArray().Length; index++) {
                if (keyActionScriptInputInterface.isPress()) {
                    inputRobotInterface.keyPress(integer[index]);
                }
                System.Threading.Thread.Sleep((int) (keyActionScriptInputInterface.getTime()));
                if (keyActionScriptInputInterface.isRelease()) {
                    inputRobotInterface.keyRelease(integer[index]);
                }
                TimeDelayHelper timeHelper = new TimeDelayHelper(keyActionScriptInputInterface.getDelayBetweenKeys());
                int toLong = 0;
                while (!timeHelper.isTimeTNT() || toLong > 6000) {
                    toLong++;
                    System.Threading.Thread.Sleep((int) (50));
                }
            }
        }
    }

}

