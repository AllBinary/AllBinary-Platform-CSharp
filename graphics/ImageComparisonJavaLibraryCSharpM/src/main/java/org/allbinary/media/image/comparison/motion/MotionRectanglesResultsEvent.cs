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
using AllBinaryEventObject = org.allbinary.logic.util.@event.AllBinaryEventObject;

namespace org.allbinary.media.image.comparison.motion;

public class MotionRectanglesResultsEvent : AllBinaryEventObject
{
    private readonly long? frame;
    private MotionRectangles motionRectangles = null;
    public MotionRectanglesResultsEvent(object anyType, long? frame, MotionRectangles motionRectangles) : base(anyType)
    {
        // base(anyType) is called from the constructor declaration
        this.frame = frame;
        this.setMotionRectangles(motionRectangles);
    }

    public virtual MotionRectangles getMotionRectangles()
    {
        return this.motionRectangles;
    }

    public virtual void setMotionRectangles(MotionRectangles motionRectangles)
    {
        this.motionRectangles = motionRectangles;
    }

    public virtual long? getFrame()
    {
        return this.frame;
    }

}

