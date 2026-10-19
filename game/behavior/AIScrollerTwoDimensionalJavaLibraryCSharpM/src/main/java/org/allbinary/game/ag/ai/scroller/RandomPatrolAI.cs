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
using GameInput = org.allbinary.game.input.GameInput;
using MyRandomFactory = org.allbinary.game.rand.MyRandomFactory;
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;
using AllBinaryLayerManager = org.allbinary.layer.AllBinaryLayerManager;
using org.allbinary.util;

namespace org.allbinary.game.ag.ai.scroller;

public class RandomPatrolAI : BasePatrolAI
{
    private bool changedDirection = true;
    public RandomPatrolAI(ABHashtable<object, object> hashtable, AllBinaryLayer ownerLayerInterface, GameInput gameInput) : base(hashtable, ownerLayerInterface, gameInput)
    {
        // base(hashtable, ownerLayerInterface, gameInput) is called from the constructor declaration
        this.updateRandomDistance();
    }

    private void updateRandomDistance()
    {
        this.currentDistance = MyRandomFactory.getInstance().getAbsoluteNextInt(((int) this.maxDistance));
    }

    // throws Exception
    public override void processAI(AllBinaryLayerManager allBinaryLayerManager)
    {
        base.update();
        base.processKeyAI(this.keyDirection);
        if (this.changedDirection) {
            base.processKeyAI(Canvas.KEY_NUM1);
            this.updateRandomDistance();
            this.changedDirection = false;
        }
    }

    protected override void nextDirection()
    {
        base.nextDirection();
        this.changedDirection = true;
    }

}

