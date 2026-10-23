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
using StringMaker = org.allbinary.logic.@string.StringMaker;
//using ResultSet = java.sql.ResultSet;
//using ResultSetMetaData = java.sql.ResultSetMetaData;
using Calendar = java.util.Calendar;
using Portion = org.allbinary.business.installer.Portion;
using AbFileOutputStream = org.allbinary.logic.io.AbFileOutputStream;
using BufferedLineReader = org.allbinary.logic.io.BufferedLineReader;
using StreamUtil = org.allbinary.logic.io.StreamUtil;
using AbFile = org.allbinary.logic.io.file.AbFile;
using FileUtil = org.allbinary.logic.io.file.FileUtil;
using Directory = org.allbinary.logic.io.file.directory.Directory;
using AbPath = org.allbinary.logic.io.path.AbPath;
using AbPathData = org.allbinary.logic.io.path.AbPathData;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using PATH_GLOBALS = org.allbinary.globals.PATH_GLOBALS;
//using OutputStream = java.io.OutputStream;
using CommonSeps = org.allbinary.@string.CommonSeps;
using CommonStrings = org.allbinary.@string.CommonStrings;
using StringUtil = org.allbinary.logic.@string.StringUtil;

namespace org.allbinary.logic.communication.sql;

public class AbSqlTableUtil
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly AbSqlTableUtil instance = new AbSqlTableUtil();
    public static AbSqlTableUtil getInstance()
    {
        return AbSqlTableUtil.instance;
    }

    private string EXTENSION = ".adb";
    private readonly string END = "')\n";
    private readonly string SAVING_BACKUP_PATH = "Saving Backup: Path: ";
    private readonly string FILE_LABEL = " File: ";
    private readonly string METHOD_RESTORE_TABLE = "restoreTable()";
    private readonly string METHOD_BACKUP_TABLE = "backupTable()";
    private readonly string METHOD_BACKUP_FILE = "backupFile()";
    private readonly string METHOD_GET_OUTPUT_STREAM = "getOutputStream()";
    private readonly string TABLE_CREATION_SUCCESS = "Table Creation Successful: ";
    private readonly string DROPPED_SUCCESS = " Dropped Successfully";
    private readonly string SAVING = "Saving: ";
    private readonly string APPENDING = "Appending: ";
    private readonly string TABLE_LABEL = "Table: ";
    private readonly string BACKUP_SUCCESS = " Backup Success";
    private readonly string ERROR_CREATING = "Error Creating: ";
    private readonly string TOTAL_LABEL = " Total: ";
    private readonly string SECTION_LABEL = " Section: ";
    private readonly string DASH = " - ";
    private readonly string PORTION_RESTORED = " Portion Restored";
    private readonly char[] specialCharArray = new char[] { '\n', '\f', '\r' };
    private readonly string NEW_LINE = "\\n";
    public readonly StringUtil stringUtil = StringUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    public readonly CommonSeps commonSeps = CommonSeps.getInstance();
    public readonly SqlStrings sqlStrings = SqlStrings.getInstance();
    [MethodImpl(MethodImplOptions.Synchronized)]
    private OutputStream getOutputStream(string backupPath, string tableName)
    {
        try {
            string fileName = tableName + this.EXTENSION;
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                this.logUtil.putF(this.SAVING + tableName, this, this.METHOD_GET_OUTPUT_STREAM);
            }
            AbPath backupFilePath = new AbPath(backupPath, fileName);
            AbFile backupFile = AbFile.createAbFile(backupFilePath);
            if (backupFile.exists()) {
                this.backupFile(backupFilePath, backupPath, tableName);
                backupFile.delete();
            }
            backupFile.createNewFile();
            OutputStream outputStream = new AbFileOutputStream(backupFile);
            return outputStream;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGINGERROR)) {
                this.logUtil.put("Create File", this, this.METHOD_GET_OUTPUT_STREAM, e);
            }
            return null;
        }
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    private bool backupFile(AbPath path, string backupPath, string tableName)
    {
        try {
            Calendar calendar = Calendar.getInstance();
            long? timeLong = calendar.getTimeInMillis();
            string time = timeLong.ToString();
            StringMaker stringBuffer = new StringMaker();
            string fileName = tableName + this.EXTENSION;
            stringBuffer.append(backupPath);
            stringBuffer.append(AbPathData.getInstance().SEPARATOR);
            stringBuffer.append(time);
            AbPath backupAbPath = new AbPath(stringBuffer.ToString());
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                stringBuffer.delete(0, stringBuffer.length());
                stringBuffer.append(this.SAVING_BACKUP_PATH);
                stringBuffer.append(backupAbPath.toFileSystemString());
                stringBuffer.append(this.FILE_LABEL);
                stringBuffer.append(fileName);
                this.logUtil.putF(stringBuffer.ToString(), this, this.METHOD_BACKUP_FILE);
            }
            Directory.create(backupAbPath);
            AbFile backupFileBak = AbFile.createAbFile(backupAbPath.toFileSystemString());
            backupFileBak.createNewFile();
            FileUtil.getInstance().copy(path, backupAbPath);
            return true;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGINGERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, this.METHOD_BACKUP_FILE, e);
            }
            return false;
        }
    }

    private string convertNewLines(string value)
    {
        StringMaker stringBuffer = new StringMaker();
        int index = 0;
        int lastIndex = 0;
        while (index < value.Length) {
            index = value.IndexOf(specialCharArray[0], lastIndex);
            if (index != -1) {
                string nextLine = value.Substring(lastIndex, (index - 1) - (lastIndex));
                stringBuffer.append(nextLine);
                stringBuffer.append(this.NEW_LINE);
                lastIndex = index + 1;
            } else {
                break;
            }
        }
        if (lastIndex < value.Length) {
            stringBuffer.append(value.Substring(lastIndex, (value.Length) - (lastIndex)));
        }
        return stringBuffer.ToString();
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual string backupTable(AbSqlTable abSqlTable)
    {
        string tableName = abSqlTable.getTableName();
        try {
            int count = 0;
            string sqlStatement = this.sqlStrings.SELECT_ALL_FROM + tableName;
            string path = org.allbinary.globals.URLGLOBALS.getMainPath() + PATH_GLOBALS.getInstance().BACKUP_PATH;
            if (!Directory.create(new AbPath(path))) {
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                    this.logUtil.putF(ERROR_CREATING + path, this, this.METHOD_BACKUP_TABLE);
                }
            }
            ResultSet rset = abSqlTable.executeSQLStatement(sqlStatement);
            ResultSetMetaData rsmd = rset.getMetaData();
            int colNum = rsmd.getColumnCount();
            string QUERY_START = new System.Text.StringBuilder().append(this.sqlStrings.INSERT_INTO).append(tableName).append(this.sqlStrings.VALUES).ToString();
            StringMaker stringBuffer = new StringMaker();
            OutputStream outputStream = this.getOutputStream(path, tableName);
            while (rset.next()) {
                stringBuffer.delete(0, stringBuffer.length());
                stringBuffer.append(QUERY_START);
                for (int i = 1; i < colNum; i++) {
                    string value = rset.getString(i);
                    stringBuffer.append(this.convertNewLines(value));
                    stringBuffer.append(this.sqlStrings.SINGLE_QUOTE_COMMA_SEP);
                }
                stringBuffer.append(rset.getString(colNum));
                stringBuffer.append(this.END);
                string sqlStatementLine = stringBuffer.ToString();
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                    this.logUtil.putF(this.APPENDING + sqlStatementLine, this, this.METHOD_BACKUP_TABLE);
                }
                outputStream.write(System.Array.ConvertAll(System.Text.Encoding.UTF8.GetBytes(sqlStatementLine), value => unchecked((sbyte) value)));
            }
            StreamUtil.getInstance().close(outputStream);
            return this.TABLE_LABEL + tableName + this.BACKUP_SUCCESS;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGINGERROR)) {
                this.logUtil.put("Backup Table Failed\nSQL Statement", this, this.METHOD_BACKUP_TABLE, e);
            }
            return this.TABLE_LABEL + tableName + " Backup Failed";
        }
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual string restoreTable(AbSqlTable abSqlTable, Portion portion)
    {
        string tableName = abSqlTable.getTableName();
        try {
            string path = org.allbinary.globals.URLGLOBALS.getMainPath() + PATH_GLOBALS.getInstance().BACKUP_PATH;
            int current = ((int) portion.getCurrent());
            if (current == 0) {
                if (Directory.create(new AbPath(path))) {
                    if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                        this.logUtil.putF(this.ERROR_CREATING + path, this, this.METHOD_RESTORE_TABLE);
                    }
                }
            }
            AbFile backupFile = AbFile.createAbFile(path, tableName + this.EXTENSION);
            BufferedLineReader bufferedLineReader = new BufferedLineReader(backupFile);
            long size = bufferedLineReader.getSize();
            long section = size / ((int) portion.getTotal()) + 1;
            long start = section * ((long) current);
            long end = start + section;
            if (end > size) {
                end = size;
            }
            StringMaker stringBuffer = new StringMaker();
            stringBuffer.append(this.TOTAL_LABEL);
            stringBuffer.append(size);
            stringBuffer.append(this.SECTION_LABEL);
            stringBuffer.append(start);
            stringBuffer.append(this.DASH);
            stringBuffer.append(end);
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                this.logUtil.putF(stringBuffer.ToString(), this, this.METHOD_RESTORE_TABLE);
            }
            bufferedLineReader.readUpToLines(start);
            string line = this.stringUtil.EMPTY_STRING;
            while (bufferedLineReader.getCurrent() < end && ((line = bufferedLineReader.readLine())) != null) {
                if (line.Length > 1) {
                    abSqlTable.executeSQLStatement(line);
                }
            }
            stringBuffer.append(this.commonSeps.SPACE);
            stringBuffer.append(this.TABLE_LABEL);
            stringBuffer.append(tableName);
            stringBuffer.append(this.PORTION_RESTORED);
            return stringBuffer.ToString();
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGINGERROR)) {
                this.logUtil.put("Restore Table Failed\nSQL Statement", this, this.METHOD_RESTORE_TABLE, e);
            }
            StringMaker stringBuffer = new StringMaker();
            stringBuffer.append(this.TABLE_LABEL);
            stringBuffer.append(tableName);
            stringBuffer.append(" Restoration Failed");
            return stringBuffer.ToString();
        }
    }

}

