/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2022 AllBinary 
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
//using CommandListener = javax.microedition.lcdui.CommandListener;
//using Font = javax.microedition.lcdui.Font;
using BasicColor = org.allbinary.graphics.color.BasicColor;
using CustomTextBox = org.allbinary.graphics.form.item.CustomTextBox;

namespace org.allbinary.animation.text;

public class CustomTextBox2 : CustomTextBox
{
    public CustomTextBox2(CommandListener cmdListener, string label, string text, int maxSize, int constraints, Font font, BasicColor backgroundBasicColor, BasicColor foregroundBasicColor) : base(cmdListener, label, text, maxSize, constraints, font, backgroundBasicColor, foregroundBasicColor)
    {
        // base(cmdListener, label, text, maxSize, constraints, font, backgroundBasicColor, foregroundBasicColor) is called from the constructor declaration
        this.getTextFieldItem().setFocus(true);
    }

}

