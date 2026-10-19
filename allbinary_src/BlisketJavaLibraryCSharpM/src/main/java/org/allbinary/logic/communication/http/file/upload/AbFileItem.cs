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
//using File = java.io.File;
//using IOException = java.io.IOException;
//using InputStream = java.io.InputStream;
//using OutputStream = java.io.OutputStream;
//using UnsupportedEncodingException = java.io.UnsupportedEncodingException;
using ForcedLogUtil = org.allbinary.logic.communication.log.ForcedLogUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using AbFile = org.allbinary.logic.io.file.AbFile;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using StringValidationUtil = org.allbinary.logic.@string.StringValidationUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;
using FileItem = org.apache.commons.fileupload.FileItem;
using FileItemHeaders = org.apache.commons.fileupload.FileItemHeaders;
using FileItemUtil = org.apache.commons.fileupload.FileItemUtil;

namespace org.allbinary.logic.communication.http.file.upload;

public class AbFileItem : FileItem
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private readonly string name;
    private string fieldName;
    private readonly sbyte[] byteArray;
    public AbFileItem(string name, string fieldName, sbyte[] byteArray)
    {
        this.name = name;
        this.fieldName = fieldName;
        this.byteArray = byteArray;
    }

    // throws IOException
    public virtual InputStream getInputStream()
    {
        throw new IOException(this.commonStrings.NOT_IMPLEMENTED);
    }

    public virtual string getContentType()
    {
        return null;
    }

    public virtual string getName()
    {
        return this.name;
    }

    public virtual bool isInMemory()
    {
        return true;
    }

    public virtual long getSize()
    {
        return ((long) this.byteArray.Length);
    }

    public virtual sbyte[] get()
    {
        return this.byteArray;
    }

    // throws UnsupportedEncodingException
    public virtual string getString(string encoding)
    {
        return System.Text.Encoding.UTF8.GetString((byte[]) (Array) this.byteArray, encoding);
    }

    public virtual string getString()
    {
        try {
            return FileItemUtil.getInstance().getString(this.byteArray);
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().HTTPERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "getString", e);
            }
            return StringUtil.getInstance().EMPTY_STRING;
        }
    }

    // throws Exception
    public virtual void write(File file)
    {
        throw new Exception(this.commonStrings.NOT_IMPLEMENTED);
    }

    // throws Exception
    public virtual void write(AbFile file)
    {
        throw new Exception(this.commonStrings.NOT_IMPLEMENTED);
    }

    public virtual void delete()
    {
        ForcedLogUtil.log(this.commonStrings.NOT_IMPLEMENTED, "delete()");
    }

    public virtual string getFieldName()
    {
        return this.fieldName;
    }

    public virtual void setFieldName(string name)
    {
        this.fieldName = name;
    }

    public virtual bool isFormField()
    {
        if (StringValidationUtil.getInstance().isEmpty(this.fieldName)) {
            return false;
        } else {
            return true;
        }
    }

    public virtual void setFormField(bool state)
    {
    }

    // throws IOException
    public virtual OutputStream getOutputStream()
    {
        throw new IOException(this.commonStrings.NOT_IMPLEMENTED);
    }

    public virtual FileItemHeaders getHeaders()
    {
        throw new SystemException(this.commonStrings.NOT_IMPLEMENTED);
    }

    public virtual void setHeaders(FileItemHeaders fih)
    {
        throw new SystemException(this.commonStrings.NOT_IMPLEMENTED);
    }

}

