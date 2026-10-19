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

namespace org.allbinary.business.advertisement.thumbnail;

public class AdvertisementThumbnail : AdvertisementThumbnailInterface
{
    private string imageFileName = null;
    private string imageUrl = null;
    private TwoDimensionalConstraintInterface constraint = null;
    public AdvertisementThumbnail()
    {
    }

    public virtual string getFileName()
    {
        return this.imageFileName;
    }

    public virtual string getUrl()
    {
        return this.imageUrl;
    }

    public virtual TwoDimensionalConstraintInterface getTwoDimensionalConstraint()
    {
        return this.constraint;
    }

}

