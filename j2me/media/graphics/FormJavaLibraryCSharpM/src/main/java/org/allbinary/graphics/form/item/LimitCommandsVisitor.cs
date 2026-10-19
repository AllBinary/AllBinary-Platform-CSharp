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
using GameCommandsFactory = org.allbinary.game.commands.GameCommandsFactory;
using DisplayInfoSingleton = org.allbinary.graphics.displayable.DisplayInfoSingleton;
using ScreenInfo = org.allbinary.graphics.form.ScreenInfo;
using BooleanFactory = org.allbinary.logic.java.@bool.BooleanFactory;
using Visitor = org.allbinary.logic.util.visitor.Visitor;

namespace org.allbinary.graphics.form.item;

public class LimitCommandsVisitor : Visitor
{
    private readonly bool isNotSmallDisplay;
    public LimitCommandsVisitor()
    {
        DisplayInfoSingleton displayInfo = DisplayInfoSingleton.getInstance();
        this.isNotSmallDisplay = (displayInfo.isPortrait() && displayInfo.getLastHeight() > ScreenInfo.getInstance().SMALL_WIDTH) || (!displayInfo.isPortrait() && displayInfo.getLastHeight() > ScreenInfo.getInstance().SMALL_HEIGHT);
    }

    public override object visit(object anyType)
    {
        Command command = ((Command) anyType);
        BooleanFactory booleanFactory = BooleanFactory.getInstance();
        if (this.isNotSmallDisplay || command.getPriority() == 1 || command == GameCommandsFactory.getInstance().EXIT_COMMAND || command == GameCommandsFactory.getInstance().EXIT_WITHOUT_PROGRESS_COMMAND) {
            return booleanFactory.TRUE;
        } else {
            return booleanFactory.FALSE;
        }
    }

}

