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

public class BasicHighScoresGameInfoFactory
{
    private static readonly BasicHighScoresGameInfoFactory SINGLETON = new BasicHighScoresGameInfoFactory();
    public static BasicHighScoresGameInfoFactory getInstance()
    {
        return BasicHighScoresGameInfoFactory.SINGLETON;
    }

    public readonly GameInfo MULTI_PLAYER_SERVER = new GameInfo(GameTypeFactory.getInstance().MULTI_PLAYER, GameMode.SERVER, PlayerTypesFactory.getInstance().PLAYER_TYPE_ONE, 0, 0);
    public readonly GameInfo SINGLE_PLAYER_SERVER = new GameInfo(GameTypeFactory.getInstance().SINGLE_PLAYER, GameMode.SERVER, PlayerTypesFactory.getInstance().PLAYER_TYPE_ONE, 0, 0);
}

