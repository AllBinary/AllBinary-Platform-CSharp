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

namespace org.allbinary.graphics.j2me;

public class StatusFactory
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly StatusFactory instance = new StatusFactory();
    public static StatusFactory getInstance()
    {
        return StatusFactory.instance;
    }

    private readonly string SETSTATUS = "setStatus";
    private readonly string STATUS_LABEL = "Status: ";
    public virtual void setStatusNoLog(string status)
    {
        MyFrame.statusJLabel.setText(status);
    }

    public virtual void setStatus(string status)
    {
        this.setStatusNoLog(status);
        this.logUtil.putF(this.STATUS_LABEL + status, this, this.SETSTATUS);
    }

}

