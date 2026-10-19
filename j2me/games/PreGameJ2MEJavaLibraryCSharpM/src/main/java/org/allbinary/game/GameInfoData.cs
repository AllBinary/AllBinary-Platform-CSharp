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

namespace org.allbinary.game;

public class GameInfoData
{
    private static readonly GameInfoData instance = new GameInfoData();
    public static GameInfoData getInstance()
    {
        return GameInfoData.instance;
    }

    private GameInfoData()
    {
    }

    public readonly string GAME_TYPE = "GAME_TYPE";
    public readonly string GAME_MODE = "GAME_MODE";
    public readonly string PLAYER_TYPE = "PLAYER_TYPE";
    public readonly string HIGHEST_LEVEL = "HIGHEST_LEVEL";
    public readonly string CURRENT_LEVEL = "CURRENT_LEVEL";
    public readonly string SOFTWARE_INFORMATION = "SOFTWARE_INFORMATION";
}

