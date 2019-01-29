using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Eventing.Reader;
using System.Diagnostics;
using System.Xml;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;
using CsvHelper;
using System.Security.Principal;

namespace EventFinder
{
    public partial class FindEvents : Form
    {
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox box = new AboutBox();
            box.ShowDialog();
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
        public FindEvents()
        {
            InitializeComponent();

            // Check if the User is running as Administrator. Display appropriate text.
            bool isElevated;
            using (WindowsIdentity identity = WindowsIdentity.GetCurrent())
            {
                WindowsPrincipal principal = new WindowsPrincipal(identity);
                isElevated = principal.IsInRole(WindowsBuiltInRole.Administrator);
            }

            if (isElevated)
            {
                StatusOutput.Text = "Running as Administrator.\nRestricted logs will be enumerated.";
                StatusOutput.ForeColor = System.Drawing.Color.Green;
            } else
            {
                StatusOutput.Text = "Not running as Administrator!\nYou will not be able to read Security, etc.";
                StatusOutput.ForeColor = System.Drawing.Color.Red;
            }
        }

        // Get a start time for our filter
        private void StartButton_Click(object sender, EventArgs e)
        {
            string CurrentTime = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
            StartInput.Text = CurrentTime;
        }

        // Get an end time for our filter
        private void EndButton_Click(object sender, EventArgs e)
        {
            string CurrentTime = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
            EndInput.Text = CurrentTime;
        }

