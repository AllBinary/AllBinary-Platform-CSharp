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
using System.Runtime.CompilerServices;
//using BufferedReader = java.io.BufferedReader;
//using BufferedWriter = java.io.BufferedWriter;
//using File = java.io.File;
//using FileReader = java.io.FileReader;
//using FileWriter = java.io.FileWriter;
//using RandomAccessFile = java.io.RandomAccessFile;
using CommonSeps = org.allbinary.@string.CommonSeps;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using LogFormatUtil = org.allbinary.logic.communication.log.LogFormatUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;

namespace org.allbinary.log;

public class FileLog
{
    private static readonly StringUtil stringUtil = StringUtil.getInstance();
    private static readonly long logLength = 33000000L;
    private static readonly string logPath = "g:\\log\\";
    private static readonly string extension = new string(("dat").ToCharArray());
    private static readonly string fileName = new string(("log." + FileLog.extension).ToCharArray());
    private static readonly string backupFileName = FileLog.fileName.concat(".bak");
    private static readonly string ORG_ALLBINARY = "org.allbinary: ";
    private static bool firstTime = true;
    private static File logFile = new File(FileLog.logPath, FileLog.fileName);
    private static File logFileBak = null;
    private static BufferedWriter fileOut = null;
    private static int backupIndex = 0;
    private FileLog()
    {
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public static bool createLogFile()
    {
        try {
            FileLog.logFile = new File(logPath, fileName);
            if (!FileLog.firstTime) {
                FileLog.fileOut = new BufferedWriter(new FileWriter(logFile));
            } else {
                FileLog.firstTime = false;
                RandomAccessFile raFile = new RandomAccessFile(logFile, "rw");
                raFile.seek(raFile.length());
                FileLog.fileOut = new BufferedWriter(new FileWriter(raFile.getFD()));
            }
            bool canWrite = FileLog.logFile.canWrite();
            return canWrite;
        } catch (Exception e) {
            Console.WriteLine("Error Creating Log: " + e);
            return false;
        }
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    private static bool createLogFileBackup()
    {
        try {
            StringMaker stringMaker = new StringMaker();
            FileLog.logFileBak = new File(logPath, stringMaker.append(backupFileName).append(CommonSeps.getInstance().PERIOD).appendint(backupIndex).ToString());
            while (FileLog.logFileBak.isFile()) {
                FileLog.backupIndex++;
                stringMaker.delete(0, stringMaker.length());
                FileLog.logFileBak = new File(logPath, stringMaker.append(backupFileName).append(CommonSeps.getInstance().PERIOD).appendint(backupIndex).ToString());
            }
            string line = "";
            BufferedWriter tmpOut = new BufferedWriter(new FileWriter(logFileBak));
            BufferedReader tmpIn = new BufferedReader(new FileReader(logFile));
            while (((line = tmpIn.readLine())) != null) {
                tmpOut.write(line, 0, line.Length);
                tmpOut.newLine();
            }
            tmpOut.flush();
            tmpOut.close();
            tmpIn.close();
            FileLog.logFile.delete();
            return true;
        } catch (Exception e) {
            Console.WriteLine("Error Creating Backup: " + e);
            return false;
        }
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public static string put(string specialMessage, object anyType, string functionName)
    {
        return FileLog.put(specialMessage, anyType, functionName, null);
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public static string put(string specialMessage, object anyType, string functionName, Exception exception)
    {
        try {
            if (FileLog.firstTime == true) {
                FileLog.createLogFileBackup();
                if (createLogFile() == false) {
                    return new string(("Log File Creation Error").ToCharArray());
                }
            }
            long length = ((long) FileLog.logFile.length());
            if (length > FileLog.logLength) {
                if (!(createLogFileBackup()) || createLogFile() == false) {
                    return new string(("Couldn't Create a Backup file").ToCharArray());
                }
            }
            string className = new string((stringUtil.NULL_STRING).ToCharArray());
            if (functionName == null) {
                functionName = new string((FileLog.stringUtil.NULL_STRING).ToCharArray());
            }
            if (specialMessage == null) {
                specialMessage = new string((FileLog.stringUtil.NULL_STRING).ToCharArray());
            }
            if (anyType.GetType().FullName != null) {
                className = new string((anyType.GetType().FullName).ToCharArray());
            }
            string message = LogFormatUtil.getInstance().get(className, functionName, specialMessage, exception);
            FileLog.fileOut.write(message, 0, message.Length);
            FileLog.fileOut.newLine();
            FileLog.fileOut.flush();
            return new string((FileLog.ORG_ALLBINARY + message).ToCharArray());
        } catch (Exception e) {
            return new string(("Error: " + e).ToCharArray());
        }
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public static string put(string specialMessage, string className, string functionName)
    {
        return FileLog.put(specialMessage, className, functionName, null);
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public static string put(string specialMessage, string className, string functionName, Exception exception)
    {
        try {
            if (FileLog.firstTime == true) {
                FileLog.createLogFileBackup();
                if (createLogFile() == false) {
                    return new string(("Log File Creation Error").ToCharArray());
                }
            }
            long length = ((long) FileLog.logFile.length());
            if (length > FileLog.logLength) {
                if (!(createLogFileBackup()) || createLogFile() == false) {
                    return new string(("Couldn't Create a Backup file").ToCharArray());
                }
            }
            if (functionName == null) {
                functionName = new string((FileLog.stringUtil.NULL_STRING).ToCharArray());
            }
            if (specialMessage == null) {
                specialMessage = new string((FileLog.stringUtil.NULL_STRING).ToCharArray());
            }
            string message = LogFormatUtil.getInstance().get(className, functionName, specialMessage, exception);
            FileLog.fileOut.write(message, 0, message.Length);
            FileLog.fileOut.newLine();
            FileLog.fileOut.flush();
            return new string((FileLog.ORG_ALLBINARY + message).ToCharArray());
        } catch (Exception e) {
            return new string(("Error: " + e).ToCharArray());
        }
    }

    public static string getFilePath()
    {
        return FileLog.logPath + FileLog.fileName;
    }

}

