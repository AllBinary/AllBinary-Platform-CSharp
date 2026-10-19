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
using System.Runtime.CompilerServices;
using NullUtil = org.allbinary.logic.NullUtil;

namespace org.allbinary.logic.system.loader;

public class WebappClassLoaderInfo
{
    private static object classLoader = NullUtil.getInstance().NULL_OBJECT;
    private WebappClassLoaderInfo()
    {
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public static void setLoader(ClassLoader classLoader)
    {
        WebappClassLoaderInfo.classLoader = classLoader;
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public static ClassLoader getLoader()
    {
        return ((ClassLoader) WebappClassLoaderInfo.classLoader);
    }

}

