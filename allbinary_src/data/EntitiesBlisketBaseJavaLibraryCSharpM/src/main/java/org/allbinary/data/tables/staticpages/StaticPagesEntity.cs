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
using StoreFrontData = org.allbinary.business.context.modules.storefront.StoreFrontData;
using StaticPagesDbInitInfo = org.allbinary.business.init.db.StaticPagesDbInitInfo;
using BasicItemData = org.allbinary.business.user.commerce.inventory.item.BasicItemData;
using StdUtil = org.allbinary.logic.StdUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using AbSqlBean = org.allbinary.logic.communication.sql.AbSqlBean;
using SearchData = org.allbinary.logic.control.search.SearchData;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using CommonSeps = org.allbinary.@string.CommonSeps;

namespace org.allbinary.data.tables.staticpages;

public class StaticPagesEntity : AbSqlBean, StaticPagesEntityInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly BasicItemData basicItemData = BasicItemData.getInstance();
    private readonly string TABLENAME = "staticpages";
    public StaticPagesEntity() : base(new StaticPagesDbInitInfo())
    {
        // base(new StaticPagesDbInitInfo()) is called from the constructor declaration
        this.setTableName(this.TABLENAME);
    }

    public virtual void insert(BasicArrayList values)
    {
        try {
            base.insert(values);
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                this.logUtil.putF(this.commonStrings.SUCCESS, this, INSERT);
            }
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                this.logUtil.put(this.commonStrings.FAILURE, this, INSERT, e);
            }
        }
    }

    public virtual string getFile(string store, string keywords)
    {
        HashMap<object, object> whereHashMap = StdUtil.getInstance().createHashMap();
        whereHashMap.put(StoreFrontData.getInstance().NAME, store);
        whereHashMap.put(basicItemData.KEYWORDS, keywords);
        string file = base.getField(whereHashMap, SearchData.PAGE);
        return file;
    }

    public virtual void delete(string keywords)
    {
        base.deleteWhere(basicItemData.KEYWORDS, keywords);
    }

    public virtual string dropTable()
    {
        string returnStr = base.dropTable();
        return returnStr;
    }

    public virtual void update(HashMap<object, object> updatedValues)
    {
        base.updateWhere(basicItemData.KEYWORDS, ((string) updatedValues.get(basicItemData.KEYWORDS)), updatedValues);
    }

    public string createTableStatement()
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(this.sqlStrings.CREATE_TABLE).append(TABLENAME).append(this.sqlStrings.START).append(StoreFrontData.getInstance().NAME).append(this.sqlTypeStrings.SIXTY_CHAR_COLUMN_NOT_NULL).append(basicItemData.KEYWORDS).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(SearchData.PAGE).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(this.sqlStrings.PRIMARY_KEY).append(StoreFrontData.getInstance().NAME).append(CommonSeps.getInstance().COMMA_SEP).append(basicItemData.KEYWORDS).append(this.sqlStrings.END);
        return stringBuffer.ToString();
    }

    public virtual string createTable()
    {
        return base.createTable(this.createTableStatement());
    }

}

