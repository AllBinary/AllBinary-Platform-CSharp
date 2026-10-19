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
//using IOException = java.io.IOException;
//using InputStream = java.io.InputStream;
using java.util;
//using ServletException = javax.servlet.ServletException;
//using HttpServlet = javax.servlet.http.HttpServlet;
//using HttpServletRequest = javax.servlet.http.HttpServletRequest;
//using HttpServletResponse = javax.servlet.http.HttpServletResponse;
using AuthenticationHelper = admin.taghelpers.AuthenticationHelper;
using AuthenticationHelperFactory = admin.taghelpers.AuthenticationHelperFactory;
using AuthenticationHelperUtil = admin.taghelpers.AuthenticationHelperUtil;
using URLGLOBALS = org.allbinary.globals.URLGLOBALS;
using StdUtil = org.allbinary.logic.StdUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CloudStreamUtil = org.allbinary.logic.io.CloudStreamUtil;
using StreamUtil = org.allbinary.logic.io.StreamUtil;
using AbFile = org.allbinary.logic.io.file.AbFile;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using BlisketServletUtil = org.allbinary.servlet.BlisketServletUtil;
using CommonSeps = org.allbinary.@string.CommonSeps;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.servlet.file;

public class DownloadFileServlet : HttpServlet
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private readonly string DOWNLOAD = "download";
    private readonly int DEFAULT_BUFFER_SIZE = 16384;
    // throws ServletException, IOException
    protected virtual void processRequest(HttpServletRequest request, HttpServletResponse response)
    {
        InputStream inputStream = null;
        try {
            BlisketServletUtil.getInstance().init(request);
            string requestPath = request.getRequestURI();
            if (requestPath == null) {
                response.sendError(HttpServletResponse.SC_NOT_FOUND);
                return;
            }
            int beginIndex = requestPath.IndexOf(this.DOWNLOAD);
            string filePath = StringUtil.getInstance().EMPTY_STRING;
            if (beginIndex >= 0) {
                filePath = requestPath.Substring(beginIndex + this.DOWNLOAD.Length);
            } else {
                response.sendError(HttpServletResponse.SC_NOT_FOUND);
            }
            AbFile file = AbFile.createAbFile(URLGLOBALS.getWebappPath() + filePath);
            if (!file.exists()) {
                response.sendError(HttpServletResponse.SC_NOT_FOUND);
                return;
            }
            HashMap hashMap = StdUtil.getInstance().createHashMap();
            AuthenticationHelper authenticationHelper = ((AuthenticationHelper) new AuthenticationHelperFactory().getInstance(hashMap, request));
            if (authenticationHelper.isAuthenticated()) {
                if (AuthenticationHelperUtil.getInstance().isAuthorized(authenticationHelper, filePath)) {
                    inputStream = CloudStreamUtil.getInstance().getFile(file);
                    string contentType = getServletContext().getMimeType(file.getName());
                    if (contentType == null) {
                        contentType = "application/octet-stream";
                    }
                    response.reset();
                    response.setBufferSize(this.DEFAULT_BUFFER_SIZE);
                    response.setContentType(contentType);
                    response.setHeader("Content-Length", (file.length()).ToString());
                    StringMaker stringBuffer = new StringMaker();
                    stringBuffer.append("attachment; filename=\"");
                    stringBuffer.append(file.getName());
                    stringBuffer.append(CommonSeps.getInstance().QUOTE);
                    response.setHeader("Content-Disposition", stringBuffer.ToString());
                    StreamUtil.getInstance().get(inputStream, response.getOutputStream(), new sbyte[16348]);
                } else {
                    response.sendError(HttpServletResponse.SC_UNAUTHORIZED, "You are not Authorized");
                }
            } else {
                response.sendError(HttpServletResponse.SC_UNAUTHORIZED, "Please Login");
            }
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEWERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "processRequest()", e);
            }
            response.sendError(HttpServletResponse.SC_NOT_FOUND);
        } finally {
            StreamUtil.getInstance().close(response.getOutputStream());
            if (!StreamUtil.getInstance().close(inputStream)) {
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
        return "Serves Up Cloud Files";
    }

}

