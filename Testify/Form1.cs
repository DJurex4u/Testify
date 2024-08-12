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
using System.IO;
using System.Xml;
using System.IO.Pipes;

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
            string baseUrl = "http://127.0.0.1:8000/";//txtBaseUrl.Text;
            string endpoint = "client/";// txtEndpoint.Text;
            string body = "";//txtBody.Text;
            string headers = txtHeaders.Text;

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
            //txtBody.Text = text.ToString();


            //if (!string.IsNullOrWhiteSpace(txtName.Text) && !lstNames.Items.Contains(txtName.Text))
            //    lstNames.Items.Add(txtName.Text);

            HttpClient client = GetHttpClient(baseUrl);
            //HttpResponseMessage response = HttpClientExtensions.SendAsJsonAsync<Employee>(client, HttpMethod.Post, "emp/v1/emp/details/new", emp).Result;
            //HttpContent content = new HttpContent();

            //StringContent content = new StringContent(JsonSerializer.Serialize(new
            //{
            //    email = "client@example.com",
            //    password = "123456"
            //}), Encoding.UTF8, "application/json");

            StringContent content = new StringContent(body);

            if (comboHttpMethods.Text == "POST")
            {
                var result = await client.PostAsync(endpoint, content);
                string resultContent = await result.Content.ReadAsStringAsync();
                Console.WriteLine(resultContent);
            }
        }

        public static HttpClient GetHttpClient(string baseUri)
        {
            HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri("http://127.0.0.1:8000/");
            client.BaseAddress = new Uri(baseUri);

            client.Timeout = new TimeSpan(0, 2, 0);
            //client.DefaultRequestHeaders.Add("Authorization", SettingsBindableAttribute.Value.AccessToken);
            //client.DefaultRequestHeaders.Add("Authorization", SettingsBindableAttribute.Value.AccessToken);

            //var defaultRequestHeaders = client.DefaultRequestHeaders;
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var str = txtEndpoint.Text;
            string name = new string((from c in str
                                      where char.IsWhiteSpace(c) || char.IsLetterOrDigit(c)
                                      select c
                   ).ToArray());

            StreamWriter sw = new StreamWriter(Application.StartupPath + "\\Saved\\" + name + comboHttpMethods.Text + ".txt");
            sw.WriteLine(txtBaseUrl.Text + "|||");
            sw.WriteLine(txtEndpoint.Text + "|||");
            sw.WriteLine(comboHttpMethods.Text + "|||");
            sw.WriteLine(txtHeaders.Text + "|||");
            sw.WriteLine(txtBody.Text + "|||");
            sw.WriteLine(txtResponseCode.Text + "|||");
            sw.Close();

            //using (XmlTextWriter textWriter = new XmlTextWriter(Application.StartupPath + "\\Saved\\" + name + ".xml", null))
            //{
            //    textWriter.Formatting = Formatting.Indented;
            //    textWriter.Indentation = 4;
            //    textWriter.

            //    textWriter.WriteStartDocument();
            //    textWriter.WriteStartElement("TestPlan");
            //    textWriter.WriteAttributeString("DateTime", DateTime.Now.ToString());

            //    textWriter.WriteElementString("BaseUrl", txtBaseUrl.Text);
            //    textWriter.WriteElementString("Endpoint", txtEndpoint.Text);

            //    var str = comboHttpMethods.Text;
            //    string name = new string((from c in str
            //                              where char.IsWhiteSpace(c) || char.IsLetterOrDigit(c)
            //                              select c
            //           ).ToArray());

            //    textWriter.WriteElementString("HttpMethod", comboHttpMethods.Text);

            //    textWriter.WriteStartElement("TestPlan");

            //    using (StringReader reader = new StringReader(input))
            //    {
            //        string line;
            //        while ((line = reader.ReadLine()) != null)
            //        {
            //            // Do something with the line
            //        }
            //    }

            //    textWriter.WriteEndElement();

            //    textWriter.WriteElementString("Headers", txtHeaders.Text);
            //    textWriter.WriteElementString("Body", txtBody.Text);
            //    textWriter.WriteElementString("ResponseCode", txtResponseCode.Text);

            //    textWriter.WriteEndElement();
            //    textWriter.WriteEndDocument();
            //    textWriter.Close();
            //}
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Application.StartupPath + "\\Saved\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader sw = new StreamReader(fileStream))
                    {
                        string text = sw.ReadToEnd();                            

                        string[] separatingStrings = { "|||\r\n", "|||" };
                        
                        System.Console.WriteLine($"Original text: '{text}'");

                        string[] words = text.Split(separatingStrings, System.StringSplitOptions.RemoveEmptyEntries);
                        //System.Console.WriteLine($"{words.Length} substrings in text:");

                        txtBaseUrl.Text = words[0];
                        txtEndpoint.Text = words[1];
                        comboHttpMethods.Text = words[2];
                        txtHeaders.Text = words[3];
                        txtBody.Text = words[4];
                        txtResponseCode.Text = words[5];
                    }
                }
            }
        }
    }
}
