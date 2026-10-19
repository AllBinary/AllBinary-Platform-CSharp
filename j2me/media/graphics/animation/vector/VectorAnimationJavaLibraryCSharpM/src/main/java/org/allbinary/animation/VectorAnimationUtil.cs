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
using GPoint = org.allbinary.graphics.GPoint;
using BasicArrayList = org.allbinary.util.BasicArrayList;

namespace org.allbinary.animation;

public class VectorAnimationUtil
{
    private static readonly VectorAnimationUtil instance = new VectorAnimationUtil();
    public static VectorAnimationUtil getInstance()
    {
        return VectorAnimationUtil.instance;
    }

    private VectorAnimationUtil()
    {
    }

    public virtual int[][][] toAnimationArrayFromListOfPointListWithPointsPerFrame(BasicArrayList vector, int pointsPerFrame)
    {
        int size = vector.size();
        int[][][] points = System.Linq.Enumerable.Range(0, size).Select(_ => System.Linq.Enumerable.Range(0, pointsPerFrame).Select(_ => new int[2]).ToArray()).ToArray();
        BasicArrayList nextBasicArrayList = null;
        int[][] framePoints = null;
        for (int index = 0; index < size; index++) {
            nextBasicArrayList = ((BasicArrayList) vector.objectArray[index]);
            framePoints = this.toFrameArrayFromPointBasicArrayList(nextBasicArrayList);
            for (int pointIndex = 0; pointIndex < framePoints.Length; pointIndex++) {
                points[index][pointIndex][0] = framePoints[pointIndex][0];
                points[index][pointIndex][1] = framePoints[pointIndex][1];
            }
        }
        return points;
    }

    public virtual int[][][] toAnimationArrayFromListOfPointList(BasicArrayList vector)
    {
        int size = vector.size();
        int[][][] points = System.Linq.Enumerable.Range(0, size).Select(_ => System.Linq.Enumerable.Range(0, 0).Select(_ => new int[0]).ToArray()).ToArray();
        BasicArrayList nextBasicArrayList = null;
        int[][] framePoints = null;
        for (int index = 0; index < size; index++) {
            nextBasicArrayList = ((BasicArrayList) vector.objectArray[index]);
            framePoints = this.toFrameArrayFromPointBasicArrayList(nextBasicArrayList);
            points[index] = System.Linq.Enumerable.Range(0, framePoints.Length).Select(_ => new int[2]).ToArray();
            for (int pointIndex = 0; pointIndex < framePoints.Length; pointIndex++) {
                points[index][pointIndex][0] = framePoints[pointIndex][0];
                points[index][pointIndex][1] = framePoints[pointIndex][1];
            }
        }
        return points;
    }

    public virtual int[][] toFrameArrayFromPointBasicArrayList(BasicArrayList list)
    {
        int[][] points = System.Linq.Enumerable.Range(0, list.size()).Select(_ => new int[2]).ToArray();
        int size = list.size();
        for (int index = 0; index < size; index++) {
            GPoint nextPoint = ((GPoint) list.objectArray[index]);
            points[index][0] = nextPoint.getX();
            points[index][1] = nextPoint.getY();
        }
        return points;
    }

}

