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
using GameInitializedEvent = org.allbinary.game.configuration.@event.GameInitializedEvent;
using GameInitializedEventHandler = org.allbinary.game.configuration.@event.GameInitializedEventHandler;
using GameInitializedListenerInterface = org.allbinary.game.configuration.@event.GameInitializedListenerInterface;
using FeatureResourceInitializationUtil = org.allbinary.game.resource.FeatureResourceInitializationUtil;
using SWTJOGLProcessor = org.allbinary.graphics.threed.SWTJOGLProcessor;
using ForcedLogUtil = org.allbinary.logic.communication.log.ForcedLogUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using AllBinaryEventObject = org.allbinary.logic.util.@event.AllBinaryEventObject;
using EventStrings = org.allbinary.logic.util.@event.EventStrings;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.game.init;

public class DefaultGameInitializationListener : GameInitializedListenerInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly SWTJOGLProcessor swtJOGLProcessor = SWTJOGLProcessor.getInstance();
    public DefaultGameInitializationListener()
    {
        GameInitializedEventHandler gameInitializedEventHandler = GameInitializedEventHandler.getInstance();
        gameInitializedEventHandler.removeAllListeners();
        gameInitializedEventHandler.addListenerInterface(((GameInitializedListenerInterface) this));
    }

    public virtual void onEvent(AllBinaryEventObject eventObject)
    {
        ForcedLogUtil.log(EventStrings.getInstance().PERFORMANCE_MESSAGE, this);
    }

    public bool firstTime = true;
    public virtual void onGameInitialized(GameInitializedEvent gameInitializedEvent)
    {
        string ON_GAME_INITIALIZED = "onGameInitialized";
        CommonStrings commonStrings = CommonStrings.getInstance();
        try {
            this.logUtil.putF(commonStrings.START, this, ON_GAME_INITIALIZED);
            while (!this.swtJOGLProcessor.isHolderCreated()) {
                this.logUtil.putF(commonStrings.UPDATE, this, ON_GAME_INITIALIZED);
                System.Threading.Thread.Sleep((int) (20));
            }
            FeatureResourceInitializationUtil.getInstance().init(gameInitializedEvent.getLevel());
            if (this.firstTime) {
                this.firstTime = false;
            } else {
                this.swtJOGLProcessor.onSurfaceChanged();
            }
        } catch (Exception e) {
            this.logUtil.put(commonStrings.EXCEPTION, this, ON_GAME_INITIALIZED, e);
        }
    }

}

