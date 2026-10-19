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
using J2MEUtil = org.allbinary.J2MEUtil;
using GameCommandCanvas = org.allbinary.game.displayable.canvas.GameCommandCanvas;
using Input = org.allbinary.game.input.Input;
using InputFactory = org.allbinary.game.input.InputFactory;
using PlatformKeyFactory = org.allbinary.game.input.PlatformKeyFactory;
using RawKeyEventListener = org.allbinary.game.input.@event.RawKeyEventListener;
using BasicColor = org.allbinary.graphics.color.BasicColor;
using TextItemVisitor = org.allbinary.graphics.form.item.validation.TextItemVisitor;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using CommonSeps = org.allbinary.@string.CommonSeps;

namespace org.allbinary.graphics.form.item;

public class CustomTextBox : GameCommandCanvas, RawKeyEventListener
{
    private readonly ABTextFieldItem textFieldItem;
    public CustomTextBox(CommandListener cmdListener, string label, string text, int maxSize, int constraints, Font font, BasicColor backgroundBasicColor, BasicColor foregroundBasicColor) : base(cmdListener, label, backgroundBasicColor, foregroundBasicColor)
    {
        // base(cmdListener, label, backgroundBasicColor, foregroundBasicColor) is called from the constructor declaration
        StringUtil stringUtil = StringUtil.getInstance();
        ABTextFieldItem textFieldItem = new ABTextFieldItem(this, new TextItemVisitor(), stringUtil.EMPTY_STRING, stringUtil.EMPTY_STRING, maxSize, 0, stringUtil.EMPTY_STRING, font, backgroundBasicColor, foregroundBasicColor);
        textFieldItem.setString(text);
        this.textFieldItem = textFieldItem;
        this.setTitle(label);
    }

    public virtual void submit()
    {
    }

    private readonly InputFactory inputFactory = InputFactory.getInstance();
    public override void onEventRaw(int keyCode, int deviceId, bool repeated)
    {
        this.logUtil.putF(new StringMaker().append(this.commonStrings.START).appendint(keyCode).ToString(), this, "onEvent");
        this.keyPressedByDevice(keyCode, deviceId);
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
        try {
            this.logUtil.putF(new StringMaker().append(CommonSeps.getInstance().SPACE).appendint(keyCode).ToString(), this, this.gameInputStrings.KEY_PRESSED);
            PlatformKeyFactory platformKeyFactory = PlatformKeyFactory.getInstance();
            Input input = this.inputFactory.getInstanceById(keyCode);
            if (platformKeyFactory.isSubmission(input)) {
                this.submit();
            } else {
                this.textFieldItem.keyPressed(keyCode);
            }
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, this.gameInputStrings.KEY_PRESSED, e);
        }
    }

    public override void keyReleasedByDevice(int keyCode, int deviceId)
    {
    }

    public override void paint(Graphics graphics)
    {
        graphics.setColor(this.backgroundColor);
        graphics.fillRect(0, 0, this.displayInfo.getLastWidth(), this.displayInfo.getLastHeight());
        graphics.setColor(this.foregroundColor);
        if (!J2MEUtil.isJ2ME()) {
            graphics.drawString(this.getTitle(), 8, 1, 0);
        }
        this.paintXY(graphics, 8, graphics.getFont().getHeight() + 2);
        base.paint(graphics);
    }

    public virtual void paintXY(Graphics graphics, int x, int y)
    {
        this.textFieldItem.paintXY(graphics, x, y);
    }

    public virtual ABTextFieldItem getTextFieldItem()
    {
        return this.textFieldItem;
    }

}

