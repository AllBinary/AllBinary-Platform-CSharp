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

namespace org.allbinary.logic.visual.dhtml.style;

public class StyleData
{
    private static readonly StyleData instance = new StyleData();
    public static StyleData getInstance()
    {
        return StyleData.instance;
    }

    private StyleData()
    {
    }

    public readonly string NAME = "STYLE_NAME";
    public readonly int NAMEMAXLEN = 255;
}

