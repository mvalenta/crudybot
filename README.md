# crudybot
Bot Framework using simple CRUD app interface for messages


SETUP:
1. Clone Repo
2. Build solution
3. Run T4MVC (Right click T4MVC.tt -> Run Custom Tool)
4. (Optional) Set connection string to SQL database (eg, Azure)
4 1/2. If you do not set a connection to a SQL database, CrudyBot might not work when deployed to an actual server

That's it. You'll be able to hit the end point of your localhost using Bot Framework's emulator located here:
http://download.botframework.com/botconnector/tools/emulator/publish.htm

Additionally, you may want to use your bot outside of just running locally. If this is the case, do the following steps:
1. Deploy web app somewhere (such as Azure)
2. Register your bot here: https://dev.botframework.com/bots/new
3. Update your AppId and AppSecret in Web.Config and redeploy
4. You can then use Bot Framework's Bot Connectors to create actual instances of your bot to interface with apps (such as Slack)
 
USE:
It's a basic CRUD app... "Message Text" is what the bot will look for, and "Response Text" is what will be sent back as a response.

WHY:
While CrudyBot is just that, it's good for spinning up a basic bot fast to handle simple communications. Most bots already do simple things like sending messages regarding contact info. 

FUTURE ENHANCEMENTS (in no particular order):
1. Simplify creation of image replys
2. Include LUIS examples
3. Include examples of custom uses (such as a !raffle capability)
