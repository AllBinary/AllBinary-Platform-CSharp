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
using CategoryPropertiesFactory = org.allbinary.business.category.properties.CategoryPropertiesFactory;
using CategoryPropertiesFactoryInterface = org.allbinary.business.category.properties.CategoryPropertiesFactoryInterface;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using AbPath = org.allbinary.logic.io.path.AbPath;
using CommonStrings = org.allbinary.@string.CommonStrings;
using Node = org.w3c.dom.Node;

namespace org.allbinary.business.category;

public class CategoryAbstractFactory : CategoryFactoryInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    public CategoryAbstractFactory()
    {
    }

    public virtual CategoryInterface getRootInstance()
    {
        throw new SystemException();
    }

    public virtual CategoryInterface getRootInstance(AbPath categoryAbPath)
    {
        throw new SystemException();
    }

    public virtual CategoryInterface getRootInstanceFromNode(Node node)
    {
        throw new SystemException();
    }

    public virtual CategoryInterface getInstance(string categoryName)
    {
        try {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().CATEGORY)) {
                this.logUtil.putF(this.commonStrings.START, this, "getInstance(String)");
            }
            CategoryPropertiesFactoryInterface categoryPropertiesFactoryInterface = ((CategoryPropertiesFactoryInterface) new CategoryPropertiesFactory(categoryName));
            return ((CategoryInterface) new Category(categoryPropertiesFactoryInterface));
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().ENTITYFACTORYERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "getInstance(String, int)", e);
            }
            return null;
        }
    }

    public virtual CategoryInterface getInstance(CategoryInterface rootCategoryInterface, CategoryInterface parentCategoryInterface, string categoryName)
    {
        try {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().CATEGORY)) {
                this.logUtil.putF(this.commonStrings.START, this, "getInstance(CategoryInterface, CategoryInterface, String)");
            }
            CategoryPropertiesFactoryInterface categoryPropertiesFactoryInterface = ((CategoryPropertiesFactoryInterface) new CategoryPropertiesFactory(categoryName));
            return ((CategoryInterface) new Category(rootCategoryInterface, parentCategoryInterface, categoryPropertiesFactoryInterface));
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().ENTITYFACTORYERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "getInstance(CategoryInterface, CategoryInterface , String, int)", e);
            }
            return null;
        }
    }

    public virtual CategoryInterface getInstance(Node node)
    {
        try {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().CATEGORY)) {
                this.logUtil.putF(this.commonStrings.START, this, "getInstance(Node)");
            }
            CategoryPropertiesFactoryInterface categoryPropertiesFactoryInterface = ((CategoryPropertiesFactoryInterface) new CategoryPropertiesFactory(node));
            return ((CategoryInterface) new Category(categoryPropertiesFactoryInterface));
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
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().CATEGORY)) {
                this.logUtil.putF(this.commonStrings.START, this, "getInstance(CategoryInterface, CategoryInterface, Node)");
            }
            CategoryPropertiesFactoryInterface categoryPropertiesFactoryInterface = ((CategoryPropertiesFactoryInterface) new CategoryPropertiesFactory(node));
            return ((CategoryInterface) new Category(rootCategoryInterface, parentCategoryInterface, categoryPropertiesFactoryInterface));
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().ENTITYFACTORYERROR)) {
                this.logUtil.put(commonStrings.EXCEPTION, this, "getInstance(CategoryInterface, CategoryInterface, Node, int)", e);
            }
            return null;
        }
    }

    public virtual CategoryInterface getInstance(CategoryInterface rootCategoryInterface, CategoryInterface parentCategoryInterface, HashMap categoryPropertiesHashMap)
    {
        try {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().CATEGORY)) {
                this.logUtil.putF(this.commonStrings.START, this, "getInstance(CategoryInterface, CategoryInterface, HashMap)");
            }
            CategoryPropertiesFactoryInterface categoryPropertiesFactoryInterface = ((CategoryPropertiesFactoryInterface) new CategoryPropertiesFactory(categoryPropertiesHashMap));
            return ((CategoryInterface) new Category(rootCategoryInterface, parentCategoryInterface, categoryPropertiesFactoryInterface));
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().CATEGORYERROR)) {
                this.logUtil.put(commonStrings.EXCEPTION, this, "getInstance(CategoryInterface, CategoryInterface, HashMap)", e);
            }
            return null;
        }
    }

}

