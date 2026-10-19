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
//using GL10 = javax.microedition.khronos.opengles.GL10;
//using Graphics = javax.microedition.lcdui.Graphics;
//using Image = javax.microedition.lcdui.Image;
using SWT = org.eclipse.swt.SWT;
using ImageData = org.eclipse.swt.graphics.ImageData;
using ImageLoader = org.eclipse.swt.graphics.ImageLoader;
using SwtMutableImage = org.microemu.device.swt.SwtMutableImage;
using AvianUtil = org.allbinary.AvianUtil;
using ResourceUtil = org.allbinary.data.resource.ResourceUtil;
using PointFactory = org.allbinary.graphics.PointFactory;
using Rectangle = org.allbinary.graphics.Rectangle;
using BasicColor = org.allbinary.graphics.color.BasicColor;
using BasicColorFactory = org.allbinary.graphics.color.BasicColorFactory;
using CanvasStrings = org.allbinary.graphics.displayable.CanvasStrings;
using OpenGLCapabilities = org.allbinary.graphics.opengles.OpenGLCapabilities;
using PreResourceImageUtil = org.allbinary.image.PreResourceImageUtil;
using OpenGLESImage = org.allbinary.image.opengles.OpenGLESImage;
using PreLogUtil = org.allbinary.logic.communication.log.PreLogUtil;
using CommonSeps = org.allbinary.@string.CommonSeps;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.emulator.device;

//TTF
public class TrueTypeFontUtil : TrueTypeFontUtilBase
{
    private static readonly TrueTypeFontUtil instance = new TrueTypeFontUtil();
    public static TrueTypeFontUtil getInstance()
    {
        return TrueTypeFontUtil.instance;
    }

    private readonly PreResourceImageUtil preResourceImageUtil = PreResourceImageUtil.getInstance();
    private readonly float[] widthFloatArray = null;
    public OpenGLESImage fontImage = OpenGLESImage.NULL_OPENGL_IMAGE;
    private readonly float widthScale;
    private TrueTypeFontUtil() : base(2)
    {
        // base(2) is called from the constructor declaration
        if (AvianUtil.isAvian()) {
            this.widthFloatArray = new float[] { 1504.0f, 967.0f, 527.0f, 961.0f, 957.0f, 1087.0f, 920.0f, 954.0f, 973.0f, 961.0f, 955.0f, 1296.0f, 1013.0f, 1106.0f, 1167.0f, 815.0f, 815.0f, 1216.0f, 1110.0f, 170.0f, 520.0f, 1056.0f, 815.0f, 1448.0f, 1142.0f, 1345.0f, 927.0f, 1345.0f, 1030.0f, 920.0f, 1096.0f, 1119.0f, 1219.0f, 1841.0f, 1166.0f, 1147.0f, 1005.0f, 879.0f, 965.0f, 792.0f, 964.0f, 927.0f, 753.0f, 1034.0f, 916.0f, 196.0f, 469.0f, 877.0f, 166.0f, 1563.0f, 916.0f, 1007.0f, 965.0f, 964.0f, 631.0f, 777.0f, 649.0f, 917.0f, 1026.0f, 1548.0f, 993.0f, 1028.0f, 795.0f, 241.0f, 798.0f, 241.0f, 905.0f, 1477.0f, 393.0f, 961.0f, 961.0f, 961.0f, 961.0f, 555.0f, 1029.0f, 1010.0f, 1378.0f, 952.0f, 952.0f, 952.0f, 952.0f, 463.0f, 463.0f, 926.0f, 961.0f, 491.0f, 930.0f, 457.0f, 457.0f, 644.0f, 643.0f, 326.0f, 186.0f, 1219.0f, 241.0f, 1599.0f, 961.0f, 302.0f, 711.0f, 961.0f, 961.0f, 710.0f, 141.0f, 1504.0f, 1504.0f, 1504.0f, 1504.0f, 1504.0f, 1504.0f, 1504.0f, 1504.0f };
        } else {
            this.widthFloatArray = new float[] { 1504.0f, 967.0f, 527.0f, 961.0f, 957.0f, 1087.0f, 920.0f, 954.0f, 973.0f, 961.0f, 955.0f, 1296.0f, 1013.0f, 1106.0f, 1167.0f, 815.0f, 815.0f, 1216.0f, 1110.0f, 170.0f, 520.0f, 1056.0f, 815.0f, 1448.0f, 1142.0f, 1345.0f, 927.0f, 1345.0f, 1030.0f, 920.0f, 1096.0f, 1119.0f, 1219.0f, 1841.0f, 1166.0f, 1147.0f, 1005.0f, 879.0f, 965.0f, 792.0f, 964.0f, 927.0f, 753.0f, 1034.0f, 916.0f, 196.0f, 469.0f, 877.0f, 166.0f, 1563.0f, 916.0f, 1007.0f, 965.0f, 964.0f, 631.0f, 777.0f, 649.0f, 917.0f, 1026.0f, 1548.0f, 993.0f, 1028.0f, 795.0f, 241.0f, 798.0f, 241.0f, 905.0f, 1477.0f, 393.0f, 961.0f, 555.0f, 1029.0f, 1010.0f, 1378.0f, 952.0f, 463.0f, 463.0f, 926.0f, 961.0f, 491.0f, 930.0f, 457.0f, 457.0f, 644.0f, 643.0f, 326.0f, 186.0f, 1219.0f, 241.0f, 1599.0f, 961.0f, 302.0f, 711.0f, 961.0f, 961.0f, 710.0f, 141.0f, 1504.0f, 1504.0f };
        }
        this.widthScale = ((this.scale == 2) ? 1.2f : 1f);
    }

