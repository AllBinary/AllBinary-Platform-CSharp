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
using AndroidInfoFactory = org.allbinary.android.AndroidInfoFactory;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using GenericOperatingSystem = org.allbinary.logic.system.os.GenericOperatingSystem;
using CommonSeps = org.allbinary.@string.CommonSeps;

namespace org.allbinary.logic.system.os.android;

public class AndroidOS : GenericOperatingSystem
{
    private StringMaker stringBuffer = new StringMaker();
    private readonly string DEVICE_ID = "DeviceId";
    private readonly string DEVICE_SOFTWARE_VERSION = "DeviceSoftwareVersion";
    private readonly string LINE_1_NUMBER = "Line1Number";
    public AndroidOS()
    {
        int SDK_VERSION = AndroidInfoFactory.getInstance().getVersion();
        if (SDK_VERSION > 10) {
            this.scalable = true;
        }
        AndroidSystemProperties properties = AndroidSystemProperties.getInstance();
        CommonSeps commonStrings = CommonSeps.getInstance();
        this.stringBuffer.append(this.DEVICE_ID);
        this.stringBuffer.append(commonStrings.EQUALS);
        this.stringBuffer.append(properties.getDeviceId());
        this.stringBuffer.append(commonStrings.SPACE);
        this.stringBuffer.append(this.DEVICE_SOFTWARE_VERSION);
        this.stringBuffer.append(commonStrings.EQUALS);
        this.stringBuffer.append(properties.getDeviceSoftwareVersion());
        this.stringBuffer.append(commonStrings.SPACE);
        this.stringBuffer.append(this.LINE_1_NUMBER);
        this.stringBuffer.append(commonStrings.EQUALS);
        this.stringBuffer.append(properties.getLine1Number());
        this.stringBuffer.append(commonStrings.SPACE);
        this.stringBuffer.append("NetworkCountryIso");
        this.stringBuffer.append(commonStrings.EQUALS);
        this.stringBuffer.append(properties.getNetworkCountryIso());
        this.stringBuffer.append(commonStrings.SPACE);
        this.stringBuffer.append("NetworkOperator");
        this.stringBuffer.append(commonStrings.EQUALS);
        this.stringBuffer.append(properties.getNetworkOperator());
        this.stringBuffer.append(commonStrings.SPACE);
        this.stringBuffer.append("NetworkOperatorName");
        this.stringBuffer.append(commonStrings.EQUALS);
        this.stringBuffer.append(properties.getNetworkOperatorName());
        this.stringBuffer.append(commonStrings.SPACE);
        this.stringBuffer.append("NetworkType");
        this.stringBuffer.append(commonStrings.EQUALS);
        this.stringBuffer.appendint(((int) properties.getNetworkType()));
        this.stringBuffer.append(commonStrings.SPACE);
        this.stringBuffer.append("PhoneType");
        this.stringBuffer.append(commonStrings.EQUALS);
        this.stringBuffer.appendint(((int) properties.getPhoneType()));
        this.stringBuffer.append(commonStrings.SPACE);
        this.stringBuffer.append("SimCountryIso");
        this.stringBuffer.append(commonStrings.EQUALS);
        this.stringBuffer.append(properties.getSimCountryIso());
        this.stringBuffer.append(commonStrings.SPACE);
        this.stringBuffer.append("SimOperator");
        this.stringBuffer.append(commonStrings.EQUALS);
        this.stringBuffer.append(properties.getSimOperator());
        this.stringBuffer.append(commonStrings.SPACE);
        this.stringBuffer.append("SimOperatorName");
        this.stringBuffer.append(commonStrings.EQUALS);
        this.stringBuffer.append(properties.getSimOperatorName());
        this.stringBuffer.append(commonStrings.SPACE);
        this.stringBuffer.append("SimSerialNumber");
        this.stringBuffer.append(commonStrings.EQUALS);
        this.stringBuffer.append(properties.getSimSerialNumber());
        this.stringBuffer.append(commonStrings.SPACE);
        this.stringBuffer.append("SubscriberId");
        this.stringBuffer.append(commonStrings.EQUALS);
        this.stringBuffer.append(properties.getSubscriberId());
        this.stringBuffer.append(commonStrings.SPACE);
        this.stringBuffer.append("VoiceMailAlphaTag");
        this.stringBuffer.append(commonStrings.EQUALS);
        this.stringBuffer.append(properties.getVoiceMailAlphaTag());
        this.stringBuffer.append(commonStrings.SPACE);
        this.stringBuffer.append("VoiceMailNumber");
        this.stringBuffer.append(commonStrings.EQUALS);
        this.stringBuffer.append(properties.getVoiceMailNumber());
        this.stringBuffer.append(commonStrings.SPACE);
    }

    private readonly string OUYA = "ouya";
    public override bool isOverScan()
    {
        AndroidSystemProperties properties = AndroidSystemProperties.getInstance();
        if (properties.getDevice().toLowerCase().IndexOf(this.OUYA) >= 0) {
            return true;
        }
        return false;
    }

    public override int getOverScanXPercent()
    {
        return 90;
    }

    public override int getOverScanYPercent()
    {
        return 90;
    }

    public override string ToString()
    {
        StringMaker osBuffer = new StringMaker();
        osBuffer.append(base.ToString());
        osBuffer.append(CommonSeps.getInstance().SPACE);
        osBuffer.append("Other System Info: \n");
        osBuffer.append(this.stringBuffer.ToString());
        return osBuffer.ToString();
    }

}

