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

namespace org.allbinary.input.automation.robot;

public interface InputRobotInterface
{
    string getName();

    HelpSet getHelpSet();

    BufferedImage createScreenCapture(Rectangle screenRect);

    void delay(int? ms);

    int? getAutoDelay();

    Color getPixelColor(int? x, int? y);

    bool isAutoWaitForIdle();

    void keyPress(int? keycode);

    void keyRelease(int? keycode);

    Point getMousePoint();

    void mouseMove(int? x, int? y);

    void mousePress(int? buttons);

    void mouseRelease(int? buttons);

    void mouseWheel(int? wheelAmt);

    void setAutoDelay(int? ms);

    void setAutoWaitForIdle(bool isOn);

    string ToString();

    void waitForIdle();

    void mouseMove(Point point);

    // throws Exception
    void mouseMoveToTarget(Rectangle rectangle);

    // throws Exception
    void mouseMoveToTarget(Rectangle rectangle, int? x, int? y);

}

