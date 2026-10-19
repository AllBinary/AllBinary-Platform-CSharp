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
using StoreFrontFactory = org.allbinary.business.context.modules.storefront.StoreFrontFactory;
using StoreFrontInterface = org.allbinary.business.context.modules.storefront.StoreFrontInterface;
using BasicItemData = org.allbinary.business.user.commerce.inventory.item.BasicItemData;
using BasicItemValidation = org.allbinary.business.user.commerce.inventory.item.BasicItemValidation;
using DownloadItemData = org.allbinary.business.user.commerce.inventory.item.download.DownloadItemData;
using DownloadableItem = org.allbinary.business.user.commerce.inventory.item.download.DownloadableItem;
using DownloadableItemValidation = org.allbinary.business.user.commerce.inventory.item.download.DownloadableItemValidation;
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
using StringUtil = org.allbinary.logic.@string.StringUtil;
using StringValidationUtil = org.allbinary.logic.@string.StringValidationUtil;
using TransformInfoInterface = org.allbinary.logic.visual.transform.info.TransformInfoInterface;
using CommonStrings = org.allbinary.@string.CommonStrings;
using FileItem = org.apache.commons.fileupload.FileItem;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;

namespace views.admin.inventory.download;

public class UpdateFileValidationView : DownloadableInventoryItemView, ValidationComponentInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    public UpdateFileValidationView(TransformInfoInterface transformInfoInterface) : base(transformInfoInterface)
    {
        // base(transformInfoInterface) is called from the constructor declaration
    }

    public virtual bool? isValid()
    {
        try {
            string command = ((string) this.getRequestHashMap().get(GLOBALS2.ADMINCOMMAND));
            if (StringValidationUtil.getInstance().isEmpty(command) || string.CompareOrdinal(command, this.commonStrings.UPDATE) != 0) {
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                    this.logUtil.putF("Invalid AdminCommand=" + command, this, this.commonStrings.IS_VALID);
                }
                return false;
            }
            try {
                InventoryEntity inventoryEntity = InventoryEntityFactory.getInstance().getInventoryEntityInstance();
                this.itemInterface = inventoryEntity.getItem(this.id);
            } catch (MoneyException e) {
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                    this.logUtil.put("Existing Item With MoneyException", this, this.commonStrings.IS_VALID, e);
                }
            }
            if (this.itemInterface == null) {
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                    this.logUtil.putF("Item Does Not Exist", this, this.commonStrings.IS_VALID);
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
            string fullCategory = new StringMaker().append(URLGLOBALS.getWebappPath()).append(storeFrontInterface.getCurrentHostNamePath()).append(this.itemInterface.getCategory()).ToString();
            AbFile categoryFile = AbFile.createAbFile(fullCategory);
            if (!categoryFile.isDirectory()) {
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                    this.logUtil.putF("Category Does Not Exist: " + fullCategory, this, this.commonStrings.IS_VALID);
                }
                return false;
            }
            object downloadableFileObject = this.getRequestHashMap().get(DownloadItemData.FILE);
            if (HttpFileUploadUtil.getInstance().isValid(downloadableFileObject)) {
                FileItem fileItem = ((FileItem) downloadableFileObject);
                string fileName = fileItem.getName();
                long size = fileItem.getSize();
                HttpFileUploadUtil.log(fileItem);
                if (this.isValid(fileName, size) == false) {
                    return false;
                } else {
                    this.processFile(fileItem);
                    this.getRequestHashMap().put(DownloadItemData.SIZE, (size).ToString());
                }
            } else {
                this.getRequestHashMap().remove(DownloadItemData.FILE);
            }
            object licenseFileObject = this.getRequestHashMap().get(DownloadItemData.LICENSE_FILE);
            if (HttpFileUploadUtil.getInstance().isValid(licenseFileObject)) {
                FileItem fileItem = ((FileItem) licenseFileObject);
                string fileName = fileItem.getName();
                long size = fileItem.getSize();
                HttpFileUploadUtil.log(fileItem);
                if (this.isValid(fileName, size) == false) {
                } else {
                    this.processFile(fileItem);
                }
            } else {
                this.getRequestHashMap().remove(DownloadItemData.LICENSE_FILE);
            }
            object extraFilesObject = this.getRequestHashMap().get(DownloadItemData.EXTRA_FILES);
            if (HttpFileUploadUtil.getInstance().isValid(extraFilesObject)) {
                FileItem fileItem = ((FileItem) extraFilesObject);
                string fileName = fileItem.getName();
                long size = fileItem.getSize();
                HttpFileUploadUtil.log(fileItem);
                if (this.isValid(fileName, size) == false) {
                } else {
                    this.processFile(fileItem);
                    this.unzip(fileItem);
                }
            } else {
                this.getRequestHashMap().remove(DownloadItemData.EXTRA_FILES);
            }
            HashMap hashMap = this.getRequestHashMap();
            hashMap.put(basicItemData.ID, this.itemInterface.getId());
            object licenseObject = hashMap.get(DownloadItemData.LICENSE_FILE);
            if (licenseObject != null) {
                hashMap.put(DownloadItemData.LICENSE_FILE, (((FileItem) licenseObject)).getName());
            } else {
                hashMap.put(DownloadItemData.LICENSE_FILE, StringUtil.getInstance().EMPTY_STRING);
            }
            object fileObject = hashMap.get(DownloadItemData.FILE);
            if (fileObject != null) {
                hashMap.put(DownloadItemData.FILE, (((FileItem) fileObject)).getName());
            } else {
                hashMap.put(DownloadItemData.FILE, StringUtil.getInstance().EMPTY_STRING);
            }
            this.downloadableItem = new DownloadableItem(hashMap);
            DownloadableItemValidation downloadableItemValidation = new DownloadableItemValidation(this.downloadableItem);
            if (downloadableItemValidation.isValid() == false) {
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                    this.logUtil.putF("DownloadableItem is not valid", this, this.commonStrings.IS_VALID);
                }
                return false;
            }
            return true;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEWERROR)) {
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

    public virtual string validationInfo()
    {
        try {
            StringMaker stringBuffer = new StringMaker();
            string command = ((string) this.getRequestHashMap().get(GLOBALS2.ADMINCOMMAND));
            if (StringValidationUtil.getInstance().isEmpty(command) || string.CompareOrdinal(command, this.commonStrings.UPDATE) != 0) {
                return StringUtil.getInstance().EMPTY_STRING;
            }
            if (this.itemInterface == null) {
                string ITEM_NOT_FOUND = "Item Does Not Exist";
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                    this.logUtil.putF(ITEM_NOT_FOUND, this, "validationInfo()");
                }
                return ITEM_NOT_FOUND;
            }
            BasicItemValidation basicItemValidation = new BasicItemValidation(this.itemInterface);
            if (basicItemValidation.isValid() == false) {
                stringBuffer.append(basicItemValidation.validationInfo());
                stringBuffer.append("<br/>");
            }
            StoreFrontInterface storeFrontInterface = StoreFrontFactory.getInstance(this.getWeblisketSession().getStoreName());
            string fullCategory = new StringMaker().append(URLGLOBALS.getWebappPath()).append(storeFrontInterface.getCurrentHostNamePath()).append(this.itemInterface.getCategory()).ToString();
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                this.logUtil.putF("Category: " + fullCategory, this, "validationInfo()");
            }
            AbFile categoryFile = AbFile.createAbFile(fullCategory);
            if (!categoryFile.isDirectory()) {
                stringBuffer.append("Category ");
                stringBuffer.append(this.itemInterface.getCategory());
                stringBuffer.append(" does not exist.");
                stringBuffer.append("<br />");
            }
            object downloadableFileObject = this.getRequestHashMap().get(DownloadItemData.FILE);
            if (HttpFileUploadUtil.getInstance().isValid(downloadableFileObject)) {
                FileItem fileItem = ((FileItem) downloadableFileObject);
                string fileName = fileItem.getName();
                long size = fileItem.getSize();
                this.validationInfo(stringBuffer, fileName, size);
            } else {
                stringBuffer.append("Download File Missing");
                stringBuffer.append("<br/>");
            }
            object licenseFileObject = this.getRequestHashMap().get(DownloadItemData.LICENSE_FILE);
            if (HttpFileUploadUtil.getInstance().isValid(licenseFileObject)) {
                FileItem fileItem = ((FileItem) licenseFileObject);
                string fileName = fileItem.getName();
                long size = fileItem.getSize();
                this.validationInfo(stringBuffer, fileName, size);
            } else {
            }
            object extraFilesObject = this.getRequestHashMap().get(DownloadItemData.EXTRA_FILES);
            if (HttpFileUploadUtil.getInstance().isValid(extraFilesObject)) {
                FileItem fileItem = ((FileItem) extraFilesObject);
                string fileName = fileItem.getName();
                long size = fileItem.getSize();
                this.validationInfo(stringBuffer, fileName, size);
            } else {
            }
            if (this.downloadableItem != null) {
                DownloadableItemValidation downloadableItemValidation = new DownloadableItemValidation(this.downloadableItem);
                if (downloadableItemValidation.isValid() == false) {
                    string log = downloadableItemValidation.validationInfo();
                    if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                        this.logUtil.putF(log, this, this.commonStrings.IS_VALID);
                    }
                    stringBuffer.append(log);
                    stringBuffer.append("<br/>");
                }
            }
            return stringBuffer.ToString();
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEWERROR)) {
                this.logUtil.put("Failed to generate validation error info", this, "validationInfo()", e);
            }
            return "Error Getting Validation Info";
        }
    }

    // throws Exception
    private bool? isValid(string fileName, long size)
    {
        FileData fileData = FileData.getInstance();
        if (size > fileData.MINDOWNLOADABLEFILESIZE) {
            if (size < fileData.MAXDOWNLOADABLEFILESIZE) {
                if (!StringValidationUtil.getInstance().isValidRequired(fileName, fileData.MINLEN, fileData.MAXLEN)) {
                    if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                        StringMaker stringBuffer = new StringMaker();
                        stringBuffer.append("File name is not valid: ");
                        stringBuffer.append(fileName);
                        this.logUtil.putF(stringBuffer.ToString(), this, this.commonStrings.IS_VALID);
                    }
                    return false;
                } else {
                }
            } else {
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                    StringMaker stringBuffer = new StringMaker();
                    stringBuffer.append("File Size To Large: ");
                    stringBuffer.appendlong(size);
                    stringBuffer.append(">");
                    stringBuffer.appendint(((int) fileData.MAXDOWNLOADABLEFILESIZE));
                    this.logUtil.putF(stringBuffer.ToString(), this, this.commonStrings.IS_VALID);
                }
                return false;
            }
        } else {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                StringMaker stringBuffer = new StringMaker();
                stringBuffer.append("File Size To Small: ");
                stringBuffer.appendlong(size);
                stringBuffer.append(">");
                stringBuffer.appendint(((int) fileData.MINDOWNLOADABLEFILESIZE));
                this.logUtil.putF(stringBuffer.ToString(), this, this.commonStrings.IS_VALID);
            }
            return false;
        }
        return true;
    }

    private void validationInfo(StringMaker stringBuffer, string fileName, long size)
    {
        FileData fileData = FileData.getInstance();
        if (size > fileData.MINDOWNLOADABLEFILESIZE) {
            if (size < fileData.MAXDOWNLOADABLEFILESIZE) {
                if (!StringValidationUtil.getInstance().isValidRequired(fileName, fileData.MINLEN, fileData.MAXLEN)) {
                    stringBuffer.append("File Name must be more than ");
                    stringBuffer.appendint(((int) fileData.MINLEN));
                    stringBuffer.append(" and less than ");
                    stringBuffer.appendint(((int) fileData.MAXLEN));
                    stringBuffer.append(" characters in length: ");
                    stringBuffer.append(fileName);
                    stringBuffer.append("<br/>");
                } else {
                }
            } else {
                stringBuffer.append("File Is Not The Right Size. ");
                stringBuffer.appendint(((int) fileData.MINDOWNLOADABLEFILESIZE));
                stringBuffer.append("< >");
                stringBuffer.appendint(((int) fileData.MAXDOWNLOADABLEFILESIZE));
                stringBuffer.append("<br/>");
            }
        }
    }

}

