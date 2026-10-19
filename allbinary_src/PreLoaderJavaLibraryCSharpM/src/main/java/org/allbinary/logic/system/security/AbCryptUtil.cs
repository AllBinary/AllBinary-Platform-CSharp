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
//using ByteArrayOutputStream = java.io.ByteArrayOutputStream;
//using InputStream = java.io.InputStream;
using StreamUtil = org.allbinary.logic.io.StreamUtil;
using AbCrypt = org.allbinary.logic.system.security.crypt.jcehelper.AbCrypt;
using KeySpecFactory = org.allbinary.logic.system.security.crypt.jcehelper.KeySpecFactory;

namespace org.allbinary.logic.system.security;

public class AbCryptUtil
{
    private static readonly AbCryptUtil instance = new AbCryptUtil();
    public static AbCryptUtil getInstance()
    {
        return AbCryptUtil.instance;
    }

    private readonly StreamUtil streamUtil = StreamUtil.getInstance();
    private AbCryptUtil()
    {
    }

    // throws Exception
    public virtual sbyte[] decrypt(InputStream inputStream, string key)
    {
        System.IO.MemoryStream outputStream = null;
        try {
            outputStream = ((System.IO.MemoryStream) this.streamUtil.get(inputStream, new System.IO.MemoryStream(), new sbyte[16384]));
            AbCrypt abCrypt = new AbCrypt(KeySpecFactory.getInstance().DESEDE);
            abCrypt.init(key);
            return abCrypt.decrypt(((sbyte[]) (Array) outputStream.ToArray()));
        } finally {
            this.streamUtil.close(outputStream);
            this.streamUtil.close(inputStream);
        }
    }

}

