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
using AllBinaryEventObject = org.allbinary.logic.util.@event.AllBinaryEventObject;
using AllBinaryEventObjectFactoryInterface = org.allbinary.logic.util.@event.AllBinaryEventObjectFactoryInterface;

namespace org.allbinary.game.terrain;

public class TerrainEventFactory : AllBinaryEventObjectFactoryInterface
{
    public TerrainEventFactory()
    {
    }

    public virtual AllBinaryEventObject getInstance()
    {
        return new TerrainEvent(NullUtil.getInstance().NULL_OBJECT);
    }

}

