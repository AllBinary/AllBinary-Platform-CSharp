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
using System.Runtime.CompilerServices;
using java.util;
using StdUtil = org.allbinary.logic.StdUtil;
using PreLogUtil = org.allbinary.logic.communication.log.PreLogUtil;
using LogConfigTypeFactory = org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory;
using LogConfigTypes = org.allbinary.logic.communication.log.config.type.LogConfigTypes;
using AbPath = org.allbinary.logic.io.path.AbPath;
using BooleanUtil = org.allbinary.logic.java.@bool.BooleanUtil;
using StringUtil = org.allbinary.logic.@string.StringUtil;

namespace org.allbinary.business.init;

public class InitInfo
{
    private static readonly InitInfo instance = new InitInfo();
    public static InitInfo getInstance()
    {
        return InitInfo.instance;
    }

    public readonly string TESTING = "TESTING";
    public readonly string MAINPATH = "MAINPATH";
    public readonly string TESTHTMLPATH = "TESTHTMLPATH";
    private string testing = null;
    private AbPath mainPath = null;
    private AbPath testHtmlPath = null;
    private bool hasRead = false;
    private InitInfo()
    {
    }

    // throws InitException
    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual void set()
    {
        try {
            InitInfoEntity initInfoEntity = new InitInfoEntity();
            if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().PRELOADER)) {
                PreLogUtil.put("created entity", "InitInfo", "set()");
            }
            if (!initInfoEntity.@is()) {
                if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().PRELOADER)) {
                    PreLogUtil.put("adding", "InitInfo", "set()");
                }
                initInfoEntity.add();
            } else {
                if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().PRELOADER)) {
                    PreLogUtil.put("update", "InitInfo", "set()");
                }
                initInfoEntity.update();
            }
            this.hasRead = false;
        } catch (Exception e) {
            if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().PRELOADERERROR)) {
                PreLogUtil.putOE("error", "InitInfo", "set()", e);
            }
        }
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual void set(HashMap<object, object> hashMap)
    {
        try {
            this.testing = ((string) hashMap.get(this.TESTING));
            this.mainPath = new AbPath(((string) hashMap.get(this.MAINPATH)), StringUtil.getInstance().EMPTY_STRING);
            this.testHtmlPath = new AbPath(((string) hashMap.get(this.TESTHTMLPATH)), StringUtil.getInstance().EMPTY_STRING);
        } catch (Exception e) {
            if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().PRELOADERERROR)) {
                PreLogUtil.putOE("error", "InitInfo", "set()", e);
            }
        }
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    private void get()
    {
        try {
            this.testing = null;
            this.mainPath = null;
            this.testHtmlPath = null;
            InitInfoEntity initInfoEntity = new InitInfoEntity();
            initInfoEntity.get();
        } catch (Exception e) {
            if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().PRELOADERERROR)) {
                PreLogUtil.putOE("error", "InitInfo", "set()", e);
            }
            return;
        }
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual void setHasRead(bool value)
    {
        this.hasRead = value;
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    private void updateIfNeeded()
    {
        try {
            if (!this.hasRead) {
                this.hasRead = true;
                this.get();
            }
        } catch (Exception e) {
            if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().PRELOADERERROR)) {
                PreLogUtil.putOE("error", "InitInfo", "updateIfNeeded()", e);
            }
            return;
        }
    }

    public virtual bool isTesting()
    {
        try {
            this.updateIfNeeded();
            return BooleanUtil.getInstance().getFromString(this.testing);
        } catch (Exception e) {
            if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().PRELOADERERROR)) {
                PreLogUtil.putOE("error", "InitInfo", "updateIfNeeded()", e);
            }
            return false;
        }
    }

    public virtual string getTesting()
    {
        this.updateIfNeeded();
        return this.testing;
    }

    public virtual string getTestHtmlPath()
    {
        this.updateIfNeeded();
        if (this.testHtmlPath != null) {
            return this.testHtmlPath.ToString();
        } else {
            return null;
        }
    }

    public virtual string getMainPath()
    {
        this.updateIfNeeded();
        if (this.mainPath != null) {
            return this.mainPath.ToString();
        } else {
            return null;
        }
    }

    public virtual void setTesting(string value)
    {
        this.testing = value;
    }

    public virtual void setTestHtmlPath(AbPath value)
    {
        this.testHtmlPath = value;
    }

    public virtual void setMainPath(AbPath value)
    {
        this.mainPath = value;
    }

    public virtual bool isMainPathValid(AbPath abPath)
    {
        return true;
    }

    public virtual bool isTestHtmlPathValid(AbPath abPath)
    {
        return true;
    }

    // throws Exception
    public virtual bool isTestingValid(string testing)
    {
        return BooleanUtil.getInstance().isStringBoolean(testing);
    }

    public virtual HashMap<object, object> toHashMap()
    {
        HashMap<object, object> hashMap = StdUtil.getInstance().createHashMap();
        hashMap.put(this.TESTING, this.getTesting());
        hashMap.put(this.MAINPATH, this.getMainPath());
        hashMap.put(this.TESTHTMLPATH, this.getTestHtmlPath());
        return hashMap;
    }

}

