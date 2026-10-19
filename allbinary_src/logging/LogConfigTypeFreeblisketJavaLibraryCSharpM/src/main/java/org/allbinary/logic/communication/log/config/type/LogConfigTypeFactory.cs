/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2022 AllBinary 
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
using PreLogUtil = org.allbinary.logic.communication.log.PreLogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.logic.communication.log.config.type;

public class LogConfigTypeFactory
{
    private static readonly LogConfigTypeFactory instance = new LogConfigTypeFactory();
    public static LogConfigTypeFactory getInstance()
    {
        return LogConfigTypeFactory.instance;
    }

    private readonly string NO_DESCRIPTION = "No Description";
    public readonly LogConfigType AUTHENTICATION;
    public readonly LogConfigType AUTHENTICATIONERROR;
    public readonly LogConfigType CATEGORY;
    public readonly LogConfigType CATEGORYERROR;
    public readonly LogConfigType CRYPT;
    public readonly LogConfigType CRYPTERROR;
    public readonly LogConfigType EMAILLOGGING;
    public readonly LogConfigType EMAILLOGGINGERROR;
    public readonly LogConfigType ENTITYFACTORYERROR;
    public readonly LogConfigType NETBEANS_MODULE;
    public readonly LogConfigType NETBEANS_MODULE_ERROR;
    public readonly LogConfigType FACTORYERROR;
    public readonly LogConfigType FILE;
    public readonly LogConfigType FILEERROR;
    public readonly LogConfigType HTTP;
    public readonly LogConfigType HTTPERROR;
    public readonly LogConfigType HTTPREQUEST;
    public readonly LogConfigType HTTPREQUESTERROR;
    public readonly LogConfigType IDLOGGING;
    public readonly LogConfigType JSPEXTRAOUTPUT;
    public readonly LogConfigType JSPTAGEXTRAOUTPUT;
    public readonly LogConfigType JSPTAG;
    public readonly LogConfigType JSPTAGERROR;
    public readonly LogConfigType LICENSING;
    public readonly LogConfigType LICENSINGERROR;
    public readonly LogConfigType LOADER;
    public readonly LogConfigType LOADERERROR;
    public readonly LogConfigType OS;
    public readonly LogConfigType OSERROR;
    public readonly LogConfigType PAYMENT;
    public readonly LogConfigType PAYMENTERROR;
    public readonly LogConfigType PRELOADER;
    public readonly LogConfigType PRELOADERERROR;
    public readonly LogConfigType PRODUCTSEARCHLOGGING;
    public readonly LogConfigType PRODUCTSEARCHLOGGINGERROR;
    public readonly LogConfigType SERVLET;
    public readonly LogConfigType SERVLETERROR;
    public readonly LogConfigType SHIPPINGERROR;
    public readonly LogConfigType SQLLOGGINGERROR;
    public readonly LogConfigType SQLLOGGING;
    public readonly LogConfigType SQLTAGS;
    public readonly LogConfigType SQLTAGSERROR;
    public readonly LogConfigType STYLE;
    public readonly LogConfigType STYLEERROR;
    public readonly LogConfigType TAGHELPER;
    public readonly LogConfigType TAGHELPERERROR;
    public readonly LogConfigType TAGHELPERFACTORY;
    public readonly LogConfigType TAGHELPERFACTORYERROR;
    public readonly LogConfigType TAX;
    public readonly LogConfigType TAXERROR;
    public readonly LogConfigType VALIDATION;
    public readonly LogConfigType VALIDATIONERROR;
    public readonly LogConfigType VIEW;
    public readonly LogConfigType VIEWERROR;
    public readonly LogConfigType VIEWFACTORYERROR;
    public readonly LogConfigType WORKFLOW;
    public readonly LogConfigType WORKFLOWERROR;
    public readonly LogConfigType XMLLOGGING;
    public readonly LogConfigType XMLLOGGINGERROR;
    public readonly LogConfigType XSLLOGGING;
    public readonly LogConfigType XSLLOGGINGERROR;
    public readonly LogConfigType REPLACE;
    public readonly LogConfigType REPLACE_INFO;
    public readonly LogConfigType REPLACEERROR;
    public readonly LogConfigType SQLLOGGINGPOOL;
    public readonly LogConfigType SQLLOGGINGPOOLERROR;
    public readonly LogConfigType STATICPAGEGENERATIONLOGGING;
    public readonly LogConfigType STATICPAGEGENERATIONLOGGINGERROR;
    private LogConfigTypeFactory()
    {
        this.AUTHENTICATION = new LogConfigType("Authentication", this.NO_DESCRIPTION);
        this.AUTHENTICATIONERROR = new LogConfigType("Authentication Error", this.NO_DESCRIPTION);
        this.CATEGORY = new LogConfigType("Category", this.NO_DESCRIPTION);
        this.CATEGORYERROR = new LogConfigType("Category Error", this.NO_DESCRIPTION);
        this.CRYPT = new LogConfigType("Crypt", this.NO_DESCRIPTION);
        this.CRYPTERROR = new LogConfigType("Crypt Error", this.NO_DESCRIPTION);
        this.EMAILLOGGING = new LogConfigType("Email", this.NO_DESCRIPTION);
        this.EMAILLOGGINGERROR = new LogConfigType("Email Error", this.NO_DESCRIPTION);
        this.ENTITYFACTORYERROR = new LogConfigType("Entity Factory Error", this.NO_DESCRIPTION);
        this.NETBEANS_MODULE = new LogConfigType("NetBeans Module", this.NO_DESCRIPTION);
        this.NETBEANS_MODULE_ERROR = new LogConfigType("NetBeans Module Error", this.NO_DESCRIPTION);
        this.FACTORYERROR = new LogConfigType("General Factory Error", this.NO_DESCRIPTION);
        this.FILE = new LogConfigType("File", this.NO_DESCRIPTION);
        this.FILEERROR = new LogConfigType("File Error", this.NO_DESCRIPTION);
        this.HTTP = new LogConfigType("HTTP", this.NO_DESCRIPTION);
        this.HTTPERROR = new LogConfigType("HTTP Error", this.NO_DESCRIPTION);
        this.HTTPREQUEST = new LogConfigType("Http Request", this.NO_DESCRIPTION);
        this.HTTPREQUESTERROR = new LogConfigType("Http Request Error", this.NO_DESCRIPTION);
        this.IDLOGGING = new LogConfigType("ID Logging", this.NO_DESCRIPTION);
        this.JSPEXTRAOUTPUT = new LogConfigType("JSP Extra Output", this.NO_DESCRIPTION);
        this.JSPTAGEXTRAOUTPUT = new LogConfigType("JSP Tag Extra Output", this.NO_DESCRIPTION);
        this.JSPTAG = new LogConfigType("JSP Tag", this.NO_DESCRIPTION);
        this.JSPTAGERROR = new LogConfigType("JSP Tag Error", this.NO_DESCRIPTION);
        this.LICENSING = new LogConfigType("Licensing", this.NO_DESCRIPTION);
        this.LICENSINGERROR = new LogConfigType("Licensing Error", this.NO_DESCRIPTION);
        this.LOADER = new LogConfigType("Loader", this.NO_DESCRIPTION);
        this.LOADERERROR = new LogConfigType("Loader Error", this.NO_DESCRIPTION);
        this.OS = new LogConfigType("OS", this.NO_DESCRIPTION);
        this.OSERROR = new LogConfigType("OS Error", this.NO_DESCRIPTION);
        this.PAYMENT = new LogConfigType("Payment", this.NO_DESCRIPTION);
        this.PAYMENTERROR = new LogConfigType("Payment Error", this.NO_DESCRIPTION);
        this.PRELOADER = new LogConfigType("PreLoader", this.NO_DESCRIPTION);
        this.PRELOADERERROR = new LogConfigType("PreLoader Error", this.NO_DESCRIPTION);
        this.PRODUCTSEARCHLOGGING = new LogConfigType("Product Search Logging", this.NO_DESCRIPTION);
        this.PRODUCTSEARCHLOGGINGERROR = new LogConfigType("Product Search Logging Error", this.NO_DESCRIPTION);
        this.SERVLET = new LogConfigType("Servlet", this.NO_DESCRIPTION);
        this.SERVLETERROR = new LogConfigType("Servlet Error", this.NO_DESCRIPTION);
        this.SHIPPINGERROR = new LogConfigType("Shipping Error", this.NO_DESCRIPTION);
        this.SQLLOGGINGERROR = new LogConfigType("SQL Error", this.NO_DESCRIPTION);
        this.SQLLOGGING = new LogConfigType("SQL Logging", this.NO_DESCRIPTION);
        this.SQLTAGS = new LogConfigType("SQL Tag Logging", this.NO_DESCRIPTION);
        this.SQLTAGSERROR = new LogConfigType("SQL Tag Error", this.NO_DESCRIPTION);
        this.STYLE = new LogConfigType("Style", this.NO_DESCRIPTION);
        this.STYLEERROR = new LogConfigType("Style Error", this.NO_DESCRIPTION);
        this.TAGHELPER = new LogConfigType("Tag Helper", this.NO_DESCRIPTION);
        this.TAGHELPERERROR = new LogConfigType("Tag Helper Error", this.NO_DESCRIPTION);
        this.TAGHELPERFACTORY = new LogConfigType("Tag Helper Factory", this.NO_DESCRIPTION);
        this.TAGHELPERFACTORYERROR = new LogConfigType("Tag Helper Factory Error", this.NO_DESCRIPTION);
        this.TAX = new LogConfigType("Tax", this.NO_DESCRIPTION);
        this.TAXERROR = new LogConfigType("Tax Error", this.NO_DESCRIPTION);
        this.VALIDATION = new LogConfigType("Validation", this.NO_DESCRIPTION);
        this.VALIDATIONERROR = new LogConfigType("Validation Error", this.NO_DESCRIPTION);
        this.VIEW = new LogConfigType("View", this.NO_DESCRIPTION);
        this.VIEWERROR = new LogConfigType("View Error", this.NO_DESCRIPTION);
        this.VIEWFACTORYERROR = new LogConfigType("View Factory Error", this.NO_DESCRIPTION);
        this.WORKFLOW = new LogConfigType("Workflow", this.NO_DESCRIPTION);
        this.WORKFLOWERROR = new LogConfigType("Workflow Error", this.NO_DESCRIPTION);
        this.XMLLOGGING = new LogConfigType("XML Logging", this.NO_DESCRIPTION);
        this.XMLLOGGINGERROR = new LogConfigType("XML Logging Error", this.NO_DESCRIPTION);
        this.XSLLOGGING = new LogConfigType("XSL Logging", this.NO_DESCRIPTION);
        this.XSLLOGGINGERROR = new LogConfigType("XSL Logging Error", this.NO_DESCRIPTION);
        this.REPLACE = new LogConfigType("Replace", this.NO_DESCRIPTION);
        this.REPLACE_INFO = new LogConfigType("Replace Info", this.NO_DESCRIPTION);
        this.REPLACEERROR = new LogConfigType("Replace Error", this.NO_DESCRIPTION);
        this.SQLLOGGINGPOOL = new LogConfigType("SQL Pool", this.NO_DESCRIPTION);
        this.SQLLOGGINGPOOLERROR = new LogConfigType("SQL Pool Error", this.NO_DESCRIPTION);
        this.STATICPAGEGENERATIONLOGGING = new LogConfigType("Static Page Generation Logging", this.NO_DESCRIPTION);
        this.STATICPAGEGENERATIONLOGGINGERROR = new LogConfigType("Static Page Generation Logging Error", this.NO_DESCRIPTION);
        PreLogUtil.put("FreeBlisket", this, CommonStrings.getInstance().CONSTRUCTOR);
    }

}

