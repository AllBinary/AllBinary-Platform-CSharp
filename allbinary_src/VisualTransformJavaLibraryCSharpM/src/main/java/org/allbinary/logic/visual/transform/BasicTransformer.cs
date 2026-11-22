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
using ByteArrayInputStream = java.io.ByteArrayInputStream;
using ByteArrayOutputStream = java.io.ByteArrayOutputStream;
using InputStream = java.io.InputStream;
//using URIResolver = javax.xml.transform.URIResolver;
using BasicUriResolver = org.allbinary.data.tree.dom.BasicUriResolver;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using AbCrypt = org.allbinary.logic.control.crypt.jcehelper.AbCrypt;
using KeySpecFactory = org.allbinary.logic.control.crypt.jcehelper.KeySpecFactory;
using AbFileInputStream = org.allbinary.logic.io.AbFileInputStream;
using StreamUtil = org.allbinary.logic.io.StreamUtil;
using AbFile = org.allbinary.logic.io.file.AbFile;
using AbPathData = org.allbinary.logic.io.path.AbPathData;
using PathUtil = org.allbinary.logic.io.path.PathUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using AbKeys = org.allbinary.logic.system.security.AbKeys;
using AbeClientInformationInterface = org.allbinary.logic.system.security.licensing.AbeClientInformationInterface;
using TransformInfoInterface = org.allbinary.logic.visual.transform.info.TransformInfoInterface;
using TransformInfoTemplateData = org.allbinary.logic.visual.transform.info.template.TransformInfoTemplateData;
using LogConfigTypeFactory = org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory;
using LogConfigTypes = org.allbinary.logic.communication.log.config.type.LogConfigTypes;

namespace org.allbinary.logic.visual.transform;

