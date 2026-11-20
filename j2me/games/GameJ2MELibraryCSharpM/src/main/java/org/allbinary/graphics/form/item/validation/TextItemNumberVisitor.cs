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
using TextNotificationUtil = org.allbinary.game.input.TextNotificationUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using BooleanFactory = org.allbinary.logic.java.@bool.BooleanFactory;
using StringValidationUtil = org.allbinary.logic.@string.StringValidationUtil;
using Visitor = org.allbinary.logic.util.visitor.Visitor;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.graphics.form.item.validation;

public class TextItemNumberVisitor : Visitor
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public TextItemNumberVisitor()
    {
    }

    public override object visit(object anyType)
    {
        string value = ((string) anyType);
        if (value.Length < 2) {
            StringValidationUtil stringValidationUtil = StringValidationUtil.getInstance();
            if (stringValidationUtil.isNumber(value)) {
                return BooleanFactory.getInstance().TRUE;
            } else {
                try {
                    TextNotificationUtil.getInstance().fireError("Numbers Only");
                } catch (Exception e) {
                    CommonStrings commonStrings = CommonStrings.getInstance();
                    this.logUtil.put(commonStrings.EXCEPTION, this, commonStrings.VISIT, e);
                }
                return BooleanFactory.getInstance().FALSE;
            }
        } else {
            return BooleanFactory.getInstance().FALSE;
        }
    }

}

