/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2006 AllBinary 
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
//using TiledLayer = javax.microedition.lcdui.game.TiledLayer;
using CommonSeps = org.allbinary.@string.CommonSeps;
using StringMaker = org.allbinary.logic.@string.StringMaker;

namespace org.allbinary.game.layer;

public class AllBinaryJ2METiledLayer : AllBinaryTiledLayer
{
    public readonly TiledLayer tiledLayerP;
    public readonly int debugColor;
    public AllBinaryJ2METiledLayer(int? dataId, TiledLayer tiledLayer, int[][] mapTwoDArray, int debugColor) : base(dataId, tiledLayer.getWidth(), tiledLayer.getHeight(), tiledLayer.getCellWidth(), tiledLayer.getCellHeight())
    {
        // base(dataId, tiledLayer.getWidth(), tiledLayer.getHeight(), tiledLayer.getCellWidth(), tiledLayer.getCellHeight()) is called from the constructor declaration
        this.tiledLayerP = tiledLayer;
        this.debugColor = debugColor;
        this.setCells(mapTwoDArray);
    }

    public override void paint(Graphics graphics)
    {
        this.tiledLayerP.paint(graphics);
    }

    public readonly Font font2 = Font.getFont(Font.FACE_SYSTEM, Font.STYLE_PLAIN, 4);
    public virtual void paintDebug(Graphics graphics)
    {
        Font font = graphics.getFont();
        graphics.setFont(this.font2);
        graphics.setColor(this.debugColor);
        int x = this.tiledLayerP.getX();
        int y = this.tiledLayerP.getY();
        int firstColumn = 0;
        int firstRow = 0;
        int totalColumns = this.tiledLayerP.getColumns();
        int totalRows = this.tiledLayerP.getRows();
        int x0 = x;
        int tile = 0;
        int tileHeight = this.tiledLayerP.getCellHeight();
        int tileWidth = this.tiledLayerP.getCellWidth();
        CommonSeps commonSeps = CommonSeps.getInstance();
        StringMaker stringMaker = new StringMaker();
        for (int rowIndex = firstRow; rowIndex < totalRows; rowIndex++, y += tileHeight) {
            x = x0;
            for (int columnIndex = firstColumn; columnIndex < totalColumns; columnIndex++, x += tileWidth) {
                tile = this.tiledLayerP.getCell(columnIndex, rowIndex);
                if (tile < 0) {
                    tile = this.tiledLayerP.getAnimatedTile(tile);
                }
                if (tile == 0) {
                    continue;
                }
                tile--;
                stringMaker.delete(0, stringMaker.length());
                graphics.drawString(stringMaker.appendint(columnIndex).append(commonSeps.COMMA).appendint(rowIndex).append(commonSeps.COLON).appendint(tile).ToString(), x + 5, y + 10, 0);
            }
        }
        graphics.setFont(font);
    }

    public override void moveDXY(int dx, int dy)
    {
        this.tiledLayerP.move(dx, dy);
        base.moveDXY(-dx, -dy);
    }

    public override void setPosition(int x, int y, int z)
    {
        this.tiledLayerP.setPosition(x, y);
        base.setPosition(-x, -y, z);
    }

    public virtual TiledLayer getTiledLayer()
    {
        return this.tiledLayerP;
    }

    public override int getCellWidth()
    {
        return this.tiledLayerP.getCellWidth();
    }

    public override int getCellHeight()
    {
        return this.tiledLayerP.getCellHeight();
    }

    public override int getCell(int col, int row)
    {
        return this.tiledLayerP.getCell(col, row);
    }

    public override int getColumns()
    {
        return this.tiledLayerP.getColumns();
    }

    public override int getRows()
    {
        return this.tiledLayerP.getRows();
    }

    public override void setCell(int col, int row, int index)
    {
        this.tiledLayerP.setCell(col, row, index);
    }

    public override int getAnimatedTile(int animationTileIndex)
    {
        return this.tiledLayerP.getAnimatedTile(animationTileIndex);
    }

}

