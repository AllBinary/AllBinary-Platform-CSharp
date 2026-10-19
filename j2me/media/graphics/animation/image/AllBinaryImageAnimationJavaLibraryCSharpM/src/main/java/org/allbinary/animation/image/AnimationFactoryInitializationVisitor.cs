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
using StringMaker = org.allbinary.logic.@string.StringMaker;
using PositionStrings = org.allbinary.math.PositionStrings;
using CommonLabels = org.allbinary.@string.CommonLabels;
using CommonSeps = org.allbinary.@string.CommonSeps;

namespace org.allbinary.animation.image;

public class AnimationFactoryInitializationVisitor
{
    public int width = 0;
    public int height = 0;
    public int dx = 0;
    public int dy = 0;
    public int originalDx = 0;
    public int originalDy = 0;
    public virtual void visit()
    {
    }

    public override string ToString()
    {
        CommonSeps commonSeps = CommonSeps.getInstance();
        CommonLabels commonLabels = CommonLabels.getInstance();
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(PositionStrings.getInstance().DX_LABEL).appendfloat(((float) this.dx));
        stringBuffer.append(PositionStrings.getInstance().DY_LABEL).appendfloat(((float) this.dy));
        stringBuffer.append(commonLabels.WIDTH_LABEL);
        stringBuffer.appendint(this.width);
        stringBuffer.append(commonSeps.SPACE);
        stringBuffer.append(commonLabels.HEIGHT_LABEL);
        stringBuffer.appendint(this.height);
        return stringBuffer.ToString();
    }

}

