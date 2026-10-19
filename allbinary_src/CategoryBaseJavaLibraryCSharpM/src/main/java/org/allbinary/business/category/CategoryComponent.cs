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
using DomDocumentHelper = org.allbinary.data.tree.dom.document.DomDocumentHelper;
using TransformInterface = org.allbinary.logic.visual.transform.TransformInterface;
using TransformDocumentInterface = org.allbinary.logic.visual.transform.data.TransformDocumentInterface;
using TransformInfoInterface = org.allbinary.logic.visual.transform.info.TransformInfoInterface;
using Document = org.w3c.dom.Document;

namespace org.allbinary.business.category;

public class CategoryComponent : CategoryView, TransformInterface
{
    public CategoryComponent(CategoryInterface categoryInterface) : base(categoryInterface)
    {
        // base(categoryInterface) is called from the constructor declaration
    }

    public int NO_TYPE = 0;
    public virtual int getTypeId()
    {
        return this.NO_TYPE;
    }

    public virtual TransformDocumentInterface getTransformDocumentInterface()
    {
        return null;
    }

    // throws Exception
    public virtual TransformInfoInterface getTransformInfoInterface()
    {
        return null;
    }

    public virtual void setTransformDocumentInterface(TransformDocumentInterface viewDocumentInterface)
    {
    }

    // throws Exception
    public virtual Document toXmlDoc()
    {
        Document document = DomDocumentHelper.create();
        document.appendChild(new CategoryView(this.getCategoryInterface()).toXmlNode(document));
        return document;
    }

    // throws Exception
    public virtual string view()
    {
        return null;
    }

}

