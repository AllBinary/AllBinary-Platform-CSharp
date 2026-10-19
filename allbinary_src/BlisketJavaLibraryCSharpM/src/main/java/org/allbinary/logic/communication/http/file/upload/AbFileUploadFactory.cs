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
//using ArrayList = java.util.ArrayList;
//using List = java.util.List;
//using HttpServletRequest = javax.servlet.http.HttpServletRequest;
using AbFileItemFactory = org.allbinary.logic.communication.http.AbFileItemFactory;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;
using FileItemIterator = org.apache.commons.fileupload.FileItemIterator;
using FileItemStream = org.apache.commons.fileupload.FileItemStream;
using FileItemUtil = org.apache.commons.fileupload.FileItemUtil;

namespace org.allbinary.logic.communication.http.file.upload;

public class AbFileUploadFactory
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly AbFileUploadFactory instance = new AbFileUploadFactory();
    public static AbFileUploadFactory getInstance()
    {
        return AbFileUploadFactory.instance;
    }

    private AbFileUploadFactory()
    {
    }

    // throws Exception
    public virtual List getFileItemStreamList(HttpServletRequest httpServletRequest)
    {
        try {
            AbFileUpload fileUpload = new AbFileUpload(new AbFileItemFactory());
            FileItemIterator iterator = fileUpload.getItemIterator(httpServletRequest);
            List items = new ArrayList();
            while (iterator.hasNext()) {
                FileItemStream fileItemStream = iterator.next();
                HttpFileUploadUtil.log(fileItemStream);
                AbFileItem fileItem = new AbFileItem(fileItemStream.getName(), fileItemStream.getFieldName(), FileItemUtil.getInstance().getBytes(fileItemStream));
                items.add(fileItem);
            }
            return items;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().HTTPERROR)) {
                CommonStrings commonStrings = CommonStrings.getInstance();
                this.logUtil.put(commonStrings.EXCEPTION, this, "get()", e);
            }
            throw e;
        }
    }

    // throws Exception
    public virtual List getFileItemList(HttpServletRequest httpServletRequest)
    {
        try {
            AbFileUpload abFileUpload = new AbFileUpload(new AbFileItemFactory());
            return abFileUpload.parseRequest(httpServletRequest);
        } catch (Exception e) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().HTTPERROR)) {
                this.logUtil.put(commonStrings.EXCEPTION, this, "get()", e);
            }
            throw e;
        }
    }

}

