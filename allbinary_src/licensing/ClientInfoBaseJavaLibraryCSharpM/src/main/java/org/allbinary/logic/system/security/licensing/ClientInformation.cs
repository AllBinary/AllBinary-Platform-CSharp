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
using TsUtil = org.allbinary.TsUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using HardwareInterface = org.allbinary.logic.system.hardware.HardwareInterface;
using SystemHardwareFactory = org.allbinary.logic.system.hardware.SystemHardwareFactory;
using GenericOperatingSystem = org.allbinary.logic.system.os.GenericOperatingSystem;
using NoOperatingSystem = org.allbinary.logic.system.os.NoOperatingSystem;
using CommonSeps = org.allbinary.@string.CommonSeps;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListUtil = org.allbinary.util.BasicArrayListUtil;
using StdUtil = org.allbinary.logic.StdUtil;
using org.allbinary.util;

namespace org.allbinary.logic.system.security.licensing;

// This is the information sent to the license server
public class ClientInformation : AbeClientInformationInterface
{
    private GenericOperatingSystem operatingSystemInterface = NoOperatingSystem.NO_OPERATING_SYSTEM;
    private readonly TsUtil tsUtil = TsUtil.getInstance();
    private readonly string name;
    private readonly string shortName;
    private readonly string version;
    private readonly string specialName;
    private bool hardSale = true;
    private string licenseId = StringUtil.getInstance().EMPTY_STRING;
    private BasicArrayList licenseServers = BasicArrayListUtil.getInstance().getImmutableInstance();
    public ClientInformation(string name, string version, string specialName, string shortName)
    {
        this.name = name;
        this.version = version;
        this.specialName = specialName;
        this.shortName = new StringMaker().append(shortName).append(CommonSeps.getInstance().UNDERSCORE).append(version).ToString();
        this.init();
    }

    public virtual void init()
    {
    }

    public virtual GenericOperatingSystem getOperatingSystemInterface()
    {
        return this.operatingSystemInterface;
    }

    public virtual string getName()
    {
        return this.name;
    }

    public virtual string getSpecialName()
    {
        return this.specialName;
    }

    public virtual string getVersion()
    {
        return this.version;
    }

    public virtual string getLicenseId()
    {
        return this.licenseId;
    }

    public virtual BasicArrayList getLicenseServers()
    {
        return this.licenseServers;
    }

    public virtual string getLicenseServer(int index)
    {
        return ((string) this.licenseServers.objectArray[index]);
    }

    public virtual int getNumberOfLicenseServers()
    {
        return this.licenseServers.size();
    }

    public virtual ABHashtable<object, object> toHashtable()
    {
        AbeClientInformationData abeClientInformationData = AbeClientInformationData.getInstance();
        GenericOperatingSystem genericOperatingSystem = this.getOperatingSystemInterface();
        ABHashtable<object, object> clientInfoHashtable = StdUtil.getInstance().createHashtable();
        clientInfoHashtable.put(abeClientInformationData.NAME, this.name);
        clientInfoHashtable.put(abeClientInformationData.VERSION, this.version);
        clientInfoHashtable.put(abeClientInformationData.SPECIALNAME, this.specialName);
        clientInfoHashtable.put(abeClientInformationData.LICENSEID, this.getLicenseId());
        clientInfoHashtable.put(abeClientInformationData.OSNAME, genericOperatingSystem.getName());
        clientInfoHashtable.put(abeClientInformationData.OSARCH, genericOperatingSystem.getArch());
        clientInfoHashtable.put(abeClientInformationData.OSVERSION, genericOperatingSystem.getVersion());
        clientInfoHashtable.put(abeClientInformationData.OS, genericOperatingSystem.ToString());
        HardwareInterface hardwareInterface = SystemHardwareFactory.getInstance().getInstance(genericOperatingSystem);
        string hardwareString = hardwareInterface.ToString();
        clientInfoHashtable.put(abeClientInformationData.HARDWARE, hardwareString);
        return clientInfoHashtable;
    }

    public virtual bool isSameId(string alicenseId)
    {
        if (this.tsUtil.compareTo(this.getLicenseId(), alicenseId) == 0) {
            return true;
        } else {
            return false;
        }
    }

    public virtual bool isLargerOrDifferentServerList(BasicArrayList list)
    {
        int size = list.size() - 1;
        int currentSize = this.licenseServers.size() - 1;
        if (size > currentSize) {
            return true;
        }
        for (int index = size; index >= 0; index--) {
            string newServerName = ((string) list.objectArray[index]);
            for (int index2 = currentSize; index2 >= 0; index2--) {
                string nextOldServerName = ((string) this.licenseServers.objectArray[index]);
                if (this.tsUtil.compareTo(newServerName, nextOldServerName) != 0) {
                    return true;
                }
            }
        }
        return false;
    }

    public virtual void setHardSale(bool hardSale)
    {
        this.hardSale = hardSale;
    }

    public virtual bool isHardSale()
    {
        return this.hardSale;
    }

    public virtual void setOperatingSystemInterface(GenericOperatingSystem operatingSystemInterface)
    {
        this.operatingSystemInterface = operatingSystemInterface;
    }

    public virtual void setLicenseId(string licenseId)
    {
        this.licenseId = licenseId;
    }

    public virtual void setLicenseServers(BasicArrayList licenseServers)
    {
        this.licenseServers = licenseServers;
    }

    public virtual string toShortString()
    {
        return this.shortName;
    }

}

