/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2022 AllBinary 
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
//using Font = javax.microedition.lcdui.Font;
//using Graphics = javax.microedition.lcdui.Graphics;
using AnimationBehavior = org.allbinary.animation.AnimationBehavior;
using IndexedAnimation = org.allbinary.animation.IndexedAnimation;
using RawKeyEventListener = org.allbinary.game.input.@event.RawKeyEventListener;
using BasicColor = org.allbinary.graphics.color.BasicColor;
using UpdateMyFontInterface = org.allbinary.graphics.font.UpdateMyFontInterface;
using CustomTextBox = org.allbinary.graphics.form.item.CustomTextBox;
using StringUtil = org.allbinary.logic.@string.StringUtil;

namespace org.allbinary.animation.text;

public class CustomTextBoxIndexedAnimation : IndexedAnimation, RawKeyEventListener, UpdateMyFontInterface, TextInterface
{
    private readonly CustomTextBox customTextBox;
    private string lastText = StringUtil.getInstance().INIT_STRING;
    public bool hasChanged = true;
    private TextChangeListener textChangeListener = TextChangeListener.getInstance();
    public CustomTextBoxIndexedAnimation(CustomTextBox customTextBox) : base(AnimationBehavior.getInstance())
    {
        // base(AnimationBehavior.getInstance()) is called from the constructor declaration
        this.customTextBox = customTextBox;
    }

    public override void setBasicColorP(BasicColor basicColor)
    {
        this.customTextBox.getTextFieldItem().setForegroundBasicColorP(basicColor);
    }

    public override void setBackgroundBasicColorP(BasicColor basicColor)
    {
        this.customTextBox.getTextFieldItem().setBackgroundBasicColorP(basicColor);
    }

    public override void setTextWithOnMeasure(string text, TextChangeListener textChangeListener)
    {
        this.setText(text);
        this.textChangeListener = textChangeListener;
    }

    public override void updateMeasurement(Graphics graphics)
    {
        Font font = graphics.getFont();
        this.textChangeListener.onMeasure();
        this.textChangeListener = TextChangeListener.getInstance();
    }

    public override void setText(string text)
    {
        if (this.lastText != text) {
            this.hasChanged = true;
            this.lastText = text;
            this.customTextBox.getTextFieldItem().setString(text);
        }
    }

    public override string getText()
    {
        return this.customTextBox.getTextFieldItem().getString();
    }

    public override void onEventRaw(int keyCode, int deviceId, bool repeated)
    {
        this.customTextBox.onEventRaw(keyCode, deviceId, repeated);
    }

    public override int getFontHeight()
    {
        return this.customTextBox.getTextFieldItem().getFontHeight();
    }

    public override void paintXY(Graphics graphics, int x, int y)
    {
        this.customTextBox.paintXY(graphics, x, y);
    }

    public override void paintThreedXYZ(Graphics graphics, int x, int y, int z)
    {
    }

}

