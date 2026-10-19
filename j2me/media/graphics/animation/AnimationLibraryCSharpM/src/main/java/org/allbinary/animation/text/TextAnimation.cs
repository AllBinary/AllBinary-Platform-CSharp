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
//using Font = javax.microedition.lcdui.Font;
//using Graphics = javax.microedition.lcdui.Graphics;
using AnimationBehavior = org.allbinary.animation.AnimationBehavior;
using IndexedAnimation = org.allbinary.animation.IndexedAnimation;
using Anchor = org.allbinary.graphics.Anchor;
using MyFontProcessor = org.allbinary.graphics.font.MyFontProcessor;
using UpdateMyFontInterface = org.allbinary.graphics.font.UpdateMyFontInterface;
using UpdateMyFontProcessor = org.allbinary.graphics.font.UpdateMyFontProcessor;
using SWTJOGLProcessor = org.allbinary.graphics.threed.SWTJOGLProcessor;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.animation.text;

public class TextAnimation : IndexedAnimation, UpdateMyFontInterface
{
    private readonly MyFontProcessor updateMyFontProcessor;
    public MyFontProcessor myFontProcessor;
    public string[] textArrayP = StringUtil.getInstance().ONE_EMPTY_STRING_ARRAY;
    private int anchor = Anchor.TOP_LEFT;
    private int fontHeight = 0;
    private int offsetY = 0;
    private TextChangeListener textChangeListener = TextChangeListener.getInstance();
    public TextAnimation(string text, AnimationBehavior animationBehavior) : base(animationBehavior)
    {
        this.updateMyFontProcessor = new UpdateMyFontProcessor(this);
        this.myFontProcessor = this.updateMyFontProcessor;
        // base(animationBehavior) is called from the constructor declaration
        this.setText(text);
    }

    public override void updateMeasurement(Graphics graphics)
    {
        Font font = graphics.getFont();
        this.fontHeight = font.getHeight();
        int adjustedFontHeight = ((int) (-(((double) this.fontHeight) * 2.00)));
        this.offsetY = (SWTJOGLProcessor.getInstance().isJOGL() ? adjustedFontHeight : 0);
        this.textChangeListener.onMeasure();
        this.textChangeListener = TextChangeListener.getInstance();
        this.myFontProcessor = MyFontProcessor.getInstance();
    }

    // throws Exception
    public override void nextFrame()
    {
    }

    public override void paintXY(Graphics graphics, int x, int y)
    {
        this.myFontProcessor.process(graphics);
        this.paintXYNoUpdate(graphics, x, y);
    }

    public virtual void paintXYNoUpdate(Graphics graphics, int x, int y)
    {
        this.basicSetColorUtil.setBasicColorP3(graphics, this.getBasicColorP(), this.getColor());
        int size = this.textArrayP.Length;
        for (int index = 0; index < size; index++) {
            graphics.drawString(this.textArrayP[index], x, y + this.offsetY + (index * this.fontHeight), this.anchor);
        }
    }

    public virtual void setTextWithOnMeasure(string text, TextChangeListener textChangeListener)
    {
        this.setText(text);
        this.textChangeListener = textChangeListener;
    }

    public virtual void setText(string text)
    {
        BasicArrayList list = new BasicArrayListD();
        if (text != null && text.Length > 0) {
            int index = 0;
            int startIndex = 0;
            int endIndex = 0;
            while (index >= 0) {
                startIndex = index;
                index = text.IndexOf('\n', startIndex);
                endIndex = index;
                if (index < 0) {
                    endIndex = text.Length;
                }
                list.add(text.Substring(startIndex, (endIndex) - (startIndex)));
                if (index < 0) {
                    break;
                }
                index++;
            }
        }
        if (list.size() > 0) {
            string[] textArray = new string[list.size()];
            int size = list.size();
            for (int index = 0; index < size; index++) {
                textArray[index] = ((string) list.get(index));
            }
            this.textArrayP = textArray;
        } else {
            this.textArrayP = StringUtil.getInstance().ONE_EMPTY_STRING_ARRAY;
        }
        this.myFontProcessor = this.updateMyFontProcessor;
    }

    public virtual string[] getTextArray()
    {
        return this.textArrayP;
    }

    public virtual int getFontHeight()
    {
        return this.fontHeight;
    }

}

