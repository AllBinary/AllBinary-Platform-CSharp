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
using StoreFront = org.allbinary.business.context.modules.storefront.StoreFront;
using StoreFrontData = org.allbinary.business.context.modules.storefront.StoreFrontData;
using StoreFrontFactory = org.allbinary.business.context.modules.storefront.StoreFrontFactory;
using StoreFrontInterface = org.allbinary.business.context.modules.storefront.StoreFrontInterface;
using Portion = org.allbinary.business.installer.Portion;
using UserInterface = org.allbinary.business.user.UserInterface;
using QuoteRequest = org.allbinary.business.user.quoterequest.QuoteRequest;
using UserEntityFactory = org.allbinary.data.tables.user.UserEntityFactory;
using QuoteRequestEntity = org.allbinary.data.tables.user.quoterequest.QuoteRequestEntity;
using QuoteRequestEntityFactory = org.allbinary.data.tables.user.quoterequest.QuoteRequestEntityFactory;
using WeblisketSession = org.allbinary.logic.communication.http.request.session.WeblisketSession;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using UserEmailEventNameData = org.allbinary.logic.communication.smtp.@event.UserEmailEventNameData;
using UserEmailEventHandler = org.allbinary.logic.communication.smtp.@event.handler.UserEmailEventHandler;
using AdminUserEmailEventHandlerSingletons = org.allbinary.logic.communication.smtp.@event.handler.factory.AdminUserEmailEventHandlerSingletons;
using StoreAdminUserEmailEventHandlerSingletons = org.allbinary.logic.communication.smtp.@event.handler.factory.StoreAdminUserEmailEventHandlerSingletons;
using UserEmailEventHandlerSingletons = org.allbinary.logic.communication.smtp.@event.handler.factory.UserEmailEventHandlerSingletons;
using BasicEmailInfo = org.allbinary.logic.communication.smtp.info.BasicEmailInfo;
using EmailInfo = org.allbinary.logic.communication.smtp.info.EmailInfo;
using StoreEmailInfo = org.allbinary.logic.communication.smtp.info.StoreEmailInfo;
using AbSqlTableUtil = org.allbinary.logic.communication.sql.AbSqlTableUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using AbeClientInformationInterface = org.allbinary.logic.system.security.licensing.AbeClientInformationInterface;
using ServiceClientInformationInterfaceFactory = org.allbinary.logic.system.security.licensing.ServiceClientInformationInterfaceFactory;

namespace admin.taghelpers;

