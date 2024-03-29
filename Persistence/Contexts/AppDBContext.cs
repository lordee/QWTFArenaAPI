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
            builder.Entity<SSQCGameInfo>().HasMany(p => p.Players).WithOne(p => p.SSQCGameInfo).HasForeignKey(p => p.GameID);

            builder.Entity<SSQCGameState>().ToTable("SSQCGameState");
            builder.Entity<SSQCGameState>().HasKey(p => p.GameStateID);
            builder.Entity<SSQCGameState>().Property(p => p.GameStateID).UseNpgsqlIdentityByDefaultColumn();
            builder.Entity<SSQCGameState>().Property(p => p.GameTime).IsRequired();
            builder.Entity<SSQCGameState>().Property(p => p.EventType).IsRequired().HasMaxLength(500);
            builder.Entity<SSQCGameState>().Property(p => p.Initiator).IsRequired().HasMaxLength(500);

            // this is just initial info with gameinfo/gamestate
            builder.Entity<SSQCGamePlayer>().ToTable("SSQCGamePlayer");
            builder.Entity<SSQCGamePlayer>().HasKey(p => p.PlayerID);
            builder.Entity<SSQCGamePlayer>().Property(p => p.PlayerID).UseNpgsqlIdentityByDefaultColumn();
            builder.Entity<SSQCGamePlayer>().Property(p => p.Name).IsRequired().HasMaxLength(500);
            builder.Entity<SSQCGamePlayer>().Property(p => p.Team).IsRequired();
            builder.Entity<SSQCGamePlayer>().Property(p => p.Class).IsRequired();
            builder.Entity<SSQCGamePlayer>().Property(p => p.TF_ID).IsRequired();
            builder.Entity<SSQCGamePlayer>().Property(p => p.Player).IsRequired();
            
            builder.Entity<SSQCPlayerState>().ToTable("SSQCPlayerState");
            builder.Entity<SSQCPlayerState>().HasKey(p => p.PlayerStateID);
            builder.Entity<SSQCPlayerState>().Property(p => p.PlayerStateID).UseNpgsqlIdentityByDefaultColumn();
            builder.Entity<SSQCPlayerState>().Property(p => p.GameID).IsRequired();
            builder.Entity<SSQCPlayerState>().Property(p => p.GameTime).IsRequired();
            builder.Entity<SSQCPlayerState>().Property(p => p.EventType).IsRequired().HasMaxLength(500);
            builder.Entity<SSQCPlayerState>().Property(p => p.EventChange).IsRequired().HasMaxLength(500);
            builder.Entity<SSQCPlayerState>().Property(p => p.TF_ID).IsRequired();

            builder.Entity<SSQCShoot>().ToTable("SSQCShoot");
            builder.Entity<SSQCShoot>().HasKey(p => p.ShootLineID);
            builder.Entity<SSQCShoot>().Property(p => p.ShootLineID).UseNpgsqlIdentityByDefaultColumn();
            builder.Entity<SSQCShoot>().Property(p => p.GameID).IsRequired();
            builder.Entity<SSQCShoot>().Property(p => p.GameTime).IsRequired();
            builder.Entity<SSQCShoot>().Property(p => p.TF_ID).IsRequired();
            builder.Entity<SSQCShoot>().Property(p => p.Shot_ID).IsRequired();
            builder.Entity<SSQCShoot>().Property(p => p.WeaponType).IsRequired().HasMaxLength(500);
            builder.Entity<SSQCShoot>().Property(p => p.DeathType).IsRequired().HasMaxLength(500);
            
            builder.Entity<SSQCDamage>().ToTable("SSQCDamage");
            builder.Entity<SSQCDamage>().HasKey(p => p.DamageLineID);
            builder.Entity<SSQCDamage>().Property(p => p.DamageLineID).UseNpgsqlIdentityByDefaultColumn();
            builder.Entity<SSQCDamage>().Property(p => p.GameID).IsRequired();
            builder.Entity<SSQCDamage>().Property(p => p.GameTime).IsRequired();
            builder.Entity<SSQCDamage>().Property(p => p.Attacker_TF_ID).IsRequired();
            builder.Entity<SSQCDamage>().Property(p => p.Target_TF_ID).IsRequired();
            builder.Entity<SSQCDamage>().Property(p => p.WeaponType).IsRequired().HasMaxLength(500);
            builder.Entity<SSQCDamage>().Property(p => p.Damage).IsRequired();
            builder.Entity<SSQCDamage>().Property(p => p.Shot_ID).IsRequired();
            builder.Entity<SSQCDamage>().Property(p => p.VHeight).IsRequired();
            builder.Entity<SSQCDamage>().Property(p => p.Killed).IsRequired();
            builder.Entity<SSQCDamage>().Property(p => p.DeathType).IsRequired().HasMaxLength(500);
            builder.Entity<SSQCDamage>().Property(p => p.HadFlag).IsRequired();

            builder.Entity<SSQCPlayerAction>().ToTable("SSQCPlayerAction");
            builder.Entity<SSQCPlayerAction>().HasKey(p => p.PlayerActionLineID);
            builder.Entity<SSQCPlayerAction>().Property(p => p.PlayerActionLineID).UseNpgsqlIdentityByDefaultColumn();
            builder.Entity<SSQCPlayerAction>().Property(p => p.GameID).IsRequired();
            builder.Entity<SSQCPlayerAction>().Property(p => p.GameTime).IsRequired();
            builder.Entity<SSQCPlayerAction>().Property(p => p.Action).IsRequired().HasMaxLength(500);
            builder.Entity<SSQCPlayerAction>().Property(p => p.Attacker_TF_ID).IsRequired();
            builder.Entity<SSQCPlayerAction>().Property(p => p.Target_TF_ID).IsRequired();

            builder.Entity<SSQCScoreUpdate>().ToTable("SSQCScoreUpdate");
            builder.Entity<SSQCScoreUpdate>().HasKey(p => p.ScoreUpdateLineID);
            builder.Entity<SSQCScoreUpdate>().Property(p => p.ScoreUpdateLineID).UseNpgsqlIdentityByDefaultColumn();
            builder.Entity<SSQCScoreUpdate>().Property(p => p.GameID).IsRequired();
            builder.Entity<SSQCScoreUpdate>().Property(p => p.GameTime).IsRequired();
            builder.Entity<SSQCScoreUpdate>().Property(p => p.TeamOne).IsRequired();
            builder.Entity<SSQCScoreUpdate>().Property(p => p.TeamTwo).IsRequired();
            builder.Entity<SSQCScoreUpdate>().Property(p => p.TeamThree).IsRequired();
            builder.Entity<SSQCScoreUpdate>().Property(p => p.TeamFour).IsRequired();
        }
    }
}