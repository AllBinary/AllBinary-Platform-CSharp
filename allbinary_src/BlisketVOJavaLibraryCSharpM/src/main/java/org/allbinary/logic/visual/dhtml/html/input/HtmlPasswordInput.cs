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

public class HtmlPasswordInput : HtmlLengthInput
{
    public HtmlPasswordInput(string before, string name, string value, string after) : base(before, HtmlInputData.getInstance().PASSWORD, name, value, after)
    {
        // base(before, HtmlInputData.getInstance().PASSWORD, name, value, after) is called from the constructor declaration
        setSize(32);
        setMaxLength(128);
    }

}

