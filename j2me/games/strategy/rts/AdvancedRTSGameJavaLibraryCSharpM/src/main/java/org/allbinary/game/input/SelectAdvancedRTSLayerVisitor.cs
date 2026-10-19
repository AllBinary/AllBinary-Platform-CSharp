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
using AssignWaypointsUtil = org.allbinary.game.input.form.AssignWaypointsUtil;
using AdvancedRTSGameLayer = org.allbinary.game.layer.AdvancedRTSGameLayer;
using RTSLayer = org.allbinary.game.layer.RTSLayer;
using BuildingLayer = org.allbinary.game.layer.building.BuildingLayer;
using CollidableDestroyableDamageableLayer = org.allbinary.game.layer.special.CollidableDestroyableDamageableLayer;
using UnitLayer = org.allbinary.game.layer.unit.UnitLayer;
using NullUtil = org.allbinary.logic.NullUtil;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using Visitor = org.allbinary.logic.util.visitor.Visitor;

namespace org.allbinary.game.input;

public class SelectAdvancedRTSLayerVisitor : Visitor
{
    private readonly SelectedRTSLayersPlayerGameInput selectedRTSLayersPlayerGameInput;
    public SelectAdvancedRTSLayerVisitor(SelectedRTSLayersPlayerGameInput selectedRTSLayersPlayerGameInput)
    {
        this.selectedRTSLayersPlayerGameInput = selectedRTSLayersPlayerGameInput;
    }

    public override object visit(object anyType)
    {
        CollidableDestroyableDamageableLayer selectedLayer = ((CollidableDestroyableDamageableLayer) anyType);
        if (selectedLayer != CollidableDestroyableDamageableLayer.getNullInstance() && selectedLayer.getType() == BuildingLayer.getStaticType()) {
            AdvancedRTSGameLayer rtsGameLayer = ((AdvancedRTSGameLayer) selectedLayer);
            AssignWaypointsUtil assignWaypointsUtil = AssignWaypointsUtil.getInstance();
            BasicArrayList list = this.selectedRTSLayersPlayerGameInput.getSelectedBasicArrayList();
            RTSLayer currentRTSLayer = null;
            UnitLayer unitLayer = null;
            for (int index = list.size() - 1; index >= 0; index--) {
                currentRTSLayer = ((RTSLayer) list.get(index));
                if (currentRTSLayer.getType() == UnitLayer.getStaticType()) {
                    unitLayer = ((UnitLayer) currentRTSLayer);
                    unitLayer.setParentLayer(rtsGameLayer);
                    assignWaypointsUtil.set(unitLayer, rtsGameLayer);
                }
            }
        }
        return NullUtil.getInstance().NULL_OBJECT;
    }

}

