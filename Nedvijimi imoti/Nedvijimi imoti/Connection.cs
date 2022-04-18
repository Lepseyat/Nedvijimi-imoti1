using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using System.Data.SqlClient;

namespace Nedvijimi_imoti
{
    internal class Connection
    {
        OleDbConnection connection;
        OleDbCommand command;
        
        public List<string> ListboxItems = new List<string>();
        public List<int> ListboxItems1 = new List<int>();
        private void ConnectTo()
        {
            connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\1\\Desktop\\Imoti.accdb");
            command = connection.CreateCommand();
        }
        public Connection()
        {
            ConnectTo();
        }

        public void Insert(Imoti p)
        {
            try
            {
                //command.CommandText = "INSERT INTO Bikes(ModelID, VersionID, Price, [Note]) VALUES (1, 2, 1, 'asa')";
                command.CommandText = "INSERT INTO Imoti([tip], adres, [sobstvenik], cena, plosht, stai, etaji, etaj, ploshtzadendvor) VALUES (" + "'" + p.tip + "'" + "," + p.adres + "," + "'" + p.sobstvenik + "'" + "," + p.cena + "," + p.plosht + "," + p.stai + "," + p.etaji + "," + p.etaj + "," + p.ploshtzadendvor + ")";
                command.CommandType = CommandType.Text;
                // command.Connection = connection;
                connection.Open();
                command.ExecuteNonQuery();
                MessageBox.Show("Данните са запаметени!");
            }
            catch (Exception)
            {
                //throw;
                MessageBox.Show("Некоректни данни! Моля въведете отново!");
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        public void Update (Imoti p)
        {
            try
            {

                command.CommandText = "Update Imoti Set tip='" + p.tip + "' ,adres='" + p.adres + "' ,sobstvenik='" + p.sobstvenik + "' ,cena='" + p.cena + "' ,plosht='" + p.plosht + "' ,stai='" + p.stai + "' ,etaji='" + p.etaji + "' ,etaj='" + p.etaj + "' ,ploshtzadendvor='" + p.ploshtzadendvor + "' Where ImotID=" + p.ImotID + "";

                command.CommandType = CommandType.Text;

                MessageBox.Show(CommandType.Text.ToString());

                connection.Open();
                command.ExecuteNonQuery();
                MessageBox.Show("Успешна корекция");
                
            }
            catch (Exception)
            {
                //throw;
                MessageBox.Show("Некоректни данни! Моля въведете отново!");
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        public void Delete(Imoti p)
        {
            try
            {
                //command.CommandText = "INSERT INTO Bikes(ModelID, VersionID, Price, [Note]) VALUES (1, 2, 1, 'asa')";
                command.CommandText = "Delete From Imoti Where ImotID=" + p.ImotID;

                command.CommandType = CommandType.Text;
                // command.Connection = connection;
                connection.Open();
                command.ExecuteNonQuery();
                MessageBox.Show("Успешно изтрит имот");
            }
            catch (Exception)
            {
                //throw;
                MessageBox.Show("Некоректни данни! Моля въведете отново!");
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        public void SortiranePoIme(List<Imoti> aktiviList)
        {
            using (OleDbConnection connection = this.connection)
            {
                try
                {
                    connection.Open();
                    OleDbCommand command = new OleDbCommand("Select * From Imoti ORDER BY sobstvenik ASC", connection);
                    OleDbDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Imoti a = new Imoti();
                        a.ImotID = reader.GetInt32(0);
                        a.tip = reader.GetString(1);
                        a.adres = reader.GetInt32(2);
                        a.sobstvenik = reader.GetString(3);
                        a.cena = reader.GetDouble(4);
                        a.plosht = reader.GetDouble(5);
                        a.stai = reader.GetInt32(6);
                        a.etaji = reader.GetInt32(7);
                        a.etaj = reader.GetInt32(8);
                        a.ploshtzadendvor = reader.GetDouble(9);
                        


                        aktiviList.Add(a);


                    }


                    reader.Close();
                }


                catch (Exception)
                {
                    MessageBox.Show("Whatever");
                }
                finally
                {
                    connection.Close();
                }




            }
        }

        
        public void cenapogolqma50k(List<Imoti> aktiviList)
        {
            using (OleDbConnection connection = this.connection)
            {
                try
                {
                    connection.Open();
                    OleDbCommand command = new OleDbCommand("SELECT * FROM Imoti WHERE cena>50000", connection);
                    OleDbDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Imoti a = new Imoti();
                        a.ImotID = reader.GetInt32(0);
                        a.tip = reader.GetString(1);
                        a.adres = reader.GetInt32(2);
                        a.sobstvenik = reader.GetString(3);
                        a.cena = reader.GetDouble(4);
                        a.plosht = reader.GetDouble(5);
                        a.stai = reader.GetInt32(6);
                        a.etaji = reader.GetInt32(7);
                        a.etaj = reader.GetInt32(8);
                        a.ploshtzadendvor = reader.GetDouble(9);



                        aktiviList.Add(a);


                    }


                    reader.Close();
                }


                catch (Exception)
                {
                    MessageBox.Show("Whatever");
                }
                finally
                {
                    connection.Close();
                }




            }
        }

        public void cenapomalka50k(List<Imoti> aktiviList)
        {
            using (OleDbConnection connection = this.connection)
            {
                try
                {
                    connection.Open();
                    OleDbCommand command = new OleDbCommand("SELECT * FROM Imoti WHERE cena<50000", connection);
                    OleDbDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Imoti a = new Imoti();
                        a.ImotID = reader.GetInt32(0);
                        a.tip = reader.GetString(1);
                        a.adres = reader.GetInt32(2);
                        a.sobstvenik = reader.GetString(3);
                        a.cena = reader.GetDouble(4);
                        a.plosht = reader.GetDouble(5);
                        a.stai = reader.GetInt32(6);
                        a.etaji = reader.GetInt32(7);
                        a.etaj = reader.GetInt32(8);
                        a.ploshtzadendvor = reader.GetDouble(9);



                        aktiviList.Add(a);


                    }


                    reader.Close();
                }


                catch (Exception)
                {
                    MessageBox.Show("Whatever");
                }
                finally
                {
                    connection.Close();
                }




            }
        }

        public void kyshta(List<Imoti> aktiviList)
        {
            using (OleDbConnection connection = this.connection)
            {
                try
                {
                    connection.Open();
                    OleDbCommand command = new OleDbCommand("SELECT * FROM Imoti WHERE tip='kyshta'", connection);
                    OleDbDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Imoti a = new Imoti();
                        a.ImotID = reader.GetInt32(0);
                        a.tip = reader.GetString(1);
                        a.adres = reader.GetInt32(2);
                        a.sobstvenik = reader.GetString(3);
                        a.cena = reader.GetDouble(4);
                        a.plosht = reader.GetDouble(5);
                        a.stai = reader.GetInt32(6);
                        a.etaji = reader.GetInt32(7);
                        a.etaj = reader.GetInt32(8);
                        a.ploshtzadendvor = reader.GetDouble(9);



                        aktiviList.Add(a);


                    }


                    reader.Close();
                }


                catch (Exception)
                {
                    MessageBox.Show("Whatever");
                }
                finally
                {
                    connection.Close();
                }




            }
        }

        public void apartament(List<Imoti> aktiviList)
        {
            using (OleDbConnection connection = this.connection)
            {
                try
                {
                    connection.Open();
                    OleDbCommand command = new OleDbCommand("SELECT * FROM Imoti WHERE tip='apartament'", connection);
                    OleDbDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Imoti a = new Imoti();
                        a.ImotID = reader.GetInt32(0);
                        a.tip = reader.GetString(1);
                        a.adres = reader.GetInt32(2);
                        a.sobstvenik = reader.GetString(3);
                        a.cena = reader.GetDouble(4);
                        a.plosht = reader.GetDouble(5);
                        a.stai = reader.GetInt32(6);
                        a.etaji = reader.GetInt32(7);
                        a.etaj = reader.GetInt32(8);
                        a.ploshtzadendvor = reader.GetDouble(9);



                        aktiviList.Add(a);


                    }


                    reader.Close();
                }


                catch (Exception)
                {
                    MessageBox.Show("Whatever");
                }
                finally
                {
                    connection.Close();
                }




            }
        }

        public void cityVarna(List<Imoti> aktiviList)
        {
            using (OleDbConnection connection = this.connection)
            {
                try
                {
                    connection.Open();
                    OleDbCommand command = new OleDbCommand("SELECT * FROM Imoti WHERE adres='Varna'", connection);
                    OleDbDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Imoti a = new Imoti();
                        a.ImotID = reader.GetInt32(0);
                        a.tip = reader.GetString(1);
                        a.adres = reader.GetInt32(2);
                        a.sobstvenik = reader.GetString(3);
                        a.cena = reader.GetDouble(4);
                        a.plosht = reader.GetDouble(5);
                        a.stai = reader.GetInt32(6);
                        a.etaji = reader.GetInt32(7);
                        a.etaj = reader.GetInt32(8);
                        a.ploshtzadendvor = reader.GetDouble(9);



                        aktiviList.Add(a);


                    }


                    reader.Close();
                }


                catch (Exception)
                {
                    MessageBox.Show("Whatever");
                }
                finally
                {
                    connection.Close();
                }




            }
        }





