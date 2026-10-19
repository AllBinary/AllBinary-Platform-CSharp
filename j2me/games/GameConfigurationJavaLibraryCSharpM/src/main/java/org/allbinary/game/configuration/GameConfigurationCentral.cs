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
using GameConfigurationPersistanceSingleton = org.allbinary.game.configuration.persistance.GameConfigurationPersistanceSingleton;
using KeyValuePersistance = org.allbinary.game.configuration.persistance.KeyValuePersistance;
using NullUtil = org.allbinary.logic.NullUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using SmallIntegerSingletonFactory = org.allbinary.logic.math.SmallIntegerSingletonFactory;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using AbeClientInformationInterface = org.allbinary.logic.system.security.licensing.AbeClientInformationInterface;
using CommonSeps = org.allbinary.@string.CommonSeps;
using CommonStrings = org.allbinary.@string.CommonStrings;
using org.allbinary.util;
using BasicArrayList = org.allbinary.util.BasicArrayList;

namespace org.allbinary.game.configuration;

public class GameConfigurationCentral
{
    private static object SINGLETON = NullUtil.getInstance().NULL_OBJECT;
    public static GameConfigurationCentral getInstance()
    {
        if (GameConfigurationCentral.SINGLETON == NullUtil.getInstance().NULL_OBJECT) {
            GameConfigurationCentral.SINGLETON = new GameConfigurationCentral();
        }
        return ((GameConfigurationCentral) GameConfigurationCentral.SINGLETON);
    }

    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly GameConfiguration SCALE;
    public readonly GameConfiguration ORIENTATION;
    public readonly GameConfiguration SENSOR_UPDATE_RATE;
    public readonly GameConfiguration VIBRATION;
    public readonly GameConfiguration CHALLENGE_LEVEL;
    public readonly GameConfiguration COLLIDE_DAMAGE;
    public readonly GameConfiguration DURABILITY_CHALLENGE_LEVEL;
    public readonly GameConfiguration SPEED_CHALLENGE_LEVEL;
    public readonly GameConfiguration ATTACK_CHALLENGE_LEVEL;
    public readonly GameConfiguration CONTROL_LEVEL;
    public readonly GameConfiguration PLAYER_INPUT_WAIT;
    public readonly GameConfiguration SPEED;
    public readonly GameConfiguration SOUND_VOLUME;
    public readonly GameConfiguration MAX_GAME_OBJECTS;
    public readonly GameConfiguration MAX_LAYERS;
    private int gameControlFidelity = 36;
    private GameConfigurationCentral()
    {
        SmallIntegerSingletonFactory smallIntegerSingletonFactory = SmallIntegerSingletonFactory.getInstance();
        this.SCALE = new GameConfiguration("Scale", smallIntegerSingletonFactory.getAt(2), smallIntegerSingletonFactory.getAt(2), smallIntegerSingletonFactory.getAt(3));
        this.ORIENTATION = new GameConfiguration("Orientation", smallIntegerSingletonFactory.getAt(0), smallIntegerSingletonFactory.getAt(0), smallIntegerSingletonFactory.getAt(8));
        this.SENSOR_UPDATE_RATE = new GameConfiguration("Sensor Update Rate", smallIntegerSingletonFactory.getAt(0), smallIntegerSingletonFactory.getAt(0), smallIntegerSingletonFactory.getAt(3));
        this.VIBRATION = new GameConfiguration("Vibration", smallIntegerSingletonFactory.getAt(0), smallIntegerSingletonFactory.getAt(0), smallIntegerSingletonFactory.getAt(3));
        this.CHALLENGE_LEVEL = new GameConfiguration("Global Challenge Level", smallIntegerSingletonFactory.getAt(3), smallIntegerSingletonFactory.getAt(1), smallIntegerSingletonFactory.getAt(10));
        this.COLLIDE_DAMAGE = new GameConfiguration("Collide Damage Challenge Level", smallIntegerSingletonFactory.getAt(3), smallIntegerSingletonFactory.getAt(1), smallIntegerSingletonFactory.getAt(10));
        this.DURABILITY_CHALLENGE_LEVEL = new GameConfiguration("Enemy Durability Challenge Level", smallIntegerSingletonFactory.getAt(3), smallIntegerSingletonFactory.getAt(1), smallIntegerSingletonFactory.getAt(10));
        this.SPEED_CHALLENGE_LEVEL = new GameConfiguration("Enemy Speed Challenge Level", smallIntegerSingletonFactory.getAt(3), smallIntegerSingletonFactory.getAt(1), smallIntegerSingletonFactory.getAt(10));
        this.ATTACK_CHALLENGE_LEVEL = new GameConfiguration("Enemy Attack Challenge Level", smallIntegerSingletonFactory.getAt(3), smallIntegerSingletonFactory.getAt(1), smallIntegerSingletonFactory.getAt(10));
        this.CONTROL_LEVEL = new GameConfiguration("Control Fidelity", smallIntegerSingletonFactory.getAt(5), smallIntegerSingletonFactory.getAt(1), smallIntegerSingletonFactory.getAt(10));
        this.PLAYER_INPUT_WAIT = new GameConfiguration("Input Wait", smallIntegerSingletonFactory.getAt(5), smallIntegerSingletonFactory.getAt(1), smallIntegerSingletonFactory.getAt(10));
        this.SPEED = new GameConfiguration("Game Speed (Device Specific)", smallIntegerSingletonFactory.getAt(5), smallIntegerSingletonFactory.getAt(1), smallIntegerSingletonFactory.getAt(10));
        this.SOUND_VOLUME = new GameConfiguration("Sound Volume", smallIntegerSingletonFactory.getAt(6), smallIntegerSingletonFactory.getAt(0), smallIntegerSingletonFactory.getAt(10));
        this.MAX_GAME_OBJECTS = new GameConfiguration("Max Game Objects", smallIntegerSingletonFactory.getAt(20), smallIntegerSingletonFactory.getAt(1), smallIntegerSingletonFactory.getAt(50));
        this.MAX_LAYERS = new GameConfiguration("Max Layers", smallIntegerSingletonFactory.getAt(20), smallIntegerSingletonFactory.getAt(1), smallIntegerSingletonFactory.getAt(50));
    }

