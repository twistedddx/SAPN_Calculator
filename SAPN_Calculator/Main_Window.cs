using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

enum EnergyClass
{
    Import,
    Export,
    ControlledLoad
}

enum EnergyBracket
{
    Peak,
    Offpeak,
    Shoulder
}

enum ReportDuration
{
    Hourly,
    Daily,
    Monthly,
    Seasonly,
    Yearly
}

enum ReportSchedule
{
    Peak,
    TOU,
    DayNight
}

enum LogLevel
{
    Info,
    Warn,
    Debug
}

namespace SAPN_Calculator
{
    public partial class SAPN_Calculator : Form
    {
        //0=peak,1=offpeak,2=shoulder
        //Hour starting             0  1  2  3  4  5  6  7  8  9  10 11 12 13 14 15 16 17 18 19 20 21 22 23
        readonly int[] SchedulePeak      = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        readonly int[] ScheduleTOU       = { 0, 1, 1, 1, 1, 1, 0, 0, 0, 0, 2, 2, 2, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        readonly int[] ScheduleDayNight  = { 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1 };


        static string filePath = string.Empty;

        static int meterNum = 0;

        public SAPN_Calculator()
        {
            InitializeComponent();

            comboBox_duration.DataSource = Enum.GetValues(typeof(ReportDuration));
            comboBox_duration.SelectedItem = ReportDuration.Monthly;

            comboBox_schedule.DataSource = Enum.GetValues(typeof(ReportSchedule));
            comboBox_schedule.SelectedItem = ReportSchedule.TOU;

            comboBox_loglevel.DataSource = Enum.GetValues(typeof(LogLevel));
            comboBox_loglevel.SelectedItem = LogLevel.Info;
        }

        public string[] WriteSafeReadAllLines(String path)
        {
            using (var csv = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (var sr = new StreamReader(csv))
            {
                List<string> file = new List<string>();
                while (!sr.EndOfStream)
                {
                    file.Add(sr.ReadLine());
                }

                return file.ToArray();
            }
        }

        public bool isNew(int current, ref int previous)
        {
            bool isNew;
            if (previous == 0)
            {
                isNew = false;
            }
            else if (current != previous)
            {
                isNew = true;
            }
            else
            {
                isNew = false;
            }
            previous = current;
            return isNew;
        }


        private void button_browse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Open Detailed Summary CSV file";
                openFileDialog.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;
                }
            }
            textBox_inputFile.Text = filePath;
        }

