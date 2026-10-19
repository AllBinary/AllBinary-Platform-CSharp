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
using AllBinaryGameLayerManager = org.allbinary.game.layer.AllBinaryGameLayerManager;
using ColorFillBasePaintable = org.allbinary.game.paint.ColorFillBasePaintable;
using ColorFillPaintableFactory = org.allbinary.game.paint.ColorFillPaintableFactory;
using Anchor = org.allbinary.graphics.Anchor;
using DrawStringUtil = org.allbinary.graphics.draw.DrawStringUtil;
using StringUtil = org.allbinary.logic.@string.StringUtil;

namespace org.allbinary.game.displayable.canvas;

public class GameInputMappingInstructionsCanvas : GameCommandCanvas
{
    public static readonly Command DISPLAY = new Command("Help", StringUtil.getInstance().EMPTY_STRING, Command.SCREEN, 1);
    public static readonly Command CLOSE = new Command("Close", StringUtil.getInstance().EMPTY_STRING, Command.SCREEN, 1);
    public static readonly string NAME = "GameInputMappingInstructionsCanvas";
    private readonly DrawStringUtil drawStringUtil = DrawStringUtil.getInstance();
    public readonly string TITLE = "Input Instructions";
    private readonly string[] instructions = new string[] { "Add Input Mapping:", "1. Select the desired action by generating a currently defined input for a given action.", "(Example: Press the '1' key to select the Fire action)", "2. Make the newly desired input for the selected action.", "(Example: Press 'f' to add it to the selected action)", "Note: If the input is already mapped to another action then it will not be added. You", "will need to deleted from the other action before adding it to another.", "Warning: Not all keys map for a given platform and show as Unknown.", StringUtil.getInstance().EMPTY_STRING, "Remove Input Mapping:", "1. Select the desired action by generating a currently defined input for a given action.", "(Example: Press the key '1' to select the Fire action)", "2. Select a mapped input for the selected action.", "(Example: Press the key '1' to select the '1' key input for the selected Fire action)", "3. Press the Delete Key." };
    private ColorFillBasePaintable colorFillPaintable;
    private int anchor = Anchor.TOP_LEFT;
    public GameInputMappingInstructionsCanvas(CommandListener commandListener, AllBinaryGameLayerManager allBinaryGameLayerManager) : base(commandListener, GameInputMappingInstructionsCanvas.NAME, allBinaryGameLayerManager.getBackgroundBasicColor(), allBinaryGameLayerManager.getForegroundBasicColor())
    {
        // base(commandListener, GameInputMappingInstructionsCanvas.NAME, allBinaryGameLayerManager.getBackgroundBasicColor(), allBinaryGameLayerManager.getForegroundBasicColor()) is called from the constructor declaration
        this.logUtil.putF(this.commonStrings.START, this, this.commonStrings.CONSTRUCTOR);
        this.colorFillPaintable = ColorFillPaintableFactory.getInstance().getInstance(allBinaryGameLayerManager.getBackgroundBasicColor(), false);
    }

    public override void initCommands(CommandListener cmdListener)
    {
        this.removeAllCommands();
        this.addCommand(GameInputMappingInstructionsCanvas.CLOSE);
        this.setCommandListener(cmdListener);
    }

    public override void paint(Graphics graphics)
    {
        this.myFontProcessor.process(graphics);
        this.colorFillPaintable.paint(graphics);
        int halfWidth = this.displayInfo.getLastHalfWidth();
        int beginWidth = (graphics.getFont().stringWidth(this.TITLE) >> 1);
        graphics.setColor(this.foregroundColor);
        graphics.drawString(this.TITLE, halfWidth - beginWidth, this.fontHeight, this.anchor);
        this.drawStringUtil.drawCenterStrings(graphics, this.instructions, this.displayInfo.getLastWidth(), this.fontHeight, halfWidth, 3 * this.fontHeight);
        base.paint(graphics);
    }

}

