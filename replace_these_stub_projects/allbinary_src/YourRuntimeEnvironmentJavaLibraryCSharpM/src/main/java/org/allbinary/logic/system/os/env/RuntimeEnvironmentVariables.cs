// Generated Code Do Not Modify

using System;
using System.Linq;
//using BufferedReader = java.io.BufferedReader;
//using InputStreamReader = java.io.InputStreamReader;
//using Properties = java.util.Properties;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using GenericOperatingSystem = org.allbinary.logic.system.os.GenericOperatingSystem;
using OperatingSystemFactory = org.allbinary.logic.system.os.OperatingSystemFactory;
using OperatingSystems = org.allbinary.logic.system.os.OperatingSystems;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.logic.system.os.env;

public class RuntimeEnvironmentVariables
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    public RuntimeEnvironmentVariables()
    {
    }

    public virtual string getTest1()
    {
        return System.getProperty("java.java.home");
    }

    public virtual string getVariable(string var)
    {
        Properties environmentVariables = this.get();
        return environmentVariables.getProperty(var);
    }

    public virtual Properties get()
    {
        try {
            Process process = null;
            Properties environmentVariables = new Properties();
            GenericOperatingSystem operatingSystemInterface = OperatingSystemFactory.getInstance().getOperatingSystemInstance();
            string osName = operatingSystemInterface.getName();
            string linuxCommand = "env";
            string windowsCommand = "cmd.exe /c set";
            string solarisCommand = linuxCommand;
            OperatingSystems operatingSystems = OperatingSystems.getInstance();
            if (string.CompareOrdinal(osName, operatingSystems.LINUX) == 0) {
                process = Runtime.getRuntime().exec(linuxCommand);
            } else if (osName.IndexOf(operatingSystems.WINDOWS) >= 0) {
                process = Runtime.getRuntime().exec(windowsCommand);
            } else if (string.CompareOrdinal(osName, operatingSystems.SOLARIS) == 0) {
                process = Runtime.getRuntime().exec(solarisCommand);
            } else {
                throw new Exception();
            }
            InputStreamReader processInputStreamReader = new InputStreamReader(process.getInputStream());
            BufferedReader bufferedReader = new BufferedReader(processInputStreamReader);
            string keyValuePair = null;
            while (((keyValuePair = bufferedReader.readLine())) != null) {
                int index = keyValuePair.IndexOf('=');
                string key = keyValuePair.Substring(0, (index) - (0));
                string value = keyValuePair.Substring(index + 1);
                environmentVariables.put(key, value);
            }
            return environmentVariables;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().OSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "get()", e);
            }
            return null;
        }
    }

    public virtual string getTempDir()
    {
        try {
            return System.getProperty("java.io.tmpdir");
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().OSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "getTempDir()", e);
            }
            return null;
        }
    }

    public virtual string getLibraryPath()
    {
        try {
            return System.getProperty("java.library.path");
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().OSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "getLibraryPath()", e);
            }
            return null;
        }
    }

    public virtual string getClassPath()
    {
        try {
            return System.getProperty("java.class.path");
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().OSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "getClassPath()", e);
            }
            return null;
        }
    }

    public virtual void updateLibraryPath(string libPath)
    {
        try {
            string existingPath = this.getLibraryPath();
            System.setProperty("java.library.path", libPath + ":" + existingPath);
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().OSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "updateLibraryPath()", e);
            }
        }
    }

    public virtual string getUserHome()
    {
        try {
            return System.getProperty("user.home");
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().OSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "getUserHome()", e);
            }
            return null;
        }
    }

    public virtual string getUserDir()
    {
        try {
            return System.getProperty("user.dir");
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().OSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "getUserDir()", e);
            }
            return null;
        }
    }

    public virtual void set()
    {
        try {
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().OSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "get()", e);
            }
        }
    }

    public virtual void setVariable(string var, string val)
    {
        try {
            Process process = null;
            GenericOperatingSystem operatingSystemInterface = OperatingSystemFactory.getInstance().getOperatingSystemInstance();
            OperatingSystems operatingSystems = OperatingSystems.getInstance();
            string osName = operatingSystemInterface.getName();
            string windowsCommand = "cmd.exe /c set" + var + "=" + val;
            if (string.CompareOrdinal(osName, operatingSystems.LINUX) == 0) {
                throw new Exception();
            } else if (osName.IndexOf(operatingSystems.WINDOWS) >= 0) {
                process = Runtime.getRuntime().exec(windowsCommand);
            } else if (string.CompareOrdinal(osName, operatingSystems.SOLARIS) == 0) {
                throw new Exception();
            } else {
                throw new Exception();
            }
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().OSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "setVariable()", e);
            }
        }
    }

}