        private void button_run_Click(object sender, EventArgs e)
        {
            if (!File.Exists(filePath))
            {
                textBox_output.Text = "Cannot open file. Try loading another detailed summary and press run.";
            }
            else
            {
                //get options
                ReportDuration? reportDuration = comboBox_duration.SelectedValue as ReportDuration?;
                ReportSchedule? reportSchedule = comboBox_schedule.SelectedValue as ReportSchedule?;
                LogLevel? logLevel = comboBox_loglevel.SelectedValue as LogLevel?;

                int[] currentSchedule;
                if (reportSchedule == ReportSchedule.TOU)
                {
                    currentSchedule = ScheduleTOU;
                }
                else if (reportSchedule == ReportSchedule.DayNight)
                {
                    currentSchedule = ScheduleDayNight;
                }
                else
                {
                    currentSchedule = SchedulePeak;
                }

                //read the csv
                string[] lines = WriteSafeReadAllLines(filePath);
                var lineCount = lines.Count();

                if (lineCount > 0)
                {
                    string date = "";
                    EnergyClass energyClass = EnergyClass.Import;
                    int interval = 0;

                    bool isNewYear, isNewMonth;
                    int year;
                    int month;
                    int day;
                    int previousYear = 0;
                    int previousMonth = 0;
                    bool dataPrinted = false;

                    float[] dayData = new float[3];
                    float[] monthData = new float[3];
                    float[] yearData = new float[3];

                    EnergyClass previousEnergyClass = EnergyClass.Import;

                    textBox_output.Text = "";

                    for (int linenum = 0; linenum < lineCount; linenum++)
                    {
                        string[] columns = lines[linenum].Split(',');

                        if (columns[0] == "200") //meta
                        {

                            meterNum = int.Parse(columns[1]);

                            if (columns[3] == "E1")
                            {
                                energyClass = EnergyClass.Import;
                            }
                            else if (columns[3] == "B1")
                            {
                                energyClass = EnergyClass.Export;
                            }
                            else if (columns[3] == "Q1")
                            {
                                energyClass = EnergyClass.ControlledLoad;
                            }
                            else
                            {
                                if (logLevel >= LogLevel.Warn)
                                {
                                    textBox_output.AppendText("Unknown EnergyClass " + columns[3] + " assuming Import\r\n");
                                }
                                energyClass = EnergyClass.Import;
                            }

                            //if energyClass changes create new dates for isNew
                            if (energyClass != previousEnergyClass)
                            {
                                previousYear = previousMonth = -1;
                            }
                            previousEnergyClass = energyClass;


                            interval = int.Parse(columns[8]);

                            if (logLevel >= LogLevel.Debug)
                            {
                                textBox_output.AppendText("Meter: " + meterNum + "  EnergyClass: " + energyClass.ToString() + "  Interval: " + interval + "\r\n");
                            }
                        }
                        else if (columns[0] == "300") //data
                        {
                            dataPrinted = false;

                            date = columns[1];

                            year = int.Parse(date.Substring(0, 4));
                            month = int.Parse(date.Substring(4, 2));
                            day = int.Parse(date.Substring(6, 2));

                            isNewYear = isNew(year, ref previousYear);
                            isNewMonth = isNew(month, ref previousMonth);
                            //isNewDay = isNew(day, ref previousDay); //it is always a new day

                            var intervalsPerHour = 60 / interval;
                            var intervalsPerDay = 24 * intervalsPerHour;

                            float[] hourData = new float[24];

                            if (reportDuration >= ReportDuration.Hourly)
                            {
                                int hour = 0;
                                for (int currentInterval = 0; currentInterval < intervalsPerDay; currentInterval++)
                                {
                                    for (int x = 0; x < intervalsPerHour; x++)
                                    {
                                        hourData[hour] += float.Parse(columns[currentInterval + 2]); //+2 as [0] is 300, [1] is date
                                        currentInterval++;
                                    }
                                    hour++;
                                    currentInterval--; //correction as we are about to do one too many ++
                                }
                                if (reportDuration == ReportDuration.Hourly)
                                {
                                    textBox_output.AppendText(date + "," + energyClass.ToString() + "," + string.Join(",", hourData) + "\r\n");
                                    dataPrinted = true;
                                }
                            }

                            if (reportDuration >= ReportDuration.Daily)
                            {
                                Array.Clear(dayData, 0, dayData.Count());
                                for (int x = 0; x < 24; x++)
                                {
                                    //ignore schedule for export and set all data to Peak?
                                    if (energyClass == EnergyClass.Export)
                                    {
                                        dayData[(int)EnergyBracket.Peak] += hourData[x];
                                    }
                                    else
                                    {
                                        dayData[currentSchedule[x]] += hourData[x];
                                    }
                                }
                                if (reportDuration == ReportDuration.Daily)
                                {
                                    textBox_output.AppendText(date + "," + energyClass.ToString() + "," + string.Join(",", dayData) + "\r\n");
                                    dataPrinted = true;
                                }
                            }

                            if (reportDuration >= ReportDuration.Monthly)
                            {
                                //new month, dump previous total and clear
                                if (isNewMonth)
                                {
                                    if (reportDuration == ReportDuration.Monthly)
                                    {
                                        textBox_output.AppendText(date + "," + energyClass.ToString() + "," + string.Join(",", monthData) + "\r\n");
                                        dataPrinted = true;
                                    }
                                    Array.Clear(monthData, 0, monthData.Count());
                                }


                                for (int x = 0; x < dayData.Count(); x++)
                                {
                                    monthData[x] += dayData[x];
                                }
                            }

                            if (reportDuration >= ReportDuration.Yearly)
                            {
                                //new year, dump previous total and clear
                                if (isNewYear)
                                {
                                    if (reportDuration == ReportDuration.Yearly)
                                    {
                                        textBox_output.AppendText(date + "," + energyClass.ToString() + "," + string.Join(",", yearData) + "\r\n");
                                        dataPrinted = true;
                                    }
                                    Array.Clear(yearData, 0, yearData.Count());
                                }

                                if (isNewMonth)
                                {
                                    for (int x = 0; x < monthData.Count(); x++)
                                    {
                                        yearData[x] += monthData[x];
                                    }
                                }
                            }
                        }
                    }
                    //last entry did not print as there was not a new year/month trigger, force print here
                    if (dataPrinted == false)
                    {
                        if (reportDuration == ReportDuration.Yearly)
                        {
                            //last month also did not get added
                            for (int x = 0; x < monthData.Count(); x++)
                            {
                                yearData[x] += monthData[x];
                            }

                            textBox_output.AppendText(date + "," + energyClass.ToString() + "," + string.Join(",", yearData) + "\r\n");
                            dataPrinted = true;
                        }

                        if (reportDuration == ReportDuration.Monthly)
                        {
                            textBox_output.AppendText(date + "," + energyClass.ToString() + "," + string.Join(",", monthData) + "\r\n");
                            dataPrinted = true;
                        }
                    }
                }
                else // lineCount == 0
                {
                    textBox_output.Text = "No data? Try loading another detailed summary and press run.";
                }
            }
        }

        private void comboBox_duration_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox_duration.SelectedIndex == (int)ReportDuration.Hourly)
            {
                comboBox_schedule.Enabled = false;
            }
            else
            {
                comboBox_schedule.Enabled = true;
            }
        }
    }
}
