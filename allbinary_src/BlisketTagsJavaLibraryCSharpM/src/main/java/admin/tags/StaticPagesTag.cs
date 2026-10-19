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
using StaticPagesHelperFactory = admin.taghelpers.StaticPagesHelperFactory;
using StaticPagesRequestHelperFactory = admin.taghelpers.StaticPagesRequestHelperFactory;
using AbResponseHandler = org.allbinary.logic.communication.http.request.AbResponseHandler;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using SearchData = org.allbinary.logic.control.search.SearchData;
using LicensingException = org.allbinary.logic.system.security.licensing.LicensingException;
using TransformInfoData = org.allbinary.logic.visual.transform.info.TransformInfoData;

namespace admin.tags;

public class StaticPagesTag : TableTag
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private string xslFile = null;
    public StaticPagesTag()
    {
        this.setTagHelperFactory(new StaticPagesHelperFactory());
        this.setTagRequestHelperFactory(new StaticPagesRequestHelperFactory());
    }

    public virtual void setXsl(string value)
    {
        this.xslFile = value;
    }

    // throws LicensingException
    public virtual string generateStaticPages()
    {
        try {
            object anyType = new StaticPagesRequestHelperFactory().getInstance(this.getPropertiesHashMap(), this.pageContext);
            Type helperClass = anyType.GetType();
            Method method = helperClass.getMethod("generateStaticPages", null);
            string result = ((string) method.invoke(anyType, null));
            return result;
        } catch (LicensingException e) {
            throw e;
        } catch (Exception e) {
            string error = "Failed to generate staticpages table";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "generateStaticPages()", e);
            }
            return error;
        }
    }

    // throws LicensingException
    public virtual string makePublic()
    {
        try {
            object anyType = new StaticPagesRequestHelperFactory().getInstance(this.getPropertiesHashMap(), this.pageContext);
            Type helperClass = anyType.GetType();
            Method method = helperClass.getMethod("makePublic", null);
            string result = ((string) method.invoke(anyType, null));
            return result;
        } catch (LicensingException e) {
            throw e;
        } catch (Exception e) {
            string error = "Failed to makePublic";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "makePublic()", e);
            }
            return error;
        }
    }

    // throws JspTagException
    public virtual int doStartTag()
    {
        try {
            if (this.isEnabled()) {
                if (this.getCommand() != null) {
                    if (this.getCommand().compareTo(SearchData.GENERATESTATICPAGES) == 0) {
                        this.getPropertiesHashMap().put(TransformInfoData.getInstance().TEMPLATEFILENAME, this.xslFile);
                        string output = this.generateStaticPages();
                        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().JSPTAGEXTRAOUTPUT)) {
                            this.pageContext.getOut().print(output);
                        }
                    } else if (this.getCommand().compareTo(SearchData.MAKEPUBLIC) == 0) {
                        string output = this.makePublic();
                        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().JSPTAGEXTRAOUTPUT)) {
                            this.pageContext.getOut().print(output);
                        }
                    } else {
                        return base.doStartTag();
                    }
                }
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

