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
using CategoryData = org.allbinary.business.category.CategoryData;
using CategoryInterface = org.allbinary.business.category.CategoryInterface;
using StringUtil = org.allbinary.logic.@string.StringUtil;

namespace org.allbinary.business.category.hierarchy;

public class CategoryHierarchy : CategoryHierarchyInterface
{
    private CategoryInterface rootCategoryInterface = null;
    private CategoryInterface parentCategoryInterface = null;
    private int level;
    public CategoryHierarchy(CategoryInterface rootCategoryInterface, CategoryInterface parentCategoryInterface)
    {
        this.level = 0;
        this.setRoot(rootCategoryInterface);
        this.setParent(parentCategoryInterface);
    }

    public CategoryHierarchy(CategoryInterface rootCategoryInterface, CategoryInterface parentCategoryInterface, int level)
    {
        this.level = level;
        this.setRoot(rootCategoryInterface);
        this.setParent(parentCategoryInterface);
    }

    public CategoryHierarchy(CategoryInterface rootCategoryInterface, CategoryInterface parentCategoryInterface, HashMap categoryPropertiesHashMap)
    {
        string levelString = StringUtil.getInstance().getNonNull(((string) categoryPropertiesHashMap.get(CategoryData.getInstance().LEVEL)));
        this.level = ((int) (levelString).ToString());
        this.setRoot(rootCategoryInterface);
        this.setParent(parentCategoryInterface);
    }

    public virtual int getLevel()
    {
        return this.level;
    }

    public virtual string getLevelString()
    {
        return (this.level).ToString();
    }

    public virtual void setLevel(int level)
    {
        this.level = level;
    }

    public virtual void setParent(CategoryInterface categoryInterface)
    {
        this.parentCategoryInterface = categoryInterface;
    }

    public virtual void setRoot(CategoryInterface categoryInterface)
    {
        this.rootCategoryInterface = categoryInterface;
    }

    public virtual CategoryInterface getRoot()
    {
        return this.rootCategoryInterface;
    }

    public virtual CategoryInterface getParent()
    {
        return this.parentCategoryInterface;
    }

}

