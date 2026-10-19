/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2003 AllBinary 
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
using GroupCommonFactory = org.allbinary.game.identification.GroupCommonFactory;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using DirectionFactory = org.allbinary.direction.DirectionFactory;
using GameInfo = org.allbinary.game.GameInfo;
using WeaponProperties = org.allbinary.game.combat.weapon.WeaponProperties;
using BasicGroupFactory = org.allbinary.game.identification.BasicGroupFactory;
using PartInterface = org.allbinary.game.part.PartInterface;
using BasicWeaponPart = org.allbinary.game.part.weapon.BasicWeaponPart;
using StdUtil = org.allbinary.logic.StdUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using BasicGeographicMap = org.allbinary.media.graphics.geography.map.BasicGeographicMap;
using BaseRaceTrackGeographicMap = org.allbinary.media.graphics.geography.map.racetrack.BaseRaceTrackGeographicMap;
using org.allbinary.util;

namespace org.allbinary.game.layer;

public class RTSLayerUtil
{
    private static readonly RTSLayerUtil instance = new RTSLayerUtil();
    public static RTSLayerUtil getInstance()
    {
        return RTSLayerUtil.instance;
    }

    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly GroupCommonFactory groupCommonFactory = GroupCommonFactory.getInstance();
    private WeaponProperties createWeaponProperties(WeaponProperties weaponProperties, int currentLevel, int lastLevel)
    {
        long reloadTime = weaponProperties.getReloadTime();
        if (lastLevel > currentLevel) {
            reloadTime = reloadTime + 50L;
        } else if (lastLevel < currentLevel) {
            reloadTime = reloadTime - 50L;
        }
        WeaponProperties newWeaponProperties = new WeaponProperties(reloadTime, weaponProperties.getTargetingTime(), weaponProperties.getSpeed().getUnscaled(), weaponProperties.getDamage() / lastLevel * currentLevel, weaponProperties.getDissipation());
        return newWeaponProperties;
    }

    public virtual void downgrade(RTSLayer rtsLayer)
    {
        rtsLayer.setLevel(rtsLayer.getLevel() - 1);
        PartInterface[] partInterfaceArray = rtsLayer.getPartInterfaceArray();
        int size = partInterfaceArray.Length;
        BasicWeaponPart partInterface = null;
        for (int index = size; --index >= 0; ) {
            partInterface = ((BasicWeaponPart) partInterfaceArray[index]);
            partInterface.setWeaponProperties(this.createWeaponProperties(partInterface.getWeaponProperties(), rtsLayer.getLevel(), rtsLayer.getLevel() + 1));
        }
        rtsLayer.select();
    }

    public virtual void upgrade(RTSLayer rtsLayer)
    {
        rtsLayer.setLevel(rtsLayer.getLevel() + 1);
        PartInterface[] partInterfaceArray = rtsLayer.getPartInterfaceArray();
        int size = partInterfaceArray.Length;
        BasicWeaponPart partInterface = null;
        for (int index = size; --index >= 0; ) {
            partInterface = ((BasicWeaponPart) partInterfaceArray[index]);
            partInterface.setWeaponProperties(this.createWeaponProperties(partInterface.getWeaponProperties(), rtsLayer.getLevel(), rtsLayer.getLevel() - 1));
        }
        rtsLayer.select();
    }

    private readonly long MAX_RELOAD_TIME = ((long) Integer.MAX_VALUE) / 100000L;
    public virtual long getCostExponential(long cost)
    {
        return ((cost * cost * cost) / (cost * 1000L));
    }

    private int getWeaponPropertiesCost(WeaponProperties weaponProperties)
    {
        long cost = (weaponProperties.getDamage() + weaponProperties.getRange() + ((this.MAX_RELOAD_TIME / weaponProperties.getReloadTime()) >> 1));
        cost = this.getCostExponential(cost);
        return ((int) cost);
    }

