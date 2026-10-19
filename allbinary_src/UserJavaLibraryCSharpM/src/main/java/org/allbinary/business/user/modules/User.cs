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
//using Calendar = java.util.Calendar;
using java.util;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
//using HttpServletRequest = javax.servlet.http.HttpServletRequest;
using StoreFrontData = org.allbinary.business.context.modules.storefront.StoreFrontData;
using EntryData = org.allbinary.business.entry.EntryData;
using UserData = org.allbinary.business.user.UserData;
using UserInterface = org.allbinary.business.user.UserInterface;
using UserConfigurationDomDocumentMapping = org.allbinary.business.user.modules.configuration.UserConfigurationDomDocumentMapping;
using UserConfigurationInterface = org.allbinary.business.user.modules.configuration.UserConfigurationInterface;
using UserConfigurationInterfaceFactory = org.allbinary.business.user.modules.configuration.UserConfigurationInterfaceFactory;
using Password = org.allbinary.business.user.password.Password;
using UserRole = org.allbinary.business.user.role.UserRole;
using UserRoleB = org.allbinary.business.user.role.UserRoleB;
using UserRoleData = org.allbinary.business.user.role.UserRoleData;
using UserName = org.allbinary.business.user.username.UserName;
using StdUtil = org.allbinary.logic.StdUtil;
using RequestParams = org.allbinary.logic.communication.http.request.RequestParams;
using WeblisketSessionData = org.allbinary.logic.communication.http.request.session.WeblisketSessionData;
using WeblisketSessionInterface = org.allbinary.logic.communication.http.request.session.WeblisketSessionInterface;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using StringValidationUtil = org.allbinary.logic.@string.StringValidationUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;

namespace org.allbinary.business.user.modules;

