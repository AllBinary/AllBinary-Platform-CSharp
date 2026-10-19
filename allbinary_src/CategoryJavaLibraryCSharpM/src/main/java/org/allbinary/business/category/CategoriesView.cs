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
using DomNodeInterface = org.allbinary.data.tree.dom.DomNodeInterface;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;

namespace org.allbinary.business.category;

public class CategoriesView : DomNodeInterface
{
    private CategoryInterface categoryInterface;
    public CategoriesView(CategoryInterface categoryInterface)
    {
        this.categoryInterface = categoryInterface;
    }

    // throws Exception
    public virtual Node toXmlNode(Document document)
    {
        Node node = new CategoryView(this.categoryInterface).toXmlNode(document);
        object[] childArray = this.categoryInterface.getChildNodes().toArray();
        int size = childArray.Length;
        for (int i = 0; i < size; i++) {
            CategoryInterface childCategoryInterface = ((CategoryInterface) childArray[i]);
            Node childCategoryNode = new CategoriesView(childCategoryInterface).toXmlNode(document);
            node.appendChild(childCategoryNode);
        }
        return node;
    }

}

