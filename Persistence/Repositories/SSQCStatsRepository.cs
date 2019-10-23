using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using qwtfarena.Domain.Models;
using qwtfarena.Domain.Repositories;
using qwtfarena.Persistence.Contexts;

namespace qwtfarena.Persistence.Repositories
{
    public class SSQCStatsRepository : BaseRepository, ISSQCStatsRepository
    {
        public SSQCStatsRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<int> GameStateChange(int gameid, float gametime, string eventtype, string initiator)
        {
            // insert entry, return data

            SSQCGameState gs = new SSQCGameState
            {
                GameTime = gametime,
                EventType = eventtype,
                Initiator = initiator,
                GameID = gameid
            };
            
            await _context.AddAsync(gs);

            return await _context.SaveChangesAsync();
        }

        public async Task<int> GameStart(GameStateChange gsc)
        {
            SSQCGameInfo gi = new SSQCGameInfo
            {
                ServerName = gsc.ServerName
                , Map = gsc.Map
            };

            // insert entry, return gameid
            SSQCGameState gs = new SSQCGameState
            {
                GameTime = gsc.GameTime,
                EventType = gsc.EventType,
                Initiator = gsc.Initiator
            };
            
            foreach (GamePlayer gp in gsc.Players)
            {
                gi.Players.Add(new SSQCGamePlayer
                {
                    Name = gp.Name,
                    Team = gp.Team,
                    Class = gp.Class,
                    TF_ID = gp.TF_ID,
                    Player = true
                });
            }

            foreach (GamePlayer gp in gsc.Spectators)
            {
                gi.Players.Add(new SSQCGamePlayer
                {
                    Name = gp.Name,
                    Team = gp.Team,
                    Class = gp.Class,
                    TF_ID = gp.TF_ID,
                    Player = false
                });
            }
            
            gi.GameStates.Add(gs);

            await _context.AddAsync(gi);
            _context.SaveChanges();

            return gi.GameID;
        }

        public async Task<int> PlayerStateChange(PlayerStateChange psc, string change)
        {

            // TODO - save players in player table
            SSQCPlayerState ps = new SSQCPlayerState
            {
                GameID = psc.GameID,
                GameTime = psc.GameTime,
                EventType = psc.EventType,
                EventChange = change,
                TF_ID = psc.Player.TF_ID
            };

            await _context.AddAsync(ps);
            
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Shoot(Shoot s)
        {
            SSQCShoot ss = new SSQCShoot
            {
                GameID = s.GameID,
                GameTime = s.GameTime,
                TF_ID = s.TF_ID,
                WeaponType = s.WeaponType,
                Shot_ID = s.Shot_ID,
                DeathType = s.DeathType
            };

            await _context.AddAsync(ss);
            
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Damage(GameDamage d)
        {
            SSQCDamage dd = new SSQCDamage
            {
                GameID = d.GameID,
                GameTime = d.GameTime,
                Attacker_TF_ID = d.Attacker.TF_ID,
                Target_TF_ID = d.Target.TF_ID,
                WeaponType = d.WeaponType,
                Damage = d.Damage,
                Shot_ID = d.Shot_ID,
                VHeight = d.VHeight,
                DeathType = d.DeathType,
                HadFlag = d.HadFlag
            };

            await _context.AddAsync(dd);
            
            return await _context.SaveChangesAsync();
        }

        public async Task<int> PlayerAction(PlayerAction pa)
        {
            SSQCPlayerAction spa = new SSQCPlayerAction
            {
                GameID = pa.GameID,
                GameTime = pa.GameTime,
                Action = pa.Action,
                Attacker_TF_ID = pa.Attacker.TF_ID,
                Target_TF_ID = pa.Target.TF_ID
            };

            await _context.AddAsync(spa);
            
            return await _context.SaveChangesAsync();
        }

        public async Task<int> ScoreUpdate(ScoreUpdate su)
        {
            SSQCScoreUpdate spa = new SSQCScoreUpdate
            {
                GameID = su.GameID,
                GameTime = su.GameTime,
                TeamOne = su.TeamOne,
                TeamTwo = su.TeamTwo,
                TeamThree = su.TeamThree,
                TeamFour = su.TeamFour
            };

            await _context.AddAsync(spa);
            
            return await _context.SaveChangesAsync();
        }
    }
}