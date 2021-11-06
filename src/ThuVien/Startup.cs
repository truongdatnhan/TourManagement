using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FluentValidation.AspNetCore;
using System.Reflection;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace ThuVien
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                                 .RequireAuthenticatedUser()
                                 .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            }).AddFluentValidation(fv => { fv.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()); });

            services.AddIdentity<AppUser, AppRole>()
             .AddEntityFrameworkStores<TourContext>()
             .AddDefaultTokenProviders();

            services.AddDbContextPool<TourContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("TourDB")));

            /*//EF
            services.AddScoped(typeof(IEFRepository<>), typeof(EFRepository<>));

            //TheLoai
            services.AddScoped<ITheLoaiRepository, TheLoaiRepository>();
            services.AddScoped<ITheLoaiService, TheLoaiService>();

            //Nhanvien
            services.AddScoped<INhanVienRepository, NhanVienRepository>();
            services.AddScoped<INhanVienService, NhanVienService>();

            //TacGia
            services.AddScoped<ITacGiaRepository, TacGiaRepository>();
            services.AddScoped<ITacGiaService, TacGiaService>();

            //NhaXuatBan
            services.AddScoped<INhaXuatBanRepository, NhaXuatBanRepository>();
            services.AddScoped<INhaXuatBanService, NhaXuatBanService>();

            //Sach
            services.AddScoped<ISachRepository, SachRepository>();
            services.AddScoped<ISachService, SachService>();

            //Account
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IAccountService, AccountService>();

            //DocGia
            services.AddScoped<IDocGiaRepository, DocGiaRepository>();
            services.AddScoped<IDocGiaService, DocGiaService>();

            //PhieuMuon
            services.AddScoped<IPhieuMuonRepository, PhieuMuonRepository>();
            services.AddScoped<IPhieuMuonService, PhieuMuonService>();

            //ChiTietPhieuMuon
            services.AddScoped<IChiTietPhieuMuonRepository, ChiTietPhieuMuonRepository>();

            //PhieuPhat
            services.AddScoped<IPhieuPhatRepository, PhieuPhatRepository>();
            services.AddScoped<IPhieuPhatService, PhieuPhatService>();

            //ChiTietPhieuPhat
            services.AddScoped<IChiTietPhieuPhatRepository, ChiTietPhieuPhatRepository>();

            //TacGia
            services.AddScoped<ITacGiaRepository, TacGiaRepository>();
            services.AddScoped<ITacGiaService, TacGiaService>();

            //Sach
            services.AddScoped<ISachRepository, SachRepository>();
            services.AddScoped<ISachService, SachService>();*/

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                //chỉnh sửa lại quy tắc tạo mật khẩu của Identity
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin",
                    policy => policy.RequireClaim("Role", "Admin"));
                options.AddPolicy("Librarian",
                    policy => policy.RequireClaim("Role", "Librarian"));
                options.AddPolicy("Create Member",
                    policy => policy.RequireClaim("Create Member", "true"));
                options.AddPolicy("Edit Member",
                    policy => policy.RequireClaim("Edit Member", "true"));
                options.AddPolicy("Delete Member",
                    policy => policy.RequireClaim("Delete Member", "true"));
                options.AddPolicy("Create Employee",
                    policy => policy.RequireClaim("Create Employee", "true"));
                options.AddPolicy("Edit Employee",
                    policy => policy.RequireClaim("Edit Employee", "true"));
            });

            services.ConfigureApplicationCookie(config =>
            {
                config.LoginPath = "/Login";
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: default,
                    pattern: "{area:exists}/{controller}/{action}/{id?}");

                endpoints.MapControllerRoute(
                    name: default,
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "Manager",
                    pattern: "Manager",
                    defaults: new { area = "Manager", Controller = "Home", Action = "Index" });
            });
        }
    }
}