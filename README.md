# EventFinder2
Finds event logs between two time points. Useful for support/malware analysis.

Blog: https://nullsec.us/eventfinder2-finding/

# About
This program allows you to mark (bookend) a beginning and end time period, then grabs all
events between those periods. It dumps these to a sorted CSV on the desktop.

This program will not read certain logs (Security, Sysmon, etc.) without Administrator privileges.

The precursor to this, written in PowerShell, can be found here: https://github.com/BeanBagKing/EventFinder.
This was re-written in C# due to the sheer number of events that were written to PowerShell logs when using the script.

# Example Use Cases
A support team member can mark a start time, and perform an action that may cause a crash or
other problem on a workstation. Then mark the end and dump the logs to determin what might
have happened.

A security analyst could use this to run malware (in a contained environment) and determin
via logs what this malware did and in what order, which may be used to create IOC's.

This was developed with the ![Windows RDP-Related Event Logs](https://nullsec.us/windows-rdp-related-event-logs-the-client-side-of-the-story/) use case in mind.

# Detailed Usage
* Open as Administrator
* In the resulting window, click Start Time button
* Perform whatever action that you want to see events for
* Click the End Time button -  At this point (or any other), the time periods can be manually adjusted
* Click Find Events
* Wait while the program generates a CSV of found events on the current desktop - File name will be "Logs_Runtime_\<datestamp>_\<runtime>.csv"

# Demonstration Video
Thanks to Richard Davis of 13cubed for doing a short on usage and demoing the tool!

[![EventFinder2 Demo](https://img.youtube.com/vi/bs756-juO_U/0.jpg)](https://www.youtube.com/watch?v=bs756-juO_U "EventFinder2 Demo")

# Screenshot Time!
![EventFinder](https://raw.githubusercontent.com/BeanBagKing/EventFinder2/master/EventFinder2.jpg)
