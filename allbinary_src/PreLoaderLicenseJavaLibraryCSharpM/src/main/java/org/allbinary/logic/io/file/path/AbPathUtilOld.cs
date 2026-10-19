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
using System.Runtime.CompilerServices;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using FilePathData = org.allbinary.logic.io.file.FilePathData;
using AbFilePath = org.allbinary.logic.io.path.AbFilePath;
using AbPath = org.allbinary.logic.io.path.AbPath;
using AbPathData = org.allbinary.logic.io.path.AbPathData;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using StringValidationUtil = org.allbinary.logic.@string.StringValidationUtil;

namespace org.allbinary.logic.io.file.path;

//Used to correct user input for paths
public class AbPathUtilOld
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly AbPathUtilOld instance = new AbPathUtilOld();
    public static AbPathUtilOld getInstance()
    {
        return AbPathUtilOld.instance;
    }

    private readonly AbPathData abPathData = AbPathData.getInstance();
    private readonly FilePathData filePathData = FilePathData.getInstance();
    private static readonly int MIN = 4;
    private AbPathUtilOld()
    {
    }

    // throws Exception
    public virtual string getExtension(AbFilePath abFilePath)
    {
        return this.getExtension(abFilePath.ToString());
    }

    // throws Exception
    public virtual string getExtension(AbPath abPath)
    {
        return this.getExtension(abPath.ToString());
    }

    // throws Exception
    public virtual string getExtension(string filePath)
    {
        if (filePath.Length < AbPathUtilOld.MIN) {
            throw new Exception("Could not be a file path since its less that 4 characters");
        }
        int beginIndex = filePath.Length - AbPathUtilOld.MIN;
        string extension = filePath.Substring(beginIndex + 1);
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
            this.logUtil.putF("FileExtension: " + extension, this, "getExtension()");
        }
        return extension;
    }

    // throws Exception
    public virtual string getWithoutExtension(AbFilePath abFilePath)
    {
        return this.getWithoutExtension(abFilePath.ToString());
    }

    // throws Exception
    public virtual string getWithoutExtension(AbPath abPath)
    {
        return this.getWithoutExtension(abPath.ToString());
    }

    // throws Exception
    public virtual string getWithoutExtension(string filePath)
    {
        if (filePath.Length < AbPathUtilOld.MIN) {
            throw new Exception("Could not be a file path since its less that 4 characters");
        }
        int endIndex = filePath.Length - AbPathUtilOld.MIN;
        string pathWithoutExtension = filePath.Substring(0, (endIndex) - (0));
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
            this.logUtil.putF("FileWithoutExtension: " + pathWithoutExtension, this, "getWithoutExtension()");
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
        if (path[0] == this.abPathData.SEPARATORCHAR) {
            return true;
        } else {
            return false;
        }
    }

    private bool isValidEnd(string path)
    {
        if (StringValidationUtil.getInstance().isEmpty(path)) {
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
        if (StringValidationUtil.getInstance().isEmpty(path)) {
            return this.abPathData.SEPARATOR;
        }
        if (path.IndexOf("\\") >= 0) {
            path = path.Replace('\\', this.abPathData.SEPARATORCHAR);
        }
        return path;
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual string getNameFromPath(string categoryPath)
    {
        int endIndex = categoryPath.LastIndexOf(this.abPathData.SEPARATOR);
        if (endIndex < 0) {
            endIndex = categoryPath.LastIndexOf(this.filePathData.SEPARATORCHAR);
        }
        if (endIndex < 0) {
            return categoryPath;
        }
        if (categoryPath.Length == endIndex + 1) {
            string categoryName = categoryPath.Substring(0, (endIndex) - (0));
            return this.getNameFromPath(categoryName);
        } else {
            string categoryName = categoryPath.Substring(endIndex + 1);
            return categoryName;
        }
    }

    // throws Exception
    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual AbPath removeNameFromPath(string categoryPath)
    {
        int endIndex = categoryPath.LastIndexOf(this.abPathData.SEPARATOR);
        if (endIndex < 0) {
            endIndex = categoryPath.LastIndexOf(this.filePathData.SEPARATORCHAR);
        }
        if (endIndex < 0) {
            return AbPath.createAbPath();
        }
        if (categoryPath.Length == endIndex + 1) {
            return this.removeNameFromPath(categoryPath.Substring(0, (endIndex - 1) - (0)));
        } else {
            string categoryName = categoryPath.Substring(0, (endIndex) - (0));
            return new AbPath(categoryName, StringUtil.getInstance().EMPTY_STRING);
        }
    }

}

