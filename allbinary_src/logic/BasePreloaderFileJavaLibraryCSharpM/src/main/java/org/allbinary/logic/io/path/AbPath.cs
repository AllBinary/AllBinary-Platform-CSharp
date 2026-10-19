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
using FilePathUtil = org.allbinary.logic.io.file.FilePathUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using StringValidationUtil = org.allbinary.logic.@string.StringValidationUtil;
using CommonSeps = org.allbinary.@string.CommonSeps;

namespace org.allbinary.logic.io.path;

public class AbPath
{
    public static AbPath createAbPath()
    {
        try {
            string EMPTY_STRING = StringUtil.getInstance().EMPTY_STRING;
            return new AbPath(EMPTY_STRING, EMPTY_STRING);
        } catch (Exception ex) {
            throw new SystemException();
        }
    }

    private readonly CommonSeps commonSeps = CommonSeps.getInstance();
    private readonly AbPathData abPathData = AbPathData.getInstance();
    private readonly PathUtil abPathUtil = PathUtil.getInstance();
    private readonly string EMPTY_STRING = StringUtil.getInstance().EMPTY_STRING;
    public string schema;
    private string path;
    public string nameP;
    private bool hasSchemaP = false;
    private int numberOfSeps = 0;
    public AbPath(string aPath, string name)
    {
        this.schema = this.EMPTY_STRING;
        this.path = this.EMPTY_STRING;
        this.nameP = this.EMPTY_STRING;
        StringValidationUtil stringValidationUtil = StringValidationUtil.getInstance();
        if (!stringValidationUtil.isEmpty(aPath)) {
            this.schema = this.getSchema(aPath);
            this.nameP = name;
            this.path = this.abPathUtil.adjustEnd(this.abPathUtil.adjust(this.getPathFromPath(aPath)));
        } else {
            this.init();
            if (!stringValidationUtil.isEmpty(name)) {
                this.nameP = name;
            }
        }
    }

    private void init()
    {
        this.schema = this.EMPTY_STRING;
        this.setPath(this.abPathData.SEPARATOR);
        this.nameP = this.EMPTY_STRING;
    }

    protected virtual string getSchema(string aPath)
    {
        int beginIndex = aPath.IndexOf(this.commonSeps.COLON);
        if (beginIndex >= 0) {
            this.hasSchemaP = true;
            return aPath.Substring(0, (beginIndex) - (0));
        }
        this.hasSchemaP = false;
        return this.EMPTY_STRING;
    }

    public virtual bool hasSchema()
    {
        return this.hasSchemaP;
    }

    // throws Exception
    public virtual string getPathFromPath(string aPath)
    {
        FilePathData filePathData = FilePathData.getInstance();
        string tempPath = aPath;
        if (!this.hasSchema()) {
            tempPath = this.abPathUtil.adjustStart(tempPath);
        } else {
            int beginIndex = tempPath.IndexOf(this.commonSeps.COLON);
            if (beginIndex >= 0) {
                beginIndex++;
                while (tempPath[beginIndex] == this.abPathData.SEPARATORCHAR || tempPath[beginIndex] == filePathData.SEPARATORCHAR) {
                    beginIndex++;
                    this.numberOfSeps++;
                    if (this.numberOfSeps > 2) {
                        throw new Exception("Should Not Have More Than Two Seps");
                    }
                }
                tempPath = tempPath.Substring(beginIndex, (tempPath.Length) - (beginIndex));
            }
        }
        return tempPath;
    }

    public virtual void setName(string name)
    {
        this.nameP = name;
    }

    public virtual string getName()
    {
        return this.nameP;
    }

    private static readonly string NETWORK_SEP = ":/";
    public override string ToString()
    {
        StringMaker stringBuffer = new StringMaker();
        if (this.hasSchema()) {
            stringBuffer.append(this.schema);
            stringBuffer.append(AbPath.NETWORK_SEP);
        }
        stringBuffer.append(this.getPath());
        stringBuffer.append(this.nameP);
        return stringBuffer.ToString();
    }

    public virtual string toFileSystemString()
    {
        if (this.hasSchema()) {
            FilePathData filePathData = FilePathData.getInstance();
            StringMaker stringBuffer = new StringMaker();
            stringBuffer.append(this.schema);
            stringBuffer.append(this.commonSeps.COLON);
            stringBuffer.append(filePathData.PATH_START);
            stringBuffer.append(FilePathUtil.adjust(this.getPath()));
            stringBuffer.append(this.nameP);
            return stringBuffer.ToString();
        } else {
            return FilePathUtil.adjust(this.getPath()) + this.nameP;
        }
    }

    public virtual string getPath()
    {
        return this.path;
    }

    protected virtual void setPath(string path)
    {
        this.path = path;
    }

}

