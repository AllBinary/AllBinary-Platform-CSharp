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
using CommonDataFileStrings = org.allbinary.logic.io.file.CommonDataFileStrings;

namespace org.allbinary.logic.visual.transform.info.data;

public class TransformInfoDataData
{
    private static readonly TransformInfoDataData instance = new TransformInfoDataData();
    public static TransformInfoDataData getInstance()
    {
        return TransformInfoDataData.instance;
    }

    private TransformInfoDataData()
    {
    }

    public readonly string UNCRYPTED_EXTENSION = CommonDataFileStrings.getInstance().UNCRYPTED_EXTENSION;
    public readonly string ENCRYPTED_EXTENSION = CommonDataFileStrings.getInstance().ENCRYPTED_EXTENSION;
}

