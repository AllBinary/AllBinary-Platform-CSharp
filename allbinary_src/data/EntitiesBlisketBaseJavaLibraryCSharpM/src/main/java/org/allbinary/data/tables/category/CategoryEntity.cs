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
using Category = org.allbinary.business.category.Category;
using CategoryData = org.allbinary.business.category.CategoryData;
using CategoryFactoryInterface = org.allbinary.business.category.CategoryFactoryInterface;
using InventoryDbInitInfo = org.allbinary.business.init.db.InventoryDbInitInfo;
using StdUtil = org.allbinary.logic.StdUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using AbSqlBean = org.allbinary.logic.communication.sql.AbSqlBean;
using StringMaker = org.allbinary.logic.@string.StringMaker;

namespace org.allbinary.data.tables.category;

public class CategoryEntity : AbSqlBean, CategoryEntityInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly string tableName = "categories";
    public CategoryEntity(CategoryFactoryInterface categoryFactoryInterface) : base(new InventoryDbInitInfo())
    {
        // base(new InventoryDbInitInfo()) is called from the constructor declaration
        this.setTableName(this.tableName);
    }

    public CategoryEntity() : base(new InventoryDbInitInfo())
    {
        // base(new InventoryDbInitInfo()) is called from the constructor declaration
        this.setTableName(this.tableName);
    }

    public virtual void insert(Category category)
    {
        try {
            BasicArrayList categoryVector = category.toVector();
            BasicArrayList values = new BasicArrayListD();
            values.add(categoryVector.get(0));
            values.add(categoryVector.get(1));
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

    public virtual void delete(string value)
    {
        try {
            base.deleteWhere(CategoryData.getInstance().NAME, value);
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                this.logUtil.putF(this.commonStrings.SUCCESS, this, this.commonStrings.delete);
            }
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                this.logUtil.put(this.commonStrings.FAILURE, this, this.commonStrings.delete, e);
            }
        }
    }

    public string createTableStatement()
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(this.sqlStrings.CREATE_TABLE);
        stringBuffer.append(this.tableName);
        stringBuffer.append(this.sqlStrings.START);
        stringBuffer.append(CategoryData.getInstance().NAME);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(CategoryData.getInstance().LEVEL);
        stringBuffer.append(this.sqlTypeStrings.MAX_BIG_INT_UNSIGNED_NOT_NULL);
        stringBuffer.append(this.sqlStrings.PRIMARY_KEY);
        stringBuffer.append(CategoryData.getInstance().NAME);
        stringBuffer.append(this.sqlStrings.END);
        return stringBuffer.ToString();
    }

    public virtual string createTable()
    {
        return base.createTable(this.createTableStatement());
    }

    public virtual void update(HashMap updatedValues)
    {
        base.updateWhere(CategoryData.getInstance().NAME, ((string) updatedValues.get(CategoryData.getInstance().NAME)), updatedValues);
    }

    public virtual string dropTable()
    {
        return base.dropTable();
    }

}

