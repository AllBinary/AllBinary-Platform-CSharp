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

namespace org.allbinary.logic.math;

public class BasicDecimal
{
    public static readonly BasicDecimal ZERO_BIGDECIMAL = new BasicDecimal(0);
    public static BasicDecimal createBigDecimal(BasicDecimal bigDecimal)
    {
        return new BasicDecimal(bigDecimal.getUnscaled());
    }

    private long units;
    public BasicDecimal(long units)
    {
        this.units = units;
        this.updateScaled();
    }

    public virtual void setint(int value)
    {
        this.units = ((long) value);
        this.updateScaled();
    }

    public virtual void setlong(long value)
    {
        this.units = value;
        this.updateScaled();
    }

    public virtual void set(BasicDecimal bigDecimal)
    {
        this.units = bigDecimal.getUnscaled();
        this.updateScaled();
    }

    public virtual void addint(int value)
    {
        this.units = this.units + ((long) value);
        this.updateScaled();
    }

    public virtual void addlong(long value)
    {
        this.units = this.units + value;
        this.updateScaled();
    }

    public virtual void add(BasicDecimal bigDecimal)
    {
        this.units = this.units + bigDecimal.getUnscaled();
        this.updateScaled();
    }

    public virtual void subtractint(int value)
    {
        this.units = this.units - ((long) value);
        this.updateScaled();
    }

    public virtual void subtractlong(long value)
    {
        this.units = this.units - value;
        this.updateScaled();
    }

    public virtual void subtract(BasicDecimal bigDecimal)
    {
        this.units = this.units - bigDecimal.getUnscaled();
        this.updateScaled();
    }

    public virtual void multiplyint(int value)
    {
        this.units = this.units * ((long) value);
        this.updateScaled();
    }

    public virtual void multiplylong(long value)
    {
        this.units = this.units * value;
        this.updateScaled();
    }

    public virtual void multiply(BasicDecimal bigDecimal)
    {
        this.units = this.units * bigDecimal.getUnscaled();
        this.updateScaled();
    }

    public virtual void divideint(int value)
    {
        this.units = this.units / ((long) value);
        this.updateScaled();
    }

    public virtual void dividelong(long value)
    {
        this.units = this.units / value;
        this.updateScaled();
    }

    public virtual void divide(BasicDecimal bigDecimal)
    {
        this.units = this.units / bigDecimal.getUnscaled();
        this.updateScaled();
    }

    public virtual long getUnscaled()
    {
        return this.units;
    }

    private int scaled = 0;
    private void updateScaled()
    {
        this.scaled = ((int) (this.units / ((long) this.factorValue)));
    }

    public virtual int getScaled()
    {
        return this.scaled;
    }

    public override string ToString()
    {
        return (this.units).ToString();
    }

    private readonly int factor = ScaleFactorFactory.getInstance().DEFAULT_SCALE_FACTOR;
    private readonly int factorValue = ScaleFactorFactory.getInstance().DEFAULT_SCALE_VALUE;
    public virtual int getScaledFactor()
    {
        return this.factor;
    }

    public virtual int getScaledFactorValue()
    {
        return this.factorValue;
    }

}

