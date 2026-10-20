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
using StoreFrontInterface = org.allbinary.business.context.modules.storefront.StoreFrontInterface;
using UserEntityFactory = org.allbinary.data.tables.user.UserEntityFactory;
using StdUtil = org.allbinary.logic.StdUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using UserEmailEventNameData = org.allbinary.logic.communication.smtp.@event.UserEmailEventNameData;
using EmailEventHandlerUtil = org.allbinary.logic.communication.smtp.@event.handler.EmailEventHandlerUtil;
using UserEmailEventHandler = org.allbinary.logic.communication.smtp.@event.handler.UserEmailEventHandler;
using AbeClientInformationInterface = org.allbinary.logic.system.security.licensing.AbeClientInformationInterface;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.logic.communication.smtp.@event.handler.factory;

public class StoreAdminUserEmailEventHandlerSingletons
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly StoreAdminUserEmailEventHandlerSingletons instance = new StoreAdminUserEmailEventHandlerSingletons();
    public static StoreAdminUserEmailEventHandlerSingletons getInstance()
    {
        return StoreAdminUserEmailEventHandlerSingletons.instance;
    }

    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private readonly HashMap<object, object> userEmailEventHandlerHashMap = StdUtil.getInstance().createHashMap();
    private StoreAdminUserEmailEventHandlerSingletons()
    {
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().EMAILLOGGING)) {
            this.logUtil.putF(this.commonStrings.START, this, this.commonStrings.CONSTRUCTOR);
        }
    }

    // throws Exception
    public virtual UserEmailEventHandler getInstance(UserEmailEventNameData userEmailEventNameData, AbeClientInformationInterface abeClientInformation, StoreFrontInterface storeFrontInterface)
    {
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().EMAILLOGGING)) {
            this.logUtil.putF(this.commonStrings.START, this, this.commonStrings.GET_INSTANCE);
        }
        UserEmailEventHandler userEmailEventHandler = ((UserEmailEventHandler) this.userEmailEventHandlerHashMap.get(userEmailEventNameData));
        if (userEmailEventHandler == null) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().EMAILLOGGING)) {
                this.logUtil.putF("Creating New Named UserEmailEventHandler", this, this.commonStrings.GET_INSTANCE);
            }
            BasicArrayList userVector = UserEntityFactory.getInstance().getStoreManagers(storeFrontInterface);
            UserEmailEventHandler newUserEmailEventHandler = EmailEventHandlerUtil.getInstance().getEventHandler(abeClientInformation, userEmailEventNameData, userVector);
            this.userEmailEventHandlerHashMap.put(userEmailEventNameData, newUserEmailEventHandler);
            return newUserEmailEventHandler;
        } else {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().EMAILLOGGING)) {
                this.logUtil.putF("Returning existing UserEmailEventHandler", this, this.commonStrings.GET_INSTANCE);
            }
            return userEmailEventHandler;
        }
    }

}

