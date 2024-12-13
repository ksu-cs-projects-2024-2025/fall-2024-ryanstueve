There are a few things that are necessary for this project to work.
One is that you need a SQL Server database that is connected with a connection string.
Once you have one of those connected you can add a migration with the RealDbContext and it will set everything up.
Then one last thing that is kind of important to do is I have an admin user that contains the template ClothingItems,
in multiple places in the code it includes that users ID so that those items are visible, so implementing your own
admin with two clothing items should work. You may have to comment out some of the html on the index so that you can add
the clothing items to the admin, but once you've done that you won't have to mess with it again.

Once you have that set up you can just run the program as is and everything should be good!