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
using Canvas = javax.microedition.lcdui.Canvas;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using LockedFeatureNotificationUtil = org.allbinary.logic.system.security.licensing.LockedFeatureNotificationUtil;
using LockedUtil = org.allbinary.logic.system.security.licensing.LockedUtil;
using Processor = org.allbinary.canvas.Processor;
using AllBinaryGameCanvas = org.allbinary.game.displayable.canvas.AllBinaryGameCanvas;
using PreGameSelectorPaintable = org.allbinary.game.displayable.canvas.PreGameSelectorPaintable;
using GameKeyEventHandler = org.allbinary.game.input.@event.GameKeyEventHandler;
using GameKeyEventUtil = org.allbinary.game.input.@event.GameKeyEventUtil;
using GameState = org.allbinary.game.state.GameState;
using AllBinaryLayerManager = org.allbinary.layer.AllBinaryLayerManager;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;
using SecondaryPlayerQueueFactory = org.allbinary.media.audio.SecondaryPlayerQueueFactory;
using SelectSound = org.allbinary.media.audio.SelectSound;
using ABRunnable = org.allbinary.thread.ABRunnable;
using ThreadObjectUtil = org.allbinary.thread.ThreadObjectUtil;
using TimeDelayHelper = org.allbinary.time.TimeDelayHelper;

namespace org.allbinary.game.input;

public class PreGameSelectionGameInputProcessor : Processor, GameInputProcessorInterface, PlayerGameInputCompositeInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly AllBinaryGameCanvas gameCanvas;
    private readonly PreGameSelectorPaintable preGameSelectorPaintable;
    private readonly TimeDelayHelper inputTimeHelper = new TimeDelayHelper(650);
    private readonly GameState nextGameState;
    private readonly PlayerGameInput playerGameInput;
    private readonly int lockedIndex;
    public class PreGameSelectionRunnable : ABRunnable
    {
        private readonly PreGameSelectionGameInputProcessor outer;

        private readonly PreGameSelectionGameInputProcessor inputProcessor;
        public PreGameSelectionRunnable(PreGameSelectionGameInputProcessor outer, PreGameSelectionGameInputProcessor inputProcessor)
        {
            this.outer = outer;
            this.inputProcessor = inputProcessor;
        }

        public override void run()
        {
            try {
                this.setRunning(true);
                SecondaryPlayerQueueFactory.getInstance().add(SelectSound.getInstance());
                this.inputProcessor.gameCanvas.setGameState(this.inputProcessor.nextGameState);
                GameKeyEventHandler.getInstance().removeListener(this.inputProcessor.getPlayerGameInput());
                this.setRunning(false);
            } catch (Exception e) {
                this.setRunning(false);
                LogUtil logUtil = LogUtil.getInstance();
                CommonStrings commonStrings = CommonStrings.getInstance();
                logUtil.put(commonStrings.EXCEPTION, this, commonStrings.RUN, e);
            }
        }

    }
    private readonly ABRunnable abRunnable;
    public PreGameSelectionGameInputProcessor(AllBinaryGameCanvas gameCanvas, PreGameSelectorPaintable preGameSelectorPaintable, GameState nextGameState, int lockedIndex)
    {
        this.abRunnable = new PreGameSelectionRunnable(this, this);
        this.gameCanvas = gameCanvas;
        this.preGameSelectorPaintable = preGameSelectorPaintable;
        this.nextGameState = nextGameState;
        this.playerGameInput = new GameInputProcessorComposite("Pre Game Selection", this);
        this.lockedIndex = lockedIndex;
    }

    // throws Exception
    public override void process()
    {
        this.getPlayerGameInput().update();
    }

    // throws Exception
    public virtual void onInput(BasicArrayList list)
    {
        int size = list.size();
        for (int index = 0; index < size; index++) {
            object anyType = list.get(index);
            int key = GameKeyEventUtil.getKey(anyType);
            if (key == Canvas.LEFT || key == Canvas.RIGHT || key == Canvas.UP || key == Canvas.DOWN) {
                if (this.inputTimeHelper.isTimeTNT()) {
                    SecondaryPlayerQueueFactory.getInstance().add(SelectSound.getInstance());
                    this.getPreGameSelectorPaintable().getPreGameSelectionForm().processInputKey(key);
                    break;
                }
            } else if (key == Canvas.KEY_NUM0) {
                int selectedIndex = this.preGameSelectorPaintable.getPreGameSelectionForm().getSelectedIndex();
                if (selectedIndex < this.lockedIndex || !LockedUtil.getInstance().isLocked()) {
                    if (!abRunnable.isRunning()) {
                        abRunnable.setRunning(true);
                        ThreadObjectUtil.getInstance().processThread(abRunnable);
                    }
                    break;
                } else {
                    LockedFeatureNotificationUtil.getInstance().fire();
                }
            }
        }
        list.clear();
    }

    public virtual PreGameSelectorPaintable getPreGameSelectorPaintable()
    {
        return this.preGameSelectorPaintable;
    }

    // throws Exception
    public virtual void processInput(AllBinaryLayerManager layerManager)
    {
    }

    public virtual void initInputProcessors()
    {
    }

    public virtual string getName()
    {
        return this.ToString();
    }

    public virtual PlayerGameInput getPlayerGameInput()
    {
        return this.playerGameInput;
    }

}

