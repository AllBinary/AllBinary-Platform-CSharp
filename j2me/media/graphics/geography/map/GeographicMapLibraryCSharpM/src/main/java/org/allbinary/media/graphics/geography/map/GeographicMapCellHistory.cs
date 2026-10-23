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
//using Font = javax.microedition.lcdui.Font;
//using Graphics = javax.microedition.lcdui.Graphics;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using CommonStrings = org.allbinary.@string.CommonStrings;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using BooleanFactory = org.allbinary.logic.java.@bool.BooleanFactory;
using Animation = org.allbinary.animation.Animation;
using AnimationBehavior = org.allbinary.animation.AnimationBehavior;
using TextAnimation = org.allbinary.animation.text.TextAnimation;
using AllBinaryTiledLayer = org.allbinary.game.layer.AllBinaryTiledLayer;
using GPoint = org.allbinary.graphics.GPoint;
using BasicColorFactory = org.allbinary.graphics.color.BasicColorFactory;
using MyFontProcessor = org.allbinary.graphics.font.MyFontProcessor;
using UpdateMyFontInterface = org.allbinary.graphics.font.UpdateMyFontInterface;
using UpdateMyFontProcessor = org.allbinary.graphics.font.UpdateMyFontProcessor;
using BasicDecimal = org.allbinary.logic.math.BasicDecimal;

namespace org.allbinary.media.graphics.geography.map;

public class GeographicMapCellHistory : UpdateMyFontInterface
{
    public static readonly GeographicMapCellHistory[] NULL_GEOGRPAHIC_MAP_HISTORY_ARRAY = new GeographicMapCellHistory[0];
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly BooleanFactory booleanFactory = BooleanFactory.getInstance();
    private readonly BasicArrayList list;
    private readonly BasicArrayList visitedList;
    private readonly string MISSED_INFO = "Missed";
    private readonly Animation animation;
    private MyFontProcessor myFontProcessor;
    private int totalVisited = 0;
    private int halfWidth = 0;
    private int fontHeight = 0;
    public GeographicMapCellHistory()
    {
        this.animation = new TextAnimation(this.MISSED_INFO, AnimationBehavior.getInstance());
        this.myFontProcessor = new UpdateMyFontProcessor(this);
        this.list = new BasicArrayListD();
        this.visitedList = new BasicArrayListD();
        this.init();
    }

    public virtual void updateMeasurement(Graphics graphics)
    {
        Font font = graphics.getFont();
        this.fontHeight = font.getHeight();
        this.myFontProcessor = MyFontProcessor.getInstance();
    }

    public virtual int getTotalVisited()
    {
        return this.totalVisited;
    }

    public virtual int getTotalNotVisited()
    {
        return this.getSize() - this.totalVisited;
    }

    public virtual int getSize()
    {
        return this.list.size();
    }

    public virtual void trackAll(BasicArrayList list)
    {
        int size = list.size();
        this.list.ensureCapacity(size);
        this.visitedList.ensureCapacity(size);
        GeographicMapCellPosition geographicMapCellPosition = null;
        for (int index = 0; index < size; index++) {
            geographicMapCellPosition = ((GeographicMapCellPosition) list.get(index));
            this.track(geographicMapCellPosition);
        }
    }

    public virtual void track(GeographicMapCellPosition geographicMapCellPosition)
    {
        if (!this.list.contains(geographicMapCellPosition)) {
            this.list.add(geographicMapCellPosition);
            this.visitedList.add(this.booleanFactory.FALSE);
        }
    }

    public virtual BasicArrayList getTracked()
    {
        return this.list;
    }

    public virtual BasicArrayList getVisited()
    {
        return this.visitedList;
    }

    public virtual GeographicMapCellPosition getAfterIfNotLast(GeographicMapCellPosition geographicMapCellPosition)
    {
        BasicArrayList localList = this.list;
        int index = localList.indexOf(geographicMapCellPosition);
        if (localList.size() > index + 1) {
            return ((GeographicMapCellPosition) localList.get(index + 1));
        }
        return geographicMapCellPosition;
    }

    public virtual GeographicMapCellPosition getFirstUnvisited()
    {
        BasicArrayList localList = this.list;
        BasicArrayList localVisitedList = this.visitedList;
        int size = localVisitedList.size();
        bool? value = null;
        for (int index = 0; index < size; index++) {
            value = ((bool?) this.visitedList.get(index));
            if (value == this.booleanFactory.FALSE) {
                return ((GeographicMapCellPosition) localList.get(index));
            }
        }
        return ((GeographicMapCellPosition) localList.get(0));
    }

