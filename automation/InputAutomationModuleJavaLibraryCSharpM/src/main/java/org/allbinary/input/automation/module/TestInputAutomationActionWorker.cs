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
//using Set = java.util.Set;
using InputRobotFactory = org.allbinary.input.automation.robot.InputRobotFactory;
using InputRobotInterface = org.allbinary.input.automation.robot.InputRobotInterface;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using ImageComparatorConstraintsInterface = org.allbinary.media.image.comparison.ImageComparatorConstraintsInterface;
using MotionRectangleConstraintsInterface = org.allbinary.media.image.comparison.motion.MotionRectangleConstraintsInterface;
using org.allbinary.util;

namespace org.allbinary.input.automation.module;

public class TestInputAutomationActionWorker : AbstractInputAutomationWorker
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private int sleep;
    public TestInputAutomationActionWorker(int sleep, InputAutomationActionInterface inputAutomationActionInterface, ImageComparatorConstraintsInterface imageComparatorConstraintsInterface, MotionRectangleConstraintsInterface motionRectangleConstraintsInterface) : base(inputAutomationActionInterface)
    {
        // base(inputAutomationActionInterface) is called from the constructor declaration
        this.logUtil.putF("BasicTestAttackWorder", this, this.commonStrings.CONSTRUCTOR);
        this.sleep = sleep;
    }

    // throws Exception
    public virtual void processBetweenWorkers()
    {
        System.Threading.Thread.Sleep((int) (2000));
    }

    // throws Exception
    public virtual void process()
    {
        this.logUtil.putF(this.commonStrings.START, this, this.commonStrings.PROCESS);
        ABHashtable<object, object> hashtable = InputRobotFactory.getInstance().get();
        Set set = hashtable.keySet();
        object[] inputTypeNameArray = set.toArray();
        int size = inputTypeNameArray.Length;
        for (int index = 0; index < size; index++) {
            string inputTypeNameString = ((string) inputTypeNameArray[index]);
            InputRobotInterface robot = ((InputRobotInterface) hashtable.get(inputTypeNameString));
            if (this.sleep > 0) {
                System.Threading.Thread.Sleep((int) (this.sleep));
            }
        }
    }

}

