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
//using PageContext = javax.servlet.jsp.PageContext;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using LogConfigTypeFactory = org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory;
using LogConfigTypes = org.allbinary.logic.communication.log.config.type.LogConfigTypes;

namespace admin.taghelpers;

public class AdminConfigurationHelper : BasicTable
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public AdminConfigurationHelper(HashMap<object, object> hashMap, PageContext pageContext)
    {
    }

    public override string create()
    {
        try {
            string success = "No Imp";
            if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().SQLTAGS)) {
                this.logUtil.putF(success, this, "create()");
            }
            return success;
        } catch (Exception e) {
            string error = "Failed to create table";
            if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "create()", e);
            }
            return error;
        }
    }

    public override string drop()
    {
        try {
            string success = "No Imp";
            if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().SQLTAGS)) {
                this.logUtil.putF(success, this, this.commonStrings.DROP);
            }
            return success;
        } catch (Exception e) {
            string error = "Failed to drop table";
            if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.DROP, e);
            }
            return error;
        }
    }

    public override string restore()
    {
        try {
            string success = "No Imp";
            return success;
        } catch (Exception e) {
            string error = "Failed to restore backup";
            if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "restore()", e);
            }
            return error;
        }
    }

    public override string backup()
    {
        try {
            string success = "Backup Successful";
            if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().SQLTAGS)) {
                this.logUtil.putF(success, this, "backup()");
            }
            return success;
        } catch (Exception e) {
            string error = "Failed to make backup";
            if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "backup()", e);
            }
            return error;
        }
    }

}

