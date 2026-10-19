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
using CommonSeps = org.allbinary.@string.CommonSeps;

namespace org.allbinary.logic.io.path;

public class AbPathData
{
    private static readonly AbPathData instance = new AbPathData();
    public static AbPathData getInstance()
    {
        return AbPathData.instance;
    }

    public readonly string EXTENSION_SEP = CommonSeps.getInstance().PERIOD;
    public readonly char SEPARATORCHAR = '/';
    public readonly string SEPARATOR = CommonSeps.getInstance().FORWARD_SLASH;
    private AbPathData()
    {
    }

    public virtual int getExtensionIndex(string filePath)
    {
        int indexOfFileExtensionDelmiter = filePath.LastIndexOf(this.EXTENSION_SEP);
        int indexOfLatDelimiter = filePath.LastIndexOf(this.SEPARATORCHAR);
        if (indexOfFileExtensionDelmiter < 0) {
            return -1;
        }
        if (indexOfFileExtensionDelmiter < indexOfLatDelimiter) {
            return -1;
        }
        return indexOfFileExtensionDelmiter;
    }

    public virtual string getExtensionWithDot(string filePath)
    {
        int indexOfFileExtensionDelmiter = this.getExtensionIndex(filePath);
        string extension = StringUtil.getInstance().EMPTY_STRING;
        if (indexOfFileExtensionDelmiter >= 0) {
            extension = filePath.Substring(indexOfFileExtensionDelmiter);
        }
        return extension;
    }

    public virtual string getExtension(string filePath)
    {
        int indexOfFileExtensionDelmiter = this.getExtensionIndex(filePath);
        string extension = StringUtil.getInstance().EMPTY_STRING;
        if (indexOfFileExtensionDelmiter >= 0) {
            extension = filePath.Substring(indexOfFileExtensionDelmiter + 1);
        }
        return extension;
    }

    public virtual string getNameFromPath(string path)
    {
        int endIndex = path.LastIndexOf(this.SEPARATORCHAR);
        if (endIndex < 0) {
            endIndex = path.LastIndexOf(FilePathData.getInstance().SEPARATORCHAR);
        }
        if (endIndex < 0) {
            return path;
        }
        if (path.Length == endIndex + 1) {
            string categoryName = path.Substring(0, (endIndex) - (0));
            return this.getNameFromPath(categoryName);
        } else {
            string categoryName = path.Substring(endIndex + 1);
            return categoryName;
        }
    }

    public virtual string removeNameFromPath(string path)
    {
        int endIndex = path.LastIndexOf(this.SEPARATORCHAR);
        if (endIndex < 0) {
            endIndex = path.LastIndexOf(FilePathData.getInstance().SEPARATORCHAR);
        }
        if (endIndex < 0) {
            return StringUtil.getInstance().EMPTY_STRING;
        }
        if (path.Length == endIndex + 1) {
            return this.removeNameFromPath(path.Substring(0, (endIndex - 1) - (0)));
        } else {
            string pathWithoutName = path.Substring(0, (endIndex) - (0));
            return pathWithoutName;
        }
    }

}

