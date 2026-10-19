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
using ValidationInterface = org.allbinary.logic.control.validate.ValidationInterface;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;

namespace org.allbinary.business.category.store.theme;

public class StoreThemeCategoryPathValidationView : StoreThemeCategoryPathView, ValidationInterface
{
    public StoreThemeCategoryPathValidationView(StoreThemeCategoryInterface categoryInterface) : base(((StoreThemeCategoryInterface) categoryInterface))
    {
        // base(((StoreThemeCategoryInterface) categoryInterface)) is called from the constructor declaration
    }

    // throws Exception
    public virtual bool? isValid()
    {
        return true;
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
        return "Error";
    }

}

