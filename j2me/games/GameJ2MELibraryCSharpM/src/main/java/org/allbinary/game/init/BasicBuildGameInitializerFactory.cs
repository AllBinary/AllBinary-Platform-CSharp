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

namespace org.allbinary.game.init;

public class BasicBuildGameInitializerFactory : GameInitializationInterfaceFactoryInterface
{
    public static BasicBuildGameInitializerFactory NULL_BASE_BUILD_GMAE_INITIALIZER_FACTORY = new BasicBuildGameInitializerFactory();
    public virtual GameInitializationInterface getInstance()
    {
        return BaseGameInitialization.NULL_BASE_GAME_INITIALIZATION;
    }

}

