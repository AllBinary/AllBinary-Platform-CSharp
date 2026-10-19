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
using DomNodeInterface = org.allbinary.data.tree.dom.DomNodeInterface;
using URLGLOBALS = org.allbinary.globals.URLGLOBALS;
using MultipartRequestParams = org.allbinary.logic.communication.http.request.MultipartRequestParams;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using ValidationComponentInterface = org.allbinary.logic.control.validate.ValidationComponentInterface;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using TransformInfoInterface = org.allbinary.logic.visual.transform.info.TransformInfoInterface;
using HeadingValidation = org.allbinary.logic.visual.transform.template.customizer.hedges.heading.HeadingValidation;
using LogoData = org.allbinary.logic.visual.transform.template.customizer.widgets.logo.LogoData;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;
using CustomizerUtil = views.business.context.modules.storefront.customizer.CustomizerUtil;

namespace views.business.context.modules.storefront.customizer.hedges.header;

public class InsertHeaderValidationView : TopBarView, ValidationComponentInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly string LOGOPATH = "logo/";
    public InsertHeaderValidationView(TransformInfoInterface transformInfoInterface) : base(transformInfoInterface)
    {
        // base(transformInfoInterface) is called from the constructor declaration
        HashMap multipartRequestHashMap = new MultipartRequestParams(this.getPageContext()).toHashMap();
        StoreFrontInterface storeFrontInterface = StoreFrontFactory.getInstance(this.getWeblisketSession().getStoreName());
        string fullPath = URLGLOBALS.getWebappPath() + storeFrontInterface.getCurrentHostNamePath() + this.LOGOPATH;
        multipartRequestHashMap.put(LogoData.getInstance().IMAGEPATH, fullPath);
        this.heading = new HeadingValidation(multipartRequestHashMap);
    }

    // throws Exception
    public virtual Document toXmlDoc()
    {
        return null;
    }

    public virtual bool? isValid()
    {
        try {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                this.logUtil.putF("topbarValidation", this, this.commonStrings.IS_VALID);
            }
            bool? isValid = this.heading.isValid();
            if (isValid == true) {
                CustomizerUtil.getInstance().insert(this.getTransformInfoInterface(), ((DomNodeInterface) this));
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
            stringBuffer.append(this.heading.validationInfo());
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

}

