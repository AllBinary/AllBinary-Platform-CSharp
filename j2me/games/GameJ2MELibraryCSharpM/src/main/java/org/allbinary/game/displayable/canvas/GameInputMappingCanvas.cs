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
//using CommandListener = javax.microedition.lcdui.CommandListener;
//using Graphics = javax.microedition.lcdui.Graphics;
using GameCommandsFactory = org.allbinary.game.commands.GameCommandsFactory;
using GameKey = org.allbinary.game.input.GameKey;
using GameKeyFactory = org.allbinary.game.input.GameKeyFactory;
using Input = org.allbinary.game.input.Input;
using InputFactory = org.allbinary.game.input.InputFactory;
using PlatformInputMappingFactory = org.allbinary.game.input.PlatformInputMappingFactory;
using InputMappingInterface = org.allbinary.game.input.mapping.InputMappingInterface;
using PersistentInputMapping = org.allbinary.game.input.mapping.PersistentInputMapping;
using AllBinaryGameLayerManager = org.allbinary.game.layer.AllBinaryGameLayerManager;
using ColorFillBasePaintable = org.allbinary.game.paint.ColorFillBasePaintable;
using ColorFillPaintableFactory = org.allbinary.game.paint.ColorFillPaintableFactory;
using HelpPaintable = org.allbinary.game.paint.help.HelpPaintable;
using InputMappingHelpPaintable = org.allbinary.game.paint.help.InputMappingHelpPaintable;
using ProcessPaintable = org.allbinary.graphics.paint.ProcessPaintable;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using AbeClientInformationInterface = org.allbinary.logic.system.security.licensing.AbeClientInformationInterface;
using BasicArrayList = org.allbinary.util.BasicArrayList;

namespace org.allbinary.game.displayable.canvas;

public class GameInputMappingCanvas : GameCommandCanvas, InputMappingInterface
{
    private readonly ProcessPaintable paintable;
    public static readonly string NAME = "GameInputMappingCanvas";
    public static readonly Command DISPLAY = new Command("Controls", StringUtil.getInstance().EMPTY_STRING, Command.SCREEN, 2);
    public static readonly Command DEFAULT = new Command("Default", StringUtil.getInstance().EMPTY_STRING, Command.SCREEN, 2);
    private readonly InputMappingHelpPaintable helpPaintable;
    public readonly ColorFillBasePaintable colorFillPaintable;
    private readonly PersistentInputMapping inputMapping;
    private readonly GameKey NONE = GameKeyFactory.getInstance().NONE;
    private readonly AbeClientInformationInterface abeClientInformation;
    private GameKey selectedGameKey;
    private Input selectedInput;
    public GameInputMappingCanvas(AbeClientInformationInterface abeClientInformation, CommandListener commandListener, AllBinaryGameLayerManager allBinaryGameLayerManager, HelpPaintable helpPaintable) : base(commandListener, GameInputMappingCanvas.NAME, allBinaryGameLayerManager.getBackgroundBasicColor(), allBinaryGameLayerManager.getForegroundBasicColor())
    {
        this.selectedGameKey = this.NONE;
        this.selectedInput = this.NONE;
        // base(commandListener, GameInputMappingCanvas.NAME, allBinaryGameLayerManager.getBackgroundBasicColor(), allBinaryGameLayerManager.getForegroundBasicColor()) is called from the constructor declaration
        this.logUtil.putF(this.commonStrings.START, this, this.commonStrings.CONSTRUCTOR);
        if (helpPaintable == null) {
            throw new Exception("Help Paintable Exception");
        }
        this.abeClientInformation = abeClientInformation;
        this.helpPaintable = ((InputMappingHelpPaintable) helpPaintable);
        this.inputMapping = PlatformInputMappingFactory.getInstance().getPersistentInputMappingInstance();
        this.paintable = new ProcessPaintable();
        this.colorFillPaintable = ColorFillPaintableFactory.getInstance().getInstance(allBinaryGameLayerManager.getBackgroundBasicColor(), false);
    }

    // throws Exception
    public override void close()
    {
        base.close();
        this.paintable.process();
        this.selectedGameKey = this.NONE;
        this.selectedInput = this.NONE;
        this.update();
    }

    public override void initCommands(CommandListener cmdListener)
    {
        this.removeAllCommands();
        this.addCommand(GameCommandsFactory.getInstance().CLOSE_AND_SHOW_GAME_CANVAS);
        this.addCommand(GameInputMappingCanvas.DEFAULT);
        this.addCommand(GameInputMappingInstructionsCanvas.DISPLAY);
        this.setCommandListener(cmdListener);
    }

    public override void keyPressed(int keyCode)
    {
        this.keyPressedByDevice(keyCode, 0);
    }

    public override void keyReleased(int keyCode)
    {
        this.keyReleasedByDevice(keyCode, 0);
    }

    public override void keyRepeated(int keyCode)
    {
        this.keyRepeatedByDevice(keyCode, 0);
    }

    public override void keyPressedByDevice(int keyCode, int deviceId)
    {
        this.addGameKey(keyCode, false);
        base.keyPressedByDevice(keyCode, 0);
    }

    private readonly InputFactory inputFactory = InputFactory.getInstance();
    private void addGameKey(int keyCode, bool repeated)
    {
        try {
            this.logUtil.putF(new StringMaker().append("Raw Device Key Code: ").append(Convert.ToString(keyCode, 16)).ToString(), this, this.gameInputStrings.ADD_KEY_EVENT);
            GameKey gameKey = this.inputToGameKeyMapping.getInstanceForCanvas(this, keyCode);
            Input input = this.inputFactory.getInstanceById(keyCode);
            this.processInputMapping(gameKey, input);
        } catch (Exception e) {
            this.logUtil.put("Key Event Error", this, this.gameInputStrings.ADD_KEY_EVENT, e);
        }
    }

