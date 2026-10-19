/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2007 AllBinary 
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

namespace org.allbinary.logic.util.cache;

public class CacheType
{
    private readonly string vendor;
    private readonly string type;
    public CacheType(string vendor, string type)
    {
        this.vendor = vendor;
        this.type = type;
    }

    public virtual string getVendor()
    {
        return this.vendor;
    }

    public virtual string getType()
    {
        return this.type;
    }

    public override string ToString()
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append("CacheType: Vendor: ");
        stringBuffer.append(this.getVendor());
        stringBuffer.append(" Type: ");
        stringBuffer.append(this.getType());
        return stringBuffer.ToString();
    }

}

