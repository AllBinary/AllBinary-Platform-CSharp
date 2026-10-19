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
using StringUtil = org.allbinary.logic.@string.StringUtil;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.logic.system.security.licensing;

public class AbeNoLicense : AbeLicenseInterface
{
    private static AbeNoLicense abeNoLicense = new AbeNoLicense();
    public BasicArrayList serverVector = new BasicArrayListD();
    private AbeNoLicense()
    {
    }

    public static AbeNoLicense getInstance()
    {
        return AbeNoLicense.abeNoLicense;
    }

    public virtual bool hasKey()
    {
        return false;
    }

    public virtual string getKey(string keyName)
    {
        return StringUtil.getInstance().EMPTY_STRING;
    }

    public virtual string getLicenseId()
    {
        return StringUtil.getInstance().EMPTY_STRING;
    }

    public virtual string getSpecial()
    {
        return StringUtil.getInstance().EMPTY_STRING;
    }

    public virtual BasicArrayList getServers()
    {
        return this.serverVector;
    }

    public virtual bool isValid()
    {
        return false;
    }

    public virtual LicenseType getLicenseType()
    {
        return LicenseTypeFactory.getInstance().UNKNOWN;
    }

}

