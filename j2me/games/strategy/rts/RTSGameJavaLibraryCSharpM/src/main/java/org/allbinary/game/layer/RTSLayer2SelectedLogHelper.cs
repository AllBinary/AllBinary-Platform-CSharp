/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2022 AllBinary 
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
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;

namespace org.allbinary.game.layer;

public class RTSLayer2SelectedLogHelper : RTSLayer2LogHelper
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly RTSLayer2SelectedLogHelper instanceC = new RTSLayer2SelectedLogHelper();
    public static RTSLayer2SelectedLogHelper getInstance()
    {
        return RTSLayer2SelectedLogHelper.instanceC;
    }

    private readonly string TRACK_TO_FIRE_OR_MOVE = "trackTo:fireOrMove";
    private readonly string BUILDING_CHASE = "buildingChase";
    public override void steeringUp(PathFindingLayerInterface pathFindingLayerInterface)
    {
        this.logUtil.putF(new StringMaker().append(pathFindingLayerInterface.getName()).append(" steering - Up").ToString(), this, this.TRACK_TO_FIRE_OR_MOVE);
    }

    public override void steeringFireOrStop(PathFindingLayerInterface pathFindingLayerInterface)
    {
        this.logUtil.putF(new StringMaker().append(pathFindingLayerInterface.getName()).append(" steering - Fire/All Stop").ToString(), this, this.TRACK_TO_FIRE_OR_MOVE);
    }

    public override void buildingAbove(PathFindingLayerInterface pathFindingLayerInterface)
    {
        this.logUtil.putF(new StringMaker().append(pathFindingLayerInterface.getName()).append(" Building Above").ToString(), this, this.BUILDING_CHASE);
    }

    public override void buildingChaseLeft(PathFindingLayerInterface pathFindingLayerInterface, int angle)
    {
        this.logUtil.putF(new StringMaker().append(pathFindingLayerInterface.getName()).append(" steering - Going Left: ").appendint(angle).ToString(), this, this.BUILDING_CHASE);
    }

    public override void buildingChaseRight(PathFindingLayerInterface pathFindingLayerInterface, int angle)
    {
        this.logUtil.putF(new StringMaker().append(pathFindingLayerInterface.getName()).append(" steering - Going Right: ").appendint(angle).ToString(), this, this.BUILDING_CHASE);
    }

    public override void buildingDown(PathFindingLayerInterface pathFindingLayerInterface)
    {
        this.logUtil.putF(new StringMaker().append(pathFindingLayerInterface.getName()).append(" Building Below").ToString(), this, this.BUILDING_CHASE);
    }

    public override void buildingChaseDown(PathFindingLayerInterface pathFindingLayerInterface, int angle)
    {
        this.logUtil.putF(new StringMaker().append(pathFindingLayerInterface.getName()).append(" steering - Going Down: ").appendint(angle).ToString(), this, this.BUILDING_CHASE);
    }

    public override void buildingChaseUp(PathFindingLayerInterface pathFindingLayerInterface, int angle)
    {
        this.logUtil.putF(new StringMaker().append(pathFindingLayerInterface.getName()).append(" steering - Going Up: ").appendint(angle).ToString(), this, this.BUILDING_CHASE);
    }

    public virtual void buildingLeft(PathFindingLayerInterface pathFindingLayerInterface)
    {
        this.logUtil.putF(new StringMaker().append(pathFindingLayerInterface.getName()).append(" Building Left").ToString(), this, this.BUILDING_CHASE);
    }

    public virtual void buildingRight(PathFindingLayerInterface pathFindingLayerInterface)
    {
        this.logUtil.putF(new StringMaker().append(pathFindingLayerInterface.getName()).append(" Building Right").ToString(), this, this.BUILDING_CHASE);
    }

}

