/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2006 AllBinary 
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

namespace org.allbinary.game.rts.technology;

public class UnitTechnologySingletonFactory
{
    private static readonly UnitTechnologySingletonFactory instance = new UnitTechnologySingletonFactory();
    public static UnitTechnologySingletonFactory getInstance()
    {
        return UnitTechnologySingletonFactory.instance;
    }

    private int damage = 0;
    private int health = 0;
    private int reload = 0;
    private int repair = 0;
    private int speed = 0;
    private UnitTechnologySingletonFactory()
    {
    }

    public virtual void init()
    {
        this.setDamage(0);
        this.setHealth(0);
        this.setReload(0);
        this.setRepair(0);
        this.setSpeed(0);
    }

    public virtual int getDamage()
    {
        return this.damage;
    }

    public virtual void setDamage(int damage)
    {
        this.damage = damage;
    }

    public virtual int getHealth()
    {
        return this.health;
    }

    public virtual void setHealth(int health)
    {
        this.health = health;
    }

    public virtual int getReload()
    {
        return this.reload;
    }

    public virtual void setReload(int reload)
    {
        this.reload = reload;
    }

    public virtual int getRepair()
    {
        return this.repair;
    }

    public virtual void setRepair(int repair)
    {
        this.repair = repair;
    }

    public virtual int getSpeed()
    {
        return this.speed;
    }

    public virtual void setSpeed(int speed)
    {
        this.speed = speed;
    }

}

