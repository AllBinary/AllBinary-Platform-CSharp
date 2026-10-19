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
using NullUtil = org.allbinary.logic.NullUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using AllBinaryEventObject = org.allbinary.logic.util.@event.AllBinaryEventObject;

namespace org.allbinary.game.terrain;

public class TerrainEvent : AllBinaryEventObject
{
    private BasicTerrainInfo basicTerrainInfo = BasicTerrainInfo.NULL_BASIC_TERRAIN_INFO;
    public TerrainEvent(object basicTerrainInfo) : base(basicTerrainInfo)
    {
        // base(basicTerrainInfo) is called from the constructor declaration
        this.setBasicTerrainInfo(this.basicTerrainInfo);
    }

    public override string ToString()
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append("TerrainEvent: \n");
        stringBuffer.append("LayerInterface: ");
        stringBuffer.append(this.basicTerrainInfo.ToString());
        return stringBuffer.ToString();
    }

    public virtual BasicTerrainInfo getBasicTerrainInfo()
    {
        return this.basicTerrainInfo;
    }

    public virtual void setBasicTerrainInfo(BasicTerrainInfo basicTerrainInfo)
    {
        this.basicTerrainInfo = basicTerrainInfo;
    }

    public virtual void setBasicTerrainInfoForCircularStaticPool(BasicTerrainInfo basicTerrainInfo)
    {
        this.basicTerrainInfo = basicTerrainInfo;
    }

}

