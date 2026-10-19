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
using SmallIntegerSingletonFactory = org.allbinary.logic.math.SmallIntegerSingletonFactory;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.graphics.form.item.validation;

public class NumberTextFieldItemValidator : ValidatorBase
{
    private readonly ABTextFieldItem textFieldItem;
    private readonly int min;
    private readonly int max;
    private readonly int maxChars;
    public NumberTextFieldItemValidator(ABTextFieldItem textFieldItem, int maxChars, int min, int max)
    {
        this.textFieldItem = textFieldItem;
        this.min = min;
        this.max = max;
        this.maxChars = maxChars;
    }

    protected virtual bool? isNumberValid(int? value)
    {
        return BooleanFactory.getInstance().TRUE;
    }

    protected virtual BasicArrayList toNumberVector(int? value)
    {
        return new BasicArrayListD();
    }

    public override bool? isValid()
    {
        bool? result = BooleanFactory.getInstance().TRUE;
        string @string = this.textFieldItem.getString();
        int textLength = @string.Length;
        if (textLength > 0 && textLength < this.maxChars) {
            try {
                int.Parse(this.textFieldItem.getString());
            } catch (NumberFormatException e) {
                result = BooleanFactory.getInstance().FALSE;
            }
        } else {
            if (textLength < 1) {
                result = BooleanFactory.getInstance().FALSE;
            } else if (textLength > this.maxChars) {
                result = BooleanFactory.getInstance().FALSE;
            }
        }
        return result;
    }

    public override BasicArrayList toList()
    {
        BasicArrayList list = new BasicArrayListD();
        string @string = this.textFieldItem.getString();
        int textLength = @string.Length;
        string label = this.textFieldItem.getLabel();
        string name = label.Substring(0, (label.Length - 2) - (0));
        SmallIntegerSingletonFactory smallIntegerSingletonFactory = SmallIntegerSingletonFactory.getInstance();
        StringMaker stringMaker = new StringMaker();
        if (textLength > 0 && textLength < this.maxChars) {
            try {
                int? number = smallIntegerSingletonFactory.createInstance(int.Parse(this.textFieldItem.getString()));
                if (((int) number) > this.min) {
                    stringMaker.delete(0, stringMaker.length());
                    list.add(stringMaker.append(name).append(" is to small").ToString());
                } else if (((int) number) > this.max) {
                    stringMaker.delete(0, stringMaker.length());
                    list.add(stringMaker.append(name).append(" is to large").ToString());
                }
            } catch (NumberFormatException e) {
                stringMaker.delete(0, stringMaker.length());
                list.add(stringMaker.append(name).append(" is not a number").ToString());
            }
        } else {
            if (textLength < 1) {
                stringMaker.delete(0, stringMaker.length());
                list.add(stringMaker.append(name).append(" is to short").ToString());
            } else if (textLength > this.maxChars) {
                stringMaker.delete(0, stringMaker.length());
                list.add(stringMaker.append(name).append(" is to long").ToString());
            }
        }
        return list;
    }

}

