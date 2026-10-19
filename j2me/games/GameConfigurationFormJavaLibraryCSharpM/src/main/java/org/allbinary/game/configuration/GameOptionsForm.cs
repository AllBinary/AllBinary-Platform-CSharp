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
//using Choice = javax.microedition.lcdui.Choice;
//using Command = javax.microedition.lcdui.Command;
//using CommandListener = javax.microedition.lcdui.CommandListener;
//using Item = javax.microedition.lcdui.Item;
//using TextField = javax.microedition.lcdui.TextField;
using GameCommandsFactory = org.allbinary.game.commands.GameCommandsFactory;
using GameFeatureChoiceGroups = org.allbinary.game.configuration.feature.GameFeatureChoiceGroups;
using GameFeatureFormUtil = org.allbinary.game.configuration.feature.GameFeatureFormUtil;
using GameFeatureItemCommandListener = org.allbinary.game.configuration.feature.GameFeatureItemCommandListener;
using GameFeatureItemStateListener = org.allbinary.game.configuration.feature.GameFeatureItemStateListener;
using SensorFeatureFactory = org.allbinary.game.configuration.feature.SensorFeatureFactory;
using GameConfigurationPersistanceSingleton = org.allbinary.game.configuration.persistance.GameConfigurationPersistanceSingleton;
using KeyValuePersistance = org.allbinary.game.configuration.persistance.KeyValuePersistance;
using BasicColor = org.allbinary.graphics.color.BasicColor;
using MyCommandsFactory = org.allbinary.graphics.displayable.command.MyCommandsFactory;
using CommandForm = org.allbinary.graphics.displayable.screen.CommandForm;
using OrientationData = org.allbinary.input.gyro.OrientationData;
using MEUtil = org.allbinary.logic.MEUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using AbeClientInformationInterface = org.allbinary.logic.system.security.licensing.AbeClientInformationInterface;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using HashtableUtil = org.allbinary.util.HashtableUtil;
using StdUtil = org.allbinary.logic.StdUtil;
using org.allbinary.util;

namespace org.allbinary.game.configuration;

public class GameOptionsForm : CommandForm
{
    private readonly MEUtil meUtil = MEUtil.getInstance();
    public GameOptionsForm(CommandListener commandListener, string title, BasicColor backgrounBasicColor, BasicColor foregroundBasicColor) : base(commandListener, title, backgrounBasicColor, foregroundBasicColor)
    {
        // base(commandListener, title, backgrounBasicColor, foregroundBasicColor) is called from the constructor declaration
        this.logUtil.putF(this.commonStrings.START, this, this.commonStrings.CONSTRUCTOR);
        this.addConfiguration();
        GameFeatureFormUtil gameFeatureFormUtil = GameFeatureFormUtil.getInstance();
        gameFeatureFormUtil.addChoiceGroup(this, GameFeatureChoiceGroups.getExclusiveInstance().get(), Choice.EXCLUSIVE);
        gameFeatureFormUtil.addChoiceGroup(this, GameFeatureChoiceGroups.getMultipleInstance().get(), Choice.MULTIPLE);
        this.initCommands(commandListener);
        this.setItemStateListener(new GameFeatureItemStateListener(this));
        this.addTextFieldsIfSimulated();
    }

    // throws Exception
    public virtual void closeClientInformation(AbeClientInformationInterface abeClientInformation)
    {
        base.close();
        this.save(abeClientInformation);
    }

    private void addTextFieldsIfSimulated()
    {
        string key = OrientationData.getInstance().ORIENTATION_SENSOR_INPUT;
        ABHashtable<object, object> hashtable = GameFeatureChoiceGroups.getExclusiveInstance().get();
        if (hashtable != null) {
            object listCanBeNull = hashtable.get(key);
            if (listCanBeNull != null) {
                BasicArrayList list = ((BasicArrayList) listCanBeNull);
                if (list.contains(SensorFeatureFactory.getInstance().SIMULATED_ORIENTATION_SENSORS)) {
                    this.addTextFields();
                }
            }
        }
    }

    private void addTextFields()
    {
        ABHashtable<object, object> hashtable = GameConfigurationTextInput.getHashtable();
        int size = hashtable.size();
        object[] objectArray = HashtableUtil.getInstance().getKeysAsArray(hashtable);
        GameConfigurationTextInput gameConfigurationTextInput = null;
        TextField textField = null;
        for (int index = 0; index < size; index++) {
            gameConfigurationTextInput = ((GameConfigurationTextInput) hashtable.get(((object) objectArray[index])));
            textField = new TextField(gameConfigurationTextInput.getLabel(), gameConfigurationTextInput.getText(), 30, TextField.ANY);
            this.meUtil.appendItem(this, textField);
        }
    }

    private void addConfiguration()
    {
        string METHOD_NAME = "addConfiguration";
        string NAME = "Name: ";
        BasicArrayList list = GameConfigurationSingleton.getInstance().getOptionsBasicArrayList();
        Command GAUGE_CHANGE = MyCommandsFactory.getInstance().GAUGE_CHANGE;
        StringMaker stringMaker = new StringMaker();
        int size = list.size();
        GameConfiguration gameConfiguration = null;
        GameConfigurationGauge gauge = null;
        for (int index = 0; index < size; index++) {
            gameConfiguration = ((GameConfiguration) list.objectArray[index]);
            stringMaker.delete(0, stringMaker.length());
            this.logUtil.putF(stringMaker.append(NAME).append(gameConfiguration.ToString()).ToString(), this, METHOD_NAME);
            gauge = new GameConfigurationGauge(gameConfiguration);
            gauge.setDefaultCommand(GAUGE_CHANGE);
            gauge.setItemCommandListener(new GameFeatureItemCommandListener(this));
            this.meUtil.appendItem(this, gauge);
        }
    }

    public override void initCommands(CommandListener cmdListener)
    {
        GameCommandsFactory gameCommandsFactory = GameCommandsFactory.getInstance();
        this.removeAllCommands();
        this.addCommand(gameCommandsFactory.CLOSE_OPTIONS);
        this.addCommand(gameCommandsFactory.DEFAULT_OPTIONS);
        this.setCommandListener(cmdListener);
    }

    // throws Exception
    public virtual void save(AbeClientInformationInterface abeClientInformation)
    {
        int size = this.size();
        Item item = null;
        for (int index = 0; index < size; index++) {
            item = this.get(index);
            if (item is GameConfigurationGauge) {
                GameConfigurationUtil.getInstance().update(((GameConfigurationGauge) item));
            } else if (item is TextField) {
                GameConfigurationTextInput.update(((TextField) item));
            }
        }
        GameConfigurationUtil.getInstance().updateCompetitionValue();
        ABHashtable<object, object> hashtable = StdUtil.getInstance().createHashtable();
        GameConfiguration SCALE = GameConfigurationCentral.getInstance().SCALE;
        hashtable.put(SCALE.getName(), SCALE.getValue().ToString());
        KeyValuePersistance keyValuePersistance = GameConfigurationPersistanceSingleton.getInstance();
        keyValuePersistance.clear();
        keyValuePersistance.loadAll(abeClientInformation);
        BasicArrayList list = keyValuePersistance.getIds();
        keyValuePersistance.save(abeClientInformation, hashtable);
        int size2 = list.size();
        int? integer = null;
        for (int index = 0; index < size2; index++) {
            integer = ((int?) list.objectArray[index]);
            keyValuePersistance.delete(abeClientInformation, ((int) integer));
        }
    }

}

