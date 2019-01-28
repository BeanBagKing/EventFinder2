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

                            // Collect ALL THE THINGS!
                            string Message = eventRecord.FormatDescription();
                            string SystemTime = xml.Root.Element(ns + "System").Element(ns + "TimeCreated").Attribute("SystemTime").Value;
                            string Id = eventRecord.Id.ToString();
                            string Version = eventRecord.Version.ToString();
                            string Qualifiers = eventRecord.Qualifiers.ToString();
                            string Level = eventRecord.Level.ToString();
                            string Task = eventRecord.Task.ToString();
                            string Opcode = eventRecord.Opcode.ToString();
                            string Keywords = eventRecord.Keywords.ToString();
                            string RecordId = eventRecord.RecordId.ToString();
                            string ProviderName = eventRecord.ProviderName;
                            string ProviderID = eventRecord.ProviderId.ToString();
                            string LogName = eventRecord.LogName;
                            string ProcessId = eventRecord.ProcessId.ToString();
                            string ThreadId = eventRecord.ThreadId.ToString();
                            string MachineName = eventRecord.MachineName;
                            string UserID = eventRecord.UserId?.ToString();
                            string TimeCreated = eventRecord.TimeCreated.ToString();
                            string ActivityId = eventRecord.ActivityId.ToString();
                            string RelatedActivityId = eventRecord.RelatedActivityId.ToString();
                            string Hashcode = eventRecord.GetHashCode().ToString();
                            string LevelDisplayName = eventRecord.LevelDisplayName;
                            string OpcodeDisplayName = eventRecord.OpcodeDisplayName;
                            string TaskDisplayName = eventRecord.TaskDisplayName;

                            // Add them to the record. The things equal the things.
                            records.Add(new Record() { Message = Message, SystemTime = SystemTime, Id = Id, Version = Version, Qualifiers = Qualifiers, Level = Level, Task = Task, Opcode = Opcode, Keywords = Keywords, RecordId = RecordId, ProviderName = ProviderName, ProviderID = ProviderID, LogName = LogName, ProcessId = ProcessId, ThreadId = ThreadId, MachineName = MachineName, UserID = UserID, TimeCreated = TimeCreated, ActivityId = ActivityId, RelatedActivityId = RelatedActivityId, Hashcode = Hashcode, LevelDisplayName = LevelDisplayName, OpcodeDisplayName = OpcodeDisplayName, TaskDisplayName = TaskDisplayName });
                        }
                    }
                    catch (UnauthorizedAccessException)
                    {
                        // If you are running as admin, you will get unauthorized for some logs. Hey, I warned you! Nothing to do here.
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