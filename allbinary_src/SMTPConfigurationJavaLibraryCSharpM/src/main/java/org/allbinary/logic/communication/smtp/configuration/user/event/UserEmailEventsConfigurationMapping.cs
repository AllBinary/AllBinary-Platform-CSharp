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
using TableMappingInterface = org.allbinary.data.tables.TableMappingInterface;
using StdUtil = org.allbinary.logic.StdUtil;

namespace org.allbinary.logic.communication.smtp.configuration.user.@event;

public class UserEmailEventsConfigurationMapping : TableMappingInterface
{
    private UserEmailEventsConfigurationInterface userEmailEventsConfigurationInterface;
    public UserEmailEventsConfigurationMapping(UserEmailEventsConfigurationInterface userEmailEventsConfigurationInterface)
    {
        this.userEmailEventsConfigurationInterface = userEmailEventsConfigurationInterface;
    }

    public virtual HashMap toHashMap()
    {
        HashMap hashMap = StdUtil.getInstance().createHashMap();
        return hashMap;
    }

    // throws Exception
    public virtual object getKey()
    {
        return UserEmailEventsConfigurationData.NAME;
    }

    // throws Exception
    public virtual BasicArrayList toVector()
    {
        BasicArrayList vector = new BasicArrayListD();
        return vector;
    }

}

