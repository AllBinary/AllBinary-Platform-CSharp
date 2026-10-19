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
//using ByteArrayInputStream = java.io.ByteArrayInputStream;
//using InputStream = java.io.InputStream;
using Globals = org.allbinary.globals.Globals;
using URLGLOBALS = org.allbinary.globals.URLGLOBALS;
using BasicTextJDialog = org.allbinary.gui.dialog.BasicTextJDialog;
using ExitCloseListener = org.allbinary.gui.dialog.ExitCloseListener;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using AbCryptUtil = org.allbinary.logic.system.security.AbCryptUtil;
using AbKeys = org.allbinary.logic.system.security.AbKeys;
using AbeClientInformationInterface = org.allbinary.logic.system.security.licensing.AbeClientInformationInterface;
using AbeLicenseInterface = org.allbinary.logic.system.security.licensing.AbeLicenseInterface;
using AbeLicenseInterfaceFactory = org.allbinary.logic.system.security.licensing.AbeLicenseInterfaceFactory;
using AbeNoLicense = org.allbinary.logic.system.security.licensing.AbeNoLicense;
using LicensingException = org.allbinary.logic.system.security.licensing.LicensingException;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.bundle.logic.system.loader;

public class CryptService
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private readonly AbCryptUtil abCryptUtil = AbCryptUtil.getInstance();
    public CryptService()
    {
        Globals.getInstance().init(this.GetType().getClassLoader(), "./");
        this.logUtil.putF("Set Globals: " + URLGLOBALS.getWebappPath(), this, this.commonStrings.CONSTRUCTOR);
    }

    public virtual InputStream getDecryptedInputStream(AbeClientInformationInterface abeClientInformation, string name, InputStream inputStream)
    {
        try {
            string key = AbKeys.getInstance().getKey(abeClientInformation, name);
            sbyte[] decrypted = this.abCryptUtil.decrypt(inputStream, key);
            return new ByteArrayInputStream(decrypted);
        } catch (LicensingException e) {
            this.showLicenseDialog(abeClientInformation, e);
        } catch (Exception e) {
            this.showLicenseDialog(abeClientInformation, e);
        }
        return null;
    }

    private void showLicenseDialog(AbeClientInformationInterface abeClientInformation, Exception e)
    {
        try {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.INIT, e);
            BasicTextJDialog basicTextJDialog = new BasicTextJDialog(e.Message);
            try {
                AbeLicenseInterface abeLicenseInterface = AbeLicenseInterfaceFactory.getInstance().getLicenseInstance(abeClientInformation);
                if (abeLicenseInterface != AbeNoLicense.getInstance()) {
                    if (abeLicenseInterface.isValid()) {
                        basicTextJDialog.setText("Subscription Invalid");
                    }
                }
            } catch (LicensingException e2) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.INIT, e2);
            }
            basicTextJDialog.addCloseListener(new ExitCloseListener());
            basicTextJDialog.setVisible(true);
        } catch (Exception e3) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.INIT, e3);
        }
    }

}

