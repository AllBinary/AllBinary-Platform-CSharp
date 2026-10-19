// Generated Code Do Not Modify

using System;
using System.Linq;
using CommonSeps = org.allbinary.@string.CommonSeps;

namespace org.allbinary.logic.communication.sql;

public class SqlStrings
{
    private static readonly SqlStrings instance = new SqlStrings();
    public static SqlStrings getInstance()
    {
        return SqlStrings.instance;
    }

    public readonly string CREATE_DATABASE = "CREATE DATABASE ";
    public readonly string DROP_TABLE = "DROP TABLE ";
    public readonly string CREATE_TABLE = "CREATE TABLE ";
    public readonly string START = " (";
    public readonly string SELECT = "SELECT ";
    public readonly string FROM = " FROM ";
    public readonly string SELECT_ALL = "SELECT *";
    public readonly string WHERE = " WHERE ";
    public readonly string AND = " AND ";
    public readonly string UPDATE = "UPDATE ";
    public readonly string SET = " SET ";
    public readonly string SELECT_ALL_FROM;
    public readonly string DELETE = "DELETE";
    public readonly string LIKE_QUOTE = " LIKE \"";
    public readonly string INSERT_INTO = "INSERT INTO ";
    public readonly string VALUES = " VALUES ('";
    public readonly string ORDER_BY = "ORDER BY";
    public readonly string COUNT = "COUNT(";
    public readonly string ASC = "ASC";
    public readonly string DESC = "DESC";
    public readonly string PRIMARY_KEY = "PRIMARY KEY(";
    public readonly string END = ") )";
    public readonly string EQUAL_QUOTE = " = \"";
    public readonly string CLOSE_QUOTE = CommonSeps.getInstance().QUOTE;
    public readonly string EQUAL_QUOTE_NO_SPACE = "=\"";
    public readonly string ESCAPE = "\\";
    public readonly string DOUBLE_ESCAPE = "\\\\";
    public readonly string MORE_THAN_QUOTE = " > \"";
    public readonly string LESS_THAN_QUOTE = " < \"";
    public readonly string SINGLE_QUOTE_COMMA_SEP = "','";
    public readonly string ID = "ID";
    public readonly string SQL_STATEMENT_LABEL = "SQL Statement: ";
    public readonly string COLUMN_VALUE = "\nColumn Value: ";
    public readonly string CREATE_RETURN = " Created Successfully";
    public readonly string FIELD_VALUE = "\nField Value: ";
    public SqlStrings()
    {
        this.SELECT_ALL_FROM = this.SELECT_ALL + this.FROM;
    }

}

