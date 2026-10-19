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
//using Method = java.lang.reflect.Method;
//using HttpServletRequest = javax.servlet.http.HttpServletRequest;
//using JspTagException = javax.servlet.jsp.JspTagException;
using AbResponseHandler = org.allbinary.logic.communication.http.request.AbResponseHandler;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using LicensingException = org.allbinary.logic.system.security.licensing.LicensingException;
using ValidatedViewHelperFactory = taghelpers.ValidatedViewHelperFactory;

namespace tags;

public class ValidationTransformTag : TransformTag
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private string xslFile = null;
    private bool logic;
    public ValidationTransformTag() : base(new ValidatedViewHelperFactory())
    {
        // base(new ValidatedViewHelperFactory()) is called from the constructor declaration
        this.logic = true;
    }

    public virtual void setXsl(string value)
    {
        this.xslFile = value;
        this.setTemplateFile(this.xslFile);
    }

    public virtual void setLogic(bool logic)
    {
        this.logic = logic;
    }

    // throws Exception
    private bool isValid()
    {
        try {
            Type helperClass = this.getHelper().GetType();
            Method method = helperClass.getMethod(commonStrings.IS_VALID, null);
            bool? result = ((bool?) method.invoke(this.getHelper(), null));
            return result;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.IS_VALID, e);
            }
            throw e;
        }
    }

    // throws Exception
    private string validationInfo()
    {
        try {
            Type addressHelperClass = this.getHelper().GetType();
            Method method = addressHelperClass.getMethod("validationInfo", null);
            string result = ((string) method.invoke(this.getHelper(), null));
            return result;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "validationInfo()", e);
            }
            throw e;
        }
    }

    // throws JspTagException
    public virtual int doStartTag()
    {
        try {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().JSPTAG)) {
                StringMaker stringBuffer = new StringMaker();
                HttpServletRequest request = ((HttpServletRequest) this.pageContext.getRequest());
                stringBuffer.append("ValidationViewTag Start For: ");
                stringBuffer.append(this.getName());
                stringBuffer.append("\nView FIle: ");
                stringBuffer.append(this.getObjectFile());
                stringBuffer.append("\nRequest URI: ");
                stringBuffer.append(request.getRequestURI());
                this.logUtil.putF(stringBuffer.ToString(), this, tagStrings.DO_START_TAG);
            }
            this.setHelper();
            if (this.isValid()) {
                base.doStartTag();
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().JSPTAG)) {
                    StringMaker stringBuffer = new StringMaker();
                    stringBuffer.append("View File: ");
                    stringBuffer.append(this.getObjectFile());
                    stringBuffer.append("\nLogic includes body if true=");
                    stringBuffer.appendboolean(this.logic);
                    this.logUtil.putF(stringBuffer.ToString(), this, tagStrings.DO_START_TAG);
                }
                if (this.logic) {
                    return EVAL_BODY_INCLUDE;
                } else {
                    return SKIP_BODY;
                }
            } else {
                pageContext.getOut().print(this.validationInfo());
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().JSPTAG)) {
                    StringMaker stringBuffer = new StringMaker();
                    stringBuffer.append("View File: ");
                    stringBuffer.append(this.getObjectFile());
                    stringBuffer.append("\nisValid()=false");
                    stringBuffer.append("\nLogic skips body if true=");
                    stringBuffer.appendboolean(this.logic);
                    this.logUtil.putF(stringBuffer.ToString(), this, tagStrings.DO_START_TAG);
                }
                if (this.logic) {
                    return SKIP_BODY;
                } else {
                    return EVAL_BODY_INCLUDE;
                }
            }
        } catch (LicensingException e) {
            AbResponseHandler.sendJspTagLicensingRedirect(this.pageContext, e);
            return SKIP_BODY;
        } catch (Exception e) {
            AbResponseHandler.sendJspTagRedirect(this.pageContext, e);
            return SKIP_BODY;
        }
    }

    public virtual int doEndTag()
    {
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().JSPTAG)) {
            this.logUtil.putF("Tag Ended", this, "doEndTag");
        }
        this.logic = true;
        return base.doEndTag();
    }

}

