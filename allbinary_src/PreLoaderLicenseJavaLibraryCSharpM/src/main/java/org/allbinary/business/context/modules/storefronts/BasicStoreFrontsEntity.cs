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
using StoreFrontData = org.allbinary.business.context.modules.storefront.StoreFrontData;
using InitSql = org.allbinary.business.init.InitSql;
using UserDbInitInfo = org.allbinary.business.init.db.UserDbInitInfo;
using StdUtil = org.allbinary.logic.StdUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;

namespace org.allbinary.business.context.modules.storefronts;

public class BasicStoreFrontsEntity : InitSql
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly string tableName = "storefronts";
    public BasicStoreFrontsEntity() : base(new UserDbInitInfo())
    {
        // base(new UserDbInitInfo()) is called from the constructor declaration
        this.setTable(this.tableName);
    }

    // throws Exception
    public virtual BasicStoreFrontInterface getStoreFrontInterface(string name)
    {
        HashMap<object, object> keysAndValues = StdUtil.getInstance().createHashMap();
        keysAndValues.put(StoreFrontData.getInstance().NAME, name);
        HashMap<object, object> storeHashMap = base.getRow(keysAndValues);
        if (storeHashMap == null) {
            throw new Exception("No Such Store: " + name);
        }
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().FACTORYERROR)) {
            this.logUtil.putF("StoreFront: " + storeHashMap.ToString(), this, "getStore()");
        }
        return ((BasicStoreFrontInterface) new BasicStoreFront(storeHashMap));
    }

}

