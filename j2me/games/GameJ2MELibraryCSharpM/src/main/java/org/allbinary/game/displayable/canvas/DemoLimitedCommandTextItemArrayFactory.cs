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
using CommandTextItemArrayFactory = org.allbinary.graphics.form.item.CommandTextItemArrayFactory;
using LimitCommandsVisitor = org.allbinary.graphics.form.item.LimitCommandsVisitor;

namespace org.allbinary.game.displayable.canvas;

public class DemoLimitedCommandTextItemArrayFactory
{
    private static readonly DemoLimitedCommandTextItemArrayFactory instance = new DemoLimitedCommandTextItemArrayFactory();
    private readonly CommandTextItemArrayFactory commandTextItemArrayFactory = new CommandTextItemArrayFactory(new LimitCommandsVisitor());
    public static DemoLimitedCommandTextItemArrayFactory getInstance()
    {
        return DemoLimitedCommandTextItemArrayFactory.instance;
    }

    public virtual CommandTextItemArrayFactory getCommandTextItemArrayFactory()
    {
        return this.commandTextItemArrayFactory;
    }

}

