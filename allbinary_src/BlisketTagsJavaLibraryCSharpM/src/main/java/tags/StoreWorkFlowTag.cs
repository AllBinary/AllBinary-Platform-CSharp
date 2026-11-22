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
//using JspTagException = javax.servlet.jsp.JspTagException;
using AbResponseHandler = org.allbinary.logic.communication.http.request.AbResponseHandler;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using LicensingException = org.allbinary.logic.system.security.licensing.LicensingException;
using TransformInfoData = org.allbinary.logic.visual.transform.info.TransformInfoData;
using StoreTagWorkFlowHelperFactory = taghelpers.StoreTagWorkFlowHelperFactory;
using LogConfigTypeFactory = org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory;
using LogConfigTypes = org.allbinary.logic.communication.log.config.type.LogConfigTypes;

namespace tags;

//and hidden field removal
public class StoreWorkFlowTag : HelperTag
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private string viewName = null;
    private string viewFile = null;
    public StoreWorkFlowTag() : base(new StoreTagWorkFlowHelperFactory())
    {
        // Constructor invocation emitted in the initializer.
        if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().JSPTAG)) {
            this.logUtil.putF(this.commonStrings.START, this, this.commonStrings.CONSTRUCTOR);
        }
    }

    public virtual void setName(string value)
    {
        this.viewName = value;
        this.getPropertiesHashMap().put(TransformInfoData.getInstance().NAME, this.viewName);
    }

    // throws Exception
    private int process()
    {
        try {
            if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().JSPTAG)) {
                this.logUtil.putF(this.commonStrings.START, this, this.commonStrings.PROCESS);
            }
            Type helperClass = this.getHelper().GetType();
            global::System.Reflection.MethodInfo method = helperClass.getMethod(commonStrings.PROCESS, null);
            int? result = ((int?) method.invoke(this.getHelper(), null));
            return ((int) result);
        } catch (Exception e) {
            if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.PROCESS, e);
            }
            throw e;
        }
    }

    // throws JspTagException
    public virtual int doStartTag()
    {
        try {
            if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().JSPTAG)) {
                this.logUtil.putF(this.commonStrings.START, this, tagStrings.DO_START_TAG);
            }
            this.setHelper();
            return this.process();
        } catch (LicensingException e) {
            AbResponseHandler.sendJspTagLicensingRedirect(this.pageContext, e);
            return SKIP_BODY;
        } catch (Exception e) {
            AbResponseHandler.sendJspTagRedirect(this.pageContext, e);
            return SKIP_BODY;
        }
    }

}

