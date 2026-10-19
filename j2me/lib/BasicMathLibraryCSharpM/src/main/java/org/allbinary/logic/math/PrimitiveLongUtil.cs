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
using NullUtil = org.allbinary.logic.NullUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.logic.math;

public class PrimitiveLongUtil
{
    public static PrimitiveLongUtil createPowerOfTen(int powerOfTen)
    {
        PrimitiveLongUtil primitiveLongUtil = new PrimitiveLongUtil(powerOfTen, NullUtil.getInstance().NULL_OBJECT);
        if (powerOfTen % 10 != 0) {
            LogUtil logUtil = LogUtil.getInstance();
            CommonStrings commonStrings = CommonStrings.getInstance();
            logUtil.put(commonStrings.EXCEPTION, primitiveLongUtil, commonStrings.CONSTRUCTOR, new Exception("Max must be power of 10"));
        }
        return primitiveLongUtil;
    }

    public readonly LogUtil logUtil = LogUtil.getInstance();
    private int powerOfTen;
    private int maxValue;
    private int maxDigits;
    private readonly char[] charArray;
    private int currentTotalDigits = 0;
    private readonly PrimitiveLongSingleton primitiveLongSingleton = PrimitiveLongSingleton.getInstance();
    public PrimitiveLongUtil(int powerOfTen, object unused)
    {
        this.maxDigits = MathUtil.getInstance().getTotalDigits(powerOfTen);
        this.powerOfTen = powerOfTen;
        this.maxValue = (powerOfTen * 10) - 1;
        this.charArray = new char[this.maxDigits];
    }

    public virtual char[] getCharArray(int value)
    {
        if (value < 10) {
            this.setCurrentTotalDigits(1);
            return this.primitiveLongSingleton.NUMBER_CHAR_ARRAYS[value];
        }
        if (value > this.maxValue) {
            this.setCurrentTotalDigits(3);
            return this.primitiveLongSingleton.UNK;
        }
        int index = 0;
        int div = this.powerOfTen;
        int lastValue = 0;
        while (div >= 1) {
            int digit = (value - lastValue) / div;
            if (digit >= 0 && digit < 10) {
                if (digit == 0 && index == 0) {
                } else {
                    this.charArray[index++] = this.primitiveLongSingleton.NUMBER_CHAR_ARRAY[digit];
                }
                lastValue += digit * div;
            }
            div = div / 10;
        }
        this.setCurrentTotalDigits(index);
        return this.charArray;
    }

    private void setCurrentTotalDigits(int currentTotalDigits)
    {
        this.currentTotalDigits = currentTotalDigits;
    }

    public virtual int getCurrentTotalDigits()
    {
        return this.currentTotalDigits;
    }

    public virtual int getMaxDigits()
    {
        return this.maxDigits;
    }

}

