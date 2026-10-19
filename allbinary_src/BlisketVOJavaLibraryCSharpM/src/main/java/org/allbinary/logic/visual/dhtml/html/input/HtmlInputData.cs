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

public class HtmlInputData
{
    private static readonly HtmlInputData instance = new HtmlInputData();
    public static HtmlInputData getInstance()
    {
        return HtmlInputData.instance;
    }

    public readonly string TEXT = "text";
    public readonly string RADIO = "radio";
    public readonly string CHECKBOX = "checkbox";
    public readonly string HIDDEN = "hidden";
    public readonly string IMAGE = "image";
    public readonly string PASSWORD = "password";
    public readonly string RESET = "reset";
    public readonly string SUBMIT = "submit";
    public readonly string[] TYPES;
    public HtmlInputData()
    {
        this.TYPES = new string[] { this.TEXT, this.RADIO, this.CHECKBOX, this.HIDDEN, this.IMAGE, this.PASSWORD, this.RADIO, this.RESET, this.SUBMIT };
    }

}

