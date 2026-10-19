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
using GameFeatureEvent = org.allbinary.game.configuration.@event.GameFeatureEvent;
using GameFeatureEventHandler = org.allbinary.game.configuration.@event.GameFeatureEventHandler;
using NullUtil = org.allbinary.logic.NullUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using PreLogUtil = org.allbinary.logic.communication.log.PreLogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using GenericOperatingSystem = org.allbinary.logic.system.os.GenericOperatingSystem;
using OperatingSystemFactory = org.allbinary.logic.system.os.OperatingSystemFactory;
using CommonLabels = org.allbinary.@string.CommonLabels;
using CommonStrings = org.allbinary.@string.CommonStrings;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.game.configuration.feature;

public class Features
{
    private static object SINGLETON = NullUtil.getInstance().NULL_OBJECT;
    public static Features getInstance()
    {
        if (Features.SINGLETON == NullUtil.getInstance().NULL_OBJECT) {
            Features.SINGLETON = new Features();
        }
        return ((Features) Features.SINGLETON);
    }

    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private readonly BasicArrayList list;
    private readonly BasicArrayList defaultList;
    private Features()
    {
        this.list = new BasicArrayListD();
        this.defaultList = new BasicArrayListD();
        this.init();
    }

    // throws Exception
    public virtual void addDefault(Feature gameFeature)
    {
        this.add(gameFeature);
        if (!this.defaultList.contains(gameFeature)) {
            this.defaultList.add(gameFeature);
        }
    }

    // throws Exception
    public virtual void add(Feature gameFeature)
    {
        if (!this.list.contains(gameFeature)) {
            this.logUtil.putF(new StringMaker().append(CommonLabels.getInstance().START_LABEL).append(gameFeature.ToString()).ToString(), this, this.commonStrings.ADD);
            this.list.add(gameFeature);
            GameFeatureEventHandler.getInstance().fireEvent(new GameFeatureEvent(gameFeature, gameFeature.ToString()));
        }
    }

    // throws Exception
    public virtual void removeDefault(Feature gameFeature)
    {
        this.logUtil.putF(new StringMaker().append(CommonLabels.getInstance().START_LABEL).append(gameFeature.ToString()).ToString(), this, "removeDefault");
        this.remove(gameFeature);
        this.defaultList.remove(gameFeature);
    }

    // throws Exception
    public virtual void remove(Feature gameFeature)
    {
        if (this.list.contains(gameFeature)) {
            this.logUtil.putF(this.commonStrings.START, this, this.commonStrings.REMOVE);
            this.list.remove(gameFeature);
            GameFeatureEventHandler.getInstance().fireEvent(new GameFeatureEvent(gameFeature, gameFeature.ToString()));
        }
    }

    private void init()
    {
        try {
            GameFeatureFactory gameFeatureFactory = GameFeatureFactory.getInstance();
            InputFeatureFactory inputFeatureFactory = InputFeatureFactory.getInstance();
            SensorFeatureFactory sensorFeatureFactory = SensorFeatureFactory.getInstance();
            TouchFeatureFactory touchFeatureFactory = TouchFeatureFactory.getInstance();
            this.addDefault(gameFeatureFactory.ARTIFICIAL_INTELLEGENCE_PROCESSOR);
            this.addDefault(gameFeatureFactory.COLLIDABLE_INTERFACE_LAYER_PROCESSOR);
            this.addDefault(gameFeatureFactory.GAME_INPUT_LAYER_PROCESSOR);
            this.addDefault(gameFeatureFactory.TICKABLE_LAYER_PROCESSOR);
            this.addDefault(inputFeatureFactory.MULTI_KEY_PRESS);
            this.addDefault(inputFeatureFactory.REMOVE_DUPLICATE_KEY_PRESSES);
            this.addDefault(gameFeatureFactory.SCREEN_SHAKE);
            this.addDefault(gameFeatureFactory.POST_IMAGE_LOADING_MODIFICATION);
            GenericOperatingSystem operatingSystemInterface = OperatingSystemFactory.getInstance().getOperatingSystemInstance();
            if (operatingSystemInterface.isOverScan()) {
                this.addDefault(sensorFeatureFactory.NO_ORIENTATION);
                this.addDefault(touchFeatureFactory.HIDE_SCREEN_BUTTONS);
            } else {
                this.addDefault(sensorFeatureFactory.ORIENTATION_SENSORS);
                this.addDefault(touchFeatureFactory.AUTO_HIDE_SHOW_SCREEN_BUTTONS);
            }
            this.addDefault(touchFeatureFactory.TOUCH_ENABLED);
            this.addDefault(MainFeatureFactory.getInstance().FULL_SCREEN);
            this.addDefault(MainFeatureFactory.getInstance().LOAD_ONDEMAND);
        } catch (Exception e) {
            PreLogUtil.putOE(this.commonStrings.EXCEPTION, this, this.commonStrings.INIT, e);
        }
    }

    public virtual bool isDefault(Feature gameFeature)
    {
        return this.defaultList.contains(gameFeature);
    }

    public virtual bool isFeature(Feature gameFeature)
    {
        return this.list.contains(gameFeature);
    }

    // throws Exception
    public virtual void toggle(Feature gameFeature)
    {
        if (this.isFeature(gameFeature)) {
            this.remove(gameFeature);
        } else {
            this.add(gameFeature);
        }
    }

}

