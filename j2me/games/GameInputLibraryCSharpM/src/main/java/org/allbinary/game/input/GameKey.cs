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
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;

namespace org.allbinary.game.input;

public class GameKey : Input
{
    public static readonly GameKey NULL_GAME_KEY = new GameKey(-1, StringUtil.getInstance().NULL_STRING);
    public GameKey(int key, string name) : base(key, name)
    {
        // base(key, name) is called from the constructor declaration
    }

    public override string ToString()
    {
        return new StringMaker().append("GameKey ").append(base.ToString()).ToString();
    }

}

