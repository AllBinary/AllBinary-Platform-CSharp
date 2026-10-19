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
using AbPath = org.allbinary.logic.io.path.AbPath;
using Node = org.w3c.dom.Node;

namespace org.allbinary.business.category;

public interface CategoryFactoryInterface
{
    CategoryInterface getRootInstance();

    CategoryInterface getRootInstance(AbPath categoryPath);

    CategoryInterface getRootInstanceFromNode(Node node);

    CategoryInterface getInstance(CategoryInterface rootCategoryInterface, CategoryInterface parentCategoryInterface, string name);

    CategoryInterface getInstance(CategoryInterface rootCategoryInterface, CategoryInterface parentCategoryInterface, Node node);

    CategoryInterface getInstance(CategoryInterface rootCategoryInterface, CategoryInterface parentCategoryInterface, HashMap categoryPropertiesHashMap);

}

