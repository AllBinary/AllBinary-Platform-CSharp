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
using CategoryInterface = org.allbinary.business.category.CategoryInterface;

namespace org.allbinary.business.category.hierarchy;

public interface CategoryHierarchyInterface
{
    int getLevel();

    string getLevelString();

    CategoryInterface getRoot();

    CategoryInterface getParent();

    void setLevel(int level);

    void setRoot(CategoryInterface categoryInterface);

    void setParent(CategoryInterface categoryInterface);

}

