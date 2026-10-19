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
using InventoryEntityFactory = org.allbinary.data.tables.user.commerce.inventory.item.InventoryEntityFactory;
using GLOBALS2 = org.allbinary.globals.GLOBALS2;
using URLGLOBALS = org.allbinary.globals.URLGLOBALS;
using HttpFileUploadUtil = org.allbinary.logic.communication.http.file.upload.HttpFileUploadUtil;
using UploadMediaSingleton = org.allbinary.logic.communication.http.file.upload.media.UploadMediaSingleton;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using ValidationComponentInterface = org.allbinary.logic.control.validate.ValidationComponentInterface;
using AbFile = org.allbinary.logic.io.file.AbFile;
using FileData = org.allbinary.logic.io.file.FileData;
using AbPathData = org.allbinary.logic.io.path.AbPathData;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using StringValidationUtil = org.allbinary.logic.@string.StringValidationUtil;
using TransformInfoInterface = org.allbinary.logic.visual.transform.info.TransformInfoInterface;
using CommonLabels = org.allbinary.@string.CommonLabels;
using FileItem = org.apache.commons.fileupload.FileItem;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;

namespace views.admin.inventory;

public class AddFileValidationView : InventoryItemView, ValidationComponentInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly BasicItemData basicItemData = BasicItemData.getInstance();
    private static readonly string ADDPRODUCT = "Add Product";
    private static readonly string NEXTSTEP = CommonLabels.getInstance().NEXT + " Step";
    public AddFileValidationView(TransformInfoInterface transformInfoInterface) : base(transformInfoInterface)
    {
        // base(transformInfoInterface) is called from the constructor declaration
    }

    public virtual bool? isValid()
    {
        try {
            string command = ((string) this.getRequestHashMap().get(GLOBALS2.ADMINCOMMAND));
            if (StringValidationUtil.getInstance().isEmpty(command) || (string.CompareOrdinal(command, AddFileValidationView.ADDPRODUCT) != 0 && string.CompareOrdinal(command, NEXTSTEP) != 0)) {
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                    StringMaker stringBuffer = new StringMaker();
                    stringBuffer.append("Invalid AdminCommand: ");
                    stringBuffer.append(command);
                    stringBuffer.append(" must be: ");
                    stringBuffer.append(AddFileValidationView.ADDPRODUCT);
                    stringBuffer.append(" or ");
                    stringBuffer.append(AddFileValidationView.NEXTSTEP);
                    this.logUtil.putF(stringBuffer.ToString(), this, this.commonStrings.IS_VALID);
                }
                return false;
            }
            BasicItemValidation basicItemValidation = new BasicItemValidation(this.itemInterface);
            if (basicItemValidation.isValid() == false) {
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                    this.logUtil.putF(basicItemValidation.validationInfo(), this, this.commonStrings.IS_VALID);
                }
                return false;
            }
            StoreFrontInterface storeFrontInterface = StoreFrontFactory.getInstance(this.getWeblisketSession().getStoreName());
            this.itemInterface.setCategory(storeFrontInterface.getCategoryPath() + this.itemInterface.getCategory());
            string fullCategory = new StringMaker().append(URLGLOBALS.getWebappPath()).append(storeFrontInterface.getCurrentHostNamePath()).append(this.itemInterface.getCategory()).ToString();
            AbFile categoryFile = AbFile.createAbFile(fullCategory);
            if (!categoryFile.isDirectory()) {
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                    this.logUtil.putF("Category Does Not Exist: " + fullCategory, this, this.commonStrings.IS_VALID);
                }
                return false;
            }
            if (InventoryEntityFactory.getInstance().getInventoryEntityInstance().getItem(this.itemInterface.getId()) != null) {
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                    this.logUtil.putF("Item Already Exists", this, this.commonStrings.IS_VALID);
                }
                return false;
            }
            object imageFileItemObject = this.getRequestHashMap().get(basicItemData.IMAGE);
            if (HttpFileUploadUtil.getInstance().isValid(imageFileItemObject)) {
                FileItem fileItem = ((FileItem) imageFileItemObject);
                string fileName = fileItem.getName();
                long size = fileItem.getSize();
                HttpFileUploadUtil.log(fileItem);
                if (this.isValid(fileName, size) == false) {
                    return false;
                }
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
            if (StringValidationUtil.getInstance().isEmpty(command) || (string.CompareOrdinal(command, AddFileValidationView.ADDPRODUCT) != 0 && string.CompareOrdinal(command, NEXTSTEP) != 0)) {
                return StringUtil.getInstance().EMPTY_STRING;
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
                stringBuffer.append(" does not exist.<br />");
            }
            try {
                if (InventoryEntityFactory.getInstance().getInventoryEntityInstance().getItem(this.itemInterface.getId()) != null) {
                    stringBuffer.append("Id is already in use. Refresh the page for a valid id.<br/>");
                }
            } catch (MoneyException e) {
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                    this.logUtil.putF("Existing Item With MoneyException", this, "validationInfo()");
                }
            }
            object anyType = this.getRequestHashMap().get(basicItemData.IMAGE);
            if (HttpFileUploadUtil.getInstance().isValid(anyType)) {
                FileItem fileItem = ((FileItem) anyType);
                string fileName = fileItem.getName();
                string fileItemFieldName = fileItem.getFieldName();
                long size = fileItem.getSize();
                this.validationInfo(stringBuffer, fileName, fileItemFieldName, size);
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
        if (size > fileData.MINIMAGEFILESIZE) {
            if (size < fileData.MAXIMAGEFILESIZE) {
                if (!StringValidationUtil.getInstance().isValidRequired(fileName, fileData.MINLEN, fileData.MAXLEN)) {
                    return false;
                } else {
                    AbPathData pathData = AbPathData.getInstance();
                    string extension = pathData.getExtension(fileName);
                    UploadMediaSingleton uploadMedia = UploadMediaSingleton.getInstance();
                    if (!uploadMedia.isWriterSupported(extension) && !uploadMedia.isReaderSupported(extension)) {
                        return false;
                    }
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
        } else {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                StringMaker stringBuffer = new StringMaker();
                stringBuffer.append("File Size To Small: ");
                stringBuffer.appendlong(size);
                stringBuffer.append(">");
                stringBuffer.appendint(((int) fileData.MINIMAGEFILESIZE));
                this.logUtil.putF(stringBuffer.ToString(), this, this.commonStrings.IS_VALID);
            }
            return false;
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
                        stringBuffer.append(" and <");
                        stringBuffer.appendint(((int) fileData.MAXLEN));
                        stringBuffer.append("<br/>");
                    } else {
                        AbPathData pathData = AbPathData.getInstance();
                        string extension = pathData.getExtension(fileName);
                        UploadMediaSingleton uploadMedia = UploadMediaSingleton.getInstance();
                        if (!uploadMedia.isWriterSupported(extension) && !uploadMedia.isReaderSupported(extension)) {
                            stringBuffer.append("Image type: ");
                            stringBuffer.append(extension);
                            stringBuffer.append(" not supported.<br />");
                        }
                    }
                } else {
                    stringBuffer.append("Image File Is To Large. ");
                    stringBuffer.appendint(((int) fileData.MINIMAGEFILESIZE));
                    stringBuffer.append(" < > ");
                    stringBuffer.appendint(((int) fileData.MAXIMAGEFILESIZE));
                    stringBuffer.append("<br/>");
                }
            }
        } else {
            stringBuffer.append("Image File Is To Small. ");
            stringBuffer.appendint(((int) fileData.MINIMAGEFILESIZE));
            stringBuffer.append(" < > ");
            stringBuffer.appendint(((int) fileData.MAXIMAGEFILESIZE));
            stringBuffer.append("<br/>");
        }
    }

}

