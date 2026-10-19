/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2025 AllBinary 
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
using NullUtil = org.allbinary.logic.NullUtil;

namespace org.allbinary.logic.system.security.crypt.jcehelper;

public class BaseSecretComposite
{
    public static readonly BaseSecretComposite NULL_SECRET_COMPOSITE = new BaseSecretComposite();
    // throws Exception
    public virtual sbyte[] encrypt(sbyte[] array)
    {
        return NullUtil.getInstance().NULL_BYTE_ARRAY;
    }

    // throws Exception
    public virtual sbyte[] decrypt(sbyte[] array)
    {
        return NullUtil.getInstance().NULL_BYTE_ARRAY;
    }

}

