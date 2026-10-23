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
using java.util;
using URLGLOBALS = org.allbinary.globals.URLGLOBALS;
using StdUtil = org.allbinary.logic.StdUtil;
using WeblisketSession = org.allbinary.logic.communication.http.request.session.WeblisketSession;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using InputOutputTypeData = org.allbinary.logic.io.InputOutputTypeData;
using AbFile = org.allbinary.logic.io.file.AbFile;
using FileUtil = org.allbinary.logic.io.file.FileUtil;
using AbPath = org.allbinary.logic.io.path.AbPath;
using AbPathData = org.allbinary.logic.io.path.AbPathData;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using StringValidationUtil = org.allbinary.logic.@string.StringValidationUtil;
using Replace = org.allbinary.logic.@string.regex.replace.Replace;
using TransformInfoHttpInterface = org.allbinary.logic.visual.transform.info.TransformInfoHttpInterface;
using TransformInfoHttpStoreInterface = org.allbinary.logic.visual.transform.info.TransformInfoHttpStoreInterface;
using TransformInfoInterface = org.allbinary.logic.visual.transform.info.TransformInfoInterface;
using TransformInfosData = org.allbinary.logic.visual.transform.info.TransformInfosData;
using CommonSeps = org.allbinary.@string.CommonSeps;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.logic.visual.transform.info.objectConfig.generator;

public class StoreFileGenerator : TransformInfoObjectConfigGenerator
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private readonly string output;
    private readonly AbPath fileAbPath;
    private readonly AbFile file;
    public StoreFileGenerator(TransformInfoInterface transformInfoInterface)
    {
        TransformInfoHttpInterface httpTransformInfoInterface = ((TransformInfoHttpInterface) transformInfoInterface);
        WeblisketSession weblisketSession = new WeblisketSession(httpTransformInfoInterface.getPropertiesHashMap(), httpTransformInfoInterface.getPageContext());
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(URLGLOBALS.getWebappPath());
        stringBuffer.append(weblisketSession.getStoreName());
        stringBuffer.append(AbPathData.getInstance().SEPARATOR);
        AbPath abPath = new AbPath(stringBuffer.ToString(), StringUtil.getInstance().EMPTY_STRING);
        string fileName = ((string) httpTransformInfoInterface.getPropertiesHashMap().get(InputOutputTypeData.getInstance().FILE));
        StringValidationUtil stringValidationUtil = StringValidationUtil.getInstance();
        if (stringValidationUtil.isEmpty(fileName)) {
            TransformInfoHttpStoreInterface transformInfoHttpStoreInterface = ((TransformInfoHttpStoreInterface) transformInfoInterface);
            fileName = transformInfoInterface.getName().Substring(transformInfoHttpStoreInterface.getStoreName().length() + 1);
            HashMap<object, object> outputMappingHashMap = StdUtil.getInstance().createHashMap();
            outputMappingHashMap.put(TransformInfosData.getInstance().PREVIEW, "Preview");
            outputMappingHashMap.put(TransformInfosData.getInstance().SMALL_PREVIEW, "SmallPreview");
            outputMappingHashMap.put(CommonSeps.getInstance().SPACE, StringUtil.getInstance().EMPTY_STRING);
            Replace replace = new Replace(outputMappingHashMap);
            fileName = replace.all(fileName);
        }
        if (stringValidationUtil.isEmpty(fileName)) {
            throw new Exception("TransformInfoObjectConfigGenerator FileName Not Specified");
        }
        string tempOutput = ((string) httpTransformInfoInterface.getPropertiesHashMap().get(InputOutputTypeData.getInstance().NAME));
        if (stringValidationUtil.isEmpty(tempOutput)) {
            tempOutput = InputOutputTypeData.getInstance().DEFAULT;
        }
        this.output = tempOutput;
        if (stringValidationUtil.isEmpty(this.output)) {
            throw new Exception("TransformInfoObjectConfigGenerator Output=extension Not Specified");
        }
        stringBuffer = new StringMaker();
        stringBuffer.append(fileName);
        stringBuffer.append(AbPathData.getInstance().EXTENSION_SEP);
        stringBuffer.append(this.output);
        abPath = new AbPath(abPath.ToString(), stringBuffer.ToString());
        this.fileAbPath = abPath;
        this.file = AbFile.createAbFileFromAbPath(this.fileAbPath);
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
            this.logUtil.putF("File: " + this.fileAbPath.ToString(), this, this.commonStrings.CONSTRUCTOR);
        }
    }

    // throws Exception
    public virtual string process(string input)
    {
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
            this.logUtil.putF("Processing", this, this.commonStrings.PROCESS);
        }
        if (!this.file.exists()) {
            this.file.createNewFile();
        }
        if (this.file.exists()) {
            InputStream inputStream = new ByteArrayInputStream(System.Array.ConvertAll(System.Text.Encoding.UTF8.GetBytes(input), value => unchecked((sbyte) value)));
            FileUtil.getInstance().write(inputStream, this.file);
        } else {
            throw new Exception("Could Not Create: " + this.fileAbPath.ToString());
        }
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
            this.logUtil.putF("Processed", this, this.commonStrings.PROCESS);
        }
        return StringUtil.getInstance().EMPTY_STRING;
    }

}

