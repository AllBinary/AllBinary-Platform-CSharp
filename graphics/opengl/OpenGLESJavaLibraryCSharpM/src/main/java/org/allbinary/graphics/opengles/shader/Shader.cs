/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2025 AllBinary 
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
using StringUtil = org.allbinary.logic.@string.StringUtil;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListUtil = org.allbinary.util.BasicArrayListUtil;

namespace org.allbinary.graphics.opengles.shader;

public class Shader
{
    public string shaderName = StringUtil.getInstance().EMPTY_STRING;
    public BasicArrayList shaderStringList = BasicArrayListUtil.getInstance().getImmutableInstance();
    public string shaderAsString = StringUtil.getInstance().EMPTY_STRING;
    public int shaderHandle = 0;
}

