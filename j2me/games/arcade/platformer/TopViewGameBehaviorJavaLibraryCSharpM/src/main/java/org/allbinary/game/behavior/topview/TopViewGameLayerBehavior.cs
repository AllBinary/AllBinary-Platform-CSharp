/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2022 AllBinary 
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
using GameLayerBehavior = org.allbinary.game.layer.behavior.GameLayerBehavior;
using BasicAccelerationProperties = org.allbinary.game.physics.acceleration.BasicAccelerationProperties;
using VelocityProperties = org.allbinary.game.physics.velocity.VelocityProperties;

namespace org.allbinary.game.behavior.topview;

public class TopViewGameLayerBehavior : GameLayerBehavior
{
    public readonly int maxGravityActionIndex;
    public bool isJumpAction = true;
    public bool isJumpOver = false;
    public bool isFallingWithoutJumpAttempt = false;
    public int gravityActionIndex = 0;
    public TopViewGameLayerBehavior(int maxGravityActionIndex)
    {
        this.maxGravityActionIndex = maxGravityActionIndex;
    }

    public virtual void gravity()
    {
        if (this.gravityActionIndex == 0) {
            this.gravityActionIndex++;
            this.isFallingWithoutJumpAttempt = true;
        }
    }

    public virtual void land(VelocityProperties velocityProperties)
    {
        velocityProperties.getVelocityYBasicDecimalP().setint(0);
        this.landReset();
    }

    public virtual void landReset()
    {
        this.gravityActionIndex = 0;
        this.isFallingWithoutJumpAttempt = false;
        this.isJumpAction = true;
        this.isJumpOver = false;
    }

    public virtual void up(VelocityProperties velocityProperties, BasicAccelerationProperties acceleration, InitialJumpBehavior jumpBehavior, int accelerationMultiplier)
    {
        if (!this.isJumpOver) {
            if (this.gravityActionIndex < this.maxGravityActionIndex) {
                int acceleration2 = -acceleration.getForward() * accelerationMultiplier;
                velocityProperties.getVelocityYBasicDecimalP().addint(acceleration2);
                velocityProperties.limitXYToForwardAndReverseMaxVelocity();
                this.gravityActionIndex++;
            } else {
            }
        } else {
        }
        if (this.isJumpAction) {
            jumpBehavior.process();
            this.isJumpAction = false;
        }
    }

    public virtual void inputFrames(VelocityProperties velocityProperties)
    {
        if (this.gravityActionIndex > 0 && velocityProperties.getVelocityYBasicDecimalP().getUnscaled() > 0) {
            this.isJumpOver = true;
        }
    }

}

