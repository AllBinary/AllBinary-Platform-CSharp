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
using DomSearchHelper = org.allbinary.data.tree.dom.DomSearchHelper;
using DisplayInBrowserContraints = org.allbinary.logic.control.contraints.display.browser.DisplayInBrowserContraints;
using DisplayInBrowserContraintsInterface = org.allbinary.logic.control.contraints.display.browser.DisplayInBrowserContraintsInterface;
using TwoDimensionalConstraint = org.allbinary.logic.control.contraints.size.TwoDimensionalConstraint;
using TwoDimensionalConstraintInterface = org.allbinary.logic.control.contraints.size.TwoDimensionalConstraintInterface;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;

namespace org.allbinary.business.advertisement.area;

public class AdvertisementAreaConstraints : AdvertisementAreaConstraintsInterface
{
    private DisplayInBrowserContraintsInterface displayInBrowserContraintsInterface;
    private TwoDimensionalConstraintInterface twoDimensionConstraintsInterface;
    public AdvertisementAreaConstraints(Document document)
    {
        Node node = DomSearchHelper.getNode(AdvertisementAreaData.getInstance().NAME, document.getChildNodes());
        this.displayInBrowserContraintsInterface = new DisplayInBrowserContraints(node);
        this.twoDimensionConstraintsInterface = new TwoDimensionalConstraint(node);
    }

    public virtual void setDisplayInBrowserContraints(DisplayInBrowserContraintsInterface displayInBrowserContraintsInterface)
    {
        this.displayInBrowserContraintsInterface = displayInBrowserContraintsInterface;
    }

    public virtual void getTwoDimensionContraints(TwoDimensionalConstraintInterface twoDimensionConstraintsInterface)
    {
        this.twoDimensionConstraintsInterface = twoDimensionConstraintsInterface;
    }

    public virtual DisplayInBrowserContraintsInterface getDisplayInBrowserContraints()
    {
        return this.displayInBrowserContraintsInterface;
    }

    public virtual TwoDimensionalConstraintInterface getTwoDimensionContraints()
    {
        return this.twoDimensionConstraintsInterface;
    }

}

