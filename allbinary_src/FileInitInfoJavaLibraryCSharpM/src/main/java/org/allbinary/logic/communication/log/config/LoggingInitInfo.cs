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
using DomSearchHelper = org.allbinary.data.tree.dom.DomSearchHelper;
using DomDocumentHelper = org.allbinary.data.tree.dom.document.DomDocumentHelper;
using XmlDocumentHelper = org.allbinary.data.tree.dom.document.XmlDocumentHelper;
using PATH_GLOBALS = org.allbinary.globals.PATH_GLOBALS;
using URLGLOBALS = org.allbinary.globals.URLGLOBALS;
using AbFileLocalInputStream = org.allbinary.logic.io.AbFileLocalInputStream;
using AbFile = org.allbinary.logic.io.file.AbFile;
using AbPath = org.allbinary.logic.io.path.AbPath;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;
using NodeList = org.w3c.dom.NodeList;

namespace org.allbinary.logic.communication.log.config;

public class LoggingInitInfo
{
    private static readonly string INITFILENAME = "logConfig.xml";
    private static readonly string PACKAGE = PATH_GLOBALS.getInstance().INIT_PATH;
    private static BasicArrayList logConfigInfoList = null;
    private static bool hasRead = false;
    public LoggingInitInfo()
    {
    }

    // throws Exception
    [MethodImpl(MethodImplOptions.Synchronized)]
    public static Document getDoc()
    {
        string path = URLGLOBALS.getWebappPath() + LoggingInitInfo.PACKAGE;
        AbPath FILEABPATH = new AbPath(path, INITFILENAME);
        AbFile file = AbFile.createAbFileFromAbPath(FILEABPATH);
        Document document = DomDocumentHelper.create(new AbFileLocalInputStream(file));
        return document;
    }

    // throws Exception
    [MethodImpl(MethodImplOptions.Synchronized)]
    public static void write()
    {
        try {
            LoggingInitInfo.hasRead = false;
        } catch (Exception e) {
            throw e;
        }
    }

    // throws Exception
    [MethodImpl(MethodImplOptions.Synchronized)]
    private static void read()
    {
        try {
            Document document = LoggingInitInfo.getDoc();
            NodeList logConfigsNodeList = document.getElementsByTagName(LogConfigsData.getInstance().NAME);
            Node logConfigsNode = logConfigsNodeList.item(0);
            BasicArrayList logConfigNodeVector = DomSearchHelper.getAllNodes(LogConfigData.getInstance().NAME, logConfigsNode.getChildNodes());
            LoggingInitInfo.logConfigInfoList = new BasicArrayListD();
            int size = logConfigNodeVector.size();
            for (int i = 0; i < size; i++) {
                Node node = ((Node) logConfigNodeVector.get(i));
                LogConfig logConfigInfo = new LogConfig(node);
                LoggingInitInfo.logConfigInfoList.add(logConfigInfo);
            }
        } catch (Exception e) {
            throw e;
        }
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public static void setHasRead(bool value)
    {
        LoggingInitInfo.hasRead = value;
    }

    // throws Exception
    [MethodImpl(MethodImplOptions.Synchronized)]
    private static void updateIfNeeded()
    {
        if (!LoggingInitInfo.hasRead) {
            LoggingInitInfo.read();
            LoggingInitInfo.hasRead = true;
            if (LoggingInitInfo.logConfigInfoList == null) {
                throw new Exception("Read Failed");
            }
        }
    }

    public virtual bool isValid()
    {
        try {
            return true;
        } catch (Exception e) {
            return false;
        }
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public static void set(BasicArrayList logConfigInfoVector)
    {
        LoggingInitInfo.logConfigInfoList = logConfigInfoVector;
    }

    // throws Exception
    public static BasicArrayList get()
    {
        LoggingInitInfo.updateIfNeeded();
        return LoggingInitInfo.logConfigInfoList;
    }

    // throws Exception
    public static BasicArrayList getTypeNameList()
    {
        LoggingInitInfo.updateIfNeeded();
        BasicArrayList allLogTypeVector = new BasicArrayListD();
        int size = LoggingInitInfo.logConfigInfoList.size();
        for (int index = 0; index < size; index++) {
            LogConfig logConfigInfo = ((LogConfig) LoggingInitInfo.logConfigInfoList.objectArray[index]);
            BasicArrayList logTypeVector = logConfigInfo.getTypeVector();
            if (logConfigInfo.isEnabled()) {
                allLogTypeVector.addAllList(logTypeVector);
            }
        }
        return allLogTypeVector;
    }

    // throws Exception
    public static BasicArrayList getTypeList()
    {
        LoggingInitInfo.updateIfNeeded();
        BasicArrayList allLogTypeVector = new BasicArrayListD();
        int size = LoggingInitInfo.logConfigInfoList.size();
        for (int index = 0; index < size; index++) {
            LogConfig logConfigInfo = ((LogConfig) LoggingInitInfo.logConfigInfoList.objectArray[index]);
            BasicArrayList logTypeVector = logConfigInfo.getTypeVector();
            if (logConfigInfo.isEnabled()) {
                allLogTypeVector.addAllList(logTypeVector);
            }
        }
        return allLogTypeVector;
    }

    // throws Exception
    public virtual int getNumberOfLogConfigs()
    {
        return LoggingInitInfo.logConfigInfoList.size();
    }

    public override string ToString()
    {
        try {
            Document document = LoggingInitInfo.getDoc();
            return XmlDocumentHelper.toString(document);
        } catch (Exception e) {
            return "Error";
        }
    }

}

