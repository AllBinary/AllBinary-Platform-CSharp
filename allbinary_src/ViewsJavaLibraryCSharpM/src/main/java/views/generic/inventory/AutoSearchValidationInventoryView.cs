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
using SearchRequest = org.allbinary.logic.control.search.SearchRequest;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;

namespace views.generic.inventory;

public class AutoSearchValidationInventoryView : InventorySearch
{
    public AutoSearchValidationInventoryView(SearchRequest searchRequest) : base(searchRequest)
    {
        // base(searchRequest) is called from the constructor declaration
    }

    public virtual bool? isValid()
    {
        return true;
    }

    public virtual Document toValidationInfoDoc()
    {
        return null;
    }

    public virtual Node toValidationInfoNode(Document document)
    {
        return null;
    }

    public virtual string validationInfo()
    {
        return null;
    }

}