    // throws Exception
    public override void processInputMapping(GameKey gameKey, Input input)
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append("Start Passed GameKey: ");
        stringBuffer.append(this.stringUtil.toString(gameKey));
        stringBuffer.append(" Input: ");
        stringBuffer.append(this.stringUtil.toString(input));
        this.logUtil.putF(stringBuffer.ToString(), this, this.commonStrings.PROCESS);
        if (this.selectedGameKey != this.NONE) {
            this.gameActionCrud(gameKey, input);
        } else {
            this.setSelectedAction(gameKey);
        }
    }

    private void setSelectedAction(GameKey gameKey)
    {
        this.logUtil.putF(new StringMaker().append("Selected GameKey: ").append(this.stringUtil.toString(gameKey)).ToString(), this, "setSelectedAction");
        this.selectedGameKey = gameKey;
        this.selectedInput = this.NONE;
        this.helpPaintable.update(this.selectedGameKey, this.selectedInput);
        this.repaintBehavior.onChangeRepaint(this);
    }

    // throws Exception
    private void gameActionCrud(GameKey gameKey, Input input)
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append("Start GameKey: ");
        stringBuffer.append(this.stringUtil.toString(this.selectedGameKey));
        stringBuffer.append(" Input: ");
        stringBuffer.append(this.stringUtil.toString(this.selectedInput));
        this.logUtil.putF(stringBuffer.ToString(), this, "gameActionCrud");
        if (this.selectedInput == this.NONE) {
            BasicArrayList list = this.inputMapping.getInputMapping().getMappedInput(this.selectedGameKey);
            bool isInputAlreadyMappedToSelectedAction = list.contains(input);
            if (isInputAlreadyMappedToSelectedAction) {
                this.logUtil.putF(new StringMaker().append("Already Mapped Input: ").append(this.stringUtil.toString(input)).ToString(), this, "gameActionCrud");
                this.selectedInput = input;
                this.helpPaintable.update(this.selectedGameKey, this.selectedInput);
                this.repaintBehavior.onChangeRepaint(this);
            } else {
                this.addNewMapping(gameKey, input);
            }
        } else if (this.inputMapping.isDelete(input)) {
            this.deleteCurrentMapping();
        } else {
            this.setSelectedAction(gameKey);
        }
    }

    // throws Exception
    private void addNewMapping(GameKey gameKey, Input input)
    {
        string METHOD_NAME = "addNewMapping";
        this.logUtil.putF(this.commonStrings.START, this, METHOD_NAME);
        bool isInputAlreadyMapped = this.inputMapping.getInputMapping().isMapped(input);
        if (!isInputAlreadyMapped && !this.inputMapping.isSystemInput(input)) {
            StringMaker stringBuffer = new StringMaker();
            stringBuffer.append("Add Key Mapping : GameKey: ");
            stringBuffer.append(this.stringUtil.toString(this.selectedGameKey));
            stringBuffer.append(" Input: ");
            stringBuffer.append(this.stringUtil.toString(this.selectedInput));
            this.logUtil.putF(stringBuffer.ToString(), this, METHOD_NAME);
            this.inputMapping.getInputMapping().add(this.selectedGameKey, input);
            this.selectedInput = input;
            this.update();
        } else {
            this.logUtil.putF("Unable to add Mapping since one already exists or is MENU, HOME, or BACK key and setting selected action to what it is already mapped to", this, METHOD_NAME);
            this.setSelectedAction(gameKey);
        }
    }

    // throws Exception
    private void deleteCurrentMapping()
    {
        string METHOD_NAME = "deleteCurrentMapping";
        BasicArrayList list = this.inputMapping.getInputMapping().getMappedInput(this.selectedGameKey);
        if (list.size() > 1) {
            StringMaker stringBuffer = new StringMaker();
            stringBuffer.append("Start GameKey: ");
            stringBuffer.append("Remove Key Mapping: GameKey: ");
            stringBuffer.append(this.stringUtil.toString(this.selectedGameKey));
            stringBuffer.append(" Input: ");
            stringBuffer.append(this.stringUtil.toString(this.selectedInput));
            this.logUtil.putF(stringBuffer.ToString(), this, METHOD_NAME);
            this.inputMapping.getInputMapping().remove(this.selectedGameKey, this.selectedInput);
            this.selectedInput = this.NONE;
            this.update();
        } else {
            this.logUtil.putF("Can't Remove Last Key Mapping", this, METHOD_NAME);
        }
    }

    // throws Exception
    public virtual void setDefault()
    {
        this.inputMapping.setDefault(this.abeClientInformation);
        this.helpPaintable.update(this.NONE, this.NONE);
        this.repaintBehavior.onChangeRepaint(this);
    }

    // throws Exception
    public override void update()
    {
        this.inputMapping.update(this.abeClientInformation);
        this.helpPaintable.update(this.selectedGameKey, this.selectedInput);
        this.repaintBehavior.onChangeRepaint(this);
    }

    public override void paint(Graphics graphics)
    {
        this.colorFillPaintable.paint(graphics);
        this.helpPaintable.paint(graphics);
        this.paintable.paint(graphics);
        base.paint(graphics);
    }

}