    public virtual Image getFontBitmapGL(GL10 gl, string filename, int cellSize, BasicColor basicColor)
    {
        try {
            if (this.fontImage == OpenGLESImage.NULL_OPENGL_IMAGE) {
                CanvasStrings canvasStrings = CanvasStrings.getInstance();
                OpenGLCapabilities openGLCapabilities = OpenGLCapabilities.getInstance();
                if (openGLCapabilities.isTextureSizeValid(1024) && this.scale == 2) {
                    string FONT_ATLAS_1024 = "/font_1024.png";
                    Image image = Image.createImage(ResourceUtil.getInstance().getResourceAsStream(FONT_ATLAS_1024));
                    image.setName(canvasStrings.FONT_ATLAS);
                    this.fontImage = ((OpenGLESImage) this.preResourceImageUtil.encapsulate(image));
                } else if (openGLCapabilities.isTextureSizeValid(512)) {
                    string FONT_ATLAS_512 = "/font_512.png";
                    Image image = Image.createImage(ResourceUtil.getInstance().getResourceAsStream(FONT_ATLAS_512));
                    image.setName(canvasStrings.FONT_ATLAS);
                    this.fontImage = ((OpenGLESImage) this.preResourceImageUtil.encapsulate(image));
                } else {
                    string FONT_ATLAS_512 = "/font_512.png";
                    Image image = Image.createImage(ResourceUtil.getInstance().getResourceAsStream(FONT_ATLAS_512));
                    image.setName(canvasStrings.FONT_ATLAS);
                    this.fontImage = ((OpenGLESImage) this.preResourceImageUtil.encapsulate(image));
                }
                return this.fontImage;
            } else {
                return this.fontImage;
            }
        } catch (Exception e) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            PreLogUtil.putOE(commonStrings.EXCEPTION, this, commonStrings.EXCEPTION, e);
            throw new SystemException();
        }
    }

    public virtual void saveFontAtlasAsFile()
    {
        Image image = this.getFontBitmap(null, cellSize, BasicColorFactory.getInstance().WHITE);
        ImageLoader imageLoader = new ImageLoader();
        ImageData imageData = (((SwtMutableImage) image)).image.getImageData();
        imageData.transparentPixel = imageData.getPixel(0, 0);
        imageLoader.data = new ImageData[] { imageData };
        imageLoader.save(CommonSeps.getInstance().PERIOD + CanvasStrings.getInstance().FONT_ATLAS, SWT.IMAGE_PNG);
    }

    public virtual Image getFontBitmap(string filename, int cellSize, BasicColor basicColor)
    {
        int cellsPerRow2 = this.CELLS_PER_ROW * 2;
        int cellsPerRow3 = this.CELLS_PER_ROW * 3;
        int cellsPerRow4 = this.CELLS_PER_ROW * 4;
        int cellsPerRow5 = this.CELLS_PER_ROW * 5;
        int cellsPerRow6 = this.CELLS_PER_ROW * 6;
        int cellsPerRow7 = this.CELLS_PER_ROW * 7;
        Image image = Image.createImage(textureSize, textureSize);
        Graphics graphics = image.getGraphics();
        graphics.setColor(((int) basicColor));
        int biggestHeight = 0;
        Rectangle bounds = new Rectangle(PointFactory.getInstance().createXY(0, 0), cellSize, cellSize);
        int x = 0;
        int y = 0;
        for (int index = 0; index < size; index++) {
            this.characterArray[0] = pattern.charAt(index);
            _characterWidth[index] = bounds.getMaxX();
            if (bounds.getMaxY() - bounds.getPoint().getX() > biggestHeight) {
                biggestHeight = bounds.getMaxY() - bounds.getPoint().getX();
            }
            x = (index % this.CELLS_PER_ROW) * cellSize;
            x += (cellSize >> 1);
            x -= (_characterWidth[index] >> 1);
            y = -(cellSize >> 1);
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
            graphics.drawChar(this.characterArray[0], x, y, 0);
        }
        return image;
    }

    public virtual int[] getFontWidths(string filename, int fontSize)
    {
        CommonStrings commonStrings = CommonStrings.getInstance();
        for (int index = 0; index < size; index++) {
            this.characterArray[0] = pattern.charAt(index);
            if (this.characterArray[0] == ' ') {
                _characterWidth[index] = (fontSize / 4);
            } else {
                int shortPatternIndex = this.shortPattern.indexOf(this.characterArray[0]);
                int w = ((int) (this.widthFloatArray[shortPatternIndex] / 75f)) + 19;
                _characterWidth[index] = w;
                if (this.characterArray[0] == '.' || this.characterArray[0] == '1') {
                    _characterWidth[index] += 4;
                }
                if (this.characterArray[0] >= 'a' && this.characterArray[0] < 'k') {
                    _characterWidth[index] -= 2;
                }
                if (this.characterArray[0] >= 'k' && this.characterArray[0] < 'v') {
                    _characterWidth[index] -= 4;
                }
                if (this.characterArray[0] >= 'v' && this.characterArray[0] < 'z') {
                    _characterWidth[index] -= 8;
                }
                if (this.characterArray[0] == 'D') {
                    _characterWidth[index] -= 4;
                }
                if (this.characterArray[0] >= 'A' && this.characterArray[0] <= 'Z') {
                    _characterWidth[index] -= 2;
                }
            }
            _characterWidth[index] *= this.widthScale;
        }
        return _characterWidth;
    }

}

