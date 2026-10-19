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
//using FileFilter = java.io.FileFilter;
//using FilenameFilter = java.io.FilenameFilter;
//using IOException = java.io.IOException;
//using URI = java.net.URI;
using TsUtil = org.allbinary.TsUtil;
using AbPath = org.allbinary.logic.io.path.AbPath;
using StringUtil = org.allbinary.logic.@string.StringUtil;

namespace org.allbinary.logic.io.file;

public class AbFile : AbFileInterface
{
    public static readonly AbFile NULL_FILE = AbFile.createAbFileFromRawPath(StringUtil.getInstance().EMPTY_STRING);
    // throws Exception
    public static AbFile createAbFileWithChild(AbFile file, string childPathName)
    {
        return new AbFile(new File(file.getFile(), childPathName));
    }

    // throws Exception
    public static AbFile createAbFile(string filePath)
    {
        return new AbFile(new File(new AbPath(filePath, StringUtil.getInstance().EMPTY_STRING).toFileSystemString()));
    }

    // throws Exception
    public static AbFile createAbFilePathAndName(string filePath, string fileName)
    {
        return new AbFile(new File(new AbPath(filePath, StringUtil.getInstance().EMPTY_STRING).toFileSystemString(), fileName));
    }

    public static AbFile createAbFileFromAbPath(AbPath abPath)
    {
        return new AbFile(new File(abPath.toFileSystemString()));
    }

    public static AbFile createAbFileFromRawPath(string filePath)
    {
        return new AbFile(new File(filePath));
    }

    private readonly File file;
    protected AbFile(File file)
    {
        this.file = file;
    }

    protected virtual File getFile()
    {
        return this.file;
    }

    public virtual string getName()
    {
        return this.file.getName();
    }

    public virtual string getParent()
    {
        return this.file.getParent();
    }

    public virtual File getParentFile()
    {
        return this.file.getParentFile();
    }

    public virtual string getPath()
    {
        return this.file.getPath();
    }

    public virtual bool isAbsolute()
    {
        return this.file.isAbsolute();
    }

    public virtual string getAbsolutePath()
    {
        return this.file.getAbsolutePath();
    }

    public virtual File getAbsoluteFile()
    {
        return this.file.getAbsoluteFile();
    }

    // throws IOException
    public virtual string getCanonicalPath()
    {
        return this.file.getCanonicalPath();
    }

    // throws IOException
    public virtual File getCanonicalFile()
    {
        return this.file.getCanonicalFile();
    }

    public virtual URI toURI()
    {
        return this.file.toURI();
    }

    public virtual bool canRead()
    {
        return this.file.canRead();
    }

    public virtual bool canWrite()
    {
        return this.file.canWrite();
    }

    public virtual bool exists()
    {
        return this.file.exists();
    }

    public virtual bool isDirectory()
    {
        return this.file.isDirectory();
    }

    public virtual bool isFile()
    {
        return this.file.isFile();
    }

    public virtual bool isHidden()
    {
        return this.file.isHidden();
    }

    public virtual long lastModified()
    {
        return this.file.lastModified();
    }

    public virtual long length()
    {
        return ((long) this.file.length());
    }

    // throws IOException
    public virtual bool createNewFile()
    {
        return this.file.createNewFile();
    }

    // throws IOException
    public virtual bool delete()
    {
        return this.file.delete();
    }

    public virtual void deleteOnExit()
    {
        this.file.deleteOnExit();
    }

    public virtual string[] list()
    {
        return this.file.list();
    }

    public virtual string[] listWithFilter(FilenameFilter filter)
    {
        return this.file.list(filter);
    }

    public virtual object[] listFiles()
    {
        return ((object[]) this.file.listFiles());
    }

    public virtual object[] listFilesFileNameFilter(FilenameFilter filter)
    {
        return ((object[]) this.file.listFiles(filter));
    }

    public virtual object[] listFilesFileFilter(FileFilter filter)
    {
        return ((object[]) this.file.listFiles(filter));
    }

    public virtual bool mkdir()
    {
        return this.file.mkdir();
    }

    public virtual bool mkdirs()
    {
        return this.file.mkdirs();
    }

    public virtual bool renameTo(AbFile dest)
    {
        return this.file.renameTo(dest.getFile());
    }

    public virtual bool setLastModified(long time)
    {
        return this.file.setLastModified(time);
    }

    public virtual bool setReadOnly()
    {
        return this.file.setReadOnly();
    }

    public virtual int compareTo(File pathname)
    {
        return this.file.compareTo(pathname);
    }

    public override bool Equals(object obj)
    {
        return TsUtil.getInstance().equalsNotstring(this.file, obj);
    }

    public override int GetHashCode()
    {
        return this.file.GetHashCode();
    }

    public override string ToString()
    {
        return this.file.ToString();
    }

}

