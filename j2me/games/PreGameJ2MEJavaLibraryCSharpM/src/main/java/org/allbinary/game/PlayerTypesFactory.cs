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

public class PlayerTypesFactory
{
    public readonly PlayerType PLAYER_TYPE_ONE = new PlayerType("Player Type One", 0);
    public readonly PlayerType PLAYER_TYPE_TWO = new PlayerType("Player Type Two", 1);
    public readonly PlayerType PLAYER_TYPE_THREE = new PlayerType("Player Type Three", 2);
    private static readonly PlayerTypesFactory SINGLETON = new PlayerTypesFactory();
    public static PlayerTypesFactory getInstance()
    {
        return PlayerTypesFactory.SINGLETON;
    }

}

