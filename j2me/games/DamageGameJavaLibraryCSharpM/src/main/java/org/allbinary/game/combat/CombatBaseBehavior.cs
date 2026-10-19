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
using DamageableBaseBehavior = org.allbinary.game.combat.damage.DamageableBaseBehavior;
using DestroyableBaseBehavior = org.allbinary.game.combat.destroy.DestroyableBaseBehavior;

namespace org.allbinary.game.combat;

public class CombatBaseBehavior
{
    public static readonly CombatBaseBehavior NULL_COMBAT_BEHAVIOR = new CombatBaseBehavior(DamageableBaseBehavior.getInstance(), DestroyableBaseBehavior.getInstance());
    private readonly DamageableBaseBehavior damageableBaseBehavior;
    private readonly DestroyableBaseBehavior destroyableBaseBehavior;
    private bool readyForExplosion = false;
    public CombatBaseBehavior(DamageableBaseBehavior damageableBaseBehavior, DestroyableBaseBehavior destroyableBaseBehavior)
    {
        this.damageableBaseBehavior = damageableBaseBehavior;
        this.destroyableBaseBehavior = destroyableBaseBehavior;
    }

    public virtual DamageableBaseBehavior getDamageableBaseBehavior()
    {
        return this.damageableBaseBehavior;
    }

    public virtual DestroyableBaseBehavior getDestroyableBaseBehavior()
    {
        return this.destroyableBaseBehavior;
    }

    public bool isReadyForExplosion()
    {
        return this.readyForExplosion;
    }

    public void setReadyForExplosion(bool readyForExplosion)
    {
        this.readyForExplosion = readyForExplosion;
    }

}

