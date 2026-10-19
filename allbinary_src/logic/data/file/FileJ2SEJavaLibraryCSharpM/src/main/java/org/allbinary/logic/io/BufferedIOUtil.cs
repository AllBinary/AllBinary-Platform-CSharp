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
//using BufferedReader = java.io.BufferedReader;
//using BufferedWriter = java.io.BufferedWriter;
//using FileReader = java.io.FileReader;
//using FileWriter = java.io.FileWriter;
using AbFile = org.allbinary.logic.io.file.AbFile;
using AbFileNativeUtil = org.allbinary.logic.io.file.AbFileNativeUtil;
using StringUtil = org.allbinary.logic.@string.StringUtil;

namespace org.allbinary.logic.io;

public class BufferedIOUtil
{
    // throws Exception
    public static void copy(AbFile backupFile, AbFile backupFileBak)
    {
        string line = StringUtil.getInstance().EMPTY_STRING;
        BufferedWriter tmpOut = new BufferedWriter(new FileWriter(AbFileNativeUtil.get(backupFileBak)));
        BufferedReader tmpIn = new BufferedReader(new FileReader(AbFileNativeUtil.get(backupFile)));
        while (true) {
            line = tmpIn.readLine();
            if (line == null) {
                break;
            }
            tmpOut.write(line, 0, line.Length);
            tmpOut.newLine();
        }
        tmpOut.flush();
    }

}

