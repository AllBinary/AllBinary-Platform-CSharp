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
//using ByteArrayOutputStream = java.io.ByteArrayOutputStream;
//using IOException = java.io.IOException;
//using InputStream = java.io.InputStream;
//using ServletException = javax.servlet.ServletException;
//using HttpServlet = javax.servlet.http.HttpServlet;
//using HttpServletRequest = javax.servlet.http.HttpServletRequest;
//using HttpServletResponse = javax.servlet.http.HttpServletResponse;
using URLGLOBALS = org.allbinary.globals.URLGLOBALS;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CloudStreamUtil = org.allbinary.logic.io.CloudStreamUtil;
using StreamUtil = org.allbinary.logic.io.StreamUtil;
using AbFile = org.allbinary.logic.io.file.AbFile;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.servlet;

public class ImageServlet : HttpServlet
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    // throws ServletException, IOException
    protected virtual void processRequest(HttpServletRequest request, HttpServletResponse response)
    {
        InputStream inputStream = null;
        try {
            BlisketServletUtil.getInstance().init(request);
            string requestURI = request.getRequestURI();
            AbFile file = AbFile.createAbFile(URLGLOBALS.getWebappPath() + requestURI);
            inputStream = CloudStreamUtil.getInstance().getFileLocal(file);
            System.IO.MemoryStream outputStream = new System.IO.MemoryStream(8000);
            sbyte[] byteArray = StreamUtil.getInstance().getByteArray(inputStream, outputStream, new sbyte[16384]);
            response.setContentType("image/jpeg;charset=utf-8");
            response.getOutputStream().write(byteArray);
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEWERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "processRequest()", e);
            }
        } finally {
            StreamUtil.getInstance().close(response.getOutputStream());
            if (!StreamUtil.getInstance().close(inputStream)) {
                response.sendError(HttpServletResponse.SC_NOT_FOUND);
            }
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
        return "Serves Up Image";
    }

}

