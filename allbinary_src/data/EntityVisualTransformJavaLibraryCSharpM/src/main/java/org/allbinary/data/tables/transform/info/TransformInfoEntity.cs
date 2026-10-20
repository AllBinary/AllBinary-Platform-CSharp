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
//using PageContext = javax.servlet.jsp.PageContext;
using StoreFrontData = org.allbinary.business.context.modules.storefront.StoreFrontData;
using EntryData = org.allbinary.business.entry.EntryData;
using UserDbInitInfo = org.allbinary.business.init.db.UserDbInitInfo;
using DomDocumentHelper = org.allbinary.data.tree.dom.document.DomDocumentHelper;
using StdUtil = org.allbinary.logic.StdUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using AbSqlBean = org.allbinary.logic.communication.sql.AbSqlBean;
using Encoder = org.allbinary.logic.control.crypt.Encoder;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using AbeClientInformationInterface = org.allbinary.logic.system.security.licensing.AbeClientInformationInterface;
using ServiceClientInformationInterfaceFactory = org.allbinary.logic.system.security.licensing.ServiceClientInformationInterfaceFactory;
using TransformInfoData = org.allbinary.logic.visual.transform.info.TransformInfoData;
using TransformInfoFactoryInterface = org.allbinary.logic.visual.transform.info.TransformInfoFactoryInterface;
using TransformInfoInterface = org.allbinary.logic.visual.transform.info.TransformInfoInterface;
using TransformInfoObjectConfigAndManipulatorFactoryBase = org.allbinary.logic.visual.transform.info.objectConfig.TransformInfoObjectConfigAndManipulatorFactoryBase;
using TransformInfoObjectConfigGeneratorFactoryInterface = org.allbinary.logic.visual.transform.info.objectConfig.generator.TransformInfoObjectConfigGeneratorFactoryInterface;

namespace org.allbinary.data.tables.transform.info;

