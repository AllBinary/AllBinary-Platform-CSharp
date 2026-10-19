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
using CollidableCompositeLayer = org.allbinary.game.layer.CollidableCompositeLayer;
using CollidableDestroyableDamageableLayer = org.allbinary.game.layer.special.CollidableDestroyableDamageableLayer;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;

namespace org.allbinary.game.combat.damage;

public class DamageUtil
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly DamageUtil instance = new DamageUtil();
    public static DamageUtil getInstance()
    {
        return DamageUtil.instance;
    }

    public readonly string COLLIDE = "collide";
    private DamageUtil()
    {
    }

    // throws Exception
    public virtual void process(DamageableInterface damageableInterface, DamageableInterface damageableInterface2)
    {
        damageableInterface.damage(damageableInterface2.getDamage(0), 0);
    }

    // throws Exception
    public virtual void debugDamage(CollidableCompositeLayer collidableInterfaceCompositeInterface1, CollidableCompositeLayer collidableInterfaceCompositeInterface)
    {
        CollidableDestroyableDamageableLayer collidableDestroyableDamageableLayer = ((CollidableDestroyableDamageableLayer) collidableInterfaceCompositeInterface);
        int damage = collidableDestroyableDamageableLayer.getDamage(0);
        if (damage > 20000) {
            StringMaker stringBuffer = new StringMaker();
            stringBuffer.append("Collision ");
            stringBuffer.append(collidableInterfaceCompositeInterface1.ToString());
            stringBuffer.append(" with: ");
            stringBuffer.append(collidableInterfaceCompositeInterface.ToString());
            stringBuffer.append(" damage: ");
            stringBuffer.appendint(damage);
            this.logUtil.putF(stringBuffer.ToString(), collidableInterfaceCompositeInterface1, this.COLLIDE);
        }
    }

}

