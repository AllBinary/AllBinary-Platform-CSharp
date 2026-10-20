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
using Calendar = java.util.Calendar;
using java.util;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
//using HttpServletRequest = javax.servlet.http.HttpServletRequest;
//using PageContext = javax.servlet.jsp.PageContext;
using EntryData = org.allbinary.business.entry.EntryData;
using BasicItemData = org.allbinary.business.user.commerce.inventory.item.BasicItemData;
using BasicGroupItemData = org.allbinary.business.user.commerce.inventory.item.group.BasicGroupItemData;
using BasicGroupItemsEntityFactory = org.allbinary.data.tables.user.commerce.inventory.item.groups.BasicGroupItemsEntityFactory;
using StdUtil = org.allbinary.logic.StdUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using CommonSeps = org.allbinary.@string.CommonSeps;

namespace admin.taghelpers;

public class BasicGroupItemsRequestHelper : ModifyTable
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly BasicItemData basicItemData = BasicItemData.getInstance();
    private HttpServletRequest request;
    private string id = null;
    private string itemOne = null;
    private string itemTwo = null;
    private string itemThree = null;
    private string itemFour = null;
    private string itemFive = null;
    private string itemSix = null;
    private string itemSeven = null;
    private string itemEight = null;
    private string itemNine = null;
    private string itemTen = null;
    private string timeEntered = null;
    private string lastModified = null;
    public BasicGroupItemsRequestHelper(HashMap hashMap, PageContext pageContext)
    {
        this.request = ((HttpServletRequest) pageContext.getRequest());
        this.getFormData();
    }

    public virtual void getFormData()
    {
        this.id = this.request.getParameter(basicItemData.ID);
        this.itemOne = this.request.getParameter(BasicGroupItemData.ITEM_ONE);
        this.itemTwo = this.request.getParameter(BasicGroupItemData.ITEM_TWO);
        this.itemThree = this.request.getParameter(BasicGroupItemData.ITEM_THREE);
        this.itemFour = this.request.getParameter(BasicGroupItemData.ITEM_FOUR);
        this.itemFive = this.request.getParameter(BasicGroupItemData.ITEM_FIVE);
        this.itemSix = this.request.getParameter(BasicGroupItemData.ITEM_SIX);
        this.itemSeven = this.request.getParameter(BasicGroupItemData.ITEM_SEVEN);
        this.itemEight = this.request.getParameter(BasicGroupItemData.ITEM_EIGHT);
        this.itemNine = this.request.getParameter(BasicGroupItemData.ITEM_NINE);
        this.itemTen = this.request.getParameter(BasicGroupItemData.ITEM_TEN);
        this.timeEntered = this.request.getParameter(EntryData.getInstance().TIMECREATED);
        this.lastModified = this.request.getParameter(EntryData.getInstance().LASTMODIFIED);
    }

    private HashMap getHashMap()
    {
        HashMap values = StdUtil.getInstance().createHashMap();
        values.put(basicItemData.ID, id);
        values.put(BasicGroupItemData.ITEM_ONE, this.itemOne);
        values.put(BasicGroupItemData.ITEM_TWO, this.itemTwo);
        values.put(BasicGroupItemData.ITEM_THREE, this.itemThree);
        values.put(BasicGroupItemData.ITEM_FOUR, this.itemFour);
        values.put(BasicGroupItemData.ITEM_FIVE, this.itemFive);
        values.put(BasicGroupItemData.ITEM_SIX, this.itemSix);
        values.put(BasicGroupItemData.ITEM_SEVEN, this.itemSeven);
        values.put(BasicGroupItemData.ITEM_EIGHT, this.itemEight);
        values.put(BasicGroupItemData.ITEM_NINE, this.itemNine);
        values.put(BasicGroupItemData.ITEM_TEN, this.itemTen);
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
            values.add(this.itemOne);
            values.add(this.itemTwo);
            values.add(this.itemThree);
            values.add(this.itemFour);
            values.add(this.itemFive);
            values.add(this.itemSix);
            values.add(this.itemSeven);
            values.add(this.itemEight);
            values.add(this.itemNine);
            values.add(this.itemTen);
            values.add(time);
            values.add(time);
            BasicGroupItemsEntityFactory.getInstance().getBasicGroupItemsEntityInstance().insert(values);
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
            BasicGroupItemsEntityFactory.getInstance().getBasicGroupItemsEntityInstance().delete(this.id);
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
            BasicGroupItemsEntityFactory.getInstance().getBasicGroupItemsEntityInstance().update(values);
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

