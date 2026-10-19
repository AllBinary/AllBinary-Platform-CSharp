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
using DebugFactory = org.allbinary.debug.DebugFactory;
using NoDebug = org.allbinary.debug.NoDebug;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.business.init;

public class LicenseInitInfo
{
    private string id = StringUtil.getInstance().EMPTY_STRING;
    private BasicArrayList serverList = new BasicArrayListD();
    public LicenseInitInfo()
    {
    }

    public virtual string getLicenseId()
    {
        return this.id;
    }

    public virtual string getServer(int index)
    {
        return ((string) this.serverList.get(index));
    }

    public virtual int getNumberOfServers()
    {
        return this.serverList.size();
    }

    public virtual void setLicenseId(string value)
    {
        this.id = value;
    }

    public virtual void clearServers()
    {
        this.serverList.clear();
    }

    public virtual void setServer(string value, int index)
    {
        this.serverList.addAt(index, value);
    }

    public virtual void addServer(string value)
    {
        this.serverList.add(value);
    }

    public virtual BasicArrayList getServerList()
    {
        return this.serverList;
    }

    public virtual void setServerList(BasicArrayList servers)
    {
        if (DebugFactory.getInstance() == NoDebug.getInstance()) {
            this.serverList = servers;
        }
    }

}

