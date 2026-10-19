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

namespace org.allbinary.logic.visual.transform.info.viewObject;

public class TransformInfoObjectData
{
    private static readonly TransformInfoObjectData instance = new TransformInfoObjectData();
    public static TransformInfoObjectData getInstance()
    {
        return TransformInfoObjectData.instance;
    }

    private TransformInfoObjectData()
    {
    }

    public readonly string UNCRYPTED_EXTENSION = "class";
    public readonly string ENCRYPTED_EXTENSION = "abw";
}

