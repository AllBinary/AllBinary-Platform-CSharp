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
//using JspTagException = javax.servlet.jsp.JspTagException;
using TagHelperFactoryInterface = admin.taghelpers.TagHelperFactoryInterface;
using AbResponseHandler = org.allbinary.logic.communication.http.request.AbResponseHandler;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using LicensingException = org.allbinary.logic.system.security.licensing.LicensingException;
using ViewHelperFactory = taghelpers.ViewHelperFactory;
using TransformInfoTag = tags.transform.info.TransformInfoTag;

namespace tags;

public class TransformTag : TransformInfoTag
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public TransformTag() : base(new ViewHelperFactory())
    {
        // base(new ViewHelperFactory()) is called from the constructor declaration
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().JSPTAG)) {
            this.logUtil.putF(this.commonStrings.START, this, this.commonStrings.CONSTRUCTOR);
        }
    }

    public TransformTag(TagHelperFactoryInterface tagHelperFactoryInterface) : base(tagHelperFactoryInterface)
    {
        // base(tagHelperFactoryInterface) is called from the constructor declaration
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().JSPTAG)) {
            this.logUtil.putF(this.commonStrings.START, this, this.commonStrings.CONSTRUCTOR);
        }
    }

    // throws Exception
    public virtual string view()
    {
        try {
            string result = ((string) this.getHelper().GetType().getMethod("view", null).invoke(this.getHelper(), null));
            return result;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().JSPTAGERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "view()", e);
            }
            throw e;
        }
    }

    // throws JspTagException
    public virtual int doStartTag()
    {
        try {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().JSPTAG)) {
                this.logUtil.putF("Creating with: \n" + this.getPropertiesHashMap().ToString(), this, tagStrings.DO_START_TAG);
            }
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().JSPTAG)) {
                StringMaker stringBuffer = new StringMaker();
                stringBuffer.append("ViewTag Start For: ");
                stringBuffer.append(this.getName());
                stringBuffer.append("\nViewFile: ");
                stringBuffer.append(this.getObjectFile());
                this.logUtil.putF(stringBuffer.ToString(), this, tagStrings.DO_START_TAG);
            }
            this.setHelper();
            pageContext.getOut().print(this.view());
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().JSPTAG)) {
                this.logUtil.putF("Tag End", this, tagStrings.DO_START_TAG);
            }
            return SKIP_BODY;
        } catch (LicensingException e) {
            AbResponseHandler.sendJspTagLicensingRedirect(this.pageContext, e);
            return SKIP_BODY;
        } catch (Exception e) {
            AbResponseHandler.sendJspTagRedirect(this.pageContext, e);
            return SKIP_BODY;
        }
    }

}

