# ReportSync
Branch of https://code.google.com/p/reportsync/

Things added in this branch:
1. Saving connection details to the source RS.
2. Bulk updating connections inside reports. 
3. Converting a 2016 report file to work in SSRS2012

# Source Report Server URL 

This is saved to a settings file which is read and populated into the textbox upon the application starting up.

By pressing the right arrow button, the credential will be copied over to the left to Destination web service fields.

# Updating Connection credentials

This allows you to update the connection properties of selected datasources contained in selected reports:

Select the Update Conn radio button at the bottom of the form will hide the right-side treeview.

Enter the connection details for the Report Server at the top, and press load.

Select the reports for which you wish to update datasource connection values.

On the right hand side, press load to fetch the data sources available for the selected reports.

Select which datasource for the selected reports needs updating.

Provide the new username and password.

Press Update Connections at the bottom.

# Converting a 2016 report to run in SSRS2012

You will need a physical .rdl file for this - download using this application, or another method.

Select the *Tools -> Convert rdl to 2012* menu option

On the dialog window, click on the [...] button to browse to an rdl file that needs to be converted.

Once a file is selected, press the Convert button, and provide the location for the new file that will be created.
