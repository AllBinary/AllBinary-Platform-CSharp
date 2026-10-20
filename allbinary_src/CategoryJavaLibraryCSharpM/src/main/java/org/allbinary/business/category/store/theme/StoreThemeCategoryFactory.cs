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
using CategoryFactoryInterface = org.allbinary.business.category.CategoryFactoryInterface;
using CategoryInterface = org.allbinary.business.category.CategoryInterface;
using CategoryUtil = org.allbinary.business.category.CategoryUtil;
using CategoryPropertiesFactory = org.allbinary.business.category.properties.CategoryPropertiesFactory;
using CategoryPropertiesFactoryInterface = org.allbinary.business.category.properties.CategoryPropertiesFactoryInterface;
using RootStoreThemeCategoryPropertiesFactory = org.allbinary.business.category.properties.root.store.theme.RootStoreThemeCategoryPropertiesFactory;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using AbPath = org.allbinary.logic.io.path.AbPath;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using TransformInfoInterface = org.allbinary.logic.visual.transform.info.TransformInfoInterface;
using CommonStrings = org.allbinary.@string.CommonStrings;
using Node = org.w3c.dom.Node;

namespace org.allbinary.business.category.store.theme;

public class StoreThemeCategoryFactory : CategoryFactoryInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private TransformInfoInterface transformInfoInterface;
    public StoreThemeCategoryFactory(TransformInfoInterface transformInfoInterface)
    {
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().CATEGORY)) {
            this.logUtil.putF(this.commonStrings.START, this, "StoreCategoryFactory(TransformInfoInterface transformInfoInterface)");
        }
        this.transformInfoInterface = transformInfoInterface;
    }

    public virtual CategoryInterface getRootInstance()
    {
        try {
            CategoryPropertiesFactoryInterface categoryPropertiesFactoryInterface = ((CategoryPropertiesFactoryInterface) new RootStoreThemeCategoryPropertiesFactory(this.transformInfoInterface));
            return ((CategoryInterface) new StoreThemeCategory(this.transformInfoInterface, categoryPropertiesFactoryInterface, 0));
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().ENTITYFACTORYERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "getRootInstance()", e);
            }
            return null;
        }
    }

    public virtual CategoryInterface getRootInstance(AbPath categoryAbPath)
    {
        try {
            int level = CategoryUtil.getPathLevel(categoryAbPath);
            CategoryPropertiesFactoryInterface categoryPropertiesFactoryInterface = ((CategoryPropertiesFactoryInterface) new RootStoreThemeCategoryPropertiesFactory(this.transformInfoInterface, categoryAbPath));
            return ((CategoryInterface) new StoreThemeCategory(this.transformInfoInterface, categoryPropertiesFactoryInterface, level));
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().ENTITYFACTORYERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "getRootInstance(String)", e);
            }
            return null;
        }
    }

    public virtual CategoryInterface getRootInstanceFromNode(Node node)
    {
        try {
            CategoryPropertiesFactoryInterface categoryPropertiesFactoryInterface = ((CategoryPropertiesFactoryInterface) new RootStoreThemeCategoryPropertiesFactory(this.transformInfoInterface, node));
            AbPath categoryPath = new AbPath(CategoryUtil.getNameFromNode(node), StringUtil.getInstance().EMPTY_STRING);
            int level = CategoryUtil.getPathLevel(categoryPath);
            return ((CategoryInterface) new StoreThemeCategory(this.transformInfoInterface, node, categoryPropertiesFactoryInterface, level));
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().ENTITYFACTORYERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "getRootInstance(node)", e);
            }
            return null;
        }
    }

    public virtual CategoryInterface getInstance(string categoryPath, int level)
    {
        try {
            CategoryPropertiesFactoryInterface categoryPropertiesFactoryInterface = ((CategoryPropertiesFactoryInterface) new CategoryPropertiesFactory(categoryPath));
            return ((CategoryInterface) new StoreThemeCategory(this.transformInfoInterface, categoryPropertiesFactoryInterface, level));
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().ENTITYFACTORYERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "getInstance(String, int)", e);
            }
            return null;
        }
    }

    public virtual CategoryInterface getInstance(CategoryInterface rootCategoryInterface, CategoryInterface parentCategoryInterface, string categoryPath)
    {
        try {
            CategoryPropertiesFactoryInterface categoryPropertiesFactoryInterface = ((CategoryPropertiesFactoryInterface) new CategoryPropertiesFactory(categoryPath));
            return ((CategoryInterface) new StoreThemeCategory(this.transformInfoInterface, rootCategoryInterface, parentCategoryInterface, categoryPropertiesFactoryInterface));
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().ENTITYFACTORYERROR)) {
                this.logUtil.put(commonStrings.EXCEPTION, this, "getInstance(CategoryInterface, CategoryInterface , String, int)", e);
            }
            return null;
        }
    }

    public virtual CategoryInterface getInstance(Node node, int level)
    {
        try {
            CategoryPropertiesFactoryInterface categoryPropertiesFactoryInterface = ((CategoryPropertiesFactoryInterface) new CategoryPropertiesFactory(node));
            return ((CategoryInterface) new StoreThemeCategory(this.transformInfoInterface, categoryPropertiesFactoryInterface, level));
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().ENTITYFACTORYERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "getInstance(Node, int)", e);
            }
            return null;
        }
    }

    public virtual CategoryInterface getInstance(CategoryInterface rootCategoryInterface, CategoryInterface parentCategoryInterface, Node node)
    {
        try {
            CategoryPropertiesFactoryInterface categoryPropertiesFactoryInterface = ((CategoryPropertiesFactoryInterface) new CategoryPropertiesFactory(node));
            return ((CategoryInterface) new StoreThemeCategory(this.transformInfoInterface, rootCategoryInterface, parentCategoryInterface, categoryPropertiesFactoryInterface));
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().ENTITYFACTORYERROR)) {
                this.logUtil.put(commonStrings.EXCEPTION, this, "getInstance(CategoryInterface, CategoryInterface, Node, int)", e);
            }
            return null;
        }
    }

    public virtual CategoryInterface getInstance(HashMap<object, object> categoryPropertiesHashMap, int level)
    {
        try {
            CategoryPropertiesFactoryInterface categoryPropertiesFactoryInterface = ((CategoryPropertiesFactoryInterface) new CategoryPropertiesFactory(categoryPropertiesHashMap));
            return ((CategoryInterface) new StoreThemeCategory(this.transformInfoInterface, categoryPropertiesFactoryInterface, level));
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().ENTITYFACTORYERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "getInstance(HashMap)", e);
            }
            return null;
        }
    }

    public virtual CategoryInterface getInstance(CategoryInterface rootCategoryInterface, CategoryInterface parentCategoryInterface, HashMap<object, object> categoryPropertiesHashMap)
    {
        try {
            CategoryPropertiesFactoryInterface categoryPropertiesFactoryInterface = ((CategoryPropertiesFactoryInterface) new CategoryPropertiesFactory(categoryPropertiesHashMap));
            return ((CategoryInterface) new StoreThemeCategory(this.transformInfoInterface, rootCategoryInterface, parentCategoryInterface, categoryPropertiesFactoryInterface));
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().ENTITYFACTORYERROR)) {
                this.logUtil.put(commonStrings.EXCEPTION, this, "getInstance(CategoryInterface, CategoryInterface, HashMap)", e);
            }
            return null;
        }
    }

}

