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
using FilePathData = org.allbinary.logic.io.file.FilePathData;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using StringValidationUtil = org.allbinary.logic.@string.StringValidationUtil;

namespace org.allbinary.logic.io.path;

//Used to correct user input for paths
public class PathUtil
{
    private static readonly PathUtil instance = new PathUtil();
    public static PathUtil getInstance()
    {
        return PathUtil.instance;
    }

    private readonly AbPathData abPathData = AbPathData.getInstance();
    private readonly FilePathData filePathData = FilePathData.getInstance();
    private PathUtil()
    {
    }

    public virtual string getExtensionWithAbFilePath(AbFilePath abFilePath)
    {
        return this.abPathData.getExtension(abFilePath.ToString());
    }

    public virtual string getExtensionWithAbPath(AbPath abPath)
    {
        return this.abPathData.getExtension(abPath.ToString());
    }

    // throws Exception
    public virtual string getWithoutExtensionWithAbFilePath(AbFilePath abFilePath)
    {
        return this.getWithoutExtension(abFilePath.ToString());
    }

    // throws Exception
    public virtual string getWithoutExtensionWithAbPath(AbPath abPath)
    {
        return this.getWithoutExtension(abPath.ToString());
    }

    // throws Exception
    public virtual string getWithoutExtension(string filePath)
    {
        int indexOfFileExtensionDelmiter = this.abPathData.getExtensionIndex(filePath);
        string pathWithoutExtension = filePath;
        if (indexOfFileExtensionDelmiter >= 0) {
            pathWithoutExtension = filePath.Substring(0, (indexOfFileExtensionDelmiter) - (0));
        }
        return pathWithoutExtension;
    }

    public virtual bool isValid(string path)
    {
        if (this.isValidStart(path)) {
            if (this.isValidEnd(path)) {
                return true;
            }
        }
        return false;
    }

    private bool isValidStart(string path)
    {
        if (path[0] == this.abPathData.SEPARATORCHAR || path[0] == '.') {
            return true;
        } else {
            return false;
        }
    }

    private bool isValidEnd(string path)
    {
        StringValidationUtil stringValidationUtil = StringValidationUtil.getInstance();
        if (stringValidationUtil.isEmpty(path)) {
            return false;
        }
        if (path[path.Length - 1] == this.abPathData.SEPARATORCHAR) {
            return true;
        } else {
            return false;
        }
    }

    public virtual string adjustStart(string path)
    {
        if (!this.isValidStart(path)) {
            path = this.abPathData.SEPARATOR + path;
        }
        return path;
    }

    public virtual string adjustEnd(string path)
    {
        if (!this.isValidEnd(path)) {
            path = path + this.abPathData.SEPARATOR;
        }
        return path;
    }

    public virtual string adjust(string path)
    {
        StringValidationUtil stringValidationUtil = StringValidationUtil.getInstance();
        if (stringValidationUtil.isEmpty(path)) {
            return this.abPathData.SEPARATOR;
        }
        if (path.IndexOf("\\") >= 0) {
            path = path.Replace('\\', this.abPathData.SEPARATORCHAR);
        }
        return path;
    }

    // throws Exception
    public virtual AbPath removeNameFromPath(string path)
    {
        int endIndex = path.LastIndexOf(this.abPathData.SEPARATOR);
        if (endIndex < 0) {
            endIndex = path.LastIndexOf(this.filePathData.SEPARATORCHAR);
        }
        if (endIndex < 0) {
            return AbPath.createAbPath();
        }
        if (path.Length == endIndex + 1) {
            return this.removeNameFromPath(path.Substring(0, (endIndex - 1) - (0)));
        } else {
            string pathWithoutName = path.Substring(0, (endIndex) - (0));
            return new AbPath(pathWithoutName, StringUtil.getInstance().EMPTY_STRING);
        }
    }

}

