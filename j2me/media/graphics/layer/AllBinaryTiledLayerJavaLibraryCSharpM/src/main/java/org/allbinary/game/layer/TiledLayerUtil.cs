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

namespace org.allbinary.game.layer;

public class TiledLayerUtil
{
    private static readonly TiledLayerUtil instance = new TiledLayerUtil();
    public static TiledLayerUtil getInstance()
    {
        return TiledLayerUtil.instance;
    }

    public virtual int keepOnBorderdMapX(AllBinaryTiledLayer terrainTiledLayer, int x, int width, int mapBorderBufferWidth)
    {
        int newX = x;
        int maxRight = terrainTiledLayer.getWidth() - width - mapBorderBufferWidth;
        if (x + width > maxRight) {
            newX = maxRight;
        }
        if (x < mapBorderBufferWidth) {
            newX = mapBorderBufferWidth;
        }
        return newX;
    }

    public virtual int keepOnBorderdMapY(AllBinaryTiledLayer terrainTiledLayer, int y, int height, int mapBorderBufferHeight)
    {
        int newY = y;
        int maxBottom = terrainTiledLayer.getHeight() - height - mapBorderBufferHeight;
        if (y + height > maxBottom) {
            newY = maxBottom;
        }
        if (y < mapBorderBufferHeight) {
            newY = mapBorderBufferHeight;
        }
        return newY;
    }

    public virtual int keepOnMapX(AllBinaryTiledLayer terrainTiledLayer, int x, int width)
    {
        int newX = x;
        int maxRight = terrainTiledLayer.getWidth() - width;
        if (x >= maxRight) {
            newX = maxRight;
        }
        if (x < 0) {
            newX = 0;
        }
        return newX;
    }

    public virtual int keepOnMapY(AllBinaryTiledLayer terrainTiledLayer, int y, int height)
    {
        int newY = y;
        int maxBottom = terrainTiledLayer.getHeight() - height;
        if (y >= maxBottom) {
            newY = maxBottom;
        }
        if (y < 0) {
            newY = 0;
        }
        return newY;
    }

}

