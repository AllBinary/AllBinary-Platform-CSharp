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
//using BufferedWriter = java.io.BufferedWriter;
//using FileWriter = java.io.FileWriter;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using AbFile = org.allbinary.logic.io.file.AbFile;
using AbFileNativeUtil = org.allbinary.logic.io.file.AbFileNativeUtil;
using AbPathData = org.allbinary.logic.io.path.AbPathData;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using CommonLabels = org.allbinary.@string.CommonLabels;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.logic.io;

public class BufferedWriterUtil
{
    private static readonly BufferedWriterUtil instance = new BufferedWriterUtil();
    public static BufferedWriterUtil getInstance()
    {
        return BufferedWriterUtil.instance;
    }

    private readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private readonly CommonLabels commonLabels = CommonLabels.getInstance();
    private readonly string REMOVING_OLD = "Remove old for overwriting: ";
    // throws Exception
    public virtual void overwrite(string path, string data)
    {
        AbFile abFile = AbFile.createAbFile(path);
        if (abFile.exists()) {
            this.logUtil.putF(this.REMOVING_OLD + path, this, this.commonStrings.CREATE);
            abFile.delete();
        } else {
            string name = AbPathData.getInstance().removeNameFromPath(path);
            AbFile abFileDirectory = AbFile.createAbFile(name);
            if (abFileDirectory.exists()) {
            } else {
                StringMaker stringBuilder = new StringMaker();
                this.logUtil.putF(stringBuilder.append(this.commonStrings.CREATE).append(this.commonLabels.COLON_SEP).append(name).ToString(), this, this.commonStrings.CREATE);
                bool result = abFileDirectory.mkdirs();
                stringBuilder.delete(0, stringBuilder.length());
                this.logUtil.putF(stringBuilder.append(this.commonLabels.RESULT_).appendboolean(result).ToString(), this, this.commonStrings.CREATE);
            }
        }
        this.write(abFile, data);
    }

    // throws Exception
    public virtual void overwrite(AbFile abFile, string data)
    {
        if (abFile.exists()) {
            this.logUtil.putF(this.REMOVING_OLD + abFile.getPath(), this, this.commonStrings.CREATE);
            abFile.delete();
        } else {
            string name = AbPathData.getInstance().removeNameFromPath(abFile.getAbsolutePath());
            AbFile abFileDirectory = AbFile.createAbFile(name);
            if (abFileDirectory.exists()) {
            } else {
                StringMaker stringBuilder = new StringMaker();
                this.logUtil.putF(stringBuilder.append(this.commonStrings.CREATE).append(this.commonLabels.COLON_SEP).append(name).ToString(), this, this.commonStrings.CREATE);
                bool result = abFileDirectory.mkdirs();
                stringBuilder.delete(0, stringBuilder.length());
                this.logUtil.putF(stringBuilder.append(this.commonLabels.RESULT_).appendboolean(result).ToString(), this, this.commonStrings.CREATE);
            }
        }
        this.write(abFile, data);
    }

    // throws Exception
    public virtual void write(AbFile abFile, string data)
    {
        BufferedWriter fileOut = new BufferedWriter(new FileWriter(AbFileNativeUtil.get(abFile)));
        fileOut.write(data, 0, data.Length);
        fileOut.newLine();
        fileOut.flush();
    }

}

