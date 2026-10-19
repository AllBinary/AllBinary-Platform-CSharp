/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2026 AllBinary 
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
//using File = java.io.File;
//using IOException = java.io.IOException;
//using StandardCharsets = java.nio.charset.StandardCharsets;
//using java.util;
//using java.util;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using AbFile = org.allbinary.logic.io.file.AbFile;
using AbFileNativeUtil = org.allbinary.logic.io.file.AbFileNativeUtil;
using TrackedStrings = org.allbinary.logic.io.file.directory.TrackedStrings;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.java.runtime.process.git;

//Do not use this instead just skip target, build, Application paths.
public class GitProcessHelper
{
    private static readonly GitProcessHelper instance = new GitProcessHelper();
    public static GitProcessHelper getInstance()
    {
        return GitProcessHelper.instance;
    }

    private readonly TrackedStrings trackedStrings = TrackedStrings.getInstance();
    private GitProcessHelper()
    {
        LogUtil logUtil = LogUtil.getInstance();
        CommonStrings commonStrings = CommonStrings.getInstance();
        string THIS_IS_SLOW = "This is slow consider path exclusion instead";
        logUtil.putF(THIS_IS_SLOW, this, commonStrings.CONSTRUCTOR);
    }

    // throws IOException, InterruptedException
    public virtual List<string> trackedFiles(string rootAsString, string pathspec)
    {
        return this.trackedFiles(rootAsString, pathspec, ".java");
    }

    // throws IOException, InterruptedException
    public virtual List<string> trackedFiles(string rootAsString, string pathspec, string suffix)
    {
        Process process = new ProcessBuilder(this.trackedStrings.GIT_COMMAND, this.trackedStrings.CHANGE_DIRECTORY_OPTION, rootAsString, this.trackedStrings.LIST_FILES_COMMAND, this.trackedStrings.SEP_BY_NULL_CHAR_INSTEAD_OF_NEW_LINE, this.trackedStrings.PATHSPEC_SEPARATOR, pathspec).redirectError(ProcessBuilder.Redirect.INHERIT).start();
        sbyte[] output = process.getInputStream().readAllBytes();
        int exitCode = process.waitFor();
        if (exitCode != 0) {
            throw new IllegalStateException(new StringMaker().append("git ls-files failed for ").append(rootAsString).append(" with exit code ").appendint(exitCode).ToString());
        }
        List<string> files = new ArrayList();
        int start = 0;
        string relativePath = null;
        for (int index = 0; index < output.Length; index++) {
            if (((int) output[index]) == 0) {
                relativePath = System.Text.Encoding.UTF8.GetString((byte[]) (Array) output, start, index - start, StandardCharsets.UTF_8);
                if (relativePath.EndsWith(suffix)) {
                    files.add(relativePath);
                }
                start = index + 1;
            }
        }
        return files;
    }

    public virtual bool isTracked(AbFile file)
    {
        try {
            File nativeFile = AbFileNativeUtil.get(file);
            File parentFile = nativeFile.getParentFile();
            Process process = new ProcessBuilder(this.trackedStrings.GIT_COMMAND, this.trackedStrings.CHANGE_DIRECTORY_OPTION, parentFile.getPath(), this.trackedStrings.LIST_FILES_COMMAND, this.trackedStrings.ERROR_UNMATCH_OPTION, this.trackedStrings.PATHSPEC_SEPARATOR, nativeFile.getName()).redirectErrorStream(true).start();
            process.getInputStream().readAllBytes();
            return process.waitFor() == 0;
        } catch (Exception e) {
            return false;
        }
    }

}

