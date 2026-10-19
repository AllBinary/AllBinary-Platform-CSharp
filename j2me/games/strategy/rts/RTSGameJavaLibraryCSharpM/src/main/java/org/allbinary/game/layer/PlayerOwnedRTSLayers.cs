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
using StringMaker = org.allbinary.logic.@string.StringMaker;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.game.layer;

public class PlayerOwnedRTSLayers
{
    public readonly BasicArrayList rtsLayerList = new BasicArrayListD();
    public override string ToString()
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append("All: ");
        stringBuffer.appendint(this.rtsLayerList.size());
        return stringBuffer.ToString();
    }

}

