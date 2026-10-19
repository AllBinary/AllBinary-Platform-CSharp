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
using AndroidUtil = org.allbinary.AndroidUtil;
using J2MEUtil = org.allbinary.J2MEUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;

namespace org.allbinary.logic.math;

public class SmallIntegerSingletonFactory
{
    private static readonly SmallIntegerSingletonFactory instance = new SmallIntegerSingletonFactory();
    public static SmallIntegerSingletonFactory getInstance()
    {
        return SmallIntegerSingletonFactory.instance;
    }

    public readonly int NEGATIVE_MAX = 500;
    public readonly int POSITIVE_MAX = 0x2D1;
    private readonly int?[] INTEGER_ARRAY;
    private readonly string[] STRING_ARRAY;
    private int MIN = 0;
    private int lastMin = 0;
    private int lastNegativeMin = 0;
    public virtual int getMin()
    {
        int minAllowed = this.getMinAllowed();
        if (this.MIN <= minAllowed) {
            if (J2MEUtil.isJ2ME()) {
            } else if (AndroidUtil.isAndroid()) {
                LogUtil logUtil = LogUtil.getInstance();
                logUtil.putF(new StringMaker().append("Android InputFactory was initialized before GameMidlet: ").appendint(this.MIN).ToString(), this, "getMin");
                this.initWithRange(0x291, 6);
            } else {
                LogUtil logUtil = LogUtil.getInstance();
                logUtil.putF(new StringMaker().append("InputFactory was initialized before GameMidlet or KeyFactoryInitializer - Currently this is occurs on JS build by TouchMotionGestureFactory constructor: ").appendint(this.MIN).ToString(), this, "getMin");
                this.initWithRange(0x2D0, 6);
            }
        }
        if (this.MIN <= minAllowed) {
            LogUtil logUtil = LogUtil.getInstance();
            logUtil.put("This means you loaded the InputFactory before determining the platform input size requirements.", this, "getMin", new Exception());
        }
        return this.MIN;
    }

    private int getMinAllowed()
    {
        if (J2MEUtil.isJ2ME()) {
            return 0;
        } else {
            if (AndroidUtil.isAndroid()) {
                return 0x101;
            } else {
                return 23;
            }
        }
    }

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
        if (this.lastMin < this.POSITIVE_MAX || this.lastNegativeMin < this.NEGATIVE_MAX) {
            for (int index = this.POSITIVE_MAX - 1; index >= this.lastMin; index--) {
                this.INTEGER_ARRAY[index + this.NEGATIVE_MAX] = index;
            }
            for (int index = this.NEGATIVE_MAX - 1; index >= this.lastNegativeMin; index--) {
                this.INTEGER_ARRAY[index] = -index;
            }
            this.lastMin = this.POSITIVE_MAX;
            this.MIN = this.lastMin;
            this.lastNegativeMin = this.NEGATIVE_MAX;
        }
    }

    private SmallIntegerSingletonFactory()
    {
        this.INTEGER_ARRAY = new int?[this.NEGATIVE_MAX + this.POSITIVE_MAX];
        this.STRING_ARRAY = new string[this.NEGATIVE_MAX + this.POSITIVE_MAX];
        this.initWithRange(23, 0);
    }

    public virtual int? getAt(int index)
    {
        return this.INTEGER_ARRAY[index + this.NEGATIVE_MAX];
    }

    public virtual int? getAtNoThrow(int index)
    {
        if (index + this.NEGATIVE_MAX > this.INTEGER_ARRAY.Length - 1) {
            return this.INTEGER_ARRAY[-1 + this.NEGATIVE_MAX];
        }
        return this.INTEGER_ARRAY[index + this.NEGATIVE_MAX];
    }

    public virtual int? createInstance(int index)
    {
        int? integer = this.getAt(index);
        if (integer == null) {
            integer = index;
        }
        return integer;
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

