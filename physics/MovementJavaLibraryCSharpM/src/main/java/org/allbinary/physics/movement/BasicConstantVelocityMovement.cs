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
using VelocityInterfaceCompositeInterface = org.allbinary.game.physics.velocity.VelocityInterfaceCompositeInterface;
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;
using BasicDecimal = org.allbinary.logic.math.BasicDecimal;
using AxisMathVectorUtil = org.allbinary.logic.math.vector.AxisMathVectorUtil;
using AngleFactory = org.allbinary.math.AngleFactory;

namespace org.allbinary.physics.movement;

public class BasicConstantVelocityMovement : Movement, VelocityInterfaceCompositeInterface
{
    private BasicVelocityProperties velocityProperties;
    private BasicDecimal speedBasicDecimal = BasicDecimal.ZERO_BIGDECIMAL;
    private readonly AxisMathVectorUtil axisMathVectorUtil = AxisMathVectorUtil.getInstance();
    public BasicConstantVelocityMovement(BasicDecimal basicDecimal, BasicVelocityProperties velocityProperties)
    {
        this.setSpeedBasicDecimal(basicDecimal);
        this.velocityProperties = velocityProperties;
    }

    public override void init(BasicDecimal speedBasicDecimal, int angle, int otherAngle)
    {
        this.speedBasicDecimal = speedBasicDecimal;
        AngleFactory angleFactory = AngleFactory.getInstance();
        this.velocityProperties.setVelocityWithBigDecimal(speedBasicDecimal, angleFactory.getAt(angle), angleFactory.getAt(otherAngle));
    }

    public virtual void moveOutsideRadius(AllBinaryLayer layer, long radius, int angle, int otherAngle)
    {
        int scaleFactorValue = this.speedBasicDecimal.getScaledFactorValue();
        int xVector = ((int) (this.axisMathVectorUtil.calculateX(radius, angle) / scaleFactorValue));
        int yVector = ((int) (this.axisMathVectorUtil.calculateY(radius, angle) / scaleFactorValue));
        int zVector = ((int) (this.axisMathVectorUtil.calculateZ(radius, otherAngle) / scaleFactorValue));
        layer.moveDXYZ(xVector, yVector, zVector);
    }

    // throws Exception
    public override void process(AllBinaryGameLayer layer)
    {
        layer.moveDXYZ(this.velocityProperties.getVelocityXBasicDecimalP().getScaled(), this.velocityProperties.getVelocityYBasicDecimalP().getScaled(), this.velocityProperties.getVelocityZBasicDecimalP().getScaled());
    }

    public override string ToString()
    {
        return this.velocityProperties.ToString();
    }

    public override void stop()
    {
        this.velocityProperties.zero();
    }

    public override BasicVelocityProperties getVelocityProperties()
    {
        return this.velocityProperties;
    }

    public virtual void setVelocityProperties(BasicVelocityProperties velocityProperties)
    {
        this.velocityProperties = velocityProperties;
    }

    protected virtual void setSpeedBasicDecimal(BasicDecimal speedBasicDecimal)
    {
        this.speedBasicDecimal = speedBasicDecimal;
    }

    protected virtual BasicDecimal getSpeedBasicDecimal()
    {
        return this.speedBasicDecimal;
    }

}

