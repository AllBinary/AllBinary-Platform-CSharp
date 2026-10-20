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
using DomNodeInterface = org.allbinary.data.tree.dom.DomNodeInterface;
using DomSearchHelper = org.allbinary.data.tree.dom.DomSearchHelper;
using ModDomHelper = org.allbinary.data.tree.dom.ModDomHelper;
using StdUtil = org.allbinary.logic.StdUtil;
using HttpRequestUtil = org.allbinary.logic.communication.http.request.HttpRequestUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using Validation = org.allbinary.logic.control.validate.Validation;
using FileData = org.allbinary.logic.io.file.FileData;
using AbPath = org.allbinary.logic.io.path.AbPath;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using StringValidationUtil = org.allbinary.logic.@string.StringValidationUtil;
using FileItem = org.apache.commons.fileupload.FileItem;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;

namespace org.allbinary.logic.visual.transform.template.customizer.widgets.logo;

public class LogoValidation : Validation, DomNodeInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private FileItem logoFileItem = null;
    private AbPath logoAbPath;
    private string logoFile;
    private bool isFile;
    public LogoValidation()
    {
        this.isFile = false;
        this.logoAbPath = null;
        this.logoFile = null;
    }

    public LogoValidation(Node node)
    {
        this.isFile = false;
        this.logoAbPath = new AbPath(DomSearchHelper.getNode(LogoData.getInstance().IMAGEPATH, node.getChildNodes()).getNodeValue(), StringUtil.getInstance().EMPTY_STRING);
        this.logoFile = DomSearchHelper.getNode(LogoData.getInstance().IMAGEFILENAME, node.getChildNodes()).getNodeValue();
    }

    public LogoValidation(HashMap<object, object> hashMap)
    {
        this.isFile = true;
        this.getFormData(hashMap);
    }

    // throws Exception
    public virtual void getFormData(HashMap<object, object> hashMap)
    {
        this.logoFileItem = ((FileItem) hashMap.get(LogoData.getInstance().IMAGE));
        this.logoAbPath = new AbPath(((string) hashMap.get(LogoData.getInstance().IMAGEPATH)), StringUtil.getInstance().EMPTY_STRING);
        if (this.logoFileItem != null) {
            this.logoFile = HttpRequestUtil.getInstance().generateFileName(this.logoFileItem.getName());
        }
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
            StringMaker stringBuffer = new StringMaker();
            stringBuffer.append("HashMap: ");
            stringBuffer.append(hashMap.ToString());
            stringBuffer.append("\nLogoFileName: ");
            stringBuffer.append(this.logoFile);
            this.logUtil.putF(stringBuffer.ToString(), this, "getFormData()");
        }
    }

    public virtual bool? isValid()
    {
        try {
            bool? valid = true;
            FileData fileData = FileData.getInstance();
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                this.logUtil.putF("LogoValidation", this, this.commonStrings.IS_VALID);
            }
            if (!StringValidationUtil.getInstance().isValidRequired(this.logoAbPath.ToString(), 0, 512)) {
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                    this.logUtil.putF("logoPath is invalid: " + this.logoAbPath.ToString(), this, this.commonStrings.IS_VALID);
                }
                return false;
            }
            if (!StringValidationUtil.getInstance().isValidRequired(this.logoFile, fileData.MINLEN, fileData.MAXLEN)) {
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                    this.logUtil.putF("logoFile is invalid: " + this.logoFile, this, this.commonStrings.IS_VALID);
                }
                return false;
            }
            if (this.isFile) {
                if (this.logoFileItem == null) {
                    return false;
                }
                if (this.logoFileItem.getSize() > fileData.MAXIMAGEFILESIZE || this.logoFileItem.getSize() < fileData.MINIMAGEFILESIZE) {
                    if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                        this.logUtil.putF("Image File Is Not The Right Size. " + fileData.MINIMAGEFILESIZE + "< > " + fileData.MAXIMAGEFILESIZE, this, this.commonStrings.IS_VALID);
                    }
                    return false;
                }
            }
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                this.logUtil.putF("Logo Validation: " + valid, this, this.commonStrings.IS_VALID);
            }
            return valid;
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
            stringBuffer.append("Logo is not valid.");
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

    public virtual HashMap<object, object> toHashMap()
    {
        StringUtil stringUtil = StringUtil.getInstance();
        HashMap<object, object> hashMap = StdUtil.getInstance().createHashMap();
        hashMap.put(LogoData.getInstance().IMAGE, stringUtil.EMPTY_STRING);
        if (this.logoFile != null) {
            hashMap.put(LogoData.getInstance().IMAGEPATH, this.logoAbPath.ToString());
            hashMap.put(LogoData.getInstance().IMAGEFILENAME, this.logoFile);
        } else {
            hashMap.put(LogoData.getInstance().IMAGEPATH, null);
            hashMap.put(LogoData.getInstance().IMAGEFILENAME, this.logoFile);
        }
        return hashMap;
    }

    // throws Exception
    public virtual Node toXmlNode(Document document)
    {
        HashMap<object, object> hashMap = this.toHashMap();
        return ModDomHelper.createNameValueNodes(document, LogoData.getInstance().NAME, hashMap);
    }

    // throws Exception
    public virtual void processLogoFile()
    {
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
            StringMaker stringBuffer = new StringMaker();
            stringBuffer.append("Processing logoFile: ");
            stringBuffer.append(this.logoAbPath.ToString());
            stringBuffer.append(this.logoFile);
            this.logUtil.putF(stringBuffer.ToString(), this, "processLogoFile()");
        }
        new LogoImageFileUtil(this.logoAbPath, this.logoFile).saveFiles(this.logoFileItem);
    }

}

