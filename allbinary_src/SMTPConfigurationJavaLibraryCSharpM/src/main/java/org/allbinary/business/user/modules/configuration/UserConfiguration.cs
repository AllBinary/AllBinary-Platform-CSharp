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
using EntryData = org.allbinary.business.entry.EntryData;
using TimeCreated = org.allbinary.business.time.created.TimeCreated;
using TimeLastModified = org.allbinary.business.time.modified.TimeLastModified;
using UserEmailConfiguration = org.allbinary.logic.communication.smtp.configuration.user.UserEmailConfiguration;
using UserEmailConfigurationInterface = org.allbinary.logic.communication.smtp.configuration.user.UserEmailConfigurationInterface;

namespace org.allbinary.business.user.modules.configuration;

public class UserConfiguration : UserConfigurationInterface
{
    private UserEmailConfigurationInterface userEmailConfigurationInterface;
    private TimeCreated timeCreated;
    private TimeLastModified timeLastModified;
    public UserConfiguration()
    {
        this.userEmailConfigurationInterface = ((UserEmailConfigurationInterface) new UserEmailConfiguration());
        this.timeCreated = new TimeCreated(0);
        this.timeLastModified = new TimeLastModified(0);
    }

    public UserConfiguration(HashMap hashMap)
    {
        this.userEmailConfigurationInterface = ((UserEmailConfigurationInterface) new UserEmailConfiguration(hashMap));
        this.timeCreated = new TimeCreated(((string) hashMap.get(EntryData.getInstance().TIMECREATED)));
        this.timeLastModified = new TimeLastModified(((string) hashMap.get(EntryData.getInstance().LASTMODIFIED)));
    }

    public virtual UserEmailConfigurationInterface getUserEmailConfigurationInterface()
    {
        return this.userEmailConfigurationInterface;
    }

    public virtual void setUserEmailConfigurationInterface(UserEmailConfigurationInterface userEmailConfigurationInterface)
    {
        this.userEmailConfigurationInterface = userEmailConfigurationInterface;
    }

    public virtual TimeCreated getTimeCreated()
    {
        return this.timeCreated;
    }

    public virtual TimeLastModified getTimeLastModified()
    {
        return this.timeLastModified;
    }

    public virtual void setTimeCreated(TimeCreated timeCreated)
    {
        this.timeCreated = timeCreated;
    }

    public virtual void setTimeLastModified(TimeLastModified timeLastModified)
    {
        this.timeLastModified = timeLastModified;
    }

}

