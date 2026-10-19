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
using StdUtil = org.allbinary.logic.StdUtil;
using org.allbinary.util;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.game.configuration;

public class GameConfigurationSingleton
{
    private static GameConfigurationSingleton SINGLETON = new GameConfigurationSingleton();
    private BasicArrayList list;
    private ABHashtable<object, object> hashtable;
    public static GameConfigurationSingleton getInstance()
    {
        return GameConfigurationSingleton.SINGLETON;
    }

    private GameConfigurationSingleton()
    {
        this.list = new BasicArrayListD();
        this.hashtable = StdUtil.getInstance().createHashtable();
    }

    public virtual GameConfiguration getInstanceByName(string name)
    {
        return ((GameConfiguration) this.hashtable.get(name));
    }

    public virtual BasicArrayList getOptionsBasicArrayList()
    {
        return this.list;
    }

    public virtual void add(GameConfiguration gameConfiguration)
    {
        this.list.add(gameConfiguration);
    }

    public virtual ABHashtable<object, object> getHashtable()
    {
        return this.hashtable;
    }

}

