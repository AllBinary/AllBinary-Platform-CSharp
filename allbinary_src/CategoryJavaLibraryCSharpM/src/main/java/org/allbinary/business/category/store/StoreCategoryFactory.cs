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
using Category = org.allbinary.business.category.Category;
using CategoryAbstractFactory = org.allbinary.business.category.CategoryAbstractFactory;
using CategoryFactoryInterface = org.allbinary.business.category.CategoryFactoryInterface;
using CategoryInterface = org.allbinary.business.category.CategoryInterface;
using CategoryUtil = org.allbinary.business.category.CategoryUtil;
using CategoryPropertiesFactoryInterface = org.allbinary.business.category.properties.CategoryPropertiesFactoryInterface;
using RootStoreCategoryPropertiesFactory = org.allbinary.business.category.properties.root.store.RootStoreCategoryPropertiesFactory;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using AbPath = org.allbinary.logic.io.path.AbPath;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using TransformInfoInterface = org.allbinary.logic.visual.transform.info.TransformInfoInterface;
using Node = org.w3c.dom.Node;

namespace org.allbinary.business.category.store;

public class StoreCategoryFactory : CategoryAbstractFactory, CategoryFactoryInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private TransformInfoInterface transformInfoInterface;
    public StoreCategoryFactory(TransformInfoInterface transformInfoInterface)
    {
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().CATEGORY)) {
            this.logUtil.putF(this.commonStrings.START, this, "StoreCategoryFactory(TransformInfoInterface transformInfoInterface)");
        }
        this.transformInfoInterface = transformInfoInterface;
    }

    public virtual CategoryInterface getRootInstance()
    {
        try {
            CategoryPropertiesFactoryInterface categoryPropertiesFactoryInterface = ((CategoryPropertiesFactoryInterface) new RootStoreCategoryPropertiesFactory(this.transformInfoInterface));
            return ((CategoryInterface) new Category(categoryPropertiesFactoryInterface));
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().ENTITYFACTORYERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "getInstance(String, int)", e);
            }
            return null;
        }
    }

    public virtual CategoryInterface getRootInstance(AbPath categoryPath)
    {
        try {
            int level = CategoryUtil.getPathLevel(categoryPath);
            CategoryPropertiesFactoryInterface categoryPropertiesFactoryInterface = ((CategoryPropertiesFactoryInterface) new RootStoreCategoryPropertiesFactory(this.transformInfoInterface, categoryPath));
            return ((CategoryInterface) new Category(categoryPropertiesFactoryInterface, level));
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().ENTITYFACTORYERROR)) {
                this.logUtil.put(commonStrings.EXCEPTION, this, "getInstance(String, int)", e);
            }
            return null;
        }
    }

    public virtual CategoryInterface getRootInstanceFromNode(Node node)
    {
        try {
            CategoryPropertiesFactoryInterface categoryPropertiesFactoryInterface = ((CategoryPropertiesFactoryInterface) new RootStoreCategoryPropertiesFactory(this.transformInfoInterface, node));
            AbPath categoryPath = new AbPath(CategoryUtil.getNameFromNode(node), StringUtil.getInstance().EMPTY_STRING);
            int level = CategoryUtil.getPathLevel(categoryPath);
            return ((CategoryInterface) new Category(categoryPropertiesFactoryInterface, level));
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().ENTITYFACTORYERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "getInstance(String, int)", e);
            }
            return null;
        }
    }

}

