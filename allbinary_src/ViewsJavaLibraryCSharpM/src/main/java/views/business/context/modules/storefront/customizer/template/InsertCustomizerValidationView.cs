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
using TransformInfoEntityBuilder = org.allbinary.data.tables.transform.info.TransformInfoEntityBuilder;
using RequestParams = org.allbinary.logic.communication.http.request.RequestParams;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using ValidationComponentInterface = org.allbinary.logic.control.validate.ValidationComponentInterface;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringValidationUtil = org.allbinary.logic.@string.StringValidationUtil;
using TransformFactory = org.allbinary.logic.visual.transform.TransformFactory;
using TransformInterface = org.allbinary.logic.visual.transform.TransformInterface;
using GeneratorTransformInfoData = org.allbinary.logic.visual.transform.info.GeneratorTransformInfoData;
using TransformInfo = org.allbinary.logic.visual.transform.info.TransformInfo;
using TransformInfoData = org.allbinary.logic.visual.transform.info.TransformInfoData;
using TransformInfoInterface = org.allbinary.logic.visual.transform.info.TransformInfoInterface;
using TransformInfosData = org.allbinary.logic.visual.transform.info.TransformInfosData;
using CommonSeps = org.allbinary.@string.CommonSeps;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;
using HttpStoreComponentView = views.business.context.modules.storefront.HttpStoreComponentView;
using InsertTemplateCustomizerTransformInfoObjectConfig = views.business.context.modules.storefront.customizer.template.objectConfig.InsertTemplateCustomizerTransformInfoObjectConfig;
using NoTemplateTransformInfoObjectConfig = views.business.context.modules.storefront.customizer.template.objectConfig.NoTemplateTransformInfoObjectConfig;

namespace views.business.context.modules.storefront.customizer.template;

//Sets Template Type
public class InsertCustomizerValidationView : HttpStoreComponentView, ValidationComponentInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private string viewName;
    public InsertCustomizerValidationView(TransformInfoInterface transformInfoInterface) : base(transformInfoInterface)
    {
        // base(transformInfoInterface) is called from the constructor declaration
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
            this.logUtil.putF("View Name: " + transformInfoInterface.getName(), this, this.commonStrings.CONSTRUCTOR);
        }
        HashMap requestHashMap = new RequestParams(this.getPageContext()).toHashMap();
        this.viewName = ((string) requestHashMap.get(TransformInfoData.getInstance().NAME));
    }

    public virtual bool? isValid()
    {
        try {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                this.logUtil.putF("Started Validation", this, this.commonStrings.IS_VALID);
            }
            bool? isValid = true;
            if (StringValidationUtil.getInstance().isEmpty(this.viewName)) {
                isValid = false;
            } else {
                NoTemplateTransformInfoObjectConfig objectConfig = new NoTemplateTransformInfoObjectConfig(this.getTransformInfoInterface(), this.getTransformInfoInterface().getObjectConfigInterface().toXmlDoc());
                BasicArrayList componentVector = objectConfig.getGroupTransforms();
                int size = componentVector.size();
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                    StringMaker stringBuffer = new StringMaker();
                    stringBuffer.append("Pointing ");
                    stringBuffer.appendint(componentVector.size());
                    stringBuffer.append(" Components");
                    this.logUtil.putF(stringBuffer.ToString(), this, this.commonStrings.IS_VALID);
                }
                for (int index = 0; index < size; index++) {
                    TransformInfo transformInfo = ((TransformInfo) componentVector.get(index));
                    string transformInfoName = transformInfo.getName();
                    if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                        this.logUtil.putF("Setting Template Component with ViewName: " + transformInfoName, this, this.commonStrings.IS_VALID);
                    }
                    TransformInterface componentInterface = TransformFactory.getInstance().getInstance(this.abeClientInformation, transformInfoName, this.getTransformInfoInterface());
                    InsertTemplateCustomizerTransformInfoObjectConfig templateViewObjectConfig = new InsertTemplateCustomizerTransformInfoObjectConfig(componentInterface.getTransformInfoInterface(), componentInterface.getTransformInfoInterface().getObjectConfigInterface().toXmlDoc());
                    string storeName = this.getTransformInfoInterface().getStoreName();
                    int endIndex = this.viewName.IndexOf(storeName) + storeName.Length;
                    string storePrepend = this.viewName.Substring(0, (endIndex) - (0));
                    string viewNamePostfix = this.viewName.Substring(endIndex, (this.viewName.Length) - (endIndex));
                    StringMaker newViewNameStringBuffer = new StringMaker();
                    newViewNameStringBuffer.append(storePrepend);
                    CommonSeps commonSeps = CommonSeps.getInstance();
                    TransformInfosData transformInfosData = TransformInfosData.getInstance();
                    if (transformInfoName.IndexOf(transformInfosData.SMALL_PREVIEW) >= 0) {
                        newViewNameStringBuffer.append(commonSeps.SPACE);
                        newViewNameStringBuffer.append(transformInfosData.SMALL_PREVIEW);
                    } else if (transformInfoName.IndexOf(transformInfosData.PREVIEW) >= 0) {
                        newViewNameStringBuffer.append(commonSeps.SPACE);
                        newViewNameStringBuffer.append(transformInfosData.PREVIEW);
                    }
                    newViewNameStringBuffer.append(commonSeps.SPACE);
                    newViewNameStringBuffer.append(viewNamePostfix);
                    if (transformInfoName.IndexOf(GeneratorTransformInfoData.NAME) >= 0) {
                        newViewNameStringBuffer.append(commonSeps.SPACE);
                        newViewNameStringBuffer.append(GeneratorTransformInfoData.NAME);
                    }
                    string newViewName = newViewNameStringBuffer.ToString();
                    if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                        StringMaker stringBuffer = new StringMaker();
                        stringBuffer.append("Template Component: ");
                        stringBuffer.append(transformInfoName);
                        stringBuffer.append("\n Now Pointing To View Name: ");
                        stringBuffer.append(newViewName);
                        this.logUtil.putF(stringBuffer.ToString(), this, this.commonStrings.IS_VALID);
                    }
                    templateViewObjectConfig.set(newViewName);
                    if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                        StringMaker stringBuffer = new StringMaker();
                        stringBuffer.append("Template Component: ");
                        stringBuffer.append(transformInfoName);
                        stringBuffer.append("\n with ObjectConfig: ");
                        stringBuffer.append(templateViewObjectConfig.ToString());
                        this.logUtil.putF(stringBuffer.ToString(), this, this.commonStrings.IS_VALID);
                    }
                    componentInterface.getTransformInfoInterface().setObjectConfigInterface(templateViewObjectConfig);
                    HashMap updatedTransformInfoHashMap = componentInterface.getTransformInfoInterface().toHashMap();
                    TransformInfoEntityBuilder.getInstance().update(updatedTransformInfoHashMap);
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
            stringBuffer.append("Error: Template Name Is Empty.");
            return stringBuffer.ToString();
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEWERROR)) {
                this.logUtil.put("Failed to generate validation error info", this, "validationInfo()", e);
            }
            return "Error Getting Validation Info";
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
    public virtual string view()
    {
        return views.ValidationOnlyTempUtil.getInstance().view(this);
    }

}

