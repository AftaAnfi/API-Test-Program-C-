using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FakeEmailAPIGetter
{
    public partial class Form1 : Form
    {
        private readonly HttpClient _httpClient;
        string url = "https://www.1secmail.com/api/v1/?action=genRandomMailbox&count=10";
        public Form1()
        {

            InitializeComponent();
            _httpClient = new HttpClient();
            button1.Click += async (o, e) =>
            {
                string stringData = await _httpClient.GetStringAsync(url);
                dosomethingwithdata(stringData);

                
            };
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dosomethingwithdata(string s)
        {
            textBox1.Text = s;

            string[] stringarray = s.Split(',');

            for (int i = 0; i < stringarray.Length; i++)
            {
                string str = stringarray[i].ToString();
                str = str.Replace('\"', ' ');
                str = str.Replace('[', ' ');
                str = str.Replace('"', ' ');
                str = str.Replace(']', ' ');
                str = str.Trim();
                textBox1.Text = str;
                listBox1.Items.Add(str);
            }
        }
    }
}
