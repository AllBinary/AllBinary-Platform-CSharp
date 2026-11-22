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
using MESSAGES = org.allbinary.globals.MESSAGES;
using ValidationComponentInterface = org.allbinary.logic.control.validate.ValidationComponentInterface;
using TransformInfoInterface = org.allbinary.logic.visual.transform.info.TransformInfoInterface;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;

namespace views.generic.order.history;

public class ValidationView : OrderHistoryView, ValidationComponentInterface
{
    public ValidationView(TransformInfoInterface transformInfoInterface) : base(transformInfoInterface)
    {
        // Constructor invocation emitted in the initializer.
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
        return MESSAGES.CONTACTADMIN;
    }

    // throws Exception
    public override TransformInfoInterface getTransformInfoInterface()
    {
        return base.getTransformInfoInterface();
    }

}

