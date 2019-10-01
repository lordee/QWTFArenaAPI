using Microsoft.EntityFrameworkCore;
using qwtfarena.Domain.Models;

namespace qwtfarena.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<DiscordVoiceChannel> DiscordVoiceChannels { get; set; }
        public DbSet<DiscordVoiceUser> DiscordVoiceUsers { get; set; }

        public DbSet<SSQCGameInfo> SSQCGameInfos { get; set; }
        public DbSet<SSQCGameState> SSQCGameStates { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
 
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.Entity<DiscordVoiceChannel>().ToTable("DiscordVoiceChannels");
            builder.Entity<DiscordVoiceChannel>().HasKey(p => p.DiscordVoiceChannelID);
            builder.Entity<DiscordVoiceChannel>().Property(p => p.DiscordVoiceChannelID).IsRequired();
            builder.Entity<DiscordVoiceChannel>().Property(p => p.Name).IsRequired().HasMaxLength(500);
            builder.Entity<DiscordVoiceChannel>().HasMany(p => p.Users).WithOne(p => p.DiscordVoiceChannel).HasForeignKey(p => p.DiscordVoiceChannelID);

            builder.Entity<DiscordVoiceUser>().ToTable("DiscordVoiceUsers");
            builder.Entity<DiscordVoiceUser>().HasKey(p => p.DiscordVoiceUserID);
            builder.Entity<DiscordVoiceUser>().Property(p => p.DiscordVoiceUserID).IsRequired();
            builder.Entity<DiscordVoiceUser>().Property(p => p.Name).IsRequired().HasMaxLength(500);

            builder.Entity<SSQCGameInfo>().ToTable("SSQCGameInfo");
            builder.Entity<SSQCGameInfo>().HasKey(p => p.GameID);
            builder.Entity<SSQCGameInfo>().Property(p => p.GameID).UseNpgsqlIdentityByDefaultColumn();
            builder.Entity<SSQCGameInfo>().Property(p => p.ServerName).IsRequired().HasMaxLength(500);
            builder.Entity<SSQCGameInfo>().Property(p => p.Map).IsRequired().HasMaxLength(500);
            builder.Entity<SSQCGameInfo>().HasMany(p => p.GameStates).WithOne(p => p.SSQCGameInfo).HasForeignKey(p => p.GameID);

            builder.Entity<SSQCGameState>().ToTable("SSQCGameState");
            builder.Entity<SSQCGameState>().HasKey(p => p.GameStateID);
            builder.Entity<SSQCGameState>().Property(p => p.GameStateID).UseNpgsqlIdentityByDefaultColumn();
            builder.Entity<SSQCGameState>().Property(p => p.GameTime).IsRequired();
            builder.Entity<SSQCGameState>().Property(p => p.EventType).IsRequired().HasMaxLength(500);
            builder.Entity<SSQCGameState>().Property(p => p.Initiator).IsRequired().HasMaxLength(500);
        }
    }
}