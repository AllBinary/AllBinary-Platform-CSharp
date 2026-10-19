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
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
//using PageContext = javax.servlet.jsp.PageContext;
using BasicDataTableInterface = org.allbinary.data.tables.BasicDataTableInterface;
using TransformInfoInterface = org.allbinary.logic.visual.transform.info.TransformInfoInterface;

namespace org.allbinary.data.tables.transform.info;

public interface TransformInfoEntityInterface : BasicDataTableInterface
{
    // throws Exception
    TransformInfoInterface get(string name, HashMap propertiesHashMap, PageContext pageContext);

    // throws Exception
    BasicArrayList getObjectConfigs(string storeName);

    // throws Exception
    BasicArrayList getNames(string storeName);

    void delete(string name);

    void insert(BasicArrayList values);

    void update(HashMap updatedValues);

}

