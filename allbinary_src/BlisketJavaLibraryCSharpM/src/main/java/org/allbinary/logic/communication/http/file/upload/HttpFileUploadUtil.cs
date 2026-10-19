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
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using ClassUtil = org.allbinary.logic.java.anyType.clazz.ClassUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using CommonSeps = org.allbinary.@string.CommonSeps;
using FileItem = org.apache.commons.fileupload.FileItem;
using FileItemStream = org.apache.commons.fileupload.FileItemStream;

namespace org.allbinary.logic.communication.http.file.upload;

public class HttpFileUploadUtil
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly HttpFileUploadUtil instance = new HttpFileUploadUtil();
    public static HttpFileUploadUtil getInstance()
    {
        return HttpFileUploadUtil.instance;
    }

    private HttpFileUploadUtil()
    {
    }

    // throws Exception
    public virtual bool isValid(object anyType)
    {
        if (anyType != null && !(anyType is string)) {
            if (anyType is FileItem) {
                return true;
            } else {
                throw new Exception("Object Not Instance Of FileItem but is: " + ClassUtil.viewAll(anyType, CommonSeps.getInstance().NEW_LINE));
            }
        }
        return false;
    }

    // throws Exception
    public static void log(FileItemStream fileItem)
    {
        LogUtil logUtil = LogUtil.getInstance();
        StringMaker stringBuffer = new StringMaker();
        CommonSeps commonSeps = CommonSeps.getInstance();
        stringBuffer.append("FileItem Log:");
        stringBuffer.append(commonSeps.NEW_LINE);
        stringBuffer.append("Content Type:");
        stringBuffer.append(fileItem.getContentType());
        stringBuffer.append(commonSeps.NEW_LINE);
        stringBuffer.append("Field Name:");
        stringBuffer.append(fileItem.getFieldName());
        stringBuffer.append(commonSeps.NEW_LINE);
        stringBuffer.append("Name:");
        stringBuffer.append(fileItem.getName());
        stringBuffer.append(commonSeps.NEW_LINE);
        stringBuffer.append("Size:");
        stringBuffer.append(" Not Calculated Yet");
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().HTTP)) {
            logUtil.putF(stringBuffer.ToString(), getInstance(), "log()");
        }
    }

    public static void log(FileItem fileItem)
    {
        LogUtil logUtil = LogUtil.getInstance();
        StringMaker stringBuffer = new StringMaker();
        CommonSeps commonSeps = CommonSeps.getInstance();
        stringBuffer.append("FileItem Log:");
        stringBuffer.append(commonSeps.NEW_LINE);
        stringBuffer.append("Content Type:");
        stringBuffer.append(fileItem.getContentType());
        stringBuffer.append(commonSeps.NEW_LINE);
        stringBuffer.append("Field Name:");
        stringBuffer.append(fileItem.getFieldName());
        stringBuffer.append(commonSeps.NEW_LINE);
        stringBuffer.append("Name:");
        stringBuffer.append(fileItem.getName());
        stringBuffer.append(commonSeps.NEW_LINE);
        stringBuffer.append("Size:");
        stringBuffer.appendlong(((long) fileItem.getSize()));
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().HTTPREQUEST)) {
            logUtil.putF(stringBuffer.ToString(), getInstance(), "log()");
        }
    }

}

