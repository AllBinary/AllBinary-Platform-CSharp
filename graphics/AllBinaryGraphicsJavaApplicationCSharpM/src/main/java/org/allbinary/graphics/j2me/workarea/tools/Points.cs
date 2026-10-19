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
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.graphics.j2me.workarea.tools;

public class Points : PointsInterface
{
    private readonly BasicArrayList pointVector;
    public Points()
    {
        this.pointVector = new BasicArrayListD();
    }

    public virtual void init()
    {
        this.pointVector.clear();
    }

    public virtual BasicArrayList getPoints()
    {
        return this.pointVector;
    }

    public virtual void addPoints(BasicArrayList vector)
    {
        this.pointVector.addAll2(vector);
    }

    public virtual bool isValid()
    {
        if (this.pointVector.size() > 1) {
            return true;
        } else {
            return false;
        }
    }

    public virtual int getSize()
    {
        return this.pointVector.size();
    }

}

