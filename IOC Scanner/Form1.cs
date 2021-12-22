using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;




namespace IOC_Scanner
{


    public partial class Form1 : Form
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();



        List<string> iocList = new List<string>();
        List<string> sanitizedIp = new List<string>();
        public static List<string> sanitizedDomain = new List<string>();
        List<string> sanitizedHash = new List<string>();
        Dictionary<string, List<string>> csvData = new Dictionary<string, List<string>>();

        List<string> fileList = new List<string>();
        public static Dictionary<string, List<string>> logsComplete = new Dictionary<string, List<string>>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AllocConsole();
        }


        public Task<IAsyncResult> loadLogs()
        {
            var taskComplete = new TaskCompletionSource<IAsyncResult>();

            DialogResult result = logFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                foreach (var file in logFileDialog.FileNames)
                {
                    fileList.Add(file);
                 

                }
                Console.WriteLine("DEBUG: Loading Complete");

            }
            return taskComplete.Task;
        }

        public Task<IAsyncResult> loadIOCFromForm()
        {
            var taskComplete = new TaskCompletionSource<IAsyncResult>();
            iocList.Clear();
            foreach (var line in inputBox.Text.Split('\n'))
            {
                iocList.Add(line);
            }
            return taskComplete.Task;
        }

        public Task<IAsyncResult> sortIOC()
        {
            var taskComplete = new TaskCompletionSource<IAsyncResult>();

            sanitizedIp.Clear();
            sanitizedDomain.Clear();
            sanitizedHash.Clear();

            foreach (var temp in iocList)
            {
                if (Regex.Match(temp, @"\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}").Success)
                {
                    sanitizedIp.Add(temp);

                }
                else if (Regex.Match(temp, "(?![\\d.]+)((?!-))(xn--)?[a-z0-9][a-z0-9-_]{0,61}[a-z0-9]{0,1}\\.(xn--)?([a-z0-9\\._-]{1,61}|[a-z0-9-]{1,30})").Success)
                {
                    sanitizedDomain.Add(temp);
                }
                else if (Regex.Match(temp, "^(((([a-z,1-9]+)|[0-9,A-Z]+))([^a-z\\.]))*").Success)
                {
                    sanitizedHash.Add(temp);
                }
            }
            return taskComplete.Task;
        }



        public Task<IAsyncResult> exportCSV()
        {
            var taskComplete = new TaskCompletionSource<IAsyncResult>();



            using (var writer = File.AppendText(@"iocs.csv"))
            {
                foreach (var i in csvData.Keys)
                {
                    foreach (var listItems in csvData[i])
                    {
                        writer.WriteLine("{0},{1},", i, listItems);
                    }
                }
            }
            return taskComplete.Task;

        }


        public static int searchposA = 0;
        public static int searchposB = 0;





        public static int entries = sanitizedDomain.Count - 1;

        StringBuilder build = new StringBuilder();






        public void enhancedScanImportFiles()
        {
            foreach (var file in fileList)
            {
                using (StreamReader r = new StreamReader(file))
                {
                    string line;
                    while ((line = r.ReadLine()) != null)
                    {
                        if (!logsComplete.ContainsKey(line))
                        {
                            logsComplete.Add(line, new List<string>());
                            logsComplete[line].Add(file);
                        }
                        else
                        {
                            logsComplete[line].Add(file);
                        }
                    }
                }
            }
        }

        public static bool matched = false;


        public static bool found = false;
        public static bool first_run = true;
        public static string ioc = "";

        public void enDo()
        {
            foreach (var entr in sanitizedDomain)
            {
                foreach (var line in logsComplete.Keys)
                {
                    foreach (char temp in line)
                    {
                        if (first_run == true)
                        {

                            ioc = entr;
                            first_run = false;
                        }
                        var aaa = "";
                        aaa = build.ToString();
                        if (found == false && aaa != ioc && first_run == false)
                        {
                            build.Clear();
                            searchposA = 0;
                        }


                        string compTemp = ioc.Substring(searchposA, 1);
                        string compTemp2 = line.Substring(searchposB, 1);
                        if (compTemp == compTemp2)
                        {
                            found = true;
                            build.Append(compTemp2);

                            if (searchposA == ioc.Length - 1)
                            {
                                searchposA = 0;
                            }
                            else
                            {
                                searchposA++;

                            }
                            searchposB++;
                        }
                        else
                        {
                            found = false;
                            searchposB++;
                        }


                        if (build.ToString() == ioc)
                        {
                            StringBuilder builder = new StringBuilder();
                            foreach (var temp1 in logsComplete[line])
                            {
                                builder.Append(temp1).Append(" ");
                            }

                            Console.WriteLine("STRING MATCH: " + build.ToString() + " " + builder.ToString());

                            this.dataGridViewOutput.Rows.Add(build.ToString(), builder.ToString());
                            if (!csvData.ContainsKey(build.ToString()))
                            {
                                csvData.Add(build.ToString(), new List<string>());
                                csvData[build.ToString()].Add(builder.ToString());
                            }
                            else
                            {
                                csvData[build.ToString()].Add(builder.ToString());
                            }

                            build.Clear();
                        }
                    }
                    first_run = true;
                    searchposA = 0;
                    searchposB = 0;
                    build.Clear();


                }
            }



        }

        public void enIp()
        {
            foreach (var entr in sanitizedIp)
            {
                foreach (var line in logsComplete.Keys)
                {
                    foreach (char temp in line)
                    {
                        if (first_run == true)
                        {

                            ioc = entr;
                            first_run = false;
                        }
                        var aaa = "";
                        aaa = build.ToString();
                        if (found == false && aaa != ioc && first_run == false)
                        {
                            build.Clear();
                            searchposA = 0;
                        }


                        string compTemp = ioc.Substring(searchposA, 1);
                        string compTemp2 = line.Substring(searchposB, 1);
                        if (build.ToString() == ioc)
                        {

                        }
                        else
                        {
                            if (compTemp == compTemp2)
                            {
                                found = true;
                                build.Append(compTemp2);

                                if (searchposA == ioc.Length - 1)
                                {
                                    searchposA = 0;
                                }
                                else
                                {
                                    searchposA++;

                                }
                                searchposB++;
                            }
                            else
                            {
                                found = false;
                                searchposB++;
                            }

                            if (build.ToString() == ioc)
                            {
                                StringBuilder builder = new StringBuilder();
                                foreach (var temp1 in logsComplete[line])
                                {
                                    builder.Append(temp1).Append(" ");
                                }

                                Console.WriteLine("STRING MATCH: " + build.ToString() + " " + builder.ToString());

                                this.dataGridViewOutput.Rows.Add(build.ToString(), builder.ToString());
                                if (!csvData.ContainsKey(build.ToString()))
                                {
                                    csvData.Add(build.ToString(), new List<string>());
                                    csvData[build.ToString()].Add(builder.ToString());
                                }
                                else
                                {
                                    csvData[build.ToString()].Add(builder.ToString());
                                }

                                build.Clear();
                            }
                        }

                    }
                    first_run = true;
                    searchposA = 0;
                    searchposB = 0;
                    build.Clear();


                }
            }



        }

        public void enHa()
        {
            foreach (var entr in sanitizedHash)
            {
                foreach (var line in logsComplete.Keys)
                {
                    foreach (char temp in line)
                    {
                        if (first_run == true)
                        {

                            ioc = entr;
                            first_run = false;
                        }
                        if (found == false && build.ToString() != ioc && first_run == false)
                        {
                            build.Clear();
                            searchposA = 0;
                        }


                        string compTemp = ioc.Substring(searchposA, 1);
                        string compTemp2 = line.Substring(searchposB, 1);
                        if (compTemp == compTemp2)
                        {
                            found = true;
                            build.Append(compTemp2);
                            if (searchposA == ioc.Length - 1)
                            {
                                searchposA = 0;
                            }
                            else
                            {
                                searchposA++;

                            }
                            searchposB++;
                        }
                        else
                        {
                            found = false;
                            searchposB++;
                        }

                        if (build.ToString() == ioc)
                        {
                            StringBuilder builder = new StringBuilder();
                            foreach (var temp1 in logsComplete[line])
                            {
                                builder.Append(temp1).Append(" ");
                            }

                            Console.WriteLine("STRING MATCH: " + build.ToString() + " " + builder.ToString());

                            this.dataGridViewOutput.Rows.Add(build.ToString(), builder.ToString());
                            if (!csvData.ContainsKey(build.ToString()))
                            {
                                csvData.Add(build.ToString(), new List<string>());
                                csvData[build.ToString()].Add(builder.ToString());
                            }
                            else
                            {
                                csvData[build.ToString()].Add(builder.ToString());
                            }

                            build.Clear();
                        }

                    }
                    first_run = true;
                    searchposA = 0;
                    searchposB = 0;
                    build.Clear();
                }
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            loadLogs();
            enhancedScanImportFiles();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            this.dataGridViewOutput.Rows.Clear();
            loadIOCFromForm();
            sortIOC();
            enIp();
            enDo();
            enHa();

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            exportCSV();
        }
    }
}