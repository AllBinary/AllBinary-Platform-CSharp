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
//using Method = java.lang.reflect.Method;
using java.util;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
//using HttpServletRequest = javax.servlet.http.HttpServletRequest;
//using JspTagException = javax.servlet.jsp.JspTagException;
//using TagSupport = javax.servlet.jsp.tagext.TagSupport;
using AuthenticationHelperFactory = admin.taghelpers.AuthenticationHelperFactory;
using AuthenticationRequestHelperFactory = admin.taghelpers.AuthenticationRequestHelperFactory;
using StdUtil = org.allbinary.logic.StdUtil;
using AbResponseHandler = org.allbinary.logic.communication.http.request.AbResponseHandler;
using WeblisketSessionData = org.allbinary.logic.communication.http.request.session.WeblisketSessionData;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using LicensingException = org.allbinary.logic.system.security.licensing.LicensingException;
using CustomTagSupport = tags.CustomTagSupport;

namespace admin.tags;

public class AuthenticationTag : CustomTagSupport
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private string command = null;
    private string userName;
    private string password;
    private string newPassword = null;
    private BasicArrayList roles = null;
    private HashMap<object, object> propertiesHashMap = null;
    public AuthenticationTag()
    {
        StringUtil stringUtil = StringUtil.getInstance();
        this.userName = stringUtil.EMPTY_STRING;
        this.password = stringUtil.EMPTY_STRING;
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

    // throws LicensingException
    private bool changePassword()
    {
        try {
            object anyType = new AuthenticationRequestHelperFactory().getInstance(this.propertiesHashMap, this.pageContext);
            Type addressHelperClass = anyType.GetType();
            Method method = addressHelperClass.getMethod("changePassword", null);
            bool? result = ((bool?) method.invoke(anyType, null));
            return result.Value;
        } catch (LicensingException e) {
            throw e;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().JSPTAGERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "changePassword()", e);
            }
            return false;
        }
    }

    // throws LicensingException
    private bool newPassword()
    {
        try {
            object anyType = new AuthenticationRequestHelperFactory().getInstance(this.propertiesHashMap, this.pageContext);
            Type addressHelperClass = anyType.GetType();
            Method method = addressHelperClass.getMethod("newPassword", null);
            bool? result = ((bool?) method.invoke(anyType, null));
            return result.Value;
        } catch (LicensingException e) {
            throw e;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().JSPTAGERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "newPassword()", e);
            }
            return false;
        }
    }

    // throws LicensingException
    private int invalidateSession()
    {
        try {
            object anyType = new AuthenticationHelperFactory().getInstance(this.propertiesHashMap, this.pageContext);
            Type addressHelperClass = anyType.GetType();
            Method method = addressHelperClass.getMethod("invalidateSession", null);
            int? resultInteger = ((int?) method.invoke(anyType, null));
            return ((int) resultInteger);
        } catch (LicensingException e) {
            throw e;
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
            object anyType = new AuthenticationHelperFactory().getInstance(this.propertiesHashMap, this.pageContext);
            Type helperClass = anyType.GetType();
            Method method = helperClass.getMethod("isSessionOld", null);
            bool? resultBoolean = ((bool?) method.invoke(anyType, null));
            return resultBoolean.Value;
        } catch (LicensingException e) {
            throw e;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().JSPTAGERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "isSessionOld()", e);
            }
            return false;
        }
    }

    // throws LicensingException
    private bool isRoleValid()
    {
        try {
            object anyType = new AuthenticationRequestHelperFactory().getInstance(this.propertiesHashMap, this.pageContext);
            Type addressHelperClass = anyType.GetType();
            Type[] methodParams = new Type[] { this.userName.GetType(), this.password.GetType(), this.roles.GetType() };
            Method method = addressHelperClass.getMethod("isRoleValid", methodParams);
            object[] methodArgs = new object[] { this.userName, this.password, this.roles };
            bool? resultBoolean = ((bool?) method.invoke(anyType, methodArgs));
            return resultBoolean.Value;
        } catch (LicensingException e) {
            throw e;
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
            object anyType = new AuthenticationHelperFactory().getInstance(this.propertiesHashMap, this.pageContext);
            Type addressHelperClass = anyType.GetType();
            Method method = addressHelperClass.getMethod("validRole", null);
            string result = ((string) method.invoke(anyType, null));
            return result;
        } catch (LicensingException e) {
            throw e;
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
            object anyType = new AuthenticationHelperFactory().getInstance(this.propertiesHashMap, this.pageContext);
            Type addressHelperClass = anyType.GetType();
            Method method = addressHelperClass.getMethod("invalidRole", null);
            string result = ((string) method.invoke(anyType, null));
            return result;
        } catch (LicensingException e) {
            throw e;
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
            object anyType = new AuthenticationHelperFactory().getInstance(this.propertiesHashMap, this.pageContext);
            Type addressHelperClass = anyType.GetType();
            Type[] methodParams = new Type[] { this.roles.GetType() };
            Method method = addressHelperClass.getMethod("isAuthenticationSessionValid", methodParams);
            object[] methodArgs = new object[] { this.roles };
            bool? resultBoolean = ((bool?) method.invoke(anyType, methodArgs));
            return resultBoolean.Value;
        } catch (LicensingException e) {
            throw e;
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
            object anyType = new AuthenticationHelperFactory().getInstance(this.propertiesHashMap, this.pageContext);
            Type helperClass = anyType.GetType();
            Type[] methodParams = new Type[] { this.userName.GetType(), this.password.GetType() };
            Method method = helperClass.getMethod("processIfNewLogin", methodParams);
            object[] methodArgs = new object[] { this.userName, this.password };
            bool? resultBoolean = ((bool?) method.invoke(anyType, methodArgs));
            return resultBoolean.Value;
        } catch (LicensingException e) {
            throw e;
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
            object anyType = new AuthenticationHelperFactory().getInstance(this.propertiesHashMap, this.pageContext);
            Type addressHelperClass = anyType.GetType();
            Method method = addressHelperClass.getMethod("processInvalidation", null);
            bool? resultBoolean = ((bool?) method.invoke(anyType, null));
            return resultBoolean.Value;
        } catch (LicensingException e) {
            throw e;
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
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().JSPTAG)) {
                HttpServletRequest request = ((HttpServletRequest) this.pageContext.getRequest());
                StringMaker stringBuffer = new StringMaker();
                stringBuffer.append(" Request URI: ");
                stringBuffer.append(request.getRequestURI());
                this.logUtil.putF(stringBuffer.ToString(), this, tagStrings.DO_START_TAG);
            }
            if (this.command != null) {
                this.propertiesHashMap = StdUtil.getInstance().createHashMap();
                if (string.CompareOrdinal(this.command, org.allbinary.globals.GLOBALS2.NEWPASSWORD) == 0) {
                    if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().JSPTAG)) {
                        this.logUtil.putF("New Password", this, tagStrings.DO_START_TAG);
                    }
                    if (!this.newPassword()) {
                        pageContext.getOut().print("New Password Request Failed.<p/>");
                        return EVAL_BODY_INCLUDE;
                    } else {
                        pageContext.getOut().print("New Password Was Sent.<p/>");
                        return SKIP_BODY;
                    }
                } else if (string.CompareOrdinal(this.command, org.allbinary.globals.GLOBALS2.CHANGEPASSWORD) == 0) {
                    if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().JSPTAG)) {
                        this.logUtil.putF("Change Password", this, tagStrings.DO_START_TAG);
                    }
                    if (!this.changePassword()) {
                        pageContext.getOut().print("Password Change Attempt Failed.<p/>");
                        return EVAL_BODY_INCLUDE;
                    } else {
                        pageContext.getOut().print("Password Changed Successfully.<p/>");
                        return SKIP_BODY;
                    }
                } else if (string.CompareOrdinal(this.command, WeblisketSessionData.INVALIDATESESSION) == 0) {
                    if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().JSPTAG)) {
                        this.logUtil.putF("INVALIDATESESSION", this, tagStrings.DO_START_TAG);
                    }
                    return this.invalidateSession();
                } else {
                    if (this.isSessionOld()) {
                        if (this.processInvalidation()) {
                            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().JSPTAG)) {
                                this.logUtil.putF("Processing Invalidation", this, tagStrings.DO_START_TAG);
                            }
                            pageContext.getOut().print("Please login again.<p>");
                            if (string.CompareOrdinal(this.command, org.allbinary.globals.GLOBALS2.PROCESSBODYIFAUTHENTICATED) == 0) {
                                return TagSupport.SKIP_BODY;
                            } else {
                                return TagSupport.EVAL_BODY_INCLUDE;
                            }
                        } else {
                            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().JSPTAG)) {
                                this.logUtil.putF("Preparing session for invalidation", this, tagStrings.DO_START_TAG);
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
                            this.logUtil.putF("Authenticated session is valid", this, tagStrings.DO_START_TAG);
                        }
                        if (string.CompareOrdinal(this.command, org.allbinary.globals.GLOBALS2.PROCESSBODYIFAUTHENTICATED) == 0) {
                            return TagSupport.EVAL_BODY_INCLUDE;
                        } else {
                            return TagSupport.SKIP_BODY;
                        }
                    }
                    if (this.userName != null && this.password != null && this.processIfNewLogin()) {
                        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().JSPTAG)) {
                            this.logUtil.putF("Processing new login.", this, tagStrings.DO_START_TAG);
                        }
                        if (this.isRoleValid()) {
                            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().JSPTAG)) {
                                this.logUtil.putF("Role is valid - Processing new login", this, tagStrings.DO_START_TAG);
                            }
                            pageContext.getOut().print(validRole());
                            if (string.CompareOrdinal(this.command, org.allbinary.globals.GLOBALS2.PROCESSBODYIFAUTHENTICATED) == 0) {
                                return EVAL_BODY_INCLUDE;
                            } else {
                                return SKIP_BODY;
                            }
                        } else {
                            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().JSPTAG)) {
                                this.logUtil.putF("Role is not valid - Processing new login", this, tagStrings.DO_START_TAG);
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
                            this.logUtil.putF("Invalid Login", this, tagStrings.DO_START_TAG);
                        }
                        if (this.userName != null && string.CompareOrdinal(this.userName, stringUtil.EMPTY_STRING) != 0 && this.password != null && string.CompareOrdinal(this.password, stringUtil.EMPTY_STRING) != 0) {
                            pageContext.getOut().print("Sorry your username and/or password is invalid.<p/>");
                        }
                    }
                    if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().JSPTAG)) {
                        this.logUtil.putF(new StringMaker().append("Major authentication error - userName: ").append(this.userName).append(" Password: ").append(this.password).append(" Command: ").append(this.command).ToString(), this, tagStrings.DO_START_TAG);
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

