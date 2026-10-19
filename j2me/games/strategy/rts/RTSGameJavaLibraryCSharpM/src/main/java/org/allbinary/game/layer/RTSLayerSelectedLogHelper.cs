/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2022 AllBinary 
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
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonLabels = org.allbinary.@string.CommonLabels;
using CommonSeps = org.allbinary.@string.CommonSeps;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using AngleInfo = org.allbinary.math.AngleInfo;
using NamedAngle = org.allbinary.math.NamedAngle;
using PositionStrings = org.allbinary.math.PositionStrings;
using GeographicMapCellHistory = org.allbinary.media.graphics.geography.map.GeographicMapCellHistory;
using GeographicMapCellPosition = org.allbinary.media.graphics.geography.map.GeographicMapCellPosition;
using BasicArrayList = org.allbinary.util.BasicArrayList;

namespace org.allbinary.game.layer;

public class RTSLayerSelectedLogHelper : RTSLayerLogHelper
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly RTSLayerSelectedLogHelper instanceC = new RTSLayerSelectedLogHelper();
    public static RTSLayerSelectedLogHelper getInstance()
    {
        return RTSLayerSelectedLogHelper.instanceC;
    }

    private readonly CommonSeps commonSeps = CommonSeps.getInstance();
    private readonly PositionStrings positionStrings = PositionStrings.getInstance();
    private readonly string TRACKTO_TURNTO = "trackTo:turnTo";
    public override void setClosestGeographicMapCellHistory(PathFindingLayerInterface associatedAdvancedRTSGameLayer, BasicArrayList pathsList)
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(associatedAdvancedRTSGameLayer.getName());
        stringBuffer.append(this.commonSeps.SPACE);
        stringBuffer.append(CommonLabels.getInstance().START);
        stringBuffer.appendint(pathsList.size());
        stringBuffer.append(" -> ");
        stringBuffer.append(StringUtil.getInstance().toString(pathsList));
        this.logUtil.putF(stringBuffer.ToString(), this, "selected: setClosestGeographicMapCellHistory");
    }

    public override void trackTo(PathFindingLayerInterface associatedAdvancedRTSGameLayer, GeographicMapCellPosition nextUnvisitedPathGeographicMapCellPosition, int dx, int dy, string reason)
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(associatedAdvancedRTSGameLayer.getName());
        stringBuffer.append(this.commonSeps.SPACE);
        stringBuffer.append(StringUtil.getInstance().toString(nextUnvisitedPathGeographicMapCellPosition));
        stringBuffer.append(this.positionStrings.DX_LABEL);
        stringBuffer.appendint(dx);
        stringBuffer.append(this.commonSeps.SPACE);
        stringBuffer.append(this.positionStrings.DY_LABEL);
        stringBuffer.appendint(dy);
        stringBuffer.append(this.commonSeps.SPACE);
        stringBuffer.append(reason);
        this.logUtil.putF(stringBuffer.ToString(), this, "selected: trackTo");
    }

    public override void turnTo(PathFindingLayerInterface associatedAdvancedRTSGameLayer, int dx, int dy, AngleInfo angleInfo, int angle, NamedAngle movementAngle, bool evading, int targetAngle)
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(associatedAdvancedRTSGameLayer.getName());
        stringBuffer.append(" steering - ");
        stringBuffer.append(this.positionStrings.DX_LABEL);
        stringBuffer.appendint(dx);
        stringBuffer.append(this.commonSeps.SPACE);
        stringBuffer.append(this.positionStrings.DY_LABEL);
        stringBuffer.appendint(dy);
        stringBuffer.append(" angle: ");
        stringBuffer.appendint(angle);
        stringBuffer.append(" movementAngle: ");
        stringBuffer.append(movementAngle.name);
        stringBuffer.append(this.commonSeps.FORWARD_SLASH);
        stringBuffer.appendshort(((short) movementAngle.getValue()));
        if (angleInfo != null) {
            short angleIncrement = angleInfo.getAngleIncrementInfo().getAngleIncrement();
            stringBuffer.append(" angleIncrement: ");
            stringBuffer.appendshort(angleIncrement);
        }
        stringBuffer.append(" Evading: ");
        stringBuffer.appendboolean(evading);
        this.logUtil.putF(stringBuffer.ToString(), this, this.TRACKTO_TURNTO);
    }

    public override void doneMoving(PathFindingLayerInterface associatedAdvancedRTSGameLayer)
    {
        this.logUtil.putF(new StringMaker().append(associatedAdvancedRTSGameLayer.getName()).append(" steering - done moving 0,0").ToString(), this, this.TRACKTO_TURNTO);
    }

    public override void closeEnough(PathFindingLayerInterface associatedAdvancedRTSGameLayer)
    {
        this.logUtil.putF(new StringMaker().append(associatedAdvancedRTSGameLayer.getName()).append(" steering - close enough").ToString(), this, this.TRACKTO_TURNTO);
    }

    public override void movingLeft(PathFindingLayerInterface associatedAdvancedRTSGameLayer)
    {
        this.logUtil.putF(new StringMaker().append(associatedAdvancedRTSGameLayer.getName()).append(" steering - allow movingLeft").ToString(), this, this.TRACKTO_TURNTO);
    }

    public override void movingRight(PathFindingLayerInterface associatedAdvancedRTSGameLayer)
    {
        this.logUtil.putF(new StringMaker().append(associatedAdvancedRTSGameLayer.getName()).append(" steering - allow movingRight").ToString(), this, this.TRACKTO_TURNTO);
    }

    public override void movingUp(PathFindingLayerInterface associatedAdvancedRTSGameLayer)
    {
        this.logUtil.putF(new StringMaker().append(associatedAdvancedRTSGameLayer.getName()).append(" steering - allow movingUp").ToString(), this, this.TRACKTO_TURNTO);
    }

    public override void movingDown(PathFindingLayerInterface associatedAdvancedRTSGameLayer)
    {
        this.logUtil.putF(new StringMaker().append(associatedAdvancedRTSGameLayer.getName()).append(" steering - allow movingDown").ToString(), this, this.TRACKTO_TURNTO);
    }

    public override void currentMoveEnded(PathFindingLayerInterface associatedAdvancedRTSGameLayer)
    {
        this.logUtil.putF(new StringMaker().append(associatedAdvancedRTSGameLayer.getName()).append(" steering - correct angle, but movement not needed for current deltas so reseting movement angle").ToString(), this, this.TRACKTO_TURNTO);
    }

    public override void evade(PathFindingLayerInterface associatedAdvancedRTSGameLayer)
    {
        this.logUtil.putF(new StringMaker().append(associatedAdvancedRTSGameLayer.getName()).append(" steering - evade").ToString(), this, this.TRACKTO_TURNTO);
    }

    public override void rotateLeft(PathFindingLayerInterface associatedAdvancedRTSGameLayer)
    {
        this.logUtil.putF(new StringMaker().append(associatedAdvancedRTSGameLayer.getName()).append(" steering - rotating left").ToString(), this, this.TRACKTO_TURNTO);
    }

    public override void rotateRight(PathFindingLayerInterface associatedAdvancedRTSGameLayer)
    {
        this.logUtil.putF(new StringMaker().append(associatedAdvancedRTSGameLayer.getName()).append(" steering - rotating right").ToString(), this, this.TRACKTO_TURNTO);
    }

    public override void handle(PathFindingLayerInterface associatedAdvancedRTSGameLayer, NamedAngle movementAngle)
    {
        this.logUtil.putF(new StringMaker().append(associatedAdvancedRTSGameLayer.getName()).append(" steering - movementAngle: ").append(movementAngle.name).append(this.commonSeps.FORWARD_SLASH).appendshort(((short) movementAngle.getValue())).ToString(), this, this.TRACKTO_TURNTO);
    }

    public override void noRotation(PathFindingLayerInterface associatedAdvancedRTSGameLayer)
    {
        this.logUtil.putF(new StringMaker().append(associatedAdvancedRTSGameLayer.getName()).append(" steering - Do not rotate").ToString(), this, this.TRACKTO_TURNTO);
    }

    public override void notOnPath(PathFindingLayerInterface associatedAdvancedRTSGameLayer, GeographicMapCellHistory geographicMapCellHistory, GeographicMapCellPosition currentGeographicMapCellPosition, BasicArrayList pathList)
    {
        StringUtil stringUtil = StringUtil.getInstance();
        this.logUtil.putF(new StringMaker().append(associatedAdvancedRTSGameLayer.getName()).append(CommonSeps.getInstance().SPACE).appendint(((int) geographicMapCellHistory.getTotalVisited())).append(CommonSeps.getInstance().SPACE).append(stringUtil.toString(currentGeographicMapCellPosition)).append(" - trying to move but not on path: ").append(stringUtil.toString(pathList)).ToString(), this, "turnTo");
    }

}

