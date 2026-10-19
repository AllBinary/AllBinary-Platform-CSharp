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
using LineReader = org.allbinary.logic.io.LineReader;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using HtmlTag = org.allbinary.logic.visual.dhtml.html.HtmlTag;

namespace org.allbinary.logic.visual.dhtml.html.select;

public class HtmlSelect : HtmlTag
{
    private readonly string END = ">";
    private readonly string STARTSELECT = "<SELECT ";
    private readonly string ENDSELECT = "</SELECT>";
    private readonly string SIZE = "SIZE=\"";
    private readonly string NAME = "NAME=\"";
    private readonly string STARTOPTION = "<OPTION";
    private readonly string SELETED = "SELECTED";
    private readonly string ENDOPTION = "</OPTION>";
    private string before;
    private string name;
    private string after;
    private string size;
    private string selected = null;
    private BasicArrayList options;
    private string multiple = "multiple";
    private bool isMultipleSelect = false;
    public HtmlSelect(string before, string size, string name, string after)
    {
        this.before = before;
        this.size = size;
        this.name = name;
        this.after = after;
        this.options = new BasicArrayListD();
    }

    public virtual void addOption(string key)
    {
        this.options.add(key);
    }

    public virtual void addOptions(string fileName)
    {
        try {
            LineReader lineReader = new LineReader(fileName);
            while (lineReader.hasNext()) {
                string option = lineReader.next();
                this.addOption(option);
            }
        } catch (Exception e) {
            this.addOption("Error");
        }
    }

    public virtual void setSelected(string selected)
    {
        this.selected = selected;
    }

    public virtual bool isMultiple()
    {
        return this.isMultipleSelect;
    }

    public virtual void setMultiple(bool value)
    {
        this.isMultipleSelect = value;
    }

    private string getOptions()
    {
        StringUtil stringUtil = StringUtil.getInstance();
        string result = stringUtil.EMPTY_STRING;
        object[] optionsArray = this.options.toArray();
        int optionsSize = optionsArray.Length;
        for (int i = 0; i < optionsSize; i++) {
            string value = ((string) optionsArray[i]);
            if (value != null && value.compareTo(stringUtil.EMPTY_STRING) != 0) {
                result += this.STARTOPTION;
                result += this.END;
                result += value;
                result += this.ENDOPTION;
            }
        }
        return result;
    }

    public override string ToString()
    {
        StringUtil stringUtil = StringUtil.getInstance();
        string result = stringUtil.EMPTY_STRING;
        object[] attributeKeys = this.otherAttributes.keySet().toArray();
        int attributeSize = attributeKeys.Length;
        result = this.before;
        result += this.STARTSELECT;
        result += this.NAME;
        result += this.name;
        result += "\" ";
        result += this.SIZE;
        result += this.size;
        result += "\" ";
        for (int i = 0; i < attributeSize; i++) {
            string key = ((string) attributeKeys[i]);
            string value = ((string) otherAttributes.get(key));
            if (value != null && value.compareTo(stringUtil.EMPTY_STRING) != 0) {
                result += key;
                result += "=\"";
                result += value;
                result += "\" ";
            }
        }
        if (this.isMultiple()) {
            result += " " + this.multiple + " ";
        }
        result += this.END;
        result += this.getOptions();
        result += this.ENDSELECT;
        result += this.after;
        return result;
    }

}

