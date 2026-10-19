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
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using CategoryHierarchyInterface = org.allbinary.business.category.hierarchy.CategoryHierarchyInterface;
using CategoryPropertiesInterface = org.allbinary.business.category.properties.CategoryPropertiesInterface;
using TableMappingInterface = org.allbinary.data.tables.TableMappingInterface;
using ValidationInterface = org.allbinary.logic.control.validate.ValidationInterface;
using AbPath = org.allbinary.logic.io.path.AbPath;

namespace org.allbinary.business.category;

public interface CategoryInterface : TableMappingInterface, ValidationInterface
{
    BasicArrayList getChildNodes();

    bool addChildProperty(CategoryPropertiesInterface categoryPropertiesInterface);

    bool addChild(CategoryInterface categoryInterface);

    bool removeChild(CategoryInterface categoryInterface);

    // throws Exception
    bool isLeaf();

    CategoryPropertiesInterface getProperties();

    void setProperties(CategoryPropertiesInterface categoryPropertiesInterface);

    CategoryHierarchyInterface getHierarchy();

    void setHierarchy(CategoryHierarchyInterface categoryHierarchyInterface);

    // throws Exception
    AbPath getPath();

    // throws Exception
    AbPath getFilePath();

    // throws Exception
    AbPath getWebAppPath();

    // throws Exception
    AbPath getRootFilePath();

    // throws Exception
    void log();

}

