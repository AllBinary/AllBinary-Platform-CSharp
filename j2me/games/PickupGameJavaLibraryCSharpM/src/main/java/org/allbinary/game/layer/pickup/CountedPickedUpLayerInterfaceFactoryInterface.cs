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
using LayerInterfaceFactoryInterface = org.allbinary.layer.LayerInterfaceFactoryInterface;

namespace org.allbinary.game.layer.pickup;

public interface CountedPickedUpLayerInterfaceFactoryInterface : PickedUpLayerInterfaceFactoryInterface, LayerInterfaceFactoryInterface
{
    int getId();

    int getTotal();

}

