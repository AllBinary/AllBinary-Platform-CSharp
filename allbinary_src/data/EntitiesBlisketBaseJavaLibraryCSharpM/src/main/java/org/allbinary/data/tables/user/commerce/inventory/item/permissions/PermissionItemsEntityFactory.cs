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

namespace org.allbinary.data.tables.user.commerce.inventory.item.permissions;

public class PermissionItemsEntityFactory
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly PermissionItemsEntityFactory instance = new PermissionItemsEntityFactory();
    public static PermissionItemsEntityFactory getInstance()
    {
        return PermissionItemsEntityFactory.instance;
    }

    private PermissionItemsEntityFactory()
    {
    }

    public static PermissionItemsEntity getPermissionItemsEntityInstance()
    {
        LogUtil logUtil = LogUtil.getInstance();
        try {
            return new org.allbinary.data.tables.user.commerce.inventory.item.permissions.PermissionItemsEntity();
        } catch (Exception e) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().ENTITYFACTORYERROR)) {
                logUtil.put(commonStrings.EXCEPTION, "PermissionItemsEntityFactory", commonStrings.GET_INSTANCE, e);
            }
            return null;
        }
    }

}

