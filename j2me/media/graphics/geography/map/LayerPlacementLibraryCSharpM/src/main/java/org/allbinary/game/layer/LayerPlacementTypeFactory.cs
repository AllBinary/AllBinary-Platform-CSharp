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
using DirectionFactory = org.allbinary.direction.DirectionFactory;

namespace org.allbinary.game.layer;

public class LayerPlacementTypeFactory
{
    private static readonly LayerPlacementTypeFactory instance = new LayerPlacementTypeFactory();
    public static LayerPlacementTypeFactory getInstance()
    {
        return LayerPlacementTypeFactory.instance;
    }

    public readonly LayerPlacementType MAP = new LayerPlacementType(Integer.MAX_VALUE);
    public readonly LayerPlacementType LEFT = new LayerPlacementType(DirectionFactory.getInstance().LEFT.getValue());
    public readonly LayerPlacementType DOWN = new LayerPlacementType(DirectionFactory.getInstance().DOWN.getValue());
    public readonly LayerPlacementType UP = new LayerPlacementType(DirectionFactory.getInstance().UP.getValue());
    public readonly LayerPlacementType RIGHT = new LayerPlacementType(DirectionFactory.getInstance().RIGHT.getValue());
}

