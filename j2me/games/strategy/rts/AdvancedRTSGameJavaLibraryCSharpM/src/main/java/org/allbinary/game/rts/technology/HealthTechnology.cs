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
using RTSInterface = org.allbinary.game.layer.RTSInterface;

namespace org.allbinary.game.rts.technology;

public class HealthTechnology : RTSInterface
{
    private int level = 0;
    private int maxLevel;
    public HealthTechnology(int maxLevel)
    {
        this.maxLevel = maxLevel;
    }

    public virtual bool isCompleted()
    {
        return false;
    }

    public virtual int getPercentComplete()
    {
        return 0;
    }

    public virtual int getLevel()
    {
        return this.level;
    }

    public virtual int getMaxLevel()
    {
        return this.maxLevel;
    }

    public virtual int getCost()
    {
        return 0;
    }

    public virtual void downgrade()
    {
    }

    public virtual int getDowngradeCost()
    {
        return 0;
    }

    public virtual bool isDowngradeable()
    {
        return false;
    }

    public virtual int getUpgradeCost()
    {
        return (this.getLevel() * this.getLevel()) * 1000;
    }

    public virtual bool isUpgradeable()
    {
        if (this.getLevel() < this.getMaxLevel()) {
            return true;
        } else {
            return false;
        }
    }

    public virtual void upgrade()
    {
        this.level++;
        UnitTechnologySingletonFactory unitTechnologySingletonFactory = UnitTechnologySingletonFactory.getInstance();
        unitTechnologySingletonFactory.setHealth(unitTechnologySingletonFactory.getHealth() + (this.getLevel() * 100));
    }

    public virtual bool isSelfUpgradeable()
    {
        return false;
    }

}

