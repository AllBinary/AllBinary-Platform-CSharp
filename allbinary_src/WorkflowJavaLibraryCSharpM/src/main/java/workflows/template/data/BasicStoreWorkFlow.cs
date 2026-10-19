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
//using PageContext = javax.servlet.jsp.PageContext;
using StoreFrontData = org.allbinary.business.context.modules.storefront.StoreFrontData;
using StoreWorkFlowInterface = org.allbinary.logic.control.workflow.StoreWorkFlowInterface;

namespace workflows.template.data;

public class BasicStoreWorkFlow : BasicWorkFlow, StoreWorkFlowInterface
{
    public BasicStoreWorkFlow(HashMap propertiesHashMap, PageContext pageContext) : base(propertiesHashMap, pageContext)
    {
        // base(propertiesHashMap, pageContext) is called from the constructor declaration
    }

    // throws Exception
    public virtual string getStoreName()
    {
        return ((string) this.getPropertiesHashMap().get(StoreFrontData.getInstance().NAME));
    }

}

