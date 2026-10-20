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
//using PageContext = javax.servlet.jsp.PageContext;
using StoreFrontData = org.allbinary.business.context.modules.storefront.StoreFrontData;
using Portion = org.allbinary.business.installer.Portion;
using StoreFrontsEntityFactory = org.allbinary.data.tables.context.module.storefronts.StoreFrontsEntityFactory;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using AbSqlTableUtil = org.allbinary.logic.communication.sql.AbSqlTableUtil;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using HtmlSelect = org.allbinary.logic.visual.dhtml.html.select.HtmlSelect;
using CommonPhoneStrings = org.allbinary.@string.CommonPhoneStrings;
using CommonSeps = org.allbinary.@string.CommonSeps;

namespace admin.taghelpers;

public class StoreFrontsHelper : BasicTable
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly Portion portion;
    public StoreFrontsHelper(HashMap<object, object> hashMap, PageContext pageContext)
    {
        this.portion = new Portion(hashMap);
    }

    public virtual string drop()
    {
        try {
            string success = StoreFrontsEntityFactory.getInstance().getStoreFrontsEntityInstance().dropTable();
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGS)) {
                this.logUtil.putF(success, this, this.commonStrings.DROP);
            }
            return success;
        } catch (Exception e) {
            string error = "Failed to drop storefronts table";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.DROP, e);
            }
            return error;
        }
    }

    public virtual string create()
    {
        try {
            string success = StoreFrontsEntityFactory.getInstance().getStoreFrontsEntityInstance().createTable();
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGS)) {
                this.logUtil.putF(success, this, "create()");
            }
            return success;
        } catch (Exception e) {
            string error = "Failed to create new storefronts table";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(commonStrings.EXCEPTION, this, "create()", e);
            }
            return error;
        }
    }

    public virtual string restore()
    {
        try {
            string success = "Restore Successful";
            string result = AbSqlTableUtil.getInstance().restoreTable(StoreFrontsEntityFactory.getInstance().getStoreFrontsEntityInstance(), this.portion);
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGS)) {
                this.logUtil.putF(success, this, "restore()");
            }
            return result;
        } catch (Exception e) {
            string error = "Failed to restore backup";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(commonStrings.EXCEPTION, this, "restore()", e);
            }
            return error;
        }
    }

    public virtual string backup()
    {
        try {
            string success = "Restore Successful";
            string result = AbSqlTableUtil.getInstance().backupTable(StoreFrontsEntityFactory.getInstance().getStoreFrontsEntityInstance());
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGS)) {
                this.logUtil.putF(success, this, "backup()");
            }
            return result;
        } catch (Exception e) {
            string error = "Failed to make backup";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(commonStrings.EXCEPTION, this, "backup()", e);
            }
            return error;
        }
    }

    private readonly CommonPhoneStrings commonPhoneStrings = CommonPhoneStrings.getInstance();
    private static readonly string CLASS = "class";
    private static readonly string TEXT = "text";
    public virtual string generateSelect()
    {
        try {
            string success = CommonSeps.getInstance().SPACE;
            BasicArrayList storeNamesVector = StoreFrontsEntityFactory.getInstance().getStoreFrontsEntityInstance().getStoreFrontNames();
            HtmlSelect storeSelect = new HtmlSelect(StringUtil.getInstance().EMPTY_STRING, this.commonPhoneStrings.ONE, StoreFrontData.getInstance().SELECTSTORENAME, StringUtil.getInstance().EMPTY_STRING);
            storeSelect.addAttribute(StoreFrontsHelper.CLASS, StoreFrontsHelper.TEXT);
            int size = storeNamesVector.size();
            for (int index = 0; index < size; index++) {
                string storeName = ((string) storeNamesVector.get(index));
                storeSelect.addOption(storeName);
            }
            success += storeSelect;
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGS)) {
                this.logUtil.putF(success, this, "generateSelect()");
            }
            return success;
        } catch (Exception e) {
            string error = "Failed to generate storefronts select";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(commonStrings.EXCEPTION, this, "generateSelect()", e);
            }
            return error;
        }
    }

}

