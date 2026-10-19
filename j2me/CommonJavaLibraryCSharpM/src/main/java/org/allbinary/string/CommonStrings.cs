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
//using JsType = jsinterop.annotations.JsType;
//using JsMethod = jsinterop.annotations.JsMethod;
//using JsProperty = jsinterop.annotations.JsProperty;

namespace org.allbinary.@string;

public class CommonStrings
{
    private static readonly CommonStrings instance = new CommonStrings();
    public static CommonStrings getInstance()
    {
        return CommonStrings.instance;
    }

    public readonly string EMPTY = "Empty";
    public readonly string CREATE_IMAGE = "createImage";
    public readonly string PLEASE_WAIT = "Please Wait";
    public readonly string PLEASE_WAIT_FOR_SERVER = "Please Wait Getting Data From Server...";
    public readonly string PERIODS = "...";
    public readonly string LOADING = "Loading...";
    public readonly string CONSTRUCTOR = "Constructor";
    public readonly string START = "Start";
    public readonly string END = "End";
    public readonly string EXCEPTION = "Exception";
    public readonly string EXCEPTION_LABEL = "Exception: ";
    public readonly string CLEANUP = "cleanup";
    public readonly string INIT = "init";
    public readonly string CLOSE = "close";
    public readonly string UP = "up";
    public readonly string DOWN = "down";
    public readonly string LEFT = "left";
    public readonly string RIGHT = "right";
    public readonly string[] DIRECTION_NAME;
    public readonly string CREATE = "Create";
    public readonly string REMOVE = "Remove";
    public readonly string UPDATE = "Update";
    public readonly string DELETE = "Delete";
    public readonly string delete = "delete";
    public readonly string LOAD = "load";
    public readonly string SAVE = "save";
    public readonly string ADD = "Add";
    public readonly string DROP = "Drop";
    public readonly string INSERT = "Insert";
    public readonly string VISIT = "visit";
    public readonly string START_METHOD_NAME;
    public readonly string END_METHOD_NAME = "end";
    public readonly string GET = "get";
    public readonly string PROCESS = "process";
    public readonly string GET_INSTANCE = "getInstance";
    public readonly string GET_LIST = "getList";
    public readonly string RUN = "run";
    public readonly string START_RUNNABLE = "Start Runnable";
    public readonly string RUNNING = "Running";
    public readonly string END_RUNNABLE = "End Runnable";
    public readonly string DISABLE = "disable";
    public readonly string ENABLE = "enable";
    public readonly string SUCCESS = "Command Success";
    public readonly string FAILURE = "Command Failed";
    public readonly string NOT_IMPLEMENTED = "Not Implemented";
    public readonly string UNKNOWN = "Unknown";
    public readonly string ON_EVENT = "onEvent";
    public readonly string IS_VALID = "isValid";
    public readonly string TOSTRING = "toString";
    public readonly string ADD_LISTENER = "addListener";
    public readonly string REMOVE_LISTENER = "removeListener";
    public readonly string SIZE = "size";
    public CommonStrings()
    {
        this.DIRECTION_NAME = new string[] { this.DOWN, this.LEFT, this.RIGHT, this.UP };
        this.START_METHOD_NAME = this.START;
    }

}

