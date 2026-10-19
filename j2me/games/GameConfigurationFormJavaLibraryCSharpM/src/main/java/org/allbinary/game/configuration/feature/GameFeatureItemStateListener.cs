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
//using ItemStateListener = javax.microedition.lcdui.ItemStateListener;
using GameConfigurationGauge = org.allbinary.game.configuration.GameConfigurationGauge;
using GameConfigurationUtil = org.allbinary.game.configuration.GameConfigurationUtil;
using GameOptionsForm = org.allbinary.game.configuration.GameOptionsForm;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using CommonLabels = org.allbinary.@string.CommonLabels;
using CommonStrings = org.allbinary.@string.CommonStrings;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.game.configuration.feature;

public class GameFeatureItemStateListener : ItemStateListener
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static BasicArrayList toggleList = new BasicArrayListD();
    private GameOptionsForm gameOptionsForm;
    public GameFeatureItemStateListener(GameOptionsForm gameOptionsForm)
    {
        this.gameOptionsForm = gameOptionsForm;
        GameFeatureFactory gameFeatureFactory = GameFeatureFactory.getInstance();
        GameFeatureItemStateListener.add(gameFeatureFactory.ARTIFICIAL_INTELLEGENCE_PROCESSOR);
        GameFeatureItemStateListener.add(gameFeatureFactory.COLLIDABLE_INTERFACE_LAYER_PROCESSOR);
        GameFeatureItemStateListener.add(gameFeatureFactory.DAMAGE_FLOATERS);
        GameFeatureItemStateListener.add(gameFeatureFactory.DROPPED_ITEMS);
        GameFeatureItemStateListener.add(gameFeatureFactory.GAME_INPUT_LAYER_PROCESSOR);
        GameFeatureItemStateListener.add(gameFeatureFactory.HEALTH_BARS);
        GameFeatureItemStateListener.add(gameFeatureFactory.SOUND);
        GameFeatureItemStateListener.add(gameFeatureFactory.TICKABLE_LAYER_PROCESSOR);
    }

    public static void add(GameFeature gameFeature)
    {
        if (!GameFeatureItemStateListener.toggleList.contains(gameFeature)) {
            GameFeatureItemStateListener.toggleList.add(gameFeature);
        }
    }

    public virtual void itemStateChanged(Item item)
    {
        try {
            string itemLabel = item.getLabel();
            this.logUtil.putF(new StringMaker().append(CommonLabels.getInstance().ITEM_LABEL).append(itemLabel).ToString(), this, "itemStateChanged");
            if (item is GameConfigurationGauge) {
                GameConfigurationUtil.getInstance().change(this.gameOptionsForm, ((GameConfigurationGauge) item));
            } else if (item is ChoiceGroup) {
                GameFeatureUtil gameFeatureUtil = GameFeatureUtil.getInstance();
                if (gameFeatureUtil.isExclusive(itemLabel)) {
                    gameFeatureUtil.updateExclusiveForChoiceGroup(((ChoiceGroup) item));
                } else {
                    gameFeatureUtil.updateMultiple(((ChoiceGroup) item));
                }
            }
        } catch (Exception e) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            this.logUtil.put(commonStrings.EXCEPTION, this, "itemStateChanged", e);
        }
    }

}

