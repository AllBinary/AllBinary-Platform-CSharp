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
using BooleanFactory = org.allbinary.logic.java.@bool.BooleanFactory;
using Visitor = org.allbinary.logic.util.visitor.Visitor;

namespace org.allbinary.graphics.form.item.validation;

public class TextItemVisitor : Visitor
{
    public TextItemVisitor()
    {
    }

    public override object visit(object anyType)
    {
        string value = ((string) anyType);
        if (value.Length < 2) {
            return BooleanFactory.getInstance().TRUE;
        } else {
            return BooleanFactory.getInstance().FALSE;
        }
    }

}

