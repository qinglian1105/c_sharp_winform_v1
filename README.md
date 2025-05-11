# **vue3_echarts_demo_01**

## **Creating an Windows Forms App for backend platform with C# **


### **Ⅰ. Purpose** 

 There are still many companies in Taiwan using C# windows forms to develop information systems or applications, especially ERP related applications. The content of this project is a demo to build a backend platform mainly with C# Windows Forms App (.NET Framework) for the investment statistics of top ETFs in Taiwan.<br><br>

### **Ⅱ. Tools**

Front-End: C# Windows Forms App (.NET Framework 4.8) <br> 
Back-End: FastAPI, PostgreSQL <br>
Other: Selenium, Beautiful Soup, Docker, n8n <br>
<br>

### **Ⅲ. Statement**<br>


__1. The main components of this website__ <br>

This Windows Forms App has side-menu with five options. Only 4 options will be explained.<br>

__● Option -  Home__<br>

Just a simple explanation for this windows forms app.<br>

__● Option - Analytics__<br>

Originally, 8 tabs were expected, but they all used the same method, so only 2 are listed for now. If interested, please refer to the project  [[dash_plotly_demo_01](<https://github.com/qinglian1105/dash_plotly_demo_01>)].<br>

(1)Introduction: just a brief description about this study.<br>
(2)Overview: a dashboard with metrics, charts.<br>

__● Option - Data Status__<br>

Just display a table for checking whether data is inserted successfully or completely.<br>

__● Option - Auth__<br>

It's User Management.<br>

<br>


__2. Data__ <br>

(1)Source <br>
Thanks for the website, "https://www.pocket.tw/etf/", provided by Pocket Securities. This company, one of the best Online Brokers in Taiwan, delivers high-quality services to customers, and its website makes it easier for investors to obtain financial data and useful information.<br>

(2)Web scraping<br>
The targeted data is the holding details, like stocks, bonds and so on, of exchange-traded fund (ETF) in Taiwan. The ETFs are selected according to the standard that they primarily invest in stocks and their asset value is more than one hundred billion (TWD). Therefore, 8 ETFs are selected in this project. Their security codes are '0050', '00878', '0056', '00919', '00929', '006208', '00940' and '00713' respectively.<br>
In addition, the information about ETF ranking by asset value, trading volume and so on, in Taiwan can be read on the website, Yahoo Finance (Taiwan). (Please refer to [details](<https://tw.stock.yahoo.com/tw-etf/total-assets>))<br>
Besides, web scraping is primarily implemented by "Selenium" and "Beautiful Soup", and then data is saved into database. These tasks are built in a workflow by "n8n", as the workflow of ETF tools like Airflow or DolphineScheduler, scheduling and monitoring task execution. As you can see below.<br>

![avatar](./README_png/n8n_workflow_etf_crawler.png)
<br><br>

__3. How programming works__ <br>

This windows forms app is built in three parts.<br>
(1)C# is charge of creating windows forms.<br>
(2)FastAPI gets data from the database, PostgreSQL, and then processes metrics, charts, and tables. (Please refer the project  [[dash_plotly_demo_01](<https://github.com/qinglian1105/dash_plotly_demo_01>)])<br>
(3)The workflow of n8n, as just mentioned, operates periodically for crawling data from the website and saving data into database. The node "Gmail" in workflow will inform the results regardless of whether the workflow executed successfully or not.(Please refer to the similar project  [[n8n_py_js_demo_01](<https://github.com/qinglian1105/n8n_py_js_demo_01>)])<br>

<br>


__4. Results__ <br>

__● Page - Login & Logout__ <br>

Form - login<br>

![avatar](./README_png/login.png)
<br><br>

Form - index: it will appear side menu and content area after logging.<br>

![avatar](./README_png/index.png)
<br><br>

Form - index with menu: click upper left button to open and view items in the menu.<br>

![avatar](./README_png/index_with_menu.png)
<br><br>


After clicking lower left button "Logout", it will display the message box for confirmation to logout.<br>

![avatar](./README_png/logout.png)
<br><br>


__● Page - Home__ <br>

Form - Home: as mentioned above.<br>

![avatar](./README_png/home.png)
<br><br>


__● Option - Analytics__ <br>


As mentioned above, this option is the statistics of top equity ETFs in Taiwan.<br>

(1)Introduction<br>

![avatar](./README_png/analytics_introduction.png)
<br><br>

(2)Overview: a dashboard has a date picker to choose date for metrics and charts.<br>

![avatar](./README_png/analytics_overview.png)
<br><br>

__● Option - Data Status__ <br>

Display the status, including record counts and lastest records, in main tables of database, invest. <br>

![avatar](./README_png/data.png)
<br><br>

__● Option - Auth__ <br>

This is user management. Only authorized personnel can add new users, remove users, update information of users. Besides, Using 'Update' to revise the content of coloum 'Authority' can control users for accessible pages. <br>

![avatar](./README_png/auth.png)
<br><br>

The Drop-down list provides three actions, including Create, Update, and Delete, for operating database. For example, create a new user, qqco.

![avatar](./README_png/auth_create.png)
<br><br>

Then, update information, like Email, Password, and Authority, of this user.

![avatar](./README_png/auth_update.png)
<br><br>

After new adding this user, he or she can login to this platform.

![avatar](./README_png/auth_create_login.png)
<br><br>


Of course, this record can be removed by the action - Delete.

![avatar](./README_png/auth_delete.png)
<br><br>


__The above offers backend platform by window forms with C#, FastAPI and n8n for investment statistics.__ <br>

<br>

---

### **Ⅳ. References**

[1] [使用 C# 在 Visual Studio 中建立 Windows Forms 應用程式](<https://learn.microsoft.com/zh-tw/visualstudio/ide/create-csharp-winform-visual-studio?view=vs-2022>)

[2] [Google Fonts](<https://fonts.google.com/>)

[3] [n8n](<https://n8n.io/>)

[4] [qinglian1105/dash_plotly_demo_01](<https://github.com/qinglian1105/dash_plotly_demo_01>)

[5] [Yahoo Finance(Taiwan) - ETF asset ranking](<https://tw.stock.yahoo.com/tw-etf/total-assets>)

[6] [Pocket Securities - ETF](<https://www.pocket.tw/etf/>)

