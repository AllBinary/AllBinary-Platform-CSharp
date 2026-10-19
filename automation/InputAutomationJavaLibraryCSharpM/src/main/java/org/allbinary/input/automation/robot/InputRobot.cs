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
using PointHelper = org.allbinary.input.automation.PointHelper;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;

namespace org.allbinary.input.automation.robot;

public class InputRobot : InputRobotInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private Robot robot;
    public static readonly string NAME = "Java Robot";
    public InputRobot(GraphicsDevice graphicsDevice)
    {
        this.robot = new Robot(graphicsDevice);
    }

    public virtual string getName()
    {
        return InputRobot.NAME;
    }

    public virtual HelpSet getHelpSet()
    {
        return null;
    }

    public virtual Point getMousePoint()
    {
        Point point = MouseInfo.getPointerInfo().getLocation();
        return point;
    }

    // throws Exception
    public virtual void mouseMoveToTarget(Rectangle rectangle, int? x, int? y)
    {
        Point point = PointHelper.getCenterPoint(rectangle);
        this.robot.mouseMove(point.x + x, point.y + y);
        string message = new StringMaker().append("Moved Mouse To: x: ").appendint(((int) point.x)).append(" y: ").appendint(((int) point.y)).append(" in the middle of: ").append(StringUtil.getInstance().toString(rectangle)).ToString();
        this.logUtil.putF(message, this, "moveMouseToTarget");
    }

    public virtual void mouseMove(Point point)
    {
        this.mouseMove(point.x, point.y);
    }

    public virtual void mouseMove(int x, int y)
    {
        this.robot.mouseMove(x, y);
        string message = new StringMaker().append("Moved Mouse To: x: ").appendint(x).append(" y: ").appendint(y).ToString();
        this.logUtil.putF(message, this, "moveMouse");
    }

    // throws Exception
    public virtual void mouseMoveToTarget(Rectangle rectangle)
    {
        this.mouseMoveToTarget(rectangle, 0, 0);
    }

    public virtual BufferedImage createScreenCapture(Rectangle screenRect)
    {
        return this.robot.createScreenCapture(screenRect);
    }

    public virtual void delay(int? ms)
    {
        this.robot.delay(ms);
    }

    public virtual int? getAutoDelay()
    {
        return this.robot.getAutoDelay();
    }

    public virtual Color getPixelColor(int? x, int? y)
    {
        return this.robot.getPixelColor(x, y);
    }

    public virtual bool isAutoWaitForIdle()
    {
        return this.robot.isAutoWaitForIdle();
    }

    public virtual void keyPress(int? keycode)
    {
        this.robot.keyPress(keycode);
    }

    public virtual void keyRelease(int? keycode)
    {
        this.robot.keyRelease(keycode);
    }

    public virtual void mouseMove(int? x, int? y)
    {
        this.robot.mouseMove(x, y);
    }

    public virtual void mousePress(int? buttons)
    {
        this.robot.mousePress(buttons);
    }

    public virtual void mouseRelease(int? buttons)
    {
        this.robot.mouseRelease(buttons);
    }

    public virtual void mouseWheel(int? wheelAmt)
    {
        this.robot.mouseWheel(wheelAmt);
    }

    public virtual void setAutoDelay(int? ms)
    {
        this.robot.setAutoDelay(ms);
    }

    public virtual void setAutoWaitForIdle(bool isOn)
    {
        this.robot.setAutoWaitForIdle(isOn);
    }

    public override string ToString()
    {
        return this.robot.ToString();
    }

    public virtual void waitForIdle()
    {
        this.robot.waitForIdle();
    }

    public virtual void on()
    {
    }

    public virtual void off()
    {
    }

}

