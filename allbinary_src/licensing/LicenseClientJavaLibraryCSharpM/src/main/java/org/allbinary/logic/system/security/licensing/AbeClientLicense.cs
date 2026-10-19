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
using StdUtil = org.allbinary.logic.StdUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using StringValidationUtil = org.allbinary.logic.@string.StringValidationUtil;
using org.allbinary.util;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.logic.system.security.licensing;

public class AbeClientLicense : AbeLicenseInterface
{
    private ABHashtable<object, object> hashtable;
    private string id;
    private BasicArrayList servers;
    private string special = null;
    private LicenseType licenseType;
    public AbeClientLicense(ABHashtable<object, object> hashtable)
    {
        this.hashtable = StdUtil.getInstance().createHashtable();
        AbeClientInformationData abeClientInformationData = AbeClientInformationData.getInstance();
        object keyValue = hashtable.get(abeClientInformationData.KEY);
        if (keyValue != null) {
            if (keyValue is string) {
                this.hashtable.put(abeClientInformationData.KEY, keyValue);
            }
        }
        this.id = ((string) hashtable.get(abeClientInformationData.LICENSEID));
        BasicArrayList vector = ((BasicArrayList) hashtable.get(abeClientInformationData.LICENSESERVERS));
        this.servers = new BasicArrayListD();
        int size = vector.size();
        for (int index = 0; index < size; index++) {
            this.servers.add(vector.get(index));
        }
        StringUtil stringUtil = StringUtil.getInstance();
        this.setSpecial(stringUtil.getNonNull(((string) hashtable.get(abeClientInformationData.SPECIAL))));
        string licenseTypeString = stringUtil.getNonNull(((string) hashtable.get(abeClientInformationData.LICENSE_TYPE)));
        this.licenseType = LicenseTypeFactory.getInstance().getInstance(licenseTypeString);
    }

    public static bool hasRequiredKeys(ABHashtable<object, object> resultHashtable)
    {
        AbeClientInformationData abeClientInformationData = AbeClientInformationData.getInstance();
        if (resultHashtable.containsKey(abeClientInformationData.LICENSEID) && resultHashtable.containsKey(abeClientInformationData.LICENSESERVERS) && resultHashtable.containsKey(abeClientInformationData.KEY) && resultHashtable.containsKey(abeClientInformationData.LICENSE_TYPE)) {
            return true;
        } else {
            return false;
        }
    }

    public virtual bool hasKey()
    {
        return this.isValid();
    }

    public virtual string getKey(string keyName)
    {
        return ((string) this.hashtable.get(keyName));
    }

    public virtual string getLicenseId()
    {
        return this.id;
    }

    public virtual BasicArrayList getServers()
    {
        return this.servers;
    }

    public virtual bool isValid()
    {
        StringValidationUtil stringValidationUtil = StringValidationUtil.getInstance();
        if (!stringValidationUtil.isEmpty(this.getKey(AbeClientInformationData.getInstance().KEY))) {
            return true;
        }
        return false;
    }

    public override string ToString()
    {
        StringMaker stringBuffer = new StringMaker();
        string BREAK = "<br/>";
        stringBuffer.append("License Id: ");
        stringBuffer.append(this.getLicenseId());
        stringBuffer.append(BREAK);
        stringBuffer.append("Is Valid: ");
        stringBuffer.appendboolean(this.isValid());
        stringBuffer.append(BREAK);
        stringBuffer.append("Keys: ");
        stringBuffer.append(this.hashtable.ToString());
        stringBuffer.append(BREAK);
        BasicArrayList serverVector = this.getServers();
        int size = serverVector.size();
        for (int index = 0; index < size; index++) {
            string nextServerString = ((string) serverVector.get(index));
            stringBuffer.append("Server: ");
            stringBuffer.append(nextServerString);
            stringBuffer.append(BREAK);
        }
        return stringBuffer.ToString();
    }

    private void setSpecial(string special)
    {
        this.special = special;
    }

    public virtual string getSpecial()
    {
        return this.special;
    }

    public virtual LicenseType getLicenseType()
    {
        return this.licenseType;
    }

}

