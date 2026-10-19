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
//using Security = java.security.Security;
//using KeySpec = java.security.spec.KeySpec;
//using Cipher = javax.crypto.Cipher;
//using SecretKey = javax.crypto.SecretKey;
//using SecretKeyFactory = javax.crypto.SecretKeyFactory;
using TsUtil = org.allbinary.TsUtil;
using CryptInterface = org.allbinary.init.crypt.jcehelper.CryptInterface;
using NullUtil = org.allbinary.logic.NullUtil;
using PreLogUtil = org.allbinary.logic.communication.log.PreLogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;
using BouncyCastleProvider = org.bouncycastle.jce.provider.BouncyCastleProvider;

namespace org.allbinary.logic.system.security.crypt.jcehelper;

public class AbCrypt : CryptInterface
{
    private readonly TsUtil tsUtil = TsUtil.getInstance();
    private BaseSecretComposite secretComposite = BaseSecretComposite.NULL_SECRET_COMPOSITE;
    private string algorithm;
    public AbCrypt(string algorithm)
    {
        this.algorithm = algorithm;
    }

    public virtual void init(string keyAsString)
    {
        CommonStrings commonStrings = CommonStrings.getInstance();
        try {
            try {
                Security.addProvider(new BouncyCastleProvider());
            } catch (Exception e) {
                PreLogUtil.putOE(commonStrings.EXCEPTION, this, commonStrings.INIT, e);
            }
            sbyte[] key = this.tsUtil.getByteArray(keyAsString);
            KeySpec keySpec = KeySpecFactory.getInstance().getInstance(this.algorithm, key);
            SecretKeyFactory keyFactory = SecretKeyFactory.getInstance(this.algorithm);
            SecretKey secretKey = keyFactory.generateSecret(keySpec);
            Cipher cipher = Cipher.getInstance(this.algorithm);
            this.secretComposite = new SecretComposite(secretKey, cipher, key);
        } catch (Exception e) {
            PreLogUtil.putOE("init Failed", this, commonStrings.INIT, e);
        }
    }

    public virtual sbyte[] encrypt(sbyte[] array)
    {
        try {
            return this.secretComposite.encrypt(array);
        } catch (Exception e) {
            PreLogUtil.putOE("Encrypt Failed", this, "encrypt", e);
            return NullUtil.getInstance().NULL_BYTE_ARRAY;
        }
    }

    public virtual sbyte[] decrypt(sbyte[] array)
    {
        try {
            return this.secretComposite.decrypt(array);
        } catch (Exception e) {
            PreLogUtil.putOE("decrypt Failed", this, "decrypt", e);
            return NullUtil.getInstance().NULL_BYTE_ARRAY;
        }
    }

}

