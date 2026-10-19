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
using TwoDimensionalConstraintInterface = org.allbinary.logic.control.contraints.size.TwoDimensionalConstraintInterface;

namespace org.allbinary.business.advertisement.product;

public class AdvertisementProduct : AdvertisementProductInterface
{
    private string type = null;
    private string link = null;
    private int number = 0;
    private TwoDimensionalConstraintInterface constraint = null;
    public AdvertisementProduct()
    {
    }

    public virtual string getType()
    {
        return this.type;
    }

    public virtual string getLink()
    {
        return this.link;
    }

    public virtual int getNumber()
    {
        return this.number;
    }

    public virtual TwoDimensionalConstraintInterface getTwoDimensionalConstraint()
    {
        return this.constraint;
    }

}

