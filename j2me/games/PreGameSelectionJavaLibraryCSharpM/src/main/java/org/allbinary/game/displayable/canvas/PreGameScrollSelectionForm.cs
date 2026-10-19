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
using ABCustomItem = org.allbinary.graphics.form.item.ABCustomItem;
using Rectangle = org.allbinary.graphics.Rectangle;
using BasicColor = org.allbinary.graphics.color.BasicColor;
using FormTypeFactory = org.allbinary.graphics.form.FormTypeFactory;
using ItemPaintableFactory = org.allbinary.graphics.form.ItemPaintableFactory;
using ScrollCurrentSelectionForm = org.allbinary.graphics.form.ScrollCurrentSelectionForm;

namespace org.allbinary.game.displayable.canvas;

public class PreGameScrollSelectionForm : ScrollCurrentSelectionForm
{
    public PreGameScrollSelectionForm(string title, ABCustomItem[] items, ItemPaintableFactory formPaintableFactory, BasicColor backgroundBasicColor, BasicColor foregroundBasicColor) : base(title, items, formPaintableFactory, 0, 3, false, backgroundBasicColor, foregroundBasicColor)
    {
        // base(title, items, formPaintableFactory, 0, 3, false, backgroundBasicColor, foregroundBasicColor) is called from the constructor declaration
    }

    // throws Exception
    public virtual void init(Rectangle rectangle)
    {
        base.init(rectangle, FormTypeFactory.getInstance().TEMP_HORIZONTAL_FORM);
    }

}

