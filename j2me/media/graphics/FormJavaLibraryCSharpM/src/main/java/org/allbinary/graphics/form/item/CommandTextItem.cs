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
//using Command = javax.microedition.lcdui.Command;
using BasicColor = org.allbinary.graphics.color.BasicColor;

namespace org.allbinary.graphics.form.item;

public class CommandTextItem : ABTextItem
{
    private readonly Command command;
    public CommandTextItem(Command command, int layout, string altText, BasicColor backgroundBasicColor, BasicColor foregroundBasicColor) : base(command.getLabel(), layout, altText, backgroundBasicColor, foregroundBasicColor)
    {
        // base(command.getLabel(), layout, altText, backgroundBasicColor, foregroundBasicColor) is called from the constructor declaration
        this.command = command;
    }

    public override bool isFocusable()
    {
        return true;
    }

    public virtual Command getCommand()
    {
        return this.command;
    }

}

