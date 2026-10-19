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
using KotlinUtil = org.allbinary.KotlinUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using CommonSeps = org.allbinary.@string.CommonSeps;

namespace org.allbinary.logic.system;

public class SoftwareInformation
{
    private readonly string name;
    private readonly string shortName;
    private readonly string version;
    public SoftwareInformation(string name, string version, string shortName)
    {
        this.name = name;
        this.version = version;
        this.shortName = new StringMaker().append(shortName).append(KotlinUtil.getShortName()).ToString();
    }

    public virtual string getName()
    {
        return this.name;
    }

    public virtual string getVersion()
    {
        return this.version;
    }

    public virtual string toShortString()
    {
        return this.shortName;
    }

    public override string ToString()
    {
        string NAME = "Name: ";
        string VERSION = "Version: ";
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(NAME);
        stringBuffer.append(this.getName());
        stringBuffer.append(CommonSeps.getInstance().SPACE);
        stringBuffer.append(VERSION);
        stringBuffer.append(this.getVersion());
        return stringBuffer.ToString();
    }

}

