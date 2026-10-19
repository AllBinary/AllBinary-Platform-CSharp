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
using PathFindingLayerInterface = org.allbinary.game.layer.PathFindingLayerInterface;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;
using StringMaker = org.allbinary.logic.@string.StringMaker;

namespace org.allbinary.game.layer.waypoint;

public class WaypointRunnableSelectedLogHelper : WaypointRunnableLogHelper
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly WaypointRunnableSelectedLogHelper instanceC = new WaypointRunnableSelectedLogHelper();
    public static WaypointRunnableSelectedLogHelper getInstance()
    {
        return WaypointRunnableSelectedLogHelper.instanceC;
    }

    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    public override void start(PathFindingLayerInterface pathFindingLayerInterface)
    {
        this.logUtil.putF(new StringMaker().append(pathFindingLayerInterface.getName()).append(this.commonStrings.START_RUNNABLE).ToString(), this, this.commonStrings.RUN);
    }

    public override void end(PathFindingLayerInterface pathFindingLayerInterface)
    {
        this.logUtil.putF(new StringMaker().append(pathFindingLayerInterface.getName()).append(this.commonStrings.END_RUNNABLE).ToString(), this, this.commonStrings.RUN);
    }

}

