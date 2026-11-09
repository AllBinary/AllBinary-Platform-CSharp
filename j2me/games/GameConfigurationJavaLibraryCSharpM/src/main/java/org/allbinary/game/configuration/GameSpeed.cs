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

namespace org.allbinary.game.configuration;

public class GameSpeed
{
    private static readonly GameSpeed instance = new GameSpeed();
    public int getSpeed()
    {
        GameConfiguration speedGameConfiguration = GameConfigurationCentral.getInstance().SPEED;
        return (global::java.lang.JavaNumber.intValue(speedGameConfiguration.getMaxValue()) - global::java.lang.JavaNumber.intValue(speedGameConfiguration.getValue()) + 1);
    }

    public int getDelay()
    {
        GameConfiguration speedGameConfiguration = GameConfigurationCentral.getInstance().SPEED;
        return 19 * (global::java.lang.JavaNumber.intValue(speedGameConfiguration.getMaxValue()) - global::java.lang.JavaNumber.intValue(speedGameConfiguration.getValue()));
    }

    public static GameSpeed getInstance()
    {
        return GameSpeed.instance;
    }

}

