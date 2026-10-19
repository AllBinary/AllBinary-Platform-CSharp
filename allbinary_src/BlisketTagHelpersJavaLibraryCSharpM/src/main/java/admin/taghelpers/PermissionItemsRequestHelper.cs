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
//using Calendar = java.util.Calendar;
using java.util;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
//using HttpServletRequest = javax.servlet.http.HttpServletRequest;
//using PageContext = javax.servlet.jsp.PageContext;
using EntryData = org.allbinary.business.entry.EntryData;
using BasicItemData = org.allbinary.business.user.commerce.inventory.item.BasicItemData;
using PermissionItemData = org.allbinary.business.user.commerce.inventory.item.permission.PermissionItemData;
using PermissionItemsEntityFactory = org.allbinary.data.tables.user.commerce.inventory.item.permissions.PermissionItemsEntityFactory;
using StdUtil = org.allbinary.logic.StdUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using CommonSeps = org.allbinary.@string.CommonSeps;

namespace admin.taghelpers;

public class PermissionItemsRequestHelper : ModifyTable
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly BasicItemData basicItemData = BasicItemData.getInstance();
    private HttpServletRequest request;
    private string id = null;
    private string enabled = null;
    private string number = null;
    private string who = null;
    private string what = null;
    private string type = null;
    private string remoteAddr = null;
    private string startTime = null;
    private string endTime = null;
    private string price = null;
    private string timeEntered = null;
    private string lastModified = null;
    public PermissionItemsRequestHelper(HashMap hashMap, PageContext pageContext)
    {
        this.request = ((HttpServletRequest) pageContext.getRequest());
        this.getFormData();
    }

    public virtual void getFormData()
    {
        this.id = this.request.getParameter(basicItemData.ID);
        this.number = this.request.getParameter(basicItemData.NUMBER);
        this.enabled = this.request.getParameter(EntryData.getInstance().ENABLE);
        this.who = this.request.getParameter(PermissionItemData.WHO);
        this.what = this.request.getParameter(PermissionItemData.WHAT);
        this.type = this.request.getParameter(PermissionItemData.TYPE);
        this.remoteAddr = this.request.getParameter(PermissionItemData.REMOTE_ADDR);
        this.startTime = this.request.getParameter(PermissionItemData.START_TIME);
        this.endTime = this.request.getParameter(PermissionItemData.END_TIME);
        this.price = this.request.getParameter(basicItemData.PRICE);
        this.timeEntered = this.request.getParameter(EntryData.getInstance().TIMECREATED);
        this.lastModified = this.request.getParameter(EntryData.getInstance().LASTMODIFIED);
    }

    private HashMap getHashMap()
    {
        HashMap values = StdUtil.getInstance().createHashMap();
        values.put(basicItemData.ID, this.id);
        values.put(basicItemData.NUMBER, this.number);
        values.put(EntryData.getInstance().ENABLE, this.enabled);
        values.put(PermissionItemData.WHO, this.who);
        values.put(PermissionItemData.WHAT, this.what);
        values.put(PermissionItemData.TYPE, this.type);
        values.put(PermissionItemData.REMOTE_ADDR, this.remoteAddr);
        values.put(PermissionItemData.START_TIME, this.startTime);
        values.put(PermissionItemData.END_TIME, this.endTime);
        values.put(basicItemData.PRICE, this.price);
        Calendar calendar = Calendar.getInstance();
        string time = new string((calendar.getTimeInMillis().ToString()).ToCharArray());
        values.put(EntryData.getInstance().LASTMODIFIED, time);
        return values;
    }

    public virtual string insert()
    {
        try {
            Calendar calendar = Calendar.getInstance();
            string time = new string((calendar.getTimeInMillis().ToString()).ToCharArray());
            BasicArrayList values = new BasicArrayListD();
            values.add(this.id);
            values.add(this.number);
            values.add(this.enabled);
            values.add(this.who);
            values.add(this.what);
            values.add(this.type);
            values.add(this.remoteAddr);
            values.add(this.startTime);
            values.add(this.endTime);
            values.add(this.price);
            values.add(time);
            values.add(time);
            PermissionItemsEntityFactory.getInstance().getPermissionItemsEntityInstance().insert(values);
            string success = "Successfully inserted " + this.id + " into items table";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGS)) {
                this.logUtil.putF(success, this, "insert()");
            }
            return success;
        } catch (Exception e) {
            string error = "Failed to insert " + this.id + " into items table";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "inserts()", e);
            }
            return error;
        }
    }

    public virtual string delete()
    {
        try {
            PermissionItemsEntityFactory.getInstance().getPermissionItemsEntityInstance().delete(this.id);
            string success = "Successfully deleted";
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
            string success = "Update Pricing Successful";
            HashMap values = this.getHashMap();
            PermissionItemsEntityFactory.getInstance().getPermissionItemsEntityInstance().update(values);
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGS)) {
                this.logUtil.putF(new StringMaker().append(this.id).append(CommonSeps.getInstance().SPACE).append(success).ToString(), this, "update()");
            }
            return success;
        } catch (Exception e) {
            string error = "Failed to update: " + this.id;
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "update()", e);
            }
            return error;
        }
    }

}

