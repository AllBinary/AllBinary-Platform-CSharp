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
//using Canvas = javax.microedition.lcdui.Canvas;
//using Command = javax.microedition.lcdui.Command;
using GameCommandsFactory = org.allbinary.game.commands.GameCommandsFactory;
using Features = org.allbinary.game.configuration.feature.Features;
using InputFeatureFactory = org.allbinary.game.configuration.feature.InputFeatureFactory;
using GameKeyEvent = org.allbinary.game.input.@event.GameKeyEvent;
using GameKeyEventFactory = org.allbinary.game.input.@event.GameKeyEventFactory;
using SWTUtil = org.allbinary.game.layer.SWTUtil;
using GPoint = org.allbinary.graphics.GPoint;
using MyCanvas = org.allbinary.graphics.displayable.MyCanvas;
using CommandCurrentSelectionForm = org.allbinary.graphics.form.CommandCurrentSelectionForm;
using ScrollSelectionForm = org.allbinary.graphics.form.ScrollSelectionForm;
using OpenGLFeatureFactory = org.allbinary.graphics.opengles.OpenGLFeatureFactory;
using MotionGestureInput = org.allbinary.input.motion.gesture.MotionGestureInput;
using TouchMotionGestureFactory = org.allbinary.input.motion.gesture.TouchMotionGestureFactory;
using MotionGestureEvent = org.allbinary.input.motion.gesture.observer.MotionGestureEvent;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using PrimaryPlayerQueueFactory = org.allbinary.media.audio.PrimaryPlayerQueueFactory;
using SelectSound = org.allbinary.media.audio.SelectSound;
using PrimaryThreadPool = org.allbinary.thread.PrimaryThreadPool;
using TimeDelayHelper = org.allbinary.time.TimeDelayHelper;
using BasicArrayList = org.allbinary.util.BasicArrayList;

namespace org.allbinary.game.displayable.canvas;

//In general allow scrolling of the menu and selection the center item
public class CommandFormInputProcessor : BasicMenuInputProcessor
{
    private readonly int MOTION_GESTURE_SOURCE_ID = GameKeyEventFactory.getInstance().MOTION_GESTURE_SOURCE_ID;
    private readonly int CLICK_DELAY = 150;
    private readonly TimeDelayHelper clickTimeHelper;
    private readonly int DOUBLE_CLICK_DELAY = 1200;
    private readonly TimeDelayHelper doubleClickTimeHelper;
    public readonly bool isSingleKeyProcessing = InputFeatureFactory.getInstance().isSingleKeyProcessing();
    private ScrollSelectionForm form;
    private bool hasPressed = false;
    public CommandFormInputProcessor(BasicArrayList gameKeyEventList, int playerInputId, MyCanvas gameCanvas, ScrollSelectionForm form) : base(gameKeyEventList, playerInputId, gameCanvas)
    {
        this.clickTimeHelper = new TimeDelayHelper(this.CLICK_DELAY);
        this.doubleClickTimeHelper = new TimeDelayHelper(this.DOUBLE_CLICK_DELAY);
        // base(gameKeyEventList, playerInputId, gameCanvas) is called from the constructor declaration
        this.form = form;
    }

    // throws Exception
    public virtual int processInput(int key)
    {
        if (key == Canvas.LEFT || key == Canvas.RIGHT || key == Canvas.UP || key == Canvas.DOWN) {
            PrimaryPlayerQueueFactory.getInstance().add(SelectSound.getInstance());
            this.form.processInputKey(key);
            return 1;
        } else if (key == Canvas.FIRE) {
            PrimaryPlayerQueueFactory.getInstance().add(SelectSound.getInstance());
            return this.processCommand();
        }
        return 0;
    }

