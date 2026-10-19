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

namespace org.allbinary.game.layer;

public class RTSLayer2LogHelper
{
    private static readonly RTSLayer2LogHelper instance = new RTSLayer2LogHelper();
    public static RTSLayer2LogHelper getInstance()
    {
        return RTSLayer2LogHelper.instance;
    }

    public virtual void steeringUp(PathFindingLayerInterface pathFindingLayerInterface)
    {
    }

    public virtual void steeringFireOrStop(PathFindingLayerInterface pathFindingLayerInterface)
    {
    }

    public virtual void buildingAbove(PathFindingLayerInterface pathFindingLayerInterface)
    {
    }

    public virtual void buildingChaseLeft(PathFindingLayerInterface pathFindingLayerInterface, int angle)
    {
    }

    public virtual void buildingChaseRight(PathFindingLayerInterface pathFindingLayerInterface, int angle)
    {
    }

    public virtual void buildingDown(PathFindingLayerInterface pathFindingLayerInterface)
    {
    }

    public virtual void buildingChaseDown(PathFindingLayerInterface pathFindingLayerInterface, int angle)
    {
    }

    public virtual void buildingChaseUp(PathFindingLayerInterface pathFindingLayerInterface, int angle)
    {
    }

    public virtual void buildingLeft()
    {
    }

    public virtual void buildingRight()
    {
    }

}

