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
using GuiLog = org.allbinary.logic.communication.log.GuiLog;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;

namespace org.allbinary.graphics.j2me;

public class GraphicsException : java.lang.Exception
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly GuiLog guiLog = GuiLog.getInstance();
    public GraphicsException(string msg, object obj, string method) : base(msg)
    {
        // base(msg) is called from the constructor declaration
        try {
            this.guiLog.showDialog(msg);
            this.logUtil.put(msg, obj, method, this);
        } catch (Exception e) {
        }
    }

    public GraphicsException(string msg, string className, string method) : base(msg)
    {
        // base(msg) is called from the constructor declaration
        try {
            this.guiLog.showDialog(msg);
            this.logUtil.put(msg, className, method, this);
        } catch (Exception e) {
        }
    }

}

