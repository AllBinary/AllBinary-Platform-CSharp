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
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using LogConfigTypeFactory = org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory;
using LogConfigTypes = org.allbinary.logic.communication.log.config.type.LogConfigTypes;
using AbFile = org.allbinary.logic.io.file.AbFile;
using SubDirectory = org.allbinary.logic.io.file.directory.SubDirectory;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.business.init;

public class WeblisketFinder
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly WeblisketFinder instance = new WeblisketFinder();
    public static WeblisketFinder getInstance()
    {
        return WeblisketFinder.instance;
    }

    private static readonly string KEY = "installerdata.dat";
    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private readonly SubDirectory subDirectory = SubDirectory.getInstance();
    private WeblisketFinder()
    {
    }

    public virtual BasicArrayList findAll(string path)
    {
        try {
            this.logUtil.putF(this.commonStrings.START, this, "findAll");
            return this.subDirectory.search(WeblisketFinder.KEY, AbFile.createAbFile(path));
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "findAll", e);
            if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().PRELOADERERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "findAll", e);
            }
            return null;
        }
    }

    public virtual string getInstallationPath(AbFile file)
    {
        try {
            string filePath = file.getPath();
            int end = filePath.IndexOf(KEY);
            if (end < 0) {
                return null;
            }
            return filePath.Substring(0, (end) - (0));
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().PRELOADERERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "getInstallationPath", e);
            }
            return null;
        }
    }

    // throws Exception
    public static void main(string[] args)
    {
        StringUtil stringUtil = StringUtil.getInstance();
        BasicArrayList vector = WeblisketFinder.getInstance().findAll(stringUtil.EMPTY_STRING);
        Console.WriteLine(vector.size());
    }

}

