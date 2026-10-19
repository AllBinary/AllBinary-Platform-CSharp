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
using AbPathData = org.allbinary.logic.io.path.AbPathData;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.globals;

public class PATH_GLOBALS
{
    private static readonly PATH_GLOBALS instance = new PATH_GLOBALS();
    public static PATH_GLOBALS getInstance()
    {
        return PATH_GLOBALS.instance;
    }

    private PATH_GLOBALS()
    {
        StringMaker stringBuffer = new StringMaker();
        AbPathData abPathData = AbPathData.getInstance();
        stringBuffer.append("data");
        stringBuffer.append(abPathData.SEPARATOR);
        this.DATA_PATH = stringBuffer.ToString();
        stringBuffer.delete(0, stringBuffer.length());
        stringBuffer.append(this.DATA_PATH);
        stringBuffer.append(CommonStrings.getInstance().INIT);
        stringBuffer.append(abPathData.SEPARATOR);
        this.INIT_PATH = stringBuffer.ToString();
        stringBuffer.delete(0, stringBuffer.length());
        stringBuffer.append(this.DATA_PATH);
        stringBuffer.append("log");
        stringBuffer.append(abPathData.SEPARATOR);
        this.LOG_PATH = stringBuffer.ToString();
        stringBuffer.delete(0, stringBuffer.length());
        stringBuffer.append(this.DATA_PATH);
        stringBuffer.append("backup");
        stringBuffer.append(abPathData.SEPARATOR);
        this.BACKUP_PATH = stringBuffer.ToString();
        stringBuffer.delete(0, stringBuffer.length());
        stringBuffer.append(this.INIT_PATH);
        stringBuffer.append("views");
        stringBuffer.append(abPathData.SEPARATOR);
        this.VIEWS_PATH = stringBuffer.ToString();
    }

    public readonly string DATA_PATH;
    public readonly string INIT_PATH;
    public readonly string VIEWS_PATH;
    public readonly string LOG_PATH;
    public readonly string BACKUP_PATH;
}

