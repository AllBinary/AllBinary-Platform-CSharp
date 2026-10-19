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

namespace org.allbinary.media.image;

public class ImageUnifierProperties
{
    private int? rows = null;
    private int? columns = null;
    private ImageUnifierCell imageUnifierCell = null;
    public ImageUnifierProperties()
    {
    }

    public virtual int getWidth()
    {
        return ((int) this.getColumns()) * ((int) this.getImageUnifierCell().getWidth());
    }

    public virtual int getHeight()
    {
        return ((int) this.getRows()) * ((int) this.getImageUnifierCell().getHeight());
    }

    public virtual int? getRows()
    {
        return this.rows;
    }

    public virtual void setRows(int? rows)
    {
        this.rows = rows;
    }

    public virtual int? getColumns()
    {
        return this.columns;
    }

    public virtual void setColumns(int? columns)
    {
        this.columns = columns;
    }

    public virtual ImageUnifierCell getImageUnifierCell()
    {
        return this.imageUnifierCell;
    }

    public virtual void setImageUnifierCell(ImageUnifierCell imageUnifierCell)
    {
        this.imageUnifierCell = imageUnifierCell;
    }

}

