using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Text.Json;

namespace Testify
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void lblTestName_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void button1_Click_1(object sender, EventArgs e)
        {
            StringBuilder text = new StringBuilder();
            text
            .Append(txtBaseUrl.Text)
            .Append("/")
            .Append(txtEndpoint.Text)
            .Append(comboHttpMethods.Text)
            .Append(" ")
            .Append(txtHeaders.Text)
            .Append(" ")
            .Append(" kraj ");
            txtBody.Text = text.ToString();

            if (comboHttpMethods.Text == "GET")
            {
                txtBody.Text = "ssdfsdfsdfsdfsdfsdfsdffsfds";
            }
            //if (!string.IsNullOrWhiteSpace(txtName.Text) && !lstNames.Items.Contains(txtName.Text))
            //    lstNames.Items.Add(txtName.Text);

            HttpClient client = GetHttpClient();
            //HttpResponseMessage response = HttpClientExtensions.SendAsJsonAsync<Employee>(client, HttpMethod.Post, "emp/v1/emp/details/new", emp).Result;
            //HttpContent content = new HttpContent();

            StringContent content = new StringContent(JsonSerializer.Serialize(new
            {
                email = "client@example.com",
                password = "123456"
            }), Encoding.UTF8, "application/json");

            var result = await client.PostAsync("client/", content);
            string resultContent = await result.Content.ReadAsStringAsync();
            Console.WriteLine(resultContent);
        }

        public static HttpClient GetHttpClient()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://127.0.0.1:8000/");
            client.Timeout = new TimeSpan(0, 2, 0);
            //client.DefaultRequestHeaders.Add("Authorization", SettingsBindableAttribute.Value.AccessToken);
            //client.DefaultRequestHeaders.Add("Authorization", SettingsBindableAttribute.Value.AccessToken);

            //var defaultRequestHeaders = client.DefaultRequestHeaders;
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }
    }
}
