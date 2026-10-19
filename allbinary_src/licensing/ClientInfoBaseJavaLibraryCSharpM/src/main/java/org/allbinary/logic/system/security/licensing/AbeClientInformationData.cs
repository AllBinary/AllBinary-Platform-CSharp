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

namespace org.allbinary.logic.system.security.licensing;

public class AbeClientInformationData
{
    private static readonly AbeClientInformationData instance = new AbeClientInformationData();
    public static AbeClientInformationData getInstance()
    {
        return AbeClientInformationData.instance;
    }

    private AbeClientInformationData()
    {
    }

    public readonly string KEY = "KEY";
    public readonly string NAME = "NAME";
    public readonly string VERSION = "VERSION";
    public readonly string SPECIALNAME = "SPECIALNAME";
    public readonly string LICENSEID = "LICENSEID";
    public readonly string LICENSE_TYPE = "LICENSETYPE";
    public readonly string PREVIOUSLICENSEID = "PREVIOUSLICENSEID";
    public readonly string OSNAME = "OSNAME";
    public readonly string OSARCH = "OSARCH";
    public readonly string OSVERSION = "OSVERSION";
    public readonly string OS = "OS";
    public readonly string HARDWARE = "HARDWARE";
    public readonly string LICENSESERVERS = "LICENSESERVERS";
    public readonly string NEWLICENSE = "NEWLICENSE";
    public readonly string ISNEW = "ISNEW";
    public readonly string SPECIAL = "SPECIAL";
}

