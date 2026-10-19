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
using AndroidUtil = org.allbinary.AndroidUtil;
using J2MEUtil = org.allbinary.J2MEUtil;
using Anchor = org.allbinary.graphics.Anchor;
using OpenGLFeatureUtil = org.allbinary.graphics.opengles.OpenGLFeatureUtil;
using NullUtil = org.allbinary.logic.NullUtil;
using PreLogUtil = org.allbinary.logic.communication.log.PreLogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;

namespace org.allbinary.graphics.draw;

public class DrawVerticalStringUtil
{
    private static readonly DrawVerticalStringUtil instance = new DrawVerticalStringUtil();
    public static DrawVerticalStringUtil getInstance()
    {
        return DrawVerticalStringUtil.instance;
    }

    private readonly string EMPTY_STRING = StringUtil.getInstance().EMPTY_STRING;
    private int anchor = Anchor.TOP_LEFT;
    private int charHeight = 0;
    private int offsetY = 0;
    private int[] offsetXArray = NullUtil.getInstance().NULL_INT_ARRAY;
    public virtual void updateMeasurement(Graphics graphics, string @string)
    {
        OpenGLFeatureUtil openGLFeatureUtil = OpenGLFeatureUtil.getInstance();
        Font font = graphics.getFont();
        this.charHeight = font.getHeight();
        this.offsetY = 0;
        if (J2MEUtil.isHTML()) {
            this.charHeight += 1;
        } else if (openGLFeatureUtil.isAnyThreed()) {
            this.charHeight += 2;
            if (AndroidUtil.isAndroid()) {
            } else {
                this.offsetY = 2 + (this.charHeight * 2 / 3);
            }
        }
        int size = @string.Length;
        char aChar = '\0';
        int[] offsetXArray = new int[size];
        for (int index = size - 1; index >= 0; index--) {
            aChar = @string[index];
            if (openGLFeatureUtil.isAnyThreed()) {
                offsetXArray[index] = font.charWidth(aChar) / 2;
            }
        }
        this.offsetXArray = offsetXArray;
    }

    public virtual void paintVerticle(Graphics graphics, string @string, int x, int y, int anchor)
    {
        int size = @string.Length;
        char aChar = '\0';
        for (int index = size - 1; index >= 0; index--) {
            aChar = @string[index];
            graphics.drawChar(aChar, x + this.offsetXArray[index], y + (this.charHeight * index) + this.offsetY, anchor);
        }
    }

    public virtual void drawCenterString(Graphics graphics, string @string, int offset, int length, int x, int y)
    {
        int width = (graphics.getFont().substringWidth(@string, offset, length) >> 1);
        try {
            graphics.drawSubstring(@string, offset, length, x - width, y, this.anchor);
        } catch (Exception e) {
            PreLogUtil.put(new StringMaker().append("Exception: stringLength: ").appendint(@string.Length).append(" offset: ").appendint(offset).append(" currentLength: ").appendint(length).ToString(), this, "drawCenterString");
        }
    }

    public virtual void drawCenterStrings(Graphics graphics, string[] stringArray, int maxWidth, int x, int y)
    {
        int extraLines = 0;
        for (int index = 0; index < stringArray.Length; index++) {
            string @string = stringArray[index];
            if (@string != this.EMPTY_STRING) {
                int width = graphics.getFont().stringWidth(@string);
                int minTotalLines = 1;
                if (width > maxWidth) {
                    minTotalLines = (width / maxWidth) + 1;
                }
                int linePortion = @string.Length / minTotalLines;
                int offset = 0;
                int currentLength = linePortion;
                int size = @string.Length;
                while (offset < size) {
                    if (offset + currentLength > size) {
                        currentLength = size - offset;
                    }
                    if (offset + currentLength != size) {
                        while (currentLength > 0 && stringArray[index].charAt(offset + currentLength) != ' ') {
                            currentLength--;
                        }
                        if (currentLength <= 4) {
                            currentLength = linePortion;
                        }
                    }
                    this.drawCenterString(graphics, @string, offset, currentLength, x, y + ((index + extraLines++) * this.charHeight));
                    offset = offset + currentLength;
                    currentLength = linePortion;
                }
                extraLines--;
            }
        }
    }

}

