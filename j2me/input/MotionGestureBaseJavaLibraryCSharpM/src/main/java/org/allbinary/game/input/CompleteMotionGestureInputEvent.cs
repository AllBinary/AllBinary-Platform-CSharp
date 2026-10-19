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
using MotionGestureInput = org.allbinary.input.motion.gesture.MotionGestureInput;
using TouchMotionGestureFactory = org.allbinary.input.motion.gesture.TouchMotionGestureFactory;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using AllBinaryEventObject = org.allbinary.logic.util.@event.AllBinaryEventObject;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.game.input;

public class CompleteMotionGestureInputEvent : AllBinaryEventObject, CompleteMotionGestureInputInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private string name = StringUtil.getInstance().EMPTY_STRING;
    private MotionGestureInput motionGestureInput = TouchMotionGestureFactory.getInstance().NO_MOTION;
    public CompleteMotionGestureInputEvent(string name, MotionGestureInput motionGestureInput) : base(motionGestureInput)
    {
        // base(motionGestureInput) is called from the constructor declaration
        this.setName(name);
        try {
            this.setMotionGestureInput(motionGestureInput);
        } catch (Exception e) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            this.logUtil.put(commonStrings.EXCEPTION, this, "InputToGameKeyEventAction", e);
        }
    }

    protected virtual void setName(string name)
    {
        this.name = name;
    }

    public override string getName()
    {
        return this.name;
    }

    public virtual void setMotionGestureInput(MotionGestureInput motionGestureInput)
    {
        this.motionGestureInput = motionGestureInput;
    }

    public virtual MotionGestureInput getMotionGestureInput()
    {
        return this.motionGestureInput;
    }

}

