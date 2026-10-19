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
using BasicGeographicMap = org.allbinary.media.graphics.geography.map.BasicGeographicMap;
using GeographicMapCellHistory = org.allbinary.media.graphics.geography.map.GeographicMapCellHistory;
using BasicArrayList = org.allbinary.util.BasicArrayList;

namespace org.allbinary.media.graphics.geography.pathfinding;

public interface PathGeneratorInterface
{
    // throws Exception
    BasicArrayList createList(BasicGeographicMap geographicMapInterface, GeographicMapCellHistory geographicMapCellHistory, PathFindingInfo pathFindingInfo, int totalPaths);

}

