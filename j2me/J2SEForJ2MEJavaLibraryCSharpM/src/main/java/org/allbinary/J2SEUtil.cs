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
using java.util;

namespace org.allbinary;

//J2SEForJ2ME
public class J2SEUtil
{
    private static readonly J2SEUtil instance = new J2SEUtil();
    public static J2SEUtil getInstance()
    {
        return J2SEUtil.instance;
    }

    public virtual object[] getHashMapAsArray(HashMap<object, object> hashMap)
    {
        object[] objectArray = hashMap.keySet().toArray();
        return objectArray;
    }

    public virtual object[] getMapAsArray(Map<object, object> map)
    {
        object[] objectArray = map.keySet().toArray();
        return objectArray;
    }

    public virtual object[] getSetAsArray(Set<string> set)
    {
        object[] objectArray = set.toArray();
        return objectArray;
    }

}

