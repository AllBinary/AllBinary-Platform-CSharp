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
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using CellPosition = org.allbinary.graphics.CellPosition;
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;

namespace org.allbinary.game.layer.waypoint;

public class WaypointCellPositionHistory
{
    private static readonly WaypointCellPositionHistory SINGLETON = new WaypointCellPositionHistory();
    public static WaypointCellPositionHistory getInstance()
    {
        return WaypointCellPositionHistory.SINGLETON;
    }

    private BasicArrayList positionList = new BasicArrayListD();
    private BasicArrayList layerList = new BasicArrayListD();
    public virtual void add(CellPosition cellPosition, AllBinaryLayer layerInterface)
    {
        this.positionList.add(cellPosition);
        this.layerList.add(layerInterface);
    }

    public virtual void addList(BasicArrayList list, AllBinaryLayer layerInterface)
    {
        for (int index = list.size() - 1; index >= 0; index--) {
            this.add(((CellPosition) list.get(index)), layerInterface);
        }
    }

    public virtual void remove(CellPosition cellPosition)
    {
        int index = this.positionList.indexOf(cellPosition);
        if (index >= 0) {
            this.positionList.removeAt(index);
            this.layerList.removeAt(index);
        }
    }

    public virtual void removeLayer(AllBinaryLayer layerInterface)
    {
        int index = 0;
        while (index != -1) {
            index = this.layerList.indexOf(layerInterface);
            if (index >= 0) {
                this.positionList.removeAt(index);
                this.layerList.removeAt(index);
            }
        }
    }

    public virtual void clear()
    {
        this.positionList.clear();
        this.layerList.clear();
    }

    public virtual bool isCellPositionWithDrop(CellPosition cellPosition)
    {
        return this.positionList.contains(cellPosition);
    }

    public virtual bool anyCellPositionWithDrop(BasicArrayList list)
    {
        for (int index = list.size() - 1; index >= 0; index--) {
            if (this.isCellPositionWithDrop(((CellPosition) list.get(index)))) {
                return true;
            }
        }
        return false;
    }

    public virtual AllBinaryLayer getLayerInterface(CellPosition cellPosition)
    {
        int index = this.positionList.indexOf(cellPosition);
        if (index >= 0) {
            return ((AllBinaryLayer) this.layerList.get(index));
        } else {
            return AllBinaryLayer.NULL_ALLBINARY_LAYER;
        }
    }

}

