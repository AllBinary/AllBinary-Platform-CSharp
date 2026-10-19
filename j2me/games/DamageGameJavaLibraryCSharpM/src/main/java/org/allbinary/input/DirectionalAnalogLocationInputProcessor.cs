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
using AnalogLocationInputProcessor = org.allbinary.android.input.motion.AnalogLocationInputProcessor;
using GameInputProcessor = org.allbinary.game.input.GameInputProcessor;
using GameKeyEventSourceInterface = org.allbinary.game.input.GameKeyEventSourceInterface;
using GameKeyFactory = org.allbinary.game.input.GameKeyFactory;
using AnalogLocationInput = org.allbinary.game.input.analog.AnalogLocationInput;
using GameKeyEvent = org.allbinary.game.input.@event.GameKeyEvent;
using GameKeyEventFactory = org.allbinary.game.input.@event.GameKeyEventFactory;
using CustomGPoint = org.allbinary.graphics.CustomGPoint;
using AllBinaryLayerManager = org.allbinary.layer.AllBinaryLayerManager;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.input;

public class DirectionalAnalogLocationInputProcessor : AnalogLocationInputProcessor, GameKeyEventSourceInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly GameInputProcessor[] inputProcessorArray;
    private readonly GameKeyFactory gameKeyFactory = GameKeyFactory.getInstance();
    private GameKeyEvent leftGameKeyEvent = GameKeyEvent.NONE;
    private GameKeyEvent rightGameKeyEvent = GameKeyEvent.NONE;
    private GameKeyEvent upGameKeyEvent = GameKeyEvent.NONE;
    private GameKeyEvent downGameKeyEvent = GameKeyEvent.NONE;
    private GameKeyEvent leftTriggerGameKeyEvent = GameKeyEvent.NONE;
    private GameKeyEvent rightTriggerGameKeyEvent = GameKeyEvent.NONE;
    public DirectionalAnalogLocationInputProcessor(GameInputProcessor[] inputProcessorArray)
    {
        this.inputProcessorArray = inputProcessorArray;
        try {
            this.leftGameKeyEvent = GameKeyEventFactory.getInstance().getInstanceForInput(this, this.gameKeyFactory.LEFT);
            this.rightGameKeyEvent = GameKeyEventFactory.getInstance().getInstanceForInput(this, this.gameKeyFactory.RIGHT);
            this.upGameKeyEvent = GameKeyEventFactory.getInstance().getInstanceForInput(this, this.gameKeyFactory.UP);
            this.downGameKeyEvent = GameKeyEventFactory.getInstance().getInstanceForInput(this, this.gameKeyFactory.DOWN);
            this.leftTriggerGameKeyEvent = GameKeyEventFactory.getInstance().getInstanceForInput(this, this.gameKeyFactory.KEY_NUM0);
            this.rightTriggerGameKeyEvent = GameKeyEventFactory.getInstance().getInstanceForInput(this, this.gameKeyFactory.KEY_NUM5);
        } catch (Exception e) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            this.logUtil.put(commonStrings.EXCEPTION, this, commonStrings.CONSTRUCTOR, e);
        }
    }

    public override void process(AllBinaryLayerManager allbinaryLayerManager, AnalogLocationInput analogLocationInput)
    {
        try {
            CustomGPoint customGPoint = null;
            customGPoint = analogLocationInput.getCustomGPoint();
            int x = customGPoint.getX();
            int y = customGPoint.getY();
            int leftTrigger = analogLocationInput.getLeftTrigger();
            int rightTrigger = analogLocationInput.getRightTrigger();
            if (x < 0) {
                this.inputProcessorArray[this.leftGameKeyEvent.getKey()].processAnalog(allbinaryLayerManager, this.leftGameKeyEvent, x);
            } else if (x > 0) {
                this.inputProcessorArray[this.rightGameKeyEvent.getKey()].processAnalog(allbinaryLayerManager, this.rightGameKeyEvent, x);
            }
            if (y < 0) {
                this.inputProcessorArray[this.downGameKeyEvent.getKey()].processAnalog(allbinaryLayerManager, this.downGameKeyEvent, y);
            } else if (y > 0) {
                this.inputProcessorArray[this.upGameKeyEvent.getKey()].processAnalog(allbinaryLayerManager, this.upGameKeyEvent, y);
            }
            if (leftTrigger > 0) {
                this.inputProcessorArray[this.leftTriggerGameKeyEvent.getKey()].processAnalog(allbinaryLayerManager, this.leftTriggerGameKeyEvent, leftTrigger);
            }
            if (rightTrigger > 0) {
                this.inputProcessorArray[this.rightTriggerGameKeyEvent.getKey()].processAnalog(allbinaryLayerManager, this.rightTriggerGameKeyEvent, rightTrigger);
            }
        } catch (Exception e) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            this.logUtil.put("Unable to process analog input", this, commonStrings.PROCESS, e);
        }
    }

    public override int getSourceId()
    {
        return 0;
    }

}

