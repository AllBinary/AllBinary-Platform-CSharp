/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2003 AllBinary 
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
//using Graphics = javax.microedition.lcdui.Graphics;
using Animation = org.allbinary.animation.Animation;
using GPoint = org.allbinary.graphics.GPoint;
using BasicColor = org.allbinary.graphics.color.BasicColor;
using BasicColorFactory = org.allbinary.graphics.color.BasicColorFactory;
using CanvasStrings = org.allbinary.graphics.displayable.CanvasStrings;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using BasicGeographicMap = org.allbinary.media.graphics.geography.map.BasicGeographicMap;
using GeographicMapCellHistory = org.allbinary.media.graphics.geography.map.GeographicMapCellHistory;
using GeographicMapCellPosition = org.allbinary.media.graphics.geography.map.GeographicMapCellPosition;
using GeographicMapCompositeInterface = org.allbinary.media.graphics.geography.map.GeographicMapCompositeInterface;
using SimpleGeographicMapCellPositionFactory = org.allbinary.media.graphics.geography.map.SimpleGeographicMapCellPositionFactory;
using BasicArrayList = org.allbinary.util.BasicArrayList;

namespace org.allbinary.game.layer;

public class PathAnimation : Animation
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly LinePathAnimation linePathAnimation;
    private readonly PathFindingLayerInterface pathFindingLayer;
    public AllBinaryGameLayerManager allBinaryGameLayerManagerP = AllBinaryGameLayerManager.getNullInstance();
    public PathAnimation(PathFindingLayerInterface pathFindingLayer, LinePathAnimation linePathAnimation)
    {
        this.pathFindingLayer = pathFindingLayer;
        this.linePathAnimation = linePathAnimation;
    }

    // throws Exception
    public virtual void setAllBinaryGameLayerManager(AllBinaryGameLayerManager allBinaryGameLayerManager)
    {
        this.allBinaryGameLayerManagerP = allBinaryGameLayerManager;
    }

    // throws Exception
    public override void nextFrame()
    {
    }

    private readonly BasicColor startColor = BasicColorFactory.getInstance().RED;
    private readonly BasicColor middleColor = BasicColorFactory.getInstance().BLUE;
    private readonly BasicColor endColor = BasicColorFactory.getInstance().GREEN;
    public override void paintXY(Graphics graphics, int x, int y)
    {
        try {
            WaypointBehaviorBase waypointBehaviorBase = this.pathFindingLayer.getWaypointBehavior();
            if (waypointBehaviorBase != null) {
                GeographicMapCellHistory geographicMapCellHistory = waypointBehaviorBase.getCurrentGeographicMapCellHistory();
                BasicArrayList list = geographicMapCellHistory.getTracked();
                int size = list.size();
                if (size > 0) {
                    GeographicMapCompositeInterface geographicMapCompositeInterface = ((GeographicMapCompositeInterface) this.allBinaryGameLayerManagerP);
                    BasicGeographicMap geographicMapInterface = geographicMapCompositeInterface.getGeographicMapInterface()[0];
                    AllBinaryTiledLayer tiledLayer = geographicMapInterface.getAllBinaryTiledLayer();
                    GeographicMapCellPosition geographicMapCellPosition = SimpleGeographicMapCellPositionFactory.NULL_GEOGRAPHIC_MAP_CELL_POSITION;
                    GPoint nextPoint = null;
                    GPoint point = null;
                    int start = size - 2;
                    for (int index = 0; index < size - 1; index++) {
                        if (index == start) {
                            this.setBasicColorP(this.startColor);
                            this.basicSetColorUtil.setBasicColorP3(graphics, this.getBasicColorP(), this.getColor());
                        } else if (geographicMapCellHistory.isVisited(geographicMapCellPosition)) {
                            this.setBasicColorP(this.endColor);
                            this.basicSetColorUtil.setBasicColorP3(graphics, this.getBasicColorP(), this.getColor());
                        } else {
                            this.setBasicColorP(this.middleColor);
                            this.basicSetColorUtil.setBasicColorP3(graphics, this.getBasicColorP(), this.getColor());
                        }
                        geographicMapCellPosition = ((GeographicMapCellPosition) list.get(index));
                        point = geographicMapCellPosition.getMidPoint();
                        geographicMapCellPosition = ((GeographicMapCellPosition) list.get(index + 1));
                        nextPoint = geographicMapCellPosition.getMidPoint();
                        this.linePathAnimation.paint(graphics, point, nextPoint, tiledLayer);
                    }
                }
            }
        } catch (Exception e) {
            this.logUtil.putF("Cleared Target", this, CanvasStrings.getInstance().PAINT);
        }
    }

}