    public virtual void load(AbeClientInformationInterface abeClientInformation)
    {
        CommonStrings commonStrings = CommonStrings.getInstance();
        try {
            SmallIntegerSingletonFactory smallIntegerSingletonFactory = SmallIntegerSingletonFactory.getInstance();
            KeyValuePersistance keyValuePersistance = GameConfigurationPersistanceSingleton.getInstance();
            keyValuePersistance.clear();
            keyValuePersistance.loadAll(abeClientInformation);
            BasicArrayList list = keyValuePersistance.getIds();
            if (list.size() > 0) {
                ABHashtable<object, object> hashtable = keyValuePersistance.get(0);
                object anyType = ((object) this.SCALE.getName());
                string value = ((string) hashtable.get(anyType));
                this.SCALE.setValue(smallIntegerSingletonFactory.getAt(((int) (value).ToString())));
            } else {
                this.logUtil.putF("No Game Configuration To Load", this, commonStrings.LOAD);
            }
        } catch (Exception e) {
            this.logUtil.put(commonStrings.EXCEPTION, this, commonStrings.LOAD, e);
        }
    }

    public virtual void setGameControlFidelity(int gameControlFidelity)
    {
        this.gameControlFidelity = gameControlFidelity;
    }

    public virtual int getGameControlFidelity()
    {
        return this.gameControlFidelity;
    }

