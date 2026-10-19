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
//using HttpServletRequest = javax.servlet.http.HttpServletRequest;
//using PageContext = javax.servlet.jsp.PageContext;
using UserData = org.allbinary.business.user.UserData;
using UserInterface = org.allbinary.business.user.UserInterface;
using Password = org.allbinary.business.user.password.Password;
using BasicUserRole = org.allbinary.business.user.role.BasicUserRole;
using UserEntityFactory = org.allbinary.data.tables.user.UserEntityFactory;
using UserEntityInterface = org.allbinary.data.tables.user.UserEntityInterface;
using GLOBALS2 = org.allbinary.globals.GLOBALS2;
using WeblisketSession = org.allbinary.logic.communication.http.request.session.WeblisketSession;
using WeblisketSessionData = org.allbinary.logic.communication.http.request.session.WeblisketSessionData;
using WeblisketSessionInterface = org.allbinary.logic.communication.http.request.session.WeblisketSessionInterface;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using NewPasswordEmail = org.allbinary.logic.communication.smtp.email.NewPasswordEmail;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using AbeClientInformationInterface = org.allbinary.logic.system.security.licensing.AbeClientInformationInterface;
using ServiceClientInformationInterfaceFactory = org.allbinary.logic.system.security.licensing.ServiceClientInformationInterfaceFactory;

namespace admin.taghelpers;

public class AuthenticationRequestHelper : TagHelper
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly AbeClientInformationInterface abeClientInformation = ServiceClientInformationInterfaceFactory.getInstance();
    private WeblisketSession weblisketSession;
    private HttpServletRequest request;
    public AuthenticationRequestHelper(HashMap hashMap, PageContext pageContext)
    {
        this.weblisketSession = new WeblisketSession(hashMap, pageContext);
        this.request = ((HttpServletRequest) pageContext.getRequest());
    }

    public AuthenticationRequestHelper(HashMap hashMap, HttpServletRequest httpServletRequest)
    {
        this.weblisketSession = new WeblisketSession(hashMap, httpServletRequest);
        this.request = httpServletRequest;
    }

    // throws Exception
    private string generateNewPassword()
    {
        if (this.weblisketSession != null && this.weblisketSession.getId() != null) {
            int startIndex = this.weblisketSession.getId().length();
            if (startIndex >= 8) {
                return this.weblisketSession.getId().substring(startIndex - 8);
            } else {
                throw new Exception("Error Generating New Password");
            }
        } else {
            throw new Exception("No Session Available For Generating New Password");
        }
    }

    public virtual bool? newPassword()
    {
        try {
            string userName = this.request.getParameter(WeblisketSessionData.REMOVABLEUSERNAME);
            string email = this.request.getParameter(UserData.MAINEMAIL);
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().TAGHELPER)) {
                this.logUtil.putF("Generating New Password For: " + userName, this, "newPassword()");
            }
            UserEntityInterface userEntityInterface = UserEntityFactory.getInstance();
            UserInterface userInterface = userEntityInterface.getUser(userName);
            if (userInterface.getMainEmail().compareTo(email) != 0) {
                if (userInterface.getSecondaryEmail() != null && userInterface.getSecondaryEmail().compareTo(email) != 0) {
                    if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().TAGHELPER)) {
                        this.logUtil.putF("Requested Email Is Not In User Profile", this, "newPassword()");
                    }
                    return false;
                }
            }
            string newPassword = this.generateNewPassword();
            userInterface.setPassword(newPassword);
            HashMap newPasswordHashMap = userInterface.toPasswordHashMap();
            UserEntityFactory.getInstance().update(userName, newPasswordHashMap);
            new NewPasswordEmail(this.abeClientInformation, userInterface, newPassword).process();
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().TAGHELPER)) {
                this.logUtil.putF("Generated New Password For: " + userName, this, "newPassword()");
            }
            return true;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().TAGHELPERERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "newPassword()", e);
            }
            return false;
        }
    }

    public virtual bool? changePassword()
    {
        try {
            string userName = this.request.getParameter(WeblisketSessionData.REMOVABLEUSERNAME);
            string passwordString = this.request.getParameter(WeblisketSessionData.REMOVABLEPASSWORD);
            string newPassword = this.request.getParameter(WeblisketSessionData.REMOVABLENEWPASSWORD);
            string newReenteredPassword = this.request.getParameter(WeblisketSessionData.REMOVABLEREENTERNEWPASSWORD);
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().TAGHELPER)) {
                this.logUtil.putF("Changing Password For User: " + userName, this, "changePassword()");
            }
            Password password = new Password(newPassword);
            if (!password.isValid()) {
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().TAGHELPER)) {
                    this.logUtil.putF("New Password Is Not Valid", this, "changePassword()");
                }
                return false;
            }
            if (string.CompareOrdinal(newPassword, newReenteredPassword) != 0) {
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().TAGHELPER)) {
                    this.logUtil.putF("New Password Fields Do Not Match", this, "changePassword()");
                }
                return false;
            }
            string sessionPassword = this.weblisketSession.getPassword();
            UserEntityInterface userEntityInterface = UserEntityFactory.getInstance();
            UserInterface userInterface = userEntityInterface.getUser(userName);
            string login = userEntityInterface.login(userName, passwordString);
            if (string.CompareOrdinal(login, GLOBALS2.LOGINSUCCESS) == 0) {
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().TAGHELPER)) {
                    this.logUtil.putF("Authentication Successful", this, "changePassword()");
                }
                HashMap newPasswordHashMap = password.toHashMap(null);
                UserEntityFactory.getInstance().update(userName, newPasswordHashMap);
                new NewPasswordEmail(this.abeClientInformation, userInterface, newPassword).process();
                return true;
            }
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().TAGHELPER)) {
                this.logUtil.putF("Authentication Failed", this, "changePassword()");
            }
            return false;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().TAGHELPERERROR)) {
                this.logUtil.put("Authentication Failed", this, "changePassword()", e);
            }
            return false;
        }
    }

    public virtual bool? isRoleValid(string userName, string password, BasicArrayList roles)
    {
        try {
            UserEntityInterface userEntityInterface = UserEntityFactory.getInstance();
            UserInterface userInterface = userEntityInterface.getUser(userName);
            if (userInterface.getRole() == null) {
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().TAGHELPER)) {
                    this.logUtil.putF("Role is null: " + userInterface.getRole() + " Valid Roles: " + roles.ToString(), this, "isRoleValid()");
                }
                return false;
            }
            object[] basicUserRoleArray = roles.toArray();
            int size = basicUserRoleArray.Length;
            for (int index = 0; index < size; index++) {
                BasicUserRole nextRole = ((BasicUserRole) basicUserRoleArray[index]);
                if (userInterface.getRole().getBasicUserRole().Equals(nextRole)) {
                    userInterface.validateSession(((WeblisketSessionInterface) this.weblisketSession));
                    this.request.removeAttribute(WeblisketSessionData.REMOVABLEUSERNAME);
                    this.request.removeAttribute(WeblisketSessionData.REMOVABLEPASSWORD);
                    return true;
                }
            }
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().TAGHELPER)) {
                StringMaker stringBuffer = new StringMaker();
                stringBuffer.append("Role is not valid: ");
                stringBuffer.append(userInterface.getRole().ToString());
                stringBuffer.append(" Valid Roles: ");
                stringBuffer.append(roles.ToString());
                this.logUtil.putF(stringBuffer.ToString(), this, "isRoleValid()");
            }
            return false;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().TAGHELPERERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "isRoleValid()", e);
            }
            return false;
        }
    }

}

