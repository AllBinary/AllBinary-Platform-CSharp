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
using CategoryHelperFactory = admin.taghelpers.CategoryHelperFactory;
using CategoryRequestHelperFactory = admin.taghelpers.CategoryRequestHelperFactory;
using CategoryData = org.allbinary.business.category.CategoryData;
using AbResponseHandler = org.allbinary.logic.communication.http.request.AbResponseHandler;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using LicensingException = org.allbinary.logic.system.security.licensing.LicensingException;
using TransformInfoData = org.allbinary.logic.visual.transform.info.TransformInfoData;

namespace admin.tags;

public class CategoryTag : TableTag
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private string xsl = null;
    public CategoryTag()
    {
        this.setTagHelperFactory(new CategoryHelperFactory());
        this.setTagRequestHelperFactory(new CategoryRequestHelperFactory());
    }

    public virtual void setXsl(string value)
    {
        this.xsl = value;
    }

    // throws LicensingException
    private string viewCategory()
    {
        try {
            object anyType = new CategoryRequestHelperFactory().getInstance(this.getPropertiesHashMap(), this.pageContext);
            Type helperClass = anyType.GetType();
            Method method = helperClass.getMethod("viewCategory", null);
            string result = ((string) method.invoke(anyType, null));
            return result;
        } catch (LicensingException e) {
            throw e;
        } catch (Exception e) {
            string error = "Failed to view a Category";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "viewCategory()", e);
            }
            return error;
        }
    }

    // throws LicensingException
    private string viewCategories()
    {
        try {
            object anyType = new CategoryRequestHelperFactory().getInstance(this.getPropertiesHashMap(), this.pageContext);
            Type helperClass = anyType.GetType();
            Method method = helperClass.getMethod("viewCategories", null);
            string result = ((string) method.invoke(anyType, null));
            return result;
        } catch (LicensingException e) {
            throw e;
        } catch (Exception e) {
            string error = "Failed to view a Categories";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "viewCategories()", e);
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
                    this.getPropertiesHashMap().put(TransformInfoData.getInstance().TEMPLATEFILENAME, this.xsl);
                    if (this.getCommand().compareTo(CategoryData.getInstance().VIEW) == 0) {
                        string output = this.viewCategory();
                        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().JSPTAGEXTRAOUTPUT)) {
                            pageContext.getOut().print(output);
                        }
                    } else if (this.getCommand().compareTo(CategoryData.getInstance().VIEW) == 0) {
                        string output = this.viewCategories();
                        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().JSPTAGEXTRAOUTPUT)) {
                            pageContext.getOut().print(output);
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

