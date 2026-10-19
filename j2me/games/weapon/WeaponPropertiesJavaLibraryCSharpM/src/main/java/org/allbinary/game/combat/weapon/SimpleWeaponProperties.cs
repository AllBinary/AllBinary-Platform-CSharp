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

namespace org.allbinary.game.combat.weapon;

public class SimpleWeaponProperties
{
    private int damage = 0;
    private short dissipation = 0;
    private int range = 0;
    public virtual void set(SimpleWeaponProperties simpleWeaponProperties)
    {
        this.setDamage(simpleWeaponProperties.getDamage());
        this.setDissipation(simpleWeaponProperties.getDissipation());
        this.setRange(simpleWeaponProperties.getRange());
    }

    public virtual void setDamage(int damage)
    {
        this.damage = damage;
    }

    public virtual int getDamage()
    {
        return this.damage;
    }

    public virtual void setDissipation(short dissipation)
    {
        this.dissipation = dissipation;
    }

    public virtual short getDissipation()
    {
        return this.dissipation;
    }

    public virtual int getRange()
    {
        return this.range;
    }

    public virtual void setRange(int range)
    {
        this.range = range;
    }

}

