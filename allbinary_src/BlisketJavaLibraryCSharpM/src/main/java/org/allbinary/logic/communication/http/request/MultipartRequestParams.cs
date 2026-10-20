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
//using List = java.util.List;
//using HttpServletRequest = javax.servlet.http.HttpServletRequest;
//using PageContext = javax.servlet.jsp.PageContext;
using StdUtil = org.allbinary.logic.StdUtil;
using AbFileUploadFactory = org.allbinary.logic.communication.http.file.upload.AbFileUploadFactory;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringValidationUtil = org.allbinary.logic.@string.StringValidationUtil;
using FileItem = org.apache.commons.fileupload.FileItem;
using InvalidContentTypeException = org.apache.commons.fileupload.FileUploadBase.InvalidContentTypeException;

namespace org.allbinary.logic.communication.http.request;

public class MultipartRequestParams : RequestParams
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private bool special = false;
    public MultipartRequestParams(HttpServletRequest request) : base()
    {
        // base() is called from the constructor declaration
        this.processMultipartRequest(request);
    }

    public MultipartRequestParams(PageContext pageContext) : base()
    {
        // base() is called from the constructor declaration
        this.processMultipartRequest(((HttpServletRequest) pageContext.getRequest()));
    }

    protected virtual void setSpecial()
    {
        this.special = true;
    }

    private void processMultipartRequest(HttpServletRequest request)
    {
        try {
            HashMap<object, object> specialRequest = StdUtil.getInstance().createHashMap();
            List multipartRequestList = AbFileUploadFactory.getInstance().getFileItemStreamList(request);
            if (multipartRequestList != null) {
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().HTTPREQUEST)) {
                    this.logUtil.putF("FileItem List Size: " + multipartRequestList.size(), this, "processMultipartRequest()");
                }
                object[] fileItemArray = multipartRequestList.toArray();
                int size = fileItemArray.Length;
                for (int index = 0; index < size; index++) {
                    FileItem fileItem = ((FileItem) fileItemArray[index]);
                    string name = fileItem.getName();
                    if (StringValidationUtil.getInstance().isEmpty(name)) {
                        specialRequest.put(fileItem.getFieldName(), fileItem.getString());
                    } else {
                        specialRequest.put(fileItem.getFieldName(), fileItem);
                    }
                }
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().HTTPREQUEST)) {
                    this.logUtil.putF("Special Request Data: " + specialRequest.ToString(), this, "processMultipartRequest()");
                }
                this.setSpecial();
                this.setMap(specialRequest);
            }
        } catch (InvalidContentTypeException e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().HTTPREQUEST)) {
                this.logUtil.putF("Using Normal RequestParams", this, "processMultipartRequest()");
            }
            base.setMap(request.getParameterMap());
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().HTTPREQUESTERROR)) {
                this.logUtil.putF("Should Not Occur", this, "processMultipartRequest()");
            }
            base.setMap(request.getParameterMap());
        }
    }

    // throws Exception
    public virtual HashMap<object, object> toHashMap()
    {
        if (this.special) {
            return ((HashMap<object, object>) this.getMap());
        } else {
            return base.toHashMap();
        }
    }

}

