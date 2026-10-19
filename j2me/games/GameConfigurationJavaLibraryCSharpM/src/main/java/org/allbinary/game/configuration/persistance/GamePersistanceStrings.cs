/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2025 AllBinary 
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

public class GamePersistanceStrings
{
    private static readonly GamePersistanceStrings instance = new GamePersistanceStrings();
    public static GamePersistanceStrings getInstance()
    {
        return GamePersistanceStrings.instance;
    }

    public readonly string SAVED_GAME_RECORD_ID = "_SG";
    public readonly string SAVED_GAME_CONFIGURATION_RECORD_ID = "_SGC";
    public readonly string DEFAULT_INPUT_MAPPING_RECORD_ID = "_DIM";
    public readonly string SAVED_INPUT_CONFIGURATION_RECORD_ID = "_SIC";
}

