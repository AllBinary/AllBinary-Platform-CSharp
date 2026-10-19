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

namespace org.allbinary.logic.io.file;

public class FileData
{
    private static readonly FileData instance = new FileData();
    public static FileData getInstance()
    {
        return FileData.instance;
    }

    private FileData()
    {
    }

    public readonly string NAME = "FILE_NAME";
    public readonly string ISFILE = "FILE_ISFILE";
    public readonly string ISDIRECTORY = "FILE_ISDIRECTORY";
    public readonly string ISHIDDEN = "FILE_ISHIDDEN";
    public readonly string ISABSOLUTE = "FILE_ISABSOLUTE";
    public readonly string ROOT_NAME = "FILE_ROOT_NAME";
    public readonly string PATH = "FILE_PATH";
    public readonly string ABSOLUTE_PATH = "FILE_ABSOLUTE_PATH";
    public readonly string CANONICAL_PATH = "FILE_CANONICAL_PATH";
    public readonly string PARENT = "FILE_PARENT";
    public readonly int MINLEN = 1;
    public readonly int MAXLEN = 120;
    public readonly int MAXIMAGEFILESIZE = 1048576;
    public readonly int MINIMAGEFILESIZE = 32;
    public readonly int MAXDOWNLOADABLEFILESIZE = 1048576 * 20;
    public readonly int MINDOWNLOADABLEFILESIZE = 1;
}

