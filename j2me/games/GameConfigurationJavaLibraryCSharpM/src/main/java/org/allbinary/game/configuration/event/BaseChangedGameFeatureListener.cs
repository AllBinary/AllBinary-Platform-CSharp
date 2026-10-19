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
using Feature = org.allbinary.game.configuration.feature.Feature;
using Features = org.allbinary.game.configuration.feature.Features;
using GameFeatureUtil = org.allbinary.game.configuration.feature.GameFeatureUtil;
using ForcedLogUtil = org.allbinary.logic.communication.log.ForcedLogUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using AllBinaryEventObject = org.allbinary.logic.util.@event.AllBinaryEventObject;
using CommonStrings = org.allbinary.@string.CommonStrings;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.game.configuration.@event;

public class BaseChangedGameFeatureListener : GameFeatureListenerInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly GameFeatureUtil gameFeatureUtil = GameFeatureUtil.getInstance();
    public readonly BasicArrayList list = new BasicArrayListD();
    private bool changed = true;
    public virtual void onEvent(AllBinaryEventObject eventObject)
    {
        ForcedLogUtil.log(CommonStrings.getInstance().NOT_IMPLEMENTED, this);
    }

    public virtual void onGameFeatureChange(GameFeatureEvent gameFeatureEvent)
    {
        this.logUtil.putF(new StringMaker().append(this.gameFeatureUtil.GAME_FEATURE_CHANGED).append(gameFeatureEvent.getWhatChanged()).ToString(), this, this.gameFeatureUtil.ON_GAME_FEATURE_CHANGE);
        this.list.add(gameFeatureEvent.getGameOption());
        this.setChanged(true);
    }

    public virtual void add(Feature gameFeature)
    {
        this.list.add(gameFeature);
    }

    public virtual void remove(Feature gameFeature)
    {
        this.list.remove(gameFeature);
    }

    public virtual void setChanged(bool initialized)
    {
        this.changed = initialized;
        if (!this.isChanged()) {
            this.list.clear();
        }
    }

    public virtual bool isChangedFeature(Feature gameFeature)
    {
        bool isChanged = this.list.contains(gameFeature);
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append("GameFeature: ");
        stringBuffer.append(StringUtil.getInstance().toString(gameFeature));
        stringBuffer.append(" isFeature: ");
        stringBuffer.appendboolean(Features.getInstance().isFeature(gameFeature));
        stringBuffer.append(" isChanged: ");
        stringBuffer.appendboolean(isChanged);
        this.logUtil.putF(stringBuffer.ToString(), this, "isChanged");
        return isChanged;
    }

    public virtual bool isChanged()
    {
        return this.changed;
    }

}

