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
using System.Runtime.CompilerServices;
//using InputStream = java.io.InputStream;
//using OutputStream = java.io.OutputStream;
using URLGLOBALS = org.allbinary.globals.URLGLOBALS;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using PreLogUtil = org.allbinary.logic.communication.log.PreLogUtil;
using LogConfigTypeFactory = org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory;
using AbDataOutputStream = org.allbinary.logic.io.AbDataOutputStream;
using AbFileInputStream = org.allbinary.logic.io.AbFileInputStream;
using AbFileLocalInputStream = org.allbinary.logic.io.AbFileLocalInputStream;
using AbIOSystem = org.allbinary.logic.io.AbIOSystem;
using DataOutputStreamFactory = org.allbinary.logic.io.DataOutputStreamFactory;
using FileStreamFactory = org.allbinary.logic.io.FileStreamFactory;
using StreamUtil = org.allbinary.logic.io.StreamUtil;
using Directory = org.allbinary.logic.io.file.directory.Directory;
using AbPath = org.allbinary.logic.io.path.AbPath;
using AbPathData = org.allbinary.logic.io.path.AbPathData;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using CommonLabels = org.allbinary.@string.CommonLabels;
using CommonStrings = org.allbinary.@string.CommonStrings;
using BasicArrayList = org.allbinary.util.BasicArrayList;

namespace org.allbinary.logic.io.file;

