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
using BasicVelocityProperties = org.allbinary.game.physics.velocity.BasicVelocityProperties;
using VelocityInterfaceCompositeInterface = org.allbinary.game.physics.velocity.VelocityInterfaceCompositeInterface;
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;
using MathUtil = org.allbinary.logic.math.MathUtil;
using SmallIntegerSingletonFactory = org.allbinary.logic.math.SmallIntegerSingletonFactory;
using org.allbinary.util;

namespace org.allbinary.game.ag.ai.scroller;

public class BasePatrolAI : BasicAI
{
    public static readonly int? MAX_DISTANCE = SmallIntegerSingletonFactory.getInstance().getAt(2);
    public static readonly int? DIRECTION_ARRAY = SmallIntegerSingletonFactory.getInstance().getAt(3);
    public static readonly int? FIRING_DISTANCE = SmallIntegerSingletonFactory.getInstance().getAt(4);
    public static int? SPEED = SmallIntegerSingletonFactory.getInstance().getAt(5);
    public int? maxDistance;
    public int currentDistance;
    public int xTotalDistance = 0;
    public int lastKeyDirection = Canvas.RIGHT;
    public int keyDirection = Canvas.RIGHT;
    public BasePatrolAI(ABHashtable<object, object> hashtable, AllBinaryLayer ownerLayerInterface, GameInput gameInput) : base(ownerLayerInterface, gameInput)
    {
        // base(ownerLayerInterface, gameInput) is called from the constructor declaration
        this.maxDistance = ((int?) hashtable.get(BasePatrolAI.MAX_DISTANCE));
        this.currentDistance = ((int) this.maxDistance);
    }

    protected virtual void update()
    {
        this.updateTotalDistance();
        this.changeDirectionIfReachedPacingAreaMax();
    }

    private void updateTotalDistance()
    {
        VelocityInterfaceCompositeInterface velocityInterfaceCompositeInterface = ((VelocityInterfaceCompositeInterface) this.getOwnerLayerInterface());
        BasicVelocityProperties velocityProperties = velocityInterfaceCompositeInterface.getVelocityProperties();
        this.xTotalDistance += velocityProperties.getVelocityXBasicDecimalP().getScaled();
    }

    private void changeDirectionIfReachedPacingAreaMax()
    {
        MathUtil mathUtil = MathUtil.getInstance();
        int totalDistance = mathUtil.abs(this.xTotalDistance);
        if (totalDistance > this.currentDistance) {
            this.nextDirection();
        }
    }

    protected virtual void nextDirection()
    {
        if (this.lastKeyDirection == Canvas.LEFT) {
            this.keyDirection = Canvas.RIGHT;
            this.lastKeyDirection = this.keyDirection;
            this.xTotalDistance = 0;
        } else if (this.lastKeyDirection == Canvas.RIGHT) {
            this.keyDirection = Canvas.LEFT;
            this.lastKeyDirection = this.keyDirection;
            this.xTotalDistance = 0;
        }
    }

    public virtual void disable()
    {
    }

}

