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
using BasicAI = org.allbinary.game.ai.BasicAI;
using GameInput = org.allbinary.game.input.GameInput;
using AllBinaryGameLayerManager = org.allbinary.game.layer.AllBinaryGameLayerManager;
using MyRandomFactory = org.allbinary.game.rand.MyRandomFactory;
using DisplayInfoSingleton = org.allbinary.graphics.displayable.DisplayInfoSingleton;
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;
using AllBinaryLayerManager = org.allbinary.layer.AllBinaryLayerManager;
using SmallIntegerSingletonFactory = org.allbinary.logic.math.SmallIntegerSingletonFactory;
using PlayerQueue = org.allbinary.media.audio.PlayerQueue;
using SecondaryPlayerQueueFactory = org.allbinary.media.audio.SecondaryPlayerQueueFactory;
using Sound = org.allbinary.media.audio.Sound;
using TimeDelayHelper = org.allbinary.time.TimeDelayHelper;
using org.allbinary.util;

namespace org.allbinary.game.ag.ai.scroller;

public class HorizontalScreenPatrolAI : BasicAI
{
    public int keyDirection = Canvas.LEFT;
    private readonly DisplayInfoSingleton displayInfoSingleton = DisplayInfoSingleton.getInstance();
    private int firingX;
    private int firedIndex = 0;
    private readonly int MAX_FIRE = 28;
    private readonly TimeDelayHelper timeDelayHelper = new TimeDelayHelper(240);
    private readonly PlayerQueue secondaryPlayerQueue = SecondaryPlayerQueueFactory.getInstance();
    private readonly Sound sound;
    public static readonly int? SOUND = SmallIntegerSingletonFactory.getInstance().getAt(433);
    public HorizontalScreenPatrolAI(ABHashtable<object, object> hashtable, AllBinaryLayer ownerLayerInterface, GameInput gameInput) : base(ownerLayerInterface, gameInput)
    {
        this.firingX = this.displayInfoSingleton.getLastHalfWidth();
        // base(ownerLayerInterface, gameInput) is called from the constructor declaration
        this.sound = ((Sound) hashtable.get(HorizontalScreenPatrolAI.SOUND));
        if (this.sound == null) {
            throw new Exception("No Sound Provided!!");
        }
    }

    // throws Exception
    public override void processAI(AllBinaryLayerManager allBinaryLayerManager)
    {
        base.processKeyAI(this.keyDirection);
        if (this.timeDelayHelper.isTimeTNT()) {
            AllBinaryLayer layerInterface = this.getOwnerLayerInterface();
            int currentOwnerLayerX = layerInterface.getXP();
            if (currentOwnerLayerX < -layerInterface.getWidth()) {
                int y = MyRandomFactory.getInstance().getAbsoluteNextIntAllowZero(50);
                layerInterface.setPosition(this.displayInfoSingleton.getLastWidth() + layerInterface.getWidth() + 50, y, layerInterface.getZP());
                this.firedIndex = 0;
                this.firingX = this.displayInfoSingleton.getLastHalfWidth() + MyRandomFactory.getInstance().getNextInt(this.displayInfoSingleton.getLastHalfWidth());
                this.secondaryPlayerQueue.add(this.sound);
            }
            if (currentOwnerLayerX < this.firingX && currentOwnerLayerX > -layerInterface.getWidth()) {
                base.processKeyAI(Canvas.KEY_NUM1);
                AllBinaryGameLayerManager gameLayerManager = ((AllBinaryGameLayerManager) allBinaryLayerManager);
                int FIRE = (gameLayerManager.getGameInfo().getCurrentLevel() + 12) >> 2;
                if (FIRE > this.MAX_FIRE) {
                    FIRE = this.MAX_FIRE;
                }
                if (this.firedIndex > FIRE) {
                    this.firedIndex = 0;
                    this.firingX = int.MinValue;
                }
                this.firedIndex++;
            }
        }
    }

    public virtual void nextDirection()
    {
    }

}

