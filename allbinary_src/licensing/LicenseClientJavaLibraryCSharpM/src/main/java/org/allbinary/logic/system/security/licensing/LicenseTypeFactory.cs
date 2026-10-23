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
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.logic.system.security.licensing;

public class LicenseTypeFactory
{
    private static readonly LicenseTypeFactory instance = new LicenseTypeFactory();
    public static LicenseTypeFactory getInstance()
    {
        return LicenseTypeFactory.instance;
    }

    public readonly LicenseType UNKNOWN = new LicenseType(CommonStrings.getInstance().UNKNOWN);
    public readonly LicenseType DEMO = new LicenseType("Demo");
    public readonly LicenseType NORMAL = new LicenseType("Normal");
    public virtual LicenseType getInstance(string name)
    {
        if (string.CompareOrdinal(this.DEMO.getName(), name) == 0) {
            return this.DEMO;
        } else if (string.CompareOrdinal(this.NORMAL.getName(), name) == 0) {
            return this.NORMAL;
        }
        return this.UNKNOWN;
    }

}

