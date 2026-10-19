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
using BasicArrayList = org.allbinary.util.BasicArrayList;
using CircularIndexUtil = org.allbinary.util.CircularIndexUtil;
using LayerCoveringCellPositionsUtil = org.allbinary.game.layer.geographic.map.LayerCoveringCellPositionsUtil;
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;
using BasicGeographicMap = org.allbinary.media.graphics.geography.map.BasicGeographicMap;
using CellPositionsUtil = org.allbinary.media.graphics.geography.map.CellPositionsUtil;
using GeographicMapCellPosition = org.allbinary.media.graphics.geography.map.GeographicMapCellPosition;
using BasicArrayListS = org.allbinary.util.BasicArrayListS;
using BasicArrayListUtil = org.allbinary.util.BasicArrayListUtil;

namespace org.allbinary.game.layer;

public class GeographicMapCellPositionArea : GeographicMapCellPositionAreaBase
{
    private readonly CellPositionsUtil cellPositionsUtil = CellPositionsUtil.getInstance();
    private readonly LayerCoveringCellPositionsUtil layerCoveringCellPositionsUtil = LayerCoveringCellPositionsUtil.getInstance();
    private readonly BasicArrayList reusableOccupyingGeographicMapCellPositionList = new BasicArrayListS(4);
    private readonly BasicArrayList reusableSurroundingGeographicMapCellPositionList = new BasicArrayListS(12);
    private readonly CircularIndexUtil surroundingCircularIndexUtil = CircularIndexUtil.createInstance(0);
    private readonly AllBinaryLayer layerInterface;
    private BasicArrayList LIST = BasicArrayListUtil.getInstance().getImmutableInstance();
    private BasicArrayList occupyingGeographicMapCellPositionList;
    private BasicArrayList surroundingGeographicMapCellPositionList;
    public GeographicMapCellPositionArea(AllBinaryLayer layerInterface)
    {
        this.occupyingGeographicMapCellPositionList = this.LIST;
        this.surroundingGeographicMapCellPositionList = this.LIST;
        this.layerInterface = layerInterface;
    }

    // throws Exception
    public override void update(BasicGeographicMap geographicMapInterface)
    {
        this.occupyingGeographicMapCellPositionList = this.layerCoveringCellPositionsUtil.getAllXY(geographicMapInterface, this.layerInterface, this.layerInterface.getXP(), this.layerInterface.getYP(), this.reusableOccupyingGeographicMapCellPositionList);
        this.surroundingGeographicMapCellPositionList = this.cellPositionsUtil.getAllSurrounding(geographicMapInterface, this.occupyingGeographicMapCellPositionList, this.reusableSurroundingGeographicMapCellPositionList);
        this.surroundingCircularIndexUtil.setSize(this.surroundingGeographicMapCellPositionList.size());
    }

    public override BasicArrayList getOccupyingGeographicMapCellPositionList()
    {
        return this.occupyingGeographicMapCellPositionList;
    }

    public override BasicArrayList getSurroundingGeographicMapCellPositionList()
    {
        return this.surroundingGeographicMapCellPositionList;
    }

    public override GeographicMapCellPosition getNextSurroundingGeographicMapCellPosition()
    {
        GeographicMapCellPosition geographicMapCellPosition = ((GeographicMapCellPosition) this.surroundingGeographicMapCellPositionList.get(this.surroundingCircularIndexUtil.getIndex()));
        this.surroundingCircularIndexUtil.next();
        return geographicMapCellPosition;
    }

}

