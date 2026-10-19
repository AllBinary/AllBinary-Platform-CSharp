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
using TouchButtonRecognizer = org.allbinary.input.motion.button.TouchButtonRecognizer;

namespace org.allbinary.input.motion;

public class OnlyTouchButtonRecognizer : MotionRecognizer
{
    private readonly TouchButtonRecognizer touchButtonRecognizer;
    private bool touchButtonProcessing = false;
    public OnlyTouchButtonRecognizer()
    {
        this.touchButtonRecognizer = new TouchButtonRecognizer();
    }

    // throws Exception
    public override void processStartMotionEvent(int x, int y, int deviceId, int modifiers)
    {
        if (this.touchButtonRecognizer.pressTouchButtonInput(x, y, deviceId)) {
            this.touchButtonProcessing = true;
        }
    }

    // throws Exception
    public override void processEndMotionEvent(int x, int y, int deviceId, int modifiers)
    {
        if (this.touchButtonProcessing) {
            this.touchButtonProcessing = false;
        }
        if (this.touchButtonRecognizer.releaseTouchButtonInput(x, y, deviceId)) {
            return;
        }
    }

    // throws Exception
    public override void processDraggedMotionEvent(int x, int y, int deviceId, int modifiers)
    {
        if (this.touchButtonProcessing) {
            this.touchButtonRecognizer.pressTouchButtonInput(x, y, deviceId);
        }
    }

}

