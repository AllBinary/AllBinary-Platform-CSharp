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
using java.util;
using BundleContext = org.osgi.framework.BundleContext;

namespace org.allbinary.input.automation;

public interface RemoteFramework
{
    BundleContext connect(string host);

    void disconnect(BundleContext bc);

    Map getSystemProperties(BundleContext bc);

}

