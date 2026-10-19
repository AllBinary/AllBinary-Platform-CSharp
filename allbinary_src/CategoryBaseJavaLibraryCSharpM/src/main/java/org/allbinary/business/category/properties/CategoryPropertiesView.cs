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
using CategoryData = org.allbinary.business.category.CategoryData;
using DomNodeInterface = org.allbinary.data.tree.dom.DomNodeInterface;
using Document = org.w3c.dom.Document;
using Element = org.w3c.dom.Element;
using Node = org.w3c.dom.Node;

namespace org.allbinary.business.category.properties;

public class CategoryPropertiesView : DomNodeInterface
{
    public CategoryPropertiesInterface categoryPropertiesInterface;
    public CategoryPropertiesView(CategoryPropertiesInterface categoryPropertiesInterface)
    {
        this.categoryPropertiesInterface = categoryPropertiesInterface;
    }

    // throws Exception
    public virtual Node toXmlNode(Document document)
    {
        Node categoryNode = document.createElement(CategoryData.getInstance().NAME);
        Element newCategoryNode = ((Element) categoryNode);
        newCategoryNode.setAttribute(CategoryData.getInstance().LABEL, this.categoryPropertiesInterface.getValue());
        return categoryNode;
    }

}

