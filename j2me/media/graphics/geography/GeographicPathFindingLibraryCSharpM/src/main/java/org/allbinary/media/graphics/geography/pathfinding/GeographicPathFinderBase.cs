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
using CommonStrings = org.allbinary.@string.CommonStrings;
using BasicArrayList = org.allbinary.util.BasicArrayList;

namespace org.allbinary.media.graphics.geography.pathfinding;

public class GeographicPathFinderBase
{
    public static readonly GeographicPathFinderBase NULL_GEOGRAPHIC_PATH_FINDER_BASE = new GeographicPathFinderBase();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    // throws Exception
    public virtual BasicArrayList searchTotalPath(BasicArrayList startPathFindingNodeList, BasicArrayList endPathFindingNodeList, int totalPaths)
    {
        throw new SystemException();
    }

    // throws Exception
    public virtual BasicArrayList searchTotalPathN(BasicArrayList startPathFindingNodeList, BasicArrayList endPathFindingNodeList, int totalPaths, MultipassState multipassState)
    {
        throw new SystemException();
    }

}

