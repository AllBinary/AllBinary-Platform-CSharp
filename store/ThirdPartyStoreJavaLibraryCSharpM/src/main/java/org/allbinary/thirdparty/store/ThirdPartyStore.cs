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
using AbeClientInformationInterface = org.allbinary.logic.system.security.licensing.AbeClientInformationInterface;

namespace org.allbinary.thirdparty.store;

public class ThirdPartyStore
{
    private bool authorized = false;
    private readonly string name;
    public ThirdPartyStore(string name)
    {
        this.name = name;
    }

    public virtual void authorize(AbeClientInformationInterface clientInformationInterface)
    {
    }

    public virtual bool isAuthorized()
    {
        return this.authorized;
    }

    protected virtual void setAuthorized(bool authorized)
    {
        this.authorized = authorized;
    }

    public virtual string getName()
    {
        return this.name;
    }

}

