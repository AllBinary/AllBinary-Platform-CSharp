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
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.logic.communication.log.config.type;

public class LogConfigType
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private string name;
    private string description;
    public static BasicArrayList availableLogConfigTypes = new BasicArrayListD();
    public LogConfigType(string name, string description)
    {
        this.name = name;
        this.description = description;
        LogConfigType.availableLogConfigTypes.add(this);
    }

    public virtual string getName()
    {
        return this.name;
    }

    public virtual string getDescription()
    {
        return this.description;
    }

    public virtual void setName(string value)
    {
        this.name = value;
    }

    public virtual void setDescription(string value)
    {
        this.description = value;
    }

}

