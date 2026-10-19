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
using GenericOperatingSystem = org.allbinary.logic.system.os.GenericOperatingSystem;
using org.allbinary.util;
using BasicArrayList = org.allbinary.util.BasicArrayList;

namespace org.allbinary.logic.system.security.licensing;

public interface AbeClientInformationInterface
{
    void init();

    GenericOperatingSystem getOperatingSystemInterface();

    string getName();

    string getSpecialName();

    string getVersion();

    string getLicenseId();

    BasicArrayList getLicenseServers();

    string getLicenseServer(int index);

    int getNumberOfLicenseServers();

    ABHashtable<object, object> toHashtable();

    bool isSameId(string alicenseId);

    bool isLargerOrDifferentServerList(BasicArrayList vector);

    bool isHardSale();

    string toShortString();

}

