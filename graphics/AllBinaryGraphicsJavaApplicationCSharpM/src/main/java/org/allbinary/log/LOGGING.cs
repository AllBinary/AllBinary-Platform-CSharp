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
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using StdUtil = org.allbinary.logic.StdUtil;

namespace org.allbinary.log;

public class LOGGING
{
    private string name;
    private static BasicArrayList logging = new BasicArrayListD();
    private LOGGING(string value)
    {
        this.name = value;
        LOGGING.logging.add(value);
    }

    public static bool contains(LOGGING logType)
    {
        return LOGGING.logging.contains(logType.ToString());
    }

    public override string ToString()
    {
        return this.name;
    }

    public static readonly LOGGING GRAPHICSPAINT = new LOGGING("Graphics Paint");
    public static readonly LOGGING GRAPHICSCREATION = new LOGGING("Graphics Creation");
    public static readonly LOGGING GRAPHICSDELETION = new LOGGING("Graphics Deletion");
    public static readonly LOGGING LOADINGERROR = new LOGGING("Loading Error");
    public static readonly LOGGING MENUEVENT = new LOGGING("Menu Action Event");
    public static readonly LOGGING MOUSEEVENT = new LOGGING("Mouse Action Event");
    public static readonly LOGGING KEYEVENT = new LOGGING("Keyboard Action Event");
    public static readonly LOGGING ACTIONEVENT = new LOGGING("Action Event");
    public static readonly LOGGING ADJUSTMENTEVENT = new LOGGING("Adjustment Action Event");
    public static readonly LOGGING COMPONENTEVENT = new LOGGING("Component Action Event");
    public static readonly LOGGING CONTAINEREVENT = new LOGGING("Container Action Event");
    public static readonly LOGGING FOCUSEVENT = new LOGGING("Focus Action Event");
    public static readonly LOGGING HIERARCHYEVENT = new LOGGING("Hierarchy Action Event");
    public static readonly LOGGING INPUTEVENT = new LOGGING("Input Action Event");
    public static readonly LOGGING INVOCATIONEVENT = new LOGGING("Invocation Action Event");
    public static readonly LOGGING ITEMEVENT = new LOGGING("Item Action Event");
    public static readonly LOGGING PAINTEVENT = new LOGGING("Paint Action Event");
    public static readonly LOGGING TEXTEVENT = new LOGGING("Text Action Event");
    public static readonly LOGGING WINDOWEVENT = new LOGGING("Window Action Event");
}

