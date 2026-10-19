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
using FilePathData = org.allbinary.logic.io.file.FilePathData;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using CommonSeps = org.allbinary.@string.CommonSeps;

namespace org.allbinary.logic.io.path;

public class AbPathData
{
    private static readonly AbPathData instance = new AbPathData();
    public static AbPathData getInstance()
    {
        return AbPathData.instance;
    }

    public readonly string EXTENSION_SEP = CommonSeps.getInstance().PERIOD;
    public readonly char SEPARATORCHAR = '/';
    public readonly string SEPARATOR = CommonSeps.getInstance().FORWARD_SLASH;
    private AbPathData()
    {
    }

}

