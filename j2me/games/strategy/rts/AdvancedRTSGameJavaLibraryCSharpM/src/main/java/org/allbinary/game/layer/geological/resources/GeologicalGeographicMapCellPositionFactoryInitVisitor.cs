/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2006 AllBinary 
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
using AllBinaryTiledLayer = org.allbinary.game.layer.AllBinaryTiledLayer;
using GeographicMapCellPosition = org.allbinary.media.graphics.geography.map.GeographicMapCellPosition;
using GeographicMapCellPositionFactoryInitVisitorInterface = org.allbinary.media.graphics.geography.map.GeographicMapCellPositionFactoryInitVisitorInterface;

namespace org.allbinary.game.layer.geological.resources;

public class GeologicalGeographicMapCellPositionFactoryInitVisitor : GeographicMapCellPositionFactoryInitVisitorInterface
{
    // throws Exception
    public virtual void visit(AllBinaryTiledLayer tiledLayer, GeographicMapCellPosition cellPosition)
    {
        GeologicalGeographicMapCellPosition geologicalGeographicMapCellPosition = (((GeologicalGeographicMapCellPosition) cellPosition));
        geologicalGeographicMapCellPosition.getGeologicalResource().init();
    }

}

