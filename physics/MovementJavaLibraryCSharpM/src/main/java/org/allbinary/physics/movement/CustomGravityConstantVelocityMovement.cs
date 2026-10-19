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

public class CustomGravityConstantVelocityMovement : BasicConstantVelocityMovement
{
    private int customGravity;
    public CustomGravityConstantVelocityMovement(BasicDecimal speedBasicDecimal, int customGravity) : base(speedBasicDecimal, new VelocityProperties(((int) speedBasicDecimal.getUnscaled()), ((int) speedBasicDecimal.getUnscaled())))
    {
        // base(speedBasicDecimal, new VelocityProperties(((int) speedBasicDecimal.getUnscaled()), ((int) speedBasicDecimal.getUnscaled()))) is called from the constructor declaration
        this.customGravity = customGravity;
    }

    private readonly GravityUtil gravityUtil = GravityUtil.getInstance();
    // throws Exception
    public override void process(AllBinaryGameLayer layer)
    {
        base.process(layer);
        this.gravityUtil.process(this.getVelocityProperties(), this.customGravity);
        VelocityProperties velocityProperties = ((VelocityProperties) this.getVelocityProperties());
        velocityProperties.limitMaxYForwardVelocity();
    }

}

