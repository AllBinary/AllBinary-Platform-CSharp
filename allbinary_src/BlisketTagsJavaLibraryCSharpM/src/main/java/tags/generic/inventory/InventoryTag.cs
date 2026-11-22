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
using InventoryHelperFactory = taghelpers.InventoryHelperFactory;
using StoreValidationTransformTag = tags.StoreValidationTransformTag;
using GLOBALS2 = org.allbinary.globals.GLOBALS2;
using LogConfigTypeFactory = org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory;
using LogConfigTypes = org.allbinary.logic.communication.log.config.type.LogConfigTypes;

namespace tags.generic.inventory;

public class InventoryTag : StoreValidationTransformTag
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public InventoryTag() : base()
    {
        // Constructor invocation emitted in the initializer.
    }

    // throws LicensingException
    private void search()
    {
        try {
            object anyType = new InventoryHelperFactory().getInstance(this.getPropertiesHashMap(), this.pageContext);
            Type addressHelperClass = anyType.GetType();
            global::System.Reflection.MethodInfo method = addressHelperClass.getMethod("search", null);
            string result = ((string) method.invoke(anyType, null));
            pageContext.getOut().print(result);
        } catch (LicensingException e) {
            throw e;
        } catch (Exception e) {
            string error = "Failed to search Inventory by keyword";
            if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "search()", e);
            }
            try {
                pageContext.getOut().print(error + "<br>");
                pageContext.getOut().print("Exception: " + e + "<br>");
            } catch (Exception e2) {
                if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().LICENSINGERROR)) {
                    this.logUtil.put("Exception in Exception Handling", this, "search()", e);
                }
            }
        }
    }

    // throws LicensingException
    private void viewSummary()
    {
        try {
            object anyType = new InventoryHelperFactory().getInstance(this.getPropertiesHashMap(), this.pageContext);
            Type helperClass = anyType.GetType();
            global::System.Reflection.MethodInfo method = helperClass.getMethod("viewSummary", null);
            string result = ((string) method.invoke(anyType, null));
            pageContext.getOut().print(result);
        } catch (LicensingException e) {
            throw e;
        } catch (Exception e) {
            string error = "Failed to View Summary";
            if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "viewSummary()", e);
            }
            try {
                pageContext.getOut().print(error + "<br>");
                pageContext.getOut().print("Exception: " + e + "<br>");
            } catch (Exception e2) {
                if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().LICENSINGERROR)) {
                    this.logUtil.put("Exception in Exception Handling", this, "viewSummary())", e);
                }
            }
        }
    }

    // throws JspTagException
    public override int doStartTag()
    {
        try {
            if (this.getCommand() != null) {
                if (this.getCommand().compareTo(GLOBALS2.SEARCH) == 0) {
                    this.setName("Basic Search Inventory View");
                    this.setObjectFile("views.generic.inventory.AutoSearchValidationInventoryView");
                    this.search();
                    return EVAL_BODY_INCLUDE;
                } else if (this.getCommand().compareTo(GLOBALS2.VIEWSUMMARY) == 0) {
                    this.setName("Basic Inventory View");
                    this.setObjectFile("views.generic.inventory.AutoValidationInventoryView");
                    this.viewSummary();
                    return EVAL_BODY_INCLUDE;
                } else if (this.getCommand().compareTo(GLOBALS2.VIEW) == 0) {
                    this.setName("Basic Inventory View");
                    this.setObjectFile("views.generic.inventory.AutoValidationInventoryView");
                    return base.doStartTag();
                } else {
                    throw new Exception("No Such View Command: " + this.getCommand());
                }
            }
            throw new Exception("Command Null");
        } catch (LicensingException e) {
            AbResponseHandler.sendJspTagLicensingRedirect(this.pageContext, e);
            return SKIP_BODY;
        } catch (Exception e) {
            AbResponseHandler.sendJspTagRedirect(this.pageContext, e);
            return SKIP_BODY;
        }
    }

}

