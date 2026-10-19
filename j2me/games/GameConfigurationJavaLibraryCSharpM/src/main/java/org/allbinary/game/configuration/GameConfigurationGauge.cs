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
//using Gauge = javax.microedition.lcdui.Gauge;

namespace org.allbinary.game.configuration;

public class GameConfigurationGauge : Gauge
{
    public GameConfigurationGauge(GameConfiguration gameConfiguration) : base(gameConfiguration.getName(), gameConfiguration.isModifiable(), ((int) gameConfiguration.getMaxValue()) - ((int) gameConfiguration.getMinValue()), ((int) gameConfiguration.getValue()) - ((int) gameConfiguration.getMinValue()))
    {
        // base(gameConfiguration.getName(), gameConfiguration.isModifiable(), ((int) gameConfiguration.getMaxValue()) - ((int) gameConfiguration.getMinValue()), ((int) gameConfiguration.getValue()) - ((int) gameConfiguration.getMinValue())) is called from the constructor declaration
    }

}

