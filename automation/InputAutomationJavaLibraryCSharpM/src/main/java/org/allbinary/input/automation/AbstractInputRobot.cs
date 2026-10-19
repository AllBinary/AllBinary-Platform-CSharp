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
//using HelpSet = javax.help.HelpSet;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;

namespace org.allbinary.input.automation;

public class AbstractInputRobot
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private HelpSet helpSet = null;
    public AbstractInputRobot(HelpSet helpSet)
    {
        this.setHelpSet(helpSet);
    }

    public virtual HelpSet getHelpSet()
    {
        return this.helpSet;
    }

    public virtual void mouseMove(Point point)
    {
        this.mouseMove(point.x, point.y);
        this.logUtil.putF("Moved Mouse To: x: " + point.x + " y: " + point.y, this, "moveMouse");
    }

    // throws Exception
    public virtual void mouseMoveToTarget(Rectangle rectangle, int? x, int? y)
    {
        Point point = PointHelper.getCenterPoint(rectangle);
        this.mouseMove(point.x + x, point.y + y);
        this.logUtil.putF("Moved Mouse To: x: " + point.x + " y: " + point.y + " in the middle of: " + rectangle, this, "moveMouseToTarget");
    }

    // throws Exception
    public virtual void mouseMoveToTarget(Rectangle rectangle)
    {
        this.mouseMoveToTarget(rectangle, 0, 0);
    }

    public virtual void mouseMove(int? x, int? y)
    {
        throw new SystemException();
    }

    private void setHelpSet(HelpSet helpSet)
    {
        this.helpSet = helpSet;
    }

}

