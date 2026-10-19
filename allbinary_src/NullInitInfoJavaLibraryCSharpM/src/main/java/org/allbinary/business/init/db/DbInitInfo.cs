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
using PreLogUtil = org.allbinary.logic.communication.log.PreLogUtil;

namespace org.allbinary.business.init.db;

//import org.allbinary.logic.communication.log.config.type.LogConfigTypes;
public class DbInitInfo : DbConnectionInfo
{
    public DbInitInfo(string initFileName, bool read) : base()
    {
        // base() is called from the constructor declaration
    }

    public virtual string getUrl()
    {
        string url = base.getUrl();
        PreLogUtil.put("Url: " + url, this, "getUrl");
        return url;
    }

    // throws Exception
    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual void write()
    {
    }

    // throws Exception
    [MethodImpl(MethodImplOptions.Synchronized)]
    private void load()
    {
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual void setHasRead(bool value)
    {
    }

}

