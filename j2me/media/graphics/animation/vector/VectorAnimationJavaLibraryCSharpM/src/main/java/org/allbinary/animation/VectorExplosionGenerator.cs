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
using PointFactory = org.allbinary.graphics.PointFactory;
using RandomRotationFactory = org.allbinary.graphics.pipeline.RandomRotationFactory;
using RandomTranslation = org.allbinary.graphics.pipeline.RandomTranslation;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using BasicArrayListS = org.allbinary.util.BasicArrayListS;

namespace org.allbinary.animation;

public class VectorExplosionGenerator
{
    private static readonly VectorExplosionGenerator instance = new VectorExplosionGenerator();
    public static VectorExplosionGenerator getInstance()
    {
        return VectorExplosionGenerator.instance;
    }

    public readonly VectorExplosionType RANDOM = new VectorExplosionType();
    public readonly VectorExplosionType ROTATION = new VectorExplosionType();
    private readonly VectorAnimationUtil vectorAnimationUtil = VectorAnimationUtil.getInstance();
    private VectorExplosionGenerator()
    {
    }

    // throws Exception
    public virtual BasicArrayList createList(BasicArrayList list, int howMuch, VectorExplosionType type)
    {
        GPoint point = null;
        int size = list.size();
        int[][] points = System.Linq.Enumerable.Range(0, size).Select(_ => new int[2]).ToArray();
        for (int index = 0; index < size; index++) {
            point = ((GPoint) list.objectArray[index]);
            points[index][0] = point.getX();
            points[index][1] = point.getY();
        }
        return this.createListFromPoints(list, points, howMuch, type);
    }

    // throws Exception
    public virtual int[][][] getInstance(int[][] points, int howMuch, VectorExplosionType type)
    {
        BasicArrayList pointsBasicArrayList = this.getInstanceStartFrame(points, howMuch, type, true);
        BasicArrayList tempBasicArrayList = ((BasicArrayList) pointsBasicArrayList.objectArray[0]);
        int[][][] newPoints = this.vectorAnimationUtil.toAnimationArrayFromListOfPointListWithPointsPerFrame(pointsBasicArrayList, tempBasicArrayList.size());
        return newPoints;
    }

    // throws Exception
    public virtual BasicArrayList getInstanceStartFrame(int[][] points, int howMuch, VectorExplosionType type, bool startFrame)
    {
        try {
            BasicArrayList pointsBasicArrayList = new BasicArrayListS(howMuch);
            pointsBasicArrayList.add(this.createPointsBasicArrayList(points));
            int frameIndex = 0;
            BasicArrayList tempBasicArrayList = null;
            BasicArrayList pointBasicArrayList = null;
            while (frameIndex < howMuch) {
                tempBasicArrayList = ((BasicArrayList) pointsBasicArrayList.objectArray[frameIndex]);
                pointBasicArrayList = this.createListFromPoints(tempBasicArrayList, points, howMuch, type);
                pointsBasicArrayList.add(pointBasicArrayList);
                frameIndex++;
            }
            if (!startFrame) {
                pointsBasicArrayList.removeAt(0);
            }
            return pointsBasicArrayList;
        } catch (Exception e) {
            throw e;
        }
    }

    private readonly RandomRotationFactory randomRotationFactory = RandomRotationFactory.getInstance();
    // throws Exception
    private BasicArrayList createListFromPoints(BasicArrayList tempBasicArrayList, int[][] points, int howMuch, VectorExplosionType type)
    {
        int index = 0;
        BasicArrayList pointBasicArrayList = new BasicArrayListD();
        BasicArrayList sectionBasicArrayList = null;
        while (index < points.Length) {
            sectionBasicArrayList = new BasicArrayListD();
            while (points[index][0] != 1000) {
                sectionBasicArrayList.add(tempBasicArrayList.objectArray[index]);
                index++;
                if (index >= points.Length) {
                    break;
                }
            }
            sectionBasicArrayList = RandomTranslation.getInstance(sectionBasicArrayList, howMuch);
            if (type == this.ROTATION) {
                sectionBasicArrayList = this.randomRotationFactory.getInstanceList(sectionBasicArrayList, howMuch);
            }
            int size = sectionBasicArrayList.size();
            for (int index2 = 0; index2 < size; index2++) {
                pointBasicArrayList.add(sectionBasicArrayList.objectArray[index2]);
            }
            if (index >= points.Length) {
                break;
            } else if (points[index][0] == 1000) {
                pointBasicArrayList.add(tempBasicArrayList.objectArray[index]);
                index++;
            }
        }
        return pointBasicArrayList;
    }

    // throws Exception
    private BasicArrayList createPointsBasicArrayList(int[][] points)
    {
        if (points.Length == 0) {
            throw new Exception("Not Points Provided");
        }
        BasicArrayList firstPointBasicArrayList = new BasicArrayListS(points.Length);
        PointFactory pointFactory = PointFactory.getInstance();
        for (int index = 0; index < points.Length; index++) {
            firstPointBasicArrayList.add(pointFactory.createXY(points[index][0], points[index][1]));
        }
        return firstPointBasicArrayList;
    }

}

