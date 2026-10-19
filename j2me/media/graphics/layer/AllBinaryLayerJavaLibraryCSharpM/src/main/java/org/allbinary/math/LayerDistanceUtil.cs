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
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;
using MathUtil = org.allbinary.logic.math.MathUtil;

namespace org.allbinary.math;

public class LayerDistanceUtil
{
    private static readonly LayerDistanceUtil instance = new LayerDistanceUtil();
    public static LayerDistanceUtil getInstance()
    {
        return LayerDistanceUtil.instance;
    }

    private readonly MathUtil mathUtil = MathUtil.getInstance();
    public virtual int getDistance(AllBinaryLayer layerInterface, AllBinaryLayer layerInterface2)
    {
        int dx = (layerInterface.getXP() + layerInterface.getHalfWidth()) - (layerInterface2.getXP() + layerInterface2.getHalfWidth());
        int dy = (layerInterface.getYP() + layerInterface.getHalfHeight()) - (layerInterface2.getYP() + layerInterface2.getHalfHeight());
        return ((int) this.mathUtil.sqrt((dx * dx) + (dy * dy)));
    }

    public virtual int getDistance3D(AllBinaryLayer layerInterface, AllBinaryLayer layerInterface2)
    {
        int dx = (layerInterface.getXP() + layerInterface.getHalfWidth()) - (layerInterface2.getXP() + layerInterface2.getHalfWidth());
        int dy = (layerInterface.getYP() + layerInterface.getHalfHeight()) - (layerInterface2.getYP() + layerInterface2.getHalfHeight());
        int dz = (layerInterface.getZP() + layerInterface.getHalfDepth()) - (layerInterface2.getZP() + layerInterface2.getHalfDepth());
        return ((int) this.mathUtil.sqrt((dx * dx) + (dy * dy) + (dz * dz)));
    }

    public virtual int getDistanceAt(AllBinaryLayer layerInterface, GPoint point)
    {
        int dx = layerInterface.getXP() - point.getX();
        int dy = layerInterface.getYP() - point.getY();
        return ((int) this.mathUtil.sqrt((dx * dx) + (dy * dy)));
    }

}

