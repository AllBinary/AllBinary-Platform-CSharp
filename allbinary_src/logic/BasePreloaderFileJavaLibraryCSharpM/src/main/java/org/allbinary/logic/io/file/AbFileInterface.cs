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
//using FilenameFilter = java.io.FilenameFilter;
//using IOException = java.io.IOException;
//using URI = java.net.URI;

namespace org.allbinary.logic.io.file;

public interface AbFileInterface
{
    bool canRead();

    bool canWrite();

    // throws IOException
    bool createNewFile();

    // throws IOException
    bool delete();

    void deleteOnExit();

    bool exists();

    string getAbsolutePath();

    // throws IOException
    string getCanonicalPath();

    string getParent();

    string getPath();

    bool isAbsolute();

    bool isDirectory();

    bool isFile();

    bool isHidden();

    long lastModified();

    long length();

    string[] list();

    string[] listWithFilter(FilenameFilter filter);

    bool mkdir();

    bool mkdirs();

    bool setLastModified(long time);

    bool setReadOnly();

    string ToString();

    URI toURI();

}

