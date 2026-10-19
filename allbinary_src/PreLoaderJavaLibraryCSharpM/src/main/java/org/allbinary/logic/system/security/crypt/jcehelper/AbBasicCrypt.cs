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
//using Provider = java.security.Provider;
//using Security = java.security.Security;
//using KeySpec = java.security.spec.KeySpec;
//using Cipher = javax.crypto.Cipher;
//using SecretKey = javax.crypto.SecretKey;
//using SecretKeyFactory = javax.crypto.SecretKeyFactory;
using CryptInterface = org.allbinary.init.crypt.jcehelper.CryptInterface;
using PreLogUtil = org.allbinary.logic.communication.log.PreLogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.logic.system.security.crypt.jcehelper;

public class AbBasicCrypt : CryptInterface
{
    private Cipher cipher = null;
    private SecretKey secretKey = null;
    private string algorithm = null;
    private sbyte[] key = null;
    public AbBasicCrypt(string algorithm, string key)
    {
        try {
            this.algorithm = algorithm;
            this.key = key.getBytes();
            this.init();
        } catch (Exception e) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            PreLogUtil.putOE(commonStrings.EXCEPTION, this, "AbCrypt(alg,key)", e);
        }
    }

    private void init()
    {
        try {
            Provider sunJce = new com.sun.crypto.provider.SunJCE();
            Security.addProvider(sunJce);
            KeySpec keySpec = KeySpecFactory.getInstance().getInstance(this.algorithm, this.key);
            SecretKeyFactory keyFactory = SecretKeyFactory.getInstance(this.algorithm);
            this.secretKey = keyFactory.generateSecret(keySpec);
            this.cipher = Cipher.getInstance(this.algorithm);
        } catch (Exception e) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            PreLogUtil.putOE("init Failed", this, commonStrings.INIT, e);
        }
    }

    public virtual sbyte[] encrypt(sbyte[] array)
    {
        try {
            this.cipher.init(Cipher.ENCRYPT_MODE, secretKey);
            sbyte[] ivArray = this.secretKey.getEncoded();
            sbyte[] encrypted = this.cipher.doFinal(array);
            sbyte[] result = new sbyte[ivArray.Length + encrypted.Length];
            PreLogUtil.put("ivArray Length: " + ivArray.Length, this, "encrypt");
            for (int index = 0; index < ivArray.Length; index++) {
                result[index] = ivArray[index];
            }
            for (int index = 0; index < encrypted.Length; index++) {
                result[index + ivArray.Length] = encrypted[index];
            }
            return result;
        } catch (Exception e) {
            PreLogUtil.putOE("Encrypt Failed", this, "encrypt", e);
            return null;
        }
    }

    public virtual sbyte[] decrypt(sbyte[] array)
    {
        try {
            this.cipher.init(Cipher.DECRYPT_MODE, secretKey);
            sbyte[] ivArray = new sbyte[8];
            for (int index = 0; index < 8; index++) {
                ivArray[index] = array[index];
            }
            PreLogUtil.put("ivArray Length: " + ivArray.Length, this, "encrypt");
            sbyte[] result = new sbyte[array.Length - ivArray.Length];
            for (int index = ivArray.Length; index < array.Length; index++) {
                result[index - ivArray.Length] = array[index];
            }
            sbyte[] decrypted = this.cipher.doFinal(result);
            return result;
        } catch (Exception e) {
            PreLogUtil.putOE("decrypt Failed", this, "decrypt", e);
            return null;
        }
    }

}