public class User : UserInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private string userName = null;
    private string prefixName = null;
    private string firstName = null;
    private string lastName = null;
    private string middleName = null;
    private string suffixName = null;
    private string company = null;
    private string positionAtCompany = null;
    private string mainEmail = null;
    private string secondaryEmail = null;
    private string homePhone = null;
    private string cellPhone = null;
    private string workPhone = null;
    private string otherContact = null;
    private string electronicDevice = null;
    private string fax = null;
    private UserRole role = null;
    private string encryption = null;
    private string secret = null;
    private Password password;
    private string enable = null;
    private string permissions = null;
    private UserConfigurationInterface userConfigurationInterface;
    public User()
    {
        this.userConfigurationInterface = UserConfigurationInterfaceFactory.getInstance();
        this.password = new Password(StringUtil.getInstance().EMPTY_STRING);
    }

    public User(HttpServletRequest request)
    {
        this.getFormData(new RequestParams(request).toHashMap());
        this.userConfigurationInterface = UserConfigurationInterfaceFactory.getInstance(this.getRole());
    }

    public User(HashMap userHashMap)
    {
        this.getFormData(userHashMap);
        this.userConfigurationInterface = UserConfigurationInterfaceFactory.getInstance(this.getRole());
    }

    // throws Exception
    public virtual void getFormData(HashMap userHashMap)
    {
        this.userName = new UserName(userHashMap).get();
        StringUtil stringUtil = StringUtil.getInstance();
        string passwordString = stringUtil.getNonNull(((string) userHashMap.get(UserData.PASSWORD)));
        StringValidationUtil stringValidationUtil = StringValidationUtil.getInstance();
        if (stringValidationUtil.isEmpty(this.userName) && stringValidationUtil.isEmpty(passwordString)) {
            this.userName = stringUtil.getNonNull(((string) userHashMap.get(WeblisketSessionData.REMOVABLEUSERNAME)));
            passwordString = stringUtil.getNonNull(((string) userHashMap.get(WeblisketSessionData.REMOVABLEPASSWORD)));
        }
        string encryption = stringUtil.getNonNull(((string) userHashMap.get(EntryData.getInstance().ENCRYPTION)));
        string secret = stringUtil.getNonNull(((string) userHashMap.get(UserData.SECRET)));
        this.password = new Password(passwordString);
        this.prefixName = stringUtil.getNonNull(((string) userHashMap.get(UserData.PREFIXNAME)));
        this.firstName = stringUtil.getNonNull(((string) userHashMap.get(UserData.FIRSTNAME)));
        this.lastName = stringUtil.getNonNull(((string) userHashMap.get(UserData.LASTNAME)));
        this.middleName = stringUtil.getNonNull(((string) userHashMap.get(UserData.MIDDLENAME)));
        this.suffixName = stringUtil.getNonNull(((string) userHashMap.get(UserData.SUFFIXNAME)));
        this.company = stringUtil.getNonNull(((string) userHashMap.get(UserData.COMPANY)));
        this.positionAtCompany = stringUtil.getNonNull(((string) userHashMap.get(UserData.POSITIONATCOMPANY)));
        this.mainEmail = stringUtil.getNonNull(((string) userHashMap.get(UserData.MAINEMAIL)));
        this.secondaryEmail = stringUtil.getNonNull(((string) userHashMap.get(UserData.SECONDARYEMAIL)));
        this.homePhone = stringUtil.getNonNull(((string) userHashMap.get(UserData.HOMEPHONE)));
        this.cellPhone = stringUtil.getNonNull(((string) userHashMap.get(UserData.CELLPHONE)));
        this.workPhone = stringUtil.getNonNull(((string) userHashMap.get(UserData.WORKPHONE)));
        this.otherContact = stringUtil.getNonNull(((string) userHashMap.get(UserData.OTHERCONTACT)));
        this.electronicDevice = stringUtil.getNonNull(((string) userHashMap.get(UserData.ELECTRONICDEVICE)));
        this.fax = stringUtil.getNonNull(((string) userHashMap.get(UserData.FAX)));
        this.role = UserRoleB.getRole(((string) userHashMap.get(UserRoleData.NAME.ToString())));
        this.permissions = stringUtil.getNonNull(((string) userHashMap.get(UserData.PERMISSIONS)));
        if (!stringValidationUtil.isEmpty(this.permissions) && string.CompareOrdinal(this.permissions, StoreFrontData.getInstance().NAME) == 0) {
            this.permissions = stringUtil.getNonNull(((string) userHashMap.get(StoreFrontData.getInstance().NAME)));
        } else if (this.permissions == null) {
            this.permissions = "No Permissions";
        }
        this.enable = stringUtil.getNonNull(((string) userHashMap.get(EntryData.getInstance().ENABLE)));
    }

    public virtual bool? isValid()
    {
        try {
            bool? valid = true;
            if (!UserName.getInstance().isValid(this.userName)) {
                valid = false;
            }
            if (!this.password.isValid()) {
                valid = false;
            }
            StringValidationUtil stringValidationUtil = StringValidationUtil.getInstance();
            if (!stringValidationUtil.isValidRequired(this.firstName, 1, UserData.MAXLEN)) {
                valid = false;
            }
            if (!stringValidationUtil.isValidRequired(this.lastName, 1, UserData.MAXLEN)) {
                valid = false;
            }
            if (!stringValidationUtil.isValidRequired(this.mainEmail, 1, UserData.MAXLEN) || this.mainEmail.IndexOf("@") == -1) {
                valid = false;
            }
            return valid;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VALIDATIONERROR)) {
                CommonStrings commonStrings = CommonStrings.getInstance();
                this.logUtil.put("Failed to validate form", this, commonStrings.IS_VALID, e);
            }
            return false;
        }
    }

    public virtual string validationInfo()
    {
        try {
            StringValidationUtil stringValidationUtil = StringValidationUtil.getInstance();
            StringMaker stringBuffer = new StringMaker();
            stringBuffer.append(UserName.getValidationInfo(this.userName));
            stringBuffer.append(this.password.getValidationInfo());
            if (!stringValidationUtil.isValidRequired(this.firstName, 1, UserData.MAXLEN)) {
                stringBuffer.append("Please enter a valid First Name.<br />");
            }
            if (!stringValidationUtil.isValidRequired(this.lastName, 1, UserData.MAXLEN)) {
                stringBuffer.append("Please enter a valid Last Name.<br />");
            }
            if (!stringValidationUtil.isValidRequired(this.mainEmail, 1, UserData.MAXLEN) || this.mainEmail.IndexOf("@") == -1) {
                stringBuffer.append("Please enter a valid email address.<br />");
            }
            return stringBuffer.ToString();
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put("Failed to generate validation error info", this, "validationInfo()", e);
            }
            return "Error Validating Form";
        }
    }

    public virtual void setUserName(string value)
    {
        this.userName = value;
    }

    public virtual void setPrefixName(string value)
    {
        this.prefixName = value;
    }

    public virtual void setFirstName(string value)
    {
        this.firstName = value;
    }

    public virtual void setLastName(string value)
    {
        this.lastName = value;
    }

    public virtual void setMiddleName(string value)
    {
        this.middleName = value;
    }

    public virtual void setSuffixName(string value)
    {
        this.suffixName = value;
    }

    public virtual void setCompany(string value)
    {
        this.company = value;
    }

    public virtual void setPositionAtCompany(string value)
    {
        this.positionAtCompany = value;
    }

    public virtual void setMainEmail(string value)
    {
        this.mainEmail = value;
    }

    public virtual void setSecondaryEmail(string value)
    {
        this.secondaryEmail = value;
    }

    public virtual void setHomePhone(string value)
    {
        this.homePhone = value;
    }

    public virtual void setCellPhone(string value)
    {
        this.cellPhone = value;
    }

    public virtual void setWorkPhone(string value)
    {
        this.workPhone = value;
    }

    public virtual void setOtherContact(string value)
    {
        this.otherContact = value;
    }

    public virtual void setElectronicContact(string value)
    {
        this.electronicDevice = value;
    }

    public virtual void setFax(string value)
    {
        this.fax = value;
    }

    public virtual void setRole(UserRole role)
    {
        this.role = role;
    }

    public virtual void setPermissions(string value)
    {
        this.permissions = value;
    }

    public virtual void setEncryption(string value)
    {
        this.encryption = value;
    }

    public virtual void setSecret(string value)
    {
        this.secret = value;
    }

    public virtual void setPassword(string value)
    {
        this.password.set(value);
    }

    public virtual void enable()
    {
        this.setEnable("Yes");
    }

    public virtual void disable()
    {
        this.setEnable("No");
    }

    public virtual void setEnable(string enable)
    {
        this.enable = enable;
    }

    public virtual string getUserName()
    {
        return this.userName;
    }

    public virtual string getPrefixName()
    {
        return this.prefixName;
    }

    public virtual string getFirstName()
    {
        return this.firstName;
    }

    public virtual string getLastName()
    {
        return this.lastName;
    }

    public virtual string getMiddleName()
    {
        return this.middleName;
    }

    public virtual string getSuffixName()
    {
        return this.suffixName;
    }

    public virtual string getCompany()
    {
        return this.company;
    }

    public virtual string getPositionAtCompany()
    {
        return this.positionAtCompany;
    }

    public virtual string getMainEmail()
    {
        return this.mainEmail;
    }

    public virtual string getSecondaryEmail()
    {
        return this.secondaryEmail;
    }

    public virtual string getHomePhone()
    {
        return this.homePhone;
    }

    public virtual string getCellPhone()
    {
        return this.cellPhone;
    }

    public virtual string getWorkPhone()
    {
        return this.workPhone;
    }

    public virtual string getOtherContact()
    {
        return this.otherContact;
    }

    public virtual string getElectronicContact()
    {
        return this.electronicDevice;
    }

    public virtual string getFax()
    {
        return this.fax;
    }

    public virtual UserRole getRole()
    {
        return this.role;
    }

    public virtual string getPermissions()
    {
        return this.permissions;
    }

    public virtual string getEncryption()
    {
        return this.encryption;
    }

    public virtual string getSecret()
    {
        return this.secret;
    }

    public virtual string getPassword()
    {
        return this.password.get();
    }

    // throws Exception
    public virtual BasicArrayList toVector()
    {
        BasicArrayList values = new BasicArrayListD();
        values.add(this.userName);
        values.add(this.prefixName);
        values.add(this.firstName);
        values.add(this.lastName);
        values.add(this.middleName);
        values.add(this.suffixName);
        values.add(this.company);
        values.add(this.positionAtCompany);
        values.add(this.mainEmail);
        values.add(this.secondaryEmail);
        values.add(this.homePhone);
        values.add(this.cellPhone);
        values.add(this.workPhone);
        values.add(this.otherContact);
        values.add(this.electronicDevice);
        values.add(this.fax);
        values.add(this.getRole().ToString());
        UserConfigurationDomDocumentMapping userConfigurationDomDocumentMapping = new UserConfigurationDomDocumentMapping(this.getUserConfigurationInterface());
        values.add(userConfigurationDomDocumentMapping.toDomDocumentString());
        values.add(this.permissions);
        values.addAllList(this.password.toVector(this.secret));
        values.add(this.enable);
        Calendar calendar = Calendar.getInstance();
        string time = new string((calendar.getTimeInMillis().ToString()).ToCharArray());
        values.add(time);
        values.add(time);
        return values;
    }

    // throws Exception
    public virtual HashMap toHashMap()
    {
        HashMap values = StdUtil.getInstance().createHashMap();
        values.put(UserData.USERNAME, userName);
        values.put(UserData.PREFIXNAME, prefixName);
        values.put(UserData.FIRSTNAME, firstName);
        values.put(UserData.LASTNAME, lastName);
        values.put(UserData.MIDDLENAME, middleName);
        values.put(UserData.SUFFIXNAME, suffixName);
        values.put(UserData.COMPANY, company);
        values.put(UserData.POSITIONATCOMPANY, positionAtCompany);
        values.put(UserData.MAINEMAIL, mainEmail);
        values.put(UserData.SECONDARYEMAIL, secondaryEmail);
        values.put(UserData.HOMEPHONE, homePhone);
        values.put(UserData.CELLPHONE, cellPhone);
        values.put(UserData.WORKPHONE, workPhone);
        values.put(UserData.OTHERCONTACT, otherContact);
        values.put(UserData.ELECTRONICDEVICE, electronicDevice);
        values.put(UserData.FAX, fax);
        if (this.getRole() != null) {
            values.put(UserRoleData.NAME.ToString(), this.getRole().ToString());
        }
        UserConfigurationDomDocumentMapping userConfigurationDomDocumentMapping = new UserConfigurationDomDocumentMapping(this.getUserConfigurationInterface());
        values.put(UserData.CONFIGURATION, userConfigurationDomDocumentMapping.toDomDocumentString());
        values.put(UserData.PERMISSIONS, this.permissions);
        values.putAll(this.password.toHashMap(this.secret));
        values.put(EntryData.getInstance().ENABLE, this.enable);
        Calendar calendar = Calendar.getInstance();
        string time = new string((calendar.getTimeInMillis().ToString()).ToCharArray());
        values.put(EntryData.getInstance().LASTMODIFIED, time);
        return values;
    }

    public virtual HashMap toPasswordHashMap()
    {
        return this.password.toHashMap(this.secret);
    }

    public virtual void validateSession(WeblisketSessionInterface weblisketSession)
    {
        weblisketSession.setAuthenticated();
        weblisketSession.setRole(this.getRole());
        weblisketSession.setUserName(this.getUserName());
    }

    public virtual void updateSession(WeblisketSessionInterface weblisketSession)
    {
    }

    public virtual bool? isSessionValid()
    {
        return true;
    }

    // throws Exception
    public virtual object getKey()
    {
        return ((object) this.userName);
    }

    public virtual Document toValidationInfoDoc()
    {
        return null;
    }

    public virtual Node toValidationInfoNode(Document document)
    {
        return null;
    }

    public virtual UserConfigurationInterface getUserConfigurationInterface()
    {
        return this.userConfigurationInterface;
    }

    public virtual void setUserConfigurationInterface(UserConfigurationInterface userConfigurationInterface)
    {
        this.userConfigurationInterface = userConfigurationInterface;
    }

}

