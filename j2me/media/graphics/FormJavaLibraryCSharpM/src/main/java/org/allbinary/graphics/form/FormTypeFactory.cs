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
using DisplayInfoSingleton = org.allbinary.graphics.displayable.DisplayInfoSingleton;
using StringUtil = org.allbinary.logic.@string.StringUtil;

namespace org.allbinary.graphics.form;

public class FormTypeFactory
{
    private static readonly FormTypeFactory instance = new FormTypeFactory();
    public static FormTypeFactory getInstance()
    {
        return FormTypeFactory.instance;
    }

    public readonly string UNK = "Unknown FormType";
    public readonly FormType NULL_FORM_TYPE = new FormType(StringUtil.getInstance().NULL_STRING);
    public readonly FormType TEMP_HORIZONTAL_FORM = new FormType("TempHorizontal");
    public readonly FormType HORIZONTAL_FORM = new FormType("Horizontal");
    public readonly FormType VERTICAL_CENTER_FORM = new FormType("Vertical");
    public virtual FormType getFormType()
    {
        DisplayInfoSingleton displayInfo = DisplayInfoSingleton.getInstance();
        FormType formType = null;
        if (displayInfo.isPortrait()) {
            formType = this.VERTICAL_CENTER_FORM;
        } else {
            formType = this.HORIZONTAL_FORM;
        }
        return formType;
    }

}

