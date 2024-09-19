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
using System.Net;
using NUnit.Framework;

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
            HttpResponseMessage result = null;
            string resultContent = string.Empty;
            string requestContent = string.Empty;

            try
            {
                result = await SendRequestAsync(client, endpoint, comboHttpMethods.Text, content);
                if (result == null) throw new Exception("Something went wrong. Could not get the response.");

                resultContent = await result.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtResponseCode.Text == ((Int32)result.StatusCode).ToString())
            {
                lblResponseCodeCheck.Text = "✓";
                lblResponseCodeCheck.ForeColor = Color.Green;
                lblResponseCodeCheck.Visible = true;
            }
            else
            {
                lblResponseCodeCheck.Text = "X";
                lblResponseCodeCheck.ForeColor = Color.Red;
                lblResponseCodeCheck.Visible = true;
            }

            var str = txtEndpoint.Text;
            string name = new string((from c in str
                                      where char.IsWhiteSpace(c) || char.IsLetterOrDigit(c)
                                      select c
                   ).ToArray());

            GenerateTxtReport(name, result, resultContent);
            GenerateCsvReport(name, result, resultContent);
            GenerateHtmlReport(name, result, resultContent);
        }

        private void GenerateHtmlReport(string name, HttpResponseMessage result, string resultContent)
        {
        }

        private void GenerateCsvReport(string name, HttpResponseMessage result, string resultContent)
        {
            StreamWriter sw = new StreamWriter(Application.StartupPath + "\\ReportCSV\\" + name + comboHttpMethods.Text + "_REPORT.txt");
            
            try
            {
                #region ...
                sw.WriteLine(txtBaseUrl.Text + txtEndpoint.Text + ",");
                sw.WriteLine(comboHttpMethods.Text + ",");
                sw.WriteLine(txtHeaders.Text + ",");
                sw.WriteLine(txtBody.Text);
                sw.WriteLine(txtResponseCode.Text + ",");
                #endregion

                Assert.That(txtResponseCode.Text, Is.EqualTo(((Int32)result.StatusCode).ToString()));
                sw.WriteLine("Test passed successfully,");
                sw.WriteLine(resultContent);
            }
            catch (Exception ex)
            {
                sw.WriteLine(ex.Message);
            }

            sw.Close();
        }

        private void GenerateTxtReport(string name, HttpResponseMessage result, string resultContent)
        {
            StreamWriter sw = new StreamWriter(Application.StartupPath + "\\ReportTxt\\" + name + comboHttpMethods.Text + "_REPORT.txt");
            
            try
            {
                sw.WriteLine("When I send " + comboHttpMethods.Text + " request to " + txtBaseUrl.Text + txtEndpoint.Text + " endpoint");
                sw.WriteLine("With custom headers:" + txtHeaders.Text);
                sw.WriteLine("and body: ");
                sw.WriteLine(txtBody.Text);
                sw.WriteLine("I verify response code is: " + txtResponseCode.Text);
                                
                Assert.That(((Int32)result.StatusCode).ToString(), Is.EqualTo(txtResponseCode.Text));
                sw.WriteLine("Test passed successfully");

                sw.WriteLine("Response:");
                sw.WriteLine(resultContent);
            }
            catch (Exception ex)
            {
                sw.WriteLine(ex.Message);
            }
            
            sw.Close();
        }

        private async Task<HttpResponseMessage> SendRequestAsync(HttpClient client, string endpoint, string text, StringContent content)
        {
            HttpResponseMessage result = null;

            if (text == "GET")
            {
                result = await client.GetAsync(endpoint);
            }

            if (text == "POST")
            {
                result = await client.PostAsync(endpoint, content);
            }

            if (text == "PUT")
            {
                result = await client.PutAsync(endpoint, content);
            }

            if (text == "DELETE")
            {
                result = await client.DeleteAsync(endpoint);
            }

            return result;
        }

        private HttpClient GetHttpClient(string baseUri)
        {
            HttpClient client = new HttpClient();

            try
            {
                client.BaseAddress = new Uri(baseUri);
                client.Timeout = new TimeSpan(0, 2, 0);

                if (chkAuthorisationSettings.Checked)
                {
                    var filePath = string.Empty;
                    filePath = Application.StartupPath + "\\Saved\\Authorization.txt";

                    using (StreamReader sw = new StreamReader(filePath))
                    {
                        string text = sw.ReadToEnd();
                        client.DefaultRequestHeaders.Add("Authorization", "Bearer " + text);
                        Console.WriteLine(text);
                    }
                }

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return client;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var str = txtEndpoint.Text;
            string name = new string((from c in str
                                      where char.IsWhiteSpace(c) || char.IsLetterOrDigit(c)
                                      select c
                   ).ToArray());
            string path = Application.StartupPath + "\\Saved\\" + name + comboHttpMethods.Text + ".txt";

            SaveSerializedParams(path);
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

                    LoadDeserializedParams(fileStream);
                }
            }
        }
        private void SaveSerializedParams(string path)
        {
            StreamWriter sw = new StreamWriter(path);
            sw.WriteLine(txtBaseUrl.Text + "|||");
            sw.WriteLine(txtEndpoint.Text + "|||");
            sw.WriteLine(comboHttpMethods.Text + "|||");
            sw.WriteLine(txtHeaders.Text + "|||");
            sw.WriteLine(txtBody.Text + "|||");
            sw.WriteLine(txtResponseCode.Text + "|||");
            sw.WriteLine(chkAuthorisationSettings.Checked + "|||");
            sw.Close();
        }
        private void LoadDeserializedParams(Stream fileStream)
        {
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
