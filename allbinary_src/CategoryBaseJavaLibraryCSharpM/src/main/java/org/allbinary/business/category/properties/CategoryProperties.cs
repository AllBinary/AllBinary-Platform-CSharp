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
using CategoryUtil = org.allbinary.business.category.CategoryUtil;
using CategoryHierarchyInterface = org.allbinary.business.category.hierarchy.CategoryHierarchyInterface;
using StdUtil = org.allbinary.logic.StdUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using AbSqlData = org.allbinary.logic.communication.sql.AbSqlData;
using AbPath = org.allbinary.logic.io.path.AbPath;
using AbPathData = org.allbinary.logic.io.path.AbPathData;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using StringValidationUtil = org.allbinary.logic.@string.StringValidationUtil;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;

namespace org.allbinary.business.category.properties;

public class CategoryProperties : CategoryPropertiesInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly int MAXDEPTH = 100;
    private string category;
    public CategoryProperties(string name)
    {
        this.category = name;
    }

    public CategoryProperties(Node node)
    {
        this.category = CategoryUtil.getNameFromNode(node);
    }

    public CategoryProperties(HashMap<object, object> categoryPropertiesHashMap)
    {
        this.category = new string((((string) categoryPropertiesHashMap.get(CategoryData.getInstance().NAME))).ToCharArray());
    }

    public virtual bool isRealRoot()
    {
        return false;
    }

    public virtual bool isRoot()
    {
        return false;
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
    public virtual AbPath getPath(CategoryHierarchyInterface categoryHierarchyInterface)
    {
        AbPathData abPathData = AbPathData.getInstance();
        StringMaker pathStringBuffer = new StringMaker();
        BasicArrayList list = new BasicArrayListD();
        CategoryInterface nextParentCategoryInterface = categoryHierarchyInterface.getParent();
        if (this != nextParentCategoryInterface.getProperties()) {
            int depthIndex = 0;
            while (nextParentCategoryInterface != null) {
                if (nextParentCategoryInterface.getProperties().isRealRoot()) {
                    break;
                }
                if (nextParentCategoryInterface.getProperties().isRoot()) {
                    list.addAt(0, nextParentCategoryInterface.getPath().ToString());
                } else {
                    pathStringBuffer.delete(0, pathStringBuffer.length());
                    list.addAt(0, pathStringBuffer.append(abPathData.SEPARATOR).append(nextParentCategoryInterface.getProperties().getValue()).ToString());
                }
                if (nextParentCategoryInterface == nextParentCategoryInterface.getHierarchy().getParent()) {
                    break;
                }
                nextParentCategoryInterface = nextParentCategoryInterface.getHierarchy().getParent();
                depthIndex++;
                if (depthIndex > CategoryProperties.MAXDEPTH) {
                    throw new Exception("Probably Major Error");
                }
            }
        }
        pathStringBuffer.delete(0, pathStringBuffer.length());
        pathStringBuffer.append(abPathData.SEPARATOR).append(this.getValue());
        int size = list.size();
        for (int index = 0; index < size; index++) {
            pathStringBuffer.append(((string) list.get(index)));
        }
        pathStringBuffer.append(abPathData.SEPARATOR);
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().CATEGORY)) {
            this.logUtil.putF("path = " + pathStringBuffer.ToString(), this, "getPath");
        }
        return new AbPath(pathStringBuffer.ToString(), StringUtil.getInstance().EMPTY_STRING);
    }

    public virtual string getFileName()
    {
        return this.getValue() + AbPathData.getInstance().EXTENSION_SEP + CategoryData.getInstance().UNCRYPTED_EXTENSION;
    }

    // throws Exception
    public virtual AbPath getWebAppPath()
    {
        throw new Exception("Not Root");
    }

    public virtual void setValue(string value)
    {
        this.category = value;
    }

    public virtual bool? isValid()
    {
        bool? returnBoolean = false;
        if (StringValidationUtil.getInstance().isValidRequired(this.category, 1, AbSqlData.MAXSTRING)) {
            returnBoolean = true;
        }
        return returnBoolean;
    }

    public virtual HashMap<object, object> toHashMap()
    {
        HashMap<object, object> categoryHashMap = StdUtil.getInstance().createHashMap();
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

