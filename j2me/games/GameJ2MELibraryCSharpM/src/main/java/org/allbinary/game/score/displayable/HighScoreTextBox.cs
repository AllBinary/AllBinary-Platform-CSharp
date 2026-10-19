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
//using CommandListener = javax.microedition.lcdui.CommandListener;
//using Font = javax.microedition.lcdui.Font;
//using Graphics = javax.microedition.lcdui.Graphics;
//using TextField = javax.microedition.lcdui.TextField;
using PostGameCommandFactory = org.allbinary.PostGameCommandFactory;
using GameInfo = org.allbinary.game.GameInfo;
using HighScore = org.allbinary.game.score.HighScore;
using HighScoresHelperBaseInterface = org.allbinary.game.score.HighScoresHelperBaseInterface;
using HighScoresFactoryInterface = org.allbinary.game.score.HighScoresFactoryInterface;
using BasicColor = org.allbinary.graphics.color.BasicColor;
using BasicColorFactory = org.allbinary.graphics.color.BasicColorFactory;
using CustomTextBox = org.allbinary.graphics.form.item.CustomTextBox;
using NullPaintable = org.allbinary.graphics.paint.NullPaintable;
using Paintable = org.allbinary.graphics.paint.Paintable;
using SimpleTextPaintable = org.allbinary.graphics.paint.SimpleTextPaintable;
using VirtualKeyboardEventHandler = org.allbinary.input.@event.VirtualKeyboardEventHandler;
using GenericOperatingSystem = org.allbinary.logic.system.os.GenericOperatingSystem;
using OperatingSystemFactory = org.allbinary.logic.system.os.OperatingSystemFactory;
using AbeClientInformationInterface = org.allbinary.logic.system.security.licensing.AbeClientInformationInterface;
using InApplicationPurchaseFactory = org.allbinary.logic.system.security.licensing.InApplicationPurchaseFactory;

namespace org.allbinary.game.score.displayable;

public class HighScoreTextBox : CustomTextBox
{
    private readonly VirtualKeyboardEventHandler virtualKeyboardEventHandler = VirtualKeyboardEventHandler.getInstance();
    private readonly HighScoreUtil highScoreUtil;
    private readonly Paintable pleaseWait;
    private Paintable paintable = NullPaintable.getInstance();
    public bool submitted = false;
    public HighScoreTextBox(HighScoresFactoryInterface highScoresFactoryInterface, HighScoresHelperBaseInterface highScoresHelper, AbeClientInformationInterface abeClientInformation, GameInfo gameInfo, CommandListener cmdListener, string name, HighScore highScore, BasicColor backgrounBasicColor, BasicColor foregroundBasicColor) : base(cmdListener, "New High Score Enter Name:", name, 12, TextField.ANY, Font.getDefaultFont(), backgrounBasicColor, foregroundBasicColor)
    {
        this.pleaseWait = new SimpleTextPaintable(this.commonStrings.PLEASE_WAIT, BasicColorFactory.getInstance().WHITE);
        // base(cmdListener, "New High Score Enter Name:", name, 12, TextField.ANY, Font.getDefaultFont(), backgrounBasicColor, foregroundBasicColor) is called from the constructor declaration
        this.highScoreUtil = new HighScoreUtil(highScoresFactoryInterface, highScoresHelper, abeClientInformation, gameInfo, cmdListener, name, highScore);
        GenericOperatingSystem operatingSystemInterface = OperatingSystemFactory.getInstance().getOperatingSystemInstance();
        if (operatingSystemInterface.isOverScan()) {
            string username = InApplicationPurchaseFactory.getInstance().getUserName();
            if (username != null) {
                this.getTextFieldItem().setString(username);
            } else {
                this.getTextFieldItem().setString("NoGamerInfo");
            }
        }
    }

    public override void initCommands(CommandListener cmdListener)
    {
        this.removeAllCommands();
        PostGameCommandFactory.getInstance().addCommands(this);
        this.addCommand(HighScoreUtil.SUBMIT_TEXTBOX_COMMAND);
        this.setCommandListener(cmdListener);
    }

    public override void open()
    {
        this.virtualKeyboardEventHandler.open();
        this.paintable = NullPaintable.getInstance();
        base.open();
    }

    // throws Exception
    public override void close()
    {
        this.virtualKeyboardEventHandler.close();
        this.paintable = this.pleaseWait;
        this.repaintBehavior.onChangeRepaint(this);
        base.close();
        this.removeCommand(HighScoreUtil.SUBMIT_TEXTBOX_COMMAND);
        this.update();
        if (this.submitted) {
            this.highScoreUtil.saveHighScore();
        } else {
        }
        this.paintable = NullPaintable.getInstance();
        this.repaintBehavior.onChangeRepaint(this);
    }

    // throws Exception
    public override void update()
    {
        string name = this.getTextFieldItem().getString();
        this.highScoreUtil.update(name);
        base.update();
    }

    public override void paint(Graphics graphics)
    {
        base.paint(graphics);
        this.paintable.paint(graphics);
    }

    public virtual void saveHighScore()
    {
        this.highScoreUtil.saveHighScore();
    }

    public override void submit()
    {
        this.highScoreUtil.submit(this);
    }

}

