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
using System.Runtime.CompilerServices;

namespace org.allbinary.media.graphics.geography.map.racetrack;

public class FinalPositionRaceTrackFactory
{
    public static readonly int FIRST_POSITION = 1;
    private static int index = FinalPositionRaceTrackFactory.FIRST_POSITION;
    private FinalPositionRaceTrackFactory()
    {
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public static int getInstance()
    {
        return FinalPositionRaceTrackFactory.index++;
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public static void reset()
    {
        FinalPositionRaceTrackFactory.index = FinalPositionRaceTrackFactory.FIRST_POSITION;
    }

}

