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
using Font = javax.microedition.lcdui.Font;
using Graphics = javax.microedition.lcdui.Graphics;
using AnimationBehavior = org.allbinary.animation.AnimationBehavior;
using FontDebugFactory = org.allbinary.graphics.font.FontDebugFactory;
using StringUtil = org.allbinary.logic.@string.StringUtil;

namespace org.allbinary.animation.text;

public class CustomTextAnimation : TextAnimation, TextInterface
{
    public readonly FontDebugFactory fontDebugFactory = FontDebugFactory.getInstance();
    public readonly int fontSize;
    public Font font;
    private string lastText = StringUtil.getInstance().INIT_STRING;
    public bool hasChanged = true;
    public CustomTextAnimation(string text, int fontSize, AnimationBehavior animationBehavior) : base(text, animationBehavior)
    {
        // Constructor invocation emitted in the initializer.
        this.fontSize = fontSize;
        this.font = Font.getFont(Font.FACE_SYSTEM, Font.STYLE_PLAIN, fontSize);
    }

    public override void paintXY(Graphics graphics, int x, int y)
    {
        this.myFontProcessor.process(graphics);
        Font existingFont = graphics.getFont();
        this.fontDebugFactory.setFont(this.font, graphics);
        base.paintXYNoUpdate(graphics, x, y);
        this.fontDebugFactory.setFont(existingFont, graphics);
    }

    public override void setScale(float scaleX, float scaleY)
    {
        if (scaleX != scaleY) {
            throw new SystemException();
        }
        this.hasChanged = true;
        this.font = Font.getFont(Font.FACE_SYSTEM, Font.STYLE_PLAIN, ((int) (((float) this.fontSize) * scaleX)));
    }

    public override void setTextWithOnMeasure(string text, TextChangeListener textChangeListener)
    {
        base.setTextWithOnMeasure(text, textChangeListener);
    }

    public override void setText(string text)
    {
        if (this.lastText != text) {
            this.hasChanged = true;
            this.lastText = text;
            base.setText(text);
        }
    }

    public virtual string getText()
    {
        return this.lastText;
    }

    private int textWidth = 0;
    public override int getWidth()
    {
        if (this.hasChanged) {
            this.textWidth = this.font.stringWidth(this.textArrayP[0]);
            this.hasChanged = false;
        }
        return this.textWidth;
    }

    public override int getFontHeight()
    {
        return this.font.getHeight();
    }

}

