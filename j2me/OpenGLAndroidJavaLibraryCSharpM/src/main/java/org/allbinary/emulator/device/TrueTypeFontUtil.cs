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
//using File = java.io.File;
//using FileOutputStream = java.io.FileOutputStream;
//using GL10 = javax.microedition.khronos.opengles.GL10;
//using Image = javax.microedition.lcdui.Image;
using Bitmap = android.graphics.Bitmap;
using Canvas = android.graphics.Canvas;
using Paint = android.graphics.Paint;
using Rect = android.graphics.Rect;
using Typeface = android.graphics.Typeface;
using ResourceUtil = org.allbinary.data.resource.ResourceUtil;
using BasicColor = org.allbinary.graphics.color.BasicColor;
using CanvasStrings = org.allbinary.graphics.displayable.CanvasStrings;
using PreResourceImageUtil = org.allbinary.image.PreResourceImageUtil;
using OpenGLESImage = org.allbinary.image.opengles.OpenGLESImage;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using PreLogUtil = org.allbinary.logic.communication.log.PreLogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;
using AndroidImageInterface = org.microemu.android.device.AndroidImageInterface;
using AndroidImmutableImage = org.microemu.android.device.AndroidImmutableImage;

namespace org.allbinary.emulator.device;

//TTF
public class TrueTypeFontUtil : TrueTypeFontUtilBase
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly TrueTypeFontUtil instance = new TrueTypeFontUtil();
    public static TrueTypeFontUtil getInstance()
    {
        return TrueTypeFontUtil.instance;
    }

    public readonly PreResourceImageUtil preResourceImageUtil = PreResourceImageUtil.getInstance();
    private readonly int realFontSize = 18;
    public OpenGLESImage fontImage = OpenGLESImage.NULL_OPENGL_IMAGE;
    private TrueTypeFontUtil() : base(1)
    {
        // base(1) is called from the constructor declaration
    }

    public virtual void saveFontAtlasAsFile()
    {
        try {
            CommonStrings commonStrings = CommonStrings.getInstance();
            File file = ResourceUtil.getInstance().getContext().getFilesDir();
            string path = file.getAbsolutePath() + CanvasStrings.getInstance().FONT_ATLAS;
            this.logUtil.putF(path, this, commonStrings.CONSTRUCTOR);
            FileOutputStream fos = new FileOutputStream(path);
            Bitmap bitmap = (((AndroidImageInterface) this.fontImage.openGLBitmap.getImage())).getBitmap();
            bitmap.compress(Bitmap.CompressFormat.PNG, 100, fos);
        } catch (Exception e) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            PreLogUtil.putOE(commonStrings.EXCEPTION, this, commonStrings.EXCEPTION, e);
        }
    }

    public virtual Image getFontBitmapGL(GL10 gl, string filename, int cellSize, BasicColor basicColor)
    {
        if (this.fontImage == OpenGLESImage.NULL_OPENGL_IMAGE) {
            int cellsPerRow2 = this.CELLS_PER_ROW * 2;
            int cellsPerRow3 = this.CELLS_PER_ROW * 3;
            int cellsPerRow4 = this.CELLS_PER_ROW * 4;
            int cellsPerRow5 = this.CELLS_PER_ROW * 5;
            int cellsPerRow6 = this.CELLS_PER_ROW * 6;
            int cellsPerRow7 = this.CELLS_PER_ROW * 7;
            Typeface typeface = Typeface.DEFAULT;
            int textureSize = this.getAsTextureSize(this.CELLS_PER_ROW * cellSize);
            Bitmap bitmap = Bitmap.createBitmap(textureSize, textureSize, Bitmap.Config.ARGB_8888);
            Canvas canvas = new Canvas(bitmap);
            Paint paint = new Paint();
            paint.setTypeface(typeface);
            paint.setTextSize(((float) this.realFontSize));
            paint.setAlpha(((int) basicColor.alpha));
            paint.setColor(basicColor.intValue());
            int biggestHeight = 0;
            Rect bounds = new Rect();
            int x = 0;
            int y = 0;
            for (int index = 0; index < this.size; index++) {
                this.characterArray[0] = this.pattern.charAt(index);
                paint.getTextBounds(this.characterArray, 0, 1, bounds);
                this._characterWidth[index] = bounds.right;
                if (bounds.bottom - bounds.top > biggestHeight) {
                    biggestHeight = bounds.bottom - bounds.top;
                }
                x = (index % this.CELLS_PER_ROW) * cellSize;
                x += (cellSize >> 1);
                x -= (this._characterWidth[index] >> 1);
                y = 0;
                if (index >= this.CELLS_PER_ROW) {
                    y += cellSize;
                }
                if (index >= cellsPerRow2) {
                    y += cellSize;
                }
                if (index >= cellsPerRow3) {
                    y += cellSize;
                }
                if (index >= cellsPerRow4) {
                    y += cellSize;
                }
                if (index >= cellsPerRow5) {
                    y += cellSize;
                }
                if (index >= cellsPerRow6) {
                    y += cellSize;
                }
                if (index >= cellsPerRow7) {
                    y += cellSize;
                }
                y += cellSize;
                y -= (cellSize >> 2);
                canvas.drawText(this.characterArray, 0, 1, ((float) x) - 3f, ((float) y) - 6f, paint);
            }
            canvas.save();
            Image image = AndroidImmutableImage.create(bitmap);
            this.fontImage = ((OpenGLESImage) this.preResourceImageUtil.encapsulate(image));
            return this.fontImage;
        } else {
            return this.fontImage;
        }
    }

    public virtual int[] getFontWidths(string filename, int fontSize)
    {
        Typeface typeface = Typeface.DEFAULT;
        Paint paint = new Paint();
        paint.setTypeface(typeface);
        paint.setTextSize(((float) fontSize));
        paint.setARGB(255, 255, 255, 255);
        Rect bounds = new Rect();
        for (int index = 0; index < this.size; index++) {
            this.characterArray[0] = this.pattern.charAt(index);
            paint.getTextBounds(this.characterArray, 0, 1, bounds);
            if (index < this.lastCapIndex) {
                if (this.characterArray[0] == '1') {
                    this._characterWidth[index] = bounds.right + 3;
                } else if (this.characterArray[0] == 'J' || this.characterArray[0] == 'V' || this.characterArray[0] == '2' || this.characterArray[0] == '9' || this.characterArray[0] == 'I' || this.characterArray[0] == 'N' || this.characterArray[0] == 'U') {
                    this._characterWidth[index] = bounds.right + 1;
                } else if (this.characterArray[0] == '4' || this.characterArray[0] == 'C' || this.characterArray[0] == 'E' || this.characterArray[0] == 'O') {
                    this._characterWidth[index] = bounds.right - 2;
                } else if (this.characterArray[0] == 'B' || this.characterArray[0] == 'D' || this.characterArray[0] == 'G' || this.characterArray[0] == 'H' || this.characterArray[0] == 'T' || this.characterArray[0] == 'W') {
                    this._characterWidth[index] = bounds.right - 3;
                } else if (this.characterArray[0] == 'A' || this.characterArray[0] == 'Q' || this.characterArray[0] == 'R') {
                    this._characterWidth[index] = bounds.right - 5;
                } else if (this.characterArray[0] == 'M') {
                    this._characterWidth[index] = bounds.right - 6;
                } else if (this.characterArray[0] == 'm') {
                    this._characterWidth[index] = bounds.right - 8;
                } else {
                    this._characterWidth[index] = bounds.right;
                }
            } else {
                if (this.characterArray[0] == ' ') {
                    this._characterWidth[index] = bounds.right + 10;
                } else if (this.characterArray[0] == 'l' || this.characterArray[0] == 'i' || this.characterArray[0] == 'j' || this.characterArray[0] == '.' || this.characterArray[0] == '!' || this.characterArray[0] == '|') {
                    this._characterWidth[index] = bounds.right + 6;
                } else if (this.characterArray[0] == 'f' || this.characterArray[0] == 't' || this.characterArray[0] == 'u' || this.characterArray[0] == 'v') {
                    this._characterWidth[index] = bounds.right + 1;
                } else if (this.characterArray[0] == 'r') {
                    this._characterWidth[index] = bounds.right + 2;
                } else if (this.characterArray[0] == 'a' || this.characterArray[0] == 'b' || this.characterArray[0] == 'g' || this.characterArray[0] == 'u') {
                    this._characterWidth[index] = bounds.right - 1;
                } else if (this.characterArray[0] == 'o' || this.characterArray[0] == 'e') {
                    this._characterWidth[index] = bounds.right - 2;
                } else if (this.characterArray[0] == 'm') {
                    this._characterWidth[index] = bounds.right - 7;
                } else {
                    this._characterWidth[index] = bounds.right;
                }
            }
        }
        this._characterWidth[0] = (fontSize >> 1) - 2;
        return this._characterWidth;
    }

}

