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
using StringUtil = org.allbinary.logic.@string.StringUtil;
using HtmlTag = org.allbinary.logic.visual.dhtml.html.HtmlTag;

namespace org.allbinary.logic.visual.dhtml.html.input;

public class HtmlInput : HtmlTag
{
    private readonly string END = ">";
    private readonly string STARTINPUT = "<INPUT ";
    private readonly string ENDINPUT = "</INPUT>";
    private readonly string TYPE = "TYPE=\"";
    private readonly string NAME = "NAME=\"";
    private string before;
    private string type;
    private string name;
    private string after;
    public HtmlInput(string before, string type, string name, string after)
    {
        this.before = before;
        this.type = type;
        this.name = name;
        this.after = after;
    }

    public override string ToString()
    {
        StringUtil stringUtil = StringUtil.getInstance();
        string result = stringUtil.EMPTY_STRING;
        object[] attributeKeys = this.otherAttributes.keySet().toArray();
        int attributeSize = attributeKeys.Length;
        result = this.before;
        result += this.STARTINPUT;
        result += this.TYPE;
        result += this.type;
        result += "\" ";
        result += this.NAME;
        result += this.name;
        result += "\" ";
        for (int i = 0; i < attributeSize; i++) {
            string key = ((string) attributeKeys[i]);
            string value = ((string) otherAttributes.get(key));
            if (value != null && string.CompareOrdinal(value, stringUtil.EMPTY_STRING) != 0) {
                result += key;
                result += "=\"";
                result += value;
                result += "\" ";
            }
        }
        result += this.END;
        result += this.ENDINPUT;
        result += this.after;
        return result;
    }

}

