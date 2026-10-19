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
//using Cipher = javax.crypto.Cipher;
//using SecretKey = javax.crypto.SecretKey;
using ByteUtil = org.allbinary.logic.java.byteutil.ByteUtil;

namespace org.allbinary.logic.system.security.crypt.jcehelper;

public class SecretComposite : BaseSecretComposite
{
    private readonly ByteUtil byteUtil = ByteUtil.getInstance();
    private readonly Cipher cipher;
    private readonly SecretKey secretKey;
    private sbyte[] key;
    public SecretComposite(SecretKey secretKey, Cipher cipher, sbyte[] key)
    {
        this.secretKey = secretKey;
        this.cipher = cipher;
        this.key = key;
    }

    // throws Exception
    public override sbyte[] encrypt(sbyte[] array)
    {
        array = this.mutilate(array);
        this.cipher.init(Cipher.ENCRYPT_MODE, this.secretKey);
        return this.cipher.doFinal(array);
    }

    // throws Exception
    public override sbyte[] decrypt(sbyte[] array)
    {
        this.cipher.init(Cipher.DECRYPT_MODE, this.secretKey);
        return this.mutilate(this.cipher.doFinal(array));
    }

    private sbyte[] mutilate(sbyte[] array)
    {
        for (int index = 0; index < this.key.Length; index++) {
            sbyte value = this.key[index];
            if (((int) value) < 8 && ((int) value) > 0) {
                array = this.byteUtil.xorByte(array, ((int) value));
            }
        }
        return array;
    }

}

