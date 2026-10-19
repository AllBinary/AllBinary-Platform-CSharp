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
//using NullImage = javax.microedition.lcdui.NullImage;
using GameCommandsFactory = org.allbinary.game.commands.GameCommandsFactory;
using GameDifficultyFactory = org.allbinary.game.configuration.persistance.GameDifficultyFactory;
using BasicColor = org.allbinary.graphics.color.BasicColor;
using CommandForm = org.allbinary.graphics.displayable.screen.CommandForm;
using MEUtil = org.allbinary.logic.MEUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using BasicArrayList = org.allbinary.util.BasicArrayList;

namespace org.allbinary.game.configuration;

public class GameDifficultyOptions : CommandForm
{
    private readonly MEUtil meUtil = MEUtil.getInstance();
    private readonly BasicArrayList list;
    public GameDifficultyOptions(CommandListener commandListener, string title, BasicArrayList list, BasicColor backgrounBasicColor, BasicColor foregroundBasicColor) : base(commandListener, title, backgrounBasicColor, foregroundBasicColor)
    {
        // base(commandListener, title, backgrounBasicColor, foregroundBasicColor) is called from the constructor declaration
        this.logUtil.putF(this.commonStrings.START, this, this.commonStrings.CONSTRUCTOR);
        this.list = list;
        this.update();
        this.initCommands(commandListener);
        GameDifficultyFactory gameDifficultyFactory = GameDifficultyFactory.getInstance();
        this.setSelectedId(gameDifficultyFactory.getLevel());
    }

    public override void open()
    {
        base.open();
    }

    // throws Exception
    public override void close()
    {
        base.close();
        this.save();
    }

    // throws Exception
    public virtual void save()
    {
        GameDifficultyFactory gameDifficultyFactory = GameDifficultyFactory.getInstance();
        gameDifficultyFactory.setLevel(this.getSelectedId());
    }

    public override void initCommands(CommandListener cmdListener)
    {
        GameCommandsFactory gameCommandsFactory = GameCommandsFactory.getInstance();
        this.removeAllCommands();
        this.addCommand(gameCommandsFactory.CLOSE_AND_SHOW_GAME_CANVAS);
        this.setCommandListener(cmdListener);
    }

    // throws Exception
    public override void update()
    {
        this.deleteAll();
        this.add(this.list, "Difficulty", Choice.EXCLUSIVE);
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
        string METHOD_NAME = "addChoiceGroup";
        string NAME = "Adding Choice: ";
        ChoiceGroup choiceGroup = new ChoiceGroup(name, option, StringUtil.getInstance().getArrayInstance(), NullImage.NULL_IMAGE_ARRAY);
        int size = list.size();
        object anyType = null;
        for (int index = 0; index < size; index++) {
            anyType = list.objectArray[index];
            this.logUtil.putF(new StringMaker().append(NAME).append(anyType.ToString()).ToString(), this, METHOD_NAME);
            choiceGroup.append(anyType.ToString(), NullImage.NULL_IMAGE);
        }
        return choiceGroup;
    }

    public virtual void setSelectedId(int id)
    {
        ChoiceGroup choiceGroup = ((ChoiceGroup) this.get(0));
        choiceGroup.setSelectedIndex(id, true);
    }

    public virtual int getSelectedId()
    {
        ChoiceGroup choiceGroup = ((ChoiceGroup) this.get(0));
        return choiceGroup.getSelectedIndex();
    }

    public virtual int getSelectedText()
    {
        ChoiceGroup choiceGroup = ((ChoiceGroup) this.get(0));
        int value = ((int) (choiceGroup.getString(choiceGroup.getSelectedIndex())).ToString());
        return value;
    }

}

