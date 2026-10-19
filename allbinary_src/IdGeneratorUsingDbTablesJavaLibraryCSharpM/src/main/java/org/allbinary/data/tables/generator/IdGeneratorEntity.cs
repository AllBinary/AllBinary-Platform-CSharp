/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2002 AllBinary 
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
using java.util;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using UserDbInitInfo = org.allbinary.business.init.db.UserDbInitInfo;
using StdUtil = org.allbinary.logic.StdUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using AbSqlBean = org.allbinary.logic.communication.sql.AbSqlBean;
using StringMaker = org.allbinary.logic.@string.StringMaker;

namespace org.allbinary.data.tables.generator;

public class IdGeneratorEntity : AbSqlBean, IdGeneratorEntityInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly string tableName = "idgenerator";
    private readonly string tableData;
    public readonly string NAME = "NAME";
    public readonly string VALUE = "VALUE";
    public IdGeneratorEntity() : base(new UserDbInitInfo())
    {
        // base(new UserDbInitInfo()) is called from the constructor declaration
        this.tableData = new StringMaker().append(this.sqlStrings.CREATE_TABLE).append(tableName).append(this.sqlStrings.START).append(NAME).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(VALUE).append(this.sqlTypeStrings.MAX_BIG_INT_UNSIGNED_NOT_NULL).append(this.sqlStrings.PRIMARY_KEY).append(NAME).append(this.sqlStrings.END).ToString();
        base.setTableName(this.tableName);
    }

    // throws Exception
    public virtual long? get(string name)
    {
        HashMap keysAndValues = StdUtil.getInstance().createHashMap();
        keysAndValues.put(this.NAME, name);
        HashMap hashMap = base.getRow(keysAndValues);
        if ((((string) hashMap.get(this.NAME))).compareTo(name) != 0) {
            throw new Exception("results do not match");
        }
        string value = ((string) hashMap.get(this.VALUE));
        return long.Parse(value);
    }

    public virtual void insert(BasicArrayList values)
    {
        try {
            base.insert(values);
            this.logUtil.putF(this.commonStrings.SUCCESS, this, INSERT);
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.FAILURE, this, INSERT, e);
        }
    }

    public virtual void delete(string value)
    {
        try {
            base.deleteWhere(this.NAME, value);
            this.logUtil.putF(this.commonStrings.SUCCESS, this, this.commonStrings.delete);
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.FAILURE, this, this.commonStrings.delete, e);
        }
    }

    public virtual void update(string name, long? value)
    {
        HashMap map = StdUtil.getInstance().createHashMap();
        map.put(this.NAME, name);
        map.put(this.VALUE, value.ToString());
        this.update(map);
    }

    public virtual void update(HashMap hashMap)
    {
        base.updateWhere(this.NAME, ((string) hashMap.get(this.NAME)), hashMap);
    }

    public virtual string createTable()
    {
        string returnStr = base.createTable(tableData);
        return returnStr;
    }

    public virtual string dropTable()
    {
        return base.dropTable();
    }

}

