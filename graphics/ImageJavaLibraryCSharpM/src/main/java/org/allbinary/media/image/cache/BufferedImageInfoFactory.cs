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
using StringMaker = org.allbinary.logic.@string.StringMaker;

namespace org.allbinary.media.image.cache;

public class BufferedImageInfoFactory
{
    private static HashMap<object, object> hashMap = StdUtil.getInstance().createHashMap();
    private BufferedImageInfoFactory()
    {
    }

    public static BufferedImageInfo getInstance(int width, int height, int type)
    {
        StringMaker stringbuffer = new StringMaker();
        stringbuffer.appendint(width);
        stringbuffer.appendint(height);
        stringbuffer.appendint(type);
        string key = stringbuffer.ToString();
        BufferedImageInfo bufferedImageInfo = ((BufferedImageInfo) BufferedImageInfoFactory.hashMap.get(key));
        if (bufferedImageInfo == null) {
            bufferedImageInfo = new BufferedImageInfo(width, height, type);
            BufferedImageInfoFactory.hashMap.put(key, bufferedImageInfo);
        }
        return bufferedImageInfo;
    }

}

