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
using GPoint = org.allbinary.graphics.GPoint;

namespace org.allbinary.graphics.j2me.workarea.canvas;

public class Grid
{
    public GPoint grid;
    public bool isGridOn = true;
    public bool isGridPossible = false;
    private int zoom = 3;
    public bool isChanged = true;
    public Grid()
    {
    }

    public Grid(Grid grid)
    {
        this.grid = grid.grid;
        this.showGrid(grid.isGridOn);
        this.isGridPossible = grid.isGridPossible;
        this.setZoom(grid.getZoom());
    }

    public virtual bool isGridOn()
    {
        return this.isGridOn;
    }

    public virtual bool isGridPossible()
    {
        return this.isGridPossible;
    }

    public virtual GPoint getGrid()
    {
        return this.grid;
    }

    public virtual int getZoom()
    {
        return this.zoom;
    }

    public virtual void showGrid(bool value)
    {
        this.isGridOn = value;
    }

    public virtual void setZoom(int zoom)
    {
        this.zoom = zoom;
        if (this.zoom < 1) {
            zoom = 1;
        }
        this.isChanged = true;
    }

}

