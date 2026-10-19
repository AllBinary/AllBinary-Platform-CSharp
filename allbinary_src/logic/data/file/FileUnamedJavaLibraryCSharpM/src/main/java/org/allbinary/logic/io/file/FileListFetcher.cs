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
using DirectoryBooleanFileVisitor = org.allbinary.logic.io.file.directory.DirectoryBooleanFileVisitor;
using DirectoryOrIncludeFileExtensionAndTrackedBooleanFileVisitor = org.allbinary.logic.io.file.directory.DirectoryOrIncludeFileExtensionAndTrackedBooleanFileVisitor;
using DirectoryOrIncludeFileExtensionBooleanFileVisitor = org.allbinary.logic.io.file.directory.DirectoryOrIncludeFileExtensionBooleanFileVisitor;
using SubDirectory = org.allbinary.logic.io.file.directory.SubDirectory;
using VisitorFileFilter = org.allbinary.logic.io.file.filter.VisitorFileFilter;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.logic.io.file;

public class FileListFetcher
{
    private static readonly FileListFetcher instance = new FileListFetcher();
    public static FileListFetcher getInstance()
    {
        return FileListFetcher.instance;
    }

    private readonly SubDirectory subDirectory = SubDirectory.getInstance();
    public virtual BasicArrayList getFiles(string path)
    {
        try {
            BasicArrayList files = this.subDirectory.search(AbFile.createAbFile(path));
            return files;
        } catch (Exception e) {
            Console.WriteLine(e);
            Console.WriteLine("Error: " + e + "\nMsg: " + e.Message);
        }
        return null;
    }

    public virtual BasicArrayList getFiles(string path, string[] includeExtensions)
    {
        try {
            BasicArrayList includeExtensionBasicArrayList = new BasicArrayListD();
            int size = includeExtensions.Length;
            for (int index = 0; index < size; index++) {
                includeExtensionBasicArrayList.add(includeExtensions[index]);
            }
            VisitorFileFilter visitorFileFilter = new VisitorFileFilter(new DirectoryOrIncludeFileExtensionBooleanFileVisitor(includeExtensionBasicArrayList));
            BasicArrayList files = this.subDirectory.search(visitorFileFilter, AbFile.createAbFile(path));
            return files;
        } catch (Exception e) {
            Console.WriteLine(e);
            Console.WriteLine("Error: " + e + "\nMsg: " + e.Message);
        }
        return null;
    }

    public virtual BasicArrayList getFiles(string path, string includeExtension)
    {
        try {
            BasicArrayList includeExtensionBasicArrayList = new BasicArrayListD();
            includeExtensionBasicArrayList.add(includeExtension);
            VisitorFileFilter visitorFileFilter = new VisitorFileFilter(new DirectoryOrIncludeFileExtensionBooleanFileVisitor(includeExtensionBasicArrayList));
            BasicArrayList files = this.subDirectory.search(visitorFileFilter, AbFile.createAbFile(path));
            return files;
        } catch (Exception e) {
            Console.WriteLine(e);
            Console.WriteLine("Error: " + e + "\nMsg: " + e.Message);
        }
        return null;
    }

    public virtual BasicArrayList getFiles(string path, string pathIncludes, string includeExtension)
    {
        try {
            BasicArrayList includeExtensionBasicArrayList = new BasicArrayListD();
            includeExtensionBasicArrayList.add(includeExtension);
            VisitorFileFilter visitorFileFilter = new VisitorFileFilter(new DirectoryOrIncludeFileExtensionBooleanFileVisitor(includeExtensionBasicArrayList, pathIncludes));
            BasicArrayList files = this.subDirectory.search(visitorFileFilter, AbFile.createAbFile(path));
            return files;
        } catch (Exception e) {
            Console.WriteLine(e);
            Console.WriteLine("Error: " + e + "\nMsg: " + e.Message);
        }
        return null;
    }

    public virtual BasicArrayList getTrackedFiles(string path, string[] includeExtensions)
    {
        try {
            BasicArrayList includeExtensionBasicArrayList = new BasicArrayListD();
            int size = includeExtensions.Length;
            for (int index = 0; index < size; index++) {
                includeExtensionBasicArrayList.add(includeExtensions[index]);
            }
            VisitorFileFilter visitorFileFilter = new VisitorFileFilter(new DirectoryOrIncludeFileExtensionAndTrackedBooleanFileVisitor(includeExtensionBasicArrayList));
            BasicArrayList files = this.subDirectory.search(visitorFileFilter, AbFile.createAbFile(path));
            return files;
        } catch (Exception e) {
            Console.WriteLine(e);
            Console.WriteLine("Error: " + e + "\nMsg: " + e.Message);
        }
        return null;
    }

    public virtual BasicArrayList getTrackedFiles(string path, string includeExtension)
    {
        try {
            BasicArrayList includeExtensionBasicArrayList = new BasicArrayListD();
            includeExtensionBasicArrayList.add(includeExtension);
            VisitorFileFilter visitorFileFilter = new VisitorFileFilter(new DirectoryOrIncludeFileExtensionAndTrackedBooleanFileVisitor(includeExtensionBasicArrayList));
            BasicArrayList files = this.subDirectory.search(visitorFileFilter, AbFile.createAbFile(path));
            return files;
        } catch (Exception e) {
            Console.WriteLine(e);
            Console.WriteLine("Error: " + e + "\nMsg: " + e.Message);
        }
        return null;
    }

    public virtual BasicArrayList getDirectories(string path)
    {
        try {
            VisitorFileFilter visitorFileFilter = new VisitorFileFilter(new DirectoryBooleanFileVisitor());
            BasicArrayList files = this.subDirectory.search(visitorFileFilter, AbFile.createAbFile(path));
            return files;
        } catch (Exception e) {
            Console.WriteLine(e);
            Console.WriteLine("Error: " + e + "\nMsg: " + e.Message);
        }
        return null;
    }

}

