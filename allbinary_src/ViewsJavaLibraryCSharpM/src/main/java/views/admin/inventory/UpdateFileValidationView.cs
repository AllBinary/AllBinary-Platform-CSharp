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
using StoreFrontFactory = org.allbinary.business.context.modules.storefront.StoreFrontFactory;
using StoreFrontInterface = org.allbinary.business.context.modules.storefront.StoreFrontInterface;
using BasicItemData = org.allbinary.business.user.commerce.inventory.item.BasicItemData;
using BasicItemValidation = org.allbinary.business.user.commerce.inventory.item.BasicItemValidation;
using MoneyException = org.allbinary.business.user.commerce.money.MoneyException;
using InventoryEntity = org.allbinary.data.tables.user.commerce.inventory.item.InventoryEntity;
using InventoryEntityFactory = org.allbinary.data.tables.user.commerce.inventory.item.InventoryEntityFactory;
using GLOBALS2 = org.allbinary.globals.GLOBALS2;
using URLGLOBALS = org.allbinary.globals.URLGLOBALS;
using HttpFileUploadUtil = org.allbinary.logic.communication.http.file.upload.HttpFileUploadUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using ValidationComponentInterface = org.allbinary.logic.control.validate.ValidationComponentInterface;
using AbFile = org.allbinary.logic.io.file.AbFile;
using FileData = org.allbinary.logic.io.file.FileData;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringValidationUtil = org.allbinary.logic.@string.StringValidationUtil;
using TransformInfoInterface = org.allbinary.logic.visual.transform.info.TransformInfoInterface;
using CommonSeps = org.allbinary.@string.CommonSeps;
using CommonStrings = org.allbinary.@string.CommonStrings;
using FileItem = org.apache.commons.fileupload.FileItem;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;

namespace views.admin.inventory;

