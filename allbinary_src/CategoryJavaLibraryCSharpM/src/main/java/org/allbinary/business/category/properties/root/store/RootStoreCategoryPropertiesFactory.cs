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
using CategoryPropertiesFactoryInterface = org.allbinary.business.category.properties.CategoryPropertiesFactoryInterface;
using CategoryPropertiesInterface = org.allbinary.business.category.properties.CategoryPropertiesInterface;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using AbPath = org.allbinary.logic.io.path.AbPath;
using TransformInfoInterface = org.allbinary.logic.visual.transform.info.TransformInfoInterface;
using CommonStrings = org.allbinary.@string.CommonStrings;
using Node = org.w3c.dom.Node;

namespace org.allbinary.business.category.properties.root.store;

public class RootStoreCategoryPropertiesFactory : CategoryPropertiesFactoryInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private CategoryPropertiesInterface categoryPropertiesInterface;
    public RootStoreCategoryPropertiesFactory(TransformInfoInterface transformInfoInterface)
    {
        this.categoryPropertiesInterface = ((CategoryPropertiesInterface) new RootStoreCategoryProperties(transformInfoInterface));
    }

    public RootStoreCategoryPropertiesFactory(TransformInfoInterface transformInfoInterface, AbPath abPath)
    {
        this.categoryPropertiesInterface = ((CategoryPropertiesInterface) new RootStoreCategoryProperties(transformInfoInterface, abPath));
    }

    public RootStoreCategoryPropertiesFactory(TransformInfoInterface transformInfoInterface, Node node)
    {
        this.categoryPropertiesInterface = ((CategoryPropertiesInterface) new RootStoreCategoryProperties(transformInfoInterface, node));
    }

    public RootStoreCategoryPropertiesFactory(TransformInfoInterface transformInfoInterface, HashMap categoryPropertiesHashMap)
    {
        this.categoryPropertiesInterface = ((CategoryPropertiesInterface) new RootStoreCategoryProperties(transformInfoInterface, categoryPropertiesHashMap));
    }

    public virtual CategoryPropertiesInterface getInstance()
    {
        try {
            return ((CategoryPropertiesInterface) this.categoryPropertiesInterface);
        } catch (Exception e) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().ENTITYFACTORYERROR)) {
                this.logUtil.put(commonStrings.EXCEPTION, this, commonStrings.GET_INSTANCE, e);
            }
            return null;
        }
    }

}

