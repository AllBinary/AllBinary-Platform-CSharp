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
using AllBinaryGameLayer = org.allbinary.game.layer.AllBinaryGameLayer;
using BasicVelocityProperties = org.allbinary.game.physics.velocity.BasicVelocityProperties;
using BasicDecimal = org.allbinary.logic.math.BasicDecimal;
using GameTickTimeDelayHelperFactory = org.allbinary.time.GameTickTimeDelayHelperFactory;
using TimeDelayHelper = org.allbinary.time.TimeDelayHelper;

namespace org.allbinary.physics.movement;

public class DelayedConstantVelocityMovement : BasicConstantVelocityMovement
{
    private readonly TimeDelayHelper timeDelayHelper = new TimeDelayHelper(60);
    public DelayedConstantVelocityMovement(BasicDecimal basicDecimal, BasicVelocityProperties velocityProperties) : base(basicDecimal, velocityProperties)
    {
        // base(basicDecimal, velocityProperties) is called from the constructor declaration
    }

    public override void init(BasicDecimal speedBasicDecimal, int angle, int otherAngle)
    {
    }

    // throws Exception
    public override void process(AllBinaryGameLayer layer)
    {
        if (this.timeDelayHelper.isTime(GameTickTimeDelayHelperFactory.getInstance().startTime)) {
            base.process(layer);
        }
    }

}

