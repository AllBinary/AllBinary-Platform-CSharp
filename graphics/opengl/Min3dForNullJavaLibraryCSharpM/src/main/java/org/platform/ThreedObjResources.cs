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
using StdUtil = org.allbinary.logic.StdUtil;
using org.allbinary.util;

namespace org.platform;

public class ThreedObjResources
{
    private static readonly ThreedObjResources instance = new ThreedObjResources();
    public static ThreedObjResources getInstance()
    {
        return ThreedObjResources.instance;
    }

    public readonly ABHashtable<object, object> hashtable = StdUtil.getInstance().createHashtable();
    public virtual string get(string resourceName)
    {
        string resourceName2 = ((string) this.hashtable.get(resourceName));
        if (resourceName2 != null) {
            return resourceName2;
        }
        return resourceName;
    }

}

