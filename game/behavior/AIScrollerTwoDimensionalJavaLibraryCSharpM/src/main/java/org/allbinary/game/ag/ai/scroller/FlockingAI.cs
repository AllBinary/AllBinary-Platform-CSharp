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
//using Canvas = javax.microedition.lcdui.Canvas;
using BasicAI = org.allbinary.game.ai.BasicAI;
using BasicGroupFactory = org.allbinary.game.identification.BasicGroupFactory;
using GameInput = org.allbinary.game.input.GameInput;
using GroupLayerManagerListener = org.allbinary.game.layer.identification.GroupLayerManagerListener;
using WeaponLayer = org.allbinary.game.layer.weapon.WeaponLayer;
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;
using AllBinaryLayerManager = org.allbinary.layer.AllBinaryLayerManager;
using MathUtil = org.allbinary.logic.math.MathUtil;
using org.allbinary.util;
using BasicArrayList = org.allbinary.util.BasicArrayList;

namespace org.allbinary.game.ag.ai.scroller;

public class FlockingAI : BasicAI
{
    private readonly int allowedDistance;
    public FlockingAI(ABHashtable<object, object> hashtable, AllBinaryLayer ownerLayerInterface, GameInput gameInput) : base(ownerLayerInterface, gameInput)
    {
        // base(ownerLayerInterface, gameInput) is called from the constructor declaration
        int? allowedDistance = ((int?) hashtable.get(BasePatrolAI.MAX_DISTANCE));
        this.allowedDistance = allowedDistance.intValue();
    }

    // throws Exception
    public override void processAI(AllBinaryLayerManager allBinaryLayerManager)
    {
        int maxDistance = 0;
        AllBinaryLayer farAllbinaryLayer = AllBinaryLayer.NULL_ALLBINARY_LAYER;
        GroupLayerManagerListener groupLayerManagerListener = GroupLayerManagerListener.getInstance();
        BasicArrayList list = groupLayerManagerListener.getList(BasicGroupFactory.getInstance().ENEMY);
        int size = list.size();
        AllBinaryLayer allBinaryLayer = null;
        AllBinaryLayer ownerLayerInterface = null;
        for (int index = 0; index < size; index++) {
            allBinaryLayer = ((AllBinaryLayer) list.get(index));
            if (allBinaryLayer.getType() != WeaponLayer.getStaticType()) {
                int distance = this.getXYDistance(allBinaryLayer);
                if (distance > maxDistance) {
                    maxDistance = distance;
                    farAllbinaryLayer = allBinaryLayer;
                    if (distance > this.allowedDistance) {
                        break;
                    }
                }
            }
        }
        if (maxDistance > this.allowedDistance) {
            if (farAllbinaryLayer != AllBinaryLayer.NULL_ALLBINARY_LAYER) {
                ownerLayerInterface = this.getOwnerLayerInterface();
                if (farAllbinaryLayer.getXP() < ownerLayerInterface.getXP()) {
                    this.processKeyAI(Canvas.LEFT);
                } else if (farAllbinaryLayer.getXP() > ownerLayerInterface.getXP()) {
                    this.processKeyAI(Canvas.RIGHT);
                } else if (farAllbinaryLayer.getYP() > ownerLayerInterface.getYP()) {
                    this.processKeyAI(Canvas.UP);
                } else if (farAllbinaryLayer.getYP() < ownerLayerInterface.getYP()) {
                    this.processKeyAI(Canvas.DOWN);
                }
            }
        }
    }

    private int getXYDistance(AllBinaryLayer allBinaryLayer)
    {
        AllBinaryLayer ownerLayerInterface = this.getOwnerLayerInterface();
        int xTotalDistance = (allBinaryLayer.getXP() + allBinaryLayer.getHalfWidth()) - (ownerLayerInterface.getXP() + ownerLayerInterface.getHalfWidth());
        int yTotalDistance = (allBinaryLayer.getYP() + allBinaryLayer.getHalfHeight()) - (ownerLayerInterface.getYP() + ownerLayerInterface.getHalfHeight());
        MathUtil mathUtil = MathUtil.getInstance();
        int totalDistance = mathUtil.abs(xTotalDistance) + mathUtil.abs(yTotalDistance);
        return totalDistance;
    }

}

