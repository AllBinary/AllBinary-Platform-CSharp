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
using AbContext = org.allbinary.business.context.AbContext;
using StoreFrontData = org.allbinary.business.context.modules.storefront.StoreFrontData;
using StoreFrontFactory = org.allbinary.business.context.modules.storefront.StoreFrontFactory;
using StoreFrontInterface = org.allbinary.business.context.modules.storefront.StoreFrontInterface;
using URLGLOBALS = org.allbinary.globals.URLGLOBALS;
using AcceptableResponseGenerator = org.allbinary.logic.communication.http.AcceptableResponseGenerator;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using UserEmailEventNameData = org.allbinary.logic.communication.smtp.@event.UserEmailEventNameData;
using UserEmailEventHandler = org.allbinary.logic.communication.smtp.@event.handler.UserEmailEventHandler;
using AdminUserEmailEventHandlerSingletons = org.allbinary.logic.communication.smtp.@event.handler.factory.AdminUserEmailEventHandlerSingletons;
using StoreAdminUserEmailEventHandlerSingletons = org.allbinary.logic.communication.smtp.@event.handler.factory.StoreAdminUserEmailEventHandlerSingletons;
using AdminEmailInfo = org.allbinary.logic.communication.smtp.info.AdminEmailInfo;
using BasicEmailInfo = org.allbinary.logic.communication.smtp.info.BasicEmailInfo;
using EmailInfo = org.allbinary.logic.communication.smtp.info.EmailInfo;
using StoreEmailInfo = org.allbinary.logic.communication.smtp.info.StoreEmailInfo;
using SearchParams = org.allbinary.logic.control.search.SearchParams;
using SearchRequest = org.allbinary.logic.control.search.SearchRequest;
using FileUtil = org.allbinary.logic.io.file.FileUtil;
using AbPath = org.allbinary.logic.io.path.AbPath;
using AbPathData = org.allbinary.logic.io.path.AbPathData;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using AbeClientInformationInterface = org.allbinary.logic.system.security.licensing.AbeClientInformationInterface;
using ServiceClientInformationInterfaceFactory = org.allbinary.logic.system.security.licensing.ServiceClientInformationInterfaceFactory;
using TransformInfoData = org.allbinary.logic.visual.transform.info.TransformInfoData;
using ProductListingFactory = views.admin.inventory.listings.ProductListingFactory;

namespace admin.taghelpers;

public class StaticPagesRequestHelper : AbContext, TagHelperInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly AbeClientInformationInterface abeClientInformation = ServiceClientInformationInterfaceFactory.getInstance();
    private HttpServletRequest request;
    private string storeName = null;
    private SearchParams searchParams = null;
    private string xslFile;
    public StaticPagesRequestHelper(HashMap propertiesHashMap, PageContext pageContext) : base(propertiesHashMap, pageContext)
    {
        // base(propertiesHashMap, pageContext) is called from the constructor declaration
        this.request = ((HttpServletRequest) pageContext.getRequest());
        this.xslFile = ((string) propertiesHashMap.get(TransformInfoData.getInstance().TEMPLATEFILENAME));
        this.getFormData();
    }

    private void getFormData()
    {
        this.storeName = this.request.getParameter(StoreFrontData.getInstance().NAME);
        this.searchParams = new SearchParams(this.request);
    }

    // throws Exception
    private void email()
    {
        try {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().EMAILLOGGING)) {
                this.logUtil.putF("Generated Static Pages Notification Email", this, "email");
            }
            StoreFrontInterface storeFrontInterface = StoreFrontFactory.getInstance(this.storeName);
            string adminEmailSubject = "Generated Static Pages Email Notification";
            string adminEmailTextBody = "Generated static pages for store: " + this.storeName;
            BasicEmailInfo adminBasicEmailInfo = ((BasicEmailInfo) new AdminEmailInfo(adminEmailSubject, adminEmailTextBody));
            BasicEmailInfo storeAdminBasicEmailInfo = ((BasicEmailInfo) new StoreEmailInfo(storeFrontInterface, adminEmailSubject, adminEmailTextBody));
            EmailInfo storeAdminEmailInfo = new EmailInfo(storeAdminBasicEmailInfo);
            EmailInfo adminEmailInfo = new EmailInfo(adminBasicEmailInfo);
            UserEmailEventHandler adminUserEmailEventHandler = AdminUserEmailEventHandlerSingletons.getInstance().getInstance(this.abeClientInformation, UserEmailEventNameData.STOREGENERATINGSTATICPAGES);
            UserEmailEventHandler storeAdminUserEmailEventHandler = StoreAdminUserEmailEventHandlerSingletons.getInstance().getInstance(UserEmailEventNameData.STOREGENERATINGSTATICPAGES, this.abeClientInformation, storeFrontInterface);
            storeAdminUserEmailEventHandler.receiveEmailInfo(UserEmailEventNameData.STOREGENERATINGSTATICPAGES, storeAdminEmailInfo);
            adminUserEmailEventHandler.receiveEmailInfo(UserEmailEventNameData.STOREGENERATINGSTATICPAGES, adminEmailInfo);
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().EMAILLOGGINGERROR)) {
                this.logUtil.put(this.commonStrings.FAILURE, this, "email", e);
            }
        }
    }

    public virtual string generateStaticPages()
    {
        try {
            string contentType = AcceptableResponseGenerator.getInstance().get(this.request);
            SearchRequest searchRequest = new SearchRequest(null, this.searchParams, this.xslFile, contentType, this.getPropertiesHashMap(), this.getPageContext());
            string success = ProductListingFactory.getInstance(searchRequest).generateAll(this.storeName);
            this.email();
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGS)) {
                this.logUtil.putF(success, this, "generateStaticPages()");
            }
            return success;
        } catch (Exception e) {
            string error = "Failed to generate staticpages table";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "generateStaticPages()", e);
            }
            return error;
        }
    }

    public virtual string makePublic()
    {
        try {
            StoreFrontInterface storeFrontInterface = StoreFrontFactory.getInstance(this.storeName);
            AbPath fromAbPath = new AbPath(storeFrontInterface.getTestHtmlPath() + storeFrontInterface.getStaticPath(), StringUtil.getInstance().EMPTY_STRING);
            AbPath toAbPath = new AbPath(URLGLOBALS.getWebappPath() + storeFrontInterface.getName() + AbPathData.getInstance().SEPARATOR + storeFrontInterface.getStaticPath(), StringUtil.getInstance().EMPTY_STRING);
            FileUtil.getInstance().copy(fromAbPath, toAbPath);
            string success = "Made Public";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGS)) {
                this.logUtil.putF(success, this, "makePublic()");
            }
            return success;
        } catch (Exception e) {
            string error = "Failed to makePublic";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "makePublic()", e);
            }
            return error;
        }
    }

}

