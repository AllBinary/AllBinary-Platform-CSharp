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
using Node = org.w3c.dom.Node;

namespace org.allbinary.logic.control.contraints.size;

public class TwoDimensionalConstraint : TwoDimensionalConstraintInterface
{
    private SizeConstraintInterface widthSizeConstraintInterface = null;
    private SizeConstraintInterface heightSizeConstraintInterface = null;
    public TwoDimensionalConstraint(Node node)
    {
    }

    public virtual SizeConstraintInterface getHeight()
    {
        return this.heightSizeConstraintInterface;
    }

    public virtual SizeConstraintInterface getWidth()
    {
        return this.widthSizeConstraintInterface;
    }

    public virtual void setHeight(SizeConstraintInterface heightSizeConstraintInterface)
    {
        this.heightSizeConstraintInterface = heightSizeConstraintInterface;
    }

    public virtual void setWidth(SizeConstraintInterface widthSizeConstraintInterface)
    {
        this.widthSizeConstraintInterface = widthSizeConstraintInterface;
    }

}

