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
using DomNodeHelper = org.allbinary.data.tree.dom.DomNodeHelper;
using DomSearchHelper = org.allbinary.data.tree.dom.DomSearchHelper;
using PreLogUtil = org.allbinary.logic.communication.log.PreLogUtil;
using LoggingInitInfo = org.allbinary.logic.communication.log.config.LoggingInitInfo;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using Node = org.w3c.dom.Node;

namespace org.allbinary.logic.communication.log.config.type;

public class LogConfigTypes
{
    public static readonly string JSP_ERROR_NO_FUNCTION = "in JSP Not In Function";
    public static BasicArrayList LOGGING = new BasicArrayListD();
    static LogConfigTypes()
    {
        LogConfigTypes.init();
    }
    private LogConfigTypes()
    {
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public static void init()
    {
        try {
            PreLogUtil.put("Initialize LogconfigTypes", "LogConfigTypes", "init()");
            LogConfigTypeFactory.getInstance();
            LoggingInitInfo loggingInitInfo = new LoggingInitInfo();
            BasicArrayList logConfigTypeVector = loggingInitInfo.getTypeList();
            PreLogUtil.put("Number Of Log Configs: " + loggingInitInfo.getNumberOfLogConfigs(), "LogConfigTypes", "init()");
            PreLogUtil.put("Number Of Log Config Type Names: " + logConfigTypeVector.size(), "LogConfigTypes", "init()");
            LogConfigTypes.LOGGING.addAllList(logConfigTypeVector);
            LogConfigTypes.LOGGING.add(LogConfigTypeFactory.getInstance().NETBEANS_MODULE);
        } catch (Exception e) {
            PreLogUtil.putSE("Unable to initialize LogConfigTypes", "LogConfigTypes", "init()", e);
        }
    }

    // throws Exception
    public static LogConfigType getInstance(Node node)
    {
        Node nameValueNode = DomSearchHelper.getNode(LogConfigTypeData.getInstance().NAME, node.getChildNodes());
        string name = DomNodeHelper.getTextNodeValue(nameValueNode);
        Node descriptionValueNode = DomSearchHelper.getNodeNoThrow(LogConfigTypeData.getInstance().DESCRIPTION, node.getChildNodes());
        if (descriptionValueNode != null) {
            string description = DomNodeHelper.getTextNodeValue(descriptionValueNode);
        }
        BasicArrayList availableLogConfigTypes = LogConfigType.availableLogConfigTypes;
        int size = availableLogConfigTypes.size();
        LogConfigType logConfigType = null;
        for (int index = 0; index < size; index++) {
            logConfigType = ((LogConfigType) availableLogConfigTypes.get(index));
            if (string.CompareOrdinal(logConfigType.getName(), name) == 0) {
                return logConfigType;
            }
        }
        throw new Exception("No Such LogConfigType: " + name);
    }

}

