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
using DownloadableItem = org.allbinary.business.user.commerce.inventory.item.download.DownloadableItem;
using MoneyException = org.allbinary.business.user.commerce.money.MoneyException;
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

public class EditValidationView : DownloadableInventoryItemView, ValidationComponentInterface
{
    private string downloadItemId = null;
    public EditValidationView(TransformInfoInterface transformInfoInterface) : base(transformInfoInterface, StringUtil.getInstance().EMPTY_STRING)
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

    // throws Exception
    public virtual bool? isValid()
    {
        if (id == null || !StringValidationUtil.getInstance().isNumber(this.id)) {
            return false;
        }
        this.itemInterface = InventoryEntityFactory.getInstance().getInventoryEntityInstance().getItem(this.id);
        if (this.itemInterface == null) {
            return false;
        }
        int downloadable = int.Parse(this.itemInterface.getDownloads());
        if (downloadable != 0) {
            DownloadItemsEntity downloadItemsEntity = DownloadItemsEntityFactory.getInstance().getDownloadItemsEntityInstance();
            BasicArrayList vector = downloadItemsEntity.getForItem(this.id, this.downloadItemId);
            if (vector.size() != 1) {
                return false;
            }
            this.downloadableItem = ((DownloadableItem) vector.get(0));
        } else {
            return false;
        }
        return true;
    }

    public virtual Document toValidationInfoDoc()
    {
        return null;
    }

    public virtual Node toValidationInfoNode(Document document)
    {
        return null;
    }

    // throws MoneyException
    public virtual string validationInfo()
    {
        StringMaker stringBuffer = new StringMaker();
        if (this.id == null || !StringValidationUtil.getInstance().isNumber(this.id)) {
            stringBuffer.append("Id is not valid.<br />");
        }
        if (InventoryEntityFactory.getInstance().getInventoryEntityInstance().getItem(this.id) == null) {
            stringBuffer.append("Item does not exist.<br />");
        }
        int downloadable = int.Parse(this.itemInterface.getDownloads());
        if (downloadable != 0) {
            if (this.downloadableItem == null) {
                stringBuffer.append("DownloadableItem does not exist for item.<br />");
            }
        } else {
            stringBuffer.append("Item should not have DownloadableItem.<br />");
        }
        return stringBuffer.ToString();
    }

}

