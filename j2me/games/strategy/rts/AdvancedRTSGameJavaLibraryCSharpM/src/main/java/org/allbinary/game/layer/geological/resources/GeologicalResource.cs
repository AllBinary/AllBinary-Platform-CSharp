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

namespace org.allbinary.game.layer.geological.resources;

public class GeologicalResource
{
    private int total = 0;
    private int initTotal;
    public GeologicalResource(int initTotal)
    {
        this.initTotal = initTotal;
        this.init();
    }

    public virtual void init()
    {
        this.setTotal(this.initTotal);
    }

    public virtual void add(int value)
    {
        int max = int.MaxValue;
        if (this.getTotal() + value > max) {
            this.setTotal(max);
        } else {
            this.setTotal(this.getTotal() + value);
        }
    }

    public virtual void remove(int value)
    {
        if (this.getTotal() - value < 0) {
            this.setTotal(0);
        } else {
            this.setTotal(this.getTotal() - value);
        }
    }

    public virtual int getTotal()
    {
        return this.total;
    }

    protected virtual void setTotal(int total)
    {
        this.total = total;
    }

}