//data/init/views/TestStore/template/type/genericTemplateObjectConfig.xml
public class FileUtil
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly FileUtil instance = new FileUtil();
    public static FileUtil getInstance()
    {
        return FileUtil.instance;
    }

    private readonly Directory directory = Directory.getInstance();
    private readonly LogConfigTypeFactory logConfigTypeFactory = LogConfigTypeFactory.getInstance();
    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private readonly StreamUtil streamUtil = StreamUtil.getInstance();
    private FileUtil()
    {
    }

    // throws Exception
    public virtual void write(InputStream inputStream, AbFile file)
    {
        AbDataOutputStream dataOutputStream = DataOutputStreamFactory.getInstance().getInstanceForAbFile(file);
        this.write(inputStream, dataOutputStream);
    }

    // throws Exception
    public virtual void write(InputStream inputStream, AbDataOutputStream dataOutputStream)
    {
        try {
            dataOutputStream = ((AbDataOutputStream) StreamUtil.getInstance().get(inputStream, dataOutputStream, new sbyte[16384]));
            dataOutputStream.flush();
        } finally {
            StreamUtil.getInstance().close(dataOutputStream);
        }
    }

    // throws Exception
    public virtual void write(InputStream inputStream, AbDataOutputStream dataOutputStream, sbyte[] buffer)
    {
        try {
            dataOutputStream = ((AbDataOutputStream) StreamUtil.getInstance().get(inputStream, dataOutputStream, buffer));
            dataOutputStream.flush();
        } finally {
            StreamUtil.getInstance().close(dataOutputStream);
        }
    }

    // throws Exception
    private void copy(AbFileInputStream dataInputStream, AbDataOutputStream dataOutputStream)
    {
        try {
            dataOutputStream = ((AbDataOutputStream) StreamUtil.getInstance().get(dataInputStream, dataOutputStream, new sbyte[16384]));
            dataOutputStream.flush();
        } finally {
            StreamUtil.getInstance().close(dataOutputStream);
            StreamUtil.getInstance().close(dataInputStream);
        }
    }

    // throws Exception
    private AbPath fixPath(AbFile file, AbPath path, AbPath realPath, string cloud)
    {
        int beginIndex = file.getPath().indexOf(cloud) + cloud.Length;
        int endIndex = file.getPath().indexOf(file.getName());
        string fixedPathString = realPath.toFileSystemString() + file.getPath().substring(beginIndex, endIndex);
        AbPath fixedPath = new AbPath(fixedPathString, StringUtil.getInstance().EMPTY_STRING);
        this.directory.create(fixedPath);
        string @string = fixedPath.toFileSystemString();
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(this.logConfigTypeFactory.FILE)) {
            this.logUtil.putF(@string, this, "fixPath");
        }
        AbPath outPath = new AbPath(@string, file.getName());
        return outPath;
    }

    // throws Exception
    public virtual void copyToCloud(AbFile file, AbPath path, AbPath realPath, string cloud)
    {
        this.copyToCloud(file, path, realPath, cloud, false, false);
    }

    // throws Exception
    public virtual void copyToCloud(AbFile file, AbPath path, AbPath realPath, string cloud, bool overwriteNewer, bool overwriteAll)
    {
        try {
            AbPath outPath = this.fixPath(file, path, realPath, cloud);
            AbFile outFile = AbFile.createAbFileFromAbPath(outPath);
            if (!this.copyPrepare(file, outFile, overwriteNewer, overwriteAll)) {
                return;
            } else {
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(this.logConfigTypeFactory.FILE)) {
                    StringMaker stringBuffer = new StringMaker();
                    stringBuffer.append("Out File: ");
                    stringBuffer.append(outFile.getPath());
                    stringBuffer.append(" In File: ");
                    stringBuffer.append(file.getPath());
                    stringBuffer.append(" to cloud.");
                    this.logUtil.putF(stringBuffer.ToString(), getInstance(), "copyToCloud");
                }
            }
            AbDataOutputStream dataOutputStream = DataOutputStreamFactory.getInstance().getInstanceForAbFile(outFile);
            AbFileInputStream fileInputStream = new AbFileLocalInputStream(file);
            this.copy(fileInputStream, dataOutputStream);
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(this.logConfigTypeFactory.FILEERROR)) {
                StringMaker stringBuffer = new StringMaker();
                stringBuffer.append("Error Copying File File: ");
                stringBuffer.append(file.ToString());
                stringBuffer.append(" to cloud.");
                this.logUtil.put(stringBuffer.ToString(), getInstance(), "copyToCloud", e);
            }
            throw e;
        }
    }

    // throws Exception
    public virtual void copyToCloud(AbFile file, AbFile outFile)
    {
        this.copyToCloud(file, outFile, false, false);
    }

    // throws Exception
    public virtual void copyToCloud(AbFile file, AbFile outFile, bool overwriteNewer, bool overwriteAll)
    {
        try {
            StringMaker stringBuffer = new StringMaker();
            if (!this.copyPrepare(file, outFile, overwriteNewer, overwriteAll)) {
                return;
            } else {
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(this.logConfigTypeFactory.FILE)) {
                    stringBuffer.delete(0, stringBuffer.length());
                    stringBuffer.append("Out File: ");
                    stringBuffer.append(outFile.getPath());
                    stringBuffer.append(" In File: ");
                    stringBuffer.append(file.getPath());
                    stringBuffer.append(" to cloud.");
                    this.logUtil.putF(stringBuffer.ToString(), getInstance(), "copyToCloud");
                }
            }
            AbDataOutputStream dataOutputStream = DataOutputStreamFactory.getInstance().getInstanceForAbFile(outFile);
            AbFileInputStream fileInputStream = new AbFileLocalInputStream(file);
            this.copy(fileInputStream, dataOutputStream);
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(this.logConfigTypeFactory.FILEERROR)) {
                StringMaker stringBuffer = new StringMaker();
                stringBuffer.append("Error Copying File File: ");
                stringBuffer.append(file.ToString());
                stringBuffer.append(" to cloud.");
                this.logUtil.put(stringBuffer.ToString(), getInstance(), "copyToCloud", e);
            }
            throw e;
        }
    }

    // throws Exception
    private bool copyPrepare(AbFile fromFile, AbFile toFile, bool overwriteNewer, bool overwriteAll)
    {
        if (toFile.exists()) {
            StringMaker stringBuffer = new StringMaker();
            if (overwriteAll) {
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(this.logConfigTypeFactory.FILE)) {
                    stringBuffer.delete(0, stringBuffer.length());
                    stringBuffer.append("Overwriting File: ");
                    stringBuffer.append(toFile.getPath());
                    this.logUtil.putF(stringBuffer.ToString(), getInstance(), "copyFile");
                }
                toFile.delete();
                toFile.createNewFile();
            } else if (toFile.lastModified() < fromFile.lastModified() && overwriteNewer) {
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(this.logConfigTypeFactory.FILE)) {
                    stringBuffer.delete(0, stringBuffer.length());
                    stringBuffer.append("Newer by: ");
                    stringBuffer.appendlong(((long) (fromFile.lastModified() - toFile.lastModified())));
                    stringBuffer.append("ms ");
                    stringBuffer.append("Copying File: ");
                    stringBuffer.append(toFile.getPath());
                    this.logUtil.putF(stringBuffer.ToString(), getInstance(), "copyFile");
                }
                toFile.delete();
                toFile.createNewFile();
            } else {
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(this.logConfigTypeFactory.FILE)) {
                    stringBuffer.delete(0, stringBuffer.length());
                    stringBuffer.append("File Already Exists");
                    if (overwriteNewer) {
                        stringBuffer.append(" And Is Not Older");
                    } else {
                        stringBuffer.append(" And Not A In Overwrite Mode");
                    }
                    stringBuffer.append(CommonLabels.getInstance().COLON_SEP);
                    stringBuffer.append(toFile.getPath());
                    this.logUtil.putF(stringBuffer.ToString(), getInstance(), "copyFile");
                }
                return false;
            }
        } else {
            toFile.createNewFile();
        }
        return true;
    }

    // throws Exception
    private void copyFile(AbFile fromFile, AbFile toFile)
    {
        this.copyFile(fromFile, toFile, false, false);
    }

    // throws Exception
    private void copyFile(AbFile fromFile, AbFile toFile, bool overwriteNewer, bool overwriteAll)
    {
        try {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(this.logConfigTypeFactory.FILE)) {
                StringMaker stringBuffer = new StringMaker();
                stringBuffer.append("Copying ");
                stringBuffer.appendlong(((long) fromFile.length()));
                stringBuffer.append(" bytes from File: ");
                stringBuffer.append(fromFile.getPath());
                stringBuffer.append(" to: ");
                stringBuffer.append(toFile.getPath());
                this.logUtil.putF(stringBuffer.ToString(), getInstance(), "copyFile");
            }
            if (!this.copyPrepare(fromFile, toFile, overwriteNewer, overwriteAll)) {
                return;
            }
            AbDataOutputStream dataOutputStream = DataOutputStreamFactory.getInstance().getInstanceForAbFile(toFile);
            AbFileInputStream fileInputStream = new AbFileInputStream(fromFile);
            this.copy(fileInputStream, dataOutputStream);
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(this.logConfigTypeFactory.FILEERROR)) {
                StringMaker stringBuffer = new StringMaker();
                stringBuffer.append("Error Copying File fromFile: ");
                stringBuffer.append(fromFile.ToString());
                stringBuffer.append(" to: ");
                stringBuffer.append(toFile.ToString());
                this.logUtil.put(stringBuffer.ToString(), getInstance(), "copyFile", e);
            }
            throw e;
        }
    }

    private static string getNewDirectory(AbFile fromFile)
    {
        string newDirectory = fromFile.getPath();
        string separatorChar = FilePathData.getInstance().PATH_START;
        if (AbIOSystem.getInstance().isType("com.vobject.appengine.java.io")) {
            separatorChar = AbPathData.getInstance().SEPARATOR;
        }
        int lastIndex = newDirectory.LastIndexOf(separatorChar);
        if (lastIndex >= newDirectory.Length) {
            newDirectory = newDirectory.Substring(0, (newDirectory.Length - 1) - (0));
            lastIndex = newDirectory.LastIndexOf(separatorChar);
        }
        return newDirectory.Substring(lastIndex, (newDirectory.Length) - (lastIndex));
    }

    // throws Exception
    public virtual void copyDirectoryPortion(AbPath fromDirectoryAbPath, AbPath toDirectoryAbPath, bool overwriteNewer, bool overwriteAll, int current, int total)
    {
        AbFile file = AbFile.createAbFileFromAbPath(fromDirectoryAbPath);
        if (!file.isDirectory()) {
            throw new Exception("Not a directory: " + file.getPath());
        }
        BasicArrayList fileList = this.directory.search(file, true);
        int size = fileList.size();
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append("Searched: ");
        stringBuffer.append(file.getPath());
        stringBuffer.append(" Total: ");
        stringBuffer.appendint(size);
        int portion = size / total + 1;
        int start = portion * current;
        int end = start + portion;
        if (end > size) {
            end = size;
        }
        stringBuffer.append(" Section: ");
        stringBuffer.appendint(start);
        stringBuffer.append(" - ");
        stringBuffer.appendint(end);
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(this.logConfigTypeFactory.FILE)) {
            this.logUtil.putF(stringBuffer.ToString(), getInstance(), "copySomeFilesToDirectory()");
        }
        AbFile nextFile = null;
        for (int index = start; index < end; index++) {
            nextFile = ((AbFile) fileList.get(index));
            if (nextFile.isDirectory()) {
            } else {
                string path = new AbPath(nextFile.getPath(), StringUtil.getInstance().EMPTY_STRING).getPath();
                int beginIndex = fromDirectoryAbPath.getPath().length();
                if (path.indexOf(URLGLOBALS.getWebappPath()) < 0) {
                    beginIndex -= new AbPath(URLGLOBALS.getWebappPath(), StringUtil.getInstance().EMPTY_STRING).getPath().length();
                }
                string newPath = toDirectoryAbPath.toFileSystemString() + path.substring(beginIndex);
                AbFile toFile = AbFile.createAbFileFromAbPath(new AbPath(newPath, StringUtil.getInstance().EMPTY_STRING));
                this.copyFile(nextFile, toFile, overwriteNewer, overwriteAll);
            }
        }
    }

    // throws Exception
    private void copyDirectory(AbFile fromFile, AbFile to)
    {
        try {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(this.logConfigTypeFactory.FILE)) {
                StringMaker stringBuffer = new StringMaker();
                stringBuffer.append("Copying Directory from: ");
                stringBuffer.append(fromFile.getPath());
                stringBuffer.append(" to: ");
                stringBuffer.append(to.getPath());
                this.logUtil.putF(stringBuffer.ToString(), getInstance(), "copyDirectory");
            }
            string newDirectory = FileUtil.getNewDirectory(fromFile);
            AbPath newDirectoryAbPath = new AbPath(to.getPath() + AbPathData.getInstance().SEPARATOR + newDirectory, StringUtil.getInstance().EMPTY_STRING);
            if (!this.directory.create(newDirectoryAbPath)) {
                throw new Exception("Failed to create directory: " + newDirectoryAbPath);
            }
            AbFile[] fileArray = FileWrapperUtil.wrapFiles(fromFile.listFiles());
            int size = fileArray.Length;
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(this.logConfigTypeFactory.FILE)) {
                StringMaker stringBuffer = new StringMaker();
                stringBuffer.append("Copying ");
                stringBuffer.appendint(size);
                stringBuffer.append(" files from: ");
                stringBuffer.append(fromFile.getPath());
                stringBuffer.append(" to: ");
                stringBuffer.append(to.getPath());
                this.logUtil.putF(stringBuffer.ToString(), getInstance(), "copyDirectory");
            }
            AbFile file = null;
            for (int index = 0; index < size; index++) {
                file = fileArray[index];
                if (file.isFile()) {
                    this.copyFile(file, AbFile.createAbFilePathAndName(newDirectoryAbPath.ToString(), file.getName()));
                } else if (file.isDirectory()) {
                    this.copyDirectory(file, AbFile.createAbFileFromAbPath(newDirectoryAbPath));
                } else {
                    throw new Exception("File Copy Error");
                }
            }
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(this.logConfigTypeFactory.FILEERROR)) {
                StringMaker stringBuffer = new StringMaker();
                stringBuffer.append("Error Copying Directory fromFile: ");
                stringBuffer.append(fromFile.ToString());
                stringBuffer.append(" to: ");
                stringBuffer.append(to.ToString());
                this.logUtil.put(stringBuffer.ToString(), getInstance(), "copyDirectory", e);
            }
            throw e;
        }
    }

    // throws Exception
    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual bool copy(AbPath fromAbPath, AbPath to)
    {
        string COPY = "copy";
        try {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(this.logConfigTypeFactory.FILE)) {
                StringMaker stringBuffer = new StringMaker();
                stringBuffer.append("Copying AbPaths from: ");
                stringBuffer.append(fromAbPath.ToString());
                stringBuffer.append(" to: ");
                stringBuffer.append(to.ToString());
                this.logUtil.putF(stringBuffer.ToString(), getInstance(), COPY);
            }
            if (fromAbPath == null) {
                throw new Exception("Cannot Copy From A Null Location");
            }
            if (to == null) {
                throw new Exception("Cannot Copy To A Null Location");
            }
            AbFile fromLocationFile = AbFile.createAbFileFromAbPath(fromAbPath);
            AbFile toLocationFile = AbFile.createAbFileFromAbPath(to);
            if (fromLocationFile.isFile()) {
                if (toLocationFile.isDirectory()) {
                    AbFile file = AbFile.createAbFileWithChild(toLocationFile, fromLocationFile.getName());
                    this.copyFile(fromLocationFile, file);
                    if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(this.logConfigTypeFactory.FILE)) {
                        StringMaker stringBuffer = new StringMaker();
                        stringBuffer.append("Copied file=");
                        stringBuffer.append(fromLocationFile.getName());
                        stringBuffer.append(" from: ");
                        stringBuffer.append(fromLocationFile.getPath());
                        stringBuffer.append(" to: ");
                        stringBuffer.append(toLocationFile.getPath());
                        this.logUtil.putF(stringBuffer.ToString(), getInstance(), COPY);
                    }
                } else {
                    this.copyFile(fromLocationFile, toLocationFile);
                    if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(this.logConfigTypeFactory.FILE)) {
                        StringMaker stringBuffer = new StringMaker();
                        stringBuffer.append("Copied file with new name ");
                        stringBuffer.append(" from: ");
                        stringBuffer.append(fromLocationFile.getPath());
                        stringBuffer.append(" to: ");
                        stringBuffer.append(toLocationFile.getPath());
                        this.logUtil.putF(stringBuffer.ToString(), getInstance(), COPY);
                    }
                }
            } else if (fromLocationFile.isDirectory() && toLocationFile.isDirectory()) {
                if (fromAbPath.toFileSystemString().charAt(fromAbPath.toFileSystemString().length() - 1) == java.io.File.separatorChar) {
                    if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(this.logConfigTypeFactory.FILE)) {
                        this.logUtil.putF("Copying subdirectories", getInstance(), COPY);
                    }
                    AbFile[] fileArray = FileWrapperUtil.wrapFiles(fromLocationFile.listFiles());
                    for (int index = 0; index < fileArray.Length; index++) {
                        AbFile file = fileArray[index];
                        if (file.isFile()) {
                            AbFile aFile = AbFile.createAbFileWithChild(toLocationFile, file.getName());
                            this.copyFile(file, aFile);
                        } else if (file.isDirectory()) {
                            this.copyDirectory(file, toLocationFile);
                        } else {
                            throw new Exception("File Copy Error");
                        }
                    }
                    if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(this.logConfigTypeFactory.FILE)) {
                        this.logUtil.putF("Copied subdirectories", getInstance(), COPY);
                    }
                } else {
                    if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(this.logConfigTypeFactory.FILE)) {
                        this.logUtil.putF("Copyinhg directory", getInstance(), COPY);
                    }
                    this.copyDirectory(fromLocationFile, toLocationFile);
                    if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(this.logConfigTypeFactory.FILE)) {
                        this.logUtil.putF("Copied directory", getInstance(), COPY);
                    }
                }
            }
            return true;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(this.logConfigTypeFactory.FILEERROR)) {
                StringMaker stringBuffer = new StringMaker();
                stringBuffer.append("Error Copying fromAbPath: ");
                stringBuffer.append(fromAbPath.ToString());
                stringBuffer.append(" to: ");
                stringBuffer.append(to.ToString());
                this.logUtil.put(stringBuffer.ToString(), getInstance(), COPY, e);
            }
            throw e;
        }
    }

    public virtual bool shouldSkip(AbFile file, string[] skipFiles)
    {
        int size = skipFiles.Length;
        string skipFile = null;
        for (int index = 0; index < size; index++) {
            skipFile = skipFiles[index];
            if (file.getPath().compareTo(skipFile) == 0) {
                return true;
            }
        }
        return false;
    }

    private readonly string WRITE_LABEL = "Write file: ";
    private readonly string DATA_LABEL = " data: ";
    private readonly string WRITE_METHOD = "write";
    // throws Exception
    public virtual void write(string filePath, string @string)
    {
        AbDataOutputStream dataOutputStream = null;
        try {
            PreLogUtil.put(new StringMaker().append(this.WRITE_LABEL).append(filePath).append(this.DATA_LABEL).append(@string).ToString(), this, this.WRITE_METHOD);
            FileStreamFactory fileInputStreamFactory = FileStreamFactory.getInstance();
            OutputStream fileOutputStream = fileInputStreamFactory.getFileOutputStreamInstance(StringUtil.getInstance().EMPTY_STRING, filePath);
            dataOutputStream = new AbDataOutputStream(fileOutputStream);
            dataOutputStream.write(System.Array.ConvertAll(System.Text.Encoding.UTF8.GetBytes(@string), value => unchecked((sbyte) value)), 0, @string.Length);
            dataOutputStream.flush();
        } finally {
            StreamUtil.getInstance().close(dataOutputStream);
        }
    }

    public virtual BasicArrayList loadFileAsList(AbFile file, int max, sbyte[] byteArray1)
    {
        return FileUtil2.getInstance().loadFileAsList(file, max, byteArray1);
    }

}

