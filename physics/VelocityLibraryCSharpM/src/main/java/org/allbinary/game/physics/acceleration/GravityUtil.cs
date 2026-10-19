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
using BasicVelocityProperties = org.allbinary.game.physics.velocity.BasicVelocityProperties;

namespace org.allbinary.game.physics.acceleration;

public class GravityUtil
{
    private static readonly GravityUtil instance = new GravityUtil();
    public static GravityUtil getInstance()
    {
        return GravityUtil.instance;
    }

    public readonly int GAME_GRAVITY_VELOCITY = 1800;
    public readonly int MAX_GAME_VELOCITY = 18000;
    public void process(BasicVelocityProperties velocityProperties, int customGravity)
    {
        velocityProperties.getVelocityYBasicDecimalP().addint(customGravity);
    }

}

