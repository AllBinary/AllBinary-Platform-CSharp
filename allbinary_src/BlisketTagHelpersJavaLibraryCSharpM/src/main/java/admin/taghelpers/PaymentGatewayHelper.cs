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
using PaymentGatewayInterface = org.allbinary.business.user.commerce.money.payment.gateway.PaymentGatewayInterface;
using PaymentGatewayInterfaceFactory = org.allbinary.business.user.commerce.money.payment.gateway.PaymentGatewayInterfaceFactory;
using BasicPaymentTypeUtil = org.allbinary.business.user.commerce.money.payment.types.BasicPaymentTypeUtil;
using PaymentGatewayEntityFactory = org.allbinary.data.tables.user.commerce.money.payment.gateway.PaymentGatewayEntityFactory;
using WeblisketSession = org.allbinary.logic.communication.http.request.session.WeblisketSession;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using AbSqlTableUtil = org.allbinary.logic.communication.sql.AbSqlTableUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;

namespace admin.taghelpers;

public class PaymentGatewayHelper : BasicTable
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private WeblisketSession weblisketSession = null;
    private readonly HttpServletRequest httpServletRequest = null;
    private readonly Portion portion = null;
    public PaymentGatewayHelper(HashMap<object, object> hashMap, PageContext pageContext)
    {
        try {
            this.weblisketSession = new WeblisketSession(hashMap, pageContext);
            this.httpServletRequest = ((HttpServletRequest) pageContext.getRequest());
            this.portion = new Portion(hashMap);
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().PAYMENTERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.CONSTRUCTOR, e);
            }
            throw e;
        }
    }

    public virtual string insert()
    {
        try {
            PaymentGatewayInterface paymentGatewayInterface = new PaymentGatewayInterfaceFactory().getInstance(this.httpServletRequest);
            paymentGatewayInterface.setStoreName(this.weblisketSession.getStoreName());
            PaymentGatewayEntityFactory.getInstance().add(paymentGatewayInterface);
            string success = "Successfully Added New Payment Gateway";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGS)) {
                this.logUtil.putF(success, this, "insert()");
            }
            return success + "<br/>";
        } catch (Exception e) {
            string error = "Failed to add";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "add()", e);
            }
            return error + "<br>" + "Exception: " + e + "<br>";
        }
    }

    public virtual string update()
    {
        try {
            PaymentGatewayInterface paymentGatewayInterface = new PaymentGatewayInterfaceFactory().getInstance(this.httpServletRequest);
            paymentGatewayInterface.setStoreName(this.weblisketSession.getStoreName());
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGS)) {
                StringMaker stringBuffer = new StringMaker();
                stringBuffer.append("Gateway Name: ");
                stringBuffer.append(paymentGatewayInterface.getName());
                stringBuffer.append(" HashMap=");
                stringBuffer.append(paymentGatewayInterface.toHashMap(true).ToString());
                this.logUtil.putF(stringBuffer.ToString(), this, "update()");
            }
            PaymentGatewayEntityFactory.getInstance().update(paymentGatewayInterface);
            string success = "Successfully Updated Payment Gateway information";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGS)) {
                this.logUtil.putF(success, this, "update()");
            }
            return success + "<br/>";
        } catch (Exception e) {
            string error = "Failed to update payment gateway information";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "update()", e);
            }
            return error + "<br/>" + "Exception: " + e + "<br/>";
        }
    }

    public virtual string delete()
    {
        try {
            PaymentGatewayInterface paymentGatewayInterface = new PaymentGatewayInterfaceFactory().getInstance(this.httpServletRequest);
            paymentGatewayInterface.setStoreName(this.weblisketSession.getStoreName());
            string storeName = paymentGatewayInterface.getStoreName();
            string gatewayName = paymentGatewayInterface.getName();
            PaymentGatewayEntityFactory.getInstance().remove(storeName, BasicPaymentTypeUtil.getInstance().get(gatewayName));
            StringMaker stringBuffer = new StringMaker();
            stringBuffer.append("Successfully Removed payment gateway where store name=");
            stringBuffer.append(storeName);
            stringBuffer.append(" and gateway name=");
            stringBuffer.append(gatewayName);
            string success = stringBuffer.ToString();
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGS)) {
                this.logUtil.putF(success, this, "delete()");
            }
            return success + "<br/>";
        } catch (Exception e) {
            string error = "Failed to remove payment gateway from table";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "remove()", e);
            }
            return error + "<br/>" + "Exception: " + e + "<br>";
        }
    }

    public virtual string drop()
    {
        try {
            string success = PaymentGatewayEntityFactory.getInstance().dropTable();
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGS)) {
                this.logUtil.putF(success, this, this.commonStrings.DROP);
            }
            return success;
        } catch (Exception e) {
            string error = "Failed to drop payment transaction result table";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.DROP, e);
            }
            return error;
        }
    }

    public virtual string create()
    {
        try {
            string success = PaymentGatewayEntityFactory.getInstance().createTable();
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGS)) {
                this.logUtil.putF(success, this, "create()");
            }
            return success;
        } catch (Exception e) {
            string error = "Failed to create payment transaction result table";
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
            string result = AbSqlTableUtil.getInstance().restoreTable(PaymentGatewayEntityFactory.getInstance(), this.portion);
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
            string success = "Restore Successful";
            string result = AbSqlTableUtil.getInstance().backupTable(PaymentGatewayEntityFactory.getInstance());
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

}

