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
//using ServletConfig = javax.servlet.ServletConfig;
//using ServletContext = javax.servlet.ServletContext;
//using ServletRequest = javax.servlet.ServletRequest;
//using ServletResponse = javax.servlet.ServletResponse;
//using HttpServletRequest = javax.servlet.http.HttpServletRequest;
//using PageContext = javax.servlet.jsp.PageContext;
using WorkFlowEntityFactory = org.allbinary.data.tables.workflow.WorkFlowEntityFactory;
using WeblisketSession = org.allbinary.logic.communication.http.request.session.WeblisketSession;
using AbPathData = org.allbinary.logic.io.path.AbPathData;
using LicensingException = org.allbinary.logic.system.security.licensing.LicensingException;

namespace org.allbinary.logic.control.workflow;

public class RequestWorkFlowFactory
{
    private RequestWorkFlowFactory()
    {
    }

    // throws Exception, LicensingException
    public static WorkFlowInterface getInstance(ServletRequest request, ServletResponse response, ServletConfig servletConfig, ServletContext servletContext)
    {
        HttpServletRequest httpRequest = ((HttpServletRequest) request);
        string requestCommand = httpRequest.getPathInfo();
        int index = requestCommand.IndexOf(AbPathData.getInstance().SEPARATOR);
        string storeName = requestCommand.Substring(0, (index) - (0));
        string requestName = requestCommand.Substring(index, (requestCommand.Length) - (index));
        return WorkFlowEntityFactory.getInstance().create2().get(requestName, storeName);
    }

    // throws Exception, LicensingException
    public static WorkFlowInterface getInstance(HashMap hashMap, PageContext pageContext)
    {
        string workFlowName = ((string) pageContext.getRequest().getParameter(WorkFlowData.getInstance().NAME));
        WeblisketSession weblisketSession = new WeblisketSession(hashMap, pageContext);
        string storeName = weblisketSession.getStoreName();
        return WorkFlowEntityFactory.getInstance().create2().get(workFlowName, storeName);
    }

}

