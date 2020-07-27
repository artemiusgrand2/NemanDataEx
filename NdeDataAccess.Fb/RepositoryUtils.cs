using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using FirebirdSql.Data.FirebirdClient;

namespace NdeDataAccessFb
{
    public static class RepositoryUtils
    {
        public static void AddArrayParameters<T>(this FbCommand cmd, string name, IEnumerable<T> values)
        {
            name = name.StartsWith("@") ? name : "@" + name;
            var names = string.Join(", ", values.Select((value, i) => {
                var paramName = name + i;
                cmd.Parameters.AddWithValue(paramName, value);
                return paramName;
            }));
            cmd.CommandText = cmd.CommandText.Replace(name, names);
        }

        public static string GetStringSafely(this IDataReader dataReader, int columnIndex)
        {
            if (dataReader.IsDBNull(columnIndex))
            {
                return string.Empty;
            }
            return dataReader.GetString(columnIndex).TrimEnd();
        }

        public static int GetInt16Safely(this IDataReader dataReader, int columnIndex)
        {
            if (dataReader.IsDBNull(columnIndex))
            {
                return -1;
            }
            return dataReader.GetInt16(columnIndex);
        }

        public static int GetInt16SafelyOr0(this IDataReader dataReader, int columnIndex)
        {
            if (dataReader.IsDBNull(columnIndex))
            {
                return 0;
            }
            return dataReader.GetInt16(columnIndex);
        }


        public static int GetInt32Safely(this IDataReader dataReader, int columnIndex)
        {
            if (dataReader.IsDBNull(columnIndex))
            {
                return -1;
            }
            return dataReader.GetInt32(columnIndex);
        }
        public static int GetInt32SafelyOr0(this IDataReader dataReader, int columnIndex)
        {
            if (dataReader.IsDBNull(columnIndex))
            {
                return 0;
            }
            return dataReader.GetInt32(columnIndex);
        }


        public static int GetByteSafely(this IDataReader dataReader, int columnIndex)
        {
            if (dataReader.IsDBNull(columnIndex))
            {
                return -1;
            }
            return dataReader.GetByte(columnIndex);
        }

        public static DateTime GetMinDateTimeIfNull(this IDataReader dataReader, int columnIndex)
        {
            if (dataReader.IsDBNull(columnIndex))
            {
                return DateTime.MinValue;
            }
            return dataReader.GetDateTime(columnIndex);
        }

        public static string GetFromString(this string data,  int lenght)
        {
            return data.Substring(0, (data.Length < lenght) ? data.Length : lenght);
        }
    }
}
