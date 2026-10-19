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
using Angle = org.allbinary.math.Angle;
using AngleFactory = org.allbinary.math.AngleFactory;
using CommonStrings = org.allbinary.@string.CommonStrings;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListS = org.allbinary.util.BasicArrayListS;
using VectorInfo = org.allbinary.vector.VectorInfo;

namespace org.allbinary.animation;

public class VectorRotationGenerator
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly VectorRotationGenerator instance = new VectorRotationGenerator();
    public static VectorRotationGenerator getInstance()
    {
        return VectorRotationGenerator.instance;
    }

    private readonly VectorAnimationUtil vectorAnimationUtil = VectorAnimationUtil.getInstance();
    private VectorRotationGenerator()
    {
    }

    public virtual int[][][] getInstance(VectorInfo vectorRotationInfo)
    {
        return this.getInstanceFrames(vectorRotationInfo.getWidth(), vectorRotationInfo.getHeight(), vectorRotationInfo.getPoints(), vectorRotationInfo.getTotalFrames());
    }

    private readonly AngleFactory angleFactory = AngleFactory.getInstance();
    public virtual int[][][] getInstanceFrames(int width, int height, int[][] points, int frames)
    {
        try {
            short totalAngle = this.angleFactory.TOTAL_ANGLE;
            int angleIncrement = ((int) totalAngle) / frames;
            BasicArrayList pointsBasicArrayList = new BasicArrayListS(((int) totalAngle) / angleIncrement);
            BasicArrayList pointBasicArrayList = new BasicArrayListS(points.Length);
            PointFactory pointFactory = PointFactory.getInstance();
            int size = points.Length;
            for (int index = 0; index < size; index++) {
                pointBasicArrayList.add(pointFactory.createXY(points[index][0], points[index][1]));
            }
            int index = 0;
            while (index < ((int) totalAngle)) {
                pointsBasicArrayList.add(this.getListAtAngle(width, height, pointBasicArrayList, this.angleFactory.getAt(index)));
                index += angleIncrement;
            }
            int[][][] newPoints = this.vectorAnimationUtil.toAnimationArrayFromListOfPointListWithPointsPerFrame(pointsBasicArrayList, pointBasicArrayList.size());
            return newPoints;
        } catch (Exception e) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            this.logUtil.put(commonStrings.EXCEPTION, this, commonStrings.GET_INSTANCE, e);
            return NullUtil.getInstance().NULL_INT_ARRAY_ARRAY_ARRAY;
        }
    }

    // throws Exception
    public virtual BasicArrayList getListAtAngle(int width, int height, BasicArrayList pointBasicArrayList, Angle angle)
    {
        BasicGraphicsPipeline graphicsPipe = new BasicGraphicsPipeline(pointBasicArrayList);
        graphicsPipe.createMatrix();
        graphicsPipe.translate(-(width >> 1), -(height >> 1));
        graphicsPipe.rotateToAngle(angle);
        graphicsPipe.translate((width >> 1), (height >> 1));
        return graphicsPipe.getMatrix();
    }

}

