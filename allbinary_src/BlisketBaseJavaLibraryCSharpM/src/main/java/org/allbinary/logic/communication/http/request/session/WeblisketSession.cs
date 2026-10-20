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
//using HttpSession = javax.servlet.http.HttpSession;
//using PageContext = javax.servlet.jsp.PageContext;
using StoreFrontData = org.allbinary.business.context.modules.storefront.StoreFrontData;
using StoreFrontFactory = org.allbinary.business.context.modules.storefront.StoreFrontFactory;
using StoreFrontInterface = org.allbinary.business.context.modules.storefront.StoreFrontInterface;
using UserData = org.allbinary.business.user.UserData;
using Basket = org.allbinary.business.user.commerce.inventory.basket.Basket;
using Order = org.allbinary.business.user.commerce.inventory.order.Order;
using OrderInterface = org.allbinary.business.user.commerce.inventory.order.OrderInterface;
using PaymentGatewayData = org.allbinary.business.user.commerce.money.payment.gateway.PaymentGatewayData;
using UserRole = org.allbinary.business.user.role.UserRole;
using UserRoleB = org.allbinary.business.user.role.UserRoleB;
using UserRoleData = org.allbinary.business.user.role.UserRoleData;
using BooleanFactory = org.allbinary.logic.java.@bool.BooleanFactory;
using StringValidationUtil = org.allbinary.logic.@string.StringValidationUtil;

namespace org.allbinary.logic.communication.http.request.session;

public class WeblisketSession : WeblisketSessionInterface
{
    private HttpSession session;
    public WeblisketSession(HashMap<object, object> hashMap, PageContext pageContext) : this(hashMap, ((HttpServletRequest) pageContext.getRequest()))
    {
        // this(hashMap, ((HttpServletRequest) pageContext.getRequest())) is called from the constructor declaration
    }

    public WeblisketSession(HashMap<object, object> hashMap, HttpServletRequest httpServletRequest)
    {
        HashMap<object, object> propertiesHashMap = hashMap;
        HttpServletRequest request = httpServletRequest;
        this.session = request.getSession(true);
        if (this.getStoreName() == null) {
            this.setStoreName(((string) propertiesHashMap.get(StoreFrontData.getInstance().NAME)));
        }
    }

    public virtual string getId()
    {
        return this.session.getId();
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

    public virtual void setRole(UserRole aRole)
    {
        this.session.setAttribute(UserRoleData.NAME.ToString(), aRole);
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

    // throws Exception
    public virtual UserRole getRole()
    {
        UserRole userRole = ((UserRole) this.session.getAttribute(UserRoleData.NAME.ToString()));
        if (userRole != null) {
            return UserRoleB.getRole(userRole.getBasicUserRole().getRole());
        } else {
            return null;
        }
    }

    // throws Exception
    public virtual OrderInterface getOrder()
    {
        StoreFrontInterface storeFrontInterface = StoreFrontFactory.getInstance(this.getStoreName());
        string basketName = storeFrontInterface.getBasketName();
        if (!StringValidationUtil.getInstance().isEmpty(basketName)) {
            OrderInterface orderInterface = ((OrderInterface) this.session.getAttribute(basketName));
            if (orderInterface == null) {
                orderInterface = ((OrderInterface) new Order(new Basket()));
            }
            this.session.setAttribute(basketName, orderInterface);
            return orderInterface;
        } else {
            throw new Exception("Basket Name Not Found");
        }
    }

    public virtual void setAuthenticated(bool value)
    {
        this.session.setAttribute(WeblisketSessionData.AUTHENTICATED, BooleanFactory.getInstance().FALSE_STRING);
    }

    public virtual void clear()
    {
        this.session.removeAttribute(WeblisketSessionData.AUTHENTICATED);
        this.session.removeAttribute(WeblisketSessionData.TIMEOUT);
        this.session.removeAttribute(UserRoleData.NAME.ToString());
        this.session.removeAttribute(UserData.USERNAME);
    }

    public virtual long getCreationTime()
    {
        return this.session.getCreationTime();
    }

    public virtual long getLastAccessedTime()
    {
        return this.session.getLastAccessedTime();
    }

    public virtual void removeBasket()
    {
        StoreFrontInterface storeFrontInterface = StoreFrontFactory.getInstance(this.getStoreName());
        string basketName = storeFrontInterface.getBasketName();
        if (!StringValidationUtil.getInstance().isEmpty(basketName)) {
            this.session.removeAttribute(basketName);
        }
    }

}