    public virtual int getCost(RTSLayer rtsLayer)
    {
        int total = 0;
        PartInterface[] partInterfaceArray = rtsLayer.getPartInterfaceArray();
        int size = partInterfaceArray.Length;
        BasicWeaponPart partInterface = null;
        WeaponProperties weaponProperties = null;
        for (int index = size - 1; index >= 0; index--) {
            partInterface = ((BasicWeaponPart) partInterfaceArray[index]);
            weaponProperties = partInterface.getWeaponProperties();
            total += this.getWeaponPropertiesCost(weaponProperties);
        }
        return total;
    }

    public virtual int getDowngradeCost(RTSLayer rtsLayer)
    {
        PartInterface[] partInterfaceArray = rtsLayer.getPartInterfaceArray();
        int size = partInterfaceArray.Length;
        int downgradeCost = 0;
        BasicWeaponPart partInterface = null;
        WeaponProperties weaponProperties = null;
        int downgradeWeaponCost = 0;
        int currentWeaponCost = 0;
        for (int index = size - 1; index >= 0; index--) {
            partInterface = ((BasicWeaponPart) partInterfaceArray[index]);
            weaponProperties = partInterface.getWeaponProperties();
            downgradeWeaponCost = this.getWeaponPropertiesCost(this.createWeaponProperties(weaponProperties, rtsLayer.getLevel() - 1, rtsLayer.getLevel()));
            currentWeaponCost = this.getWeaponPropertiesCost(weaponProperties);
            downgradeCost += (currentWeaponCost - downgradeWeaponCost);
        }
        downgradeCost = downgradeCost * 9 / 10;
        this.logUtil.putF(new StringMaker().append("Total Cost: ").appendint(downgradeCost).ToString(), this, "getDowngradeCost");
        return downgradeCost;
    }

    public virtual int getUpgradeCost(RTSLayer rtsLayer)
    {
        int upgradeCost = 0;
        PartInterface[] partInterfaceArray = rtsLayer.getPartInterfaceArray();
        int size = partInterfaceArray.Length;
        BasicWeaponPart partInterface = null;
        WeaponProperties weaponProperties = null;
        int upgradedWeaponCost = 0;
        int currentWeaponCost = 0;
        for (int index = size - 1; index >= 0; index--) {
            partInterface = ((BasicWeaponPart) partInterfaceArray[index]);
            weaponProperties = partInterface.getWeaponProperties();
            upgradedWeaponCost = this.getWeaponPropertiesCost(this.createWeaponProperties(weaponProperties, rtsLayer.getLevel() + 1, rtsLayer.getLevel()));
            currentWeaponCost = this.getWeaponPropertiesCost(weaponProperties);
            upgradeCost += (upgradedWeaponCost - currentWeaponCost);
        }
        this.logUtil.putF(new StringMaker().append("Total Cost: ").appendint(upgradeCost).ToString(), this, "getUpgradeCost");
        return upgradeCost;
    }

    // throws Exception
    public void destroyAndClear(BasicArrayList list)
    {
        RTSLayer rtsLayer = null;
        for (int index = list.size() - 1; index >= 0; index--) {
            rtsLayer = ((RTSLayer) list.get(index));
            rtsLayer.setDestroyed(true);
        }
        list.clear();
    }

    public ABHashtable<object, object> createFakeRTSLayerHashtable(BaseRaceTrackGeographicMap baseRaceTrackGeographicMap)
    {
        ABHashtable<object, object> hashtable = StdUtil.getInstance().createHashtable();
        FakeLayerManager layerManager = new FakeLayerManager(GameInfo.NONE);
        layerManager.setGeographicMapInterface(new BasicGeographicMap[] { baseRaceTrackGeographicMap });
        hashtable.put(AllBinaryGameLayerManager.ID, layerManager);
        hashtable.put(DirectionFactory.getInstance().NAME, DirectionFactory.getInstance().LEFT);
        hashtable.put(this.groupCommonFactory.ID, BasicGroupFactory.getInstance().NONE_ARRAY);
        return hashtable;
    }

}

