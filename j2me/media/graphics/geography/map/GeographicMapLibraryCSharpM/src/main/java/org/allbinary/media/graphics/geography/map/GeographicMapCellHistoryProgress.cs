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
using NullUtil = org.allbinary.logic.NullUtil;

namespace org.allbinary.media.graphics.geography.map;

public class GeographicMapCellHistoryProgress : GeographicMapCellHistoryProgressBase
{
    private int[] totalVisitedArray = NullUtil.getInstance().NULL_INT_ARRAY;
    private GeographicMapCellHistory[] geographicMapCellHistoryArray = GeographicMapCellHistory.NULL_GEOGRPAHIC_MAP_HISTORY_ARRAY;
    public GeographicMapCellHistoryProgress(GeographicMapCellHistory[] geographicMapCellHistoryArray)
    {
        this.geographicMapCellHistoryArray = geographicMapCellHistoryArray;
        this.init();
    }

    public override void init()
    {
        this.totalVisitedArray = new int[this.geographicMapCellHistoryArray.Length];
    }

    public override bool isAnyProgress()
    {
        bool isProgressing = false;
        int size = this.geographicMapCellHistoryArray.Length;
        int currentTotalVisited = 0;
        int totalVisited = 0;
        for (int index = 0; index < size; index++) {
            totalVisited = this.geographicMapCellHistoryArray[index].getTotalVisited();
            currentTotalVisited = this.totalVisitedArray[index];
            if (currentTotalVisited < totalVisited) {
                isProgressing = true;
                this.totalVisitedArray[index] = totalVisited;
            }
        }
        return isProgressing;
    }

}

