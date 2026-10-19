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
//using Calendar = java.util.Calendar;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
//using HttpServletRequest = javax.servlet.http.HttpServletRequest;
//using JspTagException = javax.servlet.jsp.JspTagException;
//using TagSupport = javax.servlet.jsp.tagext.TagSupport;
using InstallerInfo = org.allbinary.business.init.InstallerInfo;
using BasicUserRole = org.allbinary.business.user.role.BasicUserRole;
using BasicUserRoleFactory = org.allbinary.business.user.role.BasicUserRoleFactory;
using AbResponseHandler = org.allbinary.logic.communication.http.request.AbResponseHandler;
using BasicWeblisketSession = org.allbinary.logic.communication.http.request.session.BasicWeblisketSession;
using WeblisketSessionData = org.allbinary.logic.communication.http.request.session.WeblisketSessionData;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using BooleanFactory = org.allbinary.logic.java.@bool.BooleanFactory;
using BooleanUtil = org.allbinary.logic.java.@bool.BooleanUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using LicensingException = org.allbinary.logic.system.security.licensing.LicensingException;
using CustomTagSupport = tags.CustomTagSupport;

namespace admin.tags;

public class FileAuthenticationTag : CustomTagSupport
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private int? attemptsInteger = null;
    private BasicWeblisketSession weblisketSession = null;
    private HttpServletRequest request = null;
    private string command = null;
    private string userName = null;
    private string password = null;
    private string newPassword = null;
    private string authenticated = null;
    private string sessionUserName = null;
    private BasicUserRole role = null;
    private string timeout = null;
    private BasicArrayList roles = null;
    public FileAuthenticationTag()
    {
    }

    public virtual void setCommand(string command)
    {
        this.command = command;
    }

    public virtual void setUserName(string userName)
    {
        this.userName = userName;
    }

    public virtual void setPassword(string value)
    {
        this.password = value;
    }

    public virtual void setNewPassword(string value)
    {
        this.newPassword = value;
    }

    public virtual void setRoles(BasicArrayList values)
    {
        this.roles = values;
    }

    private void makeSessionValid(BasicUserRole storedRole, string userName)
    {
        this.weblisketSession.setAuthenticated();
        this.weblisketSession.setRole(storedRole);
        this.weblisketSession.setUserName(userName);
        this.request.removeAttribute(WeblisketSessionData.REMOVABLEUSERNAME);
        this.request.removeAttribute(WeblisketSessionData.REMOVABLEPASSWORD);
    }

    private void getFormData()
    {
        this.authenticated = this.weblisketSession.getAuthentication();
        this.sessionUserName = this.weblisketSession.getUserName();
        this.role = this.weblisketSession.getRole();
        this.attemptsInteger = this.weblisketSession.getAttempts();
        this.timeout = this.weblisketSession.getTimeout();
    }

    public virtual void nextAttempt()
    {
        if (this.attemptsInteger != null && ((int) this.attemptsInteger) > 0) {
            this.weblisketSession.setAttempts(((int) this.attemptsInteger) + 1);
        } else {
            this.weblisketSession.setAttempts(1);
        }
    }

    // throws LicensingException
    private bool changePassword()
    {
        try {
            string userName = this.request.getParameter(WeblisketSessionData.REMOVABLEUSERNAME);
            string password = this.request.getParameter(WeblisketSessionData.REMOVABLEPASSWORD);
            string newPassword = this.request.getParameter(WeblisketSessionData.REMOVABLENEWPASSWORD);
            string newReenteredPassword = this.request.getParameter(WeblisketSessionData.REMOVABLEREENTERNEWPASSWORD);
            if (string.CompareOrdinal(newPassword, newReenteredPassword) != 0) {
                return false;
            }
            InstallerInfo installerInfo = new InstallerInfo();
            if (installerInfo.isValid(userName, password)) {
                installerInfo.setPassword(newPassword);
                installerInfo.write();
                this.weblisketSession.setUserName(userName);
                this.weblisketSession.setPassword(newPassword);
                return true;
            }
            return false;
        } catch (LicensingException e) {
            throw e;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().JSPTAGERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "invalidateSession()", e);
            }
            return false;
        }
    }

    private int invalidateSession()
    {
        try {
            this.weblisketSession.clear();
            return ((int) TagSupport.EVAL_BODY_INCLUDE);
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().JSPTAGERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "invalidateSession()", e);
            }
            return TagSupport.SKIP_BODY;
        }
    }

    // throws LicensingException
    private bool isSessionOld()
    {
        try {
            if (this.role != null) {
                long timeCreated = this.weblisketSession.getCreationTime();
                long sessionTimout = this.role.getSessionTimeout();
                Calendar calendar = Calendar.getInstance();
                long timeFirst = calendar.getTimeInMillis() - sessionTimout;
                if (timeFirst > timeCreated) {
                    if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().AUTHENTICATION)) {
                        StringMaker stringBuffer = new StringMaker();
                        stringBuffer.append("Session Is Old - Timeout: ");
                        stringBuffer.appendlong(sessionTimout);
                        stringBuffer.append(" Eval: ");
                        stringBuffer.appendlong(timeFirst);
                        stringBuffer.append(" > ");
                        stringBuffer.appendlong(timeCreated);
                        this.logUtil.putF(stringBuffer.ToString(), this, "isSessionOld()");
                    }
                    return true;
                }
            } else {
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().AUTHENTICATION)) {
                    this.logUtil.putF("Role Is Not In Session", this, "isSessionOld()");
                }
            }
            return this.isRarelyUsedSession();
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().JSPTAGERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "isSessionOld()", e);
            }
            return false;
        }
    }

    private bool? isRarelyUsedSession()
    {
        if (this.role != null) {
            long timeCreated = this.weblisketSession.getCreationTime();
            long lastAccess = this.weblisketSession.getLastAccessedTime();
            long timePassed = this.role.getSessionInactivityTimeout();
            Calendar calendar = Calendar.getInstance();
            long timeFirst = calendar.getTimeInMillis() - lastAccess;
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().AUTHENTICATION)) {
                StringMaker stringBuffer = new StringMaker();
                stringBuffer.append("Session Is Rarely Used - Timeout: ");
                stringBuffer.appendlong(lastAccess);
                stringBuffer.append(" Eval: ");
                stringBuffer.appendlong(timeFirst);
                stringBuffer.append(" > ");
                stringBuffer.appendlong(timePassed);
                this.logUtil.putF(stringBuffer.ToString(), this, "isRarelyUsedSession()");
            }
        } else {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().AUTHENTICATION)) {
                this.logUtil.putF("Role Is Not In Session", this, "isRarelyUsedSession()");
            }
        }
        return false;
    }

    // throws LicensingException
    private bool isRoleValid()
    {
        try {
            this.makeSessionValid(BasicUserRoleFactory.getInstance().INSTALLER, userName);
            return true;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().JSPTAGERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "isRoleValid()", e);
            }
            return false;
        }
    }

    // throws LicensingException
    private string validRole()
    {
        try {
            StringMaker stringBuffer = new StringMaker();
            stringBuffer.append("Trying New login<p>");
            return stringBuffer.ToString();
        } catch (Exception e) {
            string error = "Failed to set valid role";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().JSPTAGERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "validRole()", e);
            }
            return error;
        }
    }

    // throws LicensingException
    private string invalidRole()
    {
        try {
            this.weblisketSession.setAuthenticated(false);
            StringMaker stringBuffer = new StringMaker();
            stringBuffer.append("Sorry your username and password is invalid on this page.");
            stringBuffer.append("Trying New login<p>");
            return stringBuffer.ToString();
        } catch (Exception e) {
            string error = "Failed to set role invalid";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().JSPTAGERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "invalidRole()", e);
            }
            return error;
        }
    }

    // throws LicensingException
    private bool isAuthenticationSessionValid()
    {
        try {
            if (BooleanUtil.getInstance().getFromString(this.authenticated)) {
                int size = this.roles.size();
                for (int index = 0; index < size; index++) {
                    BasicUserRole mustBeOfRole = ((BasicUserRole) this.roles.get(index));
                    if (this.sessionUserName != null && this.role.Equals(mustBeOfRole)) {
                        return true;
                    }
                }
                return false;
            }
            return false;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().JSPTAGERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "isAuthenticationSessionValid()", e);
            }
            return false;
        }
    }

    // throws LicensingException
    private bool processIfNewLogin()
    {
        try {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().TAGHELPERERROR)) {
                this.logUtil.putF("Starting for User: " + this.userName + " Attempt: " + this.weblisketSession.getAttempts(), this, "processIfNewLogin()");
            }
            if (this.userName != null && string.CompareOrdinal(this.userName, StringUtil.getInstance().EMPTY_STRING) != 0 && this.password != null && string.CompareOrdinal(this.password, StringUtil.getInstance().EMPTY_STRING) != 0) {
                string login = null;
                InstallerInfo installerInfo = new InstallerInfo();
                if (installerInfo.isValid(this.userName, this.password)) {
                    login = org.allbinary.globals.GLOBALS2.LOGINSUCCESS;
                } else {
                    login = org.allbinary.globals.GLOBALS2.LOGINFAILED;
                }
                if (string.CompareOrdinal(login, org.allbinary.globals.GLOBALS2.LOGINSUCCESS) == 0) {
                    this.weblisketSession.setAttempts(0);
                    return true;
                }
                this.nextAttempt();
                return false;
            }
            this.nextAttempt();
            return false;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().JSPTAGERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "processIfNewLogin()", e);
            }
            return false;
        }
    }

    // throws LicensingException
    private bool processInvalidation()
    {
        try {
            if (BooleanUtil.getInstance().getFromString(this.timeout)) {
                this.invalidateSession();
                return true;
            }
            {
                this.weblisketSession.setTimeout(BooleanFactory.getInstance().TRUE_STRING);
                return false;
            }
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().JSPTAGERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "isSetToInvalidate()", e);
            }
            return false;
        }
    }

    // throws JspTagException
    public virtual int doStartTag()
    {
        try {
            StringUtil stringUtil = StringUtil.getInstance();
            this.request = ((HttpServletRequest) pageContext.getRequest());
            this.weblisketSession = new BasicWeblisketSession(pageContext);
            this.getFormData();
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().JSPTAG)) {
                this.logUtil.putF("Started", this, this.tagStrings.DO_START_TAG);
            }
            if (this.command != null) {
                if (string.CompareOrdinal(this.command, org.allbinary.globals.GLOBALS2.CHANGEPASSWORD) == 0) {
                    if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().JSPTAG)) {
                        this.logUtil.putF("Change Password", this, this.tagStrings.DO_START_TAG);
                    }
                    if (!this.changePassword()) {
                        pageContext.getOut().print("Password Change Attempt Failed.<p>");
                        return EVAL_BODY_INCLUDE;
                    } else {
                        pageContext.getOut().print("Password Changed Successfully.<p>");
                        return SKIP_BODY;
                    }
                } else if (string.CompareOrdinal(this.command, WeblisketSessionData.INVALIDATESESSION) == 0) {
                    if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().JSPTAG)) {
                        this.logUtil.putF("INVALIDATESESSION", this, this.tagStrings.DO_START_TAG);
                    }
                    return this.invalidateSession();
                } else {
                    if (this.isSessionOld()) {
                        if (this.processInvalidation()) {
                            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().JSPTAG)) {
                                this.logUtil.putF("Processing Invalidation", this, this.tagStrings.DO_START_TAG);
                            }
                            pageContext.getOut().print("Please login again.<p>");
                            if (string.CompareOrdinal(this.command, org.allbinary.globals.GLOBALS2.PROCESSBODYIFAUTHENTICATED) == 0) {
                                return TagSupport.SKIP_BODY;
                            } else {
                                return TagSupport.EVAL_BODY_INCLUDE;
                            }
                        } else {
                            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().JSPTAG)) {
                                this.logUtil.putF("Preparing session for invalidation", this, this.tagStrings.DO_START_TAG);
                            }
                            if (string.CompareOrdinal(this.command, org.allbinary.globals.GLOBALS2.PROCESSBODYIFAUTHENTICATED) == 0) {
                                return TagSupport.SKIP_BODY;
                            } else {
                                return TagSupport.EVAL_BODY_INCLUDE;
                            }
                        }
                    }
                    if ((this.userName == null || string.CompareOrdinal(this.userName, stringUtil.EMPTY_STRING) == 0) && (this.password == null || string.CompareOrdinal(this.password, stringUtil.EMPTY_STRING) == 0) && this.roles != null && this.isAuthenticationSessionValid()) {
                        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().JSPTAG)) {
                            this.logUtil.putF("Authenticated session is valid", this, this.tagStrings.DO_START_TAG);
                        }
                        if (string.CompareOrdinal(this.command, org.allbinary.globals.GLOBALS2.PROCESSBODYIFAUTHENTICATED) == 0) {
                            return TagSupport.EVAL_BODY_INCLUDE;
                        } else {
                            return TagSupport.SKIP_BODY;
                        }
                    }
                    if (this.userName != null && this.password != null && this.processIfNewLogin()) {
                        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().JSPTAG)) {
                            this.logUtil.putF("Processing new login.", this, this.tagStrings.DO_START_TAG);
                        }
                        if (this.isRoleValid()) {
                            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().JSPTAG)) {
                                this.logUtil.putF("Role is valid - Processing new login", this, this.tagStrings.DO_START_TAG);
                            }
                            pageContext.getOut().print(validRole());
                            if (string.CompareOrdinal(this.command, org.allbinary.globals.GLOBALS2.PROCESSBODYIFAUTHENTICATED) == 0) {
                                return EVAL_BODY_INCLUDE;
                            } else {
                                return SKIP_BODY;
                            }
                        } else {
                            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().JSPTAG)) {
                                this.logUtil.putF("Role is not valid - Processing new login", this, this.tagStrings.DO_START_TAG);
                            }
                            pageContext.getOut().print(invalidRole());
                            if (string.CompareOrdinal(this.command, org.allbinary.globals.GLOBALS2.PROCESSBODYIFAUTHENTICATED) == 0) {
                                return SKIP_BODY;
                            } else {
                                return EVAL_BODY_INCLUDE;
                            }
                        }
                    } else {
                        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().JSPTAG)) {
                            this.logUtil.putF("Invalid Login", this, this.tagStrings.DO_START_TAG);
                        }
                        if (this.userName != null && string.CompareOrdinal(this.userName, StringUtil.getInstance().EMPTY_STRING) != 0 && this.password != null && string.CompareOrdinal(this.password, StringUtil.getInstance().EMPTY_STRING) != 0) {
                            pageContext.getOut().print("Sorry your username and/or password is invalid.<p>");
                        }
                    }
                    if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().JSPTAG)) {
                        StringMaker stringBuffer = new StringMaker();
                        stringBuffer.append("Major authentication error - userName: ");
                        stringBuffer.append(this.userName);
                        stringBuffer.append(" Password: ");
                        stringBuffer.append(this.password);
                        stringBuffer.append(" Command: ");
                        stringBuffer.append(this.command);
                        this.logUtil.putF(stringBuffer.ToString(), this, this.tagStrings.DO_START_TAG);
                    }
                    if (string.CompareOrdinal(this.command, org.allbinary.globals.GLOBALS2.PROCESSBODYIFAUTHENTICATED) == 0) {
                        return TagSupport.SKIP_BODY;
                    } else {
                        return TagSupport.EVAL_BODY_INCLUDE;
                    }
                }
            }
            return SKIP_BODY;
        } catch (LicensingException e) {
            AbResponseHandler.sendJspTagLicensingRedirect(this.pageContext, e);
            return SKIP_BODY;
        } catch (Exception e) {
            AbResponseHandler.sendJspTagRedirect(this.pageContext, e);
            return SKIP_BODY;
        }
    }

}

