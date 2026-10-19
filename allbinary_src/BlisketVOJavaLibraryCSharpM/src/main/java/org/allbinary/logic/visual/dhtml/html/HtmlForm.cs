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
using HtmlInput = org.allbinary.logic.visual.dhtml.html.input.HtmlInput;
using HtmlTable = org.allbinary.logic.visual.dhtml.html.table.HtmlTable;

namespace org.allbinary.logic.visual.dhtml.html;

public class HtmlForm
{
    private readonly string FORMBEGIN = "<form ";
    private readonly string END = ">";
    private readonly string FORMEND = "</form>";
    private readonly string ACTION = "ACTION=\"";
    private readonly string GET = "GET\"";
    private readonly string POST = "POST\"";
    private readonly string[] METHODS;
    private readonly string METHOD = "METHOD=\"";
    private string method = null;
    private string action;
    public BasicArrayList inputs;
    public HtmlForm(string action)
    {
        this.METHODS = new string[] { this.GET, this.POST };
        this.action = action;
        this.inputs = new BasicArrayListD();
    }

    public virtual void setPost()
    {
        this.method = this.POST;
    }

    public virtual void setGet()
    {
        this.method = this.GET;
    }

    public virtual void addInput(HtmlInput htmlInput)
    {
        this.inputs.add(htmlInput);
    }

    public virtual void addTable(HtmlTable htmlTable)
    {
        this.inputs.add(htmlTable);
    }

    public override string ToString()
    {
        StringUtil stringUtil = StringUtil.getInstance();
        string result = stringUtil.EMPTY_STRING;
        object[] inputArray = this.inputs.toArray();
        int inputSize = inputArray.Length;
        result = this.FORMBEGIN;
        result += this.METHOD;
        result += this.method;
        result += "\" ";
        result += this.ACTION;
        result += this.action;
        result += "\" ";
        result += this.END;
        for (int i = 0; i < inputSize; i++) {
            result += inputArray[i].ToString();
            result += " ";
        }
        result += this.FORMEND;
        return result;
    }

}

