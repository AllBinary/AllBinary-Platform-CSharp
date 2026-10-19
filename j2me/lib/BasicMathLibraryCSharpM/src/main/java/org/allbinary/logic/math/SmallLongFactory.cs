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

public class SmallLongFactory
{
    private static readonly SmallLongFactory instance = new SmallLongFactory();
    public static SmallLongFactory getInstance()
    {
        return SmallLongFactory.instance;
    }

    public readonly int NEGATIVE_MAX = 500;
    public readonly int POSITIVE_MAX = 0x2D1;
    private readonly long?[] INTEGER_ARRAY;
    private readonly string[] STRING_ARRAY;
    public int MIN = 0;
    public int lastMin = 0;
    public int lastNegativeMin = 0;
    public virtual void initWithRange(int value, int negativeValue)
    {
        for (int index = value - 1; index >= this.lastMin; index--) {
            this.INTEGER_ARRAY[index + this.NEGATIVE_MAX] = index;
        }
        for (int index = negativeValue - 1; index >= this.lastNegativeMin; index--) {
            this.INTEGER_ARRAY[index] = -index;
        }
        if (this.lastMin < value) {
            this.lastMin = value;
            this.MIN = value;
        }
        if (this.lastNegativeMin < negativeValue) {
            this.lastNegativeMin = negativeValue;
        }
    }

    public virtual void init()
    {
        if (this.INTEGER_ARRAY[0] == null) {
            if (this.lastMin < this.POSITIVE_MAX || this.lastNegativeMin < this.NEGATIVE_MAX) {
                for (int index = this.POSITIVE_MAX - 1; index >= this.lastMin; index--) {
                    this.INTEGER_ARRAY[index + this.NEGATIVE_MAX] = index;
                }
                for (int index = this.NEGATIVE_MAX - 1; index >= this.lastNegativeMin; index--) {
                    this.INTEGER_ARRAY[index] = -index;
                }
                this.lastMin = this.POSITIVE_MAX;
                this.lastNegativeMin = this.NEGATIVE_MAX;
            }
        }
    }

    private SmallLongFactory()
    {
        this.INTEGER_ARRAY = new long?[this.NEGATIVE_MAX + this.POSITIVE_MAX];
        this.STRING_ARRAY = new string[this.NEGATIVE_MAX + this.POSITIVE_MAX];
    }

    public virtual long? getInstanceNoThrow(long index)
    {
        if (index + ((long) this.NEGATIVE_MAX) > ((long) (this.INTEGER_ARRAY.Length - 1))) {
            return this.INTEGER_ARRAY[-1 + this.NEGATIVE_MAX];
        }
        return this.INTEGER_ARRAY[(((int) index)) + this.NEGATIVE_MAX];
    }

    public virtual string getString(int index)
    {
        int i = index + this.NEGATIVE_MAX;
        if (this.STRING_ARRAY[i] == null) {
            this.STRING_ARRAY[i] = this.INTEGER_ARRAY[i].ToString();
        }
        return this.STRING_ARRAY[i];
    }

}

