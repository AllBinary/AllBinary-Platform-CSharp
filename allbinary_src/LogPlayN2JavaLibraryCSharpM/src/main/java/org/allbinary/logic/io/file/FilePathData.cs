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

public class FilePathData
{
    private static readonly FilePathData instance = new FilePathData();
    public static FilePathData getInstance()
    {
        return FilePathData.instance;
    }

    public readonly char SEPARATORCHAR = '\\';
    public string PATH_START = "\\\\";
    private FilePathData()
    {
    }

}

