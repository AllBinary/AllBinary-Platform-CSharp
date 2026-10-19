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
using System.Runtime.CompilerServices;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using EventListenerInterface = org.allbinary.logic.util.@event.EventListenerInterface;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.game.input.@event;

public class GameKeyEventHandler
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly GameKeyEventHandler instance = new GameKeyEventHandler();
    public static GameKeyEventHandler getInstance()
    {
        return GameKeyEventHandler.instance;
    }

    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private readonly PressGameKeyEventHandler pressGameKeyEventHandler = PressGameKeyEventHandler.getInstance();
    private readonly UpGameKeyEventHandler upGameKeyEventHandler = UpGameKeyEventHandler.getInstance();
    private readonly DownGameKeyEventHandler downGameKeyEventHandler = DownGameKeyEventHandler.getInstance();
    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual void removeAllListeners()
    {
        this.pressGameKeyEventHandler.removeAllListeners();
        this.upGameKeyEventHandler.removeAllListeners();
        this.downGameKeyEventHandler.removeAllListeners();
    }

    public virtual void addListenerForPlayer(EventListenerInterface eventListenerInterface, int playerInputId)
    {
        this.logUtil.putF(eventListenerInterface.ToString(), this, this.commonStrings.ADD_LISTENER);
        this.pressGameKeyEventHandler.addListenerSingleThreaded(eventListenerInterface);
        this.upGameKeyEventHandler.getInstanceForPlayer(playerInputId).addListenerSingleThreaded(eventListenerInterface);
        this.downGameKeyEventHandler.getInstanceForPlayer(playerInputId).addListenerSingleThreaded(eventListenerInterface);
    }

    public virtual void addListener(EventListenerInterface eventListenerInterface)
    {
        this.logUtil.putF(eventListenerInterface.ToString(), this, this.commonStrings.ADD_LISTENER);
        this.pressGameKeyEventHandler.addListenerSingleThreaded(eventListenerInterface);
        this.upGameKeyEventHandler.addListenerSingleThreaded(eventListenerInterface);
        this.downGameKeyEventHandler.addListenerSingleThreaded(eventListenerInterface);
    }

    public virtual void removeListener(EventListenerInterface eventListenerInterface)
    {
        this.logUtil.putF(eventListenerInterface.ToString(), this, this.commonStrings.REMOVE_LISTENER);
        this.pressGameKeyEventHandler.removeListenerSingleThreaded(eventListenerInterface);
        this.upGameKeyEventHandler.removeListenerSingleThreaded(eventListenerInterface);
        this.downGameKeyEventHandler.removeListenerSingleThreaded(eventListenerInterface);
    }

}

