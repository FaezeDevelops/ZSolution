# Introduction 
This is an WPF application that uses jsonplaceholder API to fetch 100 posts and render them all
where each post is a separate square, 10 rows x 10 columns. 
• By default, id is displayed on each square. When clicking on a square, the id is 
replaced with the user id on all squares.
• When clicking again, ids are shown on all squares and so on...

# Development 
• I used .NetCore 3.1 and .NetStandard 2.0 <br/>
• I logically layered the solution to data, service and presentation (app) layers. <br/>
• I tried to follow MVVM pattern. <br/>
• I configured .NetCore built-in dependency injection and configuration providers. <br/>
• I created a separate API client that can be used across other applications (if any). <br/>

# Getting Started
Configure the endpoints in 'appsettings.json' inside Solution.App.WPF project

# Build and Run
Build and run the soltion via VisualStudio or use dotnet core CLI  

# Contribute
I’ve not implemented everything needed for a production ready application.
If I have a chance to further continue, I would go for the following tasks/features:

• Implement Security (authentication/authorization  mechanism) <br/>
• Improve resilience capabilities (e.g. API client retry/back-off) <br/>
• Configure logging <br/>
• Enhance exception handling <br/>
• Perform testing <br/>
• Improve UX/UI (e.g. navigations/layout/styling) <br/>

Feel free to contribute!
