/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2006 AllBinary 
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
using ABCustomItem = org.allbinary.graphics.form.item.ABCustomItem;
using PointFactory = org.allbinary.graphics.PointFactory;
using Rectangle = org.allbinary.graphics.Rectangle;
using BasicColorFactory = org.allbinary.graphics.color.BasicColorFactory;
using DisplayInfoSingleton = org.allbinary.graphics.displayable.DisplayInfoSingleton;
using FormTypeFactory = org.allbinary.graphics.form.FormTypeFactory;
using MultipleScrollSelectionHorizontalForm = org.allbinary.graphics.form.MultipleScrollSelectionHorizontalForm;
using ScrollSelectionForm = org.allbinary.graphics.form.ScrollSelectionForm;
using CommonButtons = org.allbinary.input.motion.button.CommonButtons;
using TouchButtonLocationHelper = org.allbinary.input.motion.button.TouchButtonLocationHelper;

namespace org.allbinary.game.layer;

public class RTSScrollSelectionFormFactory
{
    // throws Exception
    public static ScrollSelectionForm getInstance(string formLabel, ABCustomItem[] items)
    {
        BasicColorFactory basicColorFactory = BasicColorFactory.getInstance();
        TouchButtonLocationHelper touchButtonLocationHelper = new TouchButtonLocationHelper();
        DisplayInfoSingleton displayInfo = DisplayInfoSingleton.getInstance();
        int menuX = CommonButtons.getInstance().STANDARD_BUTTON_SIZE + touchButtonLocationHelper.getColumnsRemainderHalf();
        int width = displayInfo.getLastWidth() - (menuX * 2);
        Rectangle menuRectangle = new Rectangle(PointFactory.getInstance().createXY(menuX, 16), width, CommonButtons.getInstance().STANDARD_BUTTON_SIZE);
        return MultipleScrollSelectionHorizontalForm.createForm(formLabel, items, menuRectangle, FormTypeFactory.getInstance().HORIZONTAL_FORM, 0, basicColorFactory.BLACK, basicColorFactory.WHITE);
    }

}

