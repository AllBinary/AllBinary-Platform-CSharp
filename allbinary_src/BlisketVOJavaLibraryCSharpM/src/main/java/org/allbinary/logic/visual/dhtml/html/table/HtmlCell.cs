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

namespace org.allbinary.logic.visual.dhtml.html.table;

public class HtmlCell : HtmlTag
{
    private readonly string END = ">";
    private readonly string START = "<td ";
    private readonly string ENDTAG = "</td>";
    private readonly string HEIGHT = "height";
    private readonly string WIDTH = "width";
    private string height;
    private string width;
    private string before;
    private string body = null;
    private string after;
    public HtmlCell(string before, string width, string height, string after)
    {
        this.before = new string((before).ToCharArray());
        this.after = new string((after).ToCharArray());
        this.height = new string((height).ToCharArray());
        this.width = new string((width).ToCharArray());
        addAttribute(this.HEIGHT, this.height);
        addAttribute(this.WIDTH, this.width);
    }

    public virtual void addText(string body)
    {
        this.body = body;
    }

    public override string ToString()
    {
        StringUtil stringUtil = StringUtil.getInstance();
        string result = stringUtil.EMPTY_STRING;
        Any[] attributeKeys = this.otherAttributes.keySet().toArray();
        int attributeSize = attributeKeys.Length;
        result = this.before;
        result += this.START;
        result += " ";
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
        result += this.body;
        result += this.ENDTAG;
        result += this.after;
        return result;
    }

}

