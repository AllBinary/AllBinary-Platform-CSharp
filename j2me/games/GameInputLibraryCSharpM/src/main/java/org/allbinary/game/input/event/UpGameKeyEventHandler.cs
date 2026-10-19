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
using LocalPlayerInputIdFactory = org.allbinary.game.input.LocalPlayerInputIdFactory;
using EventListenerInterface = org.allbinary.logic.util.@event.EventListenerInterface;

namespace org.allbinary.game.input.@event;

public class UpGameKeyEventHandler : UpGameKeyEventHandlerBase
{
    private static readonly UpGameKeyEventHandler instance = new UpGameKeyEventHandler();
    private static readonly UpGameKeyEventHandlerBase[] instanceArray = new UpGameKeyEventHandlerBase[] { new UpGameKeyEventHandlerBase(), new UpGameKeyEventHandlerBase(), new UpGameKeyEventHandlerBase(), new UpGameKeyEventHandlerBase(), new UpGameKeyEventHandlerBase(), new UpGameKeyEventHandlerBase() };
    public static UpGameKeyEventHandler getInstance()
    {
        return UpGameKeyEventHandler.instance;
    }

    private readonly LocalPlayerInputIdFactory playerInputIdFactory = LocalPlayerInputIdFactory.getInstance();
    public virtual UpGameKeyEventHandlerBase getInstanceForDevice(int deviceId)
    {
        int playerInputId = this.playerInputIdFactory.getPlayerForDevice(deviceId);
        return UpGameKeyEventHandler.instanceArray[playerInputId];
    }

    public virtual UpGameKeyEventHandlerBase getInstanceForPlayer(int playerInputId)
    {
        return UpGameKeyEventHandler.instanceArray[playerInputId];
    }

    private UpGameKeyEventHandler()
    {
    }

    public override void removeAllListeners()
    {
        base.removeAllListeners();
        for (int index = UpGameKeyEventHandler.instanceArray.Length - 1; index >= 0; index--) {
            UpGameKeyEventHandler.instanceArray[index].removeAllListeners();
        }
    }

    public override void removeListenerSingleThreaded(EventListenerInterface eventListenerInterface)
    {
        base.removeListenerSingleThreaded(eventListenerInterface);
        for (int index = UpGameKeyEventHandler.instanceArray.Length - 1; index >= 0; index--) {
            UpGameKeyEventHandler.instanceArray[index].removeListenerSingleThreaded(eventListenerInterface);
        }
    }

    public override void removeListener(EventListenerInterface eventListenerInterface)
    {
        base.removeListener(eventListenerInterface);
        for (int index = UpGameKeyEventHandler.instanceArray.Length - 1; index >= 0; index--) {
            UpGameKeyEventHandler.instanceArray[index].removeListener(eventListenerInterface);
        }
    }

}

