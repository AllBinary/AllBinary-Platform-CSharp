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
//using RequestDispatcher = javax.servlet.RequestDispatcher;
//using ServletException = javax.servlet.ServletException;
//using HttpServletRequest = javax.servlet.http.HttpServletRequest;
//using HttpServletResponse = javax.servlet.http.HttpServletResponse;
//using JspTagException = javax.servlet.jsp.JspTagException;
//using PageContext = javax.servlet.jsp.PageContext;
using FREEBLISKET_PATH_GLOBALS = org.allbinary.globals.FREEBLISKET_PATH_GLOBALS;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using LogConfigTypeFactory = org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory;
using LogConfigTypes = org.allbinary.logic.communication.log.config.type.LogConfigTypes;

namespace org.allbinary.logic.communication.http.request;

public class AbResponseHandler
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private AbResponseHandler()
    {
    }

    // throws JspTagException
    public static void sendJspTagRedirect(PageContext pageContext, Exception e)
    {
        LogUtil logUtil = LogUtil.getInstance();
        try {
            if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().JSPTAGERROR)) {
                logUtil.put("Jsp Tag Exception", "AbResponseHandler", "sendJspRedirect()", e);
            }
            AbResponseHandler.sendRedirect(pageContext, FREEBLISKET_PATH_GLOBALS.getInstance().ERRORPAGE);
        } catch (Exception e2) {
            if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().LICENSINGERROR)) {
                logUtil.put("Exception in Redirect Handling", "AbResponseHandler", "sendJspRedirect", e);
            }
            throw new JspTagException();
        }
    }

    // throws ServletException
    public static void sendServletRedirect(PageContext pageContext, Exception e)
    {
        LogUtil logUtil = LogUtil.getInstance();
        try {
            if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().JSPTAGERROR)) {
                logUtil.put("Jsp Tag Exception", "AbResponseHandler", "sendJspRedirect()", e);
            }
            AbResponseHandler.sendRedirect(pageContext, FREEBLISKET_PATH_GLOBALS.getInstance().ERRORPAGE);
        } catch (Exception e2) {
            if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().LICENSINGERROR)) {
                logUtil.put("Exception in Redirect Handling", "AbResponseHandler", "sendJspRedirect", e);
            }
            throw new ServletException();
        }
    }

    // throws JspTagException
    public static void sendJspTagLicensingRedirect(PageContext pageContext, Exception e)
    {
        LogUtil logUtil = LogUtil.getInstance();
        try {
            if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().JSPTAGERROR)) {
                logUtil.put("Licensing Exception", "AbResponseHandler", "sendJspTagLicensingRedirect()", e);
            }
            AbResponseHandler.sendRedirect(pageContext, FREEBLISKET_PATH_GLOBALS.getInstance().LICENSEERRORPAGE);
        } catch (Exception e2) {
            if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().LICENSINGERROR)) {
                logUtil.put("Exception in Redirect Handling", "AbResponseHandler", "sendJspTagLicensingRedirect", e);
            }
            throw new JspTagException();
        }
    }

    // throws ServletException
    public static void sendServletLicensingRedirect(PageContext pageContext, Exception e)
    {
        LogUtil logUtil = LogUtil.getInstance();
        try {
            if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().JSPTAGERROR)) {
                logUtil.put("Licensing Exception", "AbResponseHandler", "sendServletLicensingRedirect()", e);
            }
            AbResponseHandler.sendRedirect(pageContext, FREEBLISKET_PATH_GLOBALS.getInstance().LICENSEERRORPAGE);
        } catch (Exception e2) {
            if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().LICENSINGERROR)) {
                logUtil.put("Exception in Redirect Handling", "AbResponseHandler", "sendServletLicensingRedirect", e);
            }
            throw new ServletException();
        }
    }

    // throws Exception
    public static void sendRedirect(PageContext pageContext, string page)
    {
        HttpServletRequest request = ((HttpServletRequest) pageContext.getRequest());
        HttpServletResponse response = ((HttpServletResponse) pageContext.getResponse());
        RequestDispatcher requestDispatcher = request.getRequestDispatcher(page);
        if (response.isCommitted()) {
            response.sendRedirect(page);
        } else {
            try {
                requestDispatcher.forward(request, response);
            } catch (Exception e) {
                pageContext.getOut().print("Error: " + page);
            }
        }
    }

}

