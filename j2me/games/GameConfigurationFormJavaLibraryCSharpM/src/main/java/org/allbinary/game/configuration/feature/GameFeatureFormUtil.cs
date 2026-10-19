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
//using ChoiceGroup = javax.microedition.lcdui.ChoiceGroup;
//using Item = javax.microedition.lcdui.Item;
//using NullImage = javax.microedition.lcdui.NullImage;
using GameConfigurationGauge = org.allbinary.game.configuration.GameConfigurationGauge;
using GameConfigurationUtil = org.allbinary.game.configuration.GameConfigurationUtil;
using CommandForm = org.allbinary.graphics.displayable.screen.CommandForm;
using MEUtil = org.allbinary.logic.MEUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using org.allbinary.util;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using HashtableUtil = org.allbinary.util.HashtableUtil;

namespace org.allbinary.game.configuration.feature;

public class GameFeatureFormUtil
{
    private static readonly GameFeatureFormUtil instance = new GameFeatureFormUtil();
    public static GameFeatureFormUtil getInstance()
    {
        return GameFeatureFormUtil.instance;
    }

    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly MEUtil meUtil = MEUtil.getInstance();
    public virtual ChoiceGroup getChoiceGroup(ABHashtable<object, object> hashtable, string name, int option)
    {
        StringMaker stringMaker = new StringMaker();
        ChoiceGroup choiceGroup = new ChoiceGroup(name, option, StringUtil.getInstance().getArrayInstance(), NullImage.NULL_IMAGE_ARRAY);
        BasicArrayList list = ((BasicArrayList) hashtable.get(((object) name)));
        Features features = Features.getInstance();
        string ADD_CHOICE = ": Adding Choice: ";
        string GET_CHOICE_GROUP = "getChoiceGroup";
        int size = list.size();
        for (int index = 0; index < size; index++) {
            Feature gameFeature = ((Feature) list.objectArray[index]);
            stringMaker.delete(0, stringMaker.length());
            this.logUtil.putF(stringMaker.append(name).append(ADD_CHOICE).append(gameFeature.ToString()).ToString(), this, GET_CHOICE_GROUP);
            choiceGroup.append(gameFeature.ToString(), NullImage.NULL_IMAGE);
            if (features.isFeature(gameFeature)) {
                choiceGroup.setSelectedIndex(index, true);
            }
        }
        return choiceGroup;
    }

    public virtual void addChoiceGroup(CommandForm form, ABHashtable<object, object> hashtable, int option)
    {
        StringMaker stringMaker = new StringMaker();
        string ADDING_CHOICE_GROUP = "Adding Choice Group: ";
        string ADD_CHOICE_GROUP = "addChoiceGroup";
        int size = hashtable.size();
        object[] objectArray = HashtableUtil.getInstance().getKeysAsArray(hashtable);
        string name = null;
        for (int index = 0; index < size; index++) {
            name = ((string) objectArray[index]);
            stringMaker.delete(0, stringMaker.length());
            this.logUtil.putF(stringMaker.append(ADDING_CHOICE_GROUP).append(name).ToString(), this, ADD_CHOICE_GROUP);
            this.meUtil.appendItem(form, this.getChoiceGroup(hashtable, name, option));
        }
    }

    // throws Exception
    public virtual void setDefault(CommandForm form)
    {
        int size = form.size();
        for (int index = 0; index < size; index++) {
            Item item = form.get(index);
            if (item is GameConfigurationGauge) {
                GameConfigurationUtil.getInstance().setDefault(((GameConfigurationGauge) item));
            } else if (item is ChoiceGroup) {
                GameFeatureUtil.getInstance().setDefault(((ChoiceGroup) item));
            }
        }
    }

}

