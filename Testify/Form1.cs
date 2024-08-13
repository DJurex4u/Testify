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
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private async void button1_Click_1(object sender, EventArgs e)
        {
            string baseUrl = txtBaseUrl.Text;
            string endpoint = txtEndpoint.Text;
            string headers = txtHeaders.Text;
            string body = txtBody.Text;
            
            HttpClient client = GetHttpClient(baseUrl);
            
            StringContent content = new StringContent(body, Encoding.UTF8, "application/json");
            HttpResponseMessage result;
            string resultContent = string.Empty;

            if (comboHttpMethods.Text == "GET")
            {
                result = await client.GetAsync(endpoint);
                resultContent = await result.Content.ReadAsStringAsync();
                Console.WriteLine(resultContent);
            }            

            if (comboHttpMethods.Text == "POST")
            {
                result = await client.PostAsync(endpoint, content);
                resultContent = await result.Content.ReadAsStringAsync();
                Console.WriteLine(resultContent);
            }
            
            if (comboHttpMethods.Text == "PUT")
            {
                result = await client.PutAsync(endpoint, content);
                resultContent = await result.Content.ReadAsStringAsync();
                Console.WriteLine(resultContent);
            }
            
            if (comboHttpMethods.Text == "DELETE")
            {
                result = await client.DeleteAsync(endpoint);
                resultContent = await result.Content.ReadAsStringAsync();
                Console.WriteLine(resultContent);
            }
        }

        private HttpClient GetHttpClient(string baseUri)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseUri);
            client.Timeout = new TimeSpan(0, 2, 0);

            if (chkAuthorisationSettings.Checked)
            {
                var filePath = string.Empty;                
                filePath = Application.StartupPath + "\\Saved\\Authorization.txt";

                using (StreamReader sw = new StreamReader(filePath))
                {
                    string text = sw.ReadToEnd();
                    client.DefaultRequestHeaders.Add("Authorization", text);
                    Console.WriteLine(text);
                }
            }            
           
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));            
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
            sw.WriteLine(chkAuthorisationSettings.Checked + "|||");
            sw.Close();           
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

                        string[] words = text.Split(separatingStrings, System.StringSplitOptions.None);
                        //System.Console.WriteLine($"{words.Length} substrings in text:");

                        txtBaseUrl.Text = words[0];
                        txtEndpoint.Text = words[1];
                        comboHttpMethods.Text = words[2];
                        txtHeaders.Text = words[3];
                        txtBody.Text = words[4];
                        txtResponseCode.Text = words[5];
                        chkAuthorisationSettings.Checked = bool.Parse(words[6]);
                    }
                }
            }
        }        
    }
}
