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
using StoreFrontInterface = org.allbinary.business.context.modules.storefront.StoreFrontInterface;
using StoreFrontsEntity = org.allbinary.data.tables.context.module.storefronts.StoreFrontsEntity;
using StoreFrontsEntityFactory = org.allbinary.data.tables.context.module.storefronts.StoreFrontsEntityFactory;
using PATH_GLOBALS = org.allbinary.globals.PATH_GLOBALS;
using URLGLOBALS = org.allbinary.globals.URLGLOBALS;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using PreLogUtil = org.allbinary.logic.communication.log.PreLogUtil;
using AbFile = org.allbinary.logic.io.file.AbFile;
using Directory = org.allbinary.logic.io.file.directory.Directory;
using ZipFileUtil = org.allbinary.logic.io.file.zip.ZipFileUtil;
using AbPath = org.allbinary.logic.io.path.AbPath;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.business.backup;

public class BlisketBackupFactory
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly BlisketBackupFactory instance = new BlisketBackupFactory();
    public static BlisketBackupFactory getInstance()
    {
        return BlisketBackupFactory.instance;
    }

    private readonly StringUtil stringUtil = StringUtil.getInstance();
    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private readonly Directory directory = Directory.getInstance();
    // throws Exception
    private BasicArrayList getFileBasicArrayList(string pathString)
    {
        AbPath path = new AbPath(pathString, this.stringUtil.EMPTY_STRING);
        AbFile file = AbFile.createAbFileFromAbPath(path);
        return this.directory.search(file, true);
    }

    public virtual void backup()
    {
        try {
            this.logUtil.putF(this.commonStrings.START, this, "backup()");
            StringMaker stringBuffer = new StringMaker();
            stringBuffer.append(URLGLOBALS.getWebappPath());
            stringBuffer.append(PATH_GLOBALS.getInstance().BACKUP_PATH);
            string backupPath = stringBuffer.ToString();
            AbPath path = new AbPath(backupPath, this.stringUtil.EMPTY_STRING);
            BasicArrayList fileBasicArrayList = this.getFileBasicArrayList(backupPath);
            this.backup(fileBasicArrayList, path.toFileSystemString() + "backup.zip");
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "backup()", e);
        }
    }

    public virtual void backupViews()
    {
        try {
            this.logUtil.putF(this.commonStrings.START, this, "backupViews()");
            StringMaker stringBuffer = new StringMaker();
            stringBuffer.append(URLGLOBALS.getWebappPath());
            stringBuffer.append(PATH_GLOBALS.getInstance().BACKUP_PATH);
            string backupPath = stringBuffer.ToString();
            AbPath path = new AbPath(backupPath, this.stringUtil.EMPTY_STRING);
            BasicArrayList fileBasicArrayList = new BasicArrayListD();
            StoreFrontsEntity storeFrontsEntity = StoreFrontsEntityFactory.getInstance().getStoreFrontsEntityInstance();
            BasicArrayList storeFrontNamesBasicArrayList = storeFrontsEntity.getStoreFrontNames();
            int size = storeFrontNamesBasicArrayList.size();
            string nextStore = null;
            string viewsPath = null;
            for (int index = 0; index < size; index++) {
                nextStore = ((string) storeFrontNamesBasicArrayList.get(index));
                stringBuffer.delete(0, stringBuffer.length());
                stringBuffer.append(URLGLOBALS.getWebappPath());
                stringBuffer.append(PATH_GLOBALS.getInstance().VIEWS_PATH);
                stringBuffer.append(nextStore);
                viewsPath = stringBuffer.ToString();
                stringBuffer.delete(0, stringBuffer.length());
                stringBuffer.append("Backup Store Views: ");
                stringBuffer.append(nextStore);
                stringBuffer.append(" from: ");
                stringBuffer.append(viewsPath);
                PreLogUtil.put(stringBuffer.ToString(), this, "backupViews()");
                fileBasicArrayList.addAllList(this.getFileBasicArrayList(viewsPath));
            }
            this.backup(fileBasicArrayList, path.toFileSystemString() + "backupViews.zip");
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "backupViews()", e);
        }
    }

    public virtual void backupResources()
    {
        try {
            this.logUtil.putF(this.commonStrings.START, this, "backupResources()");
            StringMaker stringBuffer = new StringMaker();
            stringBuffer.append(URLGLOBALS.getWebappPath());
            stringBuffer.append(PATH_GLOBALS.getInstance().BACKUP_PATH);
            string backupPath = stringBuffer.ToString();
            AbPath path = new AbPath(backupPath, this.stringUtil.EMPTY_STRING);
            BasicArrayList fileBasicArrayList = new BasicArrayListD();
            StoreFrontsEntity storeFrontsEntity = StoreFrontsEntityFactory.getInstance().getStoreFrontsEntityInstance();
            BasicArrayList storeFrontNamesBasicArrayList = storeFrontsEntity.getStoreFrontNames();
            int size = storeFrontNamesBasicArrayList.size();
            string nextStore = null;
            StoreFrontInterface storeFrontInterface = null;
            string resourcesPath = null;
            for (int index = 0; index < size; index++) {
                nextStore = ((string) storeFrontNamesBasicArrayList.get(index));
                storeFrontInterface = storeFrontsEntity.getStoreFrontInterface(nextStore);
                stringBuffer.delete(0, stringBuffer.length());
                stringBuffer.append(URLGLOBALS.getWebappPath());
                stringBuffer.append(storeFrontInterface.getCurrentHostNamePath());
                stringBuffer.append(storeFrontInterface.getCategoryPath());
                resourcesPath = stringBuffer.ToString();
                stringBuffer.delete(0, stringBuffer.length());
                stringBuffer.append("Backup Store Resrouces: ");
                stringBuffer.append(nextStore);
                stringBuffer.append(" from: ");
                stringBuffer.append(resourcesPath);
                PreLogUtil.put(stringBuffer.ToString(), this, "backupResources()");
                fileBasicArrayList.addAllList(this.getFileBasicArrayList(resourcesPath));
            }
            this.backup(fileBasicArrayList, path.toFileSystemString() + "backupResources.zip");
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "backupResources()", e);
        }
    }

    public virtual void backupJsps()
    {
        try {
            this.logUtil.putF(this.commonStrings.START, this, "backupJsps()");
            StringMaker stringBuffer = new StringMaker();
            stringBuffer.append(URLGLOBALS.getWebappPath());
            stringBuffer.append(PATH_GLOBALS.getInstance().BACKUP_PATH);
            string backupPath = stringBuffer.ToString();
            AbPath path = new AbPath(backupPath, this.stringUtil.EMPTY_STRING);
            BasicArrayList fileBasicArrayList = new BasicArrayListD();
            StoreFrontsEntity storeFrontsEntity = StoreFrontsEntityFactory.getInstance().getStoreFrontsEntityInstance();
            BasicArrayList storeFrontNamesBasicArrayList = storeFrontsEntity.getStoreFrontNames();
            int size = storeFrontNamesBasicArrayList.size();
            string nextStore = null;
            for (int index = 0; index < size; index++) {
                nextStore = ((string) storeFrontNamesBasicArrayList.get(index));
                PreLogUtil.put("Backup Store Jsps: " + nextStore, this, "backupJsps()");
                stringBuffer.delete(0, stringBuffer.length());
                stringBuffer.append(URLGLOBALS.getWebappPath());
                stringBuffer.append(nextStore);
                fileBasicArrayList.addAllList(this.getFileBasicArrayList(stringBuffer.ToString()));
            }
            this.backup(fileBasicArrayList, path.toFileSystemString() + "backupJsps.zip");
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "backupJsps()", e);
        }
    }

    public virtual void backup(BasicArrayList fileBasicArrayList, string zipFile)
    {
        try {
            StringMaker stringBuffer = new StringMaker();
            stringBuffer.delete(0, stringBuffer.length());
            stringBuffer.append("ZipFile: ");
            stringBuffer.append(zipFile);
            stringBuffer.append(" BasicArrayList: ");
            stringBuffer.appendint(fileBasicArrayList.size());
            PreLogUtil.put("Creating Backup Zip File: " + stringBuffer.ToString(), this, "backup()");
            ZipFileUtil.getInstance().create(zipFile, fileBasicArrayList);
            this.logUtil.putF("Created Backup Zip File", this, "backup()");
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "backup()", e);
        }
    }

}

