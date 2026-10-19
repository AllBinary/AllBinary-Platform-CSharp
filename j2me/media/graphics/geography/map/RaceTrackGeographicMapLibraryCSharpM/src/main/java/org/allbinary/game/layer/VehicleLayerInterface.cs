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
using RotationAnimation = org.allbinary.animation.RotationAnimation;
using LayerInterface = org.allbinary.layer.LayerInterface;
using BasicDecimal = org.allbinary.logic.math.BasicDecimal;
using GeographicMapCellHistory = org.allbinary.media.graphics.geography.map.GeographicMapCellHistory;
using GeographicMapCellPositionTracking = org.allbinary.media.graphics.geography.map.GeographicMapCellPositionTracking;

namespace org.allbinary.game.layer;

public interface VehicleLayerInterface : LayerInterface, VehiclePropertiesCompositeInterface
{
    BasicArrayList getGameKeyEventList();

    BasicDecimal getSpeedBasicDecimal();

    bool isReadyForExplosion();

    RotationAnimation getRotationAnimationInterface();

    void setRotationAnimationInterface(RotationAnimation animationInterface);

    bool isDestroyed();

    bool isFinish();

    int getFinalPosition();

    // throws Exception
    void handleFinish();

    GeographicMapCellPositionTracking getGeographicMapCellPositionTracking();

    GeographicMapCellHistory[] getGeographicMapCellHistoryArray();

    void setGeographicMapCellHistoryArray(GeographicMapCellHistory[] geographicMapCellHistory);

}

