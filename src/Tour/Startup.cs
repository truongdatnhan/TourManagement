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
using Domain.Interfaces;
using Infrastructure.Persistence.Repositories;
using Application.Interfaces;
using Application.Services;
using System;

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
            /*services.AddControllersWithViews(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                                 .RequireAuthenticatedUser()
                                 .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            }).AddFluentValidation(fv => { fv.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()); });*/

            services.AddControllersWithViews().AddFluentValidation(fv => { fv.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()); });

            /*services.AddIdentity<IdentityUser, IdentityRole>()
             .AddEntityFrameworkStores<TourContext>()
             .AddDefaultTokenProviders();*/

            services.AddDbContextPool<TourContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("TourDB")));

            //services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //EF
            services.AddScoped(typeof(IEFRepository<>), typeof(EFRepository<>));

            
            //ChiPhi
            services.AddScoped<IChiPhiRepository, ChiPhiRepository>();
            services.AddScoped<IChiPhiService, ChiPhiService>();

            //ChiTietDoan
            services.AddScoped<IChiTietDoanRepository, ChiTietDoanRepository>();
            //services.AddScoped<INhanVienService, NhanVienService>();

            //DiaDiem
            services.AddScoped<IDiaDiemRepository, DiaDiemRepository>();
            //services.AddScoped<ITacGiaService, TacGiaService>();

            //DiemThamQuan
            services.AddScoped<IDiemThamQuanRepository, DiemThamQuanRepository>();
            //services.AddScoped<INhaXuatBanService, NhaXuatBanService>();

            //DoanDuLich
            services.AddScoped<IDoanDuLichRepository, DoanDuLichRepository>();
            services.AddScoped<IDoanDuLichService, DoanDuLichService>();

            //GiaTour
            services.AddScoped<IGiaTourRepository, GiaTourRepository>();
            services.AddScoped<IGiaTourService, GiaTourService>();

            //Khach
            services.AddScoped<IKhachRepository, KhachRepository>();
            services.AddScoped<IKhachService, KhachService>();

            //LoaiChiPhi
            services.AddScoped<ILoaiChiPhiRepository, LoaiChiPhiRepository>();
            services.AddScoped<ILoaiChiPhiService, LoaiChiPhiService>();

            //LoaiHinhDuLich
            services.AddScoped<ILoaiHinhDuLichRepository, LoaiHinhDuLichRepository>();
            services.AddScoped<ILoaiHinhDuLichService, LoaiHinhDuLichService>();

            //NhanVien
            services.AddScoped<INhanVienRepository, NhanVienRepository>();
            services.AddScoped<INhanVienService, NhanVienService>();

            //NoiDungTour
            services.AddScoped<INoiDungTourRepository, NoiDungTourRepository>();
            services.AddScoped<INoiDungTourService, NoiDungTourService>();

            //PhanBoNhanVienDoan
            services.AddScoped<IPhanBoNhanVienDoanRepository, PhanBoNhanVienDoanRepository>();
            //services.AddScoped<ITacGiaService, TacGiaService>();

            //TourDuLich
            services.AddScoped<ITourDuLichRepository, TourDuLichRepository>();
            services.AddScoped<ITourDuLichService, TourDuLichService>();

            /*Hiện tại không cần vì không còn dùng Identity
             * services.Configure<IdentityOptions>(options =>
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
            });*/

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
            //app.UseAuthentication();
            //app.UseAuthorization();
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