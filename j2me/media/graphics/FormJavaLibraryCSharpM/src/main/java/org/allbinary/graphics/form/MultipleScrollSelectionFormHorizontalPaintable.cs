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
using Graphics = javax.microedition.lcdui.Graphics;
using ABCustomItem = org.allbinary.graphics.form.item.ABCustomItem;

namespace org.allbinary.graphics.form;

public class MultipleScrollSelectionFormHorizontalPaintable : ItemIndexPaintable
{
    private readonly MultipleScrollSelectionHorizontalForm multipleScrollSelectionForm;
    public MultipleScrollSelectionFormHorizontalPaintable(MultipleScrollSelectionHorizontalForm multipleScrollSelectionForm)
    {
        this.multipleScrollSelectionForm = multipleScrollSelectionForm;
    }

    // throws Exception
    public override int paint(Graphics graphics, int index, ABCustomItem item, int dx, int dy)
    {
        return this.multipleScrollSelectionForm.paintHorizontal(graphics, index, item, dx, dy);
    }

}

