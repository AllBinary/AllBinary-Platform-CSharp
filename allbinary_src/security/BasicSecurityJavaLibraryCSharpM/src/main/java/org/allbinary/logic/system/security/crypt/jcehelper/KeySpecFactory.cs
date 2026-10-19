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
//using KeySpec = java.security.spec.KeySpec;
//using DESKeySpec = javax.crypto.spec.DESKeySpec;
//using DESedeKeySpec = javax.crypto.spec.DESedeKeySpec;
using TsUtil = org.allbinary.TsUtil;
using PreLogUtil = org.allbinary.logic.communication.log.PreLogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.logic.system.security.crypt.jcehelper;

public class KeySpecFactory
{
    private static readonly KeySpecFactory instance = new KeySpecFactory();
    public static KeySpecFactory getInstance()
    {
        return KeySpecFactory.instance;
    }

    public readonly string DES = "DES";
    public readonly string DESEDE = "DESede";
    public readonly string BLOWFISH = "Blowfish";
    private KeySpecFactory()
    {
    }

    public virtual KeySpec getInstance(string algorithm, sbyte[] keyData)
    {
        try {
            TsUtil tsUtil = TsUtil.getInstance();
            if (tsUtil.compareTo(algorithm, this.DES) == 0) {
                return new DESKeySpec(keyData);
            } else if (tsUtil.compareTo(algorithm, this.DESEDE) == 0) {
                return new DESedeKeySpec(keyData);
            } else {
                throw new SystemException();
            }
        } catch (Exception e) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            PreLogUtil.putOE(commonStrings.EXCEPTION, this, commonStrings.GET_INSTANCE, e);
            throw new SystemException();
        }
    }

}

