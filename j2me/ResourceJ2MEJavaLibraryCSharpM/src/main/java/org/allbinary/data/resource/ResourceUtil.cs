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
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using CommonSeps = org.allbinary.@string.CommonSeps;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.data.resource;

//J2ME
public class ResourceUtil
{
    private static ResourceUtil instance = new ResourceUtil();
    public static ResourceUtil getInstance()
    {
        return ResourceUtil.instance;
    }

    public readonly LogUtil logUtil = LogUtil.getInstance();
    private ResourceUtil()
    {
    }

    public virtual void setLoadingPaths(string path, string ext)
    {
        this.logUtil.putF(CommonStrings.getInstance().NOT_IMPLEMENTED, this, "setLoadingPaths");
    }

    // throws Exception
    public virtual InputStream getResourceAsStream(string resource)
    {
        InputStream inputStream = resource.GetType().getResourceAsStream(resource);
        if (inputStream == null) {
            inputStream = this.getResourceAsStreamAtStart(resource, 2);
            if (inputStream == null) {
                inputStream = this.getResourceAsStreamAtStart(resource, 1);
                if (inputStream == null) {
                    StringMaker stringMaker = new StringMaker();
                    int index = resource.LastIndexOf('/');
                    string resourcePath = resource.Substring(index + 1);
                    inputStream = resource.GetType().getResourceAsStream(resourcePath);
                    if (inputStream == null) {
                        resourcePath = resource.Substring(index);
                        inputStream = resource.GetType().getResourceAsStream(resourcePath);
                        if (inputStream == null) {
                            string RES = "res";
                            resourcePath = stringMaker.append(RES).append(resource.Substring(index)).ToString();
                            inputStream = resource.GetType().getResourceAsStream(resourcePath);
                            if (inputStream == null) {
                                stringMaker.delete(0, stringMaker.length());
                                resourcePath = stringMaker.append("/").append(RES).append(resource.Substring(index)).ToString();
                                inputStream = resource.GetType().getResourceAsStream(resourcePath);
                                string COLON = CommonSeps.getInstance().COLON;
                                if (inputStream == null) {
                                    stringMaker.delete(0, stringMaker.length());
                                    resourcePath = stringMaker.append(RES).append(COLON).append(resource.Substring(index)).ToString();
                                    inputStream = resource.GetType().getResourceAsStream(resourcePath);
                                    if (inputStream == null) {
                                        stringMaker.delete(0, stringMaker.length());
                                        resourcePath = stringMaker.append(RES).append(COLON).append(resource.Substring(index + 1)).ToString();
                                        inputStream = resource.GetType().getResourceAsStream(resourcePath);
                                        if (inputStream == null) {
                                            string RESOURCE_STRING = "resource";
                                            stringMaker.delete(0, stringMaker.length());
                                            resourcePath = stringMaker.append(RESOURCE_STRING).append(COLON).append(resource.Substring(index)).ToString();
                                            inputStream = resource.GetType().getResourceAsStream(resourcePath);
                                            if (inputStream == null) {
                                                stringMaker.delete(0, stringMaker.length());
                                                resourcePath = stringMaker.append(RESOURCE_STRING).append(COLON).append(resource.Substring(index + 1)).ToString();
                                                inputStream = resource.GetType().getResourceAsStream(resourcePath);
                                                if (inputStream == null) {
                                                    stringMaker.delete(0, stringMaker.length());
                                                    throw new Exception(stringMaker.append("Unable to obtain: ").append(resource).ToString());
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        return inputStream;
    }

    // throws Exception
    private InputStream getResourceAsStreamAtStart(string resource, int startIndex)
    {
        StringMaker stringMaker = new StringMaker();
        int index = resource.IndexOf(CommonSeps.getInstance().COLON);
        string resourcePath = resource.Substring(index + startIndex);
        InputStream inputStream = resource.GetType().getResourceAsStream(resourcePath);
        if (inputStream != null) {
            return inputStream;
        }
        return inputStream;
    }

    public virtual void addResource(string resource, int? value)
    {
    }

}

