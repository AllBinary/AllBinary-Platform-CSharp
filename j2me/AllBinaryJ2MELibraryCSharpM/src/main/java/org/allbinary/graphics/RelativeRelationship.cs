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
using BasicArrayListUtil = org.allbinary.util.BasicArrayListUtil;

namespace org.allbinary.graphics;

public class RelativeRelationship
{
    public static readonly RelativeRelationship NULL_RELATIVE_RELATIONSHIP = new RelativeRelationship(PointFactory.getInstance().ZERO_ZERO, BasicArrayListUtil.getInstance().getImmutableInstance());
    private BasicArrayList typesAllowedList;
    private int x;
    private int y;
    private int z;
    public RelativeRelationship(GPoint point, BasicArrayList typesAllowedList)
    {
        this.x = point.getX();
        this.y = point.getY();
        this.z = point.getZ();
        this.typesAllowedList = typesAllowedList;
    }

    public virtual int getX()
    {
        return this.x;
    }

    public virtual int getY()
    {
        return this.y;
    }

    public virtual int getZ()
    {
        return this.z;
    }

    public virtual BasicArrayList getTypesAllowedList()
    {
        return this.typesAllowedList;
    }

    public virtual void setTypesAllowedList(BasicArrayList typesAllowedList)
    {
        this.typesAllowedList = typesAllowedList;
    }

}

