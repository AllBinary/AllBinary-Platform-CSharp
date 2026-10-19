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

public class MediaTypeData
{
    private static readonly MediaTypeData instance = new MediaTypeData();
    public static MediaTypeData getInstance()
    {
        return MediaTypeData.instance;
    }

    private MediaTypeData()
    {
    }

    public readonly string RESIZABLE_MEDIA = "RESIZABLE_MEDIA";
    public readonly string NOT_RESIZABLE_MEDIA = "NOT_RESIZABLE_MEDIA";
}

