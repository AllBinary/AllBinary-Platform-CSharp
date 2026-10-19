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
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;
using AllBinaryLayerManager = org.allbinary.layer.AllBinaryLayerManager;
using SmallIntegerSingletonFactory = org.allbinary.logic.math.SmallIntegerSingletonFactory;
using GameTickTimeDelayHelperFactory = org.allbinary.time.GameTickTimeDelayHelperFactory;
using TimeDelayHelper = org.allbinary.time.TimeDelayHelper;

namespace org.allbinary.game.ag.ai.scroller;

public class TimedFireAI : BasicAI
{
    public static readonly int? TIME = SmallIntegerSingletonFactory.getInstance().getAt(1);
    public readonly TimeDelayHelper maxFireDelayTimeHelper = new TimeDelayHelper(0);
    private readonly int delay;
    public TimedFireAI(int delay, AllBinaryLayer ownerLayerInterface, GameInput gameInput) : base(ownerLayerInterface, gameInput)
    {
        // base(ownerLayerInterface, gameInput) is called from the constructor declaration
        this.delay = delay;
    }

    // throws Exception
    public override void processAI(AllBinaryLayerManager allBinaryLayerManager)
    {
        TimeFiredInterface timeFiredInterface = ((TimeFiredInterface) this.getOwnerLayerInterface());
        if (this.maxFireDelayTimeHelper.isTime(GameTickTimeDelayHelperFactory.getInstance().startTime) && timeFiredInterface.getLastFireTime() + this.maxFireDelayTimeHelper.delay < this.maxFireDelayTimeHelper.getStartTime()) {
            base.processKeyAI(Canvas.KEY_NUM1);
            this.maxFireDelayTimeHelper.delay = this.delay;
        }
    }

}

