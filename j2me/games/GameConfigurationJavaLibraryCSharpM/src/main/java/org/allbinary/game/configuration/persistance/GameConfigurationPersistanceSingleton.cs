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

namespace org.allbinary.game.configuration.persistance;

public class GameConfigurationPersistanceSingleton : KeyValuePersistance
{
    private static GameConfigurationPersistanceSingleton GAME_PERSISTANCE = new GameConfigurationPersistanceSingleton();
    public static GameConfigurationPersistanceSingleton getInstance()
    {
        return GameConfigurationPersistanceSingleton.GAME_PERSISTANCE;
    }

    private GameConfigurationPersistanceSingleton() : base(GamePersistanceStrings.getInstance().SAVED_GAME_CONFIGURATION_RECORD_ID)
    {
        // base(GamePersistanceStrings.getInstance().SAVED_GAME_CONFIGURATION_RECORD_ID) is called from the constructor declaration
    }

}

