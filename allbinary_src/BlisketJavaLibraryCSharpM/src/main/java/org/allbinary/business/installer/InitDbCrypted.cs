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
using InitInfoEntity = org.allbinary.business.init.InitInfoEntity;
using DatabaseConnectionInfoInterface = org.allbinary.business.init.db.DatabaseConnectionInfoInterface;
using DbConnectionInfo = org.allbinary.business.init.db.DbConnectionInfo;
using HistoryDbInitInfo = org.allbinary.business.init.db.HistoryDbInitInfo;
using InventoryDbInitInfo = org.allbinary.business.init.db.InventoryDbInitInfo;
using LogDbInitInfo = org.allbinary.business.init.db.LogDbInitInfo;
using StaticPagesDbInitInfo = org.allbinary.business.init.db.StaticPagesDbInitInfo;
using UserDbInitInfo = org.allbinary.business.init.db.UserDbInitInfo;
using StoreFrontsEntityFactory = org.allbinary.data.tables.context.module.storefronts.StoreFrontsEntityFactory;
using LogTableEntityFactory = org.allbinary.data.tables.log.LogTableEntityFactory;
using StaticPagesEntityFactory = org.allbinary.data.tables.staticpages.StaticPagesEntityFactory;
using TransformInfoEntityBuilder = org.allbinary.data.tables.transform.info.TransformInfoEntityBuilder;
using UserEntityFactory = org.allbinary.data.tables.user.UserEntityFactory;
using BillingAddressesEntityFactory = org.allbinary.data.tables.user.address.billing.BillingAddressesEntityFactory;
using ShippingAddressesEntityFactory = org.allbinary.data.tables.user.address.shipping.ShippingAddressesEntityFactory;
using InventoryEntityFactory = org.allbinary.data.tables.user.commerce.inventory.item.InventoryEntityFactory;
using OrderHistoryEntityFactory = org.allbinary.data.tables.user.commerce.inventory.order.OrderHistoryEntityFactory;
using OrderItemsEntityFactory = org.allbinary.data.tables.user.commerce.inventory.order.OrderItemsEntityFactory;
using PaymentEntityFactory = org.allbinary.data.tables.user.commerce.money.payment.PaymentEntityFactory;
using PaymentGatewayEntityFactory = org.allbinary.data.tables.user.commerce.money.payment.gateway.PaymentGatewayEntityFactory;
using TransactionEntityFactory = org.allbinary.data.tables.user.commerce.money.payment.transaction.TransactionEntityFactory;
using TransactionResultEntityFactory = org.allbinary.data.tables.user.commerce.money.payment.transaction.TransactionResultEntityFactory;
using QuoteRequestEntityFactory = org.allbinary.data.tables.user.quoterequest.QuoteRequestEntityFactory;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using AbDatabaseManagement = org.allbinary.logic.communication.sql.AbDatabaseManagement;
using AbDataOutputStream = org.allbinary.logic.io.AbDataOutputStream;
using DataOutputStreamFactory = org.allbinary.logic.io.DataOutputStreamFactory;
using AbFile = org.allbinary.logic.io.file.AbFile;
using FileFactory = org.allbinary.logic.io.file.FileFactory;
using StringMaker = org.allbinary.logic.@string.StringMaker;

namespace org.allbinary.business.installer;

