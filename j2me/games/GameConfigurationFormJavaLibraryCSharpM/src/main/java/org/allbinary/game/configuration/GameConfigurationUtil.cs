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
//using Item = javax.microedition.lcdui.Item;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using SmallIntegerSingletonFactory = org.allbinary.logic.math.SmallIntegerSingletonFactory;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.game.configuration;

public class GameConfigurationUtil
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly GameConfigurationUtil instance = new GameConfigurationUtil();
    public static GameConfigurationUtil getInstance()
    {
        return GameConfigurationUtil.instance;
    }

    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    // throws Exception
    public virtual void change(GameOptionsForm gameOptionsForm, GameConfigurationGauge gauge)
    {
        this.update(gauge);
        GameConfigurationSingleton gameConfigurationSingleton = GameConfigurationSingleton.getInstance();
        GameConfiguration gameConfiguration = gameConfigurationSingleton.getInstanceByName(gauge.getLabel());
        this.updateChallange(gameOptionsForm, gameConfiguration);
    }

    private readonly string GAUGE_UPDATE = "Gauge Update: ";
    private readonly string FROM = " from: ";
    private readonly string TO = " to: ";
    // throws Exception
    public virtual void update(GameConfigurationGauge gauge)
    {
        GameConfigurationSingleton gameConfigurationSingleton = GameConfigurationSingleton.getInstance();
        GameConfiguration gameConfiguration = gameConfigurationSingleton.getInstanceByName(gauge.getLabel());
        SmallIntegerSingletonFactory smallIntegerSingletonFactory = SmallIntegerSingletonFactory.getInstance();
        int? value = smallIntegerSingletonFactory.getAt(gauge.getValue() + ((int) gameConfiguration.getMinValue()));
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(this.GAUGE_UPDATE);
        stringBuffer.append(gameConfiguration.getName());
        stringBuffer.append(this.FROM);
        stringBuffer.appendint(((int) ((int) gameConfiguration.getValue())));
        stringBuffer.append(this.TO);
        stringBuffer.appendint(((int) ((int) value)));
        this.logUtil.putF(stringBuffer.ToString(), this, this.commonStrings.UPDATE);
        gameConfiguration.setValue(value);
    }

    // throws Exception
    public virtual void setDefault(GameConfigurationGauge gauge)
    {
        GameConfigurationSingleton gameConfigurationSingleton = GameConfigurationSingleton.getInstance();
        GameConfiguration gameConfiguration = gameConfigurationSingleton.getInstanceByName(gauge.getLabel());
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append("Gauge Default: ");
        stringBuffer.append(gameConfiguration.getName());
        stringBuffer.append(this.TO);
        stringBuffer.appendint(((int) ((int) gameConfiguration.getDefaultValue())));
        this.logUtil.putF(stringBuffer.ToString(), this, "setDefault");
        gauge.setValue(((int) gameConfiguration.getDefaultValue()) - ((int) gameConfiguration.getMinValue()));
        gameConfiguration.setValue(gameConfiguration.getDefaultValue());
    }

    // throws Exception
    public virtual void updateChallange(GameOptionsForm gameOptionsForm, GameConfiguration gameConfiguration)
    {
        GameConfigurationSingleton gameConfigurationSingleton = GameConfigurationSingleton.getInstance();
        GameConfigurationCentral gameConfigurationCentral = GameConfigurationCentral.getInstance();
        if (gameConfiguration == gameConfigurationCentral.CHALLENGE_LEVEL) {
            this.logUtil.putF(this.commonStrings.START, this, "updateChallange");
            gameConfigurationCentral.COLLIDE_DAMAGE.setValue(gameConfiguration.getValue());
            gameConfigurationCentral.ATTACK_CHALLENGE_LEVEL.setValue(gameConfiguration.getValue());
            gameConfigurationCentral.DURABILITY_CHALLENGE_LEVEL.setValue(gameConfiguration.getValue());
            gameConfigurationCentral.SPEED_CHALLENGE_LEVEL.setValue(gameConfiguration.getValue());
            int size = gameOptionsForm.size();
            for (int index = 0; index < size; index++) {
                Item item = gameOptionsForm.get(index);
                if (item is GameConfigurationGauge) {
                    GameConfigurationGauge gauge = ((GameConfigurationGauge) item);
                    string name = item.getLabel();
                    GameConfiguration nextGameConfiguration = gameConfigurationSingleton.getInstanceByName(name);
                    if (nextGameConfiguration == gameConfigurationCentral.COLLIDE_DAMAGE) {
                        gauge.setValue(((int) gameConfigurationCentral.COLLIDE_DAMAGE.getValue()) - ((int) gameConfiguration.getMinValue()));
                    } else if (nextGameConfiguration == gameConfigurationCentral.DURABILITY_CHALLENGE_LEVEL) {
                        gauge.setValue(((int) gameConfigurationCentral.DURABILITY_CHALLENGE_LEVEL.getValue()) - ((int) gameConfiguration.getMinValue()));
                    } else if (nextGameConfiguration == gameConfigurationCentral.ATTACK_CHALLENGE_LEVEL) {
                        gauge.setValue(((int) gameConfigurationCentral.ATTACK_CHALLENGE_LEVEL.getValue()) - ((int) gameConfiguration.getMinValue()));
                    } else if (nextGameConfiguration == gameConfigurationCentral.SPEED_CHALLENGE_LEVEL) {
                        gauge.setValue(((int) gameConfigurationCentral.SPEED_CHALLENGE_LEVEL.getValue()) - ((int) gameConfiguration.getMinValue()));
                    }
                }
            }
        }
    }

    private int COMPETITION_VALUE = 1;
    public virtual void updateCompetitionValue()
    {
        this.logUtil.putF(this.commonStrings.START, this, "updateCompetitionValue");
        GameConfigurationCentral gameConfigurationCentral = GameConfigurationCentral.getInstance();
        this.COMPETITION_VALUE = ((int) gameConfigurationCentral.COLLIDE_DAMAGE.getValue()) + ((int) gameConfigurationCentral.ATTACK_CHALLENGE_LEVEL.getValue()) + ((int) gameConfigurationCentral.DURABILITY_CHALLENGE_LEVEL.getValue()) + ((int) gameConfigurationCentral.SPEED_CHALLENGE_LEVEL.getValue());
        this.COMPETITION_VALUE = (this.COMPETITION_VALUE >> 2);
    }

    public virtual int getCompetitionValue()
    {
        return this.COMPETITION_VALUE;
    }

}

