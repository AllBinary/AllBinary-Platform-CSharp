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
using AbFile = org.allbinary.logic.io.file.AbFile;
using AbPath = org.allbinary.logic.io.path.AbPath;

namespace org.allbinary.logic.communication.http.file.upload;

public class HttpFilePermissionsUtil
{
    private static readonly HttpFilePermissionsUtil instance = new HttpFilePermissionsUtil();
    public static HttpFilePermissionsUtil getInstance()
    {
        return HttpFilePermissionsUtil.instance;
    }

    // throws Exception
    public virtual void create(AbPath path)
    {
        AbFile file = AbFile.createAbFileFromAbPath(path);
        if (!file.isFile()) {
            file.createNewFile();
        }
    }

}

