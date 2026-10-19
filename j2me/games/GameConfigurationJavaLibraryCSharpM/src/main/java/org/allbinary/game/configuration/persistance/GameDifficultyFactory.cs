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

namespace org.allbinary.game.configuration.persistance;

public class GameDifficultyFactory
{
    private static readonly GameDifficultyFactory instance = new GameDifficultyFactory();
    public static GameDifficultyFactory getInstance()
    {
        return GameDifficultyFactory.instance;
    }

    private int level = 0;
    public virtual void setLevel(int level)
    {
        this.level = level;
    }

    public virtual int getLevel()
    {
        return this.level;
    }

}

