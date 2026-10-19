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

namespace org.allbinary.media.graphics.geography.map;

public class GeographicMapCellHistoryProgressBase
{
    private static readonly GeographicMapCellHistoryProgressBase instance = new GeographicMapCellHistoryProgressBase();
    public static GeographicMapCellHistoryProgressBase getInstance()
    {
        return GeographicMapCellHistoryProgressBase.instance;
    }

    public GeographicMapCellHistoryProgressBase()
    {
    }

    public virtual void init()
    {
        throw new SystemException();
    }

    public virtual bool isAnyProgress()
    {
        throw new SystemException();
    }

}

