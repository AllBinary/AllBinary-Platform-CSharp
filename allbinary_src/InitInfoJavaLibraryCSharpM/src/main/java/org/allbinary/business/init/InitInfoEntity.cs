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
using java.util;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using UserDbInitInfo = org.allbinary.business.init.db.UserDbInitInfo;
using StdUtil = org.allbinary.logic.StdUtil;
using PreLogUtil = org.allbinary.logic.communication.log.PreLogUtil;
using LogConfigTypeFactory = org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory;
using LogConfigTypes = org.allbinary.logic.communication.log.config.type.LogConfigTypes;
using AbPathData = org.allbinary.logic.io.path.AbPathData;
using StringMaker = org.allbinary.logic.@string.StringMaker;

namespace org.allbinary.business.init;

public class InitInfoEntity : InitSql
{
    private readonly string NAME = "InitInfoEntity";
    private readonly string NOTHING = "NOTHING";
    private readonly string tableName = "initdata";
    private readonly string tableData;
    private readonly string NOT_IN_DB = "Not In DB";
    private readonly string METHOD_GET = "get()";
    private readonly string METHOD_IS = "is()";
    private readonly string METHOD_ADD = "add()";
    private readonly string CREATED_SUCCESS = " Created Successfully";
    private readonly string FAILED_TO_CREATE = "Failed to create ";
    public InitInfoEntity() : base(new UserDbInitInfo())
    {
        // base(new UserDbInitInfo()) is called from the constructor declaration
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(this.sqlStrings.CREATE_TABLE);
        stringBuffer.append(this.tableName);
        stringBuffer.append(this.sqlStrings.START);
        stringBuffer.append(this.NOTHING);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(InitInfo.getInstance().TESTING);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(InitInfo.getInstance().TESTHTMLPATH);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(InitInfo.getInstance().MAINPATH);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(this.sqlStrings.PRIMARY_KEY);
        stringBuffer.append(this.NOTHING);
        stringBuffer.append(this.sqlStrings.END);
        this.tableData = stringBuffer.ToString();
        this.setTable(this.tableName);
    }

    public virtual bool get()
    {
        try {
            HashMap<object, object> keyAndValue = StdUtil.getInstance().createHashMap();
            keyAndValue.put(this.NOTHING, this.NOTHING);
            HashMap<object, object> hashMap = getRow(keyAndValue);
            if (hashMap != null) {
                InitInfo.getInstance().set(hashMap);
                return true;
            } else {
                if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().PRELOADER)) {
                    PreLogUtil.put(this.NOT_IN_DB, NAME, this.METHOD_GET);
                }
                return false;
            }
        } catch (Exception e) {
            if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().PRELOADERERROR)) {
                PreLogUtil.putOE(this.commonStrings.EXCEPTION, this.NAME, this.METHOD_GET, e);
            }
            return false;
        }
    }

    public virtual bool @is()
    {
        try {
            HashMap<object, object> keyAndValue = StdUtil.getInstance().createHashMap();
            keyAndValue.put(this.NOTHING, this.NOTHING);
            HashMap<object, object> hashMap = getRow(keyAndValue);
            if (hashMap != null) {
                return true;
            } else {
                if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().PRELOADER)) {
                    PreLogUtil.put(this.NOT_IN_DB, this.NAME, this.METHOD_IS);
                }
                return false;
            }
        } catch (Exception e) {
            if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().PRELOADERERROR)) {
                PreLogUtil.putOE(this.commonStrings.EXCEPTION, this.NAME, this.METHOD_IS, e);
            }
            return false;
        }
    }

    public virtual void update()
    {
        updateWhere(NOTHING, NOTHING, InitInfo.getInstance().toHashMap());
    }

    public virtual void add()
    {
        try {
            BasicArrayList values = new BasicArrayListD();
            values.add(this.NOTHING);
            values.add(InitInfo.getInstance().getTesting());
            values.add(InitInfo.getInstance().getTestHtmlPath());
            values.add(InitInfo.getInstance().getMainPath());
            insert(values);
        } catch (Exception e) {
            if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().PRELOADERERROR)) {
                PreLogUtil.putOE(this.commonStrings.EXCEPTION, this.NAME, this.METHOD_ADD, e);
            }
        }
    }

    public virtual string createTable()
    {
        if (base.createTable(this.tableData)) {
            return this.tableName + this.CREATED_SUCCESS;
        } else {
            StringMaker stringBuffer = new StringMaker();
            stringBuffer.append(this.FAILED_TO_CREATE);
            stringBuffer.append(this.tableData);
            stringBuffer.append(AbPathData.getInstance().EXTENSION_SEP);
            return stringBuffer.ToString();
        }
    }

}

