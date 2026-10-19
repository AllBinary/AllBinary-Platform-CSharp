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
using AbPathData = org.allbinary.logic.io.path.AbPathData;
using StringValidationUtil = org.allbinary.logic.@string.StringValidationUtil;

namespace org.allbinary.logic.io.file;

//Used to correct user input for paths
public class FilePathUtil
{
    private FilePathUtil()
    {
    }

    public static string adjust(string path)
    {
        AbPathData abPathData = AbPathData.getInstance();
        StringValidationUtil stringValidationUtil = StringValidationUtil.getInstance();
        FilePathData filePathData = FilePathData.getInstance();
        if (stringValidationUtil.isEmpty(path)) {
            return filePathData.PATH_START;
        }
        path = path.Replace(abPathData.SEPARATORCHAR, filePathData.SEPARATORCHAR);
        return path;
    }

}

