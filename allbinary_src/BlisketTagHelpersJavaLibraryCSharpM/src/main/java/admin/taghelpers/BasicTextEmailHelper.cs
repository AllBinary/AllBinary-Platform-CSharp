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
//using PageContext = javax.servlet.jsp.PageContext;
using UserEmailEventNameData = org.allbinary.logic.communication.smtp.@event.UserEmailEventNameData;
using UserEmailEventHandler = org.allbinary.logic.communication.smtp.@event.handler.UserEmailEventHandler;
using AdminUserEmailEventHandlerSingletons = org.allbinary.logic.communication.smtp.@event.handler.factory.AdminUserEmailEventHandlerSingletons;
using AdminEmailInfo = org.allbinary.logic.communication.smtp.info.AdminEmailInfo;
using BasicEmailInfo = org.allbinary.logic.communication.smtp.info.BasicEmailInfo;
using EmailInfo = org.allbinary.logic.communication.smtp.info.EmailInfo;
using AbeClientInformationInterface = org.allbinary.logic.system.security.licensing.AbeClientInformationInterface;
using ServiceClientInformationInterfaceFactory = org.allbinary.logic.system.security.licensing.ServiceClientInformationInterfaceFactory;

namespace admin.taghelpers;

public class BasicTextEmailHelper : TagHelper
{
    private readonly AbeClientInformationInterface abeClientInformation = ServiceClientInformationInterfaceFactory.getInstance();
    private HashMap<object, object> hashMap;
    private PageContext pageContext;
    public BasicTextEmailHelper(HashMap<object, object> hashMap, PageContext pageContext)
    {
        this.pageContext = pageContext;
        this.hashMap = hashMap;
    }

    // throws Exception
    public virtual void send()
    {
        string adminEmailSubject = ((string) this.hashMap.get("Subject"));
        string adminEmailTextBody = ((string) this.hashMap.get("Body"));
        BasicEmailInfo adminBasicEmailInfo = ((BasicEmailInfo) new AdminEmailInfo(adminEmailSubject, adminEmailTextBody));
        EmailInfo adminEmailInfo = new EmailInfo(adminBasicEmailInfo);
        UserEmailEventHandler adminUserEmailEventHandler = AdminUserEmailEventHandlerSingletons.getInstance().getInstance(this.abeClientInformation, UserEmailEventNameData.INSTALLER);
        adminUserEmailEventHandler.receiveEmailInfo(UserEmailEventNameData.INSTALLER, adminEmailInfo);
    }

}

