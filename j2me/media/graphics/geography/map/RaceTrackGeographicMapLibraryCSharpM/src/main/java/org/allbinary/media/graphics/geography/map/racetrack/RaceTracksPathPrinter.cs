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
using StringMaker = org.allbinary.logic.@string.StringMaker;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using PreLogUtil = org.allbinary.logic.communication.log.PreLogUtil;
using CommonLabels = org.allbinary.@string.CommonLabels;

namespace org.allbinary.media.graphics.geography.map.racetrack;

public class RaceTracksPathPrinter
{
    private void printPath(BasicArrayList list)
    {
        int size = list.size();
        for (int index = 0; index < size; index++) {
            object anyType = list.get(index);
            PreLogUtil.put(new StringMaker().append("pathList.add(cellPositionFactory.getInstance").append(anyType.ToString()).append(");").ToString(), this, "printPath");
        }
    }

    protected virtual void printPaths(BasicArrayList list)
    {
        int size = list.size();
        for (int index = 0; index < size; index++) {
            Console.WriteLine(new StringMaker().append(" Path ").appendint(index).append(CommonLabels.getInstance().COLON_SEP).ToString());
            this.printPath(((BasicArrayList) list.get(index)));
        }
    }

}

