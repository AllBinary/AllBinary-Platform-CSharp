/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2025 AllBinary 
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
using Animation = org.allbinary.animation.Animation;
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;

namespace org.allbinary.game.layer.pickup;

public class PickedUpLayerInterfaceFactoryBase : PickedUpLayerInterfaceFactoryInterface
{
    public static readonly PickedUpLayerInterfaceFactoryBase NULL_PICKED_UP_LAYER_FACTORY_BASE = new PickedUpLayerInterfaceFactoryBase();
    public virtual AllBinaryLayer getIconLayer()
    {
        throw new SystemException();
    }

    public virtual Animation getAnimationInterface()
    {
        throw new SystemException();
    }

    public virtual PickedUpLayerType getPickedUpLayerType()
    {
        throw new SystemException();
    }

}

