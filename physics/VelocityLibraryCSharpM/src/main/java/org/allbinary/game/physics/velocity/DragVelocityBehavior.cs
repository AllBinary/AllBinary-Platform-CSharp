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
using BasicDecimal = org.allbinary.logic.math.BasicDecimal;

namespace org.allbinary.game.physics.velocity;

public class DragVelocityBehavior : VelocityBehaviorBase
{
    public static readonly DragVelocityBehavior instance = new DragVelocityBehavior();
    public override void reduce(BasicVelocityProperties velocityProperties, int nominator, int denominator)
    {
        if (velocityProperties.getVelocityXBasicDecimalP().getUnscaled() != 0L) {
            BasicDecimal basicDecimal = velocityProperties.getVelocityXBasicDecimalP();
            basicDecimal.multiplyint(nominator);
            basicDecimal.divideint(denominator);
        }
        if (velocityProperties.getVelocityYBasicDecimalP().getUnscaled() != 0L) {
            BasicDecimal basicDecimal = velocityProperties.getVelocityYBasicDecimalP();
            basicDecimal.multiplyint(nominator);
            basicDecimal.divideint(denominator);
        }
    }

    public override void reduceX(BasicVelocityProperties velocityProperties, int nominator, int denominator)
    {
        BasicDecimal basicDecimal = velocityProperties.getVelocityXBasicDecimalP();
        if (basicDecimal.getUnscaled() != 0L) {
            basicDecimal.multiplyint(nominator);
            basicDecimal.divideint(denominator);
        }
    }

    public override void reduceY(BasicVelocityProperties velocityProperties, int nominator, int denominator)
    {
        if (velocityProperties.getVelocityYBasicDecimalP().getUnscaled() != 0L) {
            BasicDecimal basicDecimal = velocityProperties.getVelocityYBasicDecimalP();
            basicDecimal.multiplyint(nominator);
            basicDecimal.divideint(denominator);
        }
    }

}

