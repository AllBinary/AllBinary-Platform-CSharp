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

namespace org.allbinary.game.collision;

public class CollidableAlwaysPickupNeverCollideBehaviorFactory : CollidableBaseBehaviorFactory
{
    private static readonly CollidableAlwaysPickupNeverCollideBehaviorFactory instanceC = new CollidableAlwaysPickupNeverCollideBehaviorFactory();
    public static CollidableAlwaysPickupNeverCollideBehaviorFactory getInstance()
    {
        return CollidableAlwaysPickupNeverCollideBehaviorFactory.instanceC;
    }

    private readonly CollidableAlwaysPickupNeverCollideBehavior instance = new CollidableAlwaysPickupNeverCollideBehavior();
    public override CollidableBaseBehavior createBehavior()
    {
        return this.instance;
    }

}

