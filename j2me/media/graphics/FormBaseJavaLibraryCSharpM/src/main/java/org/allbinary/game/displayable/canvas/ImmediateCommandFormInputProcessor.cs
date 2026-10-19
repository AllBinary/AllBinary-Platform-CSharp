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
using System.Runtime.CompilerServices;
using GameKeyEvent = org.allbinary.game.input.@event.GameKeyEvent;
using ScrollSelectionForm = org.allbinary.graphics.form.ScrollSelectionForm;
using MotionGestureEvent = org.allbinary.input.motion.gesture.observer.MotionGestureEvent;
using TimeDelayHelper = org.allbinary.time.TimeDelayHelper;
using BasicArrayList = org.allbinary.util.BasicArrayList;

namespace org.allbinary.game.displayable.canvas;

public class ImmediateCommandFormInputProcessor : CommandFormInputProcessor
{
    private readonly TimeDelayHelper timeHelper = new TimeDelayHelper(25);
    public GameCommandCanvas gameCommandCanvas;
    public ImmediateCommandFormInputProcessor(BasicArrayList gameKeyEventList, int playerInputId, GameCommandCanvas gameCommandCanvas, ScrollSelectionForm form) : base(gameKeyEventList, playerInputId, gameCommandCanvas, form)
    {
        // base(gameKeyEventList, playerInputId, gameCommandCanvas, form) is called from the constructor declaration
        this.gameCommandCanvas = gameCommandCanvas;
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public override void onPressGameKeyEvent(GameKeyEvent gameKeyEvent)
    {
        try {
            base.onPressGameKeyEvent(gameKeyEvent);
            if (this.timeHelper.isTimeTNT()) {
                this.processInputList();
                this.gameCommandCanvas.repaintBehavior.onChangeRepaint(this.getCanvas());
            }
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, this.gameInputStrings.ON_PRESS_GAME_KEY, e);
        }
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public override void onDownGameKeyEvent(GameKeyEvent gameKeyEvent)
    {
        try {
            base.onDownGameKeyEvent(gameKeyEvent);
            if (this.timeHelper.isTimeTNT()) {
                this.processInputList();
                this.gameCommandCanvas.repaintBehavior.onChangeRepaint(this.getCanvas());
            }
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, this.gameInputStrings.ON_DOWN_GAME_KEY, e);
        }
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public override void onUpGameKeyEvent(GameKeyEvent gameKeyEvent)
    {
        try {
            base.onUpGameKeyEvent(gameKeyEvent);
            if (this.timeHelper.isTimeTNT()) {
                this.processInputList();
                this.gameCommandCanvas.repaintBehavior.onChangeRepaint(this.getCanvas());
            }
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, this.gameInputStrings.ON_UP_GAME_KEY, e);
        }
    }

    public override void onMotionGestureEvent(MotionGestureEvent motionGestureEvent)
    {
        try {
            base.onMotionGestureEvent(motionGestureEvent);
            if (this.timeHelper.isTimeTNT()) {
                this.processInputList();
                this.gameCommandCanvas.repaintBehavior.onChangeRepaint(this.getCanvas());
            }
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "onMotionGestureEvent", e);
        }
    }

}

