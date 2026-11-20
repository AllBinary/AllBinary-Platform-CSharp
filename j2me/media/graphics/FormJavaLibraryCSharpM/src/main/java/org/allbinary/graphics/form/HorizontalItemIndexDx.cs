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

namespace org.allbinary.graphics.form;

public class HorizontalItemIndexDx : ItemIndexDx
{
    private readonly ScrollCurrentSelectionForm scrollCurrentSelectionForm;
    public HorizontalItemIndexDx(ScrollCurrentSelectionForm scrollCurrentSelectionForm)
    {
        this.scrollCurrentSelectionForm = scrollCurrentSelectionForm;
    }

    // throws Exception
    public override int getDx(int index, ABCustomItem item, int dx, int dy)
    {
        return this.scrollCurrentSelectionForm.getXHorizontalForm(index, item, dx, dy);
    }

}

