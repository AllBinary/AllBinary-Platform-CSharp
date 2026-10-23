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
using TransformInfoEntity = org.allbinary.data.tables.transform.info.TransformInfoEntity;
using TransformInfoEntityBuilder = org.allbinary.data.tables.transform.info.TransformInfoEntityBuilder;
using DomDocumentHelper = org.allbinary.data.tree.dom.document.DomDocumentHelper;
using XmlDocumentHelper = org.allbinary.data.tree.dom.document.XmlDocumentHelper;
using StdUtil = org.allbinary.logic.StdUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using ValidationComponentInterface = org.allbinary.logic.control.validate.ValidationComponentInterface;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using TransformInfo = org.allbinary.logic.visual.transform.info.TransformInfo;
using TransformInfoHttpInterface = org.allbinary.logic.visual.transform.info.TransformInfoHttpInterface;
using TransformInfoInterface = org.allbinary.logic.visual.transform.info.TransformInfoInterface;
using TransformInfoObjectConfigInterface = org.allbinary.logic.visual.transform.info.objectConfig.TransformInfoObjectConfigInterface;
using PageValidation = org.allbinary.logic.visual.transform.template.customizer.page.PageValidation;
using TitleData = org.allbinary.logic.visual.transform.template.customizer.widgets.title.TitleData;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;
using CustomizerUtil = views.business.context.modules.storefront.customizer.CustomizerUtil;

namespace views.business.context.modules.storefront.customizer.generic.page;

public class PageValidationView : PageView, ValidationComponentInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public PageValidationView(TransformInfoInterface transformInfoInterface) : base(transformInfoInterface)
    {
        // base(transformInfoInterface) is called from the constructor declaration
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
            this.logUtil.putF("View Name: " + transformInfoInterface.getName(), this, "PageViewValidation()");
        }
    }

    public virtual bool? isValid()
    {
        try {
            bool? isValid = true;
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                this.logUtil.putF(this.commonStrings.START, this, this.commonStrings.IS_VALID);
            }
            TransformInfoEntity transformInfoEntityInterface = TransformInfoEntityBuilder.getInstance();
            TransformInfoObjectConfigInterface pageObjectConfigInterface = this.getTransformInfoInterface().getObjectConfigInterface();
            BasicArrayList allViewsToBeModifiedVector = pageObjectConfigInterface.getGroupTransforms();
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                this.logUtil.putF("Views To Be Modified: " + allViewsToBeModifiedVector.size(), this, "get(transformInfoInterface)");
            }
            int size = allViewsToBeModifiedVector.size();
            for (int index = 0; index < size; index++) {
                TransformInfo transformInfoInterface = ((TransformInfo) allViewsToBeModifiedVector.get(index));
                string viewNameOfViewToBeModified = transformInfoInterface.getName();
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                    StringMaker stringBuffer = new StringMaker();
                    stringBuffer.append(this.getTransformInfoInterface().getName());
                    stringBuffer.append(" is modifying view: ");
                    stringBuffer.append(viewNameOfViewToBeModified);
                    this.logUtil.putF(stringBuffer.ToString(), this, "insert()");
                }
                TransformInfoHttpInterface httpTransformInfoInterface = ((TransformInfoHttpInterface) this.getTransformInfoInterface());
                TransformInfoInterface specifiedTransformInfoInterface = transformInfoEntityInterface.get(viewNameOfViewToBeModified, httpTransformInfoInterface.getPropertiesHashMap(), httpTransformInfoInterface.getPageContext());
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                    StringMaker stringBuffer = new StringMaker();
                    stringBuffer.append(this.getTransformInfoInterface().getName());
                    stringBuffer.append(" is adding data to view: ");
                    stringBuffer.append(viewNameOfViewToBeModified);
                    this.logUtil.putF(stringBuffer.ToString(), this, "insert()");
                }
                HashMap<object, object> hashMap = StdUtil.getInstance().createHashMap();
                string title = specifiedTransformInfoInterface.getName().Substring(this.getTransformInfoInterface().getStoreName().length());
                if (string.CompareOrdinal(title, "index") == 0) {
                    hashMap.put(TitleData.getInstance().TEXT, this.getTransformInfoInterface().getStoreName() + " - Home Page");
                } else {
                    hashMap.put(TitleData.getInstance().TEXT, this.getTransformInfoInterface().getStoreName() + " -" + title);
                }
                PageValidation pageValidation = new PageValidation(hashMap);
                if (pageValidation.isValid() == false) {
                    isValid = false;
                }
                if (isValid == true) {
                    Document document = DomDocumentHelper.create();
                    document.appendChild(pageValidation.toXmlNode(document));
                    string documentString = XmlDocumentHelper.toString(document);
                    if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                        StringMaker stringBuffer = new StringMaker();
                        stringBuffer.append(viewNameOfViewToBeModified);
                        stringBuffer.append(" is changing data in ");
                        stringBuffer.append(specifiedTransformInfoInterface.getDataFilePath().ToString());
                        stringBuffer.append(" to the following data:\n");
                        stringBuffer.append(documentString);
                        this.logUtil.putF(stringBuffer.ToString(), this, this.commonStrings.IS_VALID);
                    }
                    CustomizerUtil.getInstance().write(specifiedTransformInfoInterface, documentString);
                }
            }
            return isValid;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEWERROR)) {
                this.logUtil.put("Failed to validate", this, this.commonStrings.IS_VALID, e);
            }
            return false;
        }
    }

    public virtual string validationInfo()
    {
        try {
            StringMaker stringBuffer = new StringMaker();
            TransformInfoEntity transformInfoEntityInterface = TransformInfoEntityBuilder.getInstance();
            TransformInfoObjectConfigInterface objectConfig = this.getTransformInfoInterface().getObjectConfigInterface();
            TransformInfoHttpInterface httpTransformInfoInterface = ((TransformInfoHttpInterface) this.getTransformInfoInterface());
            BasicArrayList allViewsToBeModifiedVector = objectConfig.getGroupTransforms();
            int size = allViewsToBeModifiedVector.size();
            for (int index = 0; index < size; index++) {
                TransformInfo transformInfoInterface = ((TransformInfo) allViewsToBeModifiedVector.get(index));
                string viewNameOfViewToBeModified = transformInfoInterface.getName();
                TransformInfoInterface specifiedTransformInfoInterface = transformInfoEntityInterface.get(viewNameOfViewToBeModified, httpTransformInfoInterface.getPropertiesHashMap(), httpTransformInfoInterface.getPageContext());
                HashMap<object, object> hashMap = StdUtil.getInstance().createHashMap();
                string title = specifiedTransformInfoInterface.getName().Substring(this.getTransformInfoInterface().getStoreName().length());
                if (string.CompareOrdinal(title, "index") == 0) {
                    hashMap.put(TitleData.getInstance().TEXT, this.getTransformInfoInterface().getStoreName() + " - Home Page");
                } else {
                    hashMap.put(TitleData.getInstance().TEXT, this.getTransformInfoInterface().getStoreName() + " -" + title);
                }
                PageValidation pageValidation = new PageValidation(hashMap);
                if (pageValidation.isValid() == false) {
                    stringBuffer.append("TransformInfo Name for PageValidation:" + specifiedTransformInfoInterface.getName());
                    stringBuffer.append("PageValidation:" + hashMap);
                    stringBuffer.append("PageValidation Info:" + pageValidation.validationInfo());
                }
            }
            return stringBuffer.ToString();
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEWERROR)) {
                this.logUtil.put("Failed to generate validation error info", this, "validationInfo()", e);
            }
            return "An auto generated page name was invalid.";
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

