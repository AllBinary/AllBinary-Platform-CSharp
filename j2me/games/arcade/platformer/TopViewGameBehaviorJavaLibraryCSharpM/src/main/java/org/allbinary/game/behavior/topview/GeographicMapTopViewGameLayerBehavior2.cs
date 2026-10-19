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
using MultiGeographicMapBehavior = org.allbinary.media.graphics.geography.map.MultiGeographicMapBehavior;
using AllBinaryTiledLayer = org.allbinary.game.layer.AllBinaryTiledLayer;
using GravityUtil = org.allbinary.game.physics.acceleration.GravityUtil;
using VelocityProperties = org.allbinary.game.physics.velocity.VelocityProperties;
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;
using BasicGeographicMap = org.allbinary.media.graphics.geography.map.BasicGeographicMap;
using GeographicMapCellPosition = org.allbinary.media.graphics.geography.map.GeographicMapCellPosition;
using GeographicMapCellType = org.allbinary.media.graphics.geography.map.GeographicMapCellType;
using SimpleGeographicMapCellPositionFactory = org.allbinary.media.graphics.geography.map.SimpleGeographicMapCellPositionFactory;

namespace org.allbinary.game.behavior.topview;

public class GeographicMapTopViewGameLayerBehavior2 : GeographicMapTopViewLayerBehavior
{
    private readonly GravityUtil gravityUtil = GravityUtil.getInstance();
    private readonly MultiGeographicMapBehavior geographicMapBehavior = new MultiGeographicMapBehavior();
    private readonly bool autoStepBlocks;
    private readonly int offsetY;
    private GeographicMapCellPosition previousGeographicMapCellPosition = SimpleGeographicMapCellPositionFactory.NULL_GEOGRAPHIC_MAP_CELL_POSITION;
    public GeographicMapTopViewGameLayerBehavior2(int maxGravityActionIndex, bool autoStepBlocks, int offsetY) : base(maxGravityActionIndex)
    {
        // base(maxGravityActionIndex) is called from the constructor declaration
        this.autoStepBlocks = autoStepBlocks;
        this.offsetY = offsetY;
    }

    // throws Exception
    public override void gravity(VelocityProperties velocityProperties, BasicGeographicMap[] geographicMapInterfaceArray, GeographicMapCellType[] geographicMapCellTypeArray, GeographicMapCellPosition geographicMapCellPosition)
    {
        if (geographicMapCellPosition != SimpleGeographicMapCellPositionFactory.NULL_GEOGRAPHIC_MAP_CELL_POSITION) {
            this.geographicMapBehavior.getCellTypeAt(geographicMapInterfaceArray, geographicMapCellTypeArray, geographicMapCellPosition);
            bool hasSolidBlock = this.hasSolidBlock(geographicMapInterfaceArray, geographicMapCellTypeArray);
            if (!hasSolidBlock) {
                this.gravityUtil.process(velocityProperties, this.gravityUtil.GAME_GRAVITY_VELOCITY);
                velocityProperties.limitXYToForwardAndReverseMaxVelocity();
                this.gravity();
            } else {
            }
        }
    }

    // throws Exception
    private GeographicMapCellPosition getPositionTopLeft(BasicGeographicMap[] geographicMapInterfaceArray, AllBinaryLayer layer, int x, int y)
    {
        int xCellPosition = layer.getXP() + -x;
        int yCellPosition = layer.getYP() + -y;
        return geographicMapInterfaceArray[0].getCellPositionAtXYNoThrow(xCellPosition, yCellPosition);
    }

    // throws Exception
    private GeographicMapCellPosition getPositionTopRight(BasicGeographicMap[] geographicMapInterfaceArray, AllBinaryLayer layer, int x, int y)
    {
        int xCellPosition = layer.getXP() + -x + layer.getWidth();
        int yCellPosition = layer.getYP() + -y;
        return geographicMapInterfaceArray[0].getCellPositionAtXYNoThrow(xCellPosition, yCellPosition);
    }

