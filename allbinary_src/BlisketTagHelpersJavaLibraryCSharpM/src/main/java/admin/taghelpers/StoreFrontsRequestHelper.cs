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
using System.Runtime.CompilerServices;
using java.util;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
//using HttpServletRequest = javax.servlet.http.HttpServletRequest;
//using PageContext = javax.servlet.jsp.PageContext;
using StoreFront = org.allbinary.business.context.modules.storefront.StoreFront;
using StoreFrontInterface = org.allbinary.business.context.modules.storefront.StoreFrontInterface;
using Portion = org.allbinary.business.installer.Portion;
using StoreFrontsEntityFactory = org.allbinary.data.tables.context.module.storefronts.StoreFrontsEntityFactory;
using WeblisketSession = org.allbinary.logic.communication.http.request.session.WeblisketSession;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using UserEmailEventNameData = org.allbinary.logic.communication.smtp.@event.UserEmailEventNameData;
using UserEmailEventHandler = org.allbinary.logic.communication.smtp.@event.handler.UserEmailEventHandler;
using AdminUserEmailEventHandlerSingletons = org.allbinary.logic.communication.smtp.@event.handler.factory.AdminUserEmailEventHandlerSingletons;
using StoreAdminUserEmailEventHandlerSingletons = org.allbinary.logic.communication.smtp.@event.handler.factory.StoreAdminUserEmailEventHandlerSingletons;
using AdminEmailInfo = org.allbinary.logic.communication.smtp.info.AdminEmailInfo;
using BasicEmailInfo = org.allbinary.logic.communication.smtp.info.BasicEmailInfo;
using EmailInfo = org.allbinary.logic.communication.smtp.info.EmailInfo;
using StoreEmailInfo = org.allbinary.logic.communication.smtp.info.StoreEmailInfo;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using AbeClientInformationInterface = org.allbinary.logic.system.security.licensing.AbeClientInformationInterface;
using ServiceClientInformationInterfaceFactory = org.allbinary.logic.system.security.licensing.ServiceClientInformationInterfaceFactory;

namespace admin.taghelpers;

public class StoreFrontsRequestHelper : ModifyTable
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly AbeClientInformationInterface abeClientInformation = ServiceClientInformationInterfaceFactory.getInstance();
    private readonly PageContext pageContext;
    private readonly HttpServletRequest request;
    private readonly WeblisketSession weblisketSession;
    private string storeName = null;
    private StoreFrontInterface modifyingStoreFrontInterface = null;
    private readonly Portion portion;
    public StoreFrontsRequestHelper(HashMap hashMap, PageContext pageContext)
    {
        this.pageContext = pageContext;
        this.request = ((HttpServletRequest) pageContext.getRequest());
        this.weblisketSession = new WeblisketSession(hashMap, pageContext);
        this.portion = new Portion(hashMap);
        this.getFormData();
    }

    // throws Exception
    private void getFormData()
    {
        this.storeName = this.weblisketSession.getStoreName();
        this.modifyingStoreFrontInterface = ((StoreFrontInterface) new StoreFront(this.request));
    }

    public virtual string update()
    {
        try {
            string success = "Updated Successfully";
            HashMap hashMapData = this.modifyingStoreFrontInterface.toHashMap();
            StoreFrontsEntityFactory.getInstance().getStoreFrontsEntityInstance().update(hashMapData);
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGS)) {
                this.logUtil.putF(success, this, "update()");
            }
            return success;
        } catch (Exception e) {
            string error = "Failed to update storefronts table";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "update()", e);
            }
            return error;
        }
    }

    // throws Exception
    public virtual void sendStoreCreatedEmails()
    {
        string storeManagerEmailSubject = "Store Manager Nofification For Store: " + this.modifyingStoreFrontInterface.getName();
        string adminEmailSubject = "Admin Notification For Store: " + this.modifyingStoreFrontInterface.getName();
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append("Store Created: ");
        stringBuffer.append(this.modifyingStoreFrontInterface.getName());
        stringBuffer.append("\n\n");
        stringBuffer.append("Click here for the Admin Interface:\n");
        stringBuffer.append(this.modifyingStoreFrontInterface.getCurrentHomeHostName());
        stringBuffer.append("/admin/login.jsp\n\n");
        stringBuffer.append("Goto Your Store:\n");
        stringBuffer.append(this.modifyingStoreFrontInterface.getCurrentHomeHostName());
        stringBuffer.append(this.modifyingStoreFrontInterface.getName());
        stringBuffer.append("/index.jsp");
        stringBuffer.append("\n\n");
        stringBuffer.append("UserName: ");
        stringBuffer.append(this.weblisketSession.getUserName());
        string adminEmailTextBody = stringBuffer.ToString();
        BasicEmailInfo adminBasicEmailInfo = ((BasicEmailInfo) new AdminEmailInfo(adminEmailSubject, adminEmailTextBody));
        BasicEmailInfo storeAdminBasicEmailInfo = ((BasicEmailInfo) new StoreEmailInfo(this.modifyingStoreFrontInterface, storeManagerEmailSubject, adminEmailTextBody));
        EmailInfo storeAdminEmailInfo = new EmailInfo(storeAdminBasicEmailInfo);
        EmailInfo adminEmailInfo = new EmailInfo(adminBasicEmailInfo);
        UserEmailEventHandler adminUserEmailEventHandler = AdminUserEmailEventHandlerSingletons.getInstance().getInstance(this.abeClientInformation, UserEmailEventNameData.STORECREATED);
        UserEmailEventHandler storeAdminUserEmailEventHandler = StoreAdminUserEmailEventHandlerSingletons.getInstance().getInstance(UserEmailEventNameData.STORECREATED, this.abeClientInformation, this.modifyingStoreFrontInterface);
        storeAdminUserEmailEventHandler.receiveEmailInfo(UserEmailEventNameData.STORECREATED, storeAdminEmailInfo);
        adminUserEmailEventHandler.receiveEmailInfo(UserEmailEventNameData.STORECREATED, adminEmailInfo);
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual string install()
    {
        try {
            StringMaker stringBuffer = new StringMaker();
            stringBuffer.append("Intall StoreFront Successfully: ");
            stringBuffer.appendint(((int) ((int) this.portion.getCurrent())));
            stringBuffer.append(" of ");
            stringBuffer.appendint(((int) ((int) this.portion.getTotal())));
            string success = stringBuffer.ToString();
            this.modifyingStoreFrontInterface.install(((int) this.portion.getCurrent()), ((int) this.portion.getTotal()));
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGS)) {
                this.logUtil.putF(success, this, "install()");
            }
            return success;
        } catch (Exception e) {
            string error = "Failed to Install storefront";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "install()", e);
            }
            return error;
        }
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual string insert()
    {
        try {
            string success = "Added Successfully";
            BasicArrayList values = this.modifyingStoreFrontInterface.toVector();
            StoreFrontsEntityFactory.getInstance().getStoreFrontsEntityInstance().insert(values);
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGS)) {
                this.logUtil.putF(success, this, "insert()");
            }
            return success;
        } catch (Exception e) {
            string error = "Failed to add storefront";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "insert()", e);
            }
            return error;
        }
    }

    public virtual string delete()
    {
        try {
            string success = "Delete Successfully";
            StoreFrontsEntityFactory.getInstance().getStoreFrontsEntityInstance().delete(this.storeName);
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGS)) {
                this.logUtil.putF(success, this, "delete()");
            }
            return success;
        } catch (Exception e) {
            string error = "Failed to delete storefronts table";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "delete()", e);
            }
            return error;
        }
    }

}

