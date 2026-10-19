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
using StoreFrontFactory = org.allbinary.business.context.modules.storefront.StoreFrontFactory;
using StoreFrontInterface = org.allbinary.business.context.modules.storefront.StoreFrontInterface;
using UserInterface = org.allbinary.business.user.UserInterface;
using OrderHistory = org.allbinary.business.user.commerce.inventory.order.OrderHistory;
using UserEntityFactory = org.allbinary.data.tables.user.UserEntityFactory;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using UserEmailEventNameData = org.allbinary.logic.communication.smtp.@event.UserEmailEventNameData;
using UserEmailEventHandler = org.allbinary.logic.communication.smtp.@event.handler.UserEmailEventHandler;
using AdminUserEmailEventHandlerSingletons = org.allbinary.logic.communication.smtp.@event.handler.factory.AdminUserEmailEventHandlerSingletons;
using StoreAdminUserEmailEventHandlerSingletons = org.allbinary.logic.communication.smtp.@event.handler.factory.StoreAdminUserEmailEventHandlerSingletons;
using UserEmailEventHandlerSingletons = org.allbinary.logic.communication.smtp.@event.handler.factory.UserEmailEventHandlerSingletons;
using AdminEmailInfo = org.allbinary.logic.communication.smtp.info.AdminEmailInfo;
using BasicEmailInfo = org.allbinary.logic.communication.smtp.info.BasicEmailInfo;
using EmailInfo = org.allbinary.logic.communication.smtp.info.EmailInfo;
using StoreEmailInfo = org.allbinary.logic.communication.smtp.info.StoreEmailInfo;
using AbeClientInformationInterface = org.allbinary.logic.system.security.licensing.AbeClientInformationInterface;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.business.user.commerce.inventory.order.status;

public class OrderStatusEmail
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private readonly AbeClientInformationInterface abeClientInformation;
    private OrderHistory orderHistory;
    private StoreFrontInterface storeFrontInterface;
    private UserInterface user;
    public OrderStatusEmail(AbeClientInformationInterface abeClientInformation, OrderHistory orderHistory)
    {
        this.abeClientInformation = abeClientInformation;
        this.orderHistory = orderHistory;
        string storeName = orderHistory.getStoreName();
        this.storeFrontInterface = StoreFrontFactory.getInstance(storeName);
        this.user = UserEntityFactory.getInstance().getUser(orderHistory.getUserName());
    }

    // throws Exception
    public virtual void process()
    {
        this.notifyStoreAdmin();
        this.notifyUser();
    }

    // throws Exception
    private void notifyStoreAdmin()
    {
        try {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().EMAILLOGGING)) {
                this.logUtil.putF("Order Email", this, "emailStoreAdmin");
            }
            string adminEmailSubject = "Order " + this.orderHistory.getStatus() + " Attempt";
            string adminEmailTextBody = "Order attempt: " + this.orderHistory.getId() + " Preprocessing by: " + this.user.getUserName();
            BasicEmailInfo adminBasicEmailInfo = ((BasicEmailInfo) new AdminEmailInfo(adminEmailSubject, adminEmailTextBody));
            BasicEmailInfo storeAdminBasicEmailInfo = ((BasicEmailInfo) new StoreEmailInfo(this.storeFrontInterface, adminEmailSubject, adminEmailTextBody));
            EmailInfo storeAdminEmailInfo = new EmailInfo(storeAdminBasicEmailInfo);
            EmailInfo adminEmailInfo = new EmailInfo(adminBasicEmailInfo);
            UserEmailEventNameData userEmailEventNameData = UserEmailEventNameData.getInstance(this.orderHistory.getStatus());
            UserEmailEventHandler adminUserEmailEventHandler = AdminUserEmailEventHandlerSingletons.getInstance().getInstance(this.abeClientInformation, userEmailEventNameData);
            UserEmailEventHandler storeAdminUserEmailEventHandler = StoreAdminUserEmailEventHandlerSingletons.getInstance().getInstance(userEmailEventNameData, this.abeClientInformation, this.storeFrontInterface);
            storeAdminUserEmailEventHandler.receiveEmailInfo(userEmailEventNameData, storeAdminEmailInfo);
            adminUserEmailEventHandler.receiveEmailInfo(userEmailEventNameData, adminEmailInfo);
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().EMAILLOGGINGERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "emailAdmin", e);
            }
        }
    }

    // throws Exception
    private void notifyUser()
    {
        try {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().EMAILLOGGING)) {
                this.logUtil.putF("Email User", this, "notifyUser()");
            }
            string subject = "Order " + this.orderHistory.getStatus() + " Attempt";
            string textBody = "Order attempt: " + this.orderHistory.getId() + " Preprocessing by: " + this.user.getUserName();
            BasicEmailInfo basicEmailInfo = ((BasicEmailInfo) new StoreEmailInfo(this.storeFrontInterface, subject, textBody));
            EmailInfo emailInfo = new EmailInfo(basicEmailInfo);
            UserEmailEventNameData userEmailEventNameData = UserEmailEventNameData.getInstance(this.orderHistory.getStatus());
            UserEmailEventHandler userEmailEventHandler = UserEmailEventHandlerSingletons.getInstance().getInstance(this.abeClientInformation, userEmailEventNameData, this.user);
            userEmailEventHandler.receiveEmailInfo(userEmailEventNameData, emailInfo);
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().EMAILLOGGINGERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "notifyUser", e);
            }
            throw e;
        }
    }

}

