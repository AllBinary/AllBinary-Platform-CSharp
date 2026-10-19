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

public class GameMode
{
    public static GameMode NONE = new GameMode(StringUtil.getInstance().NULL_STRING);
    public static GameMode SERVER = new GameMode("Server");
    public static GameMode CLIENT = new GameMode("Client");
    private string name = StringUtil.getInstance().EMPTY_STRING;
    private GameMode(string name)
    {
        this.setName(name);
    }

    private void setName(string name)
    {
        this.name = name;
    }

    public virtual string getName()
    {
        return this.name;
    }

    public override string ToString()
    {
        return this.getName();
    }

}

