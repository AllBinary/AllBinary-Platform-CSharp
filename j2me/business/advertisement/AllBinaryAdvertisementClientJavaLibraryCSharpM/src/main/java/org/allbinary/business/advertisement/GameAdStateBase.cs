/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2025 AllBinary 
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
using GameType = org.allbinary.game.GameType;
using GameState = org.allbinary.game.state.GameState;
using ForcedLogUtil = org.allbinary.logic.communication.log.ForcedLogUtil;
using AllBinaryEventObject = org.allbinary.logic.util.@event.AllBinaryEventObject;
using EventStrings = org.allbinary.logic.util.@event.EventStrings;

namespace org.allbinary.business.advertisement;

public class GameAdStateBase
{
    public readonly AdConfiguration adConfigurationP;
    public readonly Advertisements advertisementsP = new Advertisements();
    public bool okayToShowAdsP = false;
    public GameAdStateBase(AdConfiguration adConfiguration)
    {
        this.adConfigurationP = adConfiguration;
    }

    public virtual void initViewArray(object[] viewArray)
    {
    }

    public virtual void onStart(object anyType)
    {
        this.init();
    }

    public virtual void init()
    {
    }

    public virtual bool isShowingAtLocation(int location)
    {
        return false;
    }

    public virtual bool isShowingAt()
    {
        return false;
    }

    public virtual void show()
    {
    }

    public virtual void hide()
    {
    }

    public virtual void onEvent(AllBinaryEventObject eventObject)
    {
        ForcedLogUtil.log(EventStrings.getInstance().PERFORMANCE_MESSAGE, this);
    }

    public virtual void processAdState(GameState gameState, GameType gameType)
    {
    }

    public virtual void processPageAdState()
    {
    }

    // throws Exception
    public virtual void playingAdState()
    {
    }

    // throws Exception
    public virtual void playingAdStateWH(int width, int height)
    {
    }

    // throws Exception
    public virtual void notPlayingAdState()
    {
    }

    public virtual void setGameIsReady(bool gameIsReady)
    {
    }

    public virtual bool isGameIsReady()
    {
        return false;
    }

    public virtual Advertisements getAdvertisements()
    {
        return this.advertisementsP;
    }

    public virtual AdConfiguration getAdConfiguration()
    {
        return this.adConfigurationP;
    }

    public virtual bool isOkayToShowPageAd()
    {
        return false;
    }

    public virtual void setOkayToShowAds(bool okayToShowAds)
    {
        this.okayToShowAdsP = okayToShowAds;
    }

    public virtual bool isOkayToShowAds()
    {
        return this.okayToShowAdsP;
    }

    public virtual bool isEnabled()
    {
        return false;
    }

}

