// Generated Code Do Not Modify

using System;
using System.Linq;
using AllBinaryGameLayer = org.allbinary.game.layer.AllBinaryGameLayer;
using BasicVelocityProperties = org.allbinary.game.physics.velocity.BasicVelocityProperties;
using BasicDecimal = org.allbinary.logic.math.BasicDecimal;
using MathUtil = org.allbinary.logic.math.MathUtil;
using ScaleFactorFactory = org.allbinary.logic.math.ScaleFactorFactory;

namespace org.allbinary.physics.movement;

public class PreciseConstantVelocityMovement : BasicConstantVelocityMovement
{
    private int accumulatedX = 0;
    private int accumulatedY = 0;
    private int accumulatedZ = 0;
    public PreciseConstantVelocityMovement(BasicDecimal basicDecimal, BasicVelocityProperties velocityProperties) : base(basicDecimal, velocityProperties)
    {
        // base(basicDecimal, velocityProperties) is called from the constructor declaration
    }

    public override void init(BasicDecimal speedBasicDecimal, int angle, int otherAngle)
    {
    }

    private readonly int factorValue = ScaleFactorFactory.getInstance().DEFAULT_SCALE_VALUE;
    // throws Exception
    public override void process(AllBinaryGameLayer layer)
    {
        MathUtil mathUtil = MathUtil.getInstance();
        BasicVelocityProperties velocityProperties = this.getVelocityProperties();
        this.accumulatedX = ((int) (this.accumulatedX + velocityProperties.getVelocityXBasicDecimalP().getUnscaled()));
        this.accumulatedY = ((int) (this.accumulatedY + velocityProperties.getVelocityYBasicDecimalP().getUnscaled()));
        this.accumulatedZ = ((int) (this.accumulatedZ + velocityProperties.getVelocityZBasicDecimalP().getUnscaled()));
        layer.moveDXYZ(this.accumulatedX / this.factorValue, this.accumulatedY / this.factorValue, this.accumulatedZ / this.factorValue);
        if (mathUtil.abs(this.accumulatedX) > this.factorValue) {
            this.accumulatedX = 0;
        }
        if (mathUtil.abs(this.accumulatedY) > this.factorValue) {
            this.accumulatedY = 0;
        }
        if (mathUtil.abs(this.accumulatedZ) > this.factorValue) {
            this.accumulatedZ = 0;
        }
    }

}

