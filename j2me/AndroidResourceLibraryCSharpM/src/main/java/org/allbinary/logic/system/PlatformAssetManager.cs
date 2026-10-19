/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2022 AllBinary 
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
//using InputStream = java.io.InputStream;
using ResourceUtil = org.allbinary.data.resource.ResourceUtil;

namespace org.allbinary.logic.system;

public class PlatformAssetManager
{
    private static readonly PlatformAssetManager instance = new PlatformAssetManager();
    public static PlatformAssetManager getInstance()
    {
        return PlatformAssetManager.instance;
    }

    // throws Exception
    public virtual InputStream getResourceAsStream(string resource)
    {
        ResourceUtil resourceUtil = ResourceUtil.getInstance();
        InputStream inputStream = resourceUtil.getResourceAsStream(resource);
        return inputStream;
    }

}

