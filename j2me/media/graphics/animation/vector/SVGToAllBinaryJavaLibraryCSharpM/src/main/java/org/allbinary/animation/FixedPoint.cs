// Generated Code Do Not Modify

using System;
using System.Linq;

namespace org.allbinary.animation;

public class FixedPoint
{
    private static readonly FixedPoint instance = new FixedPoint();
    public static FixedPoint getInstance()
    {
        return FixedPoint.instance;
    }

    public readonly int ONE = 1 << 16;
    public virtual int toFixed(double val)
    {
        return ((int) (val * 65536.0));
    }

    public virtual int toFixed(float val)
    {
        return ((int) (val * 65536.0f));
    }

    public virtual int mul(int a, int b)
    {
        return ((int) ((((long) a) * ((long) b)) >> 16));
    }

    public virtual int div(int a, int b)
    {
        return ((int) (((((long) a)) << 16) / ((long) b)));
    }

    public virtual int toInt(int @fixed)
    {
        return @fixed >> 16;
    }

}

