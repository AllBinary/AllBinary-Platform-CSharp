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
using PointFactory = org.allbinary.graphics.PointFactory;
using BasicGraphicsPipeline = org.allbinary.graphics.pipeline.BasicGraphicsPipeline;
using NullUtil = org.allbinary.logic.NullUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListS = org.allbinary.util.BasicArrayListS;

namespace org.allbinary.animation;

public class VectorMirrorGenerator
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly VectorMirrorGenerator instance = new VectorMirrorGenerator();
    public static VectorMirrorGenerator getInstance()
    {
        return VectorMirrorGenerator.instance;
    }

    private readonly VectorAnimationUtil vectorAnimationUtil = VectorAnimationUtil.getInstance();
    private VectorMirrorGenerator()
    {
    }

    public virtual int[][][] getInstance(int[][][] points, int width)
    {
        try {
            PointFactory pointFactory = PointFactory.getInstance();
            BasicArrayList pointBasicArrayList = null;
            int[][] nextPoints = null;
            int size2 = 0;
            int size = points.Length;
            BasicArrayList pointsBasicArrayList = new BasicArrayListS(size);
            for (int frame = 0; frame < size; frame++) {
                nextPoints = points[frame];
                size2 = nextPoints.Length;
                pointBasicArrayList = new BasicArrayListS(size2);
                for (int index = 0; index < size2; index++) {
                    pointBasicArrayList.add(pointFactory.createXY(nextPoints[index][0], nextPoints[index][1]));
                }
                pointsBasicArrayList.add(pointBasicArrayList);
            }
            for (int index = 0; index < points.Length; index++) {
                pointsBasicArrayList.add(this.getInstance(((BasicArrayList) pointsBasicArrayList.objectArray[index]), width));
            }
            int[][][] newPoints = this.vectorAnimationUtil.toAnimationArrayFromListOfPointList(pointsBasicArrayList);
            return newPoints;
        } catch (Exception e) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            this.logUtil.put(commonStrings.EXCEPTION, this, commonStrings.GET_INSTANCE, e);
            return NullUtil.getInstance().NULL_INT_ARRAY_ARRAY_ARRAY;
        }
    }

    // throws Exception
    public virtual BasicArrayList getInstance(BasicArrayList pointBasicArrayList, int width)
    {
        BasicGraphicsPipeline graphicsPipe = new BasicGraphicsPipeline(pointBasicArrayList);
        graphicsPipe.createMatrix();
        graphicsPipe.mirror(width);
        return graphicsPipe.getMatrix();
    }

}

