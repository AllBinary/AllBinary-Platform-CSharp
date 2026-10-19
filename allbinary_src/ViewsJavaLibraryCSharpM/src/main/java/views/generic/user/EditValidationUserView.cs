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
using UserName = org.allbinary.business.user.username.UserName;
using UserEntityFactory = org.allbinary.data.tables.user.UserEntityFactory;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using ValidationComponentInterface = org.allbinary.logic.control.validate.ValidationComponentInterface;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using TransformInfoInterface = org.allbinary.logic.visual.transform.info.TransformInfoInterface;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;

namespace views.generic.user;

public class EditValidationUserView : UserView, ValidationComponentInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private string userName;
    public EditValidationUserView(TransformInfoInterface transformInfoInterface) : base(transformInfoInterface)
    {
        // base(transformInfoInterface) is called from the constructor declaration
        this.userName = this.getWeblisketSession().getUserName();
    }

    public virtual bool? isValid()
    {
        try {
            if (UserName.getInstance().isValid(this.userName) == true) {
                this.user = UserEntityFactory.getInstance().getUser(this.userName);
                if (this.user == null) {
                    return false;
                }
            } else {
                return false;
            }
            return this.user.isValid();
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEWERROR)) {
                this.logUtil.put("Failed to validate form", this, this.commonStrings.IS_VALID, e);
            }
            return false;
        }
    }

    public virtual string validationInfo()
    {
        try {
            StringMaker stringBuffer = new StringMaker();
            if (UserName.getInstance().isValid(this.userName)) {
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                    this.logUtil.putF("User Name is valid", this, "validationInfo()");
                }
                this.user = UserEntityFactory.getInstance().getUser(this.userName);
                if (this.user == null) {
                    stringBuffer.append("User does not exist.<br />");
                    return stringBuffer.ToString();
                }
            } else {
                stringBuffer.append("User Name is not valid.<br />");
                return stringBuffer.ToString();
            }
            if (this.user.isValid() == false) {
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                    this.logUtil.putF("User exists but is invalid - Probably manually modified", this, "validationInfo()");
                }
                stringBuffer.append("User data is not valid - Please call administrator.<br />");
                stringBuffer.append(this.user.validationInfo());
            }
            return stringBuffer.ToString();
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEWERROR)) {
                this.logUtil.put("Failed to generate validation error info", this, "validationInfo()", e);
            }
            return "Error Validating Form";
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

}