public class QuoteHelper : BasicTable
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly AbeClientInformationInterface abeClientInformation = ServiceClientInformationInterfaceFactory.getInstance();
    private readonly WeblisketSession weblisketSession;
    private readonly StoreFrontInterface storeFrontInterface = null;
    private readonly Portion portion;
    public QuoteHelper(HashMap<object, object> hashMap, PageContext pageContext)
    {
        string storeName = ((string) hashMap.get(StoreFrontData.getInstance().NAME));
        if (storeName != null) {
            this.storeFrontInterface = StoreFrontFactory.getInstance(storeName);
        } else {
            this.storeFrontInterface = new StoreFront();
        }
        this.weblisketSession = new WeblisketSession(hashMap, pageContext);
        this.portion = new Portion(hashMap);
    }

    // throws Exception
    private void emailUser(QuoteRequest quoteRequest)
    {
        UserInterface user = UserEntityFactory.getInstance().getUser(quoteRequest.getUserName());
        string userEmailSubject = "Quote Request Receipt";
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append("This is just a verification email. ");
        stringBuffer.append("We usually respond to quote request within 24 hours.");
        stringBuffer.append("\n\nThank You For Your Business.");
        string userEmailTextBody = stringBuffer.ToString();
        BasicEmailInfo basicEmailInfo = ((BasicEmailInfo) new StoreEmailInfo(this.storeFrontInterface, userEmailSubject, userEmailTextBody));
        EmailInfo emailInfo = new EmailInfo(basicEmailInfo);
        UserEmailEventHandler userEmailEventHandler = UserEmailEventHandlerSingletons.getInstance().getInstance(this.abeClientInformation, UserEmailEventNameData.QUOTEREQUEST, user);
        userEmailEventHandler.receiveEmailInfo(UserEmailEventNameData.QUOTEREQUEST, emailInfo);
    }

    // throws Exception
    private void emailAdmins(QuoteRequest quoteRequest)
    {
        string adminEmailSubject = "Quote Request";
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append("\nUserName: ");
        stringBuffer.append(quoteRequest.getUserName());
        stringBuffer.append("\nProject Info: \n");
        stringBuffer.append(quoteRequest.getProjectInfo());
        stringBuffer.append("\nUser Comments: \n");
        stringBuffer.append(quoteRequest.getUserComments());
        stringBuffer.append("\nBudget: \n");
        stringBuffer.append(quoteRequest.getBudget());
        stringBuffer.append("\nTime Frame: \n");
        stringBuffer.append(quoteRequest.getTimeFrame());
        stringBuffer.append("\nComments: \n");
        stringBuffer.append(quoteRequest.getComments());
        string adminEmailTextBody = stringBuffer.ToString();
        BasicEmailInfo basicEmailInfo = ((BasicEmailInfo) new StoreEmailInfo(this.storeFrontInterface, adminEmailSubject, adminEmailTextBody));
        EmailInfo emailInfo = new EmailInfo(basicEmailInfo);
        UserEmailEventHandler storeAdminUserEmailEventHandler = AdminUserEmailEventHandlerSingletons.getInstance().getInstance(this.abeClientInformation, UserEmailEventNameData.QUOTEREQUEST);
        UserEmailEventHandler adminUserEmailEventHandler = StoreAdminUserEmailEventHandlerSingletons.getInstance().getInstance(UserEmailEventNameData.QUOTEREQUEST, this.abeClientInformation, this.storeFrontInterface);
        storeAdminUserEmailEventHandler.receiveEmailInfo(UserEmailEventNameData.QUOTEREQUEST, emailInfo);
        adminUserEmailEventHandler.receiveEmailInfo(UserEmailEventNameData.QUOTEREQUEST, emailInfo);
    }

    // throws Exception
    public virtual string email()
    {
        try {
            QuoteRequestEntity quoteRequestEntity = QuoteRequestEntityFactory.getInstance().getQuoteRequestEntityInstance();
            string userName = this.weblisketSession.getUserName();
            BasicArrayList vector = quoteRequestEntity.getIds(userName);
            int id = 0;
            int size = vector.size();
            for (int index = 0; index < size; index++) {
                int nextId = ((int) (((int?) vector.get(index))));
                if (id < nextId) {
                    id = nextId;
                }
            }
            QuoteRequest quoteRequest = quoteRequestEntity.get(userName, id);
            if (quoteRequest != null) {
                this.emailUser(quoteRequest);
                this.emailAdmins(quoteRequest);
                return "Thank You For Your Business.<p/>";
            } else {
                throw new Exception("No Quote Request");
            }
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().EMAILLOGGINGERROR)) {
                this.logUtil.put(this.commonStrings.FAILURE, this, "email", e);
            }
            return "Thank You For Your Business.<p>";
        }
    }

    public virtual string drop()
    {
        try {
            string success = QuoteRequestEntityFactory.getInstance().getQuoteRequestEntityInstance().dropTable();
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGS)) {
                this.logUtil.putF(success, this, this.commonStrings.DROP);
            }
            return success;
        } catch (Exception e) {
            string error = "Failed to drop QuoteRequest table";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.DROP, e);
            }
            return error;
        }
    }

    public virtual string create()
    {
        try {
            string success = QuoteRequestEntityFactory.getInstance().getQuoteRequestEntityInstance().createTable();
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGS)) {
                this.logUtil.putF(success, this, "create()");
            }
            return success;
        } catch (Exception e) {
            string error = "Failed to create new QuoteRequest table";
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
            string result = AbSqlTableUtil.getInstance().restoreTable(QuoteRequestEntityFactory.getInstance().getQuoteRequestEntityInstance(), portion);
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
            string result = AbSqlTableUtil.getInstance().backupTable(QuoteRequestEntityFactory.getInstance().getQuoteRequestEntityInstance());
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

