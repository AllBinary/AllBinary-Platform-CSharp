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
using TagHelperFactoryInterface = admin.taghelpers.TagHelperFactoryInterface;
using AbResponseHandler = org.allbinary.logic.communication.http.request.AbResponseHandler;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using LicensingException = org.allbinary.logic.system.security.licensing.LicensingException;
using CommonStrings = org.allbinary.@string.CommonStrings;
using LogConfigTypeFactory = org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory;
using LogConfigTypes = org.allbinary.logic.communication.log.config.type.LogConfigTypes;

namespace tags;

public class ModifyTag : HelperTag
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public ModifyTag(TagHelperFactoryInterface tagHelperFactoryInterface) : base(tagHelperFactoryInterface)
    {
        // Constructor invocation emitted in the initializer.
        if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().JSPTAG)) {
            this.logUtil.putF(this.commonStrings.START, this, this.commonStrings.CONSTRUCTOR);
        }
    }

    // throws LicensingException
    public virtual string insert()
    {
        try {
            Type helperClass = this.getHelper().GetType();
            global::System.Reflection.MethodInfo method = helperClass.getMethod("insert", null);
            string result = ((string) method.invoke(this.getHelper(), null));
            return result;
        } catch (Exception e) {
            string error = "Failed to insert";
            if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "insert()", e);
            }
            return error;
        }
    }

    // throws LicensingException
    public virtual string delete()
    {
        try {
            Type helperClass = this.getHelper().GetType();
            global::System.Reflection.MethodInfo method = helperClass.getMethod(commonStrings.delete, null);
            string result = ((string) method.invoke(this.getHelper(), null));
            return result;
        } catch (Exception e) {
            string error = "Failed to delete";
            if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "delete()", e);
            }
            return error;
        }
    }

    // throws LicensingException
    public virtual string update()
    {
        try {
            Type helperClass = this.getHelper().GetType();
            global::System.Reflection.MethodInfo method = helperClass.getMethod("update", null);
            string result = ((string) method.invoke(this.getHelper(), null));
            return result;
        } catch (Exception e) {
            string error = "Failed to update";
            if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "update()", e);
            }
            return error;
        }
    }

    // throws JspTagException
    public virtual int doStartTag()
    {
        try {
            if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().JSPTAG)) {
                HttpServletRequest request = ((HttpServletRequest) this.pageContext.getRequest());
                StringMaker stringBuffer = new StringMaker();
                stringBuffer.append("Command: ");
                stringBuffer.append(this.getCommand());
                stringBuffer.append(" Request URI: ");
                stringBuffer.append(request.getRequestURI());
                this.logUtil.putF(stringBuffer.ToString(), this, tagStrings.DO_START_TAG);
            }
            if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().JSPTAG)) {
            }
            if (this.getCommand() != null) {
                this.setHelper();
                CommonStrings commonStrings = CommonStrings.getInstance();
                if (this.getCommand().compareTo(commonStrings.INSERT) == 0) {
                    string output = this.insert();
                    if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().JSPTAGEXTRAOUTPUT)) {
                        this.pageContext.getOut().print(output + "<br />");
                    }
                } else if (this.getCommand().compareTo(commonStrings.DELETE) == 0) {
                    string output = this.delete();
                    if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().JSPTAGEXTRAOUTPUT)) {
                        this.pageContext.getOut().print(output + "<br />");
                    }
                } else if (this.getCommand().compareTo(commonStrings.UPDATE) == 0) {
                    string output = this.update();
                    if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().JSPTAGEXTRAOUTPUT)) {
                        this.pageContext.getOut().print(output + "<br />");
                    }
                }
            }
            return this.EVAL_BODY_INCLUDE;
        } catch (LicensingException e) {
            AbResponseHandler.sendJspTagLicensingRedirect(this.pageContext, e);
            return SKIP_BODY;
        } catch (Exception e) {
            AbResponseHandler.sendJspTagRedirect(this.pageContext, e);
            return SKIP_BODY;
        }
    }

}

