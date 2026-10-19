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
using RequestMapInterface = org.allbinary.logic.communication.http.request.RequestMapInterface;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using TransformInterface = org.allbinary.logic.visual.transform.TransformInterface;
using ValidationViewHelper = taghelpers.ValidationViewHelper;
using HelperTag = tags.HelperTag;
using InventoryItemView = views.admin.inventory.InventoryItemView;
using DownloadableInventoryItemView = views.admin.inventory.download.DownloadableInventoryItemView;

namespace admin.taghelpers;

public class InventoryItemViewParentTagHelper
{
    private static readonly InventoryItemViewParentTagHelper instance = new InventoryItemViewParentTagHelper();
    public static InventoryItemViewParentTagHelper getInstance()
    {
        return InventoryItemViewParentTagHelper.instance;
    }

    // throws Exception
    public virtual InventoryItemView getInventoryItemView(HelperTag inventoryTag)
    {
        if (inventoryTag != null) {
            this.checkForValidationViewHelper(inventoryTag.getHelper());
            ValidationViewHelper validationViewHelper = ((ValidationViewHelper) inventoryTag.getHelper());
            TransformInterface viewObject = validationViewHelper.getViewObject();
            if (viewObject.getTypeId() != InventoryItemView.TYPE_ID) {
                StringMaker stringBuffer = new StringMaker();
                stringBuffer.append("Must have ");
                stringBuffer.append("InventoryItemView and not: ");
                stringBuffer.append(inventoryTag.getHelper().GetType().FullName);
                throw new Exception(stringBuffer.ToString());
            }
            return ((InventoryItemView) viewObject);
        } else {
            throw new Exception("Must have parent tag.");
        }
    }

    // throws Exception
    public virtual DownloadableInventoryItemView getDownloadableInventoryItemView(HelperTag inventoryTag)
    {
        if (inventoryTag != null) {
            this.checkForValidationViewHelper(inventoryTag.getHelper());
            ValidationViewHelper validationViewHelper = ((ValidationViewHelper) inventoryTag.getHelper());
            TransformInterface viewObject = validationViewHelper.getViewObject();
            if (viewObject.getTypeId() != DownloadableInventoryItemView.TYPE_ID) {
                StringMaker stringBuffer = new StringMaker();
                stringBuffer.append("Must have ");
                stringBuffer.append("DownloadableInventoryItemView and not: ");
                stringBuffer.append(inventoryTag.getHelper().GetType().FullName);
                throw new Exception(stringBuffer.ToString());
            }
            return ((DownloadableInventoryItemView) viewObject);
        } else {
            throw new Exception("Must have parent tag.");
        }
    }

    // throws Exception
    public virtual RequestMapInterface getRequestMapInterface(HelperTag inventoryTag)
    {
        if (inventoryTag != null) {
            this.checkForValidationViewHelper(inventoryTag.getHelper());
            ValidationViewHelper validationViewHelper = ((ValidationViewHelper) inventoryTag.getHelper());
            TransformInterface viewObject = validationViewHelper.getViewObject();
            if (viewObject.getTypeId() != InventoryItemView.TYPE_ID && viewObject.getTypeId() != DownloadableInventoryItemView.TYPE_ID) {
                StringMaker stringBuffer = new StringMaker();
                stringBuffer.append("Must have ");
                stringBuffer.append("specific TYPE_ID and not: ");
                stringBuffer.append(inventoryTag.getHelper().GetType().FullName);
                throw new Exception(stringBuffer.ToString());
            }
            return ((RequestMapInterface) viewObject);
        } else {
            throw new Exception("Must have parent tag.");
        }
    }

    // throws Exception
    public virtual void checkForValidationViewHelper(object helperObject)
    {
        if (!(helperObject is ValidationViewHelper)) {
            StringMaker stringBuffer = new StringMaker();
            stringBuffer.append("Must have ");
            stringBuffer.append("ValidationViewHelper");
            stringBuffer.append("and not: ");
            stringBuffer.append(helperObject.GetType().FullName);
            throw new Exception(stringBuffer.ToString());
        }
    }

}

