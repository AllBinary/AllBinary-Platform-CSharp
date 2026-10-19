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
using GeographicMapInterface = org.allbinary.media.graphics.geography.map.GeographicMapInterface;

namespace org.allbinary.media.graphics.geography.map.racetrack;

public interface RaceTrackGeographicMapInterface : GeographicMapInterface
{
    RaceTrackInfo getRaceTrackInfo();

    void setRaceTrackInfo(RaceTrackInfo aRaceTrackInfo);

    RaceTrackData getRaceTrackData();

    void setRaceTrackData(RaceTrackData raceTrackData);

}

