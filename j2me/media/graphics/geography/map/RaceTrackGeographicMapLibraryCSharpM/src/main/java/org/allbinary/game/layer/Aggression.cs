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
using SmallIntegerSingletonFactory = org.allbinary.logic.math.SmallIntegerSingletonFactory;

namespace org.allbinary.game.layer;

public class Aggression
{
    private int? ram = SmallIntegerSingletonFactory.getInstance().getAt(0);
    private int? projectile = SmallIntegerSingletonFactory.getInstance().getAt(0);
    private int? drops = SmallIntegerSingletonFactory.getInstance().getAt(0);
    public Aggression(int? ram, int? projectile, int? drops)
    {
        this.setRam(ram);
        this.setProjectile(projectile);
        this.setDrops(drops);
    }

    public virtual int? getRam()
    {
        return this.ram;
    }

    public virtual void setRam(int? ram)
    {
        this.ram = ram;
    }

    public virtual int? getProjectile()
    {
        return this.projectile;
    }

    public virtual void setProjectile(int? projectile)
    {
        this.projectile = projectile;
    }

    public virtual int? getDrops()
    {
        return this.drops;
    }

    public virtual void setDrops(int? drops)
    {
        this.drops = drops;
    }

}

