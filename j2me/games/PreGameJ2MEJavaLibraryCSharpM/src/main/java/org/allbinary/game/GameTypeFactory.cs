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
using StringUtil = org.allbinary.logic.@string.StringUtil;

namespace org.allbinary.game;

public class GameTypeFactory
{
    private static readonly GameTypeFactory instance = new GameTypeFactory();
    public static GameTypeFactory getInstance()
    {
        return GameTypeFactory.instance;
    }

    public GameType[] NULL_GAME_TYPE_ARRAY = new GameType[0];
    public GameType NONE = new GameType(StringUtil.getInstance().NULL_STRING);
    public GameType SINGLE_PLAYER = new GameType("Single Player");
    public GameType MULTI_PLAYER = new GameType("Multi Player");
    public GameType BOT = new GameType("Artificial Player");
}

