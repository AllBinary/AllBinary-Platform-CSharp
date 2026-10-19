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
using BasicArrayList = org.allbinary.util.BasicArrayList;

namespace org.allbinary.image;

public class ImageTypeUtil
{
    private static ImageTypeUtil SINGLETON = new ImageTypeUtil();
    public readonly string PNG = "png";
    public readonly string JPG = "jpg";
    public readonly string GIF = "gif";
    private readonly BasicArrayList list = new BasicArrayListD();
    private ImageTypeUtil()
    {
        this.list.add(JPG);
        this.list.add(GIF);
        this.list.add(PNG);
    }

    public virtual bool isSupported(string mediaFileType)
    {
        mediaFileType = mediaFileType.ToLower();
        for (int index = this.list.size() - 1; index >= 0; index--) {
            string name = ((string) this.list.objectArray[index]);
            if (string.CompareOrdinal(mediaFileType, name) == 0) {
                return true;
            }
        }
        return false;
    }

    public static ImageTypeUtil getInstance()
    {
        return ImageTypeUtil.SINGLETON;
    }

}

