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
using BasicDecimal = org.allbinary.logic.math.BasicDecimal;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using PositionStrings = org.allbinary.math.PositionStrings;
using CommonSeps = org.allbinary.@string.CommonSeps;

namespace org.allbinary.logic.math.vector;

public class Vertex
{
    public BasicDecimal x = new BasicDecimal(0);
    public BasicDecimal y = new BasicDecimal(0);
    public BasicDecimal z = new BasicDecimal(0);
    public Vertex()
    {
    }

    public override string ToString()
    {
        StringMaker stringBuffer = new StringMaker();
        PositionStrings positionStrings = PositionStrings.getInstance();
        stringBuffer.append(positionStrings.X_LABEL);
        stringBuffer.append(this.x.ToString());
        stringBuffer.append(CommonSeps.getInstance().SPACE);
        stringBuffer.append(positionStrings.Y_LABEL);
        stringBuffer.append(this.y.ToString());
        stringBuffer.append(CommonSeps.getInstance().SPACE);
        stringBuffer.append(positionStrings.Z_LABEL);
        stringBuffer.append(this.z.ToString());
        return stringBuffer.ToString();
    }

}

