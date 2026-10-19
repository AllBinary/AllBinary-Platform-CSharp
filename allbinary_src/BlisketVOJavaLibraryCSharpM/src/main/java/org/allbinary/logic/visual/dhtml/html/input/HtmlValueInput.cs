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

namespace org.allbinary.logic.visual.dhtml.html.input;

public class HtmlValueInput : HtmlInput
{
    private string value;
    private readonly string VALUE = "VALUE";
    public HtmlValueInput(string before, string type, string name, string value, string after) : base(before, type, name, after)
    {
        // base(before, type, name, after) is called from the constructor declaration
        StringUtil stringUtil = StringUtil.getInstance();
        this.value = stringUtil.EMPTY_STRING;
        addAttribute(this.VALUE, value);
    }

}

