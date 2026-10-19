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
using java.util;
using GLOBALS2 = org.allbinary.globals.GLOBALS2;
using StdUtil = org.allbinary.logic.StdUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using Replace = org.allbinary.logic.@string.regex.replace.Replace;
using CustomizerTransformInfoData = org.allbinary.logic.visual.transform.info.CustomizerTransformInfoData;
using BodyData = org.allbinary.logic.visual.transform.template.customizer.bodies.BodyData;
using TitleData = org.allbinary.logic.visual.transform.template.customizer.widgets.title.TitleData;
using CommonSeps = org.allbinary.@string.CommonSeps;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.logic.visual.transform.template.util;

public class TransformTemplateCustomizerUtil
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly TransformTemplateCustomizerUtil instance = new TransformTemplateCustomizerUtil();
    public static TransformTemplateCustomizerUtil getInstance()
    {
        return TransformTemplateCustomizerUtil.instance;
    }

    private readonly string CUSTOMIZER_NAME;
    private readonly string BODY_VIEWNAMEKEY;
    private readonly string TITLE_VIEWNAMEKEY;
    private readonly string GLOBALS_NEW;
    private readonly string GLOBALS_INSERT;
    private readonly string GLOBALS_DELETE;
    private readonly string GLOBALS_EDIT;
    private readonly string GLOBALS_UPDATE;
    private TransformTemplateCustomizerUtil()
    {
        CommonStrings commonStrings = CommonStrings.getInstance();
        string SPACE = CommonSeps.getInstance().SPACE;
        this.CUSTOMIZER_NAME = SPACE + CustomizerTransformInfoData.NAME;
        this.BODY_VIEWNAMEKEY = SPACE + BodyData.getInstance().VIEWNAMEKEY;
        this.TITLE_VIEWNAMEKEY = SPACE + TitleData.getInstance().VIEWNAMEKEY;
        this.GLOBALS_NEW = GLOBALS2.NEW + SPACE;
        this.GLOBALS_INSERT = commonStrings.INSERT + SPACE;
        this.GLOBALS_DELETE = commonStrings.DELETE + SPACE;
        this.GLOBALS_EDIT = GLOBALS2.EDIT + SPACE;
        this.GLOBALS_UPDATE = commonStrings.UPDATE + SPACE;
    }

    public virtual string getPageNameHack(string viewName, string storeName)
    {
        string SPACE = CommonSeps.getInstance().SPACE;
        string[] ONE_EMPTY_STRING_ARRAY = StringUtil.getInstance().ONE_EMPTY_STRING_ARRAY;
        HashMap hashMap = StdUtil.getInstance().createHashMap();
        hashMap.put(new string[] { viewName + SPACE }, ONE_EMPTY_STRING_ARRAY);
        hashMap.put(new string[] { storeName + SPACE }, ONE_EMPTY_STRING_ARRAY);
        hashMap.put(new string[] { this.CUSTOMIZER_NAME }, ONE_EMPTY_STRING_ARRAY);
        hashMap.put(new string[] { this.BODY_VIEWNAMEKEY }, ONE_EMPTY_STRING_ARRAY);
        hashMap.put(new string[] { this.TITLE_VIEWNAMEKEY }, ONE_EMPTY_STRING_ARRAY);
        hashMap.put(new string[] { this.GLOBALS_NEW }, ONE_EMPTY_STRING_ARRAY);
        hashMap.put(new string[] { this.GLOBALS_INSERT }, ONE_EMPTY_STRING_ARRAY);
        hashMap.put(new string[] { this.GLOBALS_DELETE }, ONE_EMPTY_STRING_ARRAY);
        hashMap.put(new string[] { this.GLOBALS_EDIT }, ONE_EMPTY_STRING_ARRAY);
        hashMap.put(new string[] { this.GLOBALS_UPDATE }, ONE_EMPTY_STRING_ARRAY);
        Replace replace = null;
        string rootViewName = replace.all(viewName);
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
            this.logUtil.putF("RootViewName for ObjectConfig: " + rootViewName, this, "getPageNameHack");
        }
        return rootViewName;
    }

}

