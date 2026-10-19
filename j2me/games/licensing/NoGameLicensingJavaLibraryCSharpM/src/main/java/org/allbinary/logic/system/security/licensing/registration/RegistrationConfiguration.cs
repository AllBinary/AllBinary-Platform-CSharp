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
using StringMaker = org.allbinary.logic.@string.StringMaker;

namespace org.allbinary.logic.system.security.licensing.registration;

public class RegistrationConfiguration
{
    private static readonly RegistrationConfiguration SINGLETON = new RegistrationConfiguration();
    private string registrationCode = "No Registration Code";
    public readonly string NAME = "registrationid";
    private RegistrationConfiguration()
    {
    }

    public static RegistrationConfiguration getInstance()
    {
        return RegistrationConfiguration.SINGLETON;
    }

    // throws Exception
    private void read()
    {
    }

    // throws Exception
    public virtual void write()
    {
    }

    public override string ToString()
    {
        return new StringMaker().append("Registration Code: ").append(this.getRegistrationCode()).ToString();
    }

    public virtual void setRegistrationCode(string registrationCode)
    {
        this.registrationCode = registrationCode;
    }

    public virtual string getRegistrationCode()
    {
        return this.registrationCode;
    }

}

