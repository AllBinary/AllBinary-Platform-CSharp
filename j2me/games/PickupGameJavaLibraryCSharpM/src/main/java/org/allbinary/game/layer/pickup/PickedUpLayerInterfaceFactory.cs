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
using Animation = org.allbinary.animation.Animation;
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;

namespace org.allbinary.game.layer.pickup;

public class PickedUpLayerInterfaceFactory : PickedUpLayerInterfaceFactoryBase
{
    private readonly PickedUpLayerType pickedUpLayerType;
    private readonly IconLayer iconLayer;
    private readonly Animation animationInterface;
    public PickedUpLayerInterfaceFactory(PickedUpLayerType pickeUpLayerType, IconLayer iconLayer, Animation animationInterface)
    {
        this.pickedUpLayerType = pickeUpLayerType;
        this.animationInterface = animationInterface;
        this.iconLayer = iconLayer;
    }

    public override AllBinaryLayer getIconLayer()
    {
        return this.iconLayer;
    }

    public override Animation getAnimationInterface()
    {
        return this.animationInterface;
    }

    public override PickedUpLayerType getPickedUpLayerType()
    {
        return this.pickedUpLayerType;
    }

}

