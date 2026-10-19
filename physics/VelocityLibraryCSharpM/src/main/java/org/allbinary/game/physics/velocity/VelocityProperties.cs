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

namespace org.allbinary.game.physics.velocity;

public class VelocityProperties : BasicVelocityProperties, VelocityInterface
{
    public static readonly VelocityProperties NULL_VELOCITY_PROPERTIES = new VelocityProperties(0, 0);
    private int maxForwardVelocity = 0;
    private int maxReverseVelocity = 0;
    public VelocityProperties(int maxForwardVelocity, int maxReverseVelocity)
    {
        this.setMaxForwardVelocity(maxForwardVelocity);
        this.setMaxReverseVelocity(maxReverseVelocity);
    }

    public override int getMaxForwardVelocity()
    {
        return this.maxForwardVelocity;
    }

    public override void setMaxForwardVelocity(int maxForwardVelocity)
    {
        this.maxForwardVelocity = maxForwardVelocity;
    }

    public override int getMaxReverseVelocity()
    {
        return this.maxReverseVelocity;
    }

    public override void setMaxReverseVelocity(int maxReverseVelocity)
    {
        this.maxReverseVelocity = maxReverseVelocity;
    }

    public override void limitMaxXYForwardVelocity()
    {
        this.limitMaxXYVelocity(this.getMaxForwardVelocity());
    }

    public override void limitMaxXYReverseVelocity()
    {
        this.limitMaxXYVelocity(this.getMaxReverseVelocity());
    }

    public virtual void limitMaxYForwardVelocity()
    {
        this.limitMaxYVelocity(this.getMaxForwardVelocity());
    }

    public virtual void limitMaxYReverseVelocity()
    {
        this.limitMaxYVelocity(this.getMaxReverseVelocity());
    }

    public virtual void limitMaxXForwardVelocity()
    {
        this.limitMaxXVelocity(this.getMaxForwardVelocity());
    }

    public virtual void limitMaxXReverseVelocity()
    {
        this.limitMaxXVelocity(this.getMaxReverseVelocity());
    }

    public virtual bool isOverXYMaxForwardVelocity()
    {
        return this.isOverXYMaxVelocity(this.getMaxForwardVelocity());
    }

    public virtual bool isOverXYMaxReverseVelocity()
    {
        return this.isOverXYMaxVelocity(this.getMaxReverseVelocity());
    }

    public override void limitXYToForwardAndReverseMaxVelocity()
    {
        this.limitMaxXYForwardVelocity();
        this.limitMaxXYReverseVelocity();
    }

    public override void limitMaxXYVelocity(int maxVelocity)
    {
        this.limitMaxXVelocity(maxVelocity);
        this.limitMaxYVelocity(maxVelocity);
    }

    public virtual void limitMaxPositiveYVelocity(int maxVelocity)
    {
        if (this.velocityYBasicDecimal.getUnscaled() > maxVelocity) {
            this.velocityYBasicDecimal.setint(maxVelocity);
        }
    }

    public virtual void limitMaxNegativeYVelocity(int maxVelocity)
    {
        if (this.velocityYBasicDecimal.getUnscaled() < -maxVelocity) {
            this.velocityYBasicDecimal.setint(-maxVelocity);
        }
    }

    public virtual void limitMaxYVelocity(int maxVelocity)
    {
        this.limitMaxPositiveYVelocity(maxVelocity);
        this.limitMaxNegativeYVelocity(maxVelocity);
    }

    public virtual void limitMaxXVelocity(int maxVelocity)
    {
        if (this.velocityXBasicDecimal.getUnscaled() > maxVelocity) {
            this.velocityXBasicDecimal.setint(maxVelocity);
        }
        if (this.velocityXBasicDecimal.getUnscaled() < -maxVelocity) {
            this.velocityXBasicDecimal.setint(-maxVelocity);
        }
    }

    public virtual bool isOverXYMaxVelocity(int maxVelocity)
    {
        if (this.velocityXBasicDecimal.getUnscaled() > maxVelocity) {
            return true;
        }
        if (this.velocityXBasicDecimal.getUnscaled() < -maxVelocity) {
            return true;
        }
        if (this.velocityYBasicDecimal.getUnscaled() > maxVelocity) {
            return true;
        }
        if (this.velocityYBasicDecimal.getUnscaled() < -maxVelocity) {
            return true;
        }
        return false;
    }

    public override void setVelocityi(long magnitude, int angle, int otherAngle)
    {
        base.setVelocityi(magnitude, angle, otherAngle);
        this.limitXYToForwardAndReverseMaxVelocity();
    }

    public override void addVelocityi(long magnitude, int angle, int otherAngle)
    {
        base.addVelocityi(magnitude, angle, otherAngle);
        this.limitXYToForwardAndReverseMaxVelocity();
    }

}

