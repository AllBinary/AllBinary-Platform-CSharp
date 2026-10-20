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
using java.util;
using GPoint = org.allbinary.graphics.GPoint;
using GraphicItemInterface = org.allbinary.graphics.j2me.workarea.tools.GraphicItemInterface;
using LinesGraphicItem = org.allbinary.graphics.j2me.workarea.tools.LinesGraphicItem;
using Points = org.allbinary.graphics.j2me.workarea.tools.Points;
using BasicGraphicsPipeline = org.allbinary.graphics.pipeline.BasicGraphicsPipeline;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using CommonLabels = org.allbinary.@string.CommonLabels;
using CommonStrings = org.allbinary.@string.CommonStrings;
using BasicArrayList = org.allbinary.util.BasicArrayList;

namespace org.allbinary.animation.vector;

public class VectorCenterGenerator
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    public int minX = int.MaxValue;
    public int minY = int.MaxValue;
    public int maxX = int.MinValue;
    public int maxY = int.MinValue;
    private int dx = 0;
    private int dy = 0;
    private int width = 0;
    private int height = 0;
    public VectorCenterGenerator()
    {
    }

    // throws Exception
    public virtual void calculate(HashMap hashMap)
    {
        object[] graphicItemArray = hashMap.keySet().toArray();
        int size = graphicItemArray.Length;
        for (int index = 0; index < size; index++) {
            GraphicItemInterface item = ((GraphicItemInterface) hashMap.get(graphicItemArray[index]));
            if (item.getName() == LinesGraphicItem.getStaticName()) {
                this.getInstance(item.getPointsInterface().getPoints());
            }
        }
        this.logUtil.putF("minX: " + this.minX + " minY: " + this.minY + " maxX: " + this.maxX + " maxY: " + this.maxY, this, this.commonStrings.GET_INSTANCE);
        this.setWidth(this.maxX - this.minX);
        this.setHeight(this.maxY - this.minY);
        int max = this.getWidth();
        if (getHeight() > max) {
            max = this.getHeight();
        }
        int middle = max / 2;
        CommonLabels commonLabels = CommonLabels.getInstance();
        string s = new StringMaker().append(commonLabels.WIDTH_LABEL).appendint(getWidth()).append(commonLabels.HEIGHT_LABEL).appendint(getHeight()).append(" max: ").appendint(max).append(" middle: ").appendint(middle).ToString();
        this.logUtil.putF(s, this, this.commonStrings.GET_INSTANCE);
        int currentMiddleX = this.minX + this.getWidth() / 2;
        int currentMiddleY = this.minY + this.getHeight() / 2;
        this.dx = middle - currentMiddleX;
        this.dy = middle - currentMiddleY;
    }

    // throws Exception
    public virtual void transform(HashMap hashMap)
    {
        this.calculate(hashMap);
        this.logUtil.putF(new StringMaker().append(" dx: ").appendint(this.dx).append(" dy: ").appendint(this.dy).ToString(), this, this.commonStrings.GET_INSTANCE);
        object[] graphicItemArray = hashMap.keySet().toArray();
        int size = graphicItemArray.Length;
        for (int index = 0; index < size; index++) {
            GraphicItemInterface item = ((GraphicItemInterface) hashMap.get(graphicItemArray[index]));
            BasicArrayList list = VectorCenterGenerator.translate(item.getPointsInterface().getPoints(), dx, dy);
            Points newPoints = new Points();
            newPoints.addPoints(list);
            item.setPointsInterface(newPoints);
        }
    }

    // throws Exception
    private void getInstance(BasicArrayList pointVector)
    {
        try {
            int size = pointVector.size();
            for (int index = 0; index < size; index++) {
                GPoint point = ((GPoint) pointVector.get(index));
                if (point.getX() < this.minX) {
                    this.minX = point.getX();
                }
                if (point.getX() > this.maxX) {
                    this.maxX = point.getX();
                }
                if (point.getY() < this.minY) {
                    this.minY = point.getY();
                }
                if (point.getY() > this.maxY) {
                    this.maxY = point.getY();
                }
            }
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.GET_INSTANCE, e);
            throw e;
        }
    }

    // throws Exception
    public static BasicArrayList translate(BasicArrayList list, int x, int y)
    {
        BasicGraphicsPipeline graphicsPipe = new BasicGraphicsPipeline(list);
        graphicsPipe.createMatrix();
        graphicsPipe.translate(x, y);
        return graphicsPipe.getMatrix();
    }

    public virtual int getWidth()
    {
        return this.width;
    }

    public virtual void setWidth(int width)
    {
        this.width = width;
    }

    public virtual int getHeight()
    {
        return this.height;
    }

    public virtual void setHeight(int height)
    {
        this.height = height;
    }

}

