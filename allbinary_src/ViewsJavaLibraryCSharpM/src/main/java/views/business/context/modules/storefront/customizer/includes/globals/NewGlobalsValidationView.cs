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
using DomNodeInterface = org.allbinary.data.tree.dom.DomNodeInterface;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using ValidationComponentInterface = org.allbinary.logic.control.validate.ValidationComponentInterface;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using TransformInfoInterface = org.allbinary.logic.visual.transform.info.TransformInfoInterface;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;
using CustomizerUtil = views.business.context.modules.storefront.customizer.CustomizerUtil;
using LogConfigTypeFactory = org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory;
using LogConfigTypes = org.allbinary.logic.communication.log.config.type.LogConfigTypes;
using ValidationOnlyTempUtil = views.ValidationOnlyTempUtil;

namespace views.business.context.modules.storefront.customizer.includes.globals;

public class NewGlobalsValidationView : GlobalsView, ValidationComponentInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public NewGlobalsValidationView(TransformInfoInterface transformInfoInterface) : base(transformInfoInterface)
    {
        // base(transformInfoInterface) is called from the constructor declaration
    }

    // throws Exception
    public override Document toXmlDoc()
    {
        return null;
    }

    public virtual bool? isValid()
    {
        try {
            {
                CustomizerUtil.getInstance().insert(this.getTransformInfoInterface(), ((DomNodeInterface) this));
            }
            return true;
        } catch (Exception e) {
            if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().VIEWERROR)) {
                this.logUtil.put("Failed to validate", this, this.commonStrings.IS_VALID, e);
            }
            return false;
        }
    }

    public virtual string validationInfo()
    {
        try {
            StringMaker stringBuffer = new StringMaker();
            return stringBuffer.ToString();
        } catch (Exception e) {
            if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().VIEWERROR)) {
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
    public override string view()
    {
        return ValidationOnlyTempUtil.getInstance().view(this);
    }

    // throws Exception
    public override TransformInfoInterface getTransformInfoInterface()
    {
        return base.getTransformInfoInterface();
    }

}

