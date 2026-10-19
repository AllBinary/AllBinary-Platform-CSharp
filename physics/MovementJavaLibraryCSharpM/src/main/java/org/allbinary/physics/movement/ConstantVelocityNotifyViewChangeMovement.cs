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
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;
using BasicDecimal = org.allbinary.logic.math.BasicDecimal;
using AxisMathVectorUtil = org.allbinary.logic.math.vector.AxisMathVectorUtil;
using AngleFactory = org.allbinary.math.AngleFactory;

namespace org.allbinary.physics.movement;

public class ConstantVelocityNotifyViewChangeMovement : Movement
{
    public BasicVelocityProperties basicVelocityProperties;
    private BasicDecimal speedBasicDecimal;
    private readonly AxisMathVectorUtil axisMathVectorUtil = AxisMathVectorUtil.getInstance();
    public ConstantVelocityNotifyViewChangeMovement()
    {
        this.speedBasicDecimal = BasicDecimal.ZERO_BIGDECIMAL;
        this.basicVelocityProperties = new BasicVelocityProperties();
    }

    public override void init(BasicDecimal speedBasicDecimal, int angle, int otherAngle)
    {
        this.speedBasicDecimal = speedBasicDecimal;
        AngleFactory angleFactory = AngleFactory.getInstance();
        this.basicVelocityProperties.setVelocityWithBigDecimal(speedBasicDecimal, angleFactory.getAt(angle), angleFactory.getAt(otherAngle));
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
        int x = this.basicVelocityProperties.getVelocityXBasicDecimalP().getScaled();
        int y = this.basicVelocityProperties.getVelocityYBasicDecimalP().getScaled();
        int z = this.basicVelocityProperties.getVelocityZBasicDecimalP().getScaled();
        layer.moveDXYZ(x, y, z);
        if (x != 0 || y != 0 || z != 0) {
            layer.onViewPositionChangeEvent();
        }
    }

    public override void stop()
    {
        this.basicVelocityProperties.zero();
    }

}

