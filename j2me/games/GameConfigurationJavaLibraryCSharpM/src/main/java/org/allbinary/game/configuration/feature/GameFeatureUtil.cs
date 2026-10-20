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
using java.util;
//using ChoiceGroup = javax.microedition.lcdui.ChoiceGroup;
using TsUtil = org.allbinary.TsUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using CommonLabels = org.allbinary.@string.CommonLabels;
using org.allbinary.util;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using EnumerationUtil = org.allbinary.util.EnumerationUtil;
using HashtableUtil = org.allbinary.util.HashtableUtil;

namespace org.allbinary.game.configuration.feature;

public class GameFeatureUtil
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly GameFeatureUtil instance = new GameFeatureUtil();
    public static GameFeatureUtil getInstance()
    {
        return GameFeatureUtil.instance;
    }

    private readonly TsUtil tsUtil = TsUtil.getInstance();
    private readonly EnumerationUtil enumerationUtil = EnumerationUtil.getInstance();
    public readonly string ON_GAME_FEATURE_CHANGE = "onGameFeatureChange";
    public readonly string GAME_FEATURE_CHANGED = "Game Feature Changed: ";
    // throws Exception
    public virtual void setDefault(ChoiceGroup choiceGroup)
    {
        StringMaker stringBuffer = new StringMaker();
        string METHOD_NAME = "setDefault";
        string SELECTED_ARRAY_RETURN = "selectedArray_return[";
        string SELECTED_SEP = "] = ";
        bool[] selectedArray_return = new bool[choiceGroup.size()];
        int total = choiceGroup.getSelectedFlags(selectedArray_return);
        stringBuffer.append("Multiple Total Choices: ");
        stringBuffer.appendint(total);
        this.logUtil.putF(stringBuffer.ToString(), this, METHOD_NAME);
        Features features = Features.getInstance();
        for (int index = 0; index < selectedArray_return.Length; index++) {
            bool isSelected = selectedArray_return[index];
            stringBuffer.delete(0, stringBuffer.length());
            stringBuffer.append(SELECTED_ARRAY_RETURN);
            stringBuffer.appendint(index);
            stringBuffer.append(SELECTED_SEP);
            stringBuffer.appendboolean(isSelected);
            this.logUtil.putF(stringBuffer.ToString(), this, METHOD_NAME);
            string selectedChoiceLabel = choiceGroup.getString(index);
            Feature gameFeature = Feature.getInstance(selectedChoiceLabel);
            if (features.isDefault(gameFeature)) {
                features.add(gameFeature);
                choiceGroup.setSelectedIndex(index, true);
            } else {
                features.remove(gameFeature);
                choiceGroup.setSelectedIndex(index, false);
            }
        }
    }

    // throws Exception
    public virtual void updateMultiple(ChoiceGroup choiceGroup)
    {
        StringMaker stringBuffer = new StringMaker();
        string METHOD_NAME = "updateMultiple";
        string SELECTED_ARRAY_RETURN = "selectedArray_return[";
        string SELECTED_SEP = "] = ";
        bool[] selectedArray_return = new bool[choiceGroup.size()];
        int total = choiceGroup.getSelectedFlags(selectedArray_return);
        stringBuffer.append("Multiple Total Choices: ");
        stringBuffer.appendint(total);
        this.logUtil.putF(stringBuffer.ToString(), this, METHOD_NAME);
        Features features = Features.getInstance();
        for (int index = 0; index < selectedArray_return.Length; index++) {
            bool isSelected = selectedArray_return[index];
            stringBuffer.delete(0, stringBuffer.length());
            stringBuffer.append(SELECTED_ARRAY_RETURN);
            stringBuffer.appendint(index);
            stringBuffer.append(SELECTED_SEP);
            stringBuffer.appendboolean(isSelected);
            this.logUtil.putF(stringBuffer.ToString(), this, METHOD_NAME);
            string selectedChoiceLabel = choiceGroup.getString(index);
            Feature gameFeature = Feature.getInstance(selectedChoiceLabel);
            if (!isSelected && features.isFeature(gameFeature)) {
                features.remove(gameFeature);
            } else if (isSelected && !features.isFeature(gameFeature)) {
                features.add(gameFeature);
            }
        }
    }

    // throws Exception
    public virtual void updateExclusiveForChoiceGroup(ChoiceGroup choiceGroup)
    {
        StringMaker stringBuffer = new StringMaker();
        string METHOD_NAME = "updateExclusive";
        string SELECTED_ARRAY_RETURN = "selectedArray_return[";
        string SELECTED_SEP = "] = ";
        bool[] selectedArray_return = new bool[choiceGroup.size()];
        int total = choiceGroup.getSelectedFlags(selectedArray_return);
        stringBuffer.append("Exclusive Total Choices: 1==");
        stringBuffer.appendint(total);
        this.logUtil.putF(stringBuffer.ToString(), this, METHOD_NAME);
        for (int index = 0; index < selectedArray_return.Length; index++) {
            bool isSelected = selectedArray_return[index];
            stringBuffer.delete(0, stringBuffer.length());
            stringBuffer.append(SELECTED_ARRAY_RETURN);
            stringBuffer.appendint(index);
            stringBuffer.append(SELECTED_SEP);
            stringBuffer.appendboolean(isSelected);
            this.logUtil.putF(stringBuffer.ToString(), this, METHOD_NAME);
            if (isSelected) {
                string selectedChoiceLabel = choiceGroup.getString(index);
                this.updateExclusive(selectedChoiceLabel);
            }
        }
    }

    public virtual bool isExclusive(string itemLabel)
    {
        Enumeration<object> enumeration = GameFeatureChoiceGroups.getExclusiveInstance().get().keys();
        string name = null;
        while (this.enumerationUtil.hasMoreElements(enumeration)) {
            name = ((string) this.enumerationUtil.nextElement(enumeration));
            if (this.tsUtil.compareTo(itemLabel, name) == 0) {
                return true;
            }
        }
        return false;
    }

    // throws Exception
    private void updateExclusive(string selectedChoiceLabel)
    {
        this.logUtil.putF(new StringMaker().append(CommonLabels.getInstance().ITEM_LABEL).append(selectedChoiceLabel).ToString(), this, "updateExclusive");
        Feature gameFeature = Feature.getInstance(selectedChoiceLabel);
        ABHashtable<object, object> hashtable = GameFeatureChoiceGroups.getExclusiveInstance().get();
        object[] objectArray = HashtableUtil.getInstance().getKeysAsArray(hashtable);
        BasicArrayList basicArrayList = null;
        object anyType = null;
        int size = objectArray.Length;
        for (int index = 0; index < size; index++) {
            anyType = ((object) objectArray[index]);
            basicArrayList = ((BasicArrayList) hashtable.get(anyType));
            this.updateExclusiveList(gameFeature, basicArrayList);
        }
    }

    // throws Exception
    public virtual void updateExclusiveList(Feature gameFeature, BasicArrayList list)
    {
        if (list.contains(gameFeature)) {
            Features features = Features.getInstance();
            int addIndex = list.indexOf(gameFeature);
            int size = list.size();
            for (int index = 0; index < size; index++) {
                if (addIndex != index) {
                    features.remove(((Feature) list.objectArray[index]));
                } else {
                    features.add(((Feature) list.objectArray[index]));
                }
            }
        }
    }

}

