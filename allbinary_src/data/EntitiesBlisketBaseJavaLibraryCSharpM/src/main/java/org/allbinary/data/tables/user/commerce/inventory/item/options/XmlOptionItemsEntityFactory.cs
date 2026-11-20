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
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;
using LogConfigTypeFactory = org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory;
using LogConfigTypes = org.allbinary.logic.communication.log.config.type.LogConfigTypes;

namespace org.allbinary.data.tables.user.commerce.inventory.item.options;

public class XmlOptionItemsEntityFactory
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly XmlOptionItemsEntityFactory instance = new XmlOptionItemsEntityFactory();
    public static XmlOptionItemsEntityFactory getInstance()
    {
        return XmlOptionItemsEntityFactory.instance;
    }

    private XmlOptionItemsEntityFactory()
    {
    }

    public virtual XmlOptionItemsEntity getXmlOptionItemsEntityInstance()
    {
        try {
            return new XmlOptionItemsEntity();
        } catch (Exception e) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().ENTITYFACTORYERROR)) {
                this.logUtil.put(commonStrings.EXCEPTION, this, commonStrings.GET_INSTANCE, e);
            }
            return null;
        }
    }

}

