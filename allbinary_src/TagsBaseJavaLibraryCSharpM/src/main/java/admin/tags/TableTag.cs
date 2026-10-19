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
using SqlStrings = org.allbinary.logic.communication.sql.SqlStrings;
using BooleanUtil = org.allbinary.logic.java.@bool.BooleanUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringValidationUtil = org.allbinary.logic.@string.StringValidationUtil;
using LicensingException = org.allbinary.logic.system.security.licensing.LicensingException;
using PropertiesTag = tags.PropertiesTag;

namespace admin.tags;

public class TableTag : PropertiesTag
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private string enabled = null;
    private TagHelperFactoryInterface tagHelperFactoryInterface = null;
    private TagHelperFactoryInterface tagRequestHelperFactoryInterface = null;
    private object requestObject = null;
    private int? current = null;
    private int? total = null;
    public TableTag()
    {
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().JSPTAG)) {
            this.logUtil.putF(this.commonStrings.START, this, this.commonStrings.CONSTRUCTOR);
        }
    }

    public virtual void setIsSelected(string enabled)
    {
        this.enabled = enabled;
    }

    // throws Exception
    public virtual bool isEnabled()
    {
        if (!StringValidationUtil.getInstance().isEmpty(this.enabled)) {
            if (BooleanUtil.getInstance().getFromString(this.enabled) || string.CompareOrdinal(this.enabled, "on") == 0) {
                return true;
            }
        }
        return false;
    }

    protected virtual void setTagHelperFactory(TagHelperFactoryInterface tagHelperFactoryInterface)
    {
        this.tagHelperFactoryInterface = tagHelperFactoryInterface;
    }

    protected virtual TagHelperFactoryInterface getTagHelperFactoryInterface()
    {
        return this.tagHelperFactoryInterface;
    }

    protected virtual void setTagRequestHelperFactory(TagHelperFactoryInterface tagHelperFactoryInterface)
    {
        this.tagRequestHelperFactoryInterface = tagHelperFactoryInterface;
    }

    protected virtual TagHelperFactoryInterface getTagRequestHelperFactoryInterface()
    {
        return this.tagRequestHelperFactoryInterface;
    }

    public virtual void setCurrent(int? current)
    {
        this.current = current;
    }

    public virtual int? getCurrent()
    {
        return this.current;
    }

    public virtual void setTotal(int? total)
    {
        this.total = total;
    }

    public virtual int? getTotal()
    {
        return this.total;
    }

    // throws LicensingException
    public virtual string drop()
    {
        try {
            object anyType = this.getTagHelperFactoryInterface().getInstance(this.getPropertiesHashMap(), pageContext);
            Type addressHelperClass = anyType.GetType();
            Method method = addressHelperClass.getMethod("drop", null);
            string result = ((string) method.invoke(anyType, null));
            return result;
        } catch (Exception e) {
            string error = "Failed to drop table";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.DROP, e);
            }
            return error;
        }
    }

    // throws LicensingException
    public virtual string create()
    {
        try {
            object anyType = this.getTagHelperFactoryInterface().getInstance(this.getPropertiesHashMap(), pageContext);
            Type addressHelperClass = anyType.GetType();
            Method method = addressHelperClass.getMethod("create", null);
            string result = ((string) method.invoke(anyType, null));
            return result;
        } catch (Exception e) {
            string error = "Failed to create table";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "create()", e);
            }
            return error;
        }
    }

    // throws LicensingException
    public virtual string restore()
    {
        try {
            object anyType = this.getTagHelperFactoryInterface().getInstance(this.getPropertiesHashMap(), pageContext);
            Type addressHelperClass = anyType.GetType();
            Method method = addressHelperClass.getMethod("restore", null);
            string result = ((string) method.invoke(anyType, null));
            return result;
        } catch (Exception e) {
            string error = "Failed to restore backup";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "restore()", e);
            }
            return error;
        }
    }

    // throws LicensingException
    public virtual string backup()
    {
        try {
            object anyType = this.getTagHelperFactoryInterface().getInstance(this.getPropertiesHashMap(), pageContext);
            Type addressHelperClass = anyType.GetType();
            Method method = addressHelperClass.getMethod("backup", null);
            string result = ((string) method.invoke(anyType, null));
            return result;
        } catch (Exception e) {
            string error = "Failed to make backup";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "backup()", e);
            }
            return error;
        }
    }

    // throws LicensingException
    public virtual string insert()
    {
        try {
            Type helperClass = this.requestObject.GetType();
            Method method = helperClass.getMethod("insert", null);
            string result = ((string) method.invoke(this.requestObject, null));
            return result;
        } catch (Exception e) {
            string error = "Failed to insert";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "insert()", e);
            }
            return error;
        }
    }

    // throws LicensingException
    public virtual string delete()
    {
        try {
            Type helperClass = this.requestObject.GetType();
            Method method = helperClass.getMethod(commonStrings.delete, null);
            string result = ((string) method.invoke(this.requestObject, null));
            return result;
        } catch (Exception e) {
            string error = "Failed to delete";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "delete()", e);
            }
            return error;
        }
    }

    // throws LicensingException
    public virtual string update()
    {
        try {
            Type helperClass = this.requestObject.GetType();
            Method method = helperClass.getMethod("update", null);
            string result = ((string) method.invoke(this.requestObject, null));
            return result;
        } catch (Exception e) {
            string error = "Failed to update";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "update()", e);
            }
            return error;
        }
    }

    // throws JspTagException
    public virtual int doStartTag()
    {
        try {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().JSPTAG)) {
                HttpServletRequest request = ((HttpServletRequest) this.pageContext.getRequest());
                StringMaker stringBuffer = new StringMaker();
                stringBuffer.append("TableTag Helper: ");
                stringBuffer.append(this.getTagHelperFactoryInterface().GetType().FullName);
                stringBuffer.append(" Request URI: ");
                stringBuffer.append(request.getRequestURI());
                this.logUtil.putF(stringBuffer.ToString(), this, this.tagStrings.DO_START_TAG);
            }
            if (this.getTagRequestHelperFactoryInterface() != null) {
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().JSPTAG)) {
                    this.logUtil.putF("TableTag RequestHelper: " + this.getTagRequestHelperFactoryInterface().GetType().FullName, this, this.tagStrings.DO_START_TAG);
                }
            } else {
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().JSPTAG)) {
                    this.logUtil.putF("TableTag RequestHelper: null", this, this.tagStrings.DO_START_TAG);
                }
            }
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().JSPTAG)) {
                this.logUtil.putF("TableTag this.getCommand(): " + this.getCommand(), this, tagStrings.DO_START_TAG);
            }
            if (this.isEnabled()) {
                if (this.getCommand() != null) {
                    if (this.getCommand().compareTo(this.commonStrings.INSERT) == 0 || this.getCommand().compareTo(SqlStrings.getInstance().INSERT_INTO) == 0 || this.getCommand().compareTo(commonStrings.DELETE) == 0 || this.getCommand().compareTo(commonStrings.UPDATE) == 0 || this.getCommand().compareTo(SqlStrings.getInstance().UPDATE) == 0) {
                        this.requestObject = this.getTagRequestHelperFactoryInterface().getInstance(this.getPropertiesHashMap(), pageContext);
                    }
                    if (this.getCommand().compareTo(this.commonStrings.INSERT) == 0 || this.getCommand().compareTo(SqlStrings.getInstance().INSERT_INTO) == 0) {
                        this.insert();
                    } else if (this.getCommand().compareTo(commonStrings.DELETE) == 0) {
                        this.delete();
                    } else if (this.getCommand().compareTo(commonStrings.UPDATE) == 0 || this.getCommand().compareTo(SqlStrings.getInstance().UPDATE) == 0) {
                        this.update();
                    }
                    if (this.getCommand().compareTo(org.allbinary.globals.GLOBALS2.BACKUP) == 0) {
                        string output = this.backup();
                        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().JSPTAGEXTRAOUTPUT)) {
                            this.pageContext.getOut().print(output + "<br />");
                        }
                        return SKIP_BODY;
                    } else if (this.getCommand().compareTo(org.allbinary.globals.GLOBALS2.RESTORE) == 0) {
                        this.getPropertiesHashMap().put("current", this.getCurrent());
                        this.getPropertiesHashMap().put("total", this.getTotal());
                        string output = this.restore();
                        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().JSPTAGEXTRAOUTPUT)) {
                            this.pageContext.getOut().print(output + "<br />");
                        }
                        return SKIP_BODY;
                    } else if (this.getCommand().compareTo(commonStrings.DROP) == 0) {
                        string output = this.drop();
                        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().JSPTAGEXTRAOUTPUT)) {
                            this.pageContext.getOut().print(output + "<br />");
                        }
                        return SKIP_BODY;
                    } else if (this.getCommand().compareTo(commonStrings.CREATE) == 0) {
                        string output = this.create();
                        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().JSPTAGEXTRAOUTPUT)) {
                            this.pageContext.getOut().print(output + "<br />");
                        }
                        return SKIP_BODY;
                    } else if (this.getCommand().compareTo(commonStrings.INSERT) == 0) {
                        string output = this.insert();
                        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().JSPTAGEXTRAOUTPUT)) {
                            this.pageContext.getOut().print(output + "<br />");
                        }
                    } else if (this.getCommand().compareTo(commonStrings.DELETE) == 0) {
                        string output = this.delete();
                        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().JSPTAGEXTRAOUTPUT)) {
                            this.pageContext.getOut().print(output + "<br />");
                        }
                    } else if (this.getCommand().compareTo(commonStrings.UPDATE) == 0) {
                        string output = this.update();
                        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().JSPTAGEXTRAOUTPUT)) {
                            this.pageContext.getOut().print(output + "<br />");
                        }
                    }
                }
            }
            return EVAL_BODY_INCLUDE;
        } catch (LicensingException e) {
            AbResponseHandler.sendJspTagLicensingRedirect(this.pageContext, e);
            return SKIP_BODY;
        } catch (Exception e) {
            AbResponseHandler.sendJspTagRedirect(this.pageContext, e);
            return SKIP_BODY;
        }
    }

}

