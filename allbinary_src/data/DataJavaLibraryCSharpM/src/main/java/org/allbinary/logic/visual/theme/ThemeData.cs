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

namespace org.allbinary.logic.visual.theme;

public class ThemeData
{
    private static readonly ThemeData instance = new ThemeData();
    public static ThemeData getInstance()
    {
        return ThemeData.instance;
    }

    private ThemeData()
    {
    }

    public readonly string NAME = "THEME_NAME";
    public readonly string PATH = "THEME_PATH";
    public readonly string PREVIEW_IMAGE_NAME = "THEME_PREVIEW_IMAGE_NAME";
    public readonly string PREVIEW_IMAGE_PATH = "THEME_PREVIEW_IMAGE_PATH";
}

