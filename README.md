# DataReader<br />
**Created Date:** 4/22/2004<br />
**Last Updated:** 9/29/2004<br />
**Description:** VB.NET Demo using ADO.NET with a DataReader Object and Synergy/DE Connectivity Series<br />
**Platforms:** Windows<br />
**Products:** xfODBC<br />
**Minimum Version:** 9.5.1a<br />
**Author:** Blair Varley
<hr>

**Additional Information:**
Introduction
============
This example includes a Visual Studio .NET 2003 Visual Basic solution called "xfODBC_DataReader_V3", which enables you to view records in the CUSTOMERS table of the sample database (distributed with Connectivity Series).

This solution uses ADO.NET and a DataReader object. The DataReader object is a high-performance, forward-only, read-only stream of data that bypasses the DataSet object to directly communicate with the database.

Requirements
============
* Visual Studio .NET 2003 with Visual Basic .NET and .NET Framework 1.1
* Synergy/DE version 8.1.7 (or higher) with Connectivity Series
* MDAC 2.8 or higher

Instructions
============
1. If it is not already installed, install Synergy/DE version 8.1.7 or higher. Be sure to select Connectivity Series.

2. Make sure the SODBC_ODBCNAME environment variable is NOT set.

3. Generate system catalogs for the sample database. Follow the instructions in chapter 2 ("Using the Sample Database as a Tutorial") of the xfODBC User's Guide. Note that xfODBC_DataReader_V3 uses the following:
-- The sodbc_sa connect file as distributed
-- The DBADMIN user (with the password "MANAGER")
-- The sample DSN (xfODBC) as distributed

4. Open the xfODBC_DataReader_V3.sln file in Visual Studio .NET 2003 Development Environment.

5. Build the solution and run it from Visual Studio .NET 2003 on a local drive (not a mapped drive).

The application has one ListBox control and one button. Click the button to populate the ListBox control with a list of all the records in the sample database's CUSTOMERS table.

To view the source code, open "frmMain.vb" in Visual Studio, and select View Code.
