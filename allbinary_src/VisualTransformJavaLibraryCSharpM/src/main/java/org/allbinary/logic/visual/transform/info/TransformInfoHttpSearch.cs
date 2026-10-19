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
using FREEBLISKET_PATH_GLOBALS = org.allbinary.globals.FREEBLISKET_PATH_GLOBALS;
using URLGLOBALS = org.allbinary.globals.URLGLOBALS;
using SearchRequest = org.allbinary.logic.control.search.SearchRequest;
using AbPath = org.allbinary.logic.io.path.AbPath;
using AbPathData = org.allbinary.logic.io.path.AbPathData;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;

namespace org.allbinary.logic.visual.transform.info;

public class TransformInfoHttpSearch : TransformInfoHttp
{
    public TransformInfoHttpSearch(SearchRequest searchRequest) : base(searchRequest.getPropertiesHashMap(), searchRequest.getPageContext())
    {
        // base(searchRequest.getPropertiesHashMap(), searchRequest.getPageContext()) is called from the constructor declaration
        if (searchRequest.getStoreFront().getName() != null) {
            this.setStoreName(searchRequest.getStoreFront().getName());
        } else {
            this.setStoreName(StringUtil.getInstance().EMPTY_STRING);
        }
        string dataFileName = searchRequest.getXslFile();
        this.setTemplateFile(dataFileName);
    }

    // throws Exception
    private string getPath()
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(URLGLOBALS.getMainPath());
        stringBuffer.append(FREEBLISKET_PATH_GLOBALS.getInstance().XSLPATH);
        stringBuffer.append(this.getStoreName());
        stringBuffer.append(AbPathData.getInstance().SEPARATOR);
        return stringBuffer.ToString();
    }

    // throws Exception
    public virtual AbPath getTemplateFilePath()
    {
        return new AbPath(this.getPath(), this.getTemplateFile());
    }

    // throws Exception
    public virtual AbPath getObjectConfigFilePath()
    {
        return new AbPath(this.getPath(), this.getObjectConfigFile());
    }

    // throws Exception
    public virtual AbPath getDataFilePath()
    {
        return new AbPath(this.getPath(), this.getDataFile());
    }

}

