// Generated Code Do Not Modify

using System;
using System.Linq;
using CustomGPoint = org.allbinary.graphics.CustomGPoint;

namespace org.allbinary.game.input.analog;

public class AnalogLocationInput
{
    public static readonly AnalogLocationInput NULL_ANALOG_LOCATION_INPUT = new AnalogLocationInput(-1);
    private readonly int playerId;
    private readonly CustomGPoint customGPoint;
    private int rz = 0;
    private int rightTrigger = 0;
    private int leftTrigger = 0;
    public AnalogLocationInput(int playerId)
    {
        this.playerId = playerId;
        this.customGPoint = new CustomGPoint(0, 0, 0);
    }

    public virtual int getPlayerId()
    {
        return this.playerId;
    }

    public virtual CustomGPoint getCustomGPoint()
    {
        return this.customGPoint;
    }

    public virtual int getRz()
    {
        return this.rz;
    }

    public virtual void setRz(int rz)
    {
        this.rz = rz;
    }

    public virtual int getRightTrigger()
    {
        return this.rightTrigger;
    }

    public virtual void setRightTrigger(int rightTrigger)
    {
        this.rightTrigger = rightTrigger;
    }

    public virtual int getLeftTrigger()
    {
        return this.leftTrigger;
    }

    public virtual void setLeftTrigger(int leftTrigger)
    {
        this.leftTrigger = leftTrigger;
    }

}

