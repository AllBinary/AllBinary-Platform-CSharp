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

public class DamageableBaseBehavior : DamageableInterface
{
    private static readonly DamageableBaseBehavior instance = new DamageableBaseBehavior();
    public static DamageableBaseBehavior getInstance()
    {
        return DamageableBaseBehavior.instance;
    }

    public virtual string getName()
    {
        return this.GetType().FullName;
    }

    // throws Exception
    public virtual void damage(int damage, int damageType)
    {
    }

    // throws Exception
    public virtual int getDamage(int damageType)
    {
        return 6000;
    }

}

