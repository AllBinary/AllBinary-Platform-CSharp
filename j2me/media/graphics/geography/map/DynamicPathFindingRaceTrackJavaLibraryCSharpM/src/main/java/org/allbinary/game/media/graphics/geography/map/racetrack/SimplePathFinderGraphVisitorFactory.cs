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
using BasicGeographicMap = org.allbinary.media.graphics.geography.map.BasicGeographicMap;
using PathFinderGraphVisitorFactoryBase = org.allbinary.media.graphics.geography.pathfinding.PathFinderGraphVisitorFactoryBase;
using PathFinderGraphVisitorBase = org.allbinary.media.graphics.geography.pathfinding.PathFinderGraphVisitorBase;

namespace org.allbinary.game.media.graphics.geography.map.racetrack;

public class SimplePathFinderGraphVisitorFactory : PathFinderGraphVisitorFactoryBase
{
    private readonly int edgeMinimum;
    private readonly int minPathWeight;
    private readonly int maxPathWeight;
    public SimplePathFinderGraphVisitorFactory(int edgeMinimum, int minPathWeight, int maxPathWeight)
    {
        this.edgeMinimum = edgeMinimum;
        this.minPathWeight = minPathWeight;
        this.maxPathWeight = maxPathWeight;
    }

    public virtual PathFinderGraphVisitorBase getInstance(BasicGeographicMap geographicMapInterface)
    {
        return new BasePathFinderGraphVisitor(geographicMapInterface, this.edgeMinimum, this.minPathWeight, this.maxPathWeight);
    }

}

