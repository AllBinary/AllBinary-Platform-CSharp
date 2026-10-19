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
using TileLayerPositionIntoViewPosition = org.allbinary.game.view.TileLayerPositionIntoViewPosition;
using AllBinaryGameCanvas = org.allbinary.game.displayable.canvas.AllBinaryGameCanvas;
using AllBinaryTiledLayer = org.allbinary.game.layer.AllBinaryTiledLayer;
using BasicGeographicMap = org.allbinary.media.graphics.geography.map.BasicGeographicMap;
using GeographicMapCompositeInterface = org.allbinary.media.graphics.geography.map.GeographicMapCompositeInterface;

namespace org.allbinary.game.view;

public class TileLayerPositionIntoViewPositionUtil
{
    public static void init(AllBinaryGameCanvas gameCanvasInterface, TileLayerPositionIntoViewPosition viewPosition)
    {
        GeographicMapCompositeInterface geographicMapCompositeInterface = ((GeographicMapCompositeInterface) gameCanvasInterface.getLayerManager());
        BasicGeographicMap geographicMapInterface = geographicMapCompositeInterface.getGeographicMapInterface()[0];
        AllBinaryTiledLayer tiledLayer = geographicMapInterface.getAllBinaryTiledLayer();
        viewPosition.setTiledLayer(tiledLayer);
    }

}

