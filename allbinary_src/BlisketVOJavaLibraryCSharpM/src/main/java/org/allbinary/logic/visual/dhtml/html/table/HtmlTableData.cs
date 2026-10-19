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
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.logic.visual.dhtml.html.table;

public class HtmlTableData
{
    private static readonly HtmlTableData instance = new HtmlTableData();
    public static HtmlTableData getInstance()
    {
        return HtmlTableData.instance;
    }

    public readonly string LEFT = CommonStrings.getInstance().LEFT;
    public readonly string RIGHT = CommonStrings.getInstance().RIGHT;
    public readonly string NONE = "none";
    public readonly string TOP = "top";
    public readonly string BOTTOM = "bottom";
    public readonly string TOPBOT = "topbot";
    public readonly string SIDES = "sides";
    public readonly string ALL = "all";
    public readonly string BORDERED = "border";
    public readonly string BASIC = "basic";
    public readonly string ROWS = "rows";
    public readonly string[] FRAMES;
    public HtmlTableData()
    {
        this.FRAMES = new string[] { this.NONE, this.TOP, this.BOTTOM, this.TOPBOT, this.SIDES, this.ALL, this.BORDERED };
    }

}

