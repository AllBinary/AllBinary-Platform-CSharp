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
using java.util;
using StdUtil = org.allbinary.logic.StdUtil;

namespace org.allbinary.logic.visual.media;

public class MediaData
{
    private static HashMap<object, object> hashMap = StdUtil.getInstance().createHashMap();
    private string name;
    private string type;
    private string extension;
    protected MediaData(string a_Name)
    {
        this.name = a_Name;
        this.extension = "." + this.name;
        this.type = MediaTypeData.getInstance().NOT_RESIZABLE_MEDIA;
        MediaData.hashMap.put(a_Name, this);
    }

    public virtual string getName()
    {
        return this.name;
    }

    public virtual string getType()
    {
        return this.type;
    }

    public virtual string getExtension()
    {
        return this.extension;
    }

    public virtual bool isConvertableTo(MediaData mediaData)
    {
        if (this == MediaDataFactory.getInstance().GIF && mediaData == MediaDataFactory.getInstance().JPG) {
            return true;
        }
        return false;
    }

    public override string ToString()
    {
        return this.getName();
    }

    // throws Exception
    public static MediaData get(string a_Name)
    {
        MediaData mediaData = ((MediaData) MediaData.hashMap.get(a_Name));
        if (mediaData != null) {
            return mediaData;
        } else {
            throw new Exception("No Such MediaData");
        }
    }

    public static MediaData getDefault()
    {
        return MediaDataFactory.getInstance().JPG;
    }

    public static HashMap<object, object> toHashMap()
    {
        return MediaData.hashMap;
    }

}

