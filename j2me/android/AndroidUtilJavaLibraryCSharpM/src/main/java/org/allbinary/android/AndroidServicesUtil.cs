/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2019 AllBinary 
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
//using java.util;
using ActivityManager = android.app.ActivityManager;
using RunningServiceInfo = android.app.ActivityManager.RunningServiceInfo;
using ComponentName = android.content.ComponentName;
using Context = android.content.Context;
using ResourceUtil = org.allbinary.data.resource.ResourceUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;

namespace org.allbinary.android;

public class AndroidServicesUtil
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public static AndroidServicesUtil getInstance()
    {
        return AndroidServicesUtil.instance;
    }

    private static readonly AndroidServicesUtil instance = new AndroidServicesUtil();
    private readonly ResourceUtil resourceUtil = ResourceUtil.getInstance();
    private readonly int SERVICE_LIMIT_MAX = 1000;
    private readonly string IS_SERVICE_RUNNING = "isServiceRunning";
    private readonly string SERVICE_NOT_FOUND_RUNNING = "Service not found Running: ";
    public virtual bool isServiceRunning(string name)
    {
        ActivityManager activityManager = ((ActivityManager) this.resourceUtil.getContext().getSystemService(Context.ACTIVITY_SERVICE));
        List<RunningServiceInfo> runningServicesList = activityManager.getRunningServices(this.SERVICE_LIMIT_MAX);
        RunningServiceInfo runningServiceInfo = null;
        ComponentName serviceComponent = null;
        string serviceName = null;
        int size = runningServicesList.size();
        for (int index = 0; index < size; index++) {
            runningServiceInfo = runningServicesList.get(index);
            serviceComponent = runningServiceInfo.service;
            serviceName = serviceComponent.ToString();
            if (serviceName.IndexOf(name) >= 0) {
                return true;
            }
        }
        this.logUtil.putF(this.SERVICE_NOT_FOUND_RUNNING + name, this, this.IS_SERVICE_RUNNING);
        return false;
    }

}