public class UpdateFileValidationView : InventoryItemView, ValidationComponentInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly string UPDATEPRODUCT = CommonStrings.getInstance().UPDATE;
    public UpdateFileValidationView(TransformInfoInterface transformInfoInterface) : base(transformInfoInterface)
    {
        // base(transformInfoInterface) is called from the constructor declaration
    }

    public virtual bool? isValid()
    {
        try {
            string command = ((string) this.getRequestHashMap().get(GLOBALS2.ADMINCOMMAND));
            if (command == null || string.CompareOrdinal(command, UpdateFileValidationView.UPDATEPRODUCT) != 0) {
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                    this.logUtil.putF("Invalid AdminCommand=" + command, this, this.commonStrings.IS_VALID);
                }
                return false;
            }
            if (new BasicItemValidation(this.itemInterface).isValid() == false) {
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                    this.logUtil.putF("BasicItem is not valid", this, this.commonStrings.IS_VALID);
                }
                return false;
            }
            StoreFrontInterface storeFrontInterface = StoreFrontFactory.getInstance(this.getWeblisketSession().getStoreName());
            StringMaker stringBuffer = new StringMaker();
            stringBuffer.append(URLGLOBALS.getWebappPath());
            stringBuffer.append(storeFrontInterface.getCurrentHostNamePath());
            stringBuffer.append(this.itemInterface.getCategory());
            string fullCategory = stringBuffer.ToString();
            AbFile categoryFile = AbFile.createAbFile(fullCategory);
            if (!categoryFile.isDirectory()) {
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                    this.logUtil.putF("Category Does Not Exist: " + fullCategory, this, this.commonStrings.IS_VALID);
                }
                return false;
            }
            InventoryEntity inventoryEntity = InventoryEntityFactory.getInstance().getInventoryEntityInstance();
            if (inventoryEntity.getItem(this.itemInterface.getId()) == null) {
                return false;
            }
            object anyType = this.getRequestHashMap().get(basicItemData.IMAGE);
            if (HttpFileUploadUtil.getInstance().isValid(anyType)) {
                FileItem fileItem = ((FileItem) anyType);
                long size = fileItem.getSize();
                string fileName = fileItem.getName();
                HttpFileUploadUtil.log(fileItem);
                if (this.isValid(fileName, size) == false) {
                    return false;
                }
            }
            return true;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                this.logUtil.put("Exception in validation", this, this.commonStrings.IS_VALID, e);
            }
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

    // throws Exception
    public virtual string validationInfo()
    {
        StringMaker stringBuffer = new StringMaker();
        string command = ((string) this.getRequestHashMap().get(GLOBALS2.ADMINCOMMAND));
        if (command == null || string.CompareOrdinal(command, UpdateFileValidationView.UPDATEPRODUCT) != 0) {
            return CommonSeps.getInstance().SPACE;
        }
        stringBuffer.append(new BasicItemValidation(this.itemInterface).validationInfo());
        StoreFrontInterface storeFrontInterface = StoreFrontFactory.getInstance(this.getWeblisketSession().getStoreName());
        string fullCategory = ((string) URLGLOBALS.getWebappPath()) + storeFrontInterface.getCurrentHostNamePath() + this.itemInterface.getCategory();
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
            this.logUtil.putF("Category: " + fullCategory, this, "validationInfo()");
        }
        try {
            if (InventoryEntityFactory.getInstance().getInventoryEntityInstance().getItem(this.itemInterface.getId()) == null) {
                stringBuffer.append("Item does not exist.<br>");
            }
        } catch (MoneyException e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                this.logUtil.putF("Existing Item With MoneyException", this, "validationInfo()");
            }
        }
        object anyType = this.getRequestHashMap().get(basicItemData.IMAGE);
        if (HttpFileUploadUtil.getInstance().isValid(anyType)) {
            FileItem fileItem = ((FileItem) anyType);
            long size = fileItem.getSize();
            string fileName = fileItem.getName();
            string fileItemFieldName = fileItem.getFieldName();
            this.validationInfo(stringBuffer, fileName, fileItemFieldName, size);
        }
        return stringBuffer.ToString();
    }

    // throws Exception
    private bool? isValid(string fileName, long size)
    {
        FileData fileData = FileData.getInstance();
        if (size > fileData.MINIMAGEFILESIZE) {
            if (size < fileData.MAXIMAGEFILESIZE) {
                if (!StringValidationUtil.getInstance().isValidRequired(fileName, fileData.MINLEN, fileData.MAXLEN)) {
                    return false;
                }
            } else {
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                    StringMaker stringBuffer = new StringMaker();
                    stringBuffer.append("File Size To Large: ");
                    stringBuffer.appendlong(size);
                    stringBuffer.append(">");
                    stringBuffer.appendint(((int) fileData.MAXIMAGEFILESIZE));
                    this.logUtil.putF(stringBuffer.ToString(), this, this.commonStrings.IS_VALID);
                }
                return false;
            }
            this.processImageFiles();
        }
        return true;
    }

    private void validationInfo(StringMaker stringBuffer, string fileName, string fileItemFieldName, long size)
    {
        FileData fileData = FileData.getInstance();
        if (size > fileData.MINIMAGEFILESIZE) {
            if (string.CompareOrdinal(fileItemFieldName, basicItemData.IMAGE) == 0) {
                if (size < fileData.MAXIMAGEFILESIZE) {
                    if (!StringValidationUtil.getInstance().isValidRequired(fileName, fileData.MINLEN, fileData.MAXLEN)) {
                        stringBuffer.append("FileName must be >");
                        stringBuffer.appendint(((int) fileData.MINLEN));
                        stringBuffer.append("and <");
                        stringBuffer.appendint(((int) fileData.MAXLEN));
                        stringBuffer.append("<br />");
                    }
                } else {
                    stringBuffer.append("Image File Is Not The Right Size. ");
                    stringBuffer.appendint(((int) fileData.MINIMAGEFILESIZE));
                    stringBuffer.append("< > ");
                    stringBuffer.appendint(((int) fileData.MAXIMAGEFILESIZE));
                    stringBuffer.append("<br />");
                }
            }
        }
    }

}

