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
//using JsType = jsinterop.annotations.JsType;
//using JsMethod = jsinterop.annotations.JsMethod;
//using JsProperty = jsinterop.annotations.JsProperty;

namespace org.allbinary.@string;

public class CommonLabels
{
    private static readonly CommonLabels instance = new CommonLabels();
    public static CommonLabels getInstance()
    {
        return CommonLabels.instance;
    }

    public readonly string WIDTH_LABEL = " Width: ";
    public readonly string HEIGHT_LABEL = " Height: ";
    public readonly string END_LABEL = "End: ";
    public readonly string TOTAL_LABEL = "Total: ";
    public readonly string INDEX_LABEL = "index: ";
    public readonly string START_LABEL = "Start: ";
    public readonly string COMMAND_LABEL = "Command: ";
    public readonly string NAME_LABEL = "Name: ";
    public readonly string START;
    public readonly string ELAPSED = " Elapsed: ";
    public readonly string CURRENT = " Current: ";
    public readonly string NEXT = "Next";
    public readonly string ITEM_LABEL = "Item: ";
    public readonly string RESULT_ = "Result: ";
    public readonly string COLON_SEP = ": ";
    public CommonLabels()
    {
        this.START = this.START_LABEL;
    }

}

