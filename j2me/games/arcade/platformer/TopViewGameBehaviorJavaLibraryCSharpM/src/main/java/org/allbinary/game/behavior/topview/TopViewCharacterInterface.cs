/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2022 AllBinary 
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
using GeographicMapCellPosition = org.allbinary.media.graphics.geography.map.GeographicMapCellPosition;
using GeographicMapCellType = org.allbinary.media.graphics.geography.map.GeographicMapCellType;

namespace org.allbinary.game.behavior.topview;

public interface TopViewCharacterInterface
{
    void terrainMove(BasicGeographicMap[] geographicMapInterfaceArray, GeographicMapCellType[] geographicMapCellTypeArray, int x, int y);

    // throws Exception
    void terrainEvent(int x, int y, BasicGeographicMap[] geographicMapInterfaceArray, GeographicMapCellType[] geographicMapCellTypeArray, GeographicMapCellPosition geographicMapCellPosition);

    void move();

    void upp();

    void leftp();

    void rightp();

    // throws Exception
    void reset();

}

