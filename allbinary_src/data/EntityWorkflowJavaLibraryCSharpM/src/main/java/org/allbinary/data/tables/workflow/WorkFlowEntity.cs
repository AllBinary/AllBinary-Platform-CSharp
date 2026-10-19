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
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using DynamicObjectData = org.allbinary.business.DynamicObjectData;
using StoreFrontData = org.allbinary.business.context.modules.storefront.StoreFrontData;
using EntryData = org.allbinary.business.entry.EntryData;
using UserDbInitInfo = org.allbinary.business.init.db.UserDbInitInfo;
using StdUtil = org.allbinary.logic.StdUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using AbSqlBean = org.allbinary.logic.communication.sql.AbSqlBean;
using DbWorkFlowFactory = org.allbinary.logic.control.workflow.DbWorkFlowFactory;
using WorkFlowData = org.allbinary.logic.control.workflow.WorkFlowData;
using WorkFlowInterface = org.allbinary.logic.control.workflow.WorkFlowInterface;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using AbeClientInformationInterface = org.allbinary.logic.system.security.licensing.AbeClientInformationInterface;
using LicensingException = org.allbinary.logic.system.security.licensing.LicensingException;
using ServiceClientInformationInterfaceFactory = org.allbinary.logic.system.security.licensing.ServiceClientInformationInterfaceFactory;

namespace org.allbinary.data.tables.workflow;

public class WorkFlowEntity : AbSqlBean, WorkFlowEntityInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly AbeClientInformationInterface abeClientInformation = ServiceClientInformationInterfaceFactory.getInstance();
    public readonly string tableName = "workflows";
    private readonly string METHOD_GET = "get()";
    private readonly string METHOD_UPDATE = "update";
    public WorkFlowEntity() : base(new UserDbInitInfo())
    {
        // base(new UserDbInitInfo()) is called from the constructor declaration
        this.setTableName(this.tableName);
    }

    public virtual void insert(BasicArrayList values)
    {
        try {
            base.insert(values);
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                this.logUtil.putF(this.commonStrings.SUCCESS, this, INSERT);
            }
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                this.logUtil.put(this.commonStrings.FAILURE, this, INSERT, e);
            }
        }
    }

    public virtual void delete(string name, string storeName)
    {
        try {
            HashMap keysAndValues = StdUtil.getInstance().createHashMap();
            keysAndValues.put(WorkFlowData.getInstance().NAME, name);
            keysAndValues.put(StoreFrontData.getInstance().NAME, storeName);
            base.deleteWhere(keysAndValues);
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                this.logUtil.putF(this.commonStrings.SUCCESS, this, this.commonStrings.delete);
            }
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                this.logUtil.put(this.commonStrings.FAILURE, this, this.commonStrings.delete, e);
            }
        }
    }

    // throws Exception, LicensingException
    public virtual WorkFlowInterface get(string name, string storeName)
    {
        try {
            HashMap keysAndValues = StdUtil.getInstance().createHashMap();
            keysAndValues.put(WorkFlowData.getInstance().NAME, name);
            keysAndValues.put(StoreFrontData.getInstance().NAME, storeName);
            HashMap hashMap = base.getRow(keysAndValues);
            return ((WorkFlowInterface) DbWorkFlowFactory.getInstance().getInstance(this.abeClientInformation, hashMap));
        } catch (LicensingException e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                this.logUtil.put(this.commonStrings.FAILURE, this, METHOD_GET, e);
            }
            throw e;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                this.logUtil.put(this.commonStrings.FAILURE, this, METHOD_GET, e);
            }
            throw e;
        }
    }

    public virtual BasicArrayList get(string storeName)
    {
        try {
            BasicArrayList workFlowsVector = new BasicArrayListD();
            HashMap keysAndValues = StdUtil.getInstance().createHashMap();
            keysAndValues.put(StoreFrontData.getInstance().NAME, storeName);
            BasicArrayList hashMapVector = base.getRows(keysAndValues);
            int size = hashMapVector.size();
            for (int i = 0; i < size; i++) {
                HashMap workFlowHashMap = ((HashMap) hashMapVector.get(i));
                if (workFlowHashMap != null) {
                    workFlowsVector.add(DbWorkFlowFactory.getInstance().getInstance(abeClientInformation, workFlowHashMap));
                }
            }
            return workFlowsVector;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                this.logUtil.put(this.commonStrings.FAILURE, this, this.METHOD_GET, e);
            }
            return null;
        }
    }

    public virtual void update(HashMap updatedValues)
    {
        try {
            HashMap wherekeysAndValues = StdUtil.getInstance().createHashMap();
            wherekeysAndValues.put(WorkFlowData.getInstance().NAME, ((string) updatedValues.get(WorkFlowData.getInstance().NAME)));
            wherekeysAndValues.put(StoreFrontData.getInstance().NAME, ((string) updatedValues.get(StoreFrontData.getInstance().NAME)));
            base.updateWhere(wherekeysAndValues, updatedValues);
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                this.logUtil.put(this.commonStrings.FAILURE, this, METHOD_UPDATE, e);
            }
        }
    }

    public string createTableStatement()
    {
        WorkFlowData workFlowData = WorkFlowData.getInstance();
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(this.sqlStrings.CREATE_TABLE).append(tableName).append(this.sqlStrings.START).append(workFlowData.NAME).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(StoreFrontData.getInstance().NAME).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(DynamicObjectData.NAME).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(workFlowData.DATA).append(this.sqlTypeStrings.BLOB_NOT_NULL).append(EntryData.getInstance().TIMECREATED).append(this.sqlTypeStrings.MAX_BIG_INT_UNSIGNED_NOT_NULL).append(EntryData.getInstance().LASTMODIFIED).append(this.sqlTypeStrings.MAX_BIG_INT_UNSIGNED_NOT_NULL).append(this.sqlStrings.PRIMARY_KEY).append(workFlowData.NAME).append(this.sqlStrings.END);
        return stringBuffer.ToString();
    }

    public virtual string createTable()
    {
        return base.createTable(this.createTableStatement());
    }

    public virtual string dropTable()
    {
        return base.dropTable();
    }

}

