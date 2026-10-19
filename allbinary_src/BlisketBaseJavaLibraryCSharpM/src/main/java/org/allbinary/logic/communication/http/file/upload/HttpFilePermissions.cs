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
using BasicUserRoleFactory = org.allbinary.business.user.role.BasicUserRoleFactory;
using StdUtil = org.allbinary.logic.StdUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using AbFile = org.allbinary.logic.io.file.AbFile;
using AbPath = org.allbinary.logic.io.path.AbPath;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.logic.communication.http.file.upload;

public class HttpFilePermissions
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private readonly AbFile file;
    private readonly BasicArrayList userRoles = new BasicArrayListD();
    public HttpFilePermissions(AbPath fullPath)
    {
        this.file = AbFile.createAbFileFromAbPath(new AbPath(fullPath.toFileSystemString(), FileUploadData.getInstance().FILE));
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEWERROR)) {
            this.logUtil.putF("Loading Privileges: " + fullPath.toFileSystemString(), this, this.commonStrings.CONSTRUCTOR);
        }
        if (this.isFile()) {
            this.userRoles.add(BasicUserRoleFactory.getInstance().ADMINISTRATOR);
        }
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEWERROR)) {
            this.logUtil.putF("User Roles: " + this.userRoles, this, this.commonStrings.CONSTRUCTOR);
        }
    }

    public virtual bool isFile()
    {
        return this.file.isFile();
    }

    public virtual BasicArrayList getUserRoles()
    {
        return this.userRoles;
    }

}

