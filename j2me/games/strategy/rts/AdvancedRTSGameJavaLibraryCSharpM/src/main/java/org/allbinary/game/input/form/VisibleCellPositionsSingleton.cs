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
//using SimpleTiledLayer = javax.microedition.lcdui.game.SimpleTiledLayer;
//using Graphics = javax.microedition.lcdui.Graphics;
using RTSLayerEvent = org.allbinary.game.layer.RTSLayerEvent;
using BuildingEventListenerInterface = org.allbinary.game.layer.building.@event.BuildingEventListenerInterface;
using LocalPlayerBuildingEventHandler = org.allbinary.game.layer.building.@event.LocalPlayerBuildingEventHandler;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using ForcedLogUtil = org.allbinary.logic.communication.log.ForcedLogUtil;
using CellPosition = org.allbinary.graphics.CellPosition;
using ScrollMapEvent = org.allbinary.layer.@event.ScrollMapEvent;
using ScrollMapEventHandler = org.allbinary.layer.@event.ScrollMapEventHandler;
using ScrollMapEventListenerInterface = org.allbinary.layer.@event.ScrollMapEventListenerInterface;
using NullUtil = org.allbinary.logic.NullUtil;
using AllBinaryEventObject = org.allbinary.logic.util.@event.AllBinaryEventObject;
using EventStrings = org.allbinary.logic.util.@event.EventStrings;

namespace org.allbinary.game.input.form;

public class VisibleCellPositionsSingleton : BuildingEventListenerInterface, ScrollMapEventListenerInterface
{
    private static readonly VisibleCellPositionsSingleton instance = new VisibleCellPositionsSingleton();
    public static VisibleCellPositionsSingleton getInstance()
    {
        return VisibleCellPositionsSingleton.instance;
    }

    private short[][] stationaryVisibleCellPositions = NullUtil.getInstance().NULL_SHORT_ARRAY_ARRAY;
    private short[][] visibleCellPositions = NullUtil.getInstance().NULL_SHORT_ARRAY_ARRAY;
    private short[][] currentlyVisibleCellPositions = NullUtil.getInstance().NULL_SHORT_ARRAY_ARRAY;
    public readonly SimpleTiledLayer ALL_VISIBLE_TILEDLAYER = new SimpleTiledLayer(0, 0, 0, 0);
    private SimpleTiledLayer simpleTiledLayer;
    private SimpleTiledLayer paintSimpleTiledLayer;
    private int currentIndex = 0;
    private VisibleCellPositionsSingleton()
    {
        this.simpleTiledLayer = this.ALL_VISIBLE_TILEDLAYER;
        this.paintSimpleTiledLayer = this.ALL_VISIBLE_TILEDLAYER;
        LocalPlayerBuildingEventHandler.getInstance().addListenerInterface(this);
        ScrollMapEventHandler.getInstance().addListenerInterface(this);
    }

    public virtual void init(SimpleTiledLayer simpleTiledLayer)
    {
        this.paintSimpleTiledLayer = this.ALL_VISIBLE_TILEDLAYER;
        this.currentIndex = 0;
        int rows = simpleTiledLayer.getRows();
        int columns = simpleTiledLayer.getColumns();
        this.stationaryVisibleCellPositions = System.Linq.Enumerable.Range(0, rows).Select(_ => new short[columns]).ToArray();
        this.visibleCellPositions = System.Linq.Enumerable.Range(0, rows).Select(_ => new short[columns]).ToArray();
        this.currentlyVisibleCellPositions = System.Linq.Enumerable.Range(0, rows).Select(_ => new short[columns]).ToArray();
        this.setSimpleTiledLayer(simpleTiledLayer);
    }

    public virtual void onEvent(AllBinaryEventObject eventObject)
    {
        ForcedLogUtil.log(EventStrings.getInstance().PERFORMANCE_MESSAGE, this);
    }

    // throws Exception
    public virtual void onBuildingEvent(RTSLayerEvent @event)
    {
        this.paintSimpleTiledLayer = this.simpleTiledLayer;
    }

    // throws Exception
    public virtual void onMoveEvent(ScrollMapEvent scrollMapEvent)
    {
        this.move(scrollMapEvent.getDx(), scrollMapEvent.getDy());
    }

    public virtual void addStationaryCellPositions(BasicArrayList list)
    {
        for (int index = list.size() - 1; index >= 0; index--) {
            CellPosition cellPosition = ((CellPosition) list.get(index));
            this.stationaryVisibleCellPositions[cellPosition.getRow()][cellPosition.getColumn()]++;
        }
    }

    public virtual void removeStationaryCellPositions(BasicArrayList list)
    {
        for (int index = list.size() - 1; index >= 0; index--) {
            CellPosition cellPosition = ((CellPosition) list.get(index));
            this.stationaryVisibleCellPositions[cellPosition.getRow()][cellPosition.getColumn()]--;
        }
    }

    public virtual void update()
    {
        if (this.currentIndex == 0) {
            short[][] temp = this.currentlyVisibleCellPositions;
            this.currentlyVisibleCellPositions = this.visibleCellPositions;
            this.visibleCellPositions = temp;
            for (int index = this.visibleCellPositions.Length - 1; index >= 0; index--) {
                for (int index2 = this.visibleCellPositions[0].Length - 1; index2 >= 0; index2--) {
                    this.visibleCellPositions[index][index2] = this.stationaryVisibleCellPositions[index][index2];
                }
            }
        }
        this.currentIndex++;
        if (this.currentIndex > 10) {
            this.currentIndex = 0;
        }
    }

    public virtual bool shouldProcess()
    {
        if (this.currentIndex == 0) {
            return true;
        } else {
            return false;
        }
    }

    public virtual void addCellPositions(BasicArrayList list)
    {
        for (int index = list.size() - 1; index >= 0; index--) {
            CellPosition cellPosition = ((CellPosition) list.get(index));
            this.visibleCellPositions[cellPosition.getRow()][cellPosition.getColumn()]++;
        }
    }

    public virtual bool isVisible(CellPosition cellPosition)
    {
        if (this.visibleCellPositions[cellPosition.getRow()][cellPosition.getColumn()] > 0) {
            return true;
        } else {
            return false;
        }
    }

    public virtual void move(int dx, int dy)
    {
        this.getSimpleTiledLayer().moveDXY(dx, dy);
    }

    public virtual void paint(Graphics graphics)
    {
        this.paintSimpleTiledLayer.paint(graphics, this.currentlyVisibleCellPositions);
    }

    private void setSimpleTiledLayer(SimpleTiledLayer simpleTiledLayer)
    {
        this.simpleTiledLayer = simpleTiledLayer;
    }

    public virtual SimpleTiledLayer getSimpleTiledLayer()
    {
        return this.simpleTiledLayer;
    }

}

