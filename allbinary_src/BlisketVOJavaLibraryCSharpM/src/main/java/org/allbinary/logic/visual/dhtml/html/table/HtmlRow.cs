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

namespace org.allbinary.logic.visual.dhtml.html.table;

public class HtmlRow : HtmlTag
{
    private readonly string END = ">";
    private readonly string START = "<tr ";
    private readonly string ENDTAG = "</tr>";
    private int numberOfColumns = 0;
    private string before;
    private string after;
    private BasicArrayList htmlCellsVector;
    public HtmlRow(string before, string after)
    {
        this.before = new string((before).ToCharArray());
        this.after = new string((after).ToCharArray());
        this.htmlCellsVector = new BasicArrayListD();
    }

    public virtual void addCell(HtmlCell htmlCell)
    {
        this.htmlCellsVector.add(htmlCell);
        this.numberOfColumns++;
    }

    public virtual int getNumberOfColumns()
    {
        return this.numberOfColumns;
    }

    public override string ToString()
    {
        StringUtil stringUtil = StringUtil.getInstance();
        string result = stringUtil.EMPTY_STRING;
        object[] attributeKeys = this.otherAttributes.keySet().toArray();
        int attributeSize = attributeKeys.Length;
        int cellSize = this.htmlCellsVector.size();
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
        for (int i = 0; i < cellSize; i++) {
            result += this.htmlCellsVector.get(i).ToString();
            result += " ";
        }
        result += this.ENDTAG;
        result += this.after;
        return result;
    }

}

