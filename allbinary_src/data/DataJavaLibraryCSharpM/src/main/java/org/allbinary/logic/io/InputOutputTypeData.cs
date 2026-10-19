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

namespace org.allbinary.logic.io;

public class InputOutputTypeData
{
    private static readonly InputOutputTypeData instance = new InputOutputTypeData();
    public static InputOutputTypeData getInstance()
    {
        return InputOutputTypeData.instance;
    }

    private InputOutputTypeData()
    {
        this.DEFAULT = this.JSP;
        this.DEFAULT_FRAGMENT = this.JSP_FRAGMENT;
    }

    public readonly string NAME = "INPUT_OUTPUT_TYPE_NAME";
    public readonly string FILE = "INPUT_OUTPUT_TYPE_FILE";
    public readonly string RESPONSE = "INPUT_OUTPUT_TYPE_RESPONSE";
    public readonly string DB = "INPUT_OUTPUT_TYPE_DB";
    public readonly string JSP = "jsp";
    public readonly string JSP_FRAGMENT = "jspf";
    public readonly string PHP = "php";
    public readonly string ASP = "asp";
    public readonly string PL = "pl";
    public readonly string DEFAULT;
    public readonly string DEFAULT_FRAGMENT;
}

