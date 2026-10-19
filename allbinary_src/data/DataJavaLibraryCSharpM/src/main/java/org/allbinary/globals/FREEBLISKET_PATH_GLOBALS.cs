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

namespace org.allbinary.globals;

public class FREEBLISKET_PATH_GLOBALS
{
    private static readonly FREEBLISKET_PATH_GLOBALS instance = new FREEBLISKET_PATH_GLOBALS();
    public static FREEBLISKET_PATH_GLOBALS getInstance()
    {
        return FREEBLISKET_PATH_GLOBALS.instance;
    }

    public readonly string INSTALLPATH;
    public readonly string XSLPATH;
    public readonly string TEMPLATEPATH = "template" + AbPathData.getInstance().SEPARATOR;
    public readonly string STYLEPATH;
    public readonly string THEMEPATH;
    public readonly string DBINITPATH = PATH_GLOBALS.getInstance().INIT_PATH + "db" + AbPathData.getInstance().SEPARATOR;
    public readonly string LINEDATAPATH = PATH_GLOBALS.getInstance().INIT_PATH + "lineData" + AbPathData.getInstance().SEPARATOR;
    public readonly string CONFIGURATIONPATH;
    public readonly string USERCONFIGURATIONPATH;
    public readonly string CONTEXTCONFIGURATIONPATH;
    public readonly string LICENSEERRORPAGE = "LicensingError.jsp";
    public readonly string ERRORPAGE = "Error.jsp";
    private FREEBLISKET_PATH_GLOBALS()
    {
        this.STYLEPATH = this.TEMPLATEPATH + "style" + AbPathData.getInstance().SEPARATOR;
        this.THEMEPATH = this.STYLEPATH + "theme" + AbPathData.getInstance().SEPARATOR;
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append("install");
        stringBuffer.append(AbPathData.getInstance().SEPARATOR);
        this.INSTALLPATH = stringBuffer.ToString();
        stringBuffer.delete(0, stringBuffer.length());
        stringBuffer.append(PATH_GLOBALS.getInstance().INIT_PATH);
        stringBuffer.append("views");
        stringBuffer.append(AbPathData.getInstance().SEPARATOR);
        this.XSLPATH = stringBuffer.ToString();
        stringBuffer.delete(0, stringBuffer.length());
        stringBuffer.append(this.XSLPATH);
        stringBuffer.append("configuration");
        stringBuffer.append(AbPathData.getInstance().SEPARATOR);
        this.CONFIGURATIONPATH = stringBuffer.ToString();
        stringBuffer.delete(0, stringBuffer.length());
        stringBuffer.append(this.CONFIGURATIONPATH);
        stringBuffer.append("user");
        stringBuffer.append(AbPathData.getInstance().SEPARATOR);
        this.USERCONFIGURATIONPATH = stringBuffer.ToString();
        stringBuffer.delete(0, stringBuffer.length());
        stringBuffer.append(this.CONFIGURATIONPATH);
        stringBuffer.append("context");
        stringBuffer.append(AbPathData.getInstance().SEPARATOR);
        this.CONTEXTCONFIGURATIONPATH = stringBuffer.ToString();
        stringBuffer.delete(0, stringBuffer.length());
    }

}

