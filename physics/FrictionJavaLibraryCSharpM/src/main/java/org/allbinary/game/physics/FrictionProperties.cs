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
using FrictionData = org.allbinary.game.physics.friction.FrictionData;
using DragVelocityBehavior = org.allbinary.game.physics.velocity.DragVelocityBehavior;
using VelocityProperties = org.allbinary.game.physics.velocity.VelocityProperties;

namespace org.allbinary.game.physics;

public class FrictionProperties
{
    public FrictionProperties()
    {
    }

    public virtual void friction(VelocityProperties velocityProperties, int nominator)
    {
        DragVelocityBehavior.instance.reduce(velocityProperties, nominator, FrictionData.getFrictionDenominator());
    }

}

