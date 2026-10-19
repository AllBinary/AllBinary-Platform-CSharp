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
//using HttpServletRequest = javax.servlet.http.HttpServletRequest;
//using HttpSession = javax.servlet.http.HttpSession;
//using PageContext = javax.servlet.jsp.PageContext;
using StoreFrontData = org.allbinary.business.context.modules.storefront.StoreFrontData;
using UserData = org.allbinary.business.user.UserData;
using PaymentGatewayData = org.allbinary.business.user.commerce.money.payment.gateway.PaymentGatewayData;
using BasicUserRole = org.allbinary.business.user.role.BasicUserRole;
using BasicUserRoleData = org.allbinary.business.user.role.BasicUserRoleData;
using BooleanFactory = org.allbinary.logic.java.@bool.BooleanFactory;

namespace org.allbinary.logic.communication.http.request.session;

public class BasicWeblisketSession
{
    private HttpSession session;
    private PageContext pageContext;
    public BasicWeblisketSession(PageContext pageContext)
    {
        this.pageContext = pageContext;
        HttpServletRequest request = ((HttpServletRequest) pageContext.getRequest());
        this.session = request.getSession(true);
    }

    public virtual void setRole(BasicUserRole aRole)
    {
        this.session.setAttribute(BasicUserRoleData.NAME.ToString(), aRole);
    }

    public virtual BasicUserRole getRole()
    {
        return ((BasicUserRole) this.session.getAttribute(BasicUserRoleData.NAME.ToString()));
    }

    public virtual void setPassword(string password)
    {
        this.session.setAttribute(UserData.PASSWORD, password);
    }

    public virtual void setUserName(string userName)
    {
        this.session.setAttribute(UserData.USERNAME, userName);
    }

    public virtual void setPaymentMethod(string value)
    {
        this.session.setAttribute(PaymentGatewayData.NAME.ToString(), value);
    }

    public virtual void setAuthenticated()
    {
        this.session.setAttribute(WeblisketSessionData.AUTHENTICATED, BooleanFactory.getInstance().TRUE_STRING);
    }

    public virtual void setAttempts(int? value)
    {
        this.session.setAttribute(WeblisketSessionData.ATTEMPTS, value);
    }

    public virtual void setTimeout(string value)
    {
        this.session.setAttribute(WeblisketSessionData.TIMEOUT, value);
    }

    public virtual void setStoreName(string value)
    {
        this.session.setAttribute(StoreFrontData.getInstance().NAME, value);
    }

    public virtual string getWebAppPath()
    {
        return ((string) this.session.getAttribute(org.allbinary.globals.GLOBALS2.WEBAPPPATH));
    }

    public virtual string getUserName()
    {
        return ((string) this.session.getAttribute(UserData.USERNAME));
    }

    public virtual string getPassword()
    {
        return ((string) this.session.getAttribute(UserData.PASSWORD));
    }

    public virtual string getPaymentMethod()
    {
        return ((string) this.session.getAttribute(PaymentGatewayData.NAME.ToString()));
    }

    public virtual string getAuthentication()
    {
        return ((string) this.session.getAttribute(WeblisketSessionData.AUTHENTICATED));
    }

    public virtual int? getAttempts()
    {
        return ((int?) this.session.getAttribute(WeblisketSessionData.ATTEMPTS));
    }

    public virtual string getTimeout()
    {
        return ((string) this.session.getAttribute(WeblisketSessionData.TIMEOUT));
    }

    public virtual string getStoreName()
    {
        return ((string) this.session.getAttribute(StoreFrontData.getInstance().NAME));
    }

    public virtual void setAuthenticated(bool value)
    {
        this.session.setAttribute(WeblisketSessionData.AUTHENTICATED, BooleanFactory.getInstance().FALSE_STRING);
    }

    public virtual void clear()
    {
        this.session.removeAttribute(WeblisketSessionData.AUTHENTICATED);
        this.session.removeAttribute(WeblisketSessionData.TIMEOUT);
        this.session.removeAttribute(BasicUserRoleData.NAME.ToString());
        this.session.removeAttribute(UserData.USERNAME);
    }

    public virtual long getCreationTime()
    {
        return this.session.getCreationTime();
    }

    public virtual long getLastAccessedTime()
    {
        long lastAccessedTime = this.session.getLastAccessedTime();
        return lastAccessedTime;
    }

}

