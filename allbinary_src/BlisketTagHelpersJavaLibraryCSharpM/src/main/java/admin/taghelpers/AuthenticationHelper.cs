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
using Calendar = java.util.Calendar;
using java.util;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
//using HttpServletRequest = javax.servlet.http.HttpServletRequest;
//using PageContext = javax.servlet.jsp.PageContext;
//using TagSupport = javax.servlet.jsp.tagext.TagSupport;
using UserInterface = org.allbinary.business.user.UserInterface;
using BasicUserRole = org.allbinary.business.user.role.BasicUserRole;
using UserRole = org.allbinary.business.user.role.UserRole;
using UserRoleFactory = org.allbinary.business.user.role.UserRoleFactory;
using UserEntityFactory = org.allbinary.data.tables.user.UserEntityFactory;
using UserEntityInterface = org.allbinary.data.tables.user.UserEntityInterface;
using GLOBALS2 = org.allbinary.globals.GLOBALS2;
using WeblisketSession = org.allbinary.logic.communication.http.request.session.WeblisketSession;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using BooleanFactory = org.allbinary.logic.java.@bool.BooleanFactory;
using BooleanUtil = org.allbinary.logic.java.@bool.BooleanUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;

namespace admin.taghelpers;

public class AuthenticationHelper : TagHelper
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private WeblisketSession weblisketSession;
    private string authenticated = null;
    private string sessionUserName = null;
    private UserRole role = null;
    private string timeout = null;
    private int? attemptsInteger = null;
    public AuthenticationHelper(HashMap<object, object> hashMap, PageContext pageContext) : this(hashMap, ((HttpServletRequest) pageContext.getRequest()))
    {
        // this(hashMap, ((HttpServletRequest) pageContext.getRequest())) is called from the constructor declaration
    }

    public AuthenticationHelper(HashMap<object, object> hashMap, HttpServletRequest httpServletRequest)
    {
        this.weblisketSession = new WeblisketSession(hashMap, httpServletRequest);
        this.getFormData();
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().AUTHENTICATION)) {
            this.logUtil.putF(this.outputSessionInfo(), this, this.commonStrings.CONSTRUCTOR);
        }
    }

    // throws Exception
    private void getFormData()
    {
        this.authenticated = this.weblisketSession.getAuthentication();
        this.sessionUserName = this.weblisketSession.getUserName();
        this.role = this.weblisketSession.getRole();
        this.attemptsInteger = this.weblisketSession.getAttempts();
        this.timeout = this.weblisketSession.getTimeout();
    }

    // throws Exception
    public virtual int? invalidateSession()
    {
        try {
            this.weblisketSession.clear();
            return TagSupport.EVAL_BODY_INCLUDE;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().AUTHENTICATIONERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "invalidateSession()", e);
            }
            return null;
        }
    }

    public virtual bool? isSessionOld()
    {
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
    }

    private bool? isRarelyUsedSession()
    {
        if (this.role != null) {
            long timeCreated = this.weblisketSession.getCreationTime();
            long lastAccess = this.weblisketSession.getLastAccessedTime();
            long inactivityAllowed = this.role.getSessionInactivityTimeout();
            Calendar calendar = Calendar.getInstance();
            long timeFirst = calendar.getTimeInMillis() - lastAccess;
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().AUTHENTICATION)) {
                StringMaker stringBuffer = new StringMaker();
                stringBuffer.append("Session Is Rarely Used - Timeout: ");
                stringBuffer.appendlong(lastAccess);
                stringBuffer.append(" Eval: ");
                stringBuffer.appendlong(timeFirst);
                stringBuffer.append(" > ");
                stringBuffer.appendlong(inactivityAllowed);
                this.logUtil.putF(stringBuffer.ToString(), this, "isRarelyUsedSession()");
            }
        } else {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().AUTHENTICATION)) {
                this.logUtil.putF("Role Is Not In Session", this, "isRarelyUsedSession()");
            }
        }
        return false;
    }

    public virtual string validRole()
    {
        try {
            StringMaker stringBuffer = new StringMaker();
            stringBuffer.append("Trying New login<p/>");
            return stringBuffer.ToString();
        } catch (Exception e) {
            string error = "Failed to set valid role";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().AUTHENTICATIONERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "validRole()", e);
            }
            return error;
        }
    }

    public virtual string invalidRole()
    {
        try {
            this.weblisketSession.setAuthenticated(false);
            StringMaker stringBuffer = new StringMaker();
            stringBuffer.append("Sorry your username and password is invalid on this page. ");
            stringBuffer.append("Trying New login<p/>");
            return stringBuffer.ToString();
        } catch (Exception e) {
            string error = "Failed to set role invalid";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().AUTHENTICATIONERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "invalidRole()", e);
            }
            return error;
        }
    }

    // throws Exception
    public virtual bool isAuthenticated()
    {
        if (BooleanUtil.getInstance().getFromString(this.authenticated)) {
            return true;
        } else {
            return false;
        }
    }

    public virtual bool? isAuthenticationSessionValid(BasicArrayList roles)
    {
        try {
            if (this.role != null) {
                if (this.isAuthenticated()) {
                    if (this.sessionUserName != null) {
                        BasicUserRole basicUserRole = this.role.getBasicUserRole();
                        object[] basicUserRoleArray = roles.toArray();
                        int size = basicUserRoleArray.Length;
                        for (int index = 0; index < size; index++) {
                            BasicUserRole mustBeOfRole = ((BasicUserRole) basicUserRoleArray[index]);
                            if (basicUserRole.Equals(mustBeOfRole)) {
                                if (basicUserRole.Equals(UserRoleFactory.getInstance().CUSTOMER)) {
                                    UserEntityInterface userEntityInterface = UserEntityFactory.getInstance();
                                    UserInterface userInterface = userEntityInterface.getUser(this.sessionUserName);
                                    if (!userInterface.isSessionValid()) {
                                        return false;
                                    }
                                }
                                return true;
                            }
                        }
                    }
                    return false;
                }
            } else {
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().AUTHENTICATION)) {
                    this.logUtil.putF("Role Is Not In Session", this, "isAuthenticationSessionValid()");
                }
            }
            return false;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().AUTHENTICATIONERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "isAuthenticatedSessionValid()", e);
            }
            return false;
        }
    }

    public virtual void nextAttempt()
    {
        if (this.attemptsInteger != null && ((int) this.attemptsInteger) > 0) {
            this.weblisketSession.setAttempts(((int) this.attemptsInteger) + 1);
        } else {
            this.weblisketSession.setAttempts(1);
        }
    }

    public virtual bool? processIfNewLogin(string userName, string password)
    {
        try {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().AUTHENTICATIONERROR)) {
                this.logUtil.putF("Starting: " + userName, this, "processIfNewLogin()");
            }
            if (userName != null && string.CompareOrdinal(userName, StringUtil.getInstance().EMPTY_STRING) != 0 && password != null && string.CompareOrdinal(password, StringUtil.getInstance().EMPTY_STRING) != 0) {
                string login = null;
                UserEntityInterface userEntityInterface = UserEntityFactory.getInstance();
                login = userEntityInterface.login(userName, password);
                if (string.CompareOrdinal(login, GLOBALS2.LOGINSUCCESS) == 0) {
                    UserInterface userInterface = userEntityInterface.getUser(userName);
                    if (userInterface.isSessionValid()) {
                        this.weblisketSession.setAttempts(0);
                        return true;
                    }
                }
                this.nextAttempt();
                return false;
            }
            this.nextAttempt();
            return false;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().AUTHENTICATIONERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "processIfNewLogin()", e);
            }
            return false;
        }
    }

    public virtual bool? processInvalidation()
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
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().AUTHENTICATIONERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "processInvalidation()", e);
            }
            return false;
        }
    }

    public virtual string outputSessionInfo()
    {
        try {
            Calendar calendar = Calendar.getInstance();
            long timeCreated = this.weblisketSession.getCreationTime();
            StringMaker stringBuffer = new StringMaker();
            long lastAccess = this.weblisketSession.getLastAccessedTime();
            stringBuffer.append("Time Since Last Access: " + (calendar.getTimeInMillis() - lastAccess) + "<br/>\n");
            if (this.role != null) {
                stringBuffer.append("Auth: ");
                stringBuffer.append(this.authenticated);
                stringBuffer.append(" UserName: ");
                stringBuffer.append(this.sessionUserName);
                stringBuffer.append(" Role: ");
                stringBuffer.append(this.role.ToString());
                stringBuffer.append("<br/>\n");
                stringBuffer.append("Time Left: ");
                stringBuffer.appendlong(((long) (this.role.getSessionTimeout() - (calendar.getTimeInMillis() - timeCreated))));
                stringBuffer.append("<br/>\n");
                stringBuffer.append("Inactivity Time Allowed: ");
                stringBuffer.appendlong(((long) this.role.getSessionTimeout()));
                stringBuffer.append("<br/>\n");
                stringBuffer.append("Inactivity Time Allowed: ");
                stringBuffer.appendlong(((long) this.role.getSessionInactivityTimeout()));
                stringBuffer.append("<br/>\n");
            } else {
                stringBuffer.append("Role Is Not Set<br/>\n");
            }
            return stringBuffer.ToString();
        } catch (Exception e) {
            return "Error";
        }
    }

    public virtual UserRole getRole()
    {
        return this.role;
    }

}

