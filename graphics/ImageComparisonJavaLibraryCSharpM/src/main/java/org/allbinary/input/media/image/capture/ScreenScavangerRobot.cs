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
//using Dimension = java.awt.Dimension;
//using Rectangle = java.awt.Rectangle;
//using Toolkit = java.awt.Toolkit;
//using BufferedImage = java.awt.image.BufferedImage;
using InputRobotFactory = org.allbinary.input.automation.robot.InputRobotFactory;
using InputRobotInterface = org.allbinary.input.automation.robot.InputRobotInterface;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;
using org.allbinary.util;

namespace org.allbinary.input.media.image.capture;

public class ScreenScavangerRobot
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    public ScreenScavangerRobot()
    {
    }

    // throws Exception
    public virtual BufferedImage[] getScreenAsBufferedImages()
    {
        this.logUtil.putF(this.commonStrings.START, this, "getScreenAsBufferedImages");
        Dimension dimScreenSize = Toolkit.getDefaultToolkit().getScreenSize();
        Rectangle rectScreenSize = new Rectangle(dimScreenSize);
        ABHashtable<object, object> robotHashtable = InputRobotFactory.getInstance().get();
        BufferedImage[] bufferedImageArray = new BufferedImage[1];
        int index = 0;
        InputRobotInterface inputRobotInterface = ((InputRobotInterface) robotHashtable.get("Java Robot"));
        bufferedImageArray[index] = inputRobotInterface.createScreenCapture(rectScreenSize);
        this.logUtil.putF("Finish", this, "getScreenAsBufferedImages");
        return bufferedImageArray;
    }

}

