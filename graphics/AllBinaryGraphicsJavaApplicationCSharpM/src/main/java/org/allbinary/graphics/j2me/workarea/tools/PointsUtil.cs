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
using VectorRotationGenerator = org.allbinary.animation.VectorRotationGenerator;
using GPoint = org.allbinary.graphics.GPoint;
using AngleFactory = org.allbinary.math.AngleFactory;
using BasicArrayList = org.allbinary.util.BasicArrayList;

namespace org.allbinary.graphics.j2me.workarea.tools;

public class PointsUtil
{
    private static readonly PointsUtil instance = new PointsUtil();
    public static PointsUtil getInstance()
    {
        return PointsUtil.instance;
    }

    // throws Exception
    public virtual BasicArrayList doTransforms(BasicArrayList pointVector, double? angle, GPoint fulcrumPoint)
    {
        return VectorRotationGenerator.getInstance().getListAtAngle(fulcrumPoint.getX(), fulcrumPoint.getY(), pointVector, AngleFactory.getInstance().getAt(((int) angle)));
    }

}

