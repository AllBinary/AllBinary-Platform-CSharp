// Generated Code Do Not Modify

using System;
using System.Linq;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using CommonSeps = org.allbinary.@string.CommonSeps;

namespace org.allbinary.logic.communication.sql;

public class SqlTypeStrings
{
    private static readonly SqlTypeStrings instance = new SqlTypeStrings();
    public static SqlTypeStrings getInstance()
    {
        return SqlTypeStrings.instance;
    }

    public readonly string CHAR_COLUMN = "VARCHAR";
    public readonly string INT_COLUMN = "VARCHAR";
    public readonly string MAX_SIZE = "(255)";
    public readonly string SIXTY_SIZE = "(60)";
    public readonly string NOT_NULL = "NOT NULL";
    public readonly string ONE_SIZE = "(1)";
    public readonly string TWO_SIZE = "(2)";
    public readonly string THREE_SIZE = "(3)";
    public readonly string SIX_SIZE = "(6)";
    public readonly string ELEVEN_SIZE = "(11)";
    public readonly string TWELVE_SIZE = "(12)";
    public readonly string ONE_KB_CHAR_COLUMN = new StringMaker().append(CommonSeps.getInstance().SPACE).append(CHAR_COLUMN).append("(1024)").append(CommonSeps.getInstance().COMMA_SEP).ToString();
    public readonly string MAX_CHAR_COLUMN = new StringMaker().append(CommonSeps.getInstance().SPACE).append(CHAR_COLUMN).append(MAX_SIZE).append(CommonSeps.getInstance().COMMA_SEP).ToString();
    public readonly string MAX_CHAR_COLUMN_NOT_NULL = new StringMaker().append(CommonSeps.getInstance().SPACE).append(CHAR_COLUMN).append(MAX_SIZE).append(CommonSeps.getInstance().SPACE).append(NOT_NULL).append(CommonSeps.getInstance().COMMA_SEP).ToString();
    public readonly string SIXTY_CHAR_COLUMN_NOT_NULL = new StringMaker().append(CommonSeps.getInstance().SPACE).append(CHAR_COLUMN).append(SIXTY_SIZE).append(NOT_NULL).append(CommonSeps.getInstance().COMMA_SEP).ToString();
    public readonly string ONE_CHAR_COLUMN_NOT_NULL = new StringMaker().append(CommonSeps.getInstance().SPACE).append(CHAR_COLUMN).append(ONE_SIZE).append(NOT_NULL).append(CommonSeps.getInstance().COMMA_SEP).ToString();
    public readonly string SIX_CHAR_COLUMN_NOT_NULL = new StringMaker().append(CommonSeps.getInstance().SPACE).append(CHAR_COLUMN).append(SIX_SIZE).append(NOT_NULL).append(CommonSeps.getInstance().COMMA_SEP).ToString();
    public readonly string TWELVE_CHAR_COLUMN_NOT_NULL;
    public readonly string TWO_INT_NOT_NULL = " INT(2) NOT NULL, ";
    public readonly string THREE_INT_NOT_NULL = " INT(3) NOT NULL, ";
    public readonly string FOUR_INT_NOT_NULL = " INT(4) NOT NULL, ";
    public readonly string MAX_INT_NOT_NULL = " INT(11) NOT NULL, ";
    public readonly string MAX_INT_UNSIGNED = " INT(11) UNSIGNED, ";
    public readonly string MAX_INT_UNSIGNED_NOT_NULL = " INT(11) UNSIGNED NOT NULL, ";
    public readonly string MAX_BIG_INT_NOT_NULL = " BIGINT(19) NOT NULL, ";
    public readonly string MAX_BIG_INT_UNSIGNED = " BIGINT(19) UNSIGNED, ";
    public readonly string MAX_BIG_INT_UNSIGNED_NOT_NULL = " BIGINT(19) UNSIGNED NOT NULL, ";
    public readonly string MAX_BIG_INT_UNSIGNED_AUTO_INCREMENT_NOT_NULL = " BIGINT(19) UNSIGNED AUTO_INCREMENT NOT NULL,";
    public readonly string LONG_BLOB = " LONGBLOB, ";
    public readonly string BLOB = " BLOB, ";
    public readonly string BLOB_NOT_NULL = " BLOB NOT NULL, ";
    public SqlTypeStrings()
    {
        this.TWELVE_CHAR_COLUMN_NOT_NULL = new StringMaker().append(CommonSeps.getInstance().SPACE).append(CHAR_COLUMN).append(this.TWELVE_SIZE).append(NOT_NULL).append(CommonSeps.getInstance().COMMA_SEP).ToString();
    }

}

