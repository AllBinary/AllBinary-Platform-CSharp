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
using MyCanvas = org.allbinary.graphics.displayable.MyCanvas;
using ScrollSelectionForm = org.allbinary.graphics.form.ScrollSelectionForm;
using MotionGestureEvent = org.allbinary.input.motion.gesture.observer.MotionGestureEvent;
using BasicArrayList = org.allbinary.util.BasicArrayList;

namespace org.allbinary.game.displayable.canvas;

public class PopupCommandFormInputProcessor : CommandFormInputProcessor
{
    public PopupCommandFormInputProcessor(BasicArrayList gameKeyEventList, int playerInputId, MyCanvas gameCanvas, ScrollSelectionForm form, PopupMenuInputProcessor popupMenuInputProcessor) : base(gameKeyEventList, playerInputId, gameCanvas, form)
    {
        // base(gameKeyEventList, playerInputId, gameCanvas, form) is called from the constructor declaration
    }

    // throws Exception
    public override int processInput(int key)
    {
        return base.processInput(key);
    }

    // throws Exception
    protected override void processMotionInput(MotionGestureEvent motionGestureEvent)
    {
        base.processMotionInput(motionGestureEvent);
    }

}

