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
using ForcedLogUtil = org.allbinary.logic.communication.log.ForcedLogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using CommonSeps = org.allbinary.@string.CommonSeps;

namespace org.allbinary.game.health;

public class Health : HealthInterface
{
    public static readonly Health NULL_HEALTH = new Health(0);
    public static readonly string NAME = "Health Resource";
    private int health = 0;
    private int maxHealth = 0;
    private HealthListenerInterface healthListenerInterface = NullHealthListener.NULL_HEALTH_LISTENER;
    public Health(int maxHealth)
    {
        this.setMaxHealth(maxHealth);
        this.setHealth(maxHealth);
    }

    public virtual void heal(int ahealth)
    {
        int newHealth = this.getHealth() + ahealth;
        if (newHealth > this.getMaxHealth()) {
            this.setHealth(this.getMaxHealth());
        } else {
            this.setHealth(newHealth);
        }
    }

    public virtual void healMax()
    {
        this.setHealth(this.getMaxHealth());
    }

    public virtual bool isDamaged()
    {
        if (this.getHealth() != this.getMaxHealth()) {
            return true;
        } else {
            return false;
        }
    }

    public virtual void damage(int ahealth)
    {
        if (ahealth < 0) {
            StringMaker stringBuffer = new StringMaker();
            stringBuffer.append("******* Trying to heal when damaging. Damage: ");
            stringBuffer.appendint(ahealth);
            stringBuffer.append(CommonSeps.getInstance().SPACE);
            stringBuffer.append(this.ToString());
            ForcedLogUtil.log(stringBuffer.ToString(), this);
            return;
        }
        int health = this.getHealth() - ahealth;
        this.setHealth(health);
    }

    public virtual bool isAlive()
    {
        if (this.getHealth() <= 0) {
            return false;
        } else {
            return true;
        }
    }

    public virtual int getMaxHealth()
    {
        return this.maxHealth;
    }

    public virtual void setMaxHealth(int maxHealth)
    {
        this.maxHealth = maxHealth;
    }

    public virtual void setHealth(int health)
    {
        if (health > this.getMaxHealth()) {
            this.health = this.getMaxHealth();
        } else if (health < 0) {
            this.health = 0;
        } else {
            this.health = health;
        }
        if (this.healthListenerInterface != null) {
            this.healthListenerInterface.onHealthChange();
        }
    }

    public virtual int getHealth()
    {
        return this.health;
    }

    public virtual void addListener(HealthListenerInterface healthGraphic)
    {
        this.healthListenerInterface = healthGraphic;
    }

    private static readonly string HEALTH_LABEL = "Health: ";
    private static readonly string MAX_HEALTH_LABEL = " Max: ";
    public override string ToString()
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(Health.HEALTH_LABEL);
        stringBuffer.appendint(this.health);
        stringBuffer.append(Health.MAX_HEALTH_LABEL);
        stringBuffer.appendint(this.maxHealth);
        return stringBuffer.ToString();
    }

}

