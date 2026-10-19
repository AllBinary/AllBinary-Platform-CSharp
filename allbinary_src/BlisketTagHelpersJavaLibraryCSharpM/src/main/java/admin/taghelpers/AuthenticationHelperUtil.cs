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
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using BasicUserRole = org.allbinary.business.user.role.BasicUserRole;
using UserRole = org.allbinary.business.user.role.UserRole;
using URLGLOBALS = org.allbinary.globals.URLGLOBALS;
using HttpFilePermissions = org.allbinary.logic.communication.http.file.upload.HttpFilePermissions;
using HttpRequestUtil = org.allbinary.logic.communication.http.request.HttpRequestUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using AbPath = org.allbinary.logic.io.path.AbPath;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using CommonLabels = org.allbinary.@string.CommonLabels;

namespace admin.taghelpers;

public class AuthenticationHelperUtil
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly AuthenticationHelperUtil instance = new AuthenticationHelperUtil();
    public static AuthenticationHelperUtil getInstance()
    {
        return AuthenticationHelperUtil.instance;
    }

    // throws Exception
    public bool isAuthorized(AuthenticationHelper authenticationHelper, string filePath)
    {
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEWERROR)) {
            this.logUtil.putF(CommonLabels.getInstance().START + filePath, this, "isAuthorized()");
        }
        int endIndex = HttpRequestUtil.getInstance().getLastSeparatorIndex(filePath);
        AbPath fullPath = new AbPath(URLGLOBALS.getWebappPath() + filePath.Substring(0, (endIndex) - (0)), StringUtil.getInstance().EMPTY_STRING);
        HttpFilePermissions downloadFilePermissions = new HttpFilePermissions(fullPath);
        BasicArrayList userRoles = downloadFilePermissions.getUserRoles();
        UserRole userRole = authenticationHelper.getRole();
        BasicUserRole basicUserRole = userRole.getBasicUserRole();
        if (userRoles.contains(basicUserRole)) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                this.logUtil.putF("Authorized", this, "isAuthorized()");
            }
            return true;
        } else {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                this.logUtil.putF("Not Authorized: " + basicUserRole.ToString(), this, "isAuthorized()");
            }
            return false;
        }
    }

}