    // throws Exception
    private GeographicMapCellPosition getPositionBottomLeft(BasicGeographicMap[] geographicMapInterfaceArray, AllBinaryLayer layer, int x, int y)
    {
        int xCellPosition = layer.getXP() + -x;
        int yCellPosition = layer.getYP() + -y + layer.getHeight();
        return geographicMapInterfaceArray[0].getCellPositionAtXYNoThrow(xCellPosition, yCellPosition);
    }

    // throws Exception
    private GeographicMapCellPosition getPositionBottomRight(BasicGeographicMap[] geographicMapInterfaceArray, AllBinaryLayer layer, int x, int y)
    {
        int xCellPosition = layer.getXP() + -x + layer.getWidth();
        int yCellPosition = layer.getYP() + -y + layer.getHeight();
        return geographicMapInterfaceArray[0].getCellPositionAtXYNoThrow(xCellPosition, yCellPosition);
    }

    // throws Exception
    private GeographicMapCellPosition getLeftPosition(BasicGeographicMap[] geographicMapInterfaceArray, AllBinaryLayer layer)
    {
        int xCellPosition = layer.getXP();
        int yCellPosition = layer.getYP() + layer.getHeight();
        return geographicMapInterfaceArray[0].getCellPositionAtXYNoThrow(xCellPosition, yCellPosition);
    }

    // throws Exception
    private GeographicMapCellPosition getRightPosition(BasicGeographicMap[] geographicMapInterfaceArray, AllBinaryLayer layer)
    {
        int xCellPosition = layer.getXP() + layer.getWidth();
        int yCellPosition = layer.getYP() + layer.getHeight();
        return geographicMapInterfaceArray[0].getCellPositionAtXYNoThrow(xCellPosition, yCellPosition);
    }

    // throws Exception
    public override GeographicMapCellPosition getGeographicMapCellPositionIfNotSolidBlockOrOffMapLocation(BasicGeographicMap[] geographicMapInterfaceArray, GeographicMapCellType[] geographicMapCellTypeArray, VelocityProperties velocityProperties, AllBinaryLayer layer, int x, int y)
    {
        GeographicMapCellPosition geographicMapCellPosition = SimpleGeographicMapCellPositionFactory.NULL_GEOGRAPHIC_MAP_CELL_POSITION;
        GeographicMapCellPosition topLeftGeographicMapCellPosition = this.getPositionTopLeft(geographicMapInterfaceArray, layer, x, y);
        geographicMapCellPosition = this.getGeographicMapCellPositionIfNotSolidBlockOrOffMap(geographicMapInterfaceArray, geographicMapCellTypeArray, topLeftGeographicMapCellPosition, velocityProperties, layer);
        if (geographicMapCellPosition == SimpleGeographicMapCellPositionFactory.NULL_GEOGRAPHIC_MAP_CELL_POSITION) {
            return SimpleGeographicMapCellPositionFactory.NULL_GEOGRAPHIC_MAP_CELL_POSITION;
        }
        GeographicMapCellPosition topRightGeographicMapCellPosition = this.getPositionTopRight(geographicMapInterfaceArray, layer, x, y);
        geographicMapCellPosition = this.getGeographicMapCellPositionIfNotSolidBlockOrOffMap(geographicMapInterfaceArray, geographicMapCellTypeArray, topRightGeographicMapCellPosition, velocityProperties, layer);
        if (geographicMapCellPosition == SimpleGeographicMapCellPositionFactory.NULL_GEOGRAPHIC_MAP_CELL_POSITION) {
            return SimpleGeographicMapCellPositionFactory.NULL_GEOGRAPHIC_MAP_CELL_POSITION;
        }
        GeographicMapCellPosition bottomLeftGeographicMapCellPosition = this.getPositionBottomLeft(geographicMapInterfaceArray, layer, x, y);
        geographicMapCellPosition = this.getGeographicMapCellPositionIfNotSolidBlockOrOffMap(geographicMapInterfaceArray, geographicMapCellTypeArray, bottomLeftGeographicMapCellPosition, velocityProperties, layer);
        if (geographicMapCellPosition == SimpleGeographicMapCellPositionFactory.NULL_GEOGRAPHIC_MAP_CELL_POSITION) {
            return SimpleGeographicMapCellPositionFactory.NULL_GEOGRAPHIC_MAP_CELL_POSITION;
        }
        GeographicMapCellPosition bottomRightGeographicMapCellPosition = this.getPositionBottomRight(geographicMapInterfaceArray, layer, x, y);
        geographicMapCellPosition = this.getGeographicMapCellPositionIfNotSolidBlockOrOffMap(geographicMapInterfaceArray, geographicMapCellTypeArray, bottomRightGeographicMapCellPosition, velocityProperties, layer);
        if (geographicMapCellPosition == SimpleGeographicMapCellPositionFactory.NULL_GEOGRAPHIC_MAP_CELL_POSITION) {
        } else {
        }
        return geographicMapCellPosition;
    }