      /*  public void selectPrice(Int32 v1, Int32 v2, List<Imoti> aktiviList)
        {
            using (OleDbConnection connection = this.connection)
            {
                try
                {
                    
                    

                    connection.Open();
                    OleDbCommand command = new OleDbCommand("Select * From Imoti Where cena Between  @v1  and  @v2", connection);
                    OleDbDataReader reader = command.ExecuteReader();
                    OleDbDataAdapter da = new OleDbDataAdapter(sql)




                    //command.Parameters.Add("?", OleDbType.Integer, 5).Value = 50000;

                    // command.Parameters.Add(parameters[v1]);

                    // new OleDbParameter("@V1", v1);

                    //command.Parameters.Add("@v1", SqlDbType.Int);
                    // command.Parameters["@v1"].Value = v1;

                    while (reader.Read())
                    {
                        Imoti a = new Imoti();
                        a.ImotID = reader.GetInt32(0);
                        a.tip = reader.GetString(1);
                        a.adres = reader.GetInt32(2);
                        a.sobstvenik = reader.GetString(3);
                        a.cena = reader.GetDouble(4);
                        a.plosht = reader.GetDouble(5);
                        a.stai = reader.GetInt32(6);
                        a.etaji = reader.GetInt32(7);
                        a.etaj = reader.GetInt32(8);
                        a.ploshtzadendvor = reader.GetDouble(9);



                        aktiviList.Add(a);


                    }


                    reader.Close();
                }


                catch (Exception)
                {
                    MessageBox.Show("Whatever");
                }
                finally
                {
                    connection.Close();
                }




            }
        } */



    }
}
