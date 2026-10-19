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
using CommonStrings = org.allbinary.@string.CommonStrings;
using AllBinaryTiledLayer = org.allbinary.game.layer.AllBinaryTiledLayer;
using StdUtil = org.allbinary.logic.StdUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using org.allbinary.util;

namespace org.allbinary.media.graphics.geography.map;

public class GeographicMapCellPositionFactory : GeographicMapCellPositionBaseFactory
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly ABHashtable<object, object> hashtable = StdUtil.getInstance().createHashtable();
    // throws Exception
    public override BasicGeographicMapCellPositionFactory getInstance(BasicGeographicMap geographicMapInterface)
    {
        CommonStrings commonStrings = CommonStrings.getInstance();
        AllBinaryTiledLayer allBinaryTiledLayer = geographicMapInterface.getAllBinaryTiledLayer();
        object geographicMapCellPositionFactoryCanBeNull = GeographicMapCellPositionFactory.hashtable.get(allBinaryTiledLayer.getDataId());
        if (geographicMapCellPositionFactoryCanBeNull == null) {
            this.logUtil.putF(new StringMaker().append("Creating GeographicMapCellPositionFactory for TileLayer: ").appendint(((int) ((int) allBinaryTiledLayer.getDataId()))).ToString(), this, commonStrings.GET_INSTANCE);
            geographicMapCellPositionFactoryCanBeNull = new BasicGeographicMapCellPositionFactory(geographicMapInterface);
            GeographicMapCellPositionFactory.hashtable.put(allBinaryTiledLayer.getDataId(), geographicMapCellPositionFactoryCanBeNull);
            return ((BasicGeographicMapCellPositionFactory) geographicMapCellPositionFactoryCanBeNull);
        } else {
            this.logUtil.putF(new StringMaker().append("Reusing GeographicMapCellPositionFactory for TileLayer: ").appendint(((int) ((int) allBinaryTiledLayer.getDataId()))).ToString(), this, commonStrings.GET_INSTANCE);
            return ((BasicGeographicMapCellPositionFactory) geographicMapCellPositionFactoryCanBeNull);
        }
    }

    public static ABHashtable<object, object> getHashtable()
    {
        return GeographicMapCellPositionFactory.hashtable;
    }

}

