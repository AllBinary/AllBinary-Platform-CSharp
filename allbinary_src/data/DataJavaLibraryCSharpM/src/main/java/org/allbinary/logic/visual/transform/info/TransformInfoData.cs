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

public class TransformInfoData
{
    private static readonly TransformInfoData instance = new TransformInfoData();
    public static TransformInfoData getInstance()
    {
        return TransformInfoData.instance;
    }

    private TransformInfoData()
    {
        this.OWNER = "OWNER_" + this.NAME;
        this.PARTIAL = "PARTIAL_" + this.NAME;
    }

    public readonly string PARENT = "TRANSFORM_INFO_PARENT";
    public readonly string MAPPED = "TRANSFORM_INFO_MAPPED";
    public readonly string NAME = "TRANSFORM_INFO_NAME";
    public readonly string DESCRIPTION = "TRANSFORM_INFO_DESCRIPTION";
    public readonly string CATEGORY = "TRANSFORM_INFO_CATEGORY";
    public readonly string OBJECTFILENAME = "TRANSFORM_INFO_OBJECTFILENAME";
    public readonly string OBJECT = "TRANSFORM_INFO_OBJECT";
    public readonly string OBJECTCONFIGFILENAME = "TRANSFORM_INFO_OBJECTCONFIGFILENAME";
    public readonly string OBJECTCONFIG = "TRANSFORM_INFO_OBJECTCONFIG";
    public readonly string TEMPLATEFILENAME = "TRANSFORM_INFO_TEMPLATEFILENAME";
    public readonly string TEMPLATE = "TRANSFORM_INFO_TEMPLATE";
    public readonly string DATAFILENAME = "TRANSFORM_INFO_DATAFILENAME";
    public readonly string DATA = "TRANSFORM_INFO_DATA";
    public readonly string LABEL = "TRANSFORM_INFO_LABEL";
    public readonly string OWNER;
    public readonly string PARTIAL;
}

