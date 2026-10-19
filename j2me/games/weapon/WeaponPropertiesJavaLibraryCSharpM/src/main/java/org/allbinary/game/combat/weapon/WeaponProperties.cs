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
using PreLogUtil = org.allbinary.logic.communication.log.PreLogUtil;
using BasicDecimal = org.allbinary.logic.math.BasicDecimal;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using CommonSeps = org.allbinary.@string.CommonSeps;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.game.combat.weapon;

public class WeaponProperties : SimpleWeaponProperties
{
    public static readonly WeaponProperties NULL_WEAPON_PROPERTIES = new WeaponProperties(0L, 0L, 0L, 0, ((short) 0));
    private long reloadTime = 0L;
    private long targetingTime = 0L;
    private BasicDecimal speed = BasicDecimal.ZERO_BIGDECIMAL;
    private static bool messageSent = false;
    private readonly long MAX = 10240L;
    private readonly short ZERO = 0;
    public WeaponProperties(long reloadTime, long targetingTime, long speed, int damage, short dissipation)
    {
        if (speed < this.MAX && speed != 0L && !WeaponProperties.messageSent) {
            string MESSAGE = "Danger Danger Danger: Speed probably to slow if using 1 degree calculations as velocity for a single axis could be below 1024: ";
            CommonStrings commonStrings = CommonStrings.getInstance();
            PreLogUtil.put(new StringMaker().append(MESSAGE).appendlong(speed).ToString(), this, commonStrings.CONSTRUCTOR);
            WeaponProperties.messageSent = true;
        }
        this.setReloadTime(reloadTime);
        this.setTargetingTime(targetingTime);
        this.setDamage(damage);
        this.setDissipation(dissipation);
        this.setSpeed(new BasicDecimal(speed));
        if (dissipation != this.ZERO) {
            long unscaledDamage = this.speed.getUnscaled() * damage;
            int scaledDissipation = dissipation * this.speed.getScaledFactorValue();
            long value = (unscaledDamage / ((long) scaledDissipation));
            this.setRange(((int) (value * 9L)) / 10);
        }
    }

    private void setReloadTime(long reloadTime)
    {
        this.reloadTime = reloadTime;
    }

    public virtual long getReloadTime()
    {
        return this.reloadTime;
    }

    private void setTargetingTime(long targetingTime)
    {
        this.targetingTime = targetingTime;
    }

    public virtual long getTargetingTime()
    {
        return this.targetingTime;
    }

    public virtual BasicDecimal getSpeed()
    {
        return this.speed;
    }

    public virtual void setSpeed(BasicDecimal speed)
    {
        this.speed = speed;
    }

    public virtual int getDamageI(int range)
    {
        return this.getDamage() - ((this.getDissipation() * range) / this.speed.getScaled());
    }

    private static readonly string DAMAGE = "Damage: ";
    private static readonly string RANGE = "Range: ";
    private static readonly string RELOAD = "Reload: ";
    public virtual string[] toStringArray()
    {
        int index = 0;
        string[] stringArray = new string[3];
        StringMaker stringBuffer = new StringMaker();
        stringArray[index++] = stringBuffer.append(WeaponProperties.DAMAGE).appendint(((int) this.getDamage())).ToString();
        stringBuffer.delete(0, stringBuffer.length());
        stringArray[index++] = stringBuffer.append(WeaponProperties.RANGE).appendint(((int) this.getRange())).ToString();
        stringBuffer.delete(0, stringBuffer.length());
        stringArray[index++] = stringBuffer.append(WeaponProperties.RELOAD).appendlong(this.getReloadTime()).ToString();
        return stringArray;
    }

    public override string ToString()
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(WeaponProperties.DAMAGE).appendint(((int) this.getDamage()));
        stringBuffer.append(CommonSeps.getInstance().SPACE);
        stringBuffer.append(WeaponProperties.RANGE).appendint(((int) this.getRange()));
        stringBuffer.append(CommonSeps.getInstance().SPACE);
        stringBuffer.append(WeaponProperties.RELOAD).appendlong(this.getReloadTime());
        return stringBuffer.ToString();
    }

}

