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
using java.util;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using BasicItemData = org.allbinary.business.user.commerce.inventory.item.BasicItemData;
using DownloadItemData = org.allbinary.business.user.commerce.inventory.item.download.DownloadItemData;
using InventoryEntity = org.allbinary.data.tables.user.commerce.inventory.item.InventoryEntity;
using InventoryEntityFactory = org.allbinary.data.tables.user.commerce.inventory.item.InventoryEntityFactory;
using DownloadItemsEntity = org.allbinary.data.tables.user.commerce.inventory.item.downloads.DownloadItemsEntity;
using DownloadItemsEntityFactory = org.allbinary.data.tables.user.commerce.inventory.item.downloads.DownloadItemsEntityFactory;
using RequestParams = org.allbinary.logic.communication.http.request.RequestParams;
using ValidationComponentInterface = org.allbinary.logic.control.validate.ValidationComponentInterface;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using StringValidationUtil = org.allbinary.logic.@string.StringValidationUtil;
using TransformInfoInterface = org.allbinary.logic.visual.transform.info.TransformInfoInterface;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;

namespace views.admin.inventory.download;

public class DeleteFileValidationView : DownloadableInventoryItemView, ValidationComponentInterface
{
    private string downloadItemId = null;
    public DeleteFileValidationView(TransformInfoInterface transformInfoInterface) : base(transformInfoInterface, StringUtil.getInstance().EMPTY_STRING)
    {
        // base(transformInfoInterface, StringUtil.getInstance().EMPTY_STRING) is called from the constructor declaration
        this.getFormData();
    }

    // throws Exception
    public virtual void getFormData()
    {
        HashMap hashMap = new RequestParams(request).toHashMap();
        if (hashMap == null) {
            throw new Exception("No Request Params Found");
        }
        this.id = ((string) hashMap.get(basicItemData.ID));
        this.downloadItemId = ((string) hashMap.get(DownloadItemData.ID));
    }

    public virtual bool? isValid()
    {
        try {
            if (id == null || !StringValidationUtil.getInstance().isNumber(this.id)) {
                return false;
            }
            InventoryEntity inventoryEntity = InventoryEntityFactory.getInstance().getInventoryEntityInstance();
            this.itemInterface = inventoryEntity.getItem(this.id);
            if (this.itemInterface == null) {
                return false;
            }
            DownloadItemsEntity downloadItemsEntity = DownloadItemsEntityFactory.getInstance().getDownloadItemsEntityInstance();
            BasicArrayList vector = downloadItemsEntity.getForItem(this.id, this.downloadItemId);
            if (vector.size() != 1) {
                return false;
            }
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
        try {
            StringMaker stringBuffer = new StringMaker();
            if (this.id == null || !StringValidationUtil.getInstance().isNumber(this.id)) {
                stringBuffer.append("Id is not valid.<br />");
            }
            if (InventoryEntityFactory.getInstance().getInventoryEntityInstance().getItem(this.id) == null) {
                stringBuffer.append("Item does not exist.<br />");
            }
            DownloadItemsEntity downloadItemsEntity = DownloadItemsEntityFactory.getInstance().getDownloadItemsEntityInstance();
            BasicArrayList vector = downloadItemsEntity.getForItem(this.id, this.downloadItemId);
            if (vector.size() == 0) {
                stringBuffer.append("DownloadItem does not exist.<br />");
            }
            if (vector.size() > 1) {
                stringBuffer.append("To Many DownloadItems exist.<br />");
            }
            return stringBuffer.ToString();
        } catch (Exception e) {
            return "Unkown Validation Error.<br />";
        }
    }

}

