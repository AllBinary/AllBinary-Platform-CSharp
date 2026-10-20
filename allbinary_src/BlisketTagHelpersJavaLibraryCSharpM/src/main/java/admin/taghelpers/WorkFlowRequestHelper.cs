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
using WorkFlowEntityFactory = org.allbinary.data.tables.workflow.WorkFlowEntityFactory;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using NewWorkFlowFactory = org.allbinary.logic.control.workflow.NewWorkFlowFactory;
using WorkFlowData = org.allbinary.logic.control.workflow.WorkFlowData;
using WorkFlowInterface = org.allbinary.logic.control.workflow.WorkFlowInterface;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using AbeClientInformationInterface = org.allbinary.logic.system.security.licensing.AbeClientInformationInterface;
using ServiceClientInformationInterfaceFactory = org.allbinary.logic.system.security.licensing.ServiceClientInformationInterfaceFactory;

namespace admin.taghelpers;

public class WorkFlowRequestHelper : ModifyTable
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly AbeClientInformationInterface abeClientInformation = ServiceClientInformationInterfaceFactory.getInstance();
    private WorkFlowInterface workFlowInterface;
    public WorkFlowRequestHelper(HashMap<object, object> hashMap, PageContext pageContext)
    {
        this.workFlowInterface = NewWorkFlowFactory.getInstance().getInstance(this.abeClientInformation, hashMap, pageContext);
    }

    // throws Exception
    public virtual string delete()
    {
        try {
            StringUtil stringUtil = StringUtil.getInstance();
            WorkFlowEntityFactory.getInstance().create2().delete(this.workFlowInterface.getName(), stringUtil.EMPTY_STRING);
            string success = "Successfully Removed the workflow with " + WorkFlowData.getInstance().NAME + "= " + this.workFlowInterface.getName() + " from ";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGS)) {
                this.logUtil.putF(success, this, "delete()");
            }
            return success;
        } catch (Exception e) {
            try {
                string error = "Failed to remove workflow with " + WorkFlowData.getInstance().NAME + "= " + this.workFlowInterface.getName() + " from ";
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                    this.logUtil.put(this.commonStrings.EXCEPTION, this, "delete()", e);
                }
                throw new Exception(e);
            } catch (Exception e2) {
                string error = "Failed to get data from workflowinterface to set error string";
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                    this.logUtil.put(this.commonStrings.EXCEPTION, this, "delete()", e2);
                }
                return error;
            }
        }
    }

    public virtual string insert()
    {
        try {
            string success = "New User Successfully added to the Users Table";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGS)) {
                this.logUtil.putF(success, this, "add()");
            }
            return success;
        } catch (Exception e) {
            string error = "Failed to add User";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "add()", e);
            }
            return error;
        }
    }

    public virtual string update()
    {
        try {
            string success = "Updated WorkFlow Successfully";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGS)) {
                this.logUtil.putF(success, this, "update()");
            }
            return success;
        } catch (Exception e) {
            string error = "Failed to update WorkFlow";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "update()", e);
            }
            return error;
        }
    }

}

