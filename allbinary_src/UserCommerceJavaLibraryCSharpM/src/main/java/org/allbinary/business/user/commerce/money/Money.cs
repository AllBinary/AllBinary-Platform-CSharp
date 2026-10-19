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
using AbPathData = org.allbinary.logic.io.path.AbPathData;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using StringValidationUtil = org.allbinary.logic.@string.StringValidationUtil;
using CommonPhoneStrings = org.allbinary.@string.CommonPhoneStrings;

namespace org.allbinary.business.user.commerce.money;

public class Money
{
    private long? units;
    private readonly string DEFAULT_CURRENCY = "USD";
    public Money(Money money)
    {
        this.units = money.getUnits();
    }

    public Money()
    {
        this.units = 0;
    }

    public Money(string usDollarStr)
    {
        if (usDollarStr != null && StringValidationUtil.getInstance().isNumber(usDollarStr)) {
            this.units = convertUsdToUnits(usDollarStr);
        }
    }

    public Money(long units)
    {
        this.units = units;
    }

    public virtual bool isValid()
    {
        if (this.units != null && ((long) this.units) > 0 && ((long) this.units) < Long.MAX_VALUE) {
            return true;
        } else {
            return false;
        }
    }

    public virtual void add(Money moreMoney)
    {
        this.add(moreMoney.ToString());
    }

    public virtual void add(string usDollarStr)
    {
        this.units = ((long) this.units) + convertUsdToUnits(usDollarStr);
    }

    public virtual void subtract(string usDollarStr)
    {
        this.units = ((long) this.units) - convertUsdToUnits(usDollarStr);
    }

    public virtual void multiply(float? multiplier)
    {
        this.units = ((long) ((long) this.units) * ((float) multiplier));
    }

    public virtual void multiply(int multiplier)
    {
        this.units = ((long) this.units) * multiplier;
    }

    private string convertUnitsTo(string currency)
    {
        StringMaker stringBuffer = new StringMaker();
        if (string.CompareOrdinal(currency, this.DEFAULT_CURRENCY) == 0) {
            long dollar = ((long) this.units) / 100;
            long cents = ((long) this.units) - (dollar * 100L);
            stringBuffer.append(dollar.ToString());
            stringBuffer.append(AbPathData.getInstance().EXTENSION_SEP);
            if (cents < 10L) {
                stringBuffer.append(CommonPhoneStrings.getInstance().ZERO);
            }
            stringBuffer.append(cents.ToString());
        }
        return stringBuffer.ToString();
    }

    private long convertUsdToUnits(string usDollarStr)
    {
        long localUnit = 0L;
        int index = usDollarStr.IndexOf(AbPathData.getInstance().EXTENSION_SEP);
        StringUtil stringUtil = StringUtil.getInstance();
        string dollarStr = stringUtil.EMPTY_STRING;
        string centsStr = stringUtil.EMPTY_STRING;
        if (index < 1) {
            dollarStr = new string((usDollarStr).ToCharArray());
            centsStr = "00";
        } else {
            dollarStr = new string((usDollarStr.Substring(0, (index) - (0))).ToCharArray());
            centsStr = new string((usDollarStr.Substring(index + 1)).ToCharArray());
        }
        localUnit = ((long) ((long) dollarStr) * 100);
        localUnit += ((long) centsStr);
        return localUnit;
    }

    public virtual long getUnits()
    {
        return ((long) this.units);
    }

    public virtual long? getUnitsLong()
    {
        return this.units;
    }

    public override string ToString()
    {
        return new string((convertUnitsTo(this.DEFAULT_CURRENCY)).ToCharArray());
    }

}

