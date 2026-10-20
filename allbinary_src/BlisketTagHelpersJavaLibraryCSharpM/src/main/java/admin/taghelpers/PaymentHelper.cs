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
using PaymentFactory = org.allbinary.business.user.commerce.money.payment.PaymentFactory;
using PaymentInterface = org.allbinary.business.user.commerce.money.payment.PaymentInterface;
using PaymentEntity = org.allbinary.data.tables.user.commerce.money.payment.PaymentEntity;
using PaymentEntityFactory = org.allbinary.data.tables.user.commerce.money.payment.PaymentEntityFactory;
using WeblisketSession = org.allbinary.logic.communication.http.request.session.WeblisketSession;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using AbSqlTableUtil = org.allbinary.logic.communication.sql.AbSqlTableUtil;
using LicensingException = org.allbinary.logic.system.security.licensing.LicensingException;

namespace admin.taghelpers;

public class PaymentHelper : Table
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private WeblisketSession weblisketSession;
    private HttpServletRequest request;
    private string value = null;
    private readonly Portion portion;
    public PaymentHelper(HashMap<object, object> hashMap, PageContext pageContext)
    {
        this.request = ((HttpServletRequest) pageContext.getRequest());
        this.weblisketSession = new WeblisketSession(hashMap, pageContext);
        this.portion = new Portion(hashMap);
        this.getFormData();
    }

    private void getFormData()
    {
        this.value = this.request.getParameter("VALUE");
    }

    public virtual string insert()
    {
        try {
            string success = "Successfully Added Payment";
            PaymentEntity paymentEntity = PaymentEntityFactory.getInstance().getPaymentEntityInstance();
            PaymentInterface paymentInterface = PaymentFactory.getInstance(this.request);
            paymentEntity.add(this.weblisketSession.getUserName(), paymentInterface);
            paymentEntity.setDefault(this.weblisketSession.getUserName(), paymentEntity.getLastId(this.weblisketSession.getUserName()));
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGS)) {
                this.logUtil.putF(success, this, "addPayment()");
            }
            return success;
        } catch (Exception e) {
            string error = "Failed to add Payment";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "addPayment()", e);
            }
            return error;
        }
    }

    public virtual string select()
    {
        try {
            string success = "Successfully Selected Payment";
            PaymentEntity paymentEntity = PaymentEntityFactory.getInstance().getPaymentEntityInstance();
            paymentEntity.setDefault(this.weblisketSession.getUserName(), this.value);
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGS)) {
                this.logUtil.putF(success, this, "selectPayment()");
            }
            return success;
        } catch (Exception e) {
            string error = "Failed to select Payment";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "selectPayment()", e);
            }
            return error;
        }
    }

    public virtual string delete()
    {
        try {
            string success = "Successfully Removed Payment";
            PaymentEntity paymentEntity = PaymentEntityFactory.getInstance().getPaymentEntityInstance();
            paymentEntity.remove(this.weblisketSession.getUserName(), this.value);
            PaymentInterface paymentInterface = paymentEntity.getDefault(this.weblisketSession.getUserName());
            if (paymentInterface == null) {
                paymentEntity.setDefault(this.weblisketSession.getUserName(), paymentEntity.getLastId(this.weblisketSession.getUserName()));
            }
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGS)) {
                this.logUtil.putF(success, this, "removePayment()");
            }
            return success;
        } catch (Exception e) {
            string error = "Failed to remove Payment";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "removePayment()", e);
            }
            return error;
        }
    }

    public virtual string drop()
    {
        try {
            PaymentEntity paymentEntity = PaymentEntityFactory.getInstance().getPaymentEntityInstance();
            string success = paymentEntity.dropTable();
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
            PaymentEntity paymentEntity = PaymentEntityFactory.getInstance().getPaymentEntityInstance();
            string success = paymentEntity.createTable();
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
            string result = AbSqlTableUtil.getInstance().restoreTable(PaymentEntityFactory.getInstance().getPaymentEntityInstance(), portion);
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
            string result = AbSqlTableUtil.getInstance().backupTable(PaymentEntityFactory.getInstance().getPaymentEntityInstance());
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

    // throws LicensingException
    public virtual string update()
    {
        return commonStrings.NOT_IMPLEMENTED;
    }

}

