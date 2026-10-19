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
//using InputStream = java.io.InputStream;
using Activity = android.app.Activity;
using Context = android.content.Context;
using Resources = android.content.res.Resources;
using DebugFactory = org.allbinary.debug.DebugFactory;
using NoDebug = org.allbinary.debug.NoDebug;
using NullUtil = org.allbinary.logic.NullUtil;
using StdUtil = org.allbinary.logic.StdUtil;
using ForcedLogUtil = org.allbinary.logic.communication.log.ForcedLogUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using PreLogUtil = org.allbinary.logic.communication.log.PreLogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using CommonSeps = org.allbinary.@string.CommonSeps;
using CommonStrings = org.allbinary.@string.CommonStrings;
using org.allbinary.util;
using HashtableUtil = org.allbinary.util.HashtableUtil;

namespace org.allbinary.data.resource;

//Android
public class ResourceUtil
{
    private static readonly ResourceUtil instance = new ResourceUtil();
    public static ResourceUtil getInstance()
    {
        return ResourceUtil.instance;
    }

    public readonly LogUtil logUtil = LogUtil.getInstance();
    private object context = NullUtil.getInstance().NULL_OBJECT;
    private object resources = NullUtil.getInstance().NULL_OBJECT;
    private ABHashtable<object, object> hashMap = StdUtil.getInstance().createHashtable();
    private ResourceUtil()
    {
    }

    public virtual void setLoadingPaths(string path, string ext)
    {
        this.logUtil.putF(CommonStrings.getInstance().NOT_IMPLEMENTED, this, "setLoadingPaths");
    }

    public virtual Context getContext()
    {
        return ((Context) this.context);
    }

    public virtual void setContextFromActivity(Activity activity)
    {
        this.context = activity;
    }

    public virtual void setContext(Context aContext)
    {
        this.context = aContext;
    }

    public virtual int? getResourceId(string resource)
    {
        int? value = ((int?) this.hashMap.get(resource));
        if (DebugFactory.getInstance() != NoDebug.getInstance()) {
            PreLogUtil.put(new StringMaker().append(resource).append(CommonSeps.getInstance().COLON).append(value.ToString()).ToString(), this, "getResourceId");
        }
        return value;
    }

    public virtual void addResource(string resource, int? value)
    {
        if (DebugFactory.getInstance() != NoDebug.getInstance()) {
            PreLogUtil.put(new StringMaker().append(resource).append(CommonSeps.getInstance().COLON).append(value.ToString()).ToString(), this, "addResource");
            if (this.containsDuplicate(resource, value)) {
                ForcedLogUtil.log(new StringMaker().append("Found Duplicate Resource: ").append(resource).ToString(), this);
            }
        }
        this.hashMap.put(resource, value);
    }

    private bool containsDuplicate(string resource, int? value)
    {
        object[] objectArray = HashtableUtil.getInstance().getKeysAsArray(this.hashMap);
        for (int index = objectArray.Length; --index >= 0; ) {
            int? integer = ((int?) this.hashMap.get(((object) objectArray[index])));
            if (resource != objectArray[index]) {
                if (value != integer) {
                    if (((int) value) == ((int) integer)) {
                        return true;
                    }
                }
            }
        }
        return false;
    }

    public virtual void setResources(Resources resources)
    {
        this.logUtil.putF(new StringMaker().append("Resource Loader: ").append(resources.GetType().FullName).ToString(), this, "setResources");
        this.resources = resources;
    }

    // throws Exception
    public virtual InputStream getResourceAsStream(string resource)
    {
        int? integer = ((int?) this.hashMap.get(resource));
        int id = ((int) integer);
        Resources resources = (((Resources) this.resources));
        InputStream inputStream = resources.openRawResource(id);
        if (inputStream != null) {
            return inputStream;
        }
        return inputStream;
    }

}