//Warning you must have sql root access
public class InitDbCrypted : AbDatabaseManagement
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private UserDbInitInfo userDbInitInfo = null;
    private InventoryDbInitInfo inventoryDbInitInfo = null;
    private HistoryDbInitInfo historyDbInitInfo = null;
    private StaticPagesDbInitInfo staticpagesDbInitInfo = null;
    private LogDbInitInfo logDbInitInfo = null;
    private readonly string SQL_FILE = "initWeblisket.sql";
    public InitDbCrypted(DatabaseConnectionInfoInterface databaseConnectionInfoInterface) : base(((DbConnectionInfo) databaseConnectionInfoInterface))
    {
        // base(((DbConnectionInfo) databaseConnectionInfoInterface)) is called from the constructor declaration
    }

    public virtual bool? addUsers()
    {
        try {
            this.logUtil.putF(this.commonStrings.START, this, this.METHOD_ADD_USERS);
            this.userDbInitInfo = new UserDbInitInfo();
            this.inventoryDbInitInfo = new InventoryDbInitInfo();
            this.historyDbInitInfo = new HistoryDbInitInfo();
            this.staticpagesDbInitInfo = new StaticPagesDbInitInfo();
            this.logDbInitInfo = new LogDbInitInfo();
            string CUSTOMERDB = this.userDbInitInfo.getName();
            string CUSTOMERDBUSER = this.userDbInitInfo.getUserName();
            string CUSTOMERDBPASSWORD = this.userDbInitInfo.getPassword();
            if (!this.addDbUser(CUSTOMERDB, CUSTOMERDBUSER, CUSTOMERDBPASSWORD)) {
                this.logUtil.putF(this.UNABLE_TO_CREATE_USER + CUSTOMERDBUSER, this, this.METHOD_ADD_USERS);
                return false;
            }
            string INVENTORYDB = this.inventoryDbInitInfo.getName();
            string INVENTORYDBUSER = this.inventoryDbInitInfo.getUserName();
            string INVENTORYDBPASSWORD = this.inventoryDbInitInfo.getPassword();
            if (!this.addDbUser(INVENTORYDB, INVENTORYDBUSER, INVENTORYDBPASSWORD)) {
                this.logUtil.putF(this.UNABLE_TO_CREATE_USER + INVENTORYDBUSER, this, this.METHOD_ADD_USERS);
                return false;
            }
            string HISTORYDB = this.historyDbInitInfo.getName();
            string HISTORYDBUSER = this.historyDbInitInfo.getUserName();
            string HISTORYDBPASSWORD = this.historyDbInitInfo.getPassword();
            if (!this.addDbUser(HISTORYDB, HISTORYDBUSER, HISTORYDBPASSWORD)) {
                this.logUtil.putF(this.UNABLE_TO_CREATE_USER + HISTORYDBUSER, this, this.METHOD_ADD_USERS);
                return false;
            }
            string STATICPAGESDB = this.staticpagesDbInitInfo.getName();
            string STATICPAGESDBUSER = this.staticpagesDbInitInfo.getUserName();
            string STATICPAGESDBPASSWORD = this.staticpagesDbInitInfo.getPassword();
            if (!this.addDbUser(STATICPAGESDB, STATICPAGESDBUSER, STATICPAGESDBPASSWORD)) {
                this.logUtil.putF(this.UNABLE_TO_CREATE_USER + STATICPAGESDBUSER, this, this.METHOD_ADD_USERS);
                return false;
            }
            string LOGDB = this.logDbInitInfo.getName();
            string LOGDBUSER = this.logDbInitInfo.getUserName();
            string LOGDBPASSWORD = this.logDbInitInfo.getPassword();
            if (!this.addDbUser(LOGDB, LOGDBUSER, LOGDBPASSWORD)) {
                this.logUtil.putF(this.UNABLE_TO_CREATE_USER + LOGDBUSER, this, this.METHOD_ADD_USERS);
                return false;
            }
            this.logUtil.putF(this.commonStrings.END, this, this.METHOD_ADD_USERS);
            return true;
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, this.METHOD_ADD_USERS, e);
            return true;
        }
    }

    public virtual bool? addDatabases()
    {
        try {
            this.logUtil.putF(this.commonStrings.START, this, this.METHOD_ADD_DATABASES);
            this.userDbInitInfo = new UserDbInitInfo();
            this.inventoryDbInitInfo = new InventoryDbInitInfo();
            this.historyDbInitInfo = new HistoryDbInitInfo();
            this.staticpagesDbInitInfo = new StaticPagesDbInitInfo();
            this.logDbInitInfo = new LogDbInitInfo();
            string CUSTOMERDB = this.userDbInitInfo.getName();
            if (!this.addDb(CUSTOMERDB)) {
                this.logUtil.putF(this.UNABLE_TO_CREATE_DATABASE + CUSTOMERDB, this, this.METHOD_ADD_DATABASES);
                return false;
            }
            string INVENTORYDB = this.inventoryDbInitInfo.getName();
            if (!this.addDb(INVENTORYDB)) {
                this.logUtil.putF(this.UNABLE_TO_CREATE_DATABASE + INVENTORYDB, this, this.METHOD_ADD_DATABASES);
                return false;
            }
            string HISTORYDB = this.historyDbInitInfo.getName();
            if (!this.addDb(HISTORYDB)) {
                this.logUtil.putF(this.UNABLE_TO_CREATE_DATABASE + HISTORYDB, this, this.METHOD_ADD_DATABASES);
                return false;
            }
            string STATICPAGESDB = this.staticpagesDbInitInfo.getName();
            if (!this.addDb(STATICPAGESDB)) {
                this.logUtil.putF(this.UNABLE_TO_CREATE_DATABASE + STATICPAGESDB, this, this.METHOD_ADD_DATABASES);
                return false;
            }
            string LOGDB = this.logDbInitInfo.getName();
            if (!this.addDb(LOGDB)) {
                this.logUtil.putF(this.UNABLE_TO_CREATE_DATABASE + LOGDB, this, this.METHOD_ADD_DATABASES);
                return false;
            }
            AbFile file = FileFactory.getInstance().getInstance(this.SQL_FILE);
            file.createNewFile();
            AbDataOutputStream idOutData = DataOutputStreamFactory.getInstance().getInstanceForAbFile(file);
            idOutData.writeBytes(this.sqlCommandLog.ToString());
            return true;
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, this.METHOD_ADD_DATABASES, e);
            return true;
        }
    }

    public virtual bool? addTables()
    {
        try {
            StringMaker stringBuffer = new StringMaker();
            this.logUtil.putF(this.commonStrings.START, this, this.METHOD_ADD_TABLES);
            stringBuffer.append(UserEntityFactory.getInstance().createTable());
            stringBuffer.append(StoreFrontsEntityFactory.getInstance().getStoreFrontsEntityInstance().createTable());
            stringBuffer.append(BillingAddressesEntityFactory.getInstance().getInstance(this.stringUtil.EMPTY_STRING).createTable());
            stringBuffer.append(ShippingAddressesEntityFactory.getInstance().getInstance(this.stringUtil.EMPTY_STRING).createTable());
            stringBuffer.append(PaymentEntityFactory.getInstance().getPaymentEntityInstance().createTable());
            stringBuffer.append(QuoteRequestEntityFactory.getInstance().getQuoteRequestEntityInstance().createTable());
            stringBuffer.append(OrderHistoryEntityFactory.getInstance().createTable());
            stringBuffer.append(OrderItemsEntityFactory.getInstance().createTable());
            stringBuffer.append(TransactionEntityFactory.getInstance().getTransactionEntityInstance().createTable());
            stringBuffer.append(TransactionResultEntityFactory.getInstance().getTransactionResultEntityInstance().createTable());
            stringBuffer.append(PaymentGatewayEntityFactory.getInstance().createTable());
            stringBuffer.append(InventoryEntityFactory.getInstance().getInventoryEntityInstance().createTable());
            stringBuffer.append(new InitInfoEntity().createTable());
            stringBuffer.append(LogTableEntityFactory.getInstance().getLogTableEntityInstance().createTable());
            stringBuffer.append(StaticPagesEntityFactory.getInstance().getStaticPagesEntityInstance().createTable());
            stringBuffer.append(TransformInfoEntityBuilder.getInstance().createTable());
            this.logUtil.putF(ADD_TABLES_RESULTS_LABEL + stringBuffer.ToString(), this, this.METHOD_ADD_TABLES);
            return true;
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, this.METHOD_ADD_TABLES, e);
            return false;
        }
    }

}

