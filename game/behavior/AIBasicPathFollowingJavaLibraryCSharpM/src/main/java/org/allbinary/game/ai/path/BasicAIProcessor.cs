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
using BasicArrayList = org.allbinary.util.BasicArrayList;
using Direction = org.allbinary.direction.Direction;
using DirectionFactory = org.allbinary.direction.DirectionFactory;
using AllBinaryLayerManager = org.allbinary.layer.AllBinaryLayerManager;
using AngleInfo = org.allbinary.math.AngleInfo;
using GeographicMapCellHistory = org.allbinary.media.graphics.geography.map.GeographicMapCellHistory;
using GeographicMapCellPosition = org.allbinary.media.graphics.geography.map.GeographicMapCellPosition;
using GeographicMapDirectionUtil = org.allbinary.media.graphics.geography.map.GeographicMapDirectionUtil;
using GeographicMapCellPathHistoryInfo = org.allbinary.media.graphics.geography.pathfinding.GeographicMapCellPathHistoryInfo;

namespace org.allbinary.game.ai.path;

public class BasicAIProcessor
{
    private string name;
    private GeographicMapCellHistory geographicMapCellHistory;
    private BasicArrayList geographicMapCellPositionBasicArrayList;
    private GeographicMapCellPathHistoryInfo geographicMapCellPathHistoryInfo;
    private BasicDirectionAIHelper basicAI;
    public BasicAIProcessor(string name, GeographicMapCellHistory geographicMapCellHistory, GeographicMapCellPathHistoryInfo geographicMapCellPathHistoryInfo, BasicArrayList chosenPathList, AngleInfo angleInfo, int seed)
    {
        this.name = name;
        this.geographicMapCellHistory = geographicMapCellHistory;
        this.geographicMapCellPositionBasicArrayList = chosenPathList;
        this.geographicMapCellPathHistoryInfo = geographicMapCellPathHistoryInfo;
        this.setName(name);
        this.setNewPath(geographicMapCellHistory, chosenPathList);
        this.basicAI = new BasicDirectionAIHelper(this.getName(), angleInfo);
    }

    private void setNewPath(GeographicMapCellHistory geographicMapCellHistory, BasicArrayList chosenPathList)
    {
        this.setGeographicMapCellHistory(geographicMapCellHistory);
        this.geographicMapCellPositionBasicArrayList = chosenPathList;
        this.init();
    }

    public virtual void init()
    {
        this.geographicMapCellPathHistoryInfo = new GeographicMapCellPathHistoryInfo();
        this.geographicMapCellPathHistoryInfo.setPreviousOnPathGeographicMapCellPosition(((GeographicMapCellPosition) this.geographicMapCellPositionBasicArrayList.get(this.geographicMapCellPositionBasicArrayList.size() - 1)));
        this.geographicMapCellPathHistoryInfo.setNextOnPathGeographicMapCellPosition(((GeographicMapCellPosition) this.geographicMapCellPositionBasicArrayList.get(this.geographicMapCellPositionBasicArrayList.size() - 1)));
        this.update();
    }

    private readonly GeographicMapDirectionUtil geographicMapDirectionUtil = GeographicMapDirectionUtil.getInstance();
    // throws Exception
    private int goTowardNextChosenOnPathPosition(GeographicMapCellPosition currentGeographicMapCellPosition)
    {
        int keyDirection = -1;
        GeographicMapCellPosition goToGeographicMapCellPosition = this.geographicMapCellPathHistoryInfo.getNextChosenOnPathGeographicMapCellPosition();
        Direction geographicMapDirectionData = this.geographicMapDirectionUtil.getDirectionFromCellPositionToAdjacentCellPosition(currentGeographicMapCellPosition, goToGeographicMapCellPosition);
        if (geographicMapDirectionData == DirectionFactory.getInstance().NOT_BORDERED_WITH) {
            geographicMapDirectionData = this.geographicMapDirectionUtil.getDirectionFromCellPositionToCellPosition(currentGeographicMapCellPosition, goToGeographicMapCellPosition);
        }
        keyDirection = this.basicAI.getAIKeyPressedFromDirection(geographicMapDirectionData);
        return keyDirection;
    }

    private void update()
    {
        this.geographicMapCellPathHistoryInfo.setNextUnvisitedOnPathGeographicMapCellPosition(this.getGeographicMapCellHistory().getFirstUnvisited());
        this.geographicMapCellPathHistoryInfo.setNextChosenOnPathGeographicMapCellPosition(this.geographicMapCellPathHistoryInfo.getNextUnvisitedOnPathGeographicMapCellPosition());
    }

    // throws Exception
    public virtual int processAI(AllBinaryLayerManager myManager, GeographicMapCellPosition currentGeographicMapCellPosition)
    {
        int keyDirection = -1;
        if (this.geographicMapCellPositionBasicArrayList.contains(currentGeographicMapCellPosition)) {
            this.update();
            keyDirection = this.goTowardNextChosenOnPathPosition(currentGeographicMapCellPosition);
            this.geographicMapCellPathHistoryInfo.setPreviousOnPathGeographicMapCellPosition(currentGeographicMapCellPosition);
        } else {
            keyDirection = this.goTowardNextChosenOnPathPosition(currentGeographicMapCellPosition);
        }
        return keyDirection;
    }

    public virtual string getName()
    {
        return this.name;
    }

    public virtual void setName(string name)
    {
        this.name = name;
    }

    public virtual GeographicMapCellPathHistoryInfo getGeographicMapCellPathHistoryInfo()
    {
        return this.geographicMapCellPathHistoryInfo;
    }

    public virtual void setGeographicMapCellPathHistoryInfo(GeographicMapCellPathHistoryInfo geographicMapCellPathHistoryInfo)
    {
        this.geographicMapCellPathHistoryInfo = geographicMapCellPathHistoryInfo;
    }

    public virtual GeographicMapCellHistory getGeographicMapCellHistory()
    {
        return this.geographicMapCellHistory;
    }

    public virtual void setGeographicMapCellHistory(GeographicMapCellHistory geographicMapCellHistory)
    {
        this.geographicMapCellHistory = geographicMapCellHistory;
    }

}

