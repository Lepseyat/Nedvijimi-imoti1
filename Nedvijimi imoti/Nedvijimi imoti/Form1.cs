using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;

using System.Data.OleDb;


namespace Nedvijimi_imoti
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        Connection b = new Connection();
        private void button1_Click(object sender, EventArgs e)
        {
            Imoti p = new Imoti();
            p.tip = textBox2.Text;
            p.adres = Int32.Parse(textBox3.Text);
            p.sobstvenik = textBox4.Text;
            p.cena = Double.Parse(textBox5.Text);
            p.plosht = Double.Parse(textBox6.Text);
            p.stai = Int32.Parse(textBox7.Text);
            p.etaji = Int32.Parse(textBox8.Text);
            p.ploshtzadendvor = Double.Parse(textBox9.Text);
            p.etaj = Int32.Parse(textBox10.Text);
            b.Insert(p);


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Imoti p = new Imoti();
            p.ImotID = Int32.Parse(textBox1.Text);
            p.tip = textBox2.Text;
            p.adres = Int32.Parse(textBox3.Text);
            p.sobstvenik = textBox4.Text;
            p.cena = Double.Parse(textBox5.Text);
            p.plosht = Double.Parse(textBox6.Text);
            p.stai = Int32.Parse(textBox7.Text);
            p.etaji = Int32.Parse(textBox8.Text);
            p.ploshtzadendvor = Double.Parse(textBox9.Text);
            p.etaj = Int32.Parse(textBox10.Text);
            b.Update(p);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Imoti p = new Imoti();
            p.ImotID = Int32.Parse(textBox1.Text);
            b.Delete(p);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            List<Imoti> aktiviList = new List<Imoti>();
            var p = new Connection();
            p.SortiranePoIme(aktiviList);

            var source = new BindingSource();
            source.DataSource = aktiviList;
            dataGridView1.DataSource = source;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            List<Imoti> aktiviList = new List<Imoti>();
            var p = new Connection();
            p.cenapogolqma50k(aktiviList);

            var source = new BindingSource();
            source.DataSource = aktiviList;
            dataGridView1.DataSource = source;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            List<Imoti> aktiviList = new List<Imoti>();
            var p = new Connection();
            p.cenapomalka50k(aktiviList);

            var source = new BindingSource();
            source.DataSource = aktiviList;
            dataGridView1.DataSource = source;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            
            List<Imoti> aktiviList = new List<Imoti>();
            var p = new Connection();
            p.kyshta(aktiviList);

            var source = new BindingSource();
            source.DataSource = aktiviList;
            dataGridView1.DataSource = source;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            List<Imoti> aktiviList = new List<Imoti>();
            var p = new Connection();
            p.apartament(aktiviList);

            var source = new BindingSource();
            source.DataSource = aktiviList;
            dataGridView1.DataSource = source;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            List<Imoti> aktiviList = new List<Imoti>();
            var p = new Connection();
            p.cityVarna(aktiviList);

            var source = new BindingSource();
            source.DataSource = aktiviList;
            dataGridView1.DataSource = source;
        }

        private void button10_Click(object sender, EventArgs e)
        {

            OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\1\\Desktop\\Imoti.accdb");
            DataTable dt = new DataTable();
           
            con.Open();
            string sql = "SELECT * FROM Imoti WHERE cena Between  @v1  and  @v2";
            OleDbDataAdapter da = new OleDbDataAdapter(sql, con);
            da.SelectCommand.Parameters.AddWithValue("@v1", textBox11.Text);
            da.SelectCommand.Parameters.AddWithValue("@v2", textBox12.Text);
            da.Fill(dt);
            con.Close();
            dataGridView1.DataSource = dt;





            //  int v1 = Int32.Parse(textBox11.Text);
            //  int v2 = Int32.Parse(textBox12.Text);
            //
            //  List<Imoti> aktiviList = new List<Imoti>();
            //  var p = new Connection();
            //  p.selectPrice(v1, v2 ,aktiviList);


            //  var source = new BindingSource();
            // source.DataSource = aktiviList;
            //  dataGridView1.DataSource = source;
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
    }
}