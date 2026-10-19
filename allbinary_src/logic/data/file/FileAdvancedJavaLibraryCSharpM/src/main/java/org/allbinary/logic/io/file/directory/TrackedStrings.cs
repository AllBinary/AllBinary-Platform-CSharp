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

namespace org.allbinary.logic.io.file.directory;

public class TrackedStrings
{
    private static readonly TrackedStrings instance = new TrackedStrings();
    public static TrackedStrings getInstance()
    {
        return TrackedStrings.instance;
    }

    public readonly string TARGET_PATH_WINDOWS = "\\target\\";
    public readonly string TARGET_PATH_UNIX = "/target/";
    public readonly string HTML_TEMP = "HTMLTemp";
    public readonly string APPLICATION = "Application";
    public readonly string APP = "\\app";
    public readonly string GIT_COMMAND = "git";
    public readonly string CHANGE_DIRECTORY_OPTION = "-C";
    public readonly string LIST_FILES_COMMAND = "ls-files";
    public readonly string ERROR_UNMATCH_OPTION = "--error-unmatch";
    public readonly string PATHSPEC_SEPARATOR = "--";
    public readonly string SEP_BY_NULL_CHAR_INSTEAD_OF_NEW_LINE = "-z";
}

