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
using Portion = org.allbinary.business.installer.Portion;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using CommonSeps = org.allbinary.@string.CommonSeps;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.logic.communication.sql;

public class AbSqlTableUtil
{
    private static readonly AbSqlTableUtil instance = new AbSqlTableUtil();
    public static AbSqlTableUtil getInstance()
    {
        return AbSqlTableUtil.instance;
    }

    private readonly string TABLE_LABEL = "Table: ";
    public readonly StringUtil stringUtil = StringUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    public readonly CommonSeps commonSeps = CommonSeps.getInstance();
    public readonly SqlStrings sqlStrings = SqlStrings.getInstance();
    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual string backupTable(AbSqlTable abSqlTable)
    {
        string tableName = abSqlTable.getTableName();
        return this.TABLE_LABEL + tableName + " Backup Failed";
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual string restoreTable(AbSqlTable abSqlTable, Portion portion)
    {
        string tableName = abSqlTable.getTableName();
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(this.TABLE_LABEL);
        stringBuffer.append(tableName);
        stringBuffer.append(" Restoration Failed");
        return stringBuffer.ToString();
    }

}

