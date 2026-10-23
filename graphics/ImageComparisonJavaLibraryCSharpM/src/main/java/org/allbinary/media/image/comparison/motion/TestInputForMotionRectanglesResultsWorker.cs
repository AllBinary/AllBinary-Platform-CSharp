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
using System.Runtime.CompilerServices;
//using Rectangle = java.awt.Rectangle;
//using InputEvent = java.awt.@event.InputEvent;
//using KeyEvent = java.awt.@event.KeyEvent;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using InputRobotFactory = org.allbinary.input.automation.robot.InputRobotFactory;
using InputRobotInterface = org.allbinary.input.automation.robot.InputRobotInterface;
using TempInputRobotNames = org.allbinary.input.automation.robot.TempInputRobotNames;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using AllBinaryEventObject = org.allbinary.logic.util.@event.AllBinaryEventObject;
using CommonLabels = org.allbinary.@string.CommonLabels;
using CommonStrings = org.allbinary.@string.CommonStrings;
using TimeDelayHelper = org.allbinary.time.TimeDelayHelper;
using org.allbinary.util;

namespace org.allbinary.media.image.comparison.motion;

public class TestInputForMotionRectanglesResultsWorker : MotionRectanglesResultsListener
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private long index = 0L;
    private bool running = false;
    private BasicArrayList motionRectanglesVector;
    public TestInputForMotionRectanglesResultsWorker()
    {
        this.motionRectanglesVector = new BasicArrayListD();
    }

    public virtual BasicArrayList getMotionRectanglesVector()
    {
        return this.motionRectanglesVector;
    }

    public virtual void onMotionRectanglesImageComparisonResultsEvent(MotionRectanglesResultsEvent motionRectanglesImageComparisonResultsEvent)
    {
        this.getMotionRectanglesVector().add(motionRectanglesImageComparisonResultsEvent.getMotionRectangles());
        this.run();
    }

    public virtual void onEvent(AllBinaryEventObject allBinaryEventObject)
    {
        this.onMotionRectanglesImageComparisonResultsEvent(((MotionRectanglesResultsEvent) allBinaryEventObject));
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual bool isRunning()
    {
        return this.running;
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual void setRunning(bool running)
    {
        this.running = running;
    }

    public virtual void run()
    {
        try {
            this.logUtil.putF(this.commonStrings.START, this, this.commonStrings.RUN);
            this.setRunning(true);
            TimeDelayHelper timeHelper = new TimeDelayHelper(1000);
            timeHelper.setStartTimeTNT();
            MotionRectangles motionRectangles = ((MotionRectangles) this.getMotionRectanglesVector().get(0));
            BasicArrayList motionRectangleVector = motionRectangles.getVector();
            if (motionRectangleVector.size() > 0) {
                Rectangle rectangle = ((Rectangle) motionRectangleVector.get(0));
                ABHashtable<object, object> robotHashtable = InputRobotFactory.getInstance().get();
                object[] inputTypeNameArray = robotHashtable.keySet().toArray();
                int size = inputTypeNameArray.Length;
                for (int index = 0; index < size; index++) {
                    string inputTypeNameString = ((string) inputTypeNameArray[index]);
                    InputRobotInterface inputRobotInterface = ((InputRobotInterface) robotHashtable.get(inputTypeNameString));
                    inputRobotInterface.mouseMoveToTarget(rectangle);
                    if (string.CompareOrdinal(inputRobotInterface.getName(), TempInputRobotNames.DX_NAME) == 0) {
                        inputRobotInterface.mousePress(InputEvent.BUTTON1_MASK);
                        System.Threading.Thread.Sleep((int) (300));
                        inputRobotInterface.mouseRelease(InputEvent.BUTTON1_MASK);
                        inputRobotInterface.mousePress(InputEvent.BUTTON2_MASK);
                        System.Threading.Thread.Sleep((int) (300));
                        inputRobotInterface.mouseRelease(InputEvent.BUTTON2_MASK);
                        inputRobotInterface.mousePress(InputEvent.BUTTON3_MASK);
                        System.Threading.Thread.Sleep((int) (300));
                        inputRobotInterface.mouseRelease(InputEvent.BUTTON3_MASK);
                        inputRobotInterface.keyPress(KeyEvent.VK_1);
                        System.Threading.Thread.Sleep((int) (300));
                        inputRobotInterface.keyRelease(KeyEvent.VK_1);
                        inputRobotInterface.keyPress(KeyEvent.VK_2);
                        System.Threading.Thread.Sleep((int) (300));
                        inputRobotInterface.keyRelease(KeyEvent.VK_2);
                        inputRobotInterface.keyPress(KeyEvent.VK_3);
                        System.Threading.Thread.Sleep((int) (300));
                        inputRobotInterface.keyRelease(KeyEvent.VK_3);
                        inputRobotInterface.keyPress(KeyEvent.VK_4);
                        System.Threading.Thread.Sleep((int) (300));
                        inputRobotInterface.keyRelease(KeyEvent.VK_4);
                        inputRobotInterface.keyPress(KeyEvent.VK_F1);
                        System.Threading.Thread.Sleep((int) (300));
                        inputRobotInterface.keyRelease(KeyEvent.VK_F1);
                    }
                }
            }
            this.index++;
            this.getMotionRectanglesVector().remove(motionRectangles);
            this.logUtil.putF(CommonLabels.getInstance().ELAPSED + timeHelper.getElapsedTNT(), this, this.commonStrings.RUN);
            this.logUtil.putF(this.commonStrings.END, this, this.commonStrings.RUN);
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.RUN, e);
        }
    }

}