    // throws Exception
    public override GeographicMapCellPosition getGeographicMapCellPositionIfNotSolidBlockOrOffMap(BasicGeographicMap[] geographicMapInterfaceArray, GeographicMapCellType[] geographicMapCellTypeArray, GeographicMapCellPosition geographicMapCellPosition, VelocityProperties velocityProperties, AllBinaryLayer layer)
    {
        if (geographicMapCellPosition != SimpleGeographicMapCellPositionFactory.NULL_GEOGRAPHIC_MAP_CELL_POSITION) {
            GeographicMapCellPosition possibleStepGeographicMapCellPosition = geographicMapCellPosition;
            AllBinaryTiledLayer tiledLayer = geographicMapInterfaceArray[0].getAllBinaryTiledLayer();
            if (possibleStepGeographicMapCellPosition.getColumn() > 0 && possibleStepGeographicMapCellPosition.getRow() > 0 && possibleStepGeographicMapCellPosition.getColumn() < tiledLayer.getColumns() && possibleStepGeographicMapCellPosition.getRow() < tiledLayer.getRows()) {
                this.geographicMapBehavior.getCellTypeAt(geographicMapInterfaceArray, geographicMapCellTypeArray, possibleStepGeographicMapCellPosition);
                bool hasSolidBlock = this.hasSolidBlock(geographicMapInterfaceArray, geographicMapCellTypeArray);
                bool hasOffMap = this.isOffMap(geographicMapInterfaceArray, geographicMapCellTypeArray);
                if (hasSolidBlock || hasOffMap) {
                    this.previousGeographicMapCellPosition = SimpleGeographicMapCellPositionFactory.NULL_GEOGRAPHIC_MAP_CELL_POSITION;
                    return SimpleGeographicMapCellPositionFactory.NULL_GEOGRAPHIC_MAP_CELL_POSITION;
                } else {
                    this.previousGeographicMapCellPosition = possibleStepGeographicMapCellPosition;
                    return possibleStepGeographicMapCellPosition;
                }
            }
        } else {
        }
        this.previousGeographicMapCellPosition = SimpleGeographicMapCellPositionFactory.NULL_GEOGRAPHIC_MAP_CELL_POSITION;
        return SimpleGeographicMapCellPositionFactory.NULL_GEOGRAPHIC_MAP_CELL_POSITION;
    }

    // throws Exception
    public override void moveAndLand(BasicGeographicMap[] geographicMapInterfaceArray, GeographicMapCellType[] geographicMapCellTypeArray, GeographicMapCellPosition geographicMapCellPosition, VelocityProperties velocityProperties, AllBinaryLayer layer, int x, int y)
    {
        if (geographicMapCellPosition != SimpleGeographicMapCellPositionFactory.NULL_GEOGRAPHIC_MAP_CELL_POSITION) {
            TopViewCharacterInterface topViewCharacterInterface = (((TopViewCharacterInterface) layer));
            topViewCharacterInterface.terrainMove(geographicMapInterfaceArray, geographicMapCellTypeArray, x, y);
        } else {
        }
    }

