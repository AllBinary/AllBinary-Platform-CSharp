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
using CategoryData = org.allbinary.business.category.CategoryData;
using CategoryHierarchyInterface = org.allbinary.business.category.hierarchy.CategoryHierarchyInterface;
using StdUtil = org.allbinary.logic.StdUtil;
using AbPath = org.allbinary.logic.io.path.AbPath;
using AbPathData = org.allbinary.logic.io.path.AbPathData;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;

namespace org.allbinary.business.category.properties.root;

public class RootCategoryPropertiesAbstract : RootCategoryPropertiesInterface
{
    private readonly string category = CategoryData.getInstance().ROOTCATEGORY;
    private readonly string fileName;
    public RootCategoryPropertiesAbstract()
    {
        this.fileName = this.category + AbPathData.getInstance().EXTENSION_SEP + CategoryData.getInstance().UNCRYPTED_EXTENSION;
    }

    public virtual object getKey()
    {
        return ((object) this.getValue());
    }

    public virtual string getValue()
    {
        return this.category;
    }

    // throws Exception
    public virtual void setValue(string value)
    {
        throw new Exception("No Value Allowed");
    }

    // throws Exception
    public virtual void setRootFilePath(AbPath value)
    {
        throw new SystemException();
    }

    // throws Exception
    public virtual void setRootFilePath(string value)
    {
        throw new Exception("No Value Allowed");
    }

    // throws Exception
    public virtual AbPath getRootFilePath()
    {
        throw new Exception("No Value Allowed");
    }

    // throws Exception
    public virtual bool isRealRoot()
    {
        throw new Exception("No A Real Root");
    }

    // throws Exception
    public virtual bool isRoot()
    {
        throw new Exception("Root but not implemented");
    }

    // throws Exception
    public virtual string getWebAppPath(CategoryHierarchyInterface categoryHierarchyInterface)
    {
        throw new Exception("Not Root");
    }

    public virtual AbPath getPath(CategoryHierarchyInterface categoryHierarchyInterface)
    {
        return AbPath.createAbPath();
    }

    public virtual string getFileName()
    {
        return this.fileName;
    }

    public virtual bool? isValid()
    {
        return true;
    }

    public virtual HashMap toHashMap()
    {
        HashMap categoryHashMap = StdUtil.getInstance().createHashMap();
        categoryHashMap.put(CategoryData.getInstance().NAME, this.category);
        return categoryHashMap;
    }

    public virtual BasicArrayList toVector()
    {
        BasicArrayList categoryVector = new BasicArrayListD();
        categoryVector.add(this.category);
        return categoryVector;
    }

    // throws Exception
    public virtual Document toValidationInfoDoc()
    {
        return null;
    }

    // throws Exception
    public virtual Node toValidationInfoNode(Document document)
    {
        return null;
    }

    // throws Exception
    public virtual string validationInfo()
    {
        return null;
    }

}

