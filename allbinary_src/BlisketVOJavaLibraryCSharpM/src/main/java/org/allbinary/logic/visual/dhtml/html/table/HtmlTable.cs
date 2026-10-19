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
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using StdUtil = org.allbinary.logic.StdUtil;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using HtmlTag = org.allbinary.logic.visual.dhtml.html.HtmlTag;
using CommonPhoneStrings = org.allbinary.@string.CommonPhoneStrings;

namespace org.allbinary.logic.visual.dhtml.html.table;

public class HtmlTable : HtmlTag
{
    private readonly string END = ">";
    private readonly string START = "<table ";
    private readonly string ENDTAG = "</table>";
    private readonly string CLASS = "class";
    private readonly string DIRECTION = "dir";
    private readonly string ID = "id";
    private readonly string LANG = "lang";
    private readonly string UNITS = "units";
    private readonly string BORDER = "border";
    private readonly string CELLPADDING = "cellpadding";
    private readonly string CELLSPACING = "cellspacing";
    private readonly string COLS = "cols";
    private readonly string FLOAT = "float";
    private readonly string FRAME = "frame";
    private readonly string RULES = "rules";
    private readonly string STYLE = "style";
    public readonly string BORDERCOLLAPSE = "border-collapse: collapse";
    private int numberOfColumns = 0;
    private string before;
    private string border = null;
    private string cellpadding;
    private string cellspacing;
    private string style = null;
    private string name = null;
    private string after;
    private BasicArrayList htmlRowsVector;
    public HtmlTable(string before, string cellpadding, string cellspacing, string after)
    {
        this.before = before;
        this.cellpadding = cellpadding;
        this.cellspacing = cellspacing;
        this.after = after;
        this.htmlRowsVector = new BasicArrayListD();
        addAttribute(this.BORDER, CommonPhoneStrings.getInstance().ZERO);
        addAttribute(this.CELLPADDING, this.cellpadding);
        addAttribute(this.CELLSPACING, this.cellspacing);
        addAttribute(this.STYLE, this.BORDERCOLLAPSE);
    }

    public virtual void addRow(HtmlRow htmlRow)
    {
        if (this.numberOfColumns < htmlRow.getNumberOfColumns()) {
            this.numberOfColumns = htmlRow.getNumberOfColumns();
        }
        this.htmlRowsVector.add(htmlRow);
    }

    public override string ToString()
    {
        StringUtil stringUtil = StringUtil.getInstance();
        string result = stringUtil.EMPTY_STRING;
        object[] attributeKeys = this.otherAttributes.keySet().toArray();
        result = this.before;
        result += this.START;
        result += " ";
        for (int i = 0; i < attributeKeys.Length; i++) {
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
        int size = this.htmlRowsVector.size();
        for (int i = 0; i < size; i++) {
            result += this.htmlRowsVector.get(i).ToString();
            result += " ";
        }
        result += this.ENDTAG;
        result += this.after;
        return result;
    }

}

