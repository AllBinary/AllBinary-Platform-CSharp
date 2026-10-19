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
using CommonDataFileStrings = org.allbinary.logic.io.file.CommonDataFileStrings;

namespace org.allbinary.business.user.modules.configuration;

public class UserConfigurationData
{
    private UserConfigurationData()
    {
    }

    public static readonly string NAME = "USER_CONFIGURATION_NAME";
    public static readonly string UNCRYPTED_EXTENSION = CommonDataFileStrings.getInstance().UNCRYPTED_EXTENSION;
    public static readonly string ENCRYPTED_EXTENSION = CommonDataFileStrings.getInstance().ENCRYPTED_EXTENSION;
}

