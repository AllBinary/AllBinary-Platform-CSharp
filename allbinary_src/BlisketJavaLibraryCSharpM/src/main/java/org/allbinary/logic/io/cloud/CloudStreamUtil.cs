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
//using InputStream = java.io.InputStream;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using AbFile = org.allbinary.logic.io.file.AbFile;

namespace org.allbinary.logic.io;

public class CloudStreamUtil
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly CloudStreamUtil instance = new CloudStreamUtil();
    public static CloudStreamUtil getInstance()
    {
        return CloudStreamUtil.instance;
    }

    // throws Exception
    public virtual InputStream getFile(AbFile file)
    {
        InputStream inputStream = new AbFileInputStream(file);
        int available = inputStream.available();
        if (available > 0) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                this.logUtil.putF("Cloud File Bytes: " + available, this, "processRequest()");
            }
        }
        return inputStream;
    }

    // throws Exception
    public virtual InputStream getFileAnyWhere(AbFile file)
    {
        InputStream inputStream = new AbFileLocalInputStream(file);
        int available = inputStream.available();
        if (available > 0) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                this.logUtil.putF("Local File Bytes: " + available, this, "processRequest()");
            }
        } else {
            inputStream = new AbFileInputStream(file);
            available = inputStream.available();
            if (available > 0) {
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEWERROR)) {
                    this.logUtil.putF("Cloud File Bytes: " + available, this, "processRequest()");
                }
            }
        }
        return inputStream;
    }

    // throws Exception
    public virtual InputStream getFileLocal(AbFile file)
    {
        InputStream inputStream = new AbFileLocalInputStream(file);
        int available = inputStream.available();
        if (available > 0) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                this.logUtil.putF("Local File Bytes: " + available, this, "processRequest()");
            }
        }
        return inputStream;
    }

}

