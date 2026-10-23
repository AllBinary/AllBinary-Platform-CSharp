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
using GameFeature = org.allbinary.game.configuration.feature.GameFeature;

namespace org.allbinary.media.graphics.geography.map.racetrack;

public class RaceTrackGameFeature : GameFeature
{
    public static readonly GameFeature MINI_MAP = new RaceTrackGameFeature("Mini Map");
    public static readonly GameFeature AUTO_FINISH_AI = new RaceTrackGameFeature("Auto Finish AI");
    public RaceTrackGameFeature(string name) : base(name)
    {
        // base(name) is called from the constructor declaration
    }

}

