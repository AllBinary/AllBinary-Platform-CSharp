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
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using AbSqlData = org.allbinary.logic.communication.sql.AbSqlData;
using Validation = org.allbinary.logic.control.validate.Validation;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringValidationUtil = org.allbinary.logic.@string.StringValidationUtil;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;

namespace org.allbinary.business.user.commerce.inventory.item.download;

public class DownloadableItemValidation : Validation
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private DownloadableItem downloadableItem;
    public DownloadableItemValidation(DownloadableItem downloadableItem)
    {
        this.downloadableItem = downloadableItem;
    }

    public virtual bool? isValid()
    {
        try {
            if (this.downloadableItem.getId() == null || this.downloadableItem.getId().length() < 1 || this.downloadableItem.getId().length() > AbSqlData.MAXNUM) {
                return false;
            }
            if (this.downloadableItem.getId() != null && !StringValidationUtil.getInstance().isNumber(this.downloadableItem.getId())) {
                return false;
            }
            if (this.downloadableItem.getSystem() == null || this.downloadableItem.getSystem().length() < 1 || this.downloadableItem.getSystem().length() > AbSqlData.MAXSTRING) {
                return false;
            }
            if (this.downloadableItem.getPlatform() == null || this.downloadableItem.getPlatform().length() < 1 || this.downloadableItem.getPlatform().length() > AbSqlData.MAXSTRING) {
                return false;
            }
            if (this.downloadableItem.getSpecialName() == null || this.downloadableItem.getSpecialName().length() < 0 || this.downloadableItem.getSpecialName().length() > AbSqlData.MAXSTRING) {
                return false;
            }
            if (this.downloadableItem.getVersion() == null || this.downloadableItem.getVersion().length() < 1 || this.downloadableItem.getVersion().length() > AbSqlData.MAXSTRING) {
                return false;
            }
            if (this.downloadableItem.getChanges() == null || this.downloadableItem.getChanges().length() < 1 || this.downloadableItem.getChanges().length() > AbSqlData.MAXBLOB) {
                return false;
            }
            if (this.downloadableItem.getSize() == null) {
                return false;
            } else {
                string size = this.downloadableItem.getSize().ToString();
                if (size.Length < 1 || size.Length > AbSqlData.MAXNUM) {
                    return false;
                }
            }
            if (this.downloadableItem.getValidTime() == null) {
                return false;
            } else {
                string size = this.downloadableItem.getValidTime().ToString();
                if (size.Length < 1 || size.Length > AbSqlData.MAXNUM) {
                    return false;
                }
            }
            if (this.downloadableItem.getRetries() == null) {
                return false;
            } else {
                string size = this.downloadableItem.getRetries().ToString();
                if (size.Length < 1 || size.Length > AbSqlData.MAXNUM) {
                    return false;
                }
            }
            return true;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put("Failed to validate form", this, this.commonStrings.IS_VALID, e);
            }
            return false;
        }
    }

    public virtual string validationInfo()
    {
        try {
            StringMaker stringBuffer = new StringMaker();
            if (this.downloadableItem.getId() == null || this.downloadableItem.getId().length() < 1 || this.downloadableItem.getId().length() > AbSqlData.MAXNUM) {
                stringBuffer.append("Id is invalid. Must be number < ");
                stringBuffer.appendint(((int) AbSqlData.MAXNUM));
                stringBuffer.append(" and > 0 digits.<br/>");
            }
            if (this.downloadableItem.getId() != null && !StringValidationUtil.getInstance().isNumber(this.downloadableItem.getId())) {
                stringBuffer.append("Id is invalid. Must be > 0.<br/>");
            }
            if (this.downloadableItem.getSystem() == null || this.downloadableItem.getSystem().length() < 1 || this.downloadableItem.getSystem().length() > AbSqlData.MAXSTRING) {
                stringBuffer.append("System value is invalid. Must be < ");
                stringBuffer.appendint(((int) AbSqlData.MAXSTRING));
                stringBuffer.append(" and > 0 characters long.<br/>");
            }
            if (this.downloadableItem.getPlatform() == null || this.downloadableItem.getPlatform().length() < 1 || this.downloadableItem.getPlatform().length() > AbSqlData.MAXSTRING) {
                stringBuffer.append("Platform value is invalid. Must be < ");
                stringBuffer.appendint(((int) AbSqlData.MAXSTRING));
                stringBuffer.append(" and > 0 characters long.<br/>");
            }
            if (this.downloadableItem.getSpecialName() == null || this.downloadableItem.getSpecialName().length() < 0 || this.downloadableItem.getSpecialName().length() > AbSqlData.MAXSTRING) {
                stringBuffer.append("Special Name value is invalid. Must be < ");
                stringBuffer.appendint(((int) AbSqlData.MAXSTRING));
                stringBuffer.append(" and > 0 characters long.<br/>");
            }
            if (this.downloadableItem.getVersion() == null || this.downloadableItem.getVersion().length() < 1 || this.downloadableItem.getVersion().length() > AbSqlData.MAXSTRING) {
                stringBuffer.append("Version value is invalid. Must be < ");
                stringBuffer.appendint(((int) AbSqlData.MAXSTRING));
                stringBuffer.append(" and > 0 characters long.<br/>");
            }
            if (this.downloadableItem.getChanges() == null || this.downloadableItem.getChanges().length() < 0 || this.downloadableItem.getChanges().length() > AbSqlData.MAXBLOB) {
                stringBuffer.append("Changes value is invalid. Must be < ");
                stringBuffer.appendint(((int) AbSqlData.MAXBLOB));
                stringBuffer.append(" and >= 0 characters long.<br/>");
            }
            if (this.downloadableItem.getSize() == null) {
                stringBuffer.append("File Size is null");
            } else {
                string size = this.downloadableItem.getSize().ToString();
                if (size.Length < 1 || size.Length > AbSqlData.MAXNUM) {
                    stringBuffer.append("File Size is invalid. Must be number < ");
                    stringBuffer.appendint(((int) AbSqlData.MAXNUM));
                    stringBuffer.append(" and > 0 digits.<br/>");
                }
            }
            if (this.downloadableItem.getValidTime() == null) {
                stringBuffer.append("Valid Time is null");
            } else {
                string size = this.downloadableItem.getValidTime().ToString();
                if (size.Length < 1 || size.Length > AbSqlData.MAXNUM) {
                    stringBuffer.append("Valid Time is invalid. Must be number < ");
                    stringBuffer.appendint(((int) AbSqlData.MAXNUM));
                    stringBuffer.append(" and > 0 digits.<br/>");
                }
            }
            if (this.downloadableItem.getRetries() == null) {
                stringBuffer.append("Retries is null");
            } else {
                string size = this.downloadableItem.getRetries().ToString();
                if (size.Length < 1 || size.Length > AbSqlData.MAXNUM) {
                    stringBuffer.append("Retries is invalid. Must be number < ");
                    stringBuffer.appendint(((int) AbSqlData.MAXNUM));
                    stringBuffer.append(" and > 0 digits.<br/>");
                }
            }
            return stringBuffer.ToString();
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put("Failed to generate validation error info", this, "validationInfo()", e);
            }
            return "Error Validating Form";
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

}

