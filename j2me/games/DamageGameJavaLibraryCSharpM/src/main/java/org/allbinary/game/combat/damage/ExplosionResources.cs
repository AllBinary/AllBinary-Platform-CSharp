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

namespace org.allbinary.game.combat.damage;

public class ExplosionResources
{
    private static readonly ExplosionResources instance = new ExplosionResources();
    public static ExplosionResources getInstance()
    {
        return ExplosionResources.instance;
    }

    private ExplosionResources()
    {
    }

    public readonly string EXPLOSION_90_RESOURCE = "/explosion_sprite_90_by_90.png";
    public readonly string EXPLOSION_60_RESOURCE = "/explosion_sprite_60_by_60.png";
    public readonly string HALF_EXPLOSION_RESOURCE = "/explosion_sprite_30_by_30.png";
    public readonly string THIRD_EXPLOSION_RESOURCE = "/explosion_sprite_15_by_15.png";
}

