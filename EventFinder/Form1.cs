using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Eventing.Reader; // I think this will be needed?
using System.Diagnostics;
using System.Xml;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;
using CsvHelper;

public class Record
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


namespace EventFinder
{
    public partial class FindEvents : Form
    {
        public FindEvents()
        {
            InitializeComponent();



        EventLogSession session = new EventLogSession();
            var providers = session.GetProviderNames().ToList();
            Regex rgx = new Regex(@"^Security$");
            bool AdminFlag = false;

            foreach (string provider in providers)
            {
                if (rgx.IsMatch(provider))
                {
                    AdminFlag = true;
                }
            }

            if (AdminFlag)
            {
                StatusOutput.Text = "Security log found!\nYou are likely administrator";
                StatusOutput.ForeColor = System.Drawing.Color.Green;
            } else
            {
                StatusOutput.Text = "Unable to read Security log.\nAre you administrator?";
                StatusOutput.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            string CurrentTime = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
            StartInput.Text = CurrentTime;
        }

        private void EndButton_Click(object sender, EventArgs e)
        {
            string CurrentTime = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
            EndInput.Text = CurrentTime;
        }

        private void FindEventsButton_Click(object sender, EventArgs e)
        {
            FindEventsButton.Enabled = false;



            

        // Variables we will need
        DateTime StartTime = DateTime.ParseExact(StartInput.Text, "MM/dd/yyyy HH:mm:ss", null);
        DateTime EndTime = DateTime.ParseExact(EndInput.Text, "MM/dd/yyyy HH:mm:ss", null);
        string RunTime = DateTime.Now.ToString("yyyyMMdd_HHmmss");
        string DesktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        EventLogSession Session = new EventLogSession();
        var Providers = Session.GetProviderNames().ToList();

        var query = string.Format(@"*[System[TimeCreated[@SystemTime >= '{0}']]] and *[System[TimeCreated[@SystemTime <= '{1}']]]", StartTime.ToString("o"), EndTime.ToString("o"));

            List<Record> records = new List<Record> { };

            foreach (var Provider in Providers)
            {
                try
                {
                    EventLogQuery eventlogQuery = new EventLogQuery(Provider, PathType.LogName, query);
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

                } catch (EventLogNotFoundException)
                {
                    // No events found - Nothing to be done
                } catch (EventLogException)
                {
                    // Error Reading Provider - Nothing to be done
                }


            }

            records.OrderBy(x => x.SystemTime);

            using (var writer = new StreamWriter(DesktopPath + "\\Logs_Runtime_" + RunTime + ".csv", append: true))
            using (var csv = new CsvWriter(writer))
            {
                csv.Configuration.ShouldQuote = (field, context) => true;
                csv.WriteRecords(records);
            }

            FindEventsButton.Enabled = true;
        }
    }
}
