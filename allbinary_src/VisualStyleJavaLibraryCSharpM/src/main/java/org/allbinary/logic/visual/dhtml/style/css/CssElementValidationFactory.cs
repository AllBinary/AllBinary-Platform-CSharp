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
using Node = org.w3c.dom.Node;

namespace org.allbinary.logic.visual.dhtml.style.css;

public class CssElementValidationFactory
{
    private CssElementValidationFactory()
    {
    }

    // throws Exception
    public static ValidationInterface getInstance(Node node)
    {
        return ((ValidationInterface) new CssElementValidation(node));
    }

}

