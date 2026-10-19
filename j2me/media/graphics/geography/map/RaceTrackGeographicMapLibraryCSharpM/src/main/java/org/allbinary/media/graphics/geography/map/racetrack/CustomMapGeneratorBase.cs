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
using NullUtil = org.allbinary.logic.NullUtil;

namespace org.allbinary.media.graphics.geography.map.racetrack;

public class CustomMapGeneratorBase
{
    // throws Exception
    public virtual void copyMapIntoCustomMap()
    {
    }

    public virtual int[][] getCustomMapArray()
    {
        return NullUtil.getInstance().NULL_INT_ARRAY_ARRAY;
    }

    // throws Exception
    public virtual int getCustomType(int column, int row, int currentType)
    {
        return -1;
    }

}

