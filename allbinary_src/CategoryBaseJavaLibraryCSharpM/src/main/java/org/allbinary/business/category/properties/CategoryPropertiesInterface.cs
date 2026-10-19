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
using CategoryHierarchyInterface = org.allbinary.business.category.hierarchy.CategoryHierarchyInterface;
using TableMappingInterface = org.allbinary.data.tables.TableMappingInterface;
using ValidationInterface = org.allbinary.logic.control.validate.ValidationInterface;
using AbPath = org.allbinary.logic.io.path.AbPath;

namespace org.allbinary.business.category.properties;

public interface CategoryPropertiesInterface : TableMappingInterface, ValidationInterface
{
    void setValue(string value);

    string getValue();

    // throws Exception
    AbPath getWebAppPath();

    // throws Exception
    AbPath getPath(CategoryHierarchyInterface categoryHierarchyInterface);

    // throws Exception
    string getFileName();

    // throws Exception
    bool isRoot();

    // throws Exception
    bool isRealRoot();

}

