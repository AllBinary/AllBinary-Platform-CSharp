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
using BasicArrayList = org.allbinary.util.BasicArrayList;
using LockedFeatureNotificationUtil = org.allbinary.logic.system.security.licensing.LockedFeatureNotificationUtil;
using LockedUtil = org.allbinary.logic.system.security.licensing.LockedUtil;
using Processor = org.allbinary.canvas.Processor;
using AllBinaryGameCanvas = org.allbinary.game.displayable.canvas.AllBinaryGameCanvas;
using PreGameSelectorPaintable = org.allbinary.game.displayable.canvas.PreGameSelectorPaintable;
using GameKeyEventHandler = org.allbinary.game.input.@event.GameKeyEventHandler;
using GameKeyEventUtil = org.allbinary.game.input.@event.GameKeyEventUtil;
using AllBinaryLayerManager = org.allbinary.layer.AllBinaryLayerManager;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;
using SecondaryPlayerQueueFactory = org.allbinary.media.audio.SecondaryPlayerQueueFactory;
using SelectSound = org.allbinary.media.audio.SelectSound;
using MultiLevelRaceTrackGeographicMapInterfaceFactoryInterface = org.allbinary.media.graphics.geography.map.racetrack.MultiLevelRaceTrackGeographicMapInterfaceFactoryInterface;
using ABRunnable = org.allbinary.thread.ABRunnable;
using ThreadObjectUtil = org.allbinary.thread.ThreadObjectUtil;
using TimeDelayHelper = org.allbinary.time.TimeDelayHelper;

namespace org.allbinary.game.input;

public class MapSelectionGameInputProcessor : Processor, GameInputProcessorInterface, PlayerGameInputCompositeInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly AllBinaryGameCanvas gameCanvas;
    private readonly MultiLevelRaceTrackGeographicMapInterfaceFactoryInterface raceTrackGeographicMapInterfaceFactoryInterface;
    private readonly PreGameSelectorPaintable preGameSelectorPaintable;
    private readonly TimeDelayHelper inputTimeHelper = new TimeDelayHelper(650);
    private readonly PlayerGameInput playerGameInput;
    private readonly int lockedIndex;
    private readonly ABRunnable abRunnable = new ABRunnable()
#if JAVA_ANONYMOUS_CLASS_BODY
        public virtual void run()
        {
            try {
                this.setRunning(true);
                SecondaryPlayerQueueFactory.getInstance().add(SelectSound.getInstance());
                int track = preGameSelectorPaintable.getPreGameSelectionForm().getSelectedIndex() + 1;
                int wave = raceTrackGeographicMapInterfaceFactoryInterface.getFirstWaveWithTrack(track);
                gameCanvas.getLayerManager().getGameInfo().setCurrentLevel(wave);
                gameCanvas.buildGameInit(false);
                GameKeyEventHandler.getInstance().removeListener(getPlayerGameInput());
                this.setRunning(false);
            } catch (Exception e) {
                this.setRunning(false);
                LogUtil logUtil = LogUtil.getInstance();
                CommonStrings commonStrings = CommonStrings.getInstance();
                logUtil.put(commonStrings.EXCEPTION, this, commonStrings.RUN, e);
            }
        }

#endif
;
    public MapSelectionGameInputProcessor(AllBinaryGameCanvas gameCanvas, MultiLevelRaceTrackGeographicMapInterfaceFactoryInterface raceTrackGeographicMapInterfaceFactoryInterface, PreGameSelectorPaintable mapSelectorPaintable, int lockedIndex)
    {
        this.gameCanvas = gameCanvas;
        this.raceTrackGeographicMapInterfaceFactoryInterface = raceTrackGeographicMapInterfaceFactoryInterface;
        this.preGameSelectorPaintable = mapSelectorPaintable;
        this.playerGameInput = new GameInputProcessorComposite("Map Selection", this);
        this.lockedIndex = lockedIndex;
    }

    // throws Exception
    public override void process()
    {
        this.getPlayerGameInput().update();
    }

    // throws Exception
    public override void onInput(BasicArrayList list)
    {
        int size = list.size();
        for (int index = 0; index < size; index++) {
            object anyType = list.get(index);
            int key = GameKeyEventUtil.getKey(anyType);
            if (key == Canvas.LEFT || key == Canvas.RIGHT || key == Canvas.UP || key == Canvas.DOWN) {
                if (this.inputTimeHelper.isTimeTNT()) {
                    SecondaryPlayerQueueFactory.getInstance().add(SelectSound.getInstance());
                    this.preGameSelectorPaintable.getPreGameSelectionForm().processInputKey(key);
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
            list.clear();
        }
    }

    // throws Exception
    public override void processInput(AllBinaryLayerManager layerManager)
    {
    }

    public override void initInputProcessors()
    {
    }

    public override string getName()
    {
        return this.ToString();
    }

    public override PlayerGameInput getPlayerGameInput()
    {
        return this.playerGameInput;
    }

}

