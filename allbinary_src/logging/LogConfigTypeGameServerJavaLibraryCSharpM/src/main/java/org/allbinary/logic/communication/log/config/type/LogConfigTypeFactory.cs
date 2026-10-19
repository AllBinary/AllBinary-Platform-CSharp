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
using LogConfigTypes = org.allbinary.logic.communication.log.config.type.LogConfigTypes;
using LogConfigTypeFactory = org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory;

namespace org.allbinary.logic.communication.log.config.type;

public class LogConfigTypeFactory
{
    private static readonly LogConfigTypeFactory instance = new LogConfigTypeFactory();
    public static LogConfigTypeFactory getInstance()
    {
        return LogConfigTypeFactory.instance;
    }

    private readonly string NO_DESCRIPTION = "No Description";
    public readonly LogConfigType INIT_SERVER;
    public readonly LogConfigType LOBBY_SERVER;
    public readonly LogConfigType GAME_SERVER;
    public readonly LogConfigType GAME_SIMULATOR;
    public readonly LogConfigType CUSTOM_TYPES;
    private LogConfigTypeFactory()
    {
        this.INIT_SERVER = new LogConfigType("Init Server", this.NO_DESCRIPTION);
        this.LOBBY_SERVER = new LogConfigType("Lobby Server", this.NO_DESCRIPTION);
        this.GAME_SERVER = new LogConfigType("Game Server", this.NO_DESCRIPTION);
        this.GAME_SIMULATOR = new LogConfigType("Game Simulator", this.NO_DESCRIPTION);
        this.CUSTOM_TYPES = new LogConfigType("Custom Types", this.NO_DESCRIPTION);
        LogConfigTypes.LOGGING.add(this.INIT_SERVER);
    }

}

