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
using java.util;
using TableMappingInterface = org.allbinary.data.tables.TableMappingInterface;
using AbPath = org.allbinary.logic.io.path.AbPath;
using TransformInfoObjectConfigInterface = org.allbinary.logic.visual.transform.info.objectConfig.TransformInfoObjectConfigInterface;
using Document = org.w3c.dom.Document;

namespace org.allbinary.logic.visual.transform.info;

public interface TransformInfoInterface : TableMappingInterface
{
    string log();

    // throws Exception
    void @override(HashMap hashMap);

    string getName();

    void setStoreName(string value);

    string getStoreName();

    string getObjectFile();

    object getObject();

    // throws Exception
    AbPath getTemplateFilePath();

    string getTemplateFile();

    string getTemplate();

    // throws Exception
    AbPath getDataFilePath();

    string getDataFile();

    // throws Exception
    Document getDataDocument();

    void setName(string value);

    void setObjectFile(string value);

    void setObject(object anyType);

    // throws Exception
    void setObjectConfigInterface(TransformInfoObjectConfigInterface transformInfoObjectConfigInterface);

    // throws Exception
    TransformInfoObjectConfigInterface getObjectConfigInterface();

    void setTemplateFile(string value);

    void setTemplate(string value);

    void setDataFile(string value);

    void setData(string value);

    void setChild();

    bool isChild();

}

