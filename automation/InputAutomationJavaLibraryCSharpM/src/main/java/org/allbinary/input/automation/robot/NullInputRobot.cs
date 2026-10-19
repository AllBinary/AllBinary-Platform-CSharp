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
//using java.awt;
//using BufferedImage = java.awt.image.BufferedImage;
//using HelpSet = javax.help.HelpSet;
using AbstractInputRobot = org.allbinary.input.automation.AbstractInputRobot;
using PointFactory = org.allbinary.input.automation.PointFactory;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;

namespace org.allbinary.input.automation.robot;

public class NullInputRobot : AbstractInputRobot, InputRobotInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public static readonly string LIBRARY_NAME = "null";
    public static readonly string NAME = "NULL";
    public NullInputRobot() : base(null)
    {
        // base(null) is called from the constructor declaration
    }

    public virtual string getName()
    {
        return NullInputRobot.NAME;
    }

    public virtual HelpSet getHelpSet()
    {
        return null;
    }

    public virtual Point getMousePoint()
    {
        return PointFactory.getInstance(0, 0);
    }

    public virtual void keyPress(int? keycode)
    {
        this.logUtil.putF("KeyCode: " + keycode, this, "keyPress");
    }

    public virtual void keyRelease(int? keycode)
    {
        this.logUtil.putF("KeyCode: " + keycode, this, "keyRelease");
    }

    public virtual void mouseMove(int? x, int? y)
    {
        this.logUtil.putF("X: " + x + " Y: " + y, this, "mouseMove");
    }

    public virtual void mousePress(int? buttons)
    {
        this.logUtil.putF("Buttons: " + buttons, this, "mousePress");
    }

    public virtual void mouseRelease(int? buttons)
    {
        this.logUtil.putF("Buttons: " + buttons, this, "mouseRelease");
    }

    public virtual BufferedImage createScreenCapture(Rectangle screenRect)
    {
        return null;
    }

    public virtual void delay(int? ms)
    {
    }

    public virtual int? getAutoDelay()
    {
        return -1;
    }

    public virtual Color getPixelColor(int? x, int? y)
    {
        return null;
    }

    public virtual bool isAutoWaitForIdle()
    {
        return false;
    }

    public virtual void mouseWheel(int? wheelAmt)
    {
    }

    public virtual void setAutoDelay(int? ms)
    {
    }

    public virtual void setAutoWaitForIdle(bool isOn)
    {
    }

    public override string ToString()
    {
        return "DirectXWindowsInputRobot";
    }

    public virtual void waitForIdle()
    {
    }

}