public class BasicTransformer : AbTransformer
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly StreamUtil streamUtil = StreamUtil.getInstance();
    private readonly AbeClientInformationInterface abeClientInformation;
    public BasicTransformer(AbeClientInformationInterface abeClientInformation, TransformInfoInterface transformInfoInterface) : base(transformInfoInterface)
    {
        // Constructor invocation emitted in the initializer.
        this.abeClientInformation = abeClientInformation;
        this.setTemplateAsInputStream();
    }

    // throws Exception
    private void setEncryptedTemplateFileAsInputStream(AbFile file)
    {
        ByteArrayOutputStream outputStream = null;
        AbFileInputStream inputStream = null;
        try {
            outputStream = new ByteArrayOutputStream();
            inputStream = AbFileInputStream.createFromAbFile(file);
            outputStream = ((ByteArrayOutputStream) this.streamUtil.get(inputStream, outputStream, new sbyte[16384]));
            AbCrypt abCrypt = new AbCrypt(KeySpecFactory.DESEDE, AbKeys.getInstance().getKey(this.abeClientInformation, file.getAbsolutePath()));
            sbyte[] decrypted = abCrypt.decrypt(outputStream.toByteArray());
            if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().TAGHELPERFACTORY)) {
                this.logUtil.putF("Decrypted Template: \n" + System.Text.Encoding.UTF8.GetString((byte[]) (Array) decrypted), this, "setEncryptedTemplateFileAsInputStream(file)");
            }
            this.setInputStream(((InputStream) new ByteArrayInputStream(decrypted)));
            this.setURIResolver(((URIResolver) new BasicUriResolver(TransformInfoTemplateData.getInstance().ENCRYPTED_EXTENSION)));
        } catch (Exception e) {
            if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().TAGHELPERFACTORYERROR)) {
                StringMaker stringBuffer = new StringMaker();
                stringBuffer.append("Failed to get Encrypted File: ");
                stringBuffer.append(file.getPath());
                stringBuffer.append(" \nName:");
                stringBuffer.append(file.getName());
                this.logUtil.put(stringBuffer.ToString(), this, "setEncryptedTemplateFileAsInputStream()", e);
            }
            throw e;
        } finally {
            this.streamUtil.close(outputStream);
            this.streamUtil.close(inputStream);
        }
    }

    // throws Exception
    private void setEncryptedTemplateAsInputStream()
    {
        ByteArrayOutputStream outputStream = null;
        ByteArrayInputStream inputStream = null;
        try {
            outputStream = new ByteArrayOutputStream();
            inputStream = new ByteArrayInputStream(this.getTransformInfoInterface().getTemplate().getBytes());
            outputStream = ((ByteArrayOutputStream) this.streamUtil.get(inputStream, outputStream, new sbyte[16384]));
            AbCrypt abCrypt = new AbCrypt(KeySpecFactory.DESEDE, AbKeys.getInstance().getKey(this.abeClientInformation, this.getTransformInfoInterface().getName()));
            sbyte[] decrypted = abCrypt.decrypt(outputStream.toByteArray());
            if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().TAGHELPERFACTORY)) {
                this.logUtil.putF("Decrypted Template: \n" + decrypted.ToString(), this, "setEncryptedTemplateAsInputStream()");
            }
            this.setInputStream(((InputStream) new ByteArrayInputStream(decrypted)));
            this.setURIResolver(((URIResolver) new BasicUriResolver(TransformInfoTemplateData.getInstance().ENCRYPTED_EXTENSION)));
        } catch (Exception e) {
            if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().TAGHELPERFACTORYERROR)) {
                this.logUtil.put("Failed to set with template: " + this.getTransformInfoInterface().getTemplateFilePath(), this, "setEncryptedTemplateFileAsInputStream()", e);
            }
            throw e;
        } finally {
            this.streamUtil.close(outputStream);
            this.streamUtil.close(inputStream);
        }
    }

    // throws Exception
    private void setTemplateAsInputStream()
    {
        AbFileInputStream inputStream = null;
        ByteArrayOutputStream outputStream = null;
        try {
            if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().TAGHELPERFACTORY)) {
                this.logUtil.putF(this.getTransformInfoInterface().log(), this, "setTemplateAsInputStream()");
            }
            TransformInfoTemplateData transformInfoTemplateData = TransformInfoTemplateData.getInstance();
            PathUtil pathUtil = PathUtil.getInstance();
            if (this.getTransformInfoInterface().getTemplateFilePath() != null) {
                string extension = pathUtil.getExtensionWithAbPath(this.getTransformInfoInterface().getTemplateFilePath());
                string filePath = pathUtil.getWithoutExtensionWithAbPath(this.getTransformInfoInterface().getTemplateFilePath());
                if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().TAGHELPERFACTORY)) {
                    this.logUtil.putF(this.getTransformInfoInterface().log(), this, "setTemplateAsInputStream()");
                }
                if (string.CompareOrdinal(extension, transformInfoTemplateData.UNCRYPTED_EXTENSION) == 0) {
                    StringMaker stringBuffer = new StringMaker();
                    stringBuffer.append(filePath);
                    stringBuffer.append(AbPathData.getInstance().EXTENSION_SEP);
                    stringBuffer.append(transformInfoTemplateData.ENCRYPTED_EXTENSION);
                    AbFile encFile = AbFile.createAbFile(stringBuffer.ToString());
                    if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().TAGHELPERFACTORY)) {
                        this.logUtil.putF(this.getTransformInfoInterface().log(), this, "setTemplateAsInputStream()");
                    }
                    if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().TAGHELPERFACTORY)) {
                        stringBuffer = new StringMaker();
                        stringBuffer.append("Encrypted Template File isFile=");
                        stringBuffer.appendboolean(encFile.isFile());
                        stringBuffer.append("\nEncTemplateFilePath: ");
                        stringBuffer.append(encFile.getPath());
                        this.logUtil.putF(stringBuffer.ToString(), this, "setTemplateAsInputStream()");
                    }
                    if (encFile.isFile()) {
                        this.setEncryptedTemplateFileAsInputStream(encFile);
                        return;
                    } else {
                        AbFile file = AbFile.createAbFileFromAbPath(this.getTransformInfoInterface().getTemplateFilePath());
                        if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().TAGHELPERFACTORY)) {
                            this.logUtil.putF(this.getTransformInfoInterface().log(), this, "setTemplateAsInputStream()");
                        }
                        if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().TAGHELPERFACTORY)) {
                            this.logUtil.putF("Template File isFile=" + file.isFile(), this, "setTemplateAsInputStream()");
                        }
                        if (file.isFile()) {
                            inputStream = AbFileInputStream.createFromAbFile(file);
                            outputStream = new ByteArrayOutputStream();
                            outputStream = ((ByteArrayOutputStream) this.streamUtil.get(inputStream, outputStream, new sbyte[16384]));
                            if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().TAGHELPERFACTORY)) {
                                this.logUtil.putF("Template: " + outputStream.ToString(), this, "getTemplateAsInputStream()");
                            }
                            this.setInputStream(((InputStream) new ByteArrayInputStream(outputStream.toByteArray())));
                            this.setURIResolver(((URIResolver) new BasicUriResolver(transformInfoTemplateData.UNCRYPTED_EXTENSION)));
                            return;
                        }
                    }
                } else if (string.CompareOrdinal(extension, transformInfoTemplateData.ENCRYPTED_EXTENSION) == 0) {
                    StringMaker stringBuffer = new StringMaker();
                    stringBuffer.append(filePath);
                    stringBuffer.append(AbPathData.getInstance().EXTENSION_SEP);
                    stringBuffer.append(transformInfoTemplateData.ENCRYPTED_EXTENSION);
                    AbFile file = AbFile.createAbFile(stringBuffer.ToString());
                    if (file.isFile()) {
                        this.setEncryptedTemplateFileAsInputStream(file);
                    }
                } else {
                    throw new Exception("View Template File Type Is Not Recognized: " + this.getTransformInfoInterface().getTemplateFilePath());
                }
            } else {
                this.setEncryptedTemplateAsInputStream();
            }
        } catch (Exception e) {
            if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().TAGHELPERFACTORYERROR)) {
                this.logUtil.put("Failed to get Template Data", this, "setTemplateAsInputStream()", e);
            }
            throw e;
        } finally {
            this.streamUtil.close(outputStream);
            this.streamUtil.close(inputStream);
        }
        throw new Exception("Error setTemplateAsInputStream()");
    }

}

