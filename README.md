# EventFinder2
Finds event logs between two time points. Useful for support/malware analysis.

# About
This program allows you to mark (or set) a beginning and end time period, then grabs all
events between those periods. It dumps these to a sorted CSV on the desktop. 

This program will not read certain logs (Security, Sysmon) without Administrator privileges.

The precursor to this, written in PowerShell, can be found here: https://github.com/BeanBagKing/EventFinder
This was re-written in C# due to the sheer number of events that were written to PowerShell logs when using the script

# Example Use Cases
Support teams can mark a begin time, and perform an action that may cause a crash or
other problem on a workstation. Then mark the end and dump the logs to determin what might
have happened.

A security analyst could use this to run malware (in a contained environment) and determin
via logs what this malware did and in what order, which may be used to create IOC's

# Detailed Usage
* Open a as Administrator
* In the resulting window, click Start Time button
* Perform whatever action that you want to see events for
* Click the End Time button -  At this point (or any other), the time periods can be manually adjusted
* Click Find Events
* Wait while the program generates a CSV of found events on the current desktop - File name will be "Logs_Runtime_\<datestamp>_\<runtime>.csv"

# Screenshot Time!
![EventFinder](https://raw.githubusercontent.com/BeanBagKing/EventFinder/master/EventFinder.png)
