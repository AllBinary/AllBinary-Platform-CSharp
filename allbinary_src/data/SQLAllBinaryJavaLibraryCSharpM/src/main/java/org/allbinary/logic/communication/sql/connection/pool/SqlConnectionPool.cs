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
using System.Runtime.CompilerServices;
//using Connection = java.sql.Connection;
//using DriverManager = java.sql.DriverManager;
//using SQLException = java.sql.SQLException;
using java.util;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using StdUtil = org.allbinary.logic.StdUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;

namespace org.allbinary.logic.communication.sql.connection.pool;

public class SqlConnectionPool
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly SqlConnectionPool instance = new SqlConnectionPool();
    public static SqlConnectionPool getInstance()
    {
        return SqlConnectionPool.instance;
    }

    public readonly StdUtil stdUtil = StdUtil.getInstance();
    private HashMap connectionHashMap = null;
    private readonly string FIRST_NEW_CONNECTION_CREATED = "First New Connection Created: ";
    private readonly string FIRST = "First ";
    private readonly string NEW_CONNECTION_FOR = "New Connection For ";
    private readonly string CREATED = " Created";
    private readonly string NUMBER_OF_SQL_CONNECTIONS_FOR = "Number Of Sql Connections for: ";
    private readonly string NUMBER_OF_SQL_CONNECTION_VECTORS = "Number Of Sql Connection Vectors: ";
    private readonly string IS = " is ";
    private readonly string CONNECTION_ALLREADY_CLOSED = "Connection AllReady Closed";
    private readonly string METHOD_GET = "get()";
    private readonly string METHOD_ADD = "add()";
    private SqlConnectionPool()
    {
    }

    // throws SQLException
    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual Connection get(string url)
    {
        if (this.connectionHashMap == null) {
            this.connectionHashMap = this.stdUtil.createHashMap();
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGINGPOOL)) {
                this.logUtil.putF(this.FIRST_NEW_CONNECTION_CREATED + url, this, METHOD_GET);
            }
            return DriverManager.getConnection(url);
        } else {
            BasicArrayList connectionVector = ((BasicArrayList) this.connectionHashMap.get(url));
            if (connectionVector == null) {
                connectionVector = new BasicArrayListD();
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGINGPOOL)) {
                    StringMaker stringBuffer = new StringMaker();
                    stringBuffer.append(this.FIRST);
                    stringBuffer.append(this.NEW_CONNECTION_FOR);
                    stringBuffer.append(url);
                    stringBuffer.append(this.CREATED);
                    this.logUtil.putF(stringBuffer.ToString(), this, this.METHOD_GET);
                }
                return DriverManager.getConnection(url);
            } else if (connectionVector.size() == 0) {
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGINGPOOL)) {
                    this.logUtil.putF(new StringMaker().append(this.NEW_CONNECTION_FOR).append(url).append(this.CREATED).ToString(), this, METHOD_GET);
                }
                return DriverManager.getConnection(url);
            } else {
                StringMaker stringBuffer = new StringMaker();
                int size = connectionVector.size();
                for (int i = 0; i < size; i++) {
                    Connection sqlConnection = ((Connection) connectionVector.get(i));
                    if (!sqlConnection.isClosed()) {
                        connectionVector.remove(sqlConnection);
                        this.connectionHashMap.put(url, connectionVector);
                        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGINGPOOL)) {
                            stringBuffer.delete(0, stringBuffer.length());
                            stringBuffer.append(this.NUMBER_OF_SQL_CONNECTIONS_FOR);
                            stringBuffer.append(url);
                            stringBuffer.append(this.IS);
                            stringBuffer.appendint(connectionVector.size());
                            this.logUtil.putF(NUMBER_OF_SQL_CONNECTION_VECTORS + this.connectionHashMap.size(), this, this.METHOD_GET);
                            this.logUtil.putF(stringBuffer.ToString(), this, METHOD_GET);
                        }
                        return ((Connection) sqlConnection);
                    }
                }
            }
        }
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGINGPOOL)) {
            StringMaker stringBuffer = new StringMaker();
            stringBuffer.append(this.NEW_CONNECTION_FOR);
            stringBuffer.append(url);
            stringBuffer.append(this.CREATED);
            this.logUtil.putF(stringBuffer.ToString(), this, this.METHOD_GET);
        }
        return DriverManager.getConnection(url);
    }

    // throws SQLException
    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual void add(string url, Connection sqlConnection)
    {
        if (!sqlConnection.isClosed()) {
            BasicArrayList connectionVector = null;
            if (this.connectionHashMap == null) {
                this.connectionHashMap = this.stdUtil.createHashMap();
                connectionVector = new BasicArrayListD();
                connectionVector.add(sqlConnection);
            } else {
                connectionVector = ((BasicArrayList) this.connectionHashMap.get(url));
                if (connectionVector == null) {
                    connectionVector = new BasicArrayListD();
                }
                connectionVector.add(sqlConnection);
                this.connectionHashMap.put(url, connectionVector);
            }
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGINGPOOL)) {
                StringMaker stringBuffer = new StringMaker();
                stringBuffer.append(this.NUMBER_OF_SQL_CONNECTIONS_FOR);
                stringBuffer.append(url);
                stringBuffer.append(this.IS);
                stringBuffer.appendint(connectionVector.size());
                this.logUtil.putF(this.NUMBER_OF_SQL_CONNECTION_VECTORS + this.connectionHashMap.size(), this, this.METHOD_ADD);
                this.logUtil.putF(stringBuffer.ToString(), this, this.METHOD_ADD);
            }
        }
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGINGPOOL)) {
            this.logUtil.putF(this.CONNECTION_ALLREADY_CLOSED, this, METHOD_ADD);
        }
    }

}

