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
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using CategoryPropertiesInterface = org.allbinary.business.category.properties.CategoryPropertiesInterface;
using CategoryPropertiesView = org.allbinary.business.category.properties.CategoryPropertiesView;
using DomNodeInterface = org.allbinary.data.tree.dom.DomNodeInterface;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using InterfaceUtil = org.allbinary.logic.java.anyType.InterfaceUtil;
using CommonSeps = org.allbinary.@string.CommonSeps;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;

namespace org.allbinary.business.category;

public class CategoryView : DomNodeInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private CategoryInterface categoryInterface;
    public CategoryView(CategoryInterface categoryInterface)
    {
        this.categoryInterface = categoryInterface;
    }

    public virtual CategoryInterface getCategoryInterface()
    {
        return this.categoryInterface;
    }

    // throws Exception
    public virtual Node toXmlNode(Document document)
    {
        Node node = document.createElement(CategoryData.getInstance().NAME);
        BasicArrayList childCategoryVector = this.categoryInterface.getChildNodes();
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().CATEGORY)) {
            this.logUtil.putF("Number Of Children: " + childCategoryVector.size(), this, "toXmlNode");
        }
        int size = childCategoryVector.size();
        for (int i = 0; i < size; i++) {
            object anyType = childCategoryVector.get(i);
            CategoryPropertiesInterface categoryPropertiesInterface = null;
            if (InterfaceUtil.isImplemented("CategoryPropertiesInterface", anyType)) {
                categoryPropertiesInterface = ((CategoryPropertiesInterface) anyType);
            } else if (InterfaceUtil.isImplemented("CategoryInterface", anyType)) {
                CategoryInterface categoryInterface = ((CategoryInterface) anyType);
                categoryPropertiesInterface = categoryInterface.getProperties();
            } else {
                string isImpl = InterfaceUtil.viewAll(anyType.GetType(), CommonSeps.getInstance().NEW_LINE);
                throw new Exception("CategoryView found unknown object.\n" + "Show Testing:" + isImpl);
            }
            Node childCategoryNode = new CategoryPropertiesView(categoryPropertiesInterface).toXmlNode(document);
            node.appendChild(childCategoryNode);
        }
        return node;
    }

}

