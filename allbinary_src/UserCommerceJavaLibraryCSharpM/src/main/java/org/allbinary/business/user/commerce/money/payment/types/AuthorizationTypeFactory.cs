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

namespace org.allbinary.business.user.commerce.money.payment.types;

public class AuthorizationTypeFactory
{
    private static readonly AuthorizationTypeFactory instance = new AuthorizationTypeFactory();
    public static AuthorizationTypeFactory getInstance()
    {
        return AuthorizationTypeFactory.instance;
    }

    public readonly AuthorizationType NONE = new AuthorizationType("None");
    public readonly AuthorizationType VOICE = new AuthorizationType("Voice");
    public readonly AuthorizationType RETINAL = new AuthorizationType("Retinal");
    public readonly AuthorizationType IMAGE = new AuthorizationType("Image");
    public readonly AuthorizationType DNA = new AuthorizationType("DNA");
    public readonly AuthorizationType PRINT = new AuthorizationType("Print");
    public readonly AuthorizationType CHIP = new AuthorizationType("Chip");
}

