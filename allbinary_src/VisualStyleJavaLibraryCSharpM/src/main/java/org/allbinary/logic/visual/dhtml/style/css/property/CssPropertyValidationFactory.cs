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
using FontFamilyValidation = org.allbinary.logic.visual.dhtml.style.css.property.font.FontFamilyValidation;
using Node = org.w3c.dom.Node;

namespace org.allbinary.logic.visual.dhtml.style.css.property;

public class CssPropertyValidationFactory
{
    private CssPropertyValidationFactory()
    {
    }

    // throws Exception
    public static ValidationInterface getInstance(Node node)
    {
        return ((ValidationInterface) new FontFamilyValidation(node));
    }

}

