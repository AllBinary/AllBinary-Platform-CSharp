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
using TransformInfoHttpFactory = org.allbinary.logic.visual.transform.info.TransformInfoHttpFactory;
using TransformInfoHttpInterface = org.allbinary.logic.visual.transform.info.TransformInfoHttpInterface;
using PaymentProcessorComponent = views.admin.payment.PaymentProcessorComponent;

namespace admin.taghelpers;

public class PaymentProcessHelper : TagHelper
{
    private PaymentProcessorComponent paymentProcessorComponent;
    public PaymentProcessHelper(HashMap propertiesHashMap, PageContext pageContext)
    {
        TransformInfoHttpInterface transformInfoInterface = ((TransformInfoHttpInterface) TransformInfoHttpFactory.getInstance(propertiesHashMap, pageContext));
        this.paymentProcessorComponent = new PaymentProcessorComponent(transformInfoInterface);
    }

    // throws Exception
    public virtual string process()
    {
        return this.paymentProcessorComponent.view();
    }

}

