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
//using HttpServletRequest = javax.servlet.http.HttpServletRequest;
using FileItemFactory = org.apache.commons.fileupload.FileItemFactory;
using FileItemIterator = org.apache.commons.fileupload.FileItemIterator;
using FileUpload = org.apache.commons.fileupload.FileUpload;
using FileUploadException = org.apache.commons.fileupload.FileUploadException;
using ServletRequestContext = org.apache.commons.fileupload.servlet.ServletRequestContext;

namespace org.allbinary.logic.communication.http.file.upload;

public class AbFileUpload : FileUpload
{
    public AbFileUpload(FileItemFactory fileItemFactory) : base(fileItemFactory)
    {
        // base(fileItemFactory) is called from the constructor declaration
    }

    // throws FileUploadException, IOException
    public virtual FileItemIterator getItemIterator(HttpServletRequest request)
    {
        return base.getItemIterator(new ServletRequestContext(request));
    }

}

