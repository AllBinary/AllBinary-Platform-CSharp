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

namespace org.allbinary.vector;

public class PointsUtil
{
    private static readonly PointsUtil instance = new PointsUtil();
    public static PointsUtil getInstance()
    {
        return PointsUtil.instance;
    }

    public virtual int[][][] adjustXY(int[][][] points, int x, int y)
    {
        int size = points.Length;
        int[][][] newPoints = System.Linq.Enumerable.Range(0, size).Select(_ => System.Linq.Enumerable.Range(0, 0).Select(_ => new int[0]).ToArray()).ToArray();
        for (int index = 0; index < size; index++) {
            int size2 = points[index].Length;
            newPoints[index] = System.Linq.Enumerable.Range(0, size2).Select(_ => new int[2]).ToArray();
            for (int index2 = 0; index2 < size2; index2++) {
                if (points[index][index2][0] != 1000) {
                    newPoints[index][index2][0] = points[index][index2][0] + x;
                    newPoints[index][index2][1] = points[index][index2][1] + y;
                } else {
                    newPoints[index][index2][0] = 1000;
                    newPoints[index][index2][1] = 1000;
                }
            }
        }
        return newPoints;
    }

    public virtual int[][] adjust(int[][] points, int both)
    {
        return this.adjust(points, both, both);
    }

    public virtual int[][] adjust(int[][] points, int x, int y)
    {
        int[][] newPoints = System.Linq.Enumerable.Range(0, points.Length).Select(_ => new int[2]).ToArray();
        for (int index2 = 0; index2 < points.Length; index2++) {
            if (points[index2][0] != 1000) {
                newPoints[index2][0] = points[index2][0] + x;
                newPoints[index2][1] = points[index2][1] + y;
            } else {
                newPoints[index2][0] = 1000;
                newPoints[index2][1] = 1000;
            }
        }
        return newPoints;
    }

}

