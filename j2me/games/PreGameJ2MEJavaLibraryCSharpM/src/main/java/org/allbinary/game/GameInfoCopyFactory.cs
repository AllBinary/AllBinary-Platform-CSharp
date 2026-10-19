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

public class GameInfoCopyFactory
{
    public static GameInfo getInstanceMaxLevel(GameInfo gameInfo, int maxLevel)
    {
        return new GameInfo(gameInfo.getGameType(), gameInfo.getGameMode(), gameInfo.getPlayerType(), maxLevel, gameInfo.getCurrentLevel());
    }

    public static GameInfo getInstance(GameInfo gameInfo)
    {
        return new GameInfo(gameInfo.getGameType(), gameInfo.getGameMode(), gameInfo.getPlayerType(), gameInfo.getHighestLevel(), gameInfo.getCurrentLevel());
    }

}