    private readonly string PROCESS_COMMAND = "processCommand";
    private int processCommand()
    {
        CommandCurrentSelectionForm commandCurrentSelectionForm = ((CommandCurrentSelectionForm) this.form);
        Command command = commandCurrentSelectionForm.getSelectedCommand();
        this.logUtil.putF(command.ToString(), this, this.PROCESS_COMMAND);
        Features features = Features.getInstance();
        OpenGLFeatureFactory openGLFeatureFactory = OpenGLFeatureFactory.getInstance();
        if (SWTUtil.isSWT && features.isFeature(openGLFeatureFactory.OPENGL) && command != GameCommandsFactory.getInstance().EXIT_COMMAND) {
            new CommandRunnable(this, command).run();
        } else {
            PrimaryThreadPool.getInstance().runTask(new CommandRunnable(this, command));
        }
        if (command == GameCommandsFactory.getInstance().QUIT_COMMAND) {
            return -1;
        } else {
            return 1;
        }
    }

    // throws Exception
    public override int processInputList()
    {
        try {
            int motionInputsIndex = this.processMotionInputs();
            BasicArrayList list = this.getGameKeyEventList();
            int size = list.size();
            int key = 0;
            GameKeyEvent gameKeyEvent = null;
            for (int index = 0; index < size; index++) {
                gameKeyEvent = ((GameKeyEvent) list.objectArray[index]);
                key = gameKeyEvent.getKey();
                if (gameKeyEvent.getSourceId() != this.MOTION_GESTURE_SOURCE_ID) {
                    if (this.processInput(key) == 1) {
                        break;
                    }
                }
            }
            this.clear();
            if (size > 0 || motionInputsIndex >= 0) {
                return 1;
            } else {
                return -1;
            }
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, this.gameInputStrings.PROCESS_INPUT, e);
            return -1;
        }
    }

    // throws Exception
    public virtual int processMotionInputs()
    {
        int lastIndex = this.motionGestureEventList.size() - 1;
        if (lastIndex >= 0) {
            MotionGestureEvent motionGestureEvent = ((MotionGestureEvent) this.motionGestureEventList.objectArray[lastIndex]);
            this.processMotionInput(motionGestureEvent);
        }
        this.motionGestureEventList.clear();
        return lastIndex;
    }

    // throws Exception
    protected virtual void processMotionInput(MotionGestureEvent motionGestureEvent)
    {
        TouchMotionGestureFactory touchMotionGestureFactory = TouchMotionGestureFactory.getInstance();
        MotionGestureInput motionGestureInput = motionGestureEvent.getMotionGesture();
        if (motionGestureInput == touchMotionGestureFactory.RELEASED) {
            GPoint point = motionGestureEvent.getCurrentPoint();
            if (this.form.isInForm(point)) {
                int index = this.form.getSelectedIndexForPoint(point);
                if (index != -1) {
                    PrimaryPlayerQueueFactory.getInstance().add(SelectSound.getInstance());
                    if (index == this.form.getSelectedIndex()) {
                        if (this.clickTimeHelper.isTimeTNT()) {
                            this.processCommand();
                        }
                    } else {
                        this.form.setSelectedIndex(index);
                    }
                } else {
                }
            }
            if (this.hasPressed) {
                if (!this.doubleClickTimeHelper.isTimeTNT()) {
                    this.logUtil.putF("Double Press", this, this.gameInputStrings.PROCESS_MOTION_INPUT);
                    this.processCommand();
                }
                this.doubleClickTimeHelper.delay = this.DOUBLE_CLICK_DELAY;
                this.doubleClickTimeHelper.setStartTimeTNT();
            }
            this.hasPressed = false;
        } else if (motionGestureInput == touchMotionGestureFactory.PRESSED) {
            this.doubleClickTimeHelper.delay = 0;
            this.hasPressed = true;
        }
    }

    private readonly string NAME_LABEL = " ScrollSelectionForm: ";
    public override string ToString()
    {
        return new StringMaker().append(base.ToString()).append(this.NAME_LABEL).append(this.form.ToString()).ToString();
    }

}

