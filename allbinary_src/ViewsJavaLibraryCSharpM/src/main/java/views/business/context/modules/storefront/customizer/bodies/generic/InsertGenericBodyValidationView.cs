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
using RequestParams = org.allbinary.logic.communication.http.request.RequestParams;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using ValidationComponentInterface = org.allbinary.logic.control.validate.ValidationComponentInterface;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using TransformInfoInterface = org.allbinary.logic.visual.transform.info.TransformInfoInterface;
using GenericBodyValidation = org.allbinary.logic.visual.transform.template.customizer.bodies.GenericBodyValidation;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;
using CustomizerUtil = views.business.context.modules.storefront.customizer.CustomizerUtil;
using StoreCustomizerComponentUtil = views.business.context.modules.storefront.customizer.StoreCustomizerComponentUtil;

namespace views.business.context.modules.storefront.customizer.bodies.generic;

public class InsertGenericBodyValidationView : GenericBodyCustomizerView, ValidationComponentInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public InsertGenericBodyValidationView(TransformInfoInterface transformInfoInterface) : base(transformInfoInterface)
    {
        // base(transformInfoInterface) is called from the constructor declaration
        HashMap requestHashMap = new RequestParams(this.getPageContext()).toHashMap();
        this.body = new GenericBodyValidation(requestHashMap);
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
                this.logUtil.putF("Started Validation", this, this.commonStrings.IS_VALID);
            }
            bool? isValid = this.body.isValid();
            if (isValid == true) {
                CustomizerUtil.getInstance().insert(this.getTransformInfoInterface(), ((DomNodeInterface) this.body));
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
            stringBuffer.append(this.body.validationInfo());
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
        try {
            return StoreCustomizerComponentUtil.getInstance().generate(this.abeClientInformation, this.getTransformInfoInterface());
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().TAGHELPERERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "view()", e);
            }
            throw e;
        }
    }

}

