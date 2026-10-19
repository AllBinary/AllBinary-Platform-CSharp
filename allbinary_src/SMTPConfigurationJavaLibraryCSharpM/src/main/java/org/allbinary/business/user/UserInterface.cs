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
using java.util;
using UserConfigurationInterface = org.allbinary.business.user.modules.configuration.UserConfigurationInterface;
using UserRole = org.allbinary.business.user.role.UserRole;
using TableMappingInterface = org.allbinary.data.tables.TableMappingInterface;
using WeblisketSessionInterface = org.allbinary.logic.communication.http.request.session.WeblisketSessionInterface;
using ValidationInterface = org.allbinary.logic.control.validate.ValidationInterface;

namespace org.allbinary.business.user;

public interface UserInterface : TableMappingInterface, ValidationInterface
{
    void setUserName(string value);

    void setPrefixName(string value);

    void setFirstName(string value);

    void setLastName(string value);

    void setMiddleName(string value);

    void setSuffixName(string value);

    void setCompany(string value);

    void setPositionAtCompany(string value);

    void setMainEmail(string value);

    void setSecondaryEmail(string value);

    void setHomePhone(string value);

    void setCellPhone(string value);

    void setWorkPhone(string value);

    void setOtherContact(string value);

    void setElectronicContact(string value);

    void setFax(string value);

    void setRole(UserRole aRole);

    void setEncryption(string value);

    void setSecret(string value);

    void setPassword(string value);

    void setPermissions(string value);

    void enable();

    void setEnable(string enable);

    string getUserName();

    string getPrefixName();

    string getFirstName();

    string getLastName();

    string getMiddleName();

    string getSuffixName();

    string getCompany();

    string getPositionAtCompany();

    string getMainEmail();

    string getSecondaryEmail();

    string getHomePhone();

    string getCellPhone();

    string getWorkPhone();

    string getOtherContact();

    string getElectronicContact();

    string getFax();

    UserRole getRole();

    string getEncryption();

    string getSecret();

    string getPassword();

    string getPermissions();

    UserConfigurationInterface getUserConfigurationInterface();

    void setUserConfigurationInterface(UserConfigurationInterface userConfigurationInterface);

    HashMap toPasswordHashMap();

    void validateSession(WeblisketSessionInterface weblisketSession);

    void updateSession(WeblisketSessionInterface weblisketSession);

    bool? isSessionValid();

}

