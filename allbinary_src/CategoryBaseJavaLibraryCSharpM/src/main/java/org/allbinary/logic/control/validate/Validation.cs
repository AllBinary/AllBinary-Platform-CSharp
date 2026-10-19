/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2025 AllBinary 
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
using CommonStrings = org.allbinary.@string.CommonStrings;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;

namespace org.allbinary.logic.control.validate;

public class Validation : ValidationInterface
{
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    // throws Exception
    public virtual bool? isValid()
    {
        throw new SystemException();
    }

    // throws Exception
    public virtual Node toValidationInfoNode(Document document)
    {
        throw new SystemException();
    }

    // throws Exception
    public virtual Document toValidationInfoDoc()
    {
        throw new SystemException();
    }

    // throws Exception
    public virtual string validationInfo()
    {
        throw new SystemException();
    }

}

