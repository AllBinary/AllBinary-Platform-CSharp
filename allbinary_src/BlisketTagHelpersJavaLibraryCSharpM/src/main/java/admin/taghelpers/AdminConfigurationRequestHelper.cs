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
//using HttpServletRequest = javax.servlet.http.HttpServletRequest;
//using PageContext = javax.servlet.jsp.PageContext;
using AdminConfiguration = org.allbinary.business.user.modules.admin.configuration.AdminConfiguration;
using AdminConfigurationInterface = org.allbinary.business.user.modules.admin.configuration.AdminConfigurationInterface;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;

namespace admin.taghelpers;

public class AdminConfigurationRequestHelper : ModifyTable
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private HttpServletRequest request;
    public AdminConfigurationRequestHelper(HashMap<object, object> hashMap, PageContext pageContext)
    {
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGS)) {
            this.logUtil.putF(this.commonStrings.CONSTRUCTOR, this, this.commonStrings.CONSTRUCTOR);
        }
        this.request = ((HttpServletRequest) pageContext.getRequest());
    }

    public virtual string insert()
    {
        try {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGS)) {
                this.logUtil.putF(this.commonStrings.START, this, "insert()");
            }
            string success = "Successfully inserted AdminConfiguration";
            AdminConfigurationInterface adminConfigurationInterface = ((AdminConfigurationInterface) new AdminConfiguration(this.request));
            adminConfigurationInterface.write();
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGS)) {
                this.logUtil.putF(success, this, "insert()");
            }
            return success;
        } catch (Exception e) {
            string error = "Failed to created AdminConfiguration";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "insert()", e);
            }
            return error;
        }
    }

    public virtual string delete()
    {
        try {
            string success = "Successfully deleted AdminConfiguration";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGS)) {
                this.logUtil.putF(success, this, "delete()");
            }
            return success;
        } catch (Exception e) {
            string error = "Failed to delete";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "delete()", e);
            }
            return error;
        }
    }

    public virtual string update()
    {
        try {
            string success = "Updated AdminConfiguration Successful";
            AdminConfigurationInterface adminConfigurationInterface = ((AdminConfigurationInterface) new AdminConfiguration(this.request));
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGS)) {
                this.logUtil.putF(success, this, "update()");
            }
            return success;
        } catch (Exception e) {
            string error = "Failed to update";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "update()", e);
            }
            return error;
        }
    }

}

