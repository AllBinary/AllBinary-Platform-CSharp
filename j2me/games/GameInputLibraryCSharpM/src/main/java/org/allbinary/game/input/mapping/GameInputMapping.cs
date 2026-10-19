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
using GameKey = org.allbinary.game.input.GameKey;
using StringUtil = org.allbinary.logic.@string.StringUtil;

namespace org.allbinary.game.input.mapping;

public class GameInputMapping
{
    private string name = StringUtil.getInstance().EMPTY_STRING;
    private GameKey gameKey = GameKey.NULL_GAME_KEY;
    public GameInputMapping(string name, GameKey gameKey)
    {
        this.setName(name);
        this.setGameKey(gameKey);
    }

    private void setGameKey(GameKey gameKey)
    {
        this.gameKey = gameKey;
    }

    public virtual GameKey getGameKey()
    {
        return this.gameKey;
    }

    private void setName(string name)
    {
        this.name = name;
    }

    public virtual string getName()
    {
        return this.name;
    }

}