        // Our Find Events button, this is where the magic happens
        private void FindEventsButton_Click(object sender, EventArgs e)
        {
            FindEventsButton.Enabled = false;

            if (StartInput.Text == "" || EndInput.Text == "")                   // Check to make sure times are populated
            {
                StatusOutput.Text = "Missing Start or End Time!";
                StatusOutput.ForeColor = System.Drawing.Color.Red;
            } else if (!DateTime.TryParse(StartInput.Text, out DateTime temp))  // And that the start time is valid
            {
                StatusOutput.Text = "Invalid Start Time";
                StatusOutput.ForeColor = System.Drawing.Color.Red;
            } else if (!DateTime.TryParse(EndInput.Text, out DateTime temp2))   // And that the end time is valid
            {
                StatusOutput.Text = "Invalid End Time";
                StatusOutput.ForeColor = System.Drawing.Color.Red;
            } else                                                              // If everything is valid, run!
            {


                // Variables we will need
                DateTime StartTime = DateTime.ParseExact(StartInput.Text, "MM/dd/yyyy HH:mm:ss", null); // Needed for filter query
                DateTime EndTime = DateTime.ParseExact(EndInput.Text, "MM/dd/yyyy HH:mm:ss", null);     // Needed for filter query
                string DesktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);      // Needed for file name
                string RunTime = DateTime.Now.ToString("yyyyMMdd_HHmmss");                              // Needed for file name
                EventLogSession Session = new EventLogSession();
                var Logs = Session.GetLogNames().ToList();
                var query = string.Format(@"*[System[TimeCreated[@SystemTime >= '{0}']]] and *[System[TimeCreated[@SystemTime <= '{1}']]]", StartTime.ToUniversalTime().ToString("o"), EndTime.ToUniversalTime().ToString("o"));
                List<Record> records = new List<Record> { };                                            // Start a list for all those sweet sweet logs we're going to get 

                foreach (var Log in Logs)
                {
                    try
                    {
                        EventLogQuery eventlogQuery = new EventLogQuery(Log, PathType.LogName, query);
                        EventLogReader eventlogReader = new EventLogReader(eventlogQuery);

                        for (EventRecord eventRecord = eventlogReader.ReadEvent(); null != eventRecord; eventRecord = eventlogReader.ReadEvent())
                        {
                            // Get the SystemTime from the event record XML 
                            var xml = XDocument.Parse(eventRecord.ToXml());
                            XNamespace ns = xml.Root.GetDefaultNamespace();

                            string Message = "";
                            string SystemTime = "";
                            string Id = "";
                            string Version = "";
                            string Qualifiers = "";
                            string Level = "";
                            string Task = "";
                            string Opcode = "";
                            string Keywords = "";
                            string RecordId = "";
                            string ProviderName = "";
                            string ProviderID = "";
                            string LogName = "";
                            string ProcessId = "";
                            string ThreadId = "";
                            string MachineName = "";
                            string UserID = "";
                            string TimeCreated = "";
                            string ActivityId = "";
                            string RelatedActivityId = "";
                            string Hashcode = "";
                            string LevelDisplayName = "";
                            string OpcodeDisplayName = "";
                            string TaskDisplayName = "";

                            // Debugging Stuff
                            //Console.WriteLine("-- STARTING --");
                            // Try to collect all the things. Catch them if we can't.
                            // Sometimes fields are null or cannot be converted to string (why?).
                            // If they are, catch and do nothing, so they will stay empty ("").
                            // This has primarily been LevelDisplayName, OpcodeDisplayName, and TaskDisplayName
                            // but we'll catch it all anyway
                            // https://github.com/BeanBagKing/EventFinder2/issues/1
                            try
                            {
                                Message = eventRecord.FormatDescription();
                            }
                            catch
                            {
                                //Console.WriteLine("Error on FormatDescription");
                          }
                            try
                            {
                                SystemTime = xml.Root.Element(ns + "System").Element(ns + "TimeCreated").Attribute("SystemTime").Value;
                            }
                            catch
                            {
                                //Console.WriteLine("Error on SystemTime");
                          }
                            try
                            {
                                Id = eventRecord.Id.ToString();
                            }
                            catch
                            {
                                //Console.WriteLine("Error on Id");
                          }
                            try
                            {
                                Version = eventRecord.Version.ToString();
                            }
                            catch
                            {
                                //Console.WriteLine("Error on Version");
                          }
                            try
                            {
                                Qualifiers = eventRecord.Qualifiers.ToString();
                            }
                            catch
                            {
                                //Console.WriteLine("Error on Qualifiers");
                          }
                            try
                            {
                                Level = eventRecord.Level.ToString();
                            }
                            catch
                            {
                                //Console.WriteLine("Error on Level");
                          }
                            try
                            {
                                Task = eventRecord.Task.ToString();
                            }
                            catch
                            {
                                //Console.WriteLine("Error on Task");
                          }
                            try
                            {
                                Opcode = eventRecord.Opcode.ToString();
                            }
                            catch
                            {
                                //Console.WriteLine("Error on Opcode");
                          }
                            try
                            {
                                Keywords = eventRecord.Keywords.ToString();
                            }
                            catch
                            {
                                //Console.WriteLine("Error on Keywords");
                          }
                            try
                            {
                                RecordId = eventRecord.RecordId.ToString();
                            }
                            catch
                            {
                                //Console.WriteLine("Error on RecordId");
                          }
                            try
                            {
                                ProviderName = eventRecord.ProviderName;
                            }
                            catch
                            {
                                //Console.WriteLine("Error on ProviderName");
                          }
                            try
                            {
                                ProviderID = eventRecord.ProviderId.ToString();
                            }
                            catch
                            {
                                //Console.WriteLine("Error on ProviderId");
                          }
                            try
                            {
                                LogName = eventRecord.LogName;
                            }
                            catch
                            {
                                //Console.WriteLine("Error on LogName");
                          }
                            try
                            {
                                ProcessId = eventRecord.ProcessId.ToString();
                            }
                            catch
                            {
                                //Console.WriteLine("Error on ProcessId");
                          }
                            try
                            {
                                ThreadId = eventRecord.ThreadId.ToString();
                            }
                            catch
                            {
                                //Console.WriteLine("Error on ThreadId");
                          }
                            try
                            {
                                MachineName = eventRecord.MachineName;
                            }
                            catch
                            {
                                //Console.WriteLine("Error on eventRecord");
                          }
                            try
                            {
                                UserID = eventRecord.UserId?.ToString();
                            }
                            catch
                            {
                                //Console.WriteLine("Error on UserId");
                          }
                            try
                            {
                                TimeCreated = eventRecord.TimeCreated.ToString();
                            }
                            catch
                            {
                                //Console.WriteLine("Error on TimeCreated");
                          }
                            try
                            {
                                ActivityId = eventRecord.ActivityId.ToString();
                            }
                            catch
                            {
                                //Console.WriteLine("Error on ActivityId");
                          }
                            try
                            {
                                RelatedActivityId = eventRecord.RelatedActivityId.ToString();
                            }
                            catch
                            {
                                //Console.WriteLine("Error on RelatedActivityId");
                          }
                            try
                            {
                                Hashcode = eventRecord.GetHashCode().ToString();
                            }
                            catch
                            {
                                //Console.WriteLine("Error on GetHashCode");
                          }
                            try
                            {
                                LevelDisplayName = eventRecord.LevelDisplayName;
                            }
                            catch
                            {
                                //Console.WriteLine("Error on LevelDisplayName");
                          }
                            try
                            {
                                OpcodeDisplayName = eventRecord.OpcodeDisplayName;
                            }
                            catch
                            {
                                //Console.WriteLine("Error on OpcodeDisplayName");
                          }
                            try
                            {
                                TaskDisplayName = eventRecord.TaskDisplayName;
                            }
                            catch
                            {
                                //Console.WriteLine("Error on TaskDisplayName");
                          }
                            //Console.WriteLine("-- ENDING --");

                            // Add them to the record. The things equal the things.
                            records.Add(new Record() { Message = Message, SystemTime = SystemTime, Id = Id, Version = Version, Qualifiers = Qualifiers, Level = Level, Task = Task, Opcode = Opcode, Keywords = Keywords, RecordId = RecordId, ProviderName = ProviderName, ProviderID = ProviderID, LogName = LogName, ProcessId = ProcessId, ThreadId = ThreadId, MachineName = MachineName, UserID = UserID, TimeCreated = TimeCreated, ActivityId = ActivityId, RelatedActivityId = RelatedActivityId, Hashcode = Hashcode, LevelDisplayName = LevelDisplayName, OpcodeDisplayName = OpcodeDisplayName, TaskDisplayName = TaskDisplayName });
                        }
                    }
                    catch (UnauthorizedAccessException)
                    {
                        // If you are running as admin, you will get unauthorized for some logs. Hey, I warned you! Nothing to do here.
                        // Catching this seperately since we know what happened.
                    }
                    catch (Exception ex)
                    {
                        if (Log.ToString().Equals("Microsoft-RMS-MSIPC/Debug"))
                        {
                            // Known issue, do nothing
                            // https://github.com/BeanBagKing/EventFinder2/issues/3
                        }
                        else if (Log.ToString().Equals("Microsoft-Windows-USBVideo/Analytic"))
                        {
                            // Known issue, do nothing
                            // https://github.com/BeanBagKing/EventFinder2/issues/2
                        }
                        else
                        {
                            // Unknown issue! Write us a bug report
                            bool isElevated;
                            using (WindowsIdentity identity = WindowsIdentity.GetCurrent())
                            {
                                WindowsPrincipal principal = new WindowsPrincipal(identity);
                                isElevated = principal.IsInRole(WindowsBuiltInRole.Administrator);
                            }
                            using (StreamWriter writer = new StreamWriter(DesktopPath + "\\ERROR_EventFinder_" + RunTime + ".txt", append: true))
                            {
                                writer.WriteLine("-----------------------------------------------------------------------------");
                                writer.WriteLine("Issue Submission: https://github.com/BeanBagKing/EventFinder2/issues");
                                writer.WriteLine("Date : " + DateTime.Now.ToString());
                                writer.WriteLine("Log : " + Log);
                                writer.WriteLine("Admin Status: " + isElevated);
                                writer.WriteLine();

                                while (ex != null)
                                {
                                    writer.WriteLine(ex.GetType().FullName);
                                    writer.WriteLine("Message : " + ex.Message);
                                    writer.WriteLine("StackTrace : " + ex.StackTrace);
                                    writer.WriteLine("Data : " + ex.Data);
                                    writer.WriteLine("HelpLink : " + ex.HelpLink);
                                    writer.WriteLine("HResult : " + ex.HResult);
                                    writer.WriteLine("InnerException : " + ex.InnerException);
                                    writer.WriteLine("Source : " + ex.Source);
                                    writer.WriteLine("TargetSite : " + ex.TargetSite);

                                    ex = ex.InnerException;
                                }
                            }
                        }
                    }

                }

                records.OrderBy(x => x.SystemTime); // Sort our records in chronological order
                // and write them to a CSV
                using (var writer = new StreamWriter(DesktopPath + "\\Logs_Runtime_" + RunTime + ".csv", append: true))
                using (var csv = new CsvWriter(writer))
                {
                    csv.Configuration.ShouldQuote = (field, context) => true;
                    csv.WriteRecords(records);
                }
                StatusOutput.Text = "Run Complete";
                StatusOutput.ForeColor = System.Drawing.Color.Blue;
                records.Clear();
            }
            FindEventsButton.Enabled = true;
        }

    }
}

public class Record // All the things that will be used in our CSV later.
{
    public string Message { get; set; }
    public string SystemTime { get; set; }
    public string Id { get; set; }
    public string Version { get; set; }
    public string Qualifiers { get; set; }
    public string Level { get; set; }
    public string Task { get; set; }
    public string Opcode { get; set; }
    public string Keywords { get; set; }
    public string RecordId { get; set; }
    public string ProviderName { get; set; }
    public string ProviderID { get; set; }
    public string LogName { get; set; }
    public string ProcessId { get; set; }
    public string ThreadId { get; set; }
    public string MachineName { get; set; }
    public string UserID { get; set; }
    public string TimeCreated { get; set; }
    public string ActivityId { get; set; }
    public string RelatedActivityId { get; set; }
    public string Hashcode { get; set; }
    public string MatchedQueryIds { get; set; }
    public string LevelDisplayName { get; set; }
    public string OpcodeDisplayName { get; set; }
    public string TaskDisplayName { get; set; }
}