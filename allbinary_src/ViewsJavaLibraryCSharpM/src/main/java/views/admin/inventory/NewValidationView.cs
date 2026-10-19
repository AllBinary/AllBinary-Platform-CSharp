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
using BasicItem = org.allbinary.business.user.commerce.inventory.item.BasicItem;
using ItemInterface = org.allbinary.business.user.commerce.inventory.item.ItemInterface;
using ValidationComponentInterface = org.allbinary.logic.control.validate.ValidationComponentInterface;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using TransformInfoInterface = org.allbinary.logic.visual.transform.info.TransformInfoInterface;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;

namespace views.admin.inventory;

public class NewValidationView : InventoryItemView, ValidationComponentInterface
{
    public NewValidationView(TransformInfoInterface transformInfoInterface) : base(transformInfoInterface, StringUtil.getInstance().EMPTY_STRING)
    {
        // base(transformInfoInterface, StringUtil.getInstance().EMPTY_STRING) is called from the constructor declaration
        this.itemInterface = ((ItemInterface) new BasicItem());
    }

    public virtual bool? isValid()
    {
        try {
            return true;
        } catch (Exception e) {
            return false;
        }
    }

    public virtual Document toValidationInfoDoc()
    {
        return null;
    }

    public virtual Node toValidationInfoNode(Document document)
    {
        return null;
    }

    public virtual string validationInfo()
    {
        return "Error Creating New Item";
    }

}

