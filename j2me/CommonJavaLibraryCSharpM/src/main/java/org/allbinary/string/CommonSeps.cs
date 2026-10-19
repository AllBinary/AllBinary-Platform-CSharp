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
using StringMaker = org.allbinary.logic.@string.StringMaker;
//using JsMethod = jsinterop.annotations.JsMethod;
//using JsProperty = jsinterop.annotations.JsProperty;

namespace org.allbinary.@string;

public class CommonSeps
{
    private static readonly CommonSeps instance = new CommonSeps();
    public static CommonSeps getInstance()
    {
        return CommonSeps.instance;
    }

    public readonly string NEW_LINE = "\n";
    public readonly string SEMICOLON = ";";
    public readonly string EQUALS = "=";
    public readonly string SPACE = " ";
    public readonly string COMMA = ",";
    public readonly string COLON = ":";
    public readonly string PERIOD = ".";
    public readonly string UNDERSCORE = "_";
    public readonly string COLON_SEP;
    public readonly string COMMA_SEP;
    public readonly string PARENTHESIS_OPEN = "(";
    public readonly string PARENTHESIS_CLOSE = ")";
    public readonly string BRACE_OPEN = "{";
    public readonly string BRACE_CLOSE = "}";
    public readonly string BRACKET_OPEN = "[";
    public readonly string BRACKET_CLOSE = "]";
    public readonly string DASH = "-";
    public readonly string PERCENT = "%";
    public readonly string AMPERSAND = "&";
    public readonly string FORWARD_SLASH = "/";
    public readonly string BACK_SLASH = "\\";
    public readonly string QUESTION = "?";
    public readonly string QUOTE = "\"";
    public readonly string QUOTE_END = "\",";
    public readonly string COMMENT = "//";
    public readonly string INDENT = "    ";
    public CommonSeps()
    {
        this.COLON_SEP = new StringMaker().append(this.COLON).append(this.SPACE).ToString();
        this.COMMA_SEP = new StringMaker().append(this.COMMA).append(this.SPACE).ToString();
    }

}

