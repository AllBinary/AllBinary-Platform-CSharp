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
//using Command = javax.microedition.lcdui.Command;
//using Item = javax.microedition.lcdui.Item;
//using ItemCommandListener = javax.microedition.lcdui.ItemCommandListener;
using GameConfigurationGauge = org.allbinary.game.configuration.GameConfigurationGauge;
using GameConfigurationUtil = org.allbinary.game.configuration.GameConfigurationUtil;
using GameOptionsForm = org.allbinary.game.configuration.GameOptionsForm;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using MidletStrings = org.allbinary.midlet.MidletStrings;
using CommonLabels = org.allbinary.@string.CommonLabels;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.game.configuration.feature;

public class GameFeatureItemCommandListener : ItemCommandListener
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private GameOptionsForm gameOptionsForm;
    public GameFeatureItemCommandListener(GameOptionsForm gameOptionsForm)
    {
        this.gameOptionsForm = gameOptionsForm;
    }

    public virtual void commandAction(Command command, Item item)
    {
        try {
            string itemLabel = item.getLabel();
            this.logUtil.putF(new StringMaker().append(CommonLabels.getInstance().ITEM_LABEL).append(itemLabel).ToString(), this, MidletStrings.getInstance().COMMAND_ACTION);
            if (item is GameConfigurationGauge) {
                GameConfigurationUtil.getInstance().change(this.gameOptionsForm, ((GameConfigurationGauge) item));
            }
        } catch (Exception e) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            this.logUtil.put(commonStrings.EXCEPTION, this, MidletStrings.getInstance().COMMAND_ACTION, e);
        }
    }

}

