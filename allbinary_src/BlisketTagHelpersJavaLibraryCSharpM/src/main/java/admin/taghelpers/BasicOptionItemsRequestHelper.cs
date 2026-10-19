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
using BasicOptionItemData = org.allbinary.business.user.commerce.inventory.item.option.BasicOptionItemData;
using BasicOptionItemsEntityFactory = org.allbinary.data.tables.user.commerce.inventory.item.options.BasicOptionItemsEntityFactory;
using StdUtil = org.allbinary.logic.StdUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using CommonSeps = org.allbinary.@string.CommonSeps;

namespace admin.taghelpers;

public class BasicOptionItemsRequestHelper : ModifyTable
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly BasicItemData basicItemData = BasicItemData.getInstance();
    private HttpServletRequest request;
    private string id = null;
    private string optionOneTitle = null;
    private string defaultOptionItem = null;
    private string defaultOptionValue = null;
    private BasicArrayList optionItem = null;
    private BasicArrayList optionValue = null;
    private string timeEntered = null;
    private string lastModified = null;
    public BasicOptionItemsRequestHelper(HashMap hashMap, PageContext pageContext)
    {
        this.request = ((HttpServletRequest) pageContext.getRequest());
        this.getFormData();
    }

    public virtual void getFormData()
    {
        this.optionItem = new BasicArrayListD();
        this.optionValue = new BasicArrayListD();
        this.id = this.request.getParameter(basicItemData.ID);
        this.optionOneTitle = this.request.getParameter(BasicOptionItemData.OPTION_ONE_TITLE);
        this.defaultOptionItem = this.request.getParameter(BasicOptionItemData.DEFAULT_OPTION_ITEM);
        this.defaultOptionValue = this.request.getParameter(BasicOptionItemData.DEFAULT_OPTION_VALUE);
        this.optionItem.add(this.request.getParameter(BasicOptionItemData.OPTION_ONE_ONE_ITEM));
        this.optionValue.add(this.request.getParameter(BasicOptionItemData.OPTION_ONE_ONE_VALUE));
        this.optionItem.add(this.request.getParameter(BasicOptionItemData.OPTION_ONE_TWO_ITEM));
        this.optionValue.add(this.request.getParameter(BasicOptionItemData.OPTION_ONE_TWO_VALUE));
        this.optionItem.add(this.request.getParameter(BasicOptionItemData.OPTION_ONE_THREE_ITEM));
        this.optionValue.add(this.request.getParameter(BasicOptionItemData.OPTION_ONE_THREE_VALUE));
        this.optionItem.add(this.request.getParameter(BasicOptionItemData.OPTION_ONE_FOUR_ITEM));
        this.optionValue.add(this.request.getParameter(BasicOptionItemData.OPTION_ONE_FOUR_VALUE));
        this.optionItem.add(this.request.getParameter(BasicOptionItemData.OPTION_ONE_FIVE_ITEM));
        this.optionValue.add(this.request.getParameter(BasicOptionItemData.OPTION_ONE_FIVE_VALUE));
        this.optionItem.add(this.request.getParameter(BasicOptionItemData.OPTION_ONE_SIX_ITEM));
        this.optionValue.add(this.request.getParameter(BasicOptionItemData.OPTION_ONE_SIX_VALUE));
        this.optionItem.add(this.request.getParameter(BasicOptionItemData.OPTION_ONE_SEVEN_ITEM));
        this.optionValue.add(this.request.getParameter(BasicOptionItemData.OPTION_ONE_SEVEN_VALUE));
        this.optionItem.add(this.request.getParameter(BasicOptionItemData.OPTION_ONE_EIGHT_ITEM));
        this.optionValue.add(this.request.getParameter(BasicOptionItemData.OPTION_ONE_EIGHT_VALUE));
        this.optionItem.add(this.request.getParameter(BasicOptionItemData.OPTION_ONE_NINE_ITEM));
        this.optionValue.add(this.request.getParameter(BasicOptionItemData.OPTION_ONE_NINE_VALUE));
        this.timeEntered = this.request.getParameter(EntryData.getInstance().TIMECREATED);
        this.lastModified = this.request.getParameter(EntryData.getInstance().LASTMODIFIED);
    }

    private HashMap getHashMap()
    {
        HashMap values = StdUtil.getInstance().createHashMap();
        values.put(basicItemData.ID, id);
        values.put(BasicOptionItemData.OPTION_ONE_ONE_ITEM, this.optionItem.get(0));
        values.put(BasicOptionItemData.OPTION_ONE_ONE_VALUE, this.optionValue.get(0));
        values.put(BasicOptionItemData.OPTION_ONE_TWO_ITEM, this.optionItem.get(1));
        values.put(BasicOptionItemData.OPTION_ONE_TWO_VALUE, this.optionValue.get(1));
        values.put(BasicOptionItemData.OPTION_ONE_THREE_ITEM, this.optionItem.get(2));
        values.put(BasicOptionItemData.OPTION_ONE_THREE_VALUE, this.optionValue.get(2));
        values.put(BasicOptionItemData.OPTION_ONE_FOUR_ITEM, this.optionItem.get(3));
        values.put(BasicOptionItemData.OPTION_ONE_FOUR_VALUE, this.optionValue.get(3));
        values.put(BasicOptionItemData.OPTION_ONE_FIVE_ITEM, this.optionItem.get(4));
        values.put(BasicOptionItemData.OPTION_ONE_FIVE_VALUE, this.optionValue.get(4));
        values.put(BasicOptionItemData.OPTION_ONE_SIX_ITEM, this.optionItem.get(5));
        values.put(BasicOptionItemData.OPTION_ONE_SIX_VALUE, this.optionValue.get(5));
        values.put(BasicOptionItemData.OPTION_ONE_SEVEN_ITEM, this.optionItem.get(6));
        values.put(BasicOptionItemData.OPTION_ONE_SEVEN_VALUE, this.optionValue.get(6));
        values.put(BasicOptionItemData.OPTION_ONE_EIGHT_ITEM, this.optionItem.get(7));
        values.put(BasicOptionItemData.OPTION_ONE_EIGHT_VALUE, this.optionValue.get(7));
        values.put(BasicOptionItemData.OPTION_ONE_NINE_ITEM, this.optionItem.get(8));
        values.put(BasicOptionItemData.OPTION_ONE_NINE_VALUE, this.optionValue.get(8));
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
            int size = this.optionValue.size();
            for (int index = 0; index < size; index++) {
                values.add(this.optionValue.get(index));
                values.add(this.optionItem.get(index));
            }
            values.add(time);
            values.add(time);
            BasicOptionItemsEntityFactory.getInstance().getBasicOptionItemsEntityInstance().insert(values);
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
            BasicOptionItemsEntityFactory.getInstance().getBasicOptionItemsEntityInstance().delete(this.id);
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
            BasicOptionItemsEntityFactory.getInstance().getBasicOptionItemsEntityInstance().update(values);
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

