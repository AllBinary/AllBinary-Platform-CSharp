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

namespace org.allbinary.logic.visual.media;

public class MediaDataFactory
{
    private static readonly MediaDataFactory instance = new MediaDataFactory();
    public static MediaDataFactory getInstance()
    {
        return MediaDataFactory.instance;
    }

    public readonly MediaData AVI = new MediaData("avi");
    public readonly MediaData BMP = new MediaData("bmp");
    public readonly MediaData CEL = new MediaData("cel");
    public readonly MediaData FITS = new MediaData("fits");
    public readonly MediaData FLI = new MediaData("fli");
    public readonly MediaData GBR = new MediaData("gbr");
    public readonly MediaData GIF = new MediaData("gif");
    public readonly MediaData GIH = new MediaData("gih");
    public readonly MediaData JPG = new MediaData("jpg");
    public readonly MediaData PIX = new MediaData("pix");
    public readonly MediaData PNG = new MediaData("png");
    public readonly MediaData PNM = new MediaData("pnm");
    public readonly MediaData PSD = new MediaData("psd");
    public readonly MediaData PSP = new MediaData("psp");
    public readonly MediaData PS = new MediaData("ps");
    public readonly MediaData SGI = new MediaData("SGI");
    public readonly MediaData SWF = new MediaData("swf");
    public readonly MediaData TGA = new MediaData("tga");
    public readonly MediaData TIFF = new MediaData("tiff");
    public readonly MediaData WMF = new MediaData("wmf");
}

