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
using GitProcessHelper = org.allbinary.java.runtime.process.git.GitProcessHelper;
using AbFile = org.allbinary.logic.io.file.AbFile;
using CommonDataFileStrings = org.allbinary.logic.io.file.CommonDataFileStrings;
using IncludeFileExtensionsBooleanFileVisitor = org.allbinary.logic.io.file.visitor.IncludeFileExtensionsBooleanFileVisitor;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.logic.io.file.directory;

public class DirectoryOrIncludeFileExtensionAndTrackedBooleanFileVisitor : IncludeFileExtensionsBooleanFileVisitor
{
    private readonly TrackedStrings trackedStrings = TrackedStrings.getInstance();
    private readonly GitProcessHelper gitProcessHelper = GitProcessHelper.getInstance();
    private readonly string includesString;
    public DirectoryOrIncludeFileExtensionAndTrackedBooleanFileVisitor(BasicArrayList filterStringBasicArrayList) : base(filterStringBasicArrayList)
    {
        // base(filterStringBasicArrayList) is called from the constructor declaration
        this.includesString = null;
    }

    public DirectoryOrIncludeFileExtensionAndTrackedBooleanFileVisitor(BasicArrayList filterStringBasicArrayList, string includesString) : base(filterStringBasicArrayList)
    {
        // base(filterStringBasicArrayList) is called from the constructor declaration
        this.includesString = includesString;
    }

    public override bool? visit(AbFile file)
    {
        if (file.isDirectory()) {
            return true;
        }
        if (this.includesString == null || file.getAbsolutePath().indexOf(this.includesString) >= 0) {
            return base.visit(file);
        } else {
            return false;
        }
    }

    public override bool? visit(AbFile file, string fileNameString)
    {
        string filePath = file.getPath();
        if (base.visit(file, fileNameString)) {
            if (!(filePath.Contains(this.trackedStrings.APPLICATION) || filePath.Contains(this.trackedStrings.APP) || filePath.Contains(this.trackedStrings.HTML_TEMP))) {
                if (!(filePath.Contains(this.trackedStrings.TARGET_PATH_WINDOWS) || filePath.Contains(this.trackedStrings.TARGET_PATH_UNIX))) {
                    if (this.gitProcessHelper.isTracked(file)) {
                        return true;
                    } else {
                    }
                } else {
                }
            } else {
            }
        }
        return false;
    }

    public static void main(string[] args)
    {
        CommonDataFileStrings commonFileStrings = CommonDataFileStrings.getInstance();
        BasicArrayList list = new BasicArrayListD();
        list.add(commonFileStrings.JAVA);
        string filePath = "G:\\mnt\\bc\\mydev\\games\\ZeptoRacer\\platform\\j2se\\ZeptoRacerStaticPathsJ2SEM\\target\\dependency\\org\\allbinary\\logic\\system\\security\\licensing\\ZeptoRacerPCClientInformation.java";
        bool result = new DirectoryOrIncludeFileExtensionAndTrackedBooleanFileVisitor(list).visit(AbFile.createAbFileFromRawPath(filePath));
        Console.WriteLine(filePath + " is Tracked: " + result);
    }

}