public class TransformInfoEntity : AbSqlBean, TransformInfoEntityInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly string tableName = "transforminfo";
    private readonly AbeClientInformationInterface abeClientInformation = ServiceClientInformationInterfaceFactory.getInstance();
    private readonly TransformInfoFactoryInterface transformInfoFactoryInterface;
    private readonly TransformInfoObjectConfigAndManipulatorFactoryBase transformInfoObjectConfigAndManipulatorFactoryInterface;
    private readonly TransformInfoObjectConfigGeneratorFactoryInterface transformInfoObjectConfigGeneratorFactoryInterface;
    public TransformInfoEntity(TransformInfoObjectConfigGeneratorFactoryInterface transformInfoObjectConfigGeneratorFactoryInterface, TransformInfoObjectConfigAndManipulatorFactoryBase transformInfoObjectConfigAndManipulatorFactoryInterface, TransformInfoFactoryInterface transformInfoFactoryInterface) : base(new UserDbInitInfo())
    {
        // base(new UserDbInitInfo()) is called from the constructor declaration
        this.setTableName(this.tableName);
        this.transformInfoObjectConfigGeneratorFactoryInterface = transformInfoObjectConfigGeneratorFactoryInterface;
        this.transformInfoObjectConfigAndManipulatorFactoryInterface = transformInfoObjectConfigAndManipulatorFactoryInterface;
        this.transformInfoFactoryInterface = transformInfoFactoryInterface;
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

    public virtual void delete(string value)
    {
        try {
            base.deleteWhere(TransformInfoData.getInstance().NAME, value);
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                this.logUtil.putF(this.commonStrings.SUCCESS, this, this.commonStrings.delete);
            }
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                this.logUtil.put(this.commonStrings.FAILURE, this, this.commonStrings.delete, e);
            }
        }
    }

    // throws Exception
    public virtual TransformInfoInterface get(string name, HashMap<object, object> propertiesHashMap, PageContext pageContext)
    {
        TransformInfoData transformInfoData = TransformInfoData.getInstance();
        HashMap<object, object> keysAndValues = StdUtil.getInstance().createHashMap();
        keysAndValues.put(transformInfoData.NAME, name);
        HashMap<object, object> hashMap = base.getRow(keysAndValues);
        if (hashMap != null) {
            object anyType = hashMap.get(transformInfoData.OBJECTCONFIG);
            if (anyType != null) {
                string @string = ((string) anyType);
                hashMap.put(transformInfoData.OBJECTCONFIG, new string((Encoder.decode(@string)).ToCharArray()));
            }
            object objectData = hashMap.get(transformInfoData.DATA);
            if (objectData != null) {
                string @string = ((string) objectData);
                hashMap.put(transformInfoData.DATA, new string((Encoder.decode(@string)).ToCharArray()));
            }
            return this.transformInfoFactoryInterface.getInstance(hashMap, propertiesHashMap, pageContext);
        } else {
            return null;
        }
    }

    // throws Exception
    public virtual BasicArrayList getObjectConfigs(string storeName)
    {
        BasicArrayList objectConfigVector = new BasicArrayListD();
        BasicArrayList objectConfigColumnVector = this.getColumnWhere(TransformInfoData.getInstance().OBJECTCONFIG, StoreFrontData.getInstance().NAME, storeName);
        int size = objectConfigColumnVector.size();
        for (int i = 0; i < size; i++) {
            string objectConfigString = ((string) objectConfigColumnVector.get(i));
            objectConfigString = new string((Encoder.decode(objectConfigString)).ToCharArray());
            objectConfigVector.add(this.transformInfoObjectConfigAndManipulatorFactoryInterface.getInstance(this.abeClientInformation, ((TransformInfoInterface) this), DomDocumentHelper.create(objectConfigString)));
        }
        return objectConfigVector;
    }

    // throws Exception
    public virtual BasicArrayList getNames(string storeName)
    {
        BasicArrayList viewNameVector = new BasicArrayListD();
        BasicArrayList columnVector = this.getColumnWhere(TransformInfoData.getInstance().NAME, StoreFrontData.getInstance().NAME, storeName);
        int size = columnVector.size();
        for (int i = 0; i < size; i++) {
            string viewNameString = ((string) columnVector.get(i));
            viewNameVector.add(viewNameString);
        }
        return viewNameVector;
    }

    public string createTableStatement()
    {
        TransformInfoData transformInfoData = TransformInfoData.getInstance();
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(this.sqlStrings.CREATE_TABLE);
        stringBuffer.append(this.tableName);
        stringBuffer.append(this.sqlStrings.START);
        stringBuffer.append(transformInfoData.NAME);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(StoreFrontData.getInstance().NAME);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(transformInfoData.OBJECTFILENAME);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(transformInfoData.OBJECT);
        stringBuffer.append(this.sqlTypeStrings.BLOB_NOT_NULL);
        stringBuffer.append(transformInfoData.OBJECTCONFIGFILENAME);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(transformInfoData.OBJECTCONFIG);
        stringBuffer.append(this.sqlTypeStrings.BLOB_NOT_NULL);
        stringBuffer.append(transformInfoData.TEMPLATEFILENAME);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(transformInfoData.TEMPLATE);
        stringBuffer.append(this.sqlTypeStrings.BLOB_NOT_NULL);
        stringBuffer.append(transformInfoData.DATAFILENAME);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(transformInfoData.DATA);
        stringBuffer.append(this.sqlTypeStrings.BLOB_NOT_NULL);
        stringBuffer.append(EntryData.getInstance().LASTMODIFIED);
        stringBuffer.append(EntryData.getInstance().TIMECREATED);
        stringBuffer.append(this.sqlTypeStrings.MAX_BIG_INT_UNSIGNED_NOT_NULL);
        stringBuffer.append(this.sqlStrings.PRIMARY_KEY);
        stringBuffer.append(transformInfoData.NAME);
        stringBuffer.append(this.sqlStrings.END);
        return stringBuffer.ToString();
    }

    public virtual string createTable()
    {
        return base.createTable(this.createTableStatement());
    }

    public virtual void update(HashMap<object, object> updatedValues)
    {
        base.updateWhere(TransformInfoData.getInstance().NAME, ((string) updatedValues.get(TransformInfoData.getInstance().NAME)), updatedValues);
    }

    public virtual string dropTable()
    {
        return base.dropTable();
    }

}

