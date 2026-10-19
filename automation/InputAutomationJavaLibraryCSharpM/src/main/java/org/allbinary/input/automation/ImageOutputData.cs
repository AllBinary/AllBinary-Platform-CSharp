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
using StringMaker = org.allbinary.logic.@string.StringMaker;

namespace org.allbinary.input.automation;

public class ImageOutputData
{
    private ImageOutputData()
    {
    }

    public static readonly string SAVE_PATH = new StringMaker().append(System.getProperty("user.dir")).appendchar(FilePathData.getInstance().SEPARATORCHAR).append("saves").appendchar(FilePathData.getInstance().SEPARATORCHAR).ToString();
}

