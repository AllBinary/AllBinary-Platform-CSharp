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
//using HttpServletRequest = javax.servlet.http.HttpServletRequest;
using CategoryData = org.allbinary.business.category.CategoryData;
using CategoryUtil = org.allbinary.business.category.CategoryUtil;
using CategoryHierarchyInterface = org.allbinary.business.category.hierarchy.CategoryHierarchyInterface;
using CategoryPropertiesInterface = org.allbinary.business.category.properties.CategoryPropertiesInterface;
using RootCategoryPropertiesInterface = org.allbinary.business.category.properties.root.RootCategoryPropertiesInterface;
using StoreFrontFactory = org.allbinary.business.context.modules.storefront.StoreFrontFactory;
using StoreFrontInterface = org.allbinary.business.context.modules.storefront.StoreFrontInterface;
using URLGLOBALS = org.allbinary.globals.URLGLOBALS;
using StdUtil = org.allbinary.logic.StdUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using AbPath = org.allbinary.logic.io.path.AbPath;
using AbPathData = org.allbinary.logic.io.path.AbPathData;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using StringValidationUtil = org.allbinary.logic.@string.StringValidationUtil;
using TransformInfoHttpInterface = org.allbinary.logic.visual.transform.info.TransformInfoHttpInterface;
using TransformInfoInterface = org.allbinary.logic.visual.transform.info.TransformInfoInterface;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;

namespace org.allbinary.business.category.properties.root.store;

public class RootStoreCategoryProperties : RootCategoryPropertiesInterface, CategoryPropertiesInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly AbPathData pathData = AbPathData.getInstance();
    private AbPath fileAbPath = null;
    private AbPath abPath;
    private string category;
    private bool isRealRoot;
    public AbPath webAppAbPath = null;
    public TransformInfoInterface transformInfoInterface;
    public RootStoreCategoryProperties(TransformInfoInterface transformInfoInterface)
    {
        this.transformInfoInterface = transformInfoInterface;
        this.abPath = AbPath.createAbPath();
        this.category = CategoryData.getInstance().ROOTCATEGORY;
        this.isRealRoot = true;
        this.initPath();
        this.log();
    }

    public RootStoreCategoryProperties(TransformInfoInterface transformInfoInterface, AbPath categoryAbPath)
    {
        this.transformInfoInterface = transformInfoInterface;
        this.abPath = categoryAbPath;
        this.category = this.pathData.getNameFromPath(categoryAbPath.ToString());
        if (StringValidationUtil.getInstance().isEmpty(this.category)) {
            this.isRealRoot = true;
            this.category = CategoryData.getInstance().ROOTCATEGORY;
        }
        this.initPath();
        this.log();
    }

    public RootStoreCategoryProperties(TransformInfoInterface transformInfoInterface, Node node)
    {
        this.transformInfoInterface = transformInfoInterface;
        string categoryPath = CategoryUtil.getNameFromNode(node);
        this.abPath = new AbPath(categoryPath, StringUtil.getInstance().EMPTY_STRING);
        this.category = this.pathData.getNameFromPath(categoryPath);
        if (StringValidationUtil.getInstance().isEmpty(this.category)) {
            this.isRealRoot = true;
            this.category = CategoryData.getInstance().ROOTCATEGORY;
        }
        this.initPath();
        this.log();
    }

    public RootStoreCategoryProperties(TransformInfoInterface transformInfoInterface, HashMap<object, object> categoryPropertiesHashMap)
    {
        this.transformInfoInterface = transformInfoInterface;
        string categoryPath = new string((((string) categoryPropertiesHashMap.get(CategoryData.getInstance().NAME))).ToCharArray());
        this.abPath = new AbPath(categoryPath, StringUtil.getInstance().EMPTY_STRING);
        this.category = this.pathData.getNameFromPath(categoryPath);
        if (StringValidationUtil.getInstance().isEmpty(this.category)) {
            this.isRealRoot = true;
            this.category = CategoryData.getInstance().ROOTCATEGORY;
        }
        this.initPath();
        this.log();
    }

    // throws Exception
    protected virtual void initPath()
    {
        TransformInfoHttpInterface transformInfoHttpStoreInterface = ((TransformInfoHttpInterface) this.transformInfoInterface);
        StoreFrontInterface storeFrontInterface = StoreFrontFactory.getInstance(transformInfoHttpStoreInterface.getStoreName());
        string postPath = storeFrontInterface.getCurrentHostNamePath() + storeFrontInterface.getCategoryPath();
        HttpServletRequest httpServletRequest = ((HttpServletRequest) transformInfoHttpStoreInterface.getPageContext().getRequest());
        this.webAppAbPath = new AbPath(httpServletRequest.getContextPath() + postPath, StringUtil.getInstance().EMPTY_STRING);
        this.setRootFilePath(new AbPath(URLGLOBALS.getMainPath() + postPath, StringUtil.getInstance().EMPTY_STRING));
    }

    public virtual bool isRealRoot()
    {
        return this.isRealRoot;
    }

    public virtual bool isRoot()
    {
        return true;
    }

    public virtual object getKey()
    {
        return ((object) this.getValue());
    }

    public virtual void setPath(AbPath path)
    {
        this.abPath = path;
    }

    public virtual void setRootFilePath(AbPath value)
    {
        this.fileAbPath = value;
    }

    public virtual AbPath getRootFilePath()
    {
        return this.fileAbPath;
    }

    public virtual string getValue()
    {
        return this.category;
    }

    // throws Exception
    public virtual AbPath getWebAppPath()
    {
        return this.webAppAbPath;
    }

    public virtual AbPath getPath(CategoryHierarchyInterface categoryHierarchyInterface)
    {
        return this.abPath;
    }

    public virtual string getFileName()
    {
        return this.getValue() + AbPathData.getInstance().EXTENSION_SEP + CategoryData.getInstance().UNCRYPTED_EXTENSION;
    }

    public virtual void setValue(string value)
    {
        this.category = value;
    }

    public virtual bool? isValid()
    {
        return true;
    }

    public virtual HashMap<object, object> toHashMap()
    {
        HashMap<object, object> categoryHashMap = StdUtil.getInstance().createHashMap();
        categoryHashMap.put(CategoryData.getInstance().NAME, this.getValue());
        return categoryHashMap;
    }

    public virtual BasicArrayList toVector()
    {
        BasicArrayList categoryVector = new BasicArrayListD();
        categoryVector.add(this.getValue());
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

    public virtual void log()
    {
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().CATEGORY)) {
            this.logUtil.putF(new StringMaker().append("filePath = ").append(this.fileAbPath.ToString()).append("\npath = ").append(this.abPath.ToString()).append("\ncategory = ").append(this.category).ToString(), this, "log()");
        }
    }

}

