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
using BasicItemData = org.allbinary.business.user.commerce.inventory.item.BasicItemData;
using InventoryEntityFactory = org.allbinary.data.tables.user.commerce.inventory.item.InventoryEntityFactory;
using RequestParams = org.allbinary.logic.communication.http.request.RequestParams;
using ValidationComponentInterface = org.allbinary.logic.control.validate.ValidationComponentInterface;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using StringValidationUtil = org.allbinary.logic.@string.StringValidationUtil;
using TransformInfoInterface = org.allbinary.logic.visual.transform.info.TransformInfoInterface;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;

namespace views.admin.inventory;

public class DeleteFileValidationView : InventoryItemView, ValidationComponentInterface
{
    private string id = null;
    public DeleteFileValidationView(TransformInfoInterface transformInfoInterface) : base(transformInfoInterface, StringUtil.getInstance().EMPTY_STRING)
    {
        // base(transformInfoInterface, StringUtil.getInstance().EMPTY_STRING) is called from the constructor declaration
        this.getFormData();
    }

    // throws Exception
    public virtual void getFormData()
    {
        HashMap<object, object> hashMap = new RequestParams(request).toHashMap();
        if (hashMap == null) {
            throw new Exception("No Request Params Found");
        }
        this.id = ((string) hashMap.get(basicItemData.ID));
    }

    public virtual bool? isValid()
    {
        try {
            if (this.id == null || !StringValidationUtil.getInstance().isNumber(this.id)) {
                return false;
            }
            this.itemInterface = InventoryEntityFactory.getInstance().getInventoryEntityInstance().getItem(this.id);
            if (this.itemInterface == null) {
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
            return stringBuffer.ToString();
        } catch (Exception e) {
            return "Unkown Validation Error.<br />";
        }
    }

}

