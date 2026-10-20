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
using FileUploadData = org.allbinary.logic.communication.http.file.upload.FileUploadData;
using HttpFileUploadUtil = org.allbinary.logic.communication.http.file.upload.HttpFileUploadUtil;
using HttpRequestUtil = org.allbinary.logic.communication.http.request.HttpRequestUtil;
using MultipartRequestParams = org.allbinary.logic.communication.http.request.MultipartRequestParams;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using AbFileOutputStream = org.allbinary.logic.io.AbFileOutputStream;
using StreamUtil = org.allbinary.logic.io.StreamUtil;
using AbFile = org.allbinary.logic.io.file.AbFile;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using BlisketServletUtil = org.allbinary.servlet.BlisketServletUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;
using FileItem = org.apache.commons.fileupload.FileItem;

namespace org.allbinary.servlet.file;

public class UploadFileServlet : HttpServlet
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    public HashMap<object, object> requestHashMap = null;
    private string fileName = null;
    // throws ServletException, IOException
    protected virtual void processRequest(HttpServletRequest request, HttpServletResponse response)
    {
        bool isError = false;
        InputStream inputStream = null;
        try {
            BlisketServletUtil.getInstance().init(request);
            this.requestHashMap = new MultipartRequestParams(request).toHashMap();
            string filePath = ((string) this.requestHashMap.get(FileUploadData.getInstance().UPLOAD_TO_FILE_PATH));
            if (filePath == null) {
                isError = true;
                response.sendError(HttpServletResponse.SC_NOT_FOUND);
                return;
            }
            HashMap<object, object> hashMap = StdUtil.getInstance().createHashMap();
            AuthenticationHelper authenticationHelper = ((AuthenticationHelper) new AuthenticationHelperFactory().getInstance(hashMap, request));
            if (authenticationHelper.isAuthenticated()) {
                if (AuthenticationHelperUtil.getInstance().isAuthorized(authenticationHelper, filePath)) {
                    this.saveFile(filePath);
                    response.setContentType("text/plain");
                    response.getOutputStream().write(System.Text.Encoding.UTF8.GetBytes("OK!"));
                } else {
                    isError = true;
                    response.sendError(HttpServletResponse.SC_UNAUTHORIZED, "You are not Authorized");
                }
            } else {
                isError = true;
                response.sendError(HttpServletResponse.SC_UNAUTHORIZED, "Please Login");
            }
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEWERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "processRequest()", e);
            }
            isError = true;
            response.sendError(HttpServletResponse.SC_NOT_FOUND);
        } finally {
            if (!isError) {
                StreamUtil.getInstance().close(response.getOutputStream());
            }
            if (!StreamUtil.getInstance().close(inputStream)) {
            }
        }
    }

    // throws Exception
    private void saveFile(string filePath)
    {
        AbFileOutputStream fileOutputStream = null;
        try {
            FileItem fileItem = ((FileItem) this.requestHashMap.get(FileUploadData.getInstance().FILE_DATA));
            if (fileItem != null && fileItem.getSize() > 1) {
                this.fileName = HttpRequestUtil.getInstance().generateFileName(fileItem.getName());
                if (filePath.EndsWith("/") || filePath.EndsWith("\\")) {
                    filePath = filePath + this.fileName;
                }
                AbFile file = AbFile.createAbFile(URLGLOBALS.getWebappPath() + filePath);
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().HTTPREQUEST)) {
                    StringMaker stringBuffer = new StringMaker();
                    stringBuffer.append("Uploaded File: ");
                    stringBuffer.append(this.fileName);
                    stringBuffer.append(" New File: ");
                    stringBuffer.append(file.getPath());
                    this.logUtil.putF(stringBuffer.ToString(), this, "saveFile()");
                }
                HttpFileUploadUtil.log(fileItem);
                sbyte[] byteArray = fileItem.get();
                if (file.isFile()) {
                    file.delete();
                    file.createNewFile();
                }
                fileOutputStream = AbFileOutputStream.createFromAbFile(file);
                fileOutputStream.write(byteArray);
            }
        } finally {
            if (fileOutputStream != null) {
                fileOutputStream.close();
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
        return "Upload Cloud Files";
    }

}

