// Generated Code Do Not Modify

using System;
using System.Linq;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.game.input.analog;

public class AnalogLocationInputFactory
{
    private static readonly AnalogLocationInputFactory instance = new AnalogLocationInputFactory();
    public static AnalogLocationInputFactory getInstance()
    {
        return AnalogLocationInputFactory.instance;
    }

    private readonly BasicArrayList list = new BasicArrayListD();
    private AnalogLocationInputFactory()
    {
    }

    public virtual void addPlayer(int playerInputId)
    {
        AnalogLocationInput analogLocationInput = AnalogLocationInput.NULL_ANALOG_LOCATION_INPUT;
        if (playerInputId < this.list.size()) {
            analogLocationInput = ((AnalogLocationInput) this.list.get(playerInputId));
        }
        if (analogLocationInput == AnalogLocationInput.NULL_ANALOG_LOCATION_INPUT) {
            analogLocationInput = new AnalogLocationInput(playerInputId);
            this.list.add(analogLocationInput);
        }
    }

    public virtual AnalogLocationInput getInstanceForPlayer(int playerInputId)
    {
        return ((AnalogLocationInput) this.list.get(playerInputId));
    }

    public virtual BasicArrayList getList()
    {
        return this.list;
    }

}

