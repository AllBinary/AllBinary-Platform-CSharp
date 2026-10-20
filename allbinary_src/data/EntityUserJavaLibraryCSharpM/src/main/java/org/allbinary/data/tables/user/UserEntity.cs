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
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using StoreFrontData = org.allbinary.business.context.modules.storefront.StoreFrontData;
using StoreFrontInterface = org.allbinary.business.context.modules.storefront.StoreFrontInterface;
using EntryData = org.allbinary.business.entry.EntryData;
using UserDbInitInfo = org.allbinary.business.init.db.UserDbInitInfo;
using CreateUserFactory = org.allbinary.business.user.CreateUserFactory;
using UserData = org.allbinary.business.user.UserData;
using UserInterface = org.allbinary.business.user.UserInterface;
using User = org.allbinary.business.user.modules.User;
using UserRole = org.allbinary.business.user.role.UserRole;
using UserRoleData = org.allbinary.business.user.role.UserRoleData;
using UserRoleFactory = org.allbinary.business.user.role.UserRoleFactory;
using GLOBALS2 = org.allbinary.globals.GLOBALS2;
using StdUtil = org.allbinary.logic.StdUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using AbSqlBean = org.allbinary.logic.communication.sql.AbSqlBean;
using SuperCrypt = org.allbinary.logic.control.crypt.SuperCrypt;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using CommonSeps = org.allbinary.@string.CommonSeps;

namespace org.allbinary.data.tables.user;

