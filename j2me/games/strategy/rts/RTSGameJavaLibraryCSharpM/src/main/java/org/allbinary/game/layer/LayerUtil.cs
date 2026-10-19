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
using CommonSeps = org.allbinary.@string.CommonSeps;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using PositionStrings = org.allbinary.math.PositionStrings;
using org.allbinary.util;

namespace org.allbinary.game.layer;

public class LayerUtil
{
    private static readonly string HASHTABLE = "Hashtable: ";
    public static string toString(ABHashtable<object, object> hashtable, int x, int y, int z)
    {
        CommonSeps commonSeps = CommonSeps.getInstance();
        PositionStrings positionStrings = PositionStrings.getInstance();
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(LayerUtil.HASHTABLE);
        stringBuffer.append(StringUtil.getInstance().toString(hashtable));
        stringBuffer.append(commonSeps.SPACE);
        stringBuffer.append(positionStrings.X_LABEL);
        stringBuffer.appendint(x);
        stringBuffer.append(commonSeps.SPACE);
        stringBuffer.append(positionStrings.Y_LABEL);
        stringBuffer.appendint(y);
        stringBuffer.append(commonSeps.SPACE);
        stringBuffer.append(positionStrings.Z_LABEL);
        stringBuffer.appendint(z);
        return stringBuffer.ToString();
    }

}

