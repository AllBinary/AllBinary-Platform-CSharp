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

namespace org.allbinary.logic.communication.http.file.upload;

public class FileUploadData
{
    private static readonly FileUploadData instance = new FileUploadData();
    public static FileUploadData getInstance()
    {
        return FileUploadData.instance;
    }

    public readonly string FILE = "download_file_permissions.xml";
    public readonly string UPLOAD_TO_FILE_PATH = "FILE_UPLOAD_UPLOAD_TO_FILE_PATH";
    public readonly string FILE_DATA = "FILE_UPLOAD_FILE_DATA";
}

