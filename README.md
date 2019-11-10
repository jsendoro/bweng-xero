# How to run the solution
- Clone the repo
- Open the solution file
- Set BwengXero.WebApp as the start-up project
- Restore nuget package
- Run the solution

# How to download list of Accounts / Contacts
- Click "Connect to Xero" button, then enter your Xero's account. You will be redirected to the Organisation page.
- Click the "Get All Organisations's Accounts" / "Get All Organisations's Vendors" to see the list of all accounts / vendors for that organisation
- Click the "Download data as json" to download a file containing the list of accounts / vendors in json format

# Notes regarding the solution
- I use VS 2019 as the IDE
- I have included bin/roslyn folder also in ths solution just in case   
- The solution is build based on the Xero's sample MVC app that can be found in their github (https://github.com/XeroAPI/Xero-Net)
- I didn't change the code that is related to the sample MVC app that much. What i did mostly is separating the code between the presentation layer (ie the MVC app) and the data layer (ie Xero API wrapper).
- I settled to download the file in json format because it's the easiest that i can do for now. To be honest, store the data on disk can also means database.. so maybe insetad of download as file, it need to be stored in database.
- Configuration values, like callback url, api key, api secret can be changed in Web.config OR XeroApiHelper.cs file in BwengXero.Core
- The Xero app is specifed as a public app right now. If the type of the app changed, the code in XeroApiHelper need to be changed also

# Known / Possible bugs:
- If you try to go to '/Organisation' or any of it's sub-pages by typing the url directly in the browser after starting the app, it will throw out exception
- The MVC app was never tested with a client that have huge data. Ideally i will need to add paging when showing the data in table format
- No logging has been implemented yet

# Business Requirements that can come up
- User can filter which column that should be included or excluded when downloading the file
- User can choose to download in multiple file type (json, csv, pdf, etc)
- User can also choose to push the account & vendor data to a databse ? this is my assumption since storing the data on disk can also means database