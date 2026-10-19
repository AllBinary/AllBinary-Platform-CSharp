/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2025 AllBinary 
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
using NullUtil = org.allbinary.logic.NullUtil;
using StringUtil = org.allbinary.logic.@string.StringUtil;

namespace org.osgi.framework;

public class NullServiceReference
{
    public virtual object getProperty(string key)
    {
        return NullUtil.getInstance().NULL_OBJECT;
    }

    public virtual string[] getPropertyKeys()
    {
        return StringUtil.getInstance().getArrayInstance();
    }

    public virtual int compareTo(object o)
    {
        throw new SystemException();
    }

}

