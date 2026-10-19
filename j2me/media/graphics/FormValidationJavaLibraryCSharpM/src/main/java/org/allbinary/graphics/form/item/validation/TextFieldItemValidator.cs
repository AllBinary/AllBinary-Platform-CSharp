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
using ABTextFieldItem = org.allbinary.graphics.form.item.ABTextFieldItem;
using ValidatorBase = org.allbinary.logic.control.validate.ValidatorBase;
using BooleanFactory = org.allbinary.logic.java.@bool.BooleanFactory;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.graphics.form.item.validation;

public class TextFieldItemValidator : ValidatorBase
{
    private readonly ABTextFieldItem textFieldItem;
    private int min;
    private int max;
    private bool allowOnEmpty;
    public TextFieldItemValidator(ABTextFieldItem textFieldItem, int min, int max, bool allowOnEmpty)
    {
        this.textFieldItem = textFieldItem;
        this.min = min;
        this.max = max;
        this.allowOnEmpty = allowOnEmpty;
    }

    public override bool? isValid()
    {
        BooleanFactory booleanFactory = BooleanFactory.getInstance();
        bool? result = booleanFactory.TRUE;
        string @string = this.textFieldItem.getString();
        int textLength = @string.Length;
        if ((textLength == 0 && this.allowOnEmpty) || textLength > this.min && textLength < this.max) {
        } else {
            if (textLength < this.min) {
                result = booleanFactory.FALSE;
            } else if (textLength > this.max) {
                result = booleanFactory.FALSE;
            }
        }
        return result;
    }

    public override BasicArrayList toList()
    {
        BasicArrayList list = new BasicArrayListD();
        string @string = this.textFieldItem.getString();
        int textLength = @string.Length;
        if (textLength > this.min && textLength < this.max) {
        } else {
            string label = this.textFieldItem.getLabel();
            string name = label.Substring(0, (label.Length - 2) - (0));
            if (textLength < this.min) {
                list.add(new StringMaker().append(name).append(" is to short").ToString());
            } else if (textLength > this.max) {
                list.add(new StringMaker().append(name).append(" is to long").ToString());
            }
        }
        return list;
    }

}

