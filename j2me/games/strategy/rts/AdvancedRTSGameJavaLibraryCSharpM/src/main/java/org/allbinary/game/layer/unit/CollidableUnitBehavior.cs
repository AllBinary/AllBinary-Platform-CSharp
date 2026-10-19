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
//using Canvas = javax.microedition.lcdui.Canvas;
using SteeringVisitor = org.allbinary.game.layer.SteeringVisitor;
using AdvancedRTSGameLayer = org.allbinary.game.layer.AdvancedRTSGameLayer;
using CollidableCompositeLayer = org.allbinary.game.layer.CollidableCompositeLayer;
using CollidableRTSBehavior = org.allbinary.game.layer.CollidableRTSBehavior;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using GameKeyEventFactory = org.allbinary.game.input.@event.GameKeyEventFactory;
using AllBinaryTiledLayer = org.allbinary.game.layer.AllBinaryTiledLayer;
using TiledLayerUtil = org.allbinary.game.layer.TiledLayerUtil;
using LayerPartialCellPositionsUtil = org.allbinary.game.layer.geographic.map.LayerPartialCellPositionsUtil;
using NullUtil = org.allbinary.logic.NullUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using BooleanFactory = org.allbinary.logic.java.@bool.BooleanFactory;
using AngleInfo = org.allbinary.math.AngleInfo;
using BasicGeographicMap = org.allbinary.media.graphics.geography.map.BasicGeographicMap;
using GeographicMapCompositeInterface = org.allbinary.media.graphics.geography.map.GeographicMapCompositeInterface;
using DropCellPositionHistory = org.allbinary.media.graphics.geography.map.drop.DropCellPositionHistory;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.game.layer.unit;

public class CollidableUnitBehavior : CollidableRTSBehavior
{
    private readonly LayerPartialCellPositionsUtil layerPartialCellPositionsUtil = LayerPartialCellPositionsUtil.getInstance();
    public CollidableUnitBehavior(bool collidable) : base(collidable)
    {
        // base(collidable) is called from the constructor declaration
    }

    // throws Exception
    protected override void collideNone(CollidableCompositeLayer ownerLayer, CollidableCompositeLayer collidableInterfaceCompositeInterface)
    {
        this.chase(ownerLayer, collidableInterfaceCompositeInterface);
        AdvancedRTSGameLayer rtsLayer = ((AdvancedRTSGameLayer) collidableInterfaceCompositeInterface);
        if (rtsLayer.getType() == UnitLayer.getStaticType()) {
            this.collideUnit(ownerLayer, ((UnitLayer) rtsLayer));
        }
    }

    private class SimpleSteeringVisitor : SteeringVisitor
    {
        public override object visit(object anyType)
        {
            LogUtil logUtil = LogUtil.getInstance();
            try {
                CollidableCompositeLayer ownerLayer = ((CollidableCompositeLayer) anyType);
                if (this.getList().size() > 0) {
                    CollidableCompositeLayer allbinaryLayer = ((CollidableCompositeLayer) this.getList().get(0));
                    bool clear = this.steer(ownerLayer, allbinaryLayer);
                    if (clear) {
                        this.getList().clear();
                        return NullUtil.getInstance().NULL_OBJECT;
                    }
                    return BooleanFactory.getInstance().TRUE;
                }
                return NullUtil.getInstance().NULL_OBJECT;
            } catch (Exception e) {
                CommonStrings commonStrings = CommonStrings.getInstance();
                logUtil.put(commonStrings.EXCEPTION, this, "visit", e);
                return NullUtil.getInstance().NULL_OBJECT;
            }
        }

    }
    private readonly SimpleSteeringVisitor simpleSteeringVisitor = new SimpleSteeringVisitor();
    // throws Exception
    private bool steer(CollidableCompositeLayer ownerLayer, CollidableCompositeLayer collidableInterfaceCompositeInterface)
    {
        UnitLayer ownerUnitLayer = ((UnitLayer) ownerLayer);
        UnitLayer unitLayer = ((UnitLayer) collidableInterfaceCompositeInterface);
        AngleInfo angleInfo2 = unitLayer.getRotationAnimationInterface().getAngleInfoP();
        AngleInfo angleInfo = ownerUnitLayer.getRotationAnimationInterface().getAngleInfoP();
        int angle = angleInfo.getAngle() - angleInfo2.getAngle();
        if (angle < 90 || angle > 270) {
            return true;
        } else if (angle >= 90 || angle <= 270) {
            ownerUnitLayer.getGameKeyEventList().add(GameKeyEventFactory.getInstance().getInstanceForKey(ownerUnitLayer, Canvas.RIGHT));
            return false;
        }
        throw new Exception("Error");
    }

