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
using AbKeys = org.allbinary.logic.system.security.AbKeys;
using AbeClientInformationInterface = org.allbinary.logic.system.security.licensing.AbeClientInformationInterface;
using LicensingException = org.allbinary.logic.system.security.licensing.LicensingException;

namespace org.allbinary.logic.system.loader;

public class SecuredNativeLibraryHelperWrapper : NativeLibraryHelperWrapper
{
    private SecuredNativeLibraryInterface securedNativeLibraryInterface;
    public SecuredNativeLibraryHelperWrapper(SecuredNativeLibraryInterface securedNativeLibraryInterface) : base(securedNativeLibraryInterface.getLibraryName())
    {
        // base(securedNativeLibraryInterface.getLibraryName()) is called from the constructor declaration
        this.securedNativeLibraryInterface = securedNativeLibraryInterface;
    }

    // throws LicensingException
    public virtual bool unlock(AbeClientInformationInterface abeClientInformation)
    {
        return this.securedNativeLibraryInterface.unlock(AbKeys.getInstance().getKey(abeClientInformation, this.securedNativeLibraryInterface.getName()));
    }

}

