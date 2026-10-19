// Generated Code Do Not Modify

using System;
using System.Linq;
using ForcedLogUtil = org.allbinary.logic.communication.log.ForcedLogUtil;
using AllBinaryEventObject = org.allbinary.logic.util.@event.AllBinaryEventObject;
using EventStrings = org.allbinary.logic.util.@event.EventStrings;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.game.terrain;

public class TerrainEventListener : TerrainEventListenerInterface
{
    private readonly BasicArrayList list = new BasicArrayListD();
    public virtual void onEvent(AllBinaryEventObject eventObject)
    {
        ForcedLogUtil.log(EventStrings.getInstance().PERFORMANCE_MESSAGE, this);
    }

    public virtual void onTerrainEvent(TerrainEvent terrainEvent)
    {
        this.list.clear();
        this.list.add(terrainEvent);
    }

    public virtual BasicArrayList getList()
    {
        return this.list;
    }

}