    // throws Exception
    private void chase(CollidableCompositeLayer ownerLayer, CollidableCompositeLayer collidableInterfaceCompositeInterface)
    {
        AdvancedRTSGameLayer rtsLayer = ((AdvancedRTSGameLayer) collidableInterfaceCompositeInterface);
        if (rtsLayer.getType() == UnitLayer.getStaticType()) {
            if (!this.simpleSteeringVisitor.getList().contains(collidableInterfaceCompositeInterface)) {
                this.simpleSteeringVisitor.getList().add(collidableInterfaceCompositeInterface);
            }
            UnitLayer ownerUnitLayer = ((UnitLayer) ownerLayer);
            BasicArrayList list = ownerUnitLayer.getUnitWaypointBehavior().getSteeringVisitorList();
            if (!list.contains(this.simpleSteeringVisitor)) {
                list.add(this.simpleSteeringVisitor);
            }
        }
    }

    // throws Exception
    protected virtual void collideUnit(CollidableCompositeLayer ownerLayer, UnitLayer unitLayer)
    {
        UnitLayer ownerUnitLayer = ((UnitLayer) ownerLayer);
        BasicArrayList partialPositionList = UnitLayer.getPartialpositionlist();
        GeographicMapCompositeInterface geographicMapCompositeInterface = ((GeographicMapCompositeInterface) ownerUnitLayer.allBinaryGameLayerManagerP);
        BasicGeographicMap geographicMapInterface = geographicMapCompositeInterface.getGeographicMapInterface()[0];
        BasicGeographicMap basicGeographicMap = geographicMapInterface;
        DropCellPositionHistory dropCellPositionHistory = DropCellPositionHistory.getInstance();
        TiledLayerUtil tiledLayerUtil = TiledLayerUtil.getInstance();
        AllBinaryTiledLayer tiledLayer = basicGeographicMap.getAllBinaryTiledLayer();
        if (ownerLayer.getXP() < unitLayer.getXP() && ownerLayer.getX2() > unitLayer.getXP()) {
            int diff = ownerLayer.getWidth() + 1;
            this.layerPartialCellPositionsUtil.getAllDXY(basicGeographicMap, ownerLayer, -diff, 0, partialPositionList);
            if (!dropCellPositionHistory.anyCellPositionWithDrop(partialPositionList)) {
                int x = unitLayer.getXP() - diff;
                int y = ownerLayer.getYP();
                x = tiledLayerUtil.keepOnMapX(tiledLayer, x, ownerLayer.getWidth());
                y = tiledLayerUtil.keepOnMapY(tiledLayer, y, ownerLayer.getHeight());
                ownerLayer.setPosition(x, y, ownerLayer.getZP());
            }
            this.layerPartialCellPositionsUtil.getAllDXY(basicGeographicMap, unitLayer, diff, 0, partialPositionList);
            if (!dropCellPositionHistory.anyCellPositionWithDrop(partialPositionList)) {
                int x = unitLayer.getXP() + diff;
                int y = unitLayer.getYP();
                x = tiledLayerUtil.keepOnMapX(tiledLayer, x, unitLayer.getWidth());
                y = tiledLayerUtil.keepOnMapY(tiledLayer, y, unitLayer.getHeight());
                unitLayer.setPosition(x, y, unitLayer.getZP());
            }
        }
        if (ownerLayer.getYP() < unitLayer.getYP() && ownerLayer.getY2() > unitLayer.getYP()) {
            int diff = ownerLayer.getHeight() + 1;
            this.layerPartialCellPositionsUtil.getAllDXY(basicGeographicMap, ownerLayer, 0, -diff, partialPositionList);
            if (!dropCellPositionHistory.anyCellPositionWithDrop(partialPositionList)) {
                int x = ownerLayer.getXP();
                int y = unitLayer.getYP() - diff;
                x = tiledLayerUtil.keepOnMapX(tiledLayer, x, ownerLayer.getWidth());
                y = tiledLayerUtil.keepOnMapY(tiledLayer, y, ownerLayer.getHeight());
                ownerLayer.setPosition(x, y, ownerLayer.getZP());
            }
            this.layerPartialCellPositionsUtil.getAllDXY(basicGeographicMap, unitLayer, 0, diff, partialPositionList);
            if (!dropCellPositionHistory.anyCellPositionWithDrop(partialPositionList)) {
                int x = unitLayer.getXP();
                int y = unitLayer.getYP() + diff;
                x = tiledLayerUtil.keepOnMapX(tiledLayer, x, unitLayer.getWidth());
                y = tiledLayerUtil.keepOnMapY(tiledLayer, y, unitLayer.getHeight());
                unitLayer.setPosition(x, y, unitLayer.getZP());
            }
        }
    }

}

