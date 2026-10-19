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
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using AbFileInputStream = org.allbinary.logic.io.AbFileInputStream;
using StreamUtil = org.allbinary.logic.io.StreamUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;
using BasicArrayList = org.allbinary.util.BasicArrayList;

namespace org.allbinary.logic.io.file;

public class FileUtil2
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly FileUtil2 instance = new FileUtil2();
    public static FileUtil2 getInstance()
    {
        return FileUtil2.instance;
    }

    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private readonly StreamUtil streamUtil = StreamUtil.getInstance();
    private FileUtil2()
    {
    }

    public virtual BasicArrayList loadFileAsList(AbFile file, int max, sbyte[] byteArray1)
    {
        AbFileInputStream inputStream = null;
        try {
            inputStream = new AbFileInputStream(file);
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.ADD, e);
        }
        return SimpleFileUtil.getInstance().loadFileAsList(inputStream, max, byteArray1);
    }

}

