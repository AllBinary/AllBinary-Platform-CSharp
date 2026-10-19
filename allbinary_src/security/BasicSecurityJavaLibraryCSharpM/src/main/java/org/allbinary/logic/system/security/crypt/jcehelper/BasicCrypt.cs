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
using TsUtil = org.allbinary.TsUtil;
using CryptInterface = org.allbinary.init.crypt.jcehelper.CryptInterface;
using NullUtil = org.allbinary.logic.NullUtil;
using PreLogUtil = org.allbinary.logic.communication.log.PreLogUtil;
using ByteUtil = org.allbinary.logic.java.byteutil.ByteUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.logic.system.security.crypt.jcehelper;

public class BasicCrypt : CryptInterface
{
    private readonly ByteUtil byteUtil = ByteUtil.getInstance();
    private readonly sbyte[] key;
    public BasicCrypt(string keyAsString)
    {
        sbyte[] key = NullUtil.getInstance().NULL_BYTE_ARRAY;
        try {
            key = TsUtil.getInstance().getByteArray(keyAsString);
        } catch (Exception e) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            PreLogUtil.putOE(commonStrings.EXCEPTION, this, "AbCrypt(alg,key)", e);
        }
        this.key = key;
    }

    public virtual sbyte[] encrypt(sbyte[] array)
    {
        try {
            return this.mutilate(array);
        } catch (Exception e) {
            PreLogUtil.putOE("Encrypt Failed", this, "encrypt", e);
            return NullUtil.getInstance().NULL_BYTE_ARRAY;
        }
    }

    public virtual sbyte[] decrypt(sbyte[] array)
    {
        try {
            return this.mutilate(array);
        } catch (Exception e) {
            PreLogUtil.putOE("decrypt Failed", this, "decrypt", e);
            return NullUtil.getInstance().NULL_BYTE_ARRAY;
        }
    }

    public virtual sbyte[] mutilate(sbyte[] array)
    {
        sbyte value = 0;
        for (int index = 0; index < this.key.Length; index++) {
            value = this.key[index];
            array = this.byteUtil.xor(array, value);
        }
        return array;
    }

}

