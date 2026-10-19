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
using Portion = org.allbinary.business.installer.Portion;
using UserData = org.allbinary.business.user.UserData;
using StreetAddress = org.allbinary.business.user.address.StreetAddress;
using BillingAddressesEntityFactory = org.allbinary.data.tables.user.address.billing.BillingAddressesEntityFactory;
using ShippingAddressesEntity = org.allbinary.data.tables.user.address.shipping.ShippingAddressesEntity;
using ShippingAddressesEntityFactory = org.allbinary.data.tables.user.address.shipping.ShippingAddressesEntityFactory;
using WeblisketSession = org.allbinary.logic.communication.http.request.session.WeblisketSession;
using WeblisketSessionData = org.allbinary.logic.communication.http.request.session.WeblisketSessionData;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using AbSqlTableUtil = org.allbinary.logic.communication.sql.AbSqlTableUtil;
using StringUtil = org.allbinary.logic.@string.StringUtil;

namespace admin.taghelpers;

public class ShippingAddressHelper : BasicTable
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly StringUtil stringUtil = StringUtil.getInstance();
    private WeblisketSession weblisketSession;
    private HttpServletRequest request;
    private string userName = null;
    private StreetAddress streetAddress = null;
    private readonly Portion portion;
    public ShippingAddressHelper(HashMap hashMap, PageContext pageContext)
    {
        this.request = ((HttpServletRequest) pageContext.getRequest());
        this.weblisketSession = new WeblisketSession(hashMap, pageContext);
        this.portion = new Portion(hashMap);
        this.getAddressForm();
    }

    private void getAddressForm()
    {
        this.userName = this.request.getParameter(UserData.USERNAME);
        if (this.userName == null) {
            this.userName = this.request.getParameter(WeblisketSessionData.REMOVABLEUSERNAME);
        }
        this.streetAddress = new StreetAddress(this.request);
    }

    public virtual string drop()
    {
        try {
            string success = new ShippingAddressesEntity(this.stringUtil.EMPTY_STRING).drop();
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGS)) {
                this.logUtil.putF(success, this, this.commonStrings.DROP);
            }
            return success;
        } catch (Exception e) {
            string error = "Failed to drop Admin table";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.DROP, e);
            }
            return error;
        }
    }

    public virtual string create()
    {
        try {
            string success = new ShippingAddressesEntity(this.stringUtil.EMPTY_STRING).createTable();
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGS)) {
                this.logUtil.putF(success, this, "create()");
            }
            return success;
        } catch (Exception e) {
            string error = "Failed to create user table";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "create()", e);
            }
            return error;
        }
    }

    public virtual string restore()
    {
        try {
            string success = "Restore Successful";
            string result = AbSqlTableUtil.getInstance().restoreTable(new ShippingAddressesEntity(StringUtil.getInstance().EMPTY_STRING), portion);
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGS)) {
                this.logUtil.putF(success, this, "restore()");
            }
            return result;
        } catch (Exception e) {
            string error = "Failed to restore backup";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "restore()", e);
            }
            return error;
        }
    }

    public virtual string backup()
    {
        try {
            string success = "Backup Successful";
            string result = AbSqlTableUtil.getInstance().backupTable(new ShippingAddressesEntity(StringUtil.getInstance().EMPTY_STRING));
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGS)) {
                this.logUtil.putF(success, this, "backup()");
            }
            return result;
        } catch (Exception e) {
            string error = "Failed to make backup";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "backup()", e);
            }
            return error;
        }
    }

    public virtual string insert()
    {
        try {
            string success = "Successfully Added Shipping Address";
            ShippingAddressesEntityFactory.getInstance().getInstance(this.weblisketSession.getUserName()).add(this.streetAddress);
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGS)) {
                this.logUtil.putF(success, this, "insert");
            }
            return success;
        } catch (Exception e) {
            string error = "Failed to add Shipping streetAddress";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "insert", e);
            }
            return error;
        }
    }

    public virtual string update()
    {
        try {
            string success = "Successfully Updated Shipping Address";
            ShippingAddressesEntityFactory.getInstance().getInstance(this.weblisketSession.getUserName()).update(this.streetAddress);
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGS)) {
                this.logUtil.putF("Successfull update of a Users Shipping Address table", this, "update()");
            }
            return success;
        } catch (Exception e) {
            string error = "Failed update of a Users Shipping Address Table";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "update", e);
            }
            return error;
        }
    }

    private string setToBillingAddress()
    {
        try {
            StreetAddress streetAddress = BillingAddressesEntityFactory.getInstance().getInstance(this.weblisketSession.getUserName()).getDefault();
            if (streetAddress != null) {
                ShippingAddressesEntityFactory.getInstance().getInstance(this.weblisketSession.getUserName()).add(streetAddress);
            } else {
                return "No Billing Address";
            }
            return StringUtil.getInstance().EMPTY_STRING;
        } catch (Exception e) {
            string error = "Failed Setting Shipping address to Billing Address";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "setToBillingAddress()", e);
            }
            return error;
        }
    }

    public virtual string delete()
    {
        try {
            string success = "Successfully Removed Shipping Address";
            ShippingAddressesEntityFactory.getInstance().getInstance(this.weblisketSession.getUserName()).remove(this.streetAddress.getId());
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGS)) {
                this.logUtil.putF(success, this, "remove()");
            }
            return success;
        } catch (Exception e) {
            string error = "Failed to remove Shipping Address";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "remove()", e);
            }
            return error;
        }
    }

    public virtual string set()
    {
        try {
            string success = "Successfully Set Shipping Address";
            ShippingAddressesEntityFactory.getInstance().getInstance(this.weblisketSession.getUserName()).setDefault(this.streetAddress.getId());
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGS)) {
                this.logUtil.putF(success, this, "set()");
            }
            return success;
        } catch (Exception e) {
            string error = "Failed to set Shipping Address";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "set()", e);
            }
            return error;
        }
    }

}