public class UserEntity : AbSqlBean, UserEntityInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly string tableName = "user";
    private readonly string COMMAND_SUCCESS_FOR_USER = "Command Success for user: ";
    private readonly string PASSWORD_LABEL = " Password: ";
    private readonly string EQUALS = "==";
    private readonly string COMMAND_SUCCESS_BUT_LOGIN_FAILED = "Command Success but login failed for user: ";
    private readonly string INVALID_PASSWORD_LABEL = " Password: \n\"";
    private readonly string NOT_EQUAL = "\"!=\"";
    private readonly string END_QUOTES = CommonSeps.getInstance().QUOTE;
    public UserEntity() : base(new UserDbInitInfo())
    {
        // base(new UserDbInitInfo()) is called from the constructor declaration
        this.setTableName(this.tableName);
    }

    public virtual void insert(BasicArrayList values)
    {
        try {
            base.insert(values);
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                this.logUtil.putF(this.commonStrings.SUCCESS, this, INSERT);
            }
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                this.logUtil.put(this.commonStrings.FAILURE, this, INSERT, e);
            }
        }
    }

    // throws Exception
    public virtual BasicArrayList getAdministrators()
    {
        return this.getUsersWithRole(UserRoleFactory.getInstance().ADMINISTRATOR);
    }

    // throws Exception
    public virtual BasicArrayList getStoreManagers(StoreFrontInterface storeFrontInterface)
    {
        HashMap<object, object> keysAndValues = StdUtil.getInstance().createHashMap();
        BasicArrayList usersVector = new BasicArrayListD();
        keysAndValues.put(UserRoleData.NAME.ToString(), UserRoleFactory.getInstance().STOREMANAGER.ToString());
        keysAndValues.put(UserData.PERMISSIONS, storeFrontInterface.getName());
        BasicArrayList usersHashMapVector = base.getRows(keysAndValues);
        int size = usersHashMapVector.size();
        for (int i = 0; i < size; i++) {
            HashMap<object, object> userHashMap = ((HashMap<object, object>) usersHashMapVector.get(i));
            if (userHashMap != null) {
                usersVector.add(new User(userHashMap));
            }
        }
        return usersVector;
    }

    // throws Exception
    public virtual BasicArrayList getCustomers()
    {
        return this.getUsersWithRole(UserRoleFactory.getInstance().CUSTOMER);
    }

    // throws Exception
    public virtual BasicArrayList getUsersWithRole(UserRole userRole)
    {
        HashMap<object, object> keysAndValues = StdUtil.getInstance().createHashMap();
        BasicArrayList usersVector = new BasicArrayListD();
        keysAndValues.put(UserRoleData.NAME.ToString(), userRole.ToString());
        BasicArrayList usersHashMapVector = base.getRows(keysAndValues);
        int size = usersHashMapVector.size();
        for (int index = 0; index < size; index++) {
            HashMap<object, object> userHashMap = ((HashMap<object, object>) usersHashMapVector.get(index));
            if (userHashMap != null) {
                usersVector.add(new User(userHashMap));
            }
        }
        return usersVector;
    }

    // throws Exception
    public virtual BasicArrayList getUsers(StoreFrontInterface storeFrontInterface)
    {
        HashMap<object, object> keysAndValues = StdUtil.getInstance().createHashMap();
        BasicArrayList usersVector = new BasicArrayListD();
        keysAndValues.put(StoreFrontData.getInstance().NAME, storeFrontInterface.getName());
        BasicArrayList usersHashMapVector = base.getRows(keysAndValues);
        int size = usersHashMapVector.size();
        for (int index = 0; index < size; index++) {
            HashMap<object, object> userHashMap = ((HashMap<object, object>) usersHashMapVector.get(index));
            if (userHashMap != null) {
                usersVector.add(new User(userHashMap));
            }
        }
        return usersVector;
    }

    // throws Exception
    public virtual UserInterface getUser(string userName)
    {
        HashMap<object, object> row = StdUtil.getInstance().createHashMap();
        row.put(UserData.USERNAME, userName);
        HashMap<object, object> userHashMap = base.getRow(row);
        if (userHashMap != null) {
            return CreateUserFactory.getInstance(userHashMap);
        } else {
            return null;
        }
    }

    public virtual void deleteWhere(string key, string value)
    {
        try {
            base.deleteWhere(key, value);
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                this.logUtil.putF(this.commonStrings.SUCCESS, this, "deleteWhere");
            }
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                this.logUtil.put(this.commonStrings.FAILURE, this, "deleteWhere", e);
            }
        }
    }

    public virtual string login(string userName, string password)
    {
        try {
            int isUserNameAndPasswordCorrect = 0;
            string result = base.getField(UserData.USERNAME, userName, UserData.PASSWORD);
            string encryption = base.getField(UserData.USERNAME, userName, EntryData.getInstance().ENCRYPTION);
            if (encryption != null && string.CompareOrdinal(encryption, this.stringUtil.EMPTY_STRING) != 0) {
                isUserNameAndPasswordCorrect = string.CompareOrdinal(result, new SuperCrypt(((int) encryption)).encrypt(password));
            } else {
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                    this.logUtil.putF("Command Success but login failed for user: " + userName + " because user did not exist", this, "login");
                }
                return GLOBALS2.LOGINFAILED;
            }
            if (isUserNameAndPasswordCorrect == 0) {
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                    StringMaker stringBuffer = new StringMaker();
                    stringBuffer.append(this.COMMAND_SUCCESS_FOR_USER);
                    stringBuffer.append(userName);
                    stringBuffer.append(this.PASSWORD_LABEL);
                    stringBuffer.append(password);
                    stringBuffer.append(this.EQUALS);
                    stringBuffer.append(result);
                    this.logUtil.putF(stringBuffer.ToString(), this, "login");
                }
                return GLOBALS2.LOGINSUCCESS;
            } else {
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                    StringMaker stringBuffer = new StringMaker();
                    stringBuffer.append(this.COMMAND_SUCCESS_BUT_LOGIN_FAILED);
                    stringBuffer.append(userName);
                    stringBuffer.append(this.INVALID_PASSWORD_LABEL);
                    stringBuffer.append(new SuperCrypt(((int) encryption)).encrypt(password));
                    stringBuffer.append(this.NOT_EQUAL);
                    stringBuffer.append(result);
                    stringBuffer.append(this.END_QUOTES);
                    this.logUtil.putF(stringBuffer.ToString(), this, "login");
                }
                return GLOBALS2.LOGINFAILED;
            }
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                this.logUtil.put(this.commonStrings.FAILURE, this, "login", e);
            }
            return "Error";
        }
    }

    public virtual void update(string userName, HashMap<object, object> updatedValues)
    {
        base.updateWhere(UserData.USERNAME, userName, updatedValues);
    }

    public virtual string dropTables()
    {
        return base.dropTable();
    }

    public string createTableStatement()
    {
        EntryData entryData = EntryData.getInstance();
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(this.sqlStrings.CREATE_TABLE).append(tableName).append(this.sqlStrings.START).append(UserData.USERNAME).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(UserData.PREFIXNAME).append(this.sqlTypeStrings.MAX_CHAR_COLUMN).append(UserData.FIRSTNAME).append(this.sqlTypeStrings.MAX_CHAR_COLUMN).append(UserData.LASTNAME).append(this.sqlTypeStrings.MAX_CHAR_COLUMN).append(UserData.MIDDLENAME).append(this.sqlTypeStrings.MAX_CHAR_COLUMN).append(UserData.SUFFIXNAME).append(this.sqlTypeStrings.MAX_CHAR_COLUMN).append(UserData.COMPANY).append(this.sqlTypeStrings.MAX_CHAR_COLUMN).append(UserData.POSITIONATCOMPANY).append(this.sqlTypeStrings.MAX_CHAR_COLUMN).append(UserData.MAINEMAIL).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(UserData.SECONDARYEMAIL).append(this.sqlTypeStrings.MAX_CHAR_COLUMN).append(UserData.HOMEPHONE).append(this.sqlTypeStrings.MAX_CHAR_COLUMN).append(UserData.CELLPHONE).append(this.sqlTypeStrings.MAX_CHAR_COLUMN).append(UserData.WORKPHONE).append(this.sqlTypeStrings.MAX_CHAR_COLUMN).append(UserData.OTHERCONTACT).append(this.sqlTypeStrings.MAX_CHAR_COLUMN).append(UserData.ELECTRONICDEVICE).append(this.sqlTypeStrings.MAX_CHAR_COLUMN).append(UserData.FAX).append(this.sqlTypeStrings.MAX_CHAR_COLUMN).append(UserRoleData.NAME.ToString()).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(UserData.CONFIGURATION).append(this.sqlTypeStrings.BLOB_NOT_NULL).append(UserData.PERMISSIONS).append(this.sqlTypeStrings.MAX_CHAR_COLUMN).append(entryData.ENCRYPTION).append(this.sqlTypeStrings.MAX_BIG_INT_UNSIGNED_NOT_NULL).append(UserData.SECRET).append(this.sqlTypeStrings.MAX_CHAR_COLUMN).append(UserData.PASSWORD).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(entryData.ENABLE).append(this.sqlTypeStrings.MAX_CHAR_COLUMN).append(entryData.TIMECREATED).append(this.sqlTypeStrings.MAX_BIG_INT_UNSIGNED_NOT_NULL).append(entryData.LASTMODIFIED).append(this.sqlTypeStrings.MAX_BIG_INT_UNSIGNED_NOT_NULL).append(this.sqlStrings.PRIMARY_KEY).append(UserData.USERNAME).append(this.sqlStrings.END);
        return stringBuffer.ToString();
    }

    public virtual string createTable()
    {
        return base.createTable(this.createTableStatement());
    }

}

