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
using GeographicMapCellPosition = org.allbinary.media.graphics.geography.map.GeographicMapCellPosition;

namespace org.allbinary.game.layer.geological.resources;

public class GeologicalGeographicMapCellPosition : GeographicMapCellPosition
{
    private readonly GeologicalResource geologicalResource;
    public GeologicalGeographicMapCellPosition(int column, int row, int columns, int rows, int width, int height, GeologicalResource geologicalResource) : base(column, row, columns, rows, width, height)
    {
        // base(column, row, columns, rows, width, height) is called from the constructor declaration
        this.geologicalResource = geologicalResource;
    }

    public virtual GeologicalResource getGeologicalResource()
    {
        return this.geologicalResource;
    }

}

