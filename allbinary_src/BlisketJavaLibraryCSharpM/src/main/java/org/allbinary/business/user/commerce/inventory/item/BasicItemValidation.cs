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

namespace org.allbinary.business.user.commerce.inventory.item;

public class BasicItemValidation : Validation
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly int MAXWEIGHT = 14;
    private readonly int MAXPRICE = 14;
    private ItemInterface itemInterface;
    public BasicItemValidation(ItemInterface itemInterface)
    {
        this.itemInterface = itemInterface;
    }

    public virtual bool? isValid()
    {
        try {
            if (this.itemInterface.getId() == null || this.itemInterface.getId().length() < 1 || this.itemInterface.getId().length() > AbSqlData.MAXNUM) {
                return false;
            }
            StringValidationUtil stringValidationUtil = StringValidationUtil.getInstance();
            if (this.itemInterface.getId() != null && !stringValidationUtil.isNumber(this.itemInterface.getId())) {
                return false;
            }
            if (this.itemInterface.getNumber() == null || this.itemInterface.getNumber().length() < 1 || this.itemInterface.getNumber().length() > AbSqlData.MAXNUM) {
                return false;
            }
            if (this.itemInterface.getNumber() != null && !stringValidationUtil.isNumber(this.itemInterface.getNumber())) {
                return false;
            }
            if (this.itemInterface.getInBaskets() == null || this.itemInterface.getInBaskets().length() < 1 || this.itemInterface.getInBaskets().length() > AbSqlData.MAXNUM) {
                return false;
            }
            if (this.itemInterface.getInBaskets() != null && !stringValidationUtil.isNumber(this.itemInterface.getInBaskets())) {
                return false;
            }
            if (this.itemInterface.getWeight() == null || this.itemInterface.getWeight().length() < 1 || this.itemInterface.getWeight().length() > this.MAXWEIGHT) {
                return false;
            }
            if (this.itemInterface.getWeight() != null && !stringValidationUtil.isNumber(this.itemInterface.getWeight())) {
                return false;
            }
            if (this.itemInterface.getEnabled() == null || this.itemInterface.getEnabled().length() < 1 || this.itemInterface.getEnabled().length() > AbSqlData.MAXSTRING) {
                return false;
            }
            if (this.itemInterface.getNewOrUsed() == null || this.itemInterface.getNewOrUsed().length() < 1 || this.itemInterface.getNewOrUsed().length() > AbSqlData.MAXSTRING) {
                return false;
            }
            if (this.itemInterface.getSummary() == null || this.itemInterface.getSummary().length() < 1 || this.itemInterface.getSummary().length() > AbSqlData.MAXSTRING) {
                return false;
            }
            if (this.itemInterface.getDescription() == null || this.itemInterface.getDescription().length() < 1 || this.itemInterface.getDescription().length() > AbSqlData.MAXBLOB) {
                return false;
            }
            if (this.itemInterface.getKeywords() == null || this.itemInterface.getKeywords().length() < 1 || this.itemInterface.getKeywords().length() > AbSqlData.MAXSTRING) {
                return false;
            }
            if (this.itemInterface.getCategory() == null || this.itemInterface.getCategory().length() < 1 || this.itemInterface.getCategory().length() > AbSqlData.MAXSTRING) {
                return false;
            }
            if (this.itemInterface.getType() == null || this.itemInterface.getType().length() < 1 || this.itemInterface.getType().length() > AbSqlData.MAXSTRING) {
                return false;
            }
            if (this.itemInterface.getPrice() == null || !this.itemInterface.getPrice().isValid()) {
                return false;
            }
            if (this.itemInterface.getCustoms() == null || this.itemInterface.getCustoms().length() < 1 || this.itemInterface.getCustoms().length() > AbSqlData.MAXNUM) {
                return false;
            }
            if (this.itemInterface.getDownloads() == null || this.itemInterface.getDownloads().length() < 1 || this.itemInterface.getDownloads().length() > AbSqlData.MAXNUM) {
                return false;
            }
            if (this.itemInterface.getGroups() == null || this.itemInterface.getGroups().length() < 1 || this.itemInterface.getGroups().length() > AbSqlData.MAXNUM) {
                return false;
            }
            if (this.itemInterface.getOptions() == null || this.itemInterface.getOptions().length() < 1 || this.itemInterface.getOptions().length() > AbSqlData.MAXNUM) {
                return false;
            }
            if (this.itemInterface.getPermissions() == null || this.itemInterface.getPermissions().length() < 1 || this.itemInterface.getPermissions().length() > AbSqlData.MAXNUM) {
                return false;
            }
            if (this.itemInterface.getSpecials() == null || this.itemInterface.getSpecials().length() < 1 || this.itemInterface.getSpecials().length() > AbSqlData.MAXNUM) {
                return false;
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
            if (this.itemInterface.getId() == null || this.itemInterface.getId().length() < 1 || this.itemInterface.getId().length() > AbSqlData.MAXNUM) {
                stringBuffer.append("Id is invalid. Must be number < " + AbSqlData.MAXNUM + " and > 0 digits.<br />");
            }
            StringValidationUtil stringValidationUtil = StringValidationUtil.getInstance();
            if (this.itemInterface.getId() != null && !stringValidationUtil.isNumber(this.itemInterface.getId())) {
                stringBuffer.append("Id is invalid. Must be > 0.<br />");
            }
            if (this.itemInterface.getNumber() == null || this.itemInterface.getNumber().length() < 1 || this.itemInterface.getNumber().length() > AbSqlData.MAXNUM) {
                stringBuffer.append("Number of items is invalid. Must be number < " + AbSqlData.MAXNUM + " and > 0 digits.<br />");
            }
            if (this.itemInterface.getNumber() != null && !stringValidationUtil.isNumber(this.itemInterface.getNumber())) {
                stringBuffer.append("Number of items value is not a valid number.<br />");
            }
            if (this.itemInterface.getInBaskets() == null || this.itemInterface.getInBaskets().length() < 1 || this.itemInterface.getInBaskets().length() > AbSqlData.MAXNUM) {
                stringBuffer.append("Number in baskets is invalid. Must be < " + AbSqlData.MAXNUM + " and > 0 digits.<br />");
            }
            if (this.itemInterface.getInBaskets() != null && !stringValidationUtil.isNumber(this.itemInterface.getInBaskets())) {
                stringBuffer.append("In Baskets value is not a valid number.<br />");
            }
            if (this.itemInterface.getWeight() == null || this.itemInterface.getWeight().length() < 1 || this.itemInterface.getWeight().length() > this.MAXWEIGHT) {
                stringBuffer.append("Weight value is invalid. Must be < " + this.MAXWEIGHT + " and > 0 digits.<br />");
            }
            if (this.itemInterface.getWeight() != null && !stringValidationUtil.isNumber(this.itemInterface.getWeight())) {
                stringBuffer.append("Weight value is not a valid number.<br />");
            }
            if (this.itemInterface.getEnabled() == null || this.itemInterface.getEnabled().length() < 1 || this.itemInterface.getEnabled().length() > AbSqlData.MAXSTRING) {
                stringBuffer.append("For Sale value is invalid. Must be < " + AbSqlData.MAXSTRING + " and > 0 characters long.<br />");
            }
            if (this.itemInterface.getNewOrUsed() == null || this.itemInterface.getNewOrUsed().length() < 1 || this.itemInterface.getNewOrUsed().length() > AbSqlData.MAXSTRING) {
                stringBuffer.append("New Or Used value is invalid. Must be < " + AbSqlData.MAXSTRING + " and > 0 characters long.<br />");
            }
            if (this.itemInterface.getSummary() == null || this.itemInterface.getSummary().length() < 1 || this.itemInterface.getSummary().length() > AbSqlData.MAXSTRING) {
                stringBuffer.append("Summary value is invalid. Must be < " + AbSqlData.MAXSTRING + " and > 0 characters long.<br />");
            }
            if (this.itemInterface.getDescription() == null || this.itemInterface.getDescription().length() < 1 || this.itemInterface.getDescription().length() > AbSqlData.MAXBLOB) {
                stringBuffer.append("Description value is invalid. Must be < " + AbSqlData.MAXBLOB + " and > 0 characters long.<br />");
            }
            if (this.itemInterface.getKeywords() == null || this.itemInterface.getKeywords().length() < 1 || this.itemInterface.getKeywords().length() > AbSqlData.MAXSTRING) {
                stringBuffer.append("Keywords value is invalid. Must be < " + AbSqlData.MAXSTRING + " and > 0 characters long.<br />");
            }
            if (this.itemInterface.getCategory() == null || this.itemInterface.getCategory().length() < 1 || this.itemInterface.getCategory().length() > AbSqlData.MAXSTRING) {
                stringBuffer.append("Category value is invalid. Must be < " + AbSqlData.MAXSTRING + " and > 0 characters long.<br />");
            }
            if (this.itemInterface.getType() == null || this.itemInterface.getType().length() < 1 || this.itemInterface.getType().length() > AbSqlData.MAXSTRING) {
                stringBuffer.append("Type value is invalid. Must be < " + AbSqlData.MAXSTRING + " and > 0 characters long.<br />");
            }
            if (this.itemInterface.getPrice() == null || !this.itemInterface.getPrice().isValid()) {
                stringBuffer.append("Price value is invalid. Must be < " + this.MAXPRICE + " and > 0 in length.<br />");
            }
            if (this.itemInterface.getCustoms() == null || this.itemInterface.getCustoms().length() < 1 || this.itemInterface.getCustoms().length() > AbSqlData.MAXNUM) {
                stringBuffer.append("Custom items value is invalid. Must be number < " + AbSqlData.MAXNUM + " and > 0 digits.<br />");
            }
            if (this.itemInterface.getDownloads() == null || this.itemInterface.getDownloads().length() < 1 || this.itemInterface.getDownloads().length() > AbSqlData.MAXNUM) {
                stringBuffer.append("Downloadable item value is invalid. Must be number < " + AbSqlData.MAXNUM + " and > 0 digits.<br />");
            }
            if (this.itemInterface.getGroups() == null || this.itemInterface.getGroups().length() < 1 || this.itemInterface.getGroups().length() > AbSqlData.MAXNUM) {
                stringBuffer.append("Group item value is invalid. Must be number < " + AbSqlData.MAXNUM + " and > 0 digits.<br />");
            }
            if (this.itemInterface.getOptions() == null || this.itemInterface.getOptions().length() < 1 || this.itemInterface.getOptions().length() > AbSqlData.MAXNUM) {
                stringBuffer.append("Option item value is invalid. Must be number < " + AbSqlData.MAXNUM + " and > 0 digits.<br />");
            }
            if (this.itemInterface.getPermissions() == null || this.itemInterface.getPermissions().length() < 1 || this.itemInterface.getPermissions().length() > AbSqlData.MAXNUM) {
                stringBuffer.append("Permission item value is invalid. Must be number < " + AbSqlData.MAXNUM + " and > 0 digits.<br />");
            }
            if (this.itemInterface.getSpecials() == null || this.itemInterface.getSpecials().length() < 1 || this.itemInterface.getSpecials().length() > AbSqlData.MAXNUM) {
                stringBuffer.append("Special item value is invalid. Must be number < " + AbSqlData.MAXNUM + " and > 0 digits.<br />");
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

