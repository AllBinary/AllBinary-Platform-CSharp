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
//using java.io;
//using java.net;
//using javax.servlet;
//using javax.servlet.http;
using LicensingException = org.allbinary.logic.system.security.licensing.LicensingException;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using WorkFlowInterface = org.allbinary.logic.control.workflow.WorkFlowInterface;
using RequestWorkFlowFactory = org.allbinary.logic.control.workflow.RequestWorkFlowFactory;

namespace servlet.request;

public class RequestHandler : HttpServlet
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    // throws ServletException
    public virtual void init(ServletConfig config)
    {
        base.init(config);
    }

    public virtual void destroy()
    {
    }

    // throws ServletException, IOException
    protected virtual void processRequest(HttpServletRequest request, HttpServletResponse response)
    {
        try {
            response.setContentType("text/html");
            PrintWriter @out = response.getWriter();
            WorkFlowInterface workflowInterface = RequestWorkFlowFactory.getInstance(((ServletRequest) request), ((ServletResponse) response), this.getServletConfig(), this.getServletContext());
            if (workflowInterface != null) {
                @out.print(workflowInterface.process());
            }
            @out.flush();
            @out.close();
        } catch (LicensingException e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SERVLETERROR)) {
                this.logUtil.put("Servlet LicensingException", this, "processRequest()", e);
            }
            response.sendRedirect(abcs.globals.URLGLOBALS.LICENSEERRORPAGE);
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SERVLETERROR)) {
                this.logUtil.put("Servlet Exception", this, "processRequest()", e);
            }
            response.sendRedirect(abcs.globals.URLGLOBALS.ERRORPAGE);
        }
    }

    // throws ServletException, IOException
    protected virtual void doGet(HttpServletRequest request, HttpServletResponse response)
    {
        this.processRequest(request, response);
    }

    // throws ServletException, IOException
    protected virtual void doPost(HttpServletRequest request, HttpServletResponse response)
    {
        this.processRequest(request, response);
    }

    public virtual string getServletInfo()
    {
        return "WorkFlow Request Handler";
    }

}