    public override string ToString()
    {
        StringMaker stringBuffer = new StringMaker();
        CommonSeps commonStrings = CommonSeps.getInstance();
        stringBuffer.append(commonStrings.COMMA_SEP);
        stringBuffer.append(this.SCALE.getName());
        stringBuffer.append(commonStrings.EQUALS);
        stringBuffer.appendint(((int) ((int) this.SCALE.getValue())));
        stringBuffer.append(commonStrings.COMMA_SEP);
        stringBuffer.append(this.ORIENTATION.getName());
        stringBuffer.append(commonStrings.EQUALS);
        stringBuffer.appendint(((int) ((int) this.ORIENTATION.getValue())));
        stringBuffer.append(commonStrings.COMMA_SEP);
        stringBuffer.append(this.SENSOR_UPDATE_RATE.getName());
        stringBuffer.append(commonStrings.EQUALS);
        stringBuffer.appendint(((int) ((int) this.SENSOR_UPDATE_RATE.getValue())));
        stringBuffer.append(commonStrings.COMMA_SEP);
        stringBuffer.append(this.VIBRATION.getName());
        stringBuffer.append(commonStrings.EQUALS);
        stringBuffer.appendint(((int) ((int) this.VIBRATION.getValue())));
        stringBuffer.append(commonStrings.COMMA_SEP);
        stringBuffer.append(this.CHALLENGE_LEVEL.getName());
        stringBuffer.append(commonStrings.EQUALS);
        stringBuffer.appendint(((int) ((int) this.CHALLENGE_LEVEL.getValue())));
        stringBuffer.append(commonStrings.COMMA_SEP);
        stringBuffer.append(this.COLLIDE_DAMAGE.getName());
        stringBuffer.append(commonStrings.EQUALS);
        stringBuffer.appendint(((int) ((int) this.COLLIDE_DAMAGE.getValue())));
        stringBuffer.append(commonStrings.COMMA_SEP);
        stringBuffer.append(this.DURABILITY_CHALLENGE_LEVEL.getName());
        stringBuffer.append(commonStrings.EQUALS);
        stringBuffer.appendint(((int) ((int) this.DURABILITY_CHALLENGE_LEVEL.getValue())));
        stringBuffer.append(commonStrings.COMMA_SEP);
        stringBuffer.append(this.SPEED_CHALLENGE_LEVEL.getName());
        stringBuffer.append(commonStrings.EQUALS);
        stringBuffer.appendint(((int) ((int) this.SPEED_CHALLENGE_LEVEL.getValue())));
        stringBuffer.append(commonStrings.COMMA_SEP);
        stringBuffer.append(this.ATTACK_CHALLENGE_LEVEL.getName());
        stringBuffer.append(commonStrings.EQUALS);
        stringBuffer.appendint(((int) ((int) this.ATTACK_CHALLENGE_LEVEL.getValue())));
        stringBuffer.append(commonStrings.COMMA_SEP);
        stringBuffer.append(this.CONTROL_LEVEL.getName());
        stringBuffer.append(commonStrings.EQUALS);
        stringBuffer.appendint(((int) ((int) this.CONTROL_LEVEL.getValue())));
        stringBuffer.append(commonStrings.COMMA_SEP);
        stringBuffer.append(this.SPEED.getName());
        stringBuffer.append(commonStrings.EQUALS);
        stringBuffer.appendint(((int) ((int) this.SPEED.getValue())));
        stringBuffer.append(commonStrings.COMMA_SEP);
        stringBuffer.append(this.MAX_GAME_OBJECTS.getName());
        stringBuffer.append(commonStrings.EQUALS);
        stringBuffer.appendint(((int) ((int) this.MAX_GAME_OBJECTS.getValue())));
        stringBuffer.append(commonStrings.COMMA_SEP);
        stringBuffer.append(this.MAX_LAYERS.getName());
        stringBuffer.append(commonStrings.EQUALS);
        stringBuffer.appendint(((int) ((int) this.MAX_LAYERS.getValue())));
        return stringBuffer.ToString();
    }

}