    public virtual int getFirstUnvisitedIndex()
    {
        BasicArrayList localVisitedList = this.visitedList;
        int size = localVisitedList.size();
        bool? value = null;
        for (int index = 0; index < size; index++) {
            value = ((bool?) this.visitedList.get(index));
            if (value == this.booleanFactory.FALSE) {
                return index;
            }
        }
        return 0;
    }

    public virtual BasicArrayList getInPathButNotTracked(BasicArrayList pathList)
    {
        BasicArrayList inPathButNotTrackedList = new BasicArrayListD();
        BasicArrayList localList = this.list;
        int size = pathList.size();
        GeographicMapCellPosition geographicMapCellPosition = null;
        for (int index = 0; index < size; index++) {
            geographicMapCellPosition = ((GeographicMapCellPosition) pathList.get(index));
            if (!localList.contains(geographicMapCellPosition)) {
                inPathButNotTrackedList.add(geographicMapCellPosition);
            }
        }
        return inPathButNotTrackedList;
    }

    public virtual bool isVisited(GeographicMapCellPosition geographicMapCellPosition)
    {
        int index = this.list.indexOf(geographicMapCellPosition);
        if (index != -1) {
            bool? value = ((bool?) this.visitedList.get(index));
            if (value == this.booleanFactory.TRUE) {
                return true;
            }
        } else {
        }
        return false;
    }

    public virtual bool visit(GeographicMapCellPosition geographicMapCellPosition)
    {
        int index = this.list.indexOf(geographicMapCellPosition);
        bool? value = null;
        if (index != -1) {
            value = ((bool?) this.visitedList.get(index));
            bool? TRUE = this.booleanFactory.TRUE;
            if (value != TRUE) {
                this.visitedList.set(index, TRUE);
                this.totalVisited++;
                return true;
            }
        } else {
        }
        return false;
    }

    // throws Exception
    public virtual bool isAllVisited()
    {
        if (this.totalVisited == this.getSize() - 1) {
            return true;
        } else {
            return false;
        }
    }

    // throws Exception
    public virtual bool isAllVisited2()
    {
        if (this.totalVisited == this.getSize()) {
            return true;
        } else {
            return false;
        }
    }

    // throws Exception
    public virtual bool isPortionVisited(BasicDecimal basicDecimal)
    {
        int size = this.getSize();
        int numberRequired = (size << basicDecimal.getScaledFactor()) / ((int) basicDecimal.getUnscaled());
        int numberNotVisited = this.getSize() - 1 - this.totalVisited;
        if (size - numberNotVisited > numberRequired) {
            return true;
        } else {
            return false;
        }
    }

    // throws Exception
    public virtual void reset()
    {
        BasicArrayList localVisitedList = this.visitedList;
        bool? localFalseBoolean = this.booleanFactory.FALSE;
        int size = localVisitedList.size();
        for (int index = size - 1; index >= 0; index--) {
            localVisitedList.set(index, localFalseBoolean);
        }
        this.totalVisited = 0;
    }

    private void paintNotVisitedRelativeToPoint(Graphics graphics, AllBinaryTiledLayer tiledLayer, GPoint point)
    {
        int x = point.getX() - tiledLayer.getXP();
        int y = point.getY() - tiledLayer.getYP();
        if (this.halfWidth == 0) {
            this.halfWidth = (graphics.getFont().stringWidth(this.MISSED_INFO) >> 1);
        }
        int height = 2 * this.fontHeight;
        this.animation.paintXY(graphics, x + this.halfWidth, y + (height));
    }

    private readonly int RED = ((int) BasicColorFactory.getInstance().RED);
    public virtual void paintNotVisited(Graphics graphics, BasicGeographicMap geographicMapInterface)
    {
        try {
            this.myFontProcessor.process(graphics);
            graphics.setColor(this.RED);
            BasicArrayList localVisitedList = this.visitedList;
            int size = localVisitedList.size();
            GeographicMapCellPosition geographicMapCellPosition = null;
            bool? isCellVisitedBoolean = null;
            for (int index = size; --index >= 0; ) {
                geographicMapCellPosition = ((GeographicMapCellPosition) this.list.get(index));
                isCellVisitedBoolean = ((bool?) localVisitedList.get(index));
                if (!isCellVisitedBoolean.Value) {
                    this.paintNotVisitedRelativeToPoint(graphics, geographicMapInterface.getAllBinaryTiledLayer(), geographicMapCellPosition.getPoint());
                }
            }
        } catch (Exception e) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            this.logUtil.put(commonStrings.EXCEPTION, this, "paintNotVisited", e);
        }
    }

    public virtual void init()
    {
        this.list.clear();
        this.visitedList.clear();
        this.totalVisited = 0;
    }

}

