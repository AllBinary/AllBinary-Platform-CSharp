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
using BasicArrayList = org.allbinary.util.BasicArrayList;

namespace org.allbinary.media.graphics.geography.pathfinding;

//1.4.2
public class PathFinderGraphVisitorBase
{
    // throws Exception
    public virtual void visit(object graph, BasicArrayList startPathFindingNodeList, BasicArrayList endPathFindingNodeList)
    {
        throw new SystemException();
    }

    // throws Exception
    public virtual void fixPath(BasicArrayList startPathFindingNodeList, BasicArrayList endPathFindingNodeList, BasicArrayList pathList)
    {
        throw new SystemException();
    }

    public virtual bool isValid(object graphPath)
    {
        throw new SystemException();
    }

    public virtual string getInvalidReason(object graphPath)
    {
        throw new SystemException();
    }

}