    // throws Exception
    public override bool move(BasicGeographicMap[] geographicMapInterfaceArray, GeographicMapCellType[] geographicMapCellTypeArray, VelocityProperties velocityProperties, AllBinaryLayer layer, int x, int y)
    {
        GeographicMapCellPosition geographicMapCellPosition = this.getGeographicMapCellPositionIfNotSolidBlockOrOffMapLocation(geographicMapInterfaceArray, geographicMapCellTypeArray, velocityProperties, layer, x, y);
        this.moveAndLand(geographicMapInterfaceArray, geographicMapCellTypeArray, geographicMapCellPosition, velocityProperties, layer, x, y);
        if (geographicMapCellPosition == SimpleGeographicMapCellPositionFactory.NULL_GEOGRAPHIC_MAP_CELL_POSITION) {
            return false;
        } else {
            return true;
        }
    }

    // throws Exception
    public override void left(BasicGeographicMap[] geographicMapInterfaceArray, GeographicMapCellType[] geographicMapCellTypeArray, VelocityProperties velocityProperties, AllBinaryLayer layer)
    {
        GeographicMapCellPosition geographicMapCellPosition = this.getLeftPosition(geographicMapInterfaceArray, layer);
        if (geographicMapCellPosition != SimpleGeographicMapCellPositionFactory.NULL_GEOGRAPHIC_MAP_CELL_POSITION) {
            GeographicMapCellPosition possibleStepGeographicMapCellPosition = geographicMapInterfaceArray[0].getGeographicMapCellPositionFactory().getAt(geographicMapCellPosition.getColumn(), geographicMapCellPosition.getRow() - 1);
            this.geographicMapBehavior.getCellTypeAt(geographicMapInterfaceArray, geographicMapCellTypeArray, possibleStepGeographicMapCellPosition);
            bool hasSolidBlock = this.hasSolidBlock(geographicMapInterfaceArray, geographicMapCellTypeArray);
            if (hasSolidBlock) {
                if (this.autoStepBlocks) {
                    TopViewCharacterInterface topViewCharacterInterface = (((TopViewCharacterInterface) layer));
                    topViewCharacterInterface.leftp();
                } else {
                    velocityProperties.getVelocityXBasicDecimalP().setint(0);
                }
            } else {
                TopViewCharacterInterface topViewCharacterInterface = (((TopViewCharacterInterface) layer));
                topViewCharacterInterface.leftp();
            }
        }
    }

    // throws Exception
    public override void right(BasicGeographicMap[] geographicMapInterfaceArray, GeographicMapCellType[] geographicMapCellTypeArray, VelocityProperties velocityProperties, AllBinaryLayer layer)
    {
        GeographicMapCellPosition geographicMapCellPosition = this.getRightPosition(geographicMapInterfaceArray, layer);
        if (geographicMapCellPosition != SimpleGeographicMapCellPositionFactory.NULL_GEOGRAPHIC_MAP_CELL_POSITION) {
            GeographicMapCellPosition possibleStepGeographicMapCellPosition = geographicMapInterfaceArray[0].getGeographicMapCellPositionFactory().getAt(geographicMapCellPosition.getColumn(), geographicMapCellPosition.getRow() - 1);
            this.geographicMapBehavior.getCellTypeAt(geographicMapInterfaceArray, geographicMapCellTypeArray, possibleStepGeographicMapCellPosition);
            bool hasSolidBlock = this.hasSolidBlock(geographicMapInterfaceArray, geographicMapCellTypeArray);
            if (hasSolidBlock) {
                if (this.autoStepBlocks) {
                    TopViewCharacterInterface topViewCharacterInterface = (((TopViewCharacterInterface) layer));
                    topViewCharacterInterface.rightp();
                } else {
                    velocityProperties.getVelocityXBasicDecimalP().setint(0);
                }
            } else {
                TopViewCharacterInterface topViewCharacterInterface = (((TopViewCharacterInterface) layer));
                topViewCharacterInterface.rightp();
            }
        }
    }

}

