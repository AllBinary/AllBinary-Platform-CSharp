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
using GravityUtil = org.allbinary.game.physics.acceleration.GravityUtil;
using VelocityProperties = org.allbinary.game.physics.velocity.VelocityProperties;
using BasicDecimal = org.allbinary.logic.math.BasicDecimal;

namespace org.allbinary.physics.movement;

public class SimpleGravityVelocityMovement : BasicConstantVelocityMovement
{
    public SimpleGravityVelocityMovement(BasicDecimal speedBasicDecimal) : base(speedBasicDecimal, new VelocityProperties(((int) speedBasicDecimal.getUnscaled()), ((int) speedBasicDecimal.getUnscaled())))
    {
        // base(speedBasicDecimal, new VelocityProperties(((int) speedBasicDecimal.getUnscaled()), ((int) speedBasicDecimal.getUnscaled()))) is called from the constructor declaration
    }

    private readonly GravityUtil gravityUtil = GravityUtil.getInstance();
    // throws Exception
    public override void process(AllBinaryGameLayer layer)
    {
        this.gravityUtil.process(this.getVelocityProperties(), this.gravityUtil.GAME_GRAVITY_VELOCITY);
        base.process(layer);
    }

}

