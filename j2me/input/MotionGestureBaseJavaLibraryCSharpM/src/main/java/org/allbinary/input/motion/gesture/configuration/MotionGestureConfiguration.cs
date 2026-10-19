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
using CompleteMotionGestureInputEvent = org.allbinary.game.input.CompleteMotionGestureInputEvent;
using BasicColor = org.allbinary.graphics.color.BasicColor;
using BasicColorFactory = org.allbinary.graphics.color.BasicColorFactory;
using MotionGestureToMotionGestureActionAssociation = org.allbinary.input.motion.gesture.MotionGestureToMotionGestureActionAssociation;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.input.motion.gesture.configuration;

public class MotionGestureConfiguration
{
    private bool diagonalMotionGestureAllowed = true;
    private int diagonalTolerance = 7;
    private int minimumMotionGesture = 9;
    private string button = StringUtil.getInstance().EMPTY_STRING;
    private BasicColor color = BasicColorFactory.getInstance().BLUE;
    private bool executingActions = true;
    private int mouseButtonMask = 0;
    private BasicArrayList activeCommands = new BasicArrayListD();
    public MotionGestureConfiguration()
    {
    }

    public virtual void addMotionGestureAction(BasicArrayList list, CompleteMotionGestureInputEvent commandAction)
    {
        this.activeCommands.add(new MotionGestureToMotionGestureActionAssociation(list, commandAction));
    }

    public virtual void clearMotionGestureAction()
    {
        this.activeCommands.clear();
    }

    public virtual BasicArrayList getAssociateCommandActionsList()
    {
        return this.activeCommands;
    }

    public virtual bool isDiagonalMotionGestureAllowed()
    {
        return this.diagonalMotionGestureAllowed;
    }

    public virtual bool isExecutingActionsAllowed()
    {
        return this.executingActions;
    }

    public virtual void setExecutingActionsAllowed(bool executingActionAllowed)
    {
        this.executingActions = executingActionAllowed;
    }

    public virtual void setDiagonalMotionGestureAllowed(bool diagonalMotionGestureAllowed)
    {
        this.diagonalMotionGestureAllowed = diagonalMotionGestureAllowed;
    }

    public virtual int getDiagonalTolerance()
    {
        return this.diagonalTolerance;
    }

    public virtual void setDiagonalTolerance(int diagonalTolerance)
    {
        this.diagonalTolerance = diagonalTolerance;
    }

    public virtual int getMinimumMotionGesture()
    {
        return this.minimumMotionGesture;
    }

    public virtual void setMinimumMotionGesture(int minimumMotionGesture)
    {
        this.minimumMotionGesture = minimumMotionGesture;
    }

    public virtual string getButton()
    {
        return this.button;
    }

    public virtual void setButton(string button)
    {
        this.button = button;
    }

    public virtual BasicColor getColor()
    {
        return this.color;
    }

    public virtual void setColor(BasicColor color)
    {
        this.color = color;
    }

    public virtual int getMouseButtonMask()
    {
        return this.mouseButtonMask;
    }

    public virtual void setMouseButtonMask(int mouseButtonMask)
    {
        this.mouseButtonMask = mouseButtonMask;
    }

}

