using System.ComponentModel.DataAnnotations;

namespace CrudyBot.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class BotCommsContext : DbContext
    {
        // Your context has been configured to use a 'BotCommsContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'CrudyBot.Models.BotCommsContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'BotCommsContext' 
        // connection string in the application configuration file.
        public BotCommsContext()
            : base("name=BotCommsContext")
        {
        }

        public virtual DbSet<BotComm> BotComms { get; set; }
    }

    public class BotComm
    {
        public int Id { get; set; }
        public string MessageText { get; set; }
        public string ResponseText { get; set; }
    }
}