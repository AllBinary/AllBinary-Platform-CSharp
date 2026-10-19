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
using DamageFloaters = org.allbinary.game.combat.damage.DamageFloaters;
using PtsDamageFloaters = org.allbinary.game.combat.damage.PtsDamageFloaters;
using Features = org.allbinary.game.configuration.feature.Features;
using GameFeatureFactory = org.allbinary.game.configuration.feature.GameFeatureFactory;
using BasicHudFactory = org.allbinary.game.graphics.hud.BasicHudFactory;
using HealthBar = org.allbinary.game.health.HealthBar;
using HealthBarTwodAnimation = org.allbinary.game.health.HealthBarTwodAnimation;
using TrackingEvent = org.allbinary.game.tracking.TrackingEvent;
using NullPaintable = org.allbinary.graphics.paint.NullPaintable;
using Paintable = org.allbinary.graphics.paint.Paintable;
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;
using StdUtil = org.allbinary.logic.StdUtil;
using org.allbinary.util;

namespace org.allbinary.game.layer.building;

public class BuildingPropertiesFactory
{
    private static readonly BuildingPropertiesFactory instance = new BuildingPropertiesFactory();
    public static BuildingPropertiesFactory getInstance()
    {
        return BuildingPropertiesFactory.instance;
    }

    public virtual int getEfficiencyPerLevel(BuildingLayer buildingLayer)
    {
        return 10000 / buildingLayer.getMaxLevel() + 10000 % buildingLayer.getMaxLevel();
    }

    public Paintable damageFloatersPaintableInterface = NullPaintable.getInstance();
    public virtual DamageFloaters getDamageFloaters(BuildingLayer buildingLayer)
    {
        DamageFloaters damageFloaters = DamageFloaters.getInstance();
        if (Features.getInstance().isFeature(GameFeatureFactory.getInstance().DAMAGE_FLOATERS)) {
            damageFloaters = new PtsDamageFloaters(buildingLayer);
            this.damageFloatersPaintableInterface = damageFloaters;
        } else {
            damageFloaters = new DamageFloaters();
        }
        return damageFloaters;
    }

    // throws Exception
    public virtual Paintable getHealthBar(BuildingLayer buildingLayer)
    {
        Paintable healthBar = NullPaintable.getInstance();
        if (Features.getInstance().isFeature(GameFeatureFactory.getInstance().HEALTH_BARS)) {
            healthBar = new HealthBar(buildingLayer, buildingLayer.getHealthInterface(), new HealthBarTwodAnimation(((AllBinaryLayer) buildingLayer), BasicHudFactory.getInstance().BOTTOMLEFT), -1);
        }
        return healthBar;
    }

    public virtual ABHashtable<object, object> getHashtable()
    {
        return StdUtil.getInstance().createHashtable();
    }

    public virtual TrackingEvent getTrackingEvent(BuildingLayer buildingLayer)
    {
        return new TrackingEvent(buildingLayer);
    }

}

