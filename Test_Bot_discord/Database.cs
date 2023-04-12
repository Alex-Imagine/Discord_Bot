using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using MySql.Data.MySqlClient;
namespace Test_Bot_discord.Commands
{
    public class Database
    {
        private MySqlConnection _connection = null;

        private MySqlCommand _command = null;
       
        public void SetConnectionDatabase(string NameTable)
        {
            _connection = new MySqlConnection("server=localhost;database="+NameTable+";user=root;password=0000");           
            _command = _connection.CreateCommand();
        }
        public Database AddParam<T>(string name, T value)
        {
            MySqlParameter parameter = new MySqlParameter();

            parameter.ParameterName = name;
            parameter.Value = value;

            _command.Parameters.Add(parameter);

            return this;
        }

        public T ExecuteScalar<T>(string query, bool isStoredProc = false)
        {
            T result = default(T);

            using (_connection)
            {
                if (isStoredProc)
                {
                    _command.CommandType = CommandType.StoredProcedure;
                }
                _command.CommandText = query;

                _connection.Open();

                result = (T)_command.ExecuteScalar();

            }

            return result;
        }

        public IEnumerable<T> ExecuteQuery<T>(string query, bool isStoredProc = false)
        {
            IList<T> list = new List<T>();
            Type t = typeof(T);
            using (_connection)
            {
                if (isStoredProc)
                {
                    _command.CommandType = CommandType.StoredProcedure;
                }
                _command.CommandText = query;

                _connection.Open();
                var reader = _command.ExecuteReader();
                while (reader.Read())
                {
                    T obj = (T)Activator.CreateInstance(t);

                    t.GetProperties().ToList().ForEach(p =>
                    {
                        p.SetValue(obj, reader[p.Name]);
                    });

                    list.Add(obj);
                }
            }

            return list;
        }

        public int ExecuteNonQuery(string query, bool isStoredProc = false)
        {

            int noOfAffected = 0;

            using (_connection)
            {
                if (isStoredProc)
                {
                    _command.CommandType = CommandType.StoredProcedure;
                }
                _command.CommandText = query;

                _connection.Open();

                noOfAffected = _command.ExecuteNonQuery();
            }

            return noOfAffected;
        }


    }
}
