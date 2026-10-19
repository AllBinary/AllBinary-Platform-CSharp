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
using Direction = org.allbinary.direction.Direction;
using DirectionUtil = org.allbinary.direction.DirectionUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using BasicDecimal = org.allbinary.logic.math.BasicDecimal;
using AxisMathVectorUtil = org.allbinary.logic.math.vector.AxisMathVectorUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using Angle = org.allbinary.math.Angle;
using PositionStrings = org.allbinary.math.PositionStrings;
using CommonSeps = org.allbinary.@string.CommonSeps;

namespace org.allbinary.game.physics.velocity;

public class BasicVelocityProperties : BasicVelocityInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly BasicDecimal velocityXBasicDecimal;
    public readonly BasicDecimal velocityYBasicDecimal;
    public readonly BasicDecimal velocityZBasicDecimal;
    private readonly AxisMathVectorUtil axisMathVectorUtil = AxisMathVectorUtil.getInstance();
    public BasicVelocityProperties()
    {
        this.velocityXBasicDecimal = new BasicDecimal(0);
        this.velocityYBasicDecimal = new BasicDecimal(0);
        this.velocityZBasicDecimal = new BasicDecimal(0);
    }

    public virtual void zero()
    {
        this.velocityXBasicDecimal.setint(0);
        this.velocityYBasicDecimal.setint(0);
        this.velocityZBasicDecimal.setint(0);
    }

    public virtual BasicDecimal getVelocityXBasicDecimalP()
    {
        return this.velocityXBasicDecimal;
    }

    public virtual BasicDecimal getVelocityYBasicDecimalP()
    {
        return this.velocityYBasicDecimal;
    }

    public virtual BasicDecimal getVelocityZBasicDecimalP()
    {
        return this.velocityZBasicDecimal;
    }

    public readonly DirectionUtil directionUtil = DirectionUtil.getInstance();
    public virtual void setVelocityWithBigDecimalAndDirection(BasicDecimal magnitudeBasicDecimal, Direction direction, Direction otherDirection)
    {
        Angle angle = this.directionUtil.getAngle(direction);
        Angle otherAngle = this.directionUtil.getAngle(otherDirection);
        this.setVelocityWithBigDecimal(magnitudeBasicDecimal, angle, otherAngle);
    }

    public virtual void setVelocityWithDirection(long magnitude, Direction direction, Direction otherDirection)
    {
        Angle angle = this.directionUtil.getAngle(direction);
        Angle otherAngle = this.directionUtil.getAngle(otherDirection);
        this.setVelocity(magnitude, angle, otherAngle);
    }

    public virtual void addVelocityWithBigDecimalAndDirection(BasicDecimal magnitudeBasicDecimal, Direction direction, Direction otherDirection)
    {
        Angle angle = this.directionUtil.getAngle(direction);
        Angle otherAngle = this.directionUtil.getAngle(otherDirection);
        this.addVelocityWithBigDecimal(magnitudeBasicDecimal, angle, otherAngle);
    }

    public virtual void addVelocityWithDirection(long magnitude, Direction direction, Direction otherDirection)
    {
        Angle angle = this.directionUtil.getAngle(direction);
        Angle otherAngle = this.directionUtil.getAngle(otherDirection);
        this.addVelocity(magnitude, angle, otherAngle);
    }

    public virtual void setVelocityWithBigDecimal(BasicDecimal magnitudeBasicDecimal, Angle angle, Angle otherAngle)
    {
        long magnitude = magnitudeBasicDecimal.getUnscaled();
        this.setVelocity(magnitude, angle, otherAngle);
    }

    public virtual void addVelocityWithBigDecimal(BasicDecimal magnitudeBasicDecimal, Angle angle, Angle otherAngle)
    {
        long magnitude = magnitudeBasicDecimal.getUnscaled();
        this.addVelocity(magnitude, angle, otherAngle);
    }

    public virtual void setVelocity(long magnitude, Angle angle, Angle otherAngle)
    {
        this.setVelocityi(magnitude, ((int) angle.getValue()), ((int) otherAngle.getValue()));
    }

    public virtual void addVelocity(long magnitude, Angle angle, Angle otherAngle)
    {
        this.addVelocityi(magnitude, ((int) angle.getValue()), ((int) otherAngle.getValue()));
    }

    public virtual void setVelocityi(long magnitude, int angle, int otherAngle)
    {
        long xVector = (this.axisMathVectorUtil.calculateX(magnitude, angle) / this.velocityXBasicDecimal.getScaledFactorValue());
        long yVector = (this.axisMathVectorUtil.calculateY(magnitude, angle) / this.velocityYBasicDecimal.getScaledFactorValue());
        long zVector = (this.axisMathVectorUtil.calculateZ(magnitude, otherAngle) / this.velocityZBasicDecimal.getScaledFactorValue());
        this.velocityXBasicDecimal.setlong(xVector);
        this.velocityYBasicDecimal.setlong(yVector);
        this.velocityZBasicDecimal.setlong(zVector);
    }

    public virtual void addVelocityi(long magnitude, int angle, int otherAngle)
    {
        long xVector = (this.axisMathVectorUtil.calculateX(magnitude, angle) / this.velocityXBasicDecimal.getScaledFactorValue());
        long yVector = (this.axisMathVectorUtil.calculateY(magnitude, angle) / this.velocityYBasicDecimal.getScaledFactorValue());
        long zVector = (this.axisMathVectorUtil.calculateZ(magnitude, otherAngle) / this.velocityZBasicDecimal.getScaledFactorValue());
        this.velocityXBasicDecimal.addlong(xVector);
        this.velocityYBasicDecimal.addlong(yVector);
        this.velocityZBasicDecimal.addlong(zVector);
    }

    public override string ToString()
    {
        CommonSeps commonSeps = CommonSeps.getInstance();
        PositionStrings positionStrings = PositionStrings.getInstance();
        StringMaker stringBuffer = new StringMaker();
        StringUtil stringUtil = StringUtil.getInstance();
        stringBuffer.append("Velocity ");
        stringBuffer.append(positionStrings.X_LABEL);
        stringBuffer.append(stringUtil.toString(this.velocityXBasicDecimal));
        stringBuffer.append(commonSeps.SPACE);
        stringBuffer.append(positionStrings.Y_LABEL);
        stringBuffer.append(stringUtil.toString(this.velocityYBasicDecimal));
        stringBuffer.append(commonSeps.SPACE);
        stringBuffer.append(positionStrings.Z_LABEL);
        stringBuffer.append(stringUtil.toString(this.velocityZBasicDecimal));
        return stringBuffer.ToString();
    }

}

