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
using StringMaker = org.allbinary.logic.@string.StringMaker;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.game.layer;

public class AdvancedPlayerOwnedRTSLayers : PlayerOwnedRTSLayers
{
    private readonly BasicArrayList unitsList = new BasicArrayListD();
    private readonly BasicArrayList waypointsList = new BasicArrayListD();
    private readonly BasicArrayList buildingList = new BasicArrayListD();
    private readonly BasicArrayList baseList = new BasicArrayListD();
    private readonly BasicArrayList garrisonList = new BasicArrayListD();
    private readonly BasicArrayList houseList = new BasicArrayListD();
    private readonly BasicArrayList labList = new BasicArrayListD();
    private readonly BasicArrayList factoryList = new BasicArrayListD();
    public virtual void addUnit(RTSLayer rtsLayer)
    {
        this.unitsList.add(rtsLayer);
        this.rtsLayerList.add(rtsLayer);
    }

    public virtual void addWaypoint(RTSLayer rtsLayer)
    {
        this.waypointsList.add(rtsLayer);
        this.rtsLayerList.add(rtsLayer);
    }

    public virtual void addBase(RTSLayer rtsLayer)
    {
        this.baseList.add(rtsLayer);
        this.buildingList.add(rtsLayer);
        this.rtsLayerList.add(rtsLayer);
    }

    public virtual void addGarrison(RTSLayer rtsLayer)
    {
        this.garrisonList.add(rtsLayer);
        this.buildingList.add(rtsLayer);
        this.rtsLayerList.add(rtsLayer);
    }

    public virtual void addHouse(RTSLayer rtsLayer)
    {
        this.houseList.add(rtsLayer);
        this.buildingList.add(rtsLayer);
        this.rtsLayerList.add(rtsLayer);
    }

    public virtual void addLab(RTSLayer rtsLayer)
    {
        this.labList.add(rtsLayer);
        this.buildingList.add(rtsLayer);
        this.rtsLayerList.add(rtsLayer);
    }

    public virtual void addFactory(RTSLayer rtsLayer)
    {
        this.factoryList.add(rtsLayer);
        this.buildingList.add(rtsLayer);
        this.rtsLayerList.add(rtsLayer);
    }

    public virtual void removeUnit(AllBinaryGameLayer gameLayer)
    {
        this.unitsList.remove(gameLayer);
        this.rtsLayerList.remove(gameLayer);
    }

    public virtual void removeWaypoint(AllBinaryGameLayer gameLayer)
    {
        this.waypointsList.remove(gameLayer);
        this.rtsLayerList.remove(gameLayer);
    }

    public virtual BasicArrayList getUnitsList()
    {
        return this.unitsList;
    }

    public virtual BasicArrayList getWaypointsList()
    {
        return this.waypointsList;
    }

    public virtual BasicArrayList getBaseList()
    {
        return this.baseList;
    }

    public virtual BasicArrayList getGarrisonList()
    {
        return this.garrisonList;
    }

    public virtual BasicArrayList getHouseList()
    {
        return this.houseList;
    }

    public virtual BasicArrayList getLabList()
    {
        return this.labList;
    }

    public virtual BasicArrayList getFactoryList()
    {
        return this.factoryList;
    }

    public virtual int getTotalBuildings()
    {
        return this.baseList.size() + this.garrisonList.size() + this.houseList.size() + this.labList.size() + this.factoryList.size();
    }

    public virtual void removeBuilding(AllBinaryGameLayer layerInterface)
    {
        this.buildingList.add(layerInterface);
        if (this.getBaseList().remove(layerInterface)) {
            this.rtsLayerList.remove(layerInterface);
        } else if (this.getFactoryList().remove(layerInterface)) {
            this.rtsLayerList.remove(layerInterface);
        } else if (this.getGarrisonList().remove(layerInterface)) {
            this.rtsLayerList.remove(layerInterface);
        } else if (this.getLabList().remove(layerInterface)) {
            this.rtsLayerList.remove(layerInterface);
        } else if (this.getHouseList().remove(layerInterface)) {
            this.rtsLayerList.remove(layerInterface);
        }
    }

    public override string ToString()
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(base.ToString());
        stringBuffer.append(" Bases: ");
        stringBuffer.appendint(this.getBaseList().size());
        stringBuffer.append(" Factory: ");
        stringBuffer.appendint(this.getFactoryList().size());
        stringBuffer.append(" Garrison: ");
        stringBuffer.appendint(this.getGarrisonList().size());
        stringBuffer.append(" Labs: ");
        stringBuffer.appendint(this.getLabList().size());
        stringBuffer.append(" Houses: ");
        stringBuffer.appendint(this.getHouseList().size());
        stringBuffer.append(" Waypoints: ");
        stringBuffer.appendint(this.getWaypointsList().size());
        stringBuffer.append(" Units: ");
        stringBuffer.appendint(this.getUnitsList().size());
        return stringBuffer.ToString();
    }

    public virtual BasicArrayList getBuildingList()
    {
        return this.buildingList;
    }

}

