/*
 *
 * AllBinary Open License Version 1
 * Copyright (c) 2026 AllBinary
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
//using IOException = java.io.IOException;
using InputStream = java.io.InputStream;
using Form = javax.microedition.lcdui.Form;
using Image = javax.microedition.lcdui.Image;
using Item = javax.microedition.lcdui.Item;
using Manager = javax.microedition.media.Manager;
using MediaException = javax.microedition.media.MediaException;
using Player = javax.microedition.media.Player;

namespace org.allbinary;

//like microemu-playn, so the languages without overloading can be generated. J2ME uses the MIDP overloads.
public class MIDPUtil
{
    private static readonly MIDPUtil instance = new MIDPUtil();
    public static MIDPUtil getInstance()
    {
        return MIDPUtil.instance;
    }

    public virtual Image createImageWH(int width, int height)
    {
        return Image.createImageWH(width, height);
    }

    public virtual Image createImageFromByteArray(sbyte[] imageData, int imageOffset, int imageLength)
    {
        return Image.createImageFromByteArray(imageData, imageOffset, imageLength);
    }

    // throws IOException
    public virtual Image createImageFromInputStream(InputStream inputStream)
    {
        return Image.createImageFromInputStream(inputStream);
    }

    // throws IOException, MediaException
    public virtual Player createPlayerFromInputStream(InputStream inputStream, string type)
    {
        return Manager.createPlayerFromInputStream(inputStream, type);
    }

    public virtual int appendItem(Form form, Item item)
    {
        return form.appendItem(item);
    }

}

