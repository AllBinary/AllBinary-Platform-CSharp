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
//using FileFilter = java.io.FileFilter;
using PreLogUtil = org.allbinary.logic.communication.log.PreLogUtil;
using AbFile = org.allbinary.logic.io.file.AbFile;
using FileFactory = org.allbinary.logic.io.file.FileFactory;
using FileWrapperUtil = org.allbinary.logic.io.file.FileWrapperUtil;
using AbPath = org.allbinary.logic.io.path.AbPath;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.logic.io.file.directory;

public class Directory
{
    private static readonly Directory instance = new Directory();
    public static Directory getInstance()
    {
        return Directory.instance;
    }

    private Directory()
    {
    }

    public virtual bool create(AbPath directoryAbPath)
    {
        return this.create(directoryAbPath.toFileSystemString());
    }

    // throws Exception
    public virtual void remove(AbPath existingDirectoryAbPath)
    {
        this.remove(existingDirectoryAbPath.toFileSystemString());
    }

    private bool create(string directory)
    {
        try {
            AbFile directoryFile = FileFactory.getInstance().getInstance(directory);
            if (!directoryFile.isDirectory()) {
                PreLogUtil.put("Creating Directories: " + directory, this, "create");
                if (!directoryFile.mkdirs()) {
                    return false;
                }
            }
            return true;
        } catch (Exception e) {
            PreLogUtil.putOE("Error Creating Directories: " + directory, this, "create", e);
            return false;
        }
    }

    // throws Exception
    private void remove(string existingDirectory)
    {
        AbFile existingDirectoryFile = FileFactory.getInstance().getInstance(existingDirectory);
        if (existingDirectoryFile.isDirectory()) {
            if (existingDirectoryFile.list().Length > 0) {
                throw new Exception("Did not remove category: " + existingDirectory + " because files exist");
            } else if (existingDirectoryFile.delete()) {
                PreLogUtil.put("Successfully Removed: " + existingDirectory, "Directory", "remove");
            }
        } else {
            throw new Exception("Category Directory Is Missing:" + existingDirectory);
        }
    }

    public virtual BasicArrayList search(FileFilter fileFilter, AbFile file)
    {
        return this.search(fileFilter, file, false);
    }

    public virtual BasicArrayList search(FileFilter fileFilter, AbFile file, bool isRecursiveSearch)
    {
        BasicArrayList fileList = new BasicArrayListD();
        BasicArrayList recursiveFileList = null;
        if (file.isDirectory()) {
            object[] fileArray = file.listFilesFileFilter(fileFilter);
            if (fileArray == null) {
                return fileList;
            }
            AbFile[] files = FileWrapperUtil.wrapFiles(fileArray);
            if (files == null) {
                return fileList;
            }
            int size = files.Length;
            for (int index = 0; index < size; index++) {
                fileList.add(files[index]);
                if (isRecursiveSearch) {
                    recursiveFileList = this.search(fileFilter, files[index], isRecursiveSearch);
                    fileList.addAllList(recursiveFileList);
                }
            }
        }
        return fileList;
    }

    public virtual BasicArrayList search(AbFile file)
    {
        return this.search(file, false);
    }

    public virtual BasicArrayList search(AbFile file, bool isRecursiveSearch)
    {
        BasicArrayList fileList = new BasicArrayListD();
        BasicArrayList recursiveFileList = null;
        if (file.isDirectory()) {
            object[] fileArray = file.listFiles();
            if (fileArray == null) {
                return fileList;
            }
            AbFile[] files = FileWrapperUtil.wrapFiles(fileArray);
            if (files == null) {
                return fileList;
            }
            for (int index = 0; index < files.Length; index++) {
                fileList.add(files[index]);
                if (isRecursiveSearch) {
                    recursiveFileList = this.search(files[index], isRecursiveSearch);
                    fileList.addAllList(recursiveFileList);
                }
            }
        }
        return fileList;
    }

    public virtual BasicArrayList search(string searchValue, AbFile file)
    {
        return this.search(searchValue, file, false);
    }

    public virtual BasicArrayList search(string searchValue, AbFile file, bool isRecursiveSearch)
    {
        BasicArrayList fileList = new BasicArrayListD();
        BasicArrayList recursiveFileList = null;
        if (file.isDirectory()) {
            object[] fileArray = file.listFiles();
            if (fileArray == null) {
                return fileList;
            }
            AbFile[] files = FileWrapperUtil.wrapFiles(fileArray);
            if (files == null) {
                return fileList;
            }
            for (int index = 0; index < files.Length; index++) {
                if (files[index].getPath().indexOf(searchValue) >= 0) {
                    fileList.add(files[index]);
                }
                if (isRecursiveSearch) {
                    recursiveFileList = this.search(searchValue, files[index], isRecursiveSearch);
                    fileList.addAllList(recursiveFileList);
                }
            }
        }
        return fileList;
    }

    public virtual BasicArrayList search(int level, AbFile file)
    {
        return this.search(level, file, false);
    }

    public virtual BasicArrayList search(int level, AbFile file, bool isRecursiveSearch)
    {
        BasicArrayList fileList = new BasicArrayListD();
        BasicArrayList recursiveFileList = null;
        if (file.isDirectory()) {
            object[] fileArray = file.listFiles();
            if (fileArray == null) {
                return fileList;
            }
            AbFile[] files = FileWrapperUtil.wrapFiles(fileArray);
            if (files == null) {
                return fileList;
            }
            for (int index = 0; index < files.Length; index++) {
                fileList.add(files[index]);
                if (level <= 0) {
                    return fileList;
                }
                recursiveFileList = this.search(level - 1, files[index], isRecursiveSearch);
                fileList.addAllList(recursiveFileList);
            }
        }
        return fileList;
    }

}

