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
using Context = android.content.Context;
using Build = android.os.Build;
using ResourceUtil = org.allbinary.data.resource.ResourceUtil;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.logic.system.os.android;

public class AndroidSystemProperties
{
    private static readonly AndroidSystemProperties SINGLETON = new AndroidSystemProperties(ResourceUtil.getInstance().getContext());
    public static AndroidSystemProperties getInstance()
    {
        return AndroidSystemProperties.SINGLETON;
    }

    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    public AndroidSystemProperties(Context context)
    {
    }

    public virtual string getDeviceId()
    {
        return StringUtil.getInstance().EMPTY_STRING;
    }

    public virtual string getDeviceSoftwareVersion()
    {
        return this.commonStrings.DISABLE;
    }

    public virtual string getLine1Number()
    {
        return this.commonStrings.DISABLE;
    }

    public virtual string getNetworkCountryIso()
    {
        return this.commonStrings.DISABLE;
    }

    public virtual string getNetworkOperator()
    {
        return this.commonStrings.DISABLE;
    }

    public virtual string getNetworkOperatorName()
    {
        return this.commonStrings.DISABLE;
    }

    public virtual string getSimCountryIso()
    {
        return this.commonStrings.DISABLE;
    }

    public virtual string getSimOperator()
    {
        return this.commonStrings.DISABLE;
    }

    public virtual string getSimOperatorName()
    {
        return this.commonStrings.DISABLE;
    }

    public virtual string getSimSerialNumber()
    {
        return this.commonStrings.DISABLE;
    }

    public virtual string getSubscriberId()
    {
        return this.commonStrings.DISABLE;
    }

    public virtual string getVoiceMailAlphaTag()
    {
        return this.commonStrings.DISABLE;
    }

    public virtual string getVoiceMailNumber()
    {
        return this.commonStrings.DISABLE;
    }

    public virtual int getNetworkType()
    {
        return -1;
    }

    public virtual int getPhoneType()
    {
        return -1;
    }

    public virtual string getBoard()
    {
        return Build.BOARD;
    }

    public virtual string getBrand()
    {
        return Build.BRAND;
    }

    public virtual string getDevice()
    {
        return Build.DEVICE;
    }

    public virtual string getFingerprint()
    {
        return Build.FINGERPRINT;
    }

    public virtual string getHost()
    {
        return Build.HOST;
    }

    public virtual string getId()
    {
        return Build.ID;
    }

    public virtual string getModel()
    {
        return Build.MODEL;
    }

    public virtual string getProduct()
    {
        return Build.PRODUCT;
    }

    public virtual string getTags()
    {
        return Build.TAGS;
    }

    public virtual long getTime()
    {
        return Build.TIME;
    }

    public virtual string getType()
    {
        return Build.TYPE;
    }

    public virtual string getUser()
    {
        return Build.USER;
    }

}

