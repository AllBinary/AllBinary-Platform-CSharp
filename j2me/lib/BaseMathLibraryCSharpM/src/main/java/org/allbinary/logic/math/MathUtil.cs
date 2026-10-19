// Generated Code Do Not Modify

using System;
using System.Linq;
//using JsType = jsinterop.annotations.JsType;

namespace org.allbinary.logic.math;

public class MathUtil
{
    private static readonly MathUtil instance = new MathUtil();
    public static MathUtil getInstance()
    {
        return MathUtil.instance;
    }

    public virtual int getTotalDigits(int digits)
    {
        int total = 0;
        while (digits > 0) {
            digits = digits / 10;
            total++;
        }
        return total;
    }

    public virtual int sqrt(int value)
    {
        if (value <= 1) {
            return value;
        }
        int accumulated = value >> 1;
        int result = (accumulated + (value / accumulated)) >> 1;
        do {
            accumulated = result;
            result = (accumulated + (value / accumulated)) >> 1;
        } while (accumulated > result);
        return accumulated;
    }

    private readonly int ACCURACY = 100;
    public virtual double sqrtd(int x)
    {
        if (x == 0) {
            return ((double) 0.0f);
        }
        if (x < 0) {
            return ((double) (-1.0f));
        }
        double result = ((double) x);
        for (int index = 0; index < this.ACCURACY; index++) {
            result = (result + (((double) x) / result)) / 2.0;
        }
        return result;
    }

    public virtual int abs(int value)
    {
        return ((value < 0) ? -value : value);
    }

    public virtual long abslong(long value)
    {
        return ((value < 0L) ? -value : value);
    }

    public virtual int min(int value, int value2)
    {
        return ((value <= value2) ? value : value2);
    }

    public virtual int max(int value, int value2)
    {
        return ((value >= value2) ? value : value2);
    }

}

