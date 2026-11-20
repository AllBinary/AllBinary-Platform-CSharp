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
using BasicTable = admin.taghelpers.BasicTable;
using Portion = org.allbinary.business.installer.Portion;
using TransformInfoEntityBuilder = org.allbinary.data.tables.transform.info.TransformInfoEntityBuilder;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using AbSqlTableUtil = org.allbinary.logic.communication.sql.AbSqlTableUtil;
using LogConfigTypeFactory = org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory;
using LogConfigTypes = org.allbinary.logic.communication.log.config.type.LogConfigTypes;

namespace taghelpers.transform.info;

public class TransformInfoHelper : BasicTable
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly Portion portion;
    public TransformInfoHelper(HashMap<object, object> hashMap, PageContext pageContext)
    {
        this.portion = new Portion(hashMap);
    }

    public override string drop()
    {
        try {
            return TransformInfoEntityBuilder.getInstance().dropTable();
        } catch (Exception e) {
            string error = "Failed to drop view info table";
            if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.DROP, e);
            }
            return error;
        }
    }

    public override string create()
    {
        try {
            return TransformInfoEntityBuilder.getInstance().createTable();
        } catch (Exception e) {
            string error = "Failed to create view info table";
            if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "create()", e);
            }
            return error;
        }
    }

    public override string restore()
    {
        try {
            string success = "Restore Successful";
            string result = AbSqlTableUtil.getInstance().restoreTable(TransformInfoEntityBuilder.getInstance(), this.portion);
            if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().SQLTAGS)) {
                this.logUtil.putF(success, this, "restore()");
            }
            return result;
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
            string result = AbSqlTableUtil.getInstance().backupTable(TransformInfoEntityBuilder.getInstance());
            if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().SQLTAGS)) {
                this.logUtil.putF(success, this, "backup()");
            }
            return result;
        } catch (Exception e) {
            string error = "Failed to make backup";
            if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "backup()", e);
            }
            return error;
        }
    }

}

