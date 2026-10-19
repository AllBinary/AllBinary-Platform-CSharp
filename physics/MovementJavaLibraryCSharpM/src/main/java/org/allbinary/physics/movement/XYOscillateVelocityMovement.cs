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
using VelocityProperties = org.allbinary.game.physics.velocity.VelocityProperties;
using BasicDecimal = org.allbinary.logic.math.BasicDecimal;

namespace org.allbinary.physics.movement;

public class XYOscillateVelocityMovement : BasicConstantVelocityMovement
{
    private int oscillateMin;
    private int oscillateMax;
    private int oscillate = 0;
    private bool oscillatePositive = false;
    public XYOscillateVelocityMovement(BasicDecimal speedBasicDecimal, int oscillateMin, int oscillateMax) : base(speedBasicDecimal, new VelocityProperties(((int) speedBasicDecimal.getUnscaled()), ((int) speedBasicDecimal.getUnscaled())))
    {
        // base(speedBasicDecimal, new VelocityProperties(((int) speedBasicDecimal.getUnscaled()), ((int) speedBasicDecimal.getUnscaled()))) is called from the constructor declaration
        this.oscillateMin = oscillateMin;
        this.oscillateMax = oscillateMax;
    }

    // throws Exception
    public override void process(AllBinaryGameLayer layer)
    {
        base.process(layer);
        if (this.oscillate < this.oscillateMin) {
            this.oscillatePositive = true;
            this.getVelocityProperties().getVelocityYBasicDecimalP().addint(3000);
        } else if (this.oscillate > this.oscillateMax) {
            this.oscillatePositive = false;
            this.getVelocityProperties().getVelocityYBasicDecimalP().subtractint(3000);
        }
        if (this.oscillatePositive) {
            this.oscillate++;
            this.getVelocityProperties().getVelocityXBasicDecimalP().addint(5000);
        } else {
            this.oscillate--;
            this.getVelocityProperties().getVelocityXBasicDecimalP().subtractint(5000);
        }
    }

}

