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
//using ChoiceGroup = javax.microedition.lcdui.ChoiceGroup;
//using CommandListener = javax.microedition.lcdui.CommandListener;
//using Item = javax.microedition.lcdui.Item;
//using NullImage = javax.microedition.lcdui.NullImage;
//using StringItem = javax.microedition.lcdui.StringItem;
using GameCommandsFactory = org.allbinary.game.commands.GameCommandsFactory;
using GamePersistanceSingleton = org.allbinary.game.configuration.persistance.GamePersistanceSingleton;
using BasicColor = org.allbinary.graphics.color.BasicColor;
using CommandForm = org.allbinary.graphics.displayable.screen.CommandForm;
using MEUtil = org.allbinary.logic.MEUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using BasicArrayList = org.allbinary.util.BasicArrayList;

namespace org.allbinary.game.configuration;

public class LoadGameForm : CommandForm
{
    private readonly MEUtil meUtil = MEUtil.getInstance();
    private bool areChoices = false;
    public LoadGameForm(CommandListener commandListener, string title, BasicColor backgrounBasicColor, BasicColor foregroundBasicColor) : base(commandListener, title, backgrounBasicColor, foregroundBasicColor)
    {
        // base(commandListener, title, backgrounBasicColor, foregroundBasicColor) is called from the constructor declaration
        this.logUtil.putF(this.commonStrings.START, this, this.commonStrings.CONSTRUCTOR);
        this.update();
        this.initCommands(commandListener);
    }

    public override void initCommands(CommandListener cmdListener)
    {
        GameCommandsFactory gameCommandsFactory = GameCommandsFactory.getInstance();
        this.removeAllCommands();
        this.addCommand(gameCommandsFactory.LOAD_FILE);
        this.addCommand(gameCommandsFactory.DELETE_FILE);
        this.addCommand(gameCommandsFactory.CLOSE_AND_SHOW_GAME_CANVAS);
        this.setCommandListener(cmdListener);
    }

    // throws Exception
    public override void update()
    {
        BasicArrayList list = GamePersistanceSingleton.getInstance().getIds();
        this.deleteAll();
        if (list.size() > 0) {
            this.add(list, "Select A Saved Game", Choice.EXCLUSIVE);
            this.areChoices = true;
        } else {
            this.meUtil.appendItem(this, new StringItem("No Saved Games", StringUtil.getInstance().EMPTY_STRING, Item.PLAIN));
            this.areChoices = false;
        }
        base.update();
    }

    private void add(BasicArrayList list, string name, int option)
    {
        ChoiceGroup choiceGroup = this.getChoiceGroup(list, name, option);
        if (list.size() > 0) {
            choiceGroup.setSelectedIndex(0, true);
        }
        this.meUtil.appendItem(this, choiceGroup);
    }

    private ChoiceGroup getChoiceGroup(BasicArrayList list, string name, int option)
    {
        string METHOD_NAME = "getChoiceGroup";
        string ADDING_CHOICE = "Adding Choice: ";
        ChoiceGroup choiceGroup = new ChoiceGroup(name, option, StringUtil.getInstance().getArrayInstance(), NullImage.NULL_IMAGE_ARRAY);
        int size = list.size();
        for (int index = 0; index < size; index++) {
            object anyType = list.objectArray[index];
            this.logUtil.putF(new StringMaker().append(ADDING_CHOICE).append(anyType.ToString()).ToString(), this, METHOD_NAME);
            choiceGroup.append(anyType.ToString(), NullImage.NULL_IMAGE);
        }
        return choiceGroup;
    }

    public virtual int getSelectedId()
    {
        if (this.areChoices) {
            ChoiceGroup choiceGroup = ((ChoiceGroup) this.get(0));
            return choiceGroup.getSelectedIndex();
        } else {
            return -1;
        }
    }

    public virtual int getSelectedText()
    {
        if (this.areChoices) {
            ChoiceGroup choiceGroup = ((ChoiceGroup) this.get(0));
            int value = ((int) (choiceGroup.getString(choiceGroup.getSelectedIndex())).ToString());
            return value;
        } else {
            return -1;
        }
    }

}

