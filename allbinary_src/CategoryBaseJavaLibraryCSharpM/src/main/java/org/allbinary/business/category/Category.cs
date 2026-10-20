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
using java.util;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using CategoryHierarchy = org.allbinary.business.category.hierarchy.CategoryHierarchy;
using CategoryHierarchyInterface = org.allbinary.business.category.hierarchy.CategoryHierarchyInterface;
using CategoryPropertiesFactoryInterface = org.allbinary.business.category.properties.CategoryPropertiesFactoryInterface;
using CategoryPropertiesInterface = org.allbinary.business.category.properties.CategoryPropertiesInterface;
using RootCategoryPropertiesInterface = org.allbinary.business.category.properties.root.RootCategoryPropertiesInterface;
using StdUtil = org.allbinary.logic.StdUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using AbPath = org.allbinary.logic.io.path.AbPath;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;

namespace org.allbinary.business.category;

public class Category : CategoryInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private CategoryHierarchyInterface categoryHierarchyInterface;
    private CategoryPropertiesInterface categoryPropertiesInterface;
    private readonly BasicArrayList childCategoryVector = new BasicArrayListD();
    private readonly BasicArrayList typeVector = new BasicArrayListD();
    private readonly int? PROPERTIES = 1;
    private readonly int? CATEGORY = 0;
    public Category(CategoryPropertiesFactoryInterface categoryPropertiesFactoryInterface)
    {
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().CATEGORY)) {
            this.logUtil.putF(this.commonStrings.CONSTRUCTOR, this, "Category(CategoryPropertiesFactoryInterface)");
        }
        this.categoryPropertiesInterface = categoryPropertiesFactoryInterface.getInstance();
        this.categoryHierarchyInterface = ((CategoryHierarchyInterface) new CategoryHierarchy(this, this));
        this.log();
    }

    public Category(CategoryPropertiesFactoryInterface categoryPropertiesFactoryInterface, int level)
    {
        this.categoryPropertiesInterface = categoryPropertiesFactoryInterface.getInstance();
        this.categoryHierarchyInterface = ((CategoryHierarchyInterface) new CategoryHierarchy(this, this, level));
        this.log();
    }

    public Category(CategoryInterface rootCategoryInterface, CategoryInterface parentCategoryInterface, CategoryPropertiesFactoryInterface categoryPropertiesFactoryInterface)
    {
        this.categoryPropertiesInterface = ((CategoryPropertiesInterface) categoryPropertiesFactoryInterface.getInstance());
        this.categoryHierarchyInterface = ((CategoryHierarchyInterface) new CategoryHierarchy(rootCategoryInterface, parentCategoryInterface));
        this.log();
    }

    // throws Exception
    public virtual object getKey()
    {
        return this.categoryPropertiesInterface.getKey();
    }

    private static readonly string NOT_ROOT = "This is not the root so it has no file path.";
    // throws Exception
    public virtual AbPath getRootFilePath()
    {
        AbPath rootAbPath = new AbPath(NOT_ROOT, StringUtil.getInstance().EMPTY_STRING);
        CategoryInterface categoryInterface = this.categoryHierarchyInterface.getRoot();
        if (categoryInterface.getProperties().isRoot()) {
            RootCategoryPropertiesInterface rootCategoryPropertiesInterface = ((RootCategoryPropertiesInterface) categoryInterface.getProperties());
            rootAbPath = rootCategoryPropertiesInterface.getRootFilePath();
        }
        return rootAbPath;
    }

    // throws Exception
    public virtual AbPath getFilePath()
    {
        return new AbPath(this.getRootFilePath().ToString() + this.getProperties().getPath(this.getHierarchy()).ToString(), this.getProperties().getFileName());
    }

    // throws Exception
    public virtual AbPath getWebAppPath()
    {
        CategoryInterface categoryInterface = this.categoryHierarchyInterface.getRoot();
        return categoryInterface.getProperties().getWebAppPath();
    }

    // throws Exception
    public virtual AbPath getPath()
    {
        return this.categoryPropertiesInterface.getPath(this.categoryHierarchyInterface);
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual bool addChildProperty(CategoryPropertiesInterface categoryPropertiesInterface)
    {
        this.typeVector.add(this.PROPERTIES);
        return this.childCategoryVector.add(categoryPropertiesInterface);
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual bool addChild(CategoryInterface categoryInterface)
    {
        this.removeDuplicateChild(categoryInterface);
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().CATEGORY)) {
            this.logUtil.putF("adding", this, "addChild");
        }
        CategoryHierarchyInterface childCategoryHierarchyInterface = categoryInterface.getHierarchy();
        childCategoryHierarchyInterface.setParent(this);
        childCategoryHierarchyInterface.setRoot(this.getHierarchy().getRoot());
        categoryInterface.setHierarchy(childCategoryHierarchyInterface);
        this.typeVector.add(this.CATEGORY);
        return this.childCategoryVector.add(categoryInterface);
    }

    public virtual BasicArrayList getChildNodes()
    {
        return this.childCategoryVector;
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual bool removeChild(CategoryInterface categoryInterface)
    {
        BasicArrayList removalVector = new BasicArrayListD();
        bool bool_return = false;
        int size = this.childCategoryVector.size();
        for (int index = 0; index < size; index++) {
            if (this.CATEGORY == this.typeVector.get(index)) {
                object anyType = this.childCategoryVector.get(index);
                CategoryInterface currentCategoryInterface = ((CategoryInterface) anyType);
                if (currentCategoryInterface.getProperties().getValue().compareTo(categoryInterface.getProperties().getValue()) == 0) {
                    removalVector.add(currentCategoryInterface);
                    bool_return = true;
                }
            }
        }
        this.removal(removalVector);
        return bool_return;
    }

    private void removal(BasicArrayList removalVector)
    {
        int removalSize = removalVector.size();
        for (int index = 0; index < removalSize; index++) {
            object anyType = removalVector.get(index);
            int objectIndex = this.childCategoryVector.indexOf(anyType);
            this.typeVector.remove(objectIndex);
            this.childCategoryVector.remove(objectIndex);
        }
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    private bool removeDuplicateChild(CategoryInterface categoryInterface)
    {
        BasicArrayList removalVector = new BasicArrayListD();
        bool bool_return = false;
        int size = this.childCategoryVector.size();
        for (int index = 0; index < size; index++) {
            object anyType = this.childCategoryVector.get(index);
            if (this.PROPERTIES == this.typeVector.get(index)) {
                CategoryPropertiesInterface categoryPropertiesInterface = ((CategoryPropertiesInterface) anyType);
                if (categoryInterface.getProperties().getValue().compareTo(categoryPropertiesInterface.getValue()) == 0) {
                    removalVector.add(categoryPropertiesInterface);
                    bool_return = true;
                    break;
                }
            } else if (this.CATEGORY == this.typeVector.get(index)) {
                CategoryInterface existingCategoryInterface = ((CategoryInterface) anyType);
                CategoryPropertiesInterface categoryPropertiesInterface = existingCategoryInterface.getProperties();
                if (categoryInterface.getProperties().getValue().compareTo(categoryPropertiesInterface.getValue()) == 0) {
                    removalVector.add(existingCategoryInterface);
                    bool_return = true;
                    break;
                }
            }
        }
        this.removal(removalVector);
        return bool_return;
    }

    // throws Exception
    public virtual bool isLeaf()
    {
        if (this.childCategoryVector == null) {
            throw new Exception("Category Error");
        }
        if (this.childCategoryVector.size() == 0) {
            return true;
        } else {
            return false;
        }
    }

    public virtual CategoryPropertiesInterface getProperties()
    {
        return this.categoryPropertiesInterface;
    }

    public virtual void setProperties(CategoryPropertiesInterface categoryPropertiesInterface)
    {
        this.categoryPropertiesInterface = categoryPropertiesInterface;
    }

    public virtual CategoryHierarchyInterface getHierarchy()
    {
        return this.categoryHierarchyInterface;
    }

    public virtual void setHierarchy(CategoryHierarchyInterface categoryHierarchyInterface)
    {
        this.categoryHierarchyInterface = categoryHierarchyInterface;
    }

    // throws Exception
    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual bool? isValid()
    {
        if (!this.categoryPropertiesInterface.isValid()) {
            return false;
        }
        int size = this.childCategoryVector.size();
        for (int index = 0; index < size; index++) {
            object anyType = this.childCategoryVector.get(index);
            if (this.PROPERTIES == this.typeVector.get(index)) {
                CategoryPropertiesInterface categoryPropertiesInterface = ((CategoryPropertiesInterface) anyType);
                if (!categoryPropertiesInterface.isValid()) {
                    return false;
                }
            } else if (this.CATEGORY == this.typeVector.get(index)) {
                CategoryInterface categoryInterface = ((CategoryInterface) anyType);
                if (!categoryInterface.isValid()) {
                    return false;
                }
            }
        }
        return true;
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

    // throws Exception
    public virtual HashMap<object, object> toHashMap()
    {
        HashMap<object, object> categoryHashMap = this.categoryPropertiesInterface.toHashMap();
        return categoryHashMap;
    }

    // throws Exception
    public virtual BasicArrayList toVector()
    {
        BasicArrayList categoryVector = this.categoryPropertiesInterface.toVector();
        categoryVector.add(this.childCategoryVector);
        return categoryVector;
    }

    // throws Exception
    public virtual void log()
    {
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().CATEGORY)) {
            StringMaker stringBuffer = new StringMaker();
            stringBuffer.append("Category Name: ");
            stringBuffer.append(this.categoryPropertiesInterface.getValue());
            stringBuffer.append("\nPath = ");
            stringBuffer.append(this.getPath().ToString());
            stringBuffer.append("\nFile Path: ");
            stringBuffer.append(this.getFilePath().ToString());
            this.logUtil.putF(stringBuffer.ToString(), this, "log()");
        }
    }

}

