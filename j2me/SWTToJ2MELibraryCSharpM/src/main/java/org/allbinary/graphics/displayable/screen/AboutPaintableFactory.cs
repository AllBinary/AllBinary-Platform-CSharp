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
using AboutPaintable = org.allbinary.game.paint.AboutPaintable;
using NullPaintable = org.allbinary.graphics.paint.NullPaintable;
using Paintable = org.allbinary.graphics.paint.Paintable;
using StringUtil = org.allbinary.logic.@string.StringUtil;

namespace org.allbinary.graphics.displayable.screen;

public class AboutPaintableFactory
{
    private static readonly AboutPaintableFactory instance = new AboutPaintableFactory();
    public static AboutPaintableFactory getInstance()
    {
        return AboutPaintableFactory.instance;
    }

    private AboutPaintableFactory()
    {
        string[] INFO = new string[] { "Built with the", "AllBinary Platform", StringUtil.getInstance().EMPTY_STRING, "Comments or Questions:", "support@allbinary.com" };
        string[] DEVELOPERS = new string[] { "Developed By:", "Travis Berthelot" };
        this.paintableArray = AboutPaintable.getInstance(INFO, DEVELOPERS).getPaintableArrayInstance();
    }

    public Paintable[] paintableArray = new Paintable[] { NullPaintable.getInstance() };
}

