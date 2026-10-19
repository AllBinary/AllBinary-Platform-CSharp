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

namespace org.allbinary.game.score.remote;

public class RemoteHighScoresData
{
    private static readonly RemoteHighScoresData SINGLETON = new RemoteHighScoresData();
    public static RemoteHighScoresData getInstance()
    {
        return RemoteHighScoresData.SINGLETON;
    }

    public readonly string HIGH_SCORES = "HIGH_SCORES";
    public string CUSTOMER_USER_NAME = "CUSTOMER_USER_NAME";
    public string DISPLAY_NAME = "DISPLAY_NAME";
    public string SCORE = "SCORE";
    public string GAME_INFO = "GAME_INFO";
    public string GAME_CONFIGURATION = "GAME_CONFIGURATION";
}

