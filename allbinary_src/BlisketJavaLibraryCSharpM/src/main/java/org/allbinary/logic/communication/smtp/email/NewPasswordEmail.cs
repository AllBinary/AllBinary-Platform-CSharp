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
using UserInterface = org.allbinary.business.user.UserInterface;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using UserEmailEventNameData = org.allbinary.logic.communication.smtp.@event.UserEmailEventNameData;
using UserEmailEventHandler = org.allbinary.logic.communication.smtp.@event.handler.UserEmailEventHandler;
using AdminUserEmailEventHandlerSingletons = org.allbinary.logic.communication.smtp.@event.handler.factory.AdminUserEmailEventHandlerSingletons;
using UserEmailEventHandlerSingletons = org.allbinary.logic.communication.smtp.@event.handler.factory.UserEmailEventHandlerSingletons;
using AdminEmailInfo = org.allbinary.logic.communication.smtp.info.AdminEmailInfo;
using BasicEmailInfo = org.allbinary.logic.communication.smtp.info.BasicEmailInfo;
using EmailInfo = org.allbinary.logic.communication.smtp.info.EmailInfo;
using AbeClientInformationInterface = org.allbinary.logic.system.security.licensing.AbeClientInformationInterface;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.logic.communication.smtp.email;

public class NewPasswordEmail
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private readonly AbeClientInformationInterface abeClientInformation;
    private UserInterface userInterface;
    private string newPassword;
    public NewPasswordEmail(AbeClientInformationInterface abeClientInformation, UserInterface userInterface, string newPassword)
    {
        this.abeClientInformation = abeClientInformation;
        this.userInterface = userInterface;
        this.newPassword = newPassword;
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
                this.logUtil.putF("notifyStoreAdmin", this, "notifyStoreAdmin");
            }
            string emailSubject = "New Password For User: " + this.userInterface.getUserName();
            string emailBody = "New Password: " + this.newPassword;
            BasicEmailInfo basicEmailInfo = ((BasicEmailInfo) new AdminEmailInfo(emailSubject, emailBody));
            EmailInfo emailInfo = new EmailInfo(basicEmailInfo);
            UserEmailEventHandler adminUserEmailEventHandler = AdminUserEmailEventHandlerSingletons.getInstance().getInstance(this.abeClientInformation, UserEmailEventNameData.NEWPASSWORD);
            adminUserEmailEventHandler.receiveEmailInfo(UserEmailEventNameData.NEWPASSWORD, emailInfo);
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
            string subject = "New Password";
            string body = "New Password: " + this.newPassword;
            BasicEmailInfo basicEmailInfo = ((BasicEmailInfo) new AdminEmailInfo(subject, body));
            EmailInfo emailInfo = new EmailInfo(basicEmailInfo);
            UserEmailEventHandler userEmailEventHandler = UserEmailEventHandlerSingletons.getInstance().getInstance(this.abeClientInformation, UserEmailEventNameData.NEWPASSWORD, this.userInterface);
            userEmailEventHandler.receiveEmailInfo(UserEmailEventNameData.NEWPASSWORD, emailInfo);
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().EMAILLOGGINGERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "notifyUser", e);
            }
            throw e;
        }
    }

}

