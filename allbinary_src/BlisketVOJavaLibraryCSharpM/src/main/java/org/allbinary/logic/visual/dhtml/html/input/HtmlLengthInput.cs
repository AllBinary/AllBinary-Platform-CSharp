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

namespace org.allbinary.logic.visual.dhtml.html.input;

public class HtmlLengthInput : HtmlValueInput
{
    private readonly string MAXLENGTH = "MAXLENGTH";
    private readonly string SIZE = "SIZE";
    private string length = null;
    private string size = null;
    public HtmlLengthInput(string before, string type, string name, string value, string after) : base(before, type, name, value, after)
    {
        // base(before, type, name, value, after) is called from the constructor declaration
    }

    public virtual void setMaxLength(int? length)
    {
        this.Length = new string((length.ToString()).ToCharArray());
        addAttribute(this.MAXLENGTH, this.Length);
    }

    public virtual void setSize(int? size)
    {
        this.size = new string((size.ToString()).ToCharArray());
        addAttribute(this.MAXLENGTH, this.size);
    }

}

