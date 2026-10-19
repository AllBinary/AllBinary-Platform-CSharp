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

namespace org.allbinary.game.ag.layer.pickup.health;

public class HealthResources
{
    private static readonly HealthResources SINGLETON = new HealthResources();
    public string RESOURCE = "health_drop_20_by_20.png";
    private HealthResources()
    {
    }

    public static HealthResources getInstance()
    {
        return HealthResources.SINGLETON;
    }

}

