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
using UserRole = org.allbinary.business.user.role.UserRole;
using DomSearchHelper = org.allbinary.data.tree.dom.DomSearchHelper;
using DomDocumentHelper = org.allbinary.data.tree.dom.document.DomDocumentHelper;
using FREEBLISKET_PATH_GLOBALS = org.allbinary.globals.FREEBLISKET_PATH_GLOBALS;
using URLGLOBALS = org.allbinary.globals.URLGLOBALS;
using CryptFileReader = org.allbinary.logic.control.crypt.file.CryptFileReader;
using AbPath = org.allbinary.logic.io.path.AbPath;
using AbPathData = org.allbinary.logic.io.path.AbPathData;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;

namespace org.allbinary.business.user.modules.configuration;

public class UserConfigurationInterfaceFactory
{
    private static readonly string configurationName = "DefaultUserConfiguration";
    private UserConfigurationInterfaceFactory()
    {
    }

    // throws Exception
    public static UserConfigurationInterface getInstance(Document document)
    {
        Node configurationNode = DomSearchHelper.getNode(UserConfigurationData.NAME, document.getChildNodes());
        return ((UserConfigurationInterface) new UserConfigurationView(configurationNode).getUserConfigurationInterface());
    }

    // throws Exception
    public static UserConfigurationInterface getInstance(UserRole userRole)
    {
        AbPath abPath = new AbPath(URLGLOBALS.getMainPath() + FREEBLISKET_PATH_GLOBALS.getInstance().USERCONFIGURATIONPATH, UserConfigurationInterfaceFactory.configurationName + userRole.ToString() + AbPathData.getInstance().EXTENSION_SEP + UserConfigurationData.UNCRYPTED_EXTENSION);
        string documentString = new CryptFileReader(UserConfigurationData.UNCRYPTED_EXTENSION, UserConfigurationData.ENCRYPTED_EXTENSION).get(abPath);
        Document document = DomDocumentHelper.create(documentString);
        return UserConfigurationInterfaceFactory.getInstance(document);
    }

    // throws Exception
    public static UserConfigurationInterface getInstance()
    {
        return new UserConfiguration();
    }

}

