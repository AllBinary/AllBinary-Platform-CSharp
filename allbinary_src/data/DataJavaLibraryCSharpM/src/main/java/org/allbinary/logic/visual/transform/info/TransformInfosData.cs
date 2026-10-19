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

namespace org.allbinary.logic.visual.transform.info;

public class TransformInfosData
{
    private static readonly TransformInfosData instance = new TransformInfosData();
    private TransformInfosData()
    {
    }

    public static TransformInfosData getInstance()
    {
        return TransformInfosData.instance;
    }

    public readonly string NAME = "TRANSFORM_INFOS_NAME";
    public readonly string GROUP = "TRANSFORM_INFOS_GROUP";
    public readonly string ALL = "TRANSFORM_INFOS_ALL";
    public readonly string PREVIEW = "TRANSFORM_INFOS_PREVIEW";
    public readonly string SMALL_PREVIEW = "TRANSFORM_INFOS_SMALL_PREVIEW";
}

