/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2002 AllBinary 
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
using BasicDataTableInterface = org.allbinary.data.tables.BasicDataTableInterface;

namespace org.allbinary.data.tables.generator;

public interface IdGeneratorEntityInterface : BasicDataTableInterface
{
    // throws Exception
    long? get(string name);

    void deleteWhere(string key, string value);

    void insert(BasicArrayList values);

    void update(HashMap updatedValues);

}

