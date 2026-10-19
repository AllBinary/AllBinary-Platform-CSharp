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
using RemoteInfo = org.allbinary.game.multiplayer.layer.RemoteInfo;
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;
using AllBinaryLayerFactoryInterface = org.allbinary.layer.AllBinaryLayerFactoryInterface;

namespace org.allbinary.game.ag.layer.pickup;

public class FallingPickupLayerFactory : AllBinaryLayerFactoryInterface
{
    // throws Exception
    public virtual AllBinaryLayer getInstance()
    {
        return new FallingPickupLayer(RemoteInfo.REMOTE_INFO);
    }

}

