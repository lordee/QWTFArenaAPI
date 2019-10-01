
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using qwtfarena.Domain.Repositories;
using qwtfarena.Domain.Services;
using qwtfarena.Persistence.Contexts;
using qwtfarena.Persistence.Repositories;
using qwtfarena.Services;

namespace qwtfarena
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
           
            services.AddEntityFrameworkNpgsql()
                .AddDbContext<AppDbContext>(options => options.UseNpgsql(Configuration["ConnectionStrings:qwtfarenatwo"]))
                .BuildServiceProvider();   

            services.AddScoped<IDiscordVoiceChannelRepository, DiscordVoiceChannelRepository>();
            services.AddScoped<IDiscordVoiceChannelService, DiscordVoiceChannelService>();         

            services.AddScoped<ISSQCStatsRepository, SSQCStatsRepository>();
            services.AddScoped<ISSQCStatsService, SSQCStatsService>();         
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
