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

public class ScrollSelectionFormTempHorizontalDx : ItemIndexDx
{
    private readonly ScrollSelectionForm scrollSelectionForm;
    public ScrollSelectionFormTempHorizontalDx(ScrollSelectionForm scrollSelectionForm)
    {
        this.scrollSelectionForm = scrollSelectionForm;
    }

    // throws Exception
    public override int getDx(int index, ABCustomItem item, int dx, int dy)
    {
        return this.scrollSelectionForm.getSelectedIndexForPointTempHorizontalDx(index, item, dx, dy);
    }

}

